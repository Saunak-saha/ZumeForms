using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Parser;
using System.Threading.Tasks;
using Janus.Windows.GridEX;

namespace ZumeForms.Word.UserControls {
    public partial class ConditionalRegionFilter : UserControl {

        public event System.EventHandler ConditionChanged;
        public static bool radDocFieldsChecked {  get; set; }
        public static bool isUserFormSelected {  get; set; }
        public static GridEX GridEXNew {  get; set; }
        public ConditionalRegionFilter() {
            InitializeComponent();
        }

        public String Filter {
            get {
                String retval = "";                
                if (filterEditor1.FilterCondition != null) {

                    // Need to add '' around values
                    String filter = filterEditor1.FilterCondition.ToString();
                    retval = CleanFilter((Janus.Windows.GridEX.IFilterCondition)filterEditor1.FilterCondition, filter);
                }
                retval = txtFilter.Text ;
                return retval;
            }
            set {
                txtFilter.Text = value;
                LoadFilter(value);
            }
        }

        private void ConditionalRegionFilter_Load(object sender, EventArgs e) {
            LoadFields();
        }

        public void LoadFields(bool isFormSelected = false) {

            
            if (radDocFields.Checked && !isFormSelected) {
                radDocFieldsChecked = false;
                Classes.FormFields.LoadFieldListFromDocument();
                Classes.FormFields.Fields.Clear();

                gridEX1.DataMember = "Form";
                gridEX1.DataSource = Classes.FormFields.FieldFormDataSet;

                //Clean Tables
                gridEX1.RetrieveStructure(true);
                CleanTable(gridEX1.RootTable);

            }
            else {
                radDocFieldsChecked = true;

                if (Classes.Application.frmZumeForm.IsDisposed) { Classes.Application.frmZumeForm = new Word.Forms.UserForms(); }
                Classes.Application.frmZumeForm.Show();
                Classes.Application.frmZumeForm.BringToFront();
                Classes.FormFields.Fields.Clear();

                if (Classes.Application.frmZumeForm.Fields != null)
                {
                    foreach (System.Xml.Linq.XElement xfield in Classes.Application.frmZumeForm.Fields.Descendants())
                    {
                        String strField = xfield.Name.LocalName;
                        Classes.FormField datafld = new Classes.FormField();

                        if (xfield.Attribute("FieldName") == null)
                        {
                            String fldname = ""; IEnumerable<WordFusion.Assembly.MailMerge.MergeFieldSwitch> switches;
                            Classes.MailMerge.ParseMergeFieldValue(strField, out fldname, out switches);
                            datafld.Field = fldname; datafld.FieldType = "WordFusion.Controls.Text";
                            Classes.FormFields.Fields.Add(datafld);
                        }
                    }
                    gridEX1.DataMember = "Form";
                    gridEX1.DataSource = Classes.FormFields.FieldFormDataSet;
                }

                gridEX1.RetrieveStructure(true);
                GridEXNew = gridEX1;
                CleanTable(gridEX1.RootTable);
            }
        }

        private void CleanTable(Janus.Windows.GridEX.GridEXTable parenttable) {

            foreach (Janus.Windows.GridEX.GridEXTable childtbl in parenttable.ChildTables) {
                if (childtbl.Columns.Contains("ico")) childtbl.Columns["ico"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                if (childtbl.Columns.Contains("Name")) childtbl.Columns["Name"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                if (childtbl.Columns.Contains("Type")) childtbl.Columns["Type"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                if (childtbl.Columns.Contains("ParentName")) childtbl.Columns["ParentName"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                if (childtbl.Columns.Contains("Field Name")) childtbl.Columns["Field Name"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;

                if (childtbl.Columns.Contains("Field Name")) childtbl.Columns["Field Name"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                if (childtbl.Columns.Contains("In Form")) childtbl.Columns["In Form"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                if (childtbl.Columns.Contains("In Doc")) childtbl.Columns["In Doc"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;

              CleanTable(childtbl);
            }

        }

        private void filterEditor1_FilterConditionChanged(object sender, EventArgs e) {

            if (filterEditor1.FilterCondition != null) {
                //txtFilter.Text = filterEditor1.FilterCondition.ToString();

                String filter = filterEditor1.FilterCondition.ToString();
                txtFilter.Text = CleanFilter((Janus.Windows.GridEX.IFilterCondition)filterEditor1.FilterCondition, filter);

                if (ConditionChanged != null) {
                    ConditionChanged(sender, e);
                }
            }           
        }

        private Boolean isContainerCondition = true;

        private void LoadFilter(String Value) {

            if (Value == "" || Value == null) return;

            // Get XML From Here
            SqlParser myParser = new SqlParser();
            myParser.Parse(Value);

            if (myParser.ParsedDocument.DocumentElement.ChildNodes.Count > 0) {

                XmlNode startnode = getStartNode(myParser.ParsedDocument.DocumentElement.ChildNodes[0]);
                XmlNode endnode = null;
                                                
                Janus.Windows.GridEX.GridEXFilterCondition parentcond = LoadCond(startnode, ref endnode);
                Janus.Windows.GridEX.GridEXFilterCondition containercond = parentcond;
 
                Janus.Windows.GridEX.LogicalOperator op =  GetLogicalOperator(endnode);

                XmlNode nextnode = getNextStartNode(endnode);

                while (nextnode != null) {
                    Janus.Windows.GridEX.GridEXFilterCondition cond = LoadCond(nextnode, ref endnode);                   
                    
                    // Need to know what Condition to add it too
                    containercond.AddCondition(cond);

                    cond.LogicalOperator = op;
                    if (isContainerCondition) containercond = cond;
                    
                    nextnode = getNextStartNode(endnode);
                    op = GetLogicalOperator(endnode);
                                              
                }

                filterEditor1.FilterCondition = parentcond;
               
            }
        }

        private Janus.Windows.GridEX.GridEXFilterCondition LoadCond(XmlNode startnode,ref XmlNode endnode) {

            Janus.Windows.GridEX.GridEXFilterCondition retval = new Janus.Windows.GridEX.GridEXFilterCondition();

            XmlNode fldnode = getFieldNode(startnode);
            String colname = fldnode.Attributes["Value"].Value;

            if (! gridEX1.RootTable.Columns.Contains(colname)) {
                Classes.FormFields.addField(colname);
                LoadFields();
            }

            retval.Column = gridEX1.RootTable.Columns[colname];
            
            // Parse the Supported condition operators
            XmlNode nodeoperator = getOperatorNode(fldnode);                       
            retval.ConditionOperator = GetConditionalOperator(nodeoperator);

            // Get the Value to compare
            endnode = getValueNode(nodeoperator); 
            String value = endnode.Attributes["Value"].Value;
            retval.Value1 = value;

            return retval;

        }

        private XmlNode getStartNode(XmlNode startnode) {

            XmlNode retval = startnode;

            while (isBraces(retval)) {
                retval = retval.ChildNodes[0];
            }

            return retval;
        }

        private XmlNode getNextStartNode(XmlNode endnode) {

            XmlNode retval = null;
            isContainerCondition = false;

            if (isLogicalOperator(endnode.NextSibling)) {
                // is a flat statement
                retval = endnode.NextSibling.NextSibling;
            }
            else {
                // Is nested in brackets
                XmlNode node = endnode.ParentNode.NextSibling;
                if (isLogicalOperator(node)) {
                    node = node.NextSibling;
                    if (isBraces(node)) {
                        retval = node.ChildNodes[0];
                        if (isBraces(retval)) {
                            isContainerCondition = true;
                            retval = retval.ChildNodes[0];
                        }
                    }
                }
            }

            return retval;
        }

        private XmlNode getFieldNode(XmlNode startnode) {

            XmlNode retval = startnode;

            while (isSquareBracesStart(retval)) {
                retval = retval.NextSibling;
            }

            return retval;
        }

        private XmlNode getOperatorNode(XmlNode valuenode) {

            XmlNode retval = valuenode.NextSibling;

            while (isSquareBracesEnd(retval)) {
                retval = retval.NextSibling;
            }

            return retval;
        }

        private XmlNode getValueNode(XmlNode operatornode) {

            // Needto cater for <>
            XmlNode retval = operatornode.NextSibling;

            XmlAttribute att = operatornode.Attributes["Type"];

            while (retval != operatornode.ParentNode.LastChild && att != null) {               
                retval = retval.NextSibling;
            }

            return retval;
        }

        private Janus.Windows.GridEX.ConditionOperator GetConditionalOperator (XmlNode node){

            Janus.Windows.GridEX.ConditionOperator retval = Janus.Windows.GridEX.ConditionOperator.Equal;

            String oper = "";
            XmlAttribute att = node.Attributes["Type"];

            while (att == null) {
                oper += node.Attributes["Value"].Value;

                // if the next node is the end then you have the operator
                if (node.NextSibling == node.ParentNode.LastChild) break;
                
                node = node.NextSibling;
                att = node.Attributes["Type"];
            }

            if (oper == ">") retval = Janus.Windows.GridEX.ConditionOperator.GreaterThan;
            if (oper == "<") retval = Janus.Windows.GridEX.ConditionOperator.LessThan;
            if (oper == "<=") retval = Janus.Windows.GridEX.ConditionOperator.LessThanOrEqualTo;
            if (oper == ">=") retval = Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo;
            if (oper == "<>") retval = Janus.Windows.GridEX.ConditionOperator.NotEqual;
            if (oper.ToLower() == "beginswith") retval = Janus.Windows.GridEX.ConditionOperator.BeginsWith;
            if (oper.ToLower() == "endswith") retval = Janus.Windows.GridEX.ConditionOperator.EndsWith;
            if (oper.ToLower() == "contains") retval = Janus.Windows.GridEX.ConditionOperator.Contains;

            return retval;

        }

        private Janus.Windows.GridEX.LogicalOperator GetLogicalOperator(XmlNode endnode) {

            Janus.Windows.GridEX.LogicalOperator retval = Janus.Windows.GridEX.LogicalOperator.None;
            String val = "";

            if (isLogicalOperator(endnode)) {
                val = endnode.Attributes.GetNamedItem("Value").Value.ToLower();
            }
            else {
                XmlNode nextsibling = endnode.NextSibling;
                if (nextsibling != null) {
                    if (isLogicalOperator(nextsibling)) {
                        val = nextsibling.Attributes.GetNamedItem("Value").Value.ToLower();
                    }
                }
                else {
                    if (isBraces(endnode.ParentNode)) {

                        nextsibling = endnode.ParentNode.NextSibling;
                        if (isLogicalOperator(nextsibling)) {
                            val = nextsibling.Attributes.GetNamedItem("Value").Value.ToLower();
                        }                        
                    }
                }
            }

            if (val == "or") retval = Janus.Windows.GridEX.LogicalOperator.Or;
            if (val == "and") retval = Janus.Windows.GridEX.LogicalOperator.And;

            return retval;

        }

        private Boolean isBraces(XmlNode node) {
            Boolean retval = false;
            System.Xml.XmlNode att = node.Attributes.GetNamedItem("Type");
            if (att != null) {
                if (att.Value == "BRACES") {
                    retval = true; 
                }
            }
            return retval;
        }

        private Boolean isSquareBracesStart(XmlNode node) {
            Boolean retval = false;
            System.Xml.XmlNode att = node.Attributes.GetNamedItem("Value");
            if (att != null) {
                if (att.Value == "[") {
                    retval = true;
                }
            }
            return retval;
        }

        private Boolean isSquareBracesEnd(XmlNode node) {
            Boolean retval = false;
            System.Xml.XmlNode att = node.Attributes.GetNamedItem("Value");
            if (att != null) {
                if (att.Value == "]") {
                    retval = true;
                }
            }
            return retval;
        }

        private Boolean isParentBraces(XmlNode node) {
            Boolean retval = false;
            System.Xml.XmlNode att = node.Attributes.GetNamedItem("Type");
            if (att != null) {
                if (att.Value == "BRACES") {
                    if (node.ChildNodes[0].Attributes.GetNamedItem("Type") != null) {
                        if (node.ChildNodes[0].Attributes.GetNamedItem("Type").Value == "BRACES") {
                            retval = true;
                        }
                    }
                }
            }
            return retval;
        }

        private Boolean isLogicalOperator(XmlNode node) {
            Boolean retval = false;

            if (node != null) {
                System.Xml.XmlNode att = node.Attributes.GetNamedItem("Value");
                if (att != null) {
                    if (att.Value.ToLower() == "and" || att.Value.ToLower() == "or") {
                        retval = true;
                    }
                }
            }

            return retval;
        }

        private Janus.Windows.GridEX.LogicalOperator getLogicalOperator(XmlNode  node) {
            Janus.Windows.GridEX.LogicalOperator retval = Janus.Windows.GridEX.LogicalOperator.And;
            string logicaloperator = node.Attributes["Value"].Value;
            switch (logicaloperator) {
                case "And":
                    retval = Janus.Windows.GridEX.LogicalOperator.And;
                    break;
                case "Or":
                    retval = Janus.Windows.GridEX.LogicalOperator.Or;
                    break;
            }
            return retval;
        }

        private String CleanFilter(Janus.Windows.GridEX.IFilterCondition conparent, String filter) {

            String retval = filter;

            if (conparent.FilterCondition.Value1 != null) {

                String val = (String)conparent.FilterCondition.Value1;
                val = val.Trim('\'');

                String cond = "Contains";
                bool HasContains = false;

                if (retval.IndexOf(cond, StringComparison.OrdinalIgnoreCase) != -1){
                    HasContains = true;
                };

                if (HasContains == true){
                    filter = filter.Replace(" " + val + ")", " '*" + val + "*')");
                };

                filter = filter.Replace(" " + val + ")", " '" + val + "')");
                filter = filter.Replace(" " + val + " )", " '" + val + "')");
                filter = filter.Replace(" " + val + " ", " '" + val + "'");

                if (conparent.FilterCondition.Value2 != null) {
                    val = (String)conparent.FilterCondition.Value2;
                    val = val.Trim('\'');
                    filter = filter.Replace(val, "'" + val + "'");
                }

                foreach (Janus.Windows.GridEX.GridEXFilterCondition con in conparent.FilterCondition.Conditions) {
                    filter = CleanFilter(con, filter);
                }
            }

            retval = filter.Replace("And (Empty)", "");
            retval = retval.Replace("''''", "'");
            retval = retval.Replace("'''", "'");
            retval = retval.Replace("''", "'");
            retval = retval.Replace("{null}", "''");
            return retval;
        }

        private void filterEditor1_KeyUp(object sender, KeyEventArgs e) {
            if(filterEditor1.FilterCondition != null) txtFilter.Text = filterEditor1.FilterCondition.ToString();
        }

        private void radFormFields_CheckedChanged(object sender, EventArgs e) {
            LoadFields();
        }

        private void radDocFields_CheckedChanged(object sender, EventArgs e) {
   
        }

    }
}
