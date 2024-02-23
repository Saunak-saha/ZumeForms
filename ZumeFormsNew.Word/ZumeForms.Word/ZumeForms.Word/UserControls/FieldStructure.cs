using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using WordFusion.Assembly.MailMerge;
using Aspose.Words;
 
namespace ZumeForms.Word.UserControls {
    public partial class FieldStructure : UserControl {

        private WordFusion.Assembly.MailMerge.MailMerge MailMerge;
        public Collection<Exception> Errors = new Collection<Exception>();
        public event TreeViewEventHandler RegionSelected;

        public FieldStructure() {
            InitializeComponent();
        }

        private void DocumentTree_Load(object sender, EventArgs e) {
            treeView1.Nodes[0].Expand();
        }

        String _filename = "";
        public String FileName {
            get {
                return _filename;
            }
            set {
                _filename = value;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            FieldStructureLoad();
        }
        
        public Boolean FieldStructureLoad() {

            Boolean retval = true;

            //SystemFramework.Progress frmprogress = CheckingFieldsMonitor();
            //frmprogress.Show();

            fldstarts.Clear();

            try {

                treeView1.Nodes[0].Nodes.Clear();
                TreeNode parentnode = treeView1.Nodes[0];

                foreach (Microsoft.Office.Interop.Word.Field fld in Classes.Application.App.ActiveDocument.Fields) {
                    if (fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldMergeField) {
                        LoadField(fld, ref parentnode);
                        //frmprogress.Refresh();
                    }
                }
                treeView1.Nodes[0].Expand();
            }
            catch (Exception ex) {
                retval = false;
                MessageBox.Show(ex.Message, "Error",  MessageBoxButtons.OK , MessageBoxIcon.Warning);
            }
            finally {
                //frmprogress.Close();
            }

            return retval; 

        }

        public Collection<String> fldstarts = new Collection<string>();

        private void LoadField(Microsoft.Office.Interop.Word.Field fld, ref TreeNode parentnode) {

            // Delcarations
            TreeNode node = new TreeNode();
            Collection<Microsoft.Office.Interop.Word.Field> col = new Collection<Microsoft.Office.Interop.Word.Field>();
            Collection<Microsoft.Office.Interop.Word.Field> colparent = (Collection<Microsoft.Office.Interop.Word.Field>)parentnode.Tag;

            // Set the Node Properties       
            col.Add(fld); node.Tag = col;

            String regionnamestart = "",  regionfilterstart = "";
            Classes.MailMerge.ParseRegionValue(fld.Code.Text, out regionnamestart, out regionfilterstart);

            if(regionnamestart == null){
                IEnumerable<MergeFieldSwitch> switches;
                Classes.MailMerge.ParseMergeFieldValue(fld.Code.Text, out regionnamestart, out switches);
            }
            
            node.Text = regionnamestart + " " + regionfilterstart;

            // Navigate Tree
            switch (getFieldType(fld)) {
                case Classes.MailMerge.FieldTypes.IFStart:
                    node.ImageKey = "ConditionalRegion";
                    node.SelectedImageKey = "ConditionalRegion";
                    parentnode.Nodes.Add(node);
                    parentnode = node;

                    if(fldstarts.Contains(regionnamestart)){
                        Exception ex = new Exception("IfStart:" + regionnamestart + " already exists.");
                        fld.Select();
                        throw (ex);
                    }
                    else{
                        fldstarts.Add(regionnamestart);
                    }

                    break;
                case Classes.MailMerge.FieldTypes.ListStart:
                    node.ImageKey = "ListRegion";
                    node.SelectedImageKey = "ListRegion";
                    parentnode.Nodes.Add(node);
                    parentnode = node;


                    if (fldstarts.Contains(regionnamestart)) {
                        Exception ex = new Exception("ListFormatStart:" + regionnamestart + " already exists.");
                        fld.Select();
                        throw (ex);
                    }
                    else {
                        fldstarts.Add(regionnamestart);
                    }

                    break;
                case Classes.MailMerge.FieldTypes.ListItem:
                    node = null;
                    break;
                case Classes.MailMerge.FieldTypes.TableStart:
                    node.ImageKey = "TableRegion";
                    node.SelectedImageKey = "TableRegion";
                    parentnode.Nodes.Add(node);
                    parentnode = node;
                    break;
                case Classes.MailMerge.FieldTypes.TableEnd:  case Classes.MailMerge.FieldTypes.IFEnd : case Classes.MailMerge.FieldTypes.ListEnd: 
                    node = null;

                    if (colparent == null) {
                        Exception ex = new Exception("Region does not match with " + fld.Code.Text);
                        throw (ex);
                    }

                    if (!isValidEnd(colparent[0], fld)) {
                        colparent[0].Select();
                        Exception ex = new Exception("Region " + colparent[0].Code.Text + " does not match with " + fld.Code.Text );
                        throw (ex);
                    }
                    else {
                        colparent.Add(fld);
                        parentnode = parentnode.Parent;
                    }
                    
                    break;
                case Classes.MailMerge.FieldTypes.Field:
                    node.ImageKey = "Field"; node.SelectedImageKey = "Field";    
                    parentnode.Nodes.Add(node);
                    break;
            }

        }

        private Boolean isValidEnd(Microsoft.Office.Interop.Word.Field fldparent, Microsoft.Office.Interop.Word.Field fld) {

            Boolean retval = false;

            String regionnamestart = "",  regionnameend = "";
            String regionfilterstart = "", regionfilterend = "";

            Classes.MailMerge.ParseRegionValue(fldparent.Code.Text, out regionnamestart, out regionfilterstart);
            Classes.MailMerge.ParseRegionValue(fld.Code.Text, out regionnameend, out regionfilterend);    

            if (regionnamestart == regionnameend) retval = true;

            return retval;

        }

        public TreeNode  RootNode {
            get {
                return treeView1.Nodes[0];
            }
        }

        private Classes.MailMerge.FieldTypes getFieldType(Microsoft.Office.Interop.Word.Field fld) {

            Classes.MailMerge.FieldTypes retval = Classes.MailMerge.FieldTypes.Field;

            if (fld.Code.Text.ToLower().Contains("ifstart:")) retval = Classes.MailMerge.FieldTypes.IFStart;
            if (fld.Code.Text.ToLower().Contains("ifend:")) retval = Classes.MailMerge.FieldTypes.IFEnd;
            if (fld.Code.Text.ToLower().Contains("tablestart:")) retval = Classes.MailMerge.FieldTypes.TableStart;
            if (fld.Code.Text.ToLower().Contains("tableend:")) retval = Classes.MailMerge.FieldTypes.TableEnd;
            if (fld.Code.Text.ToLower().Contains("listformatstart:")) retval = Classes.MailMerge.FieldTypes.ListStart;
            if (fld.Code.Text.ToLower().Contains("listformatend:")) retval = Classes.MailMerge.FieldTypes.ListEnd;
            if (fld.Code.Text.ToLower().Contains("listitem:")) retval = Classes.MailMerge.FieldTypes.ListItem;

            return retval;

        }

        # region Archive

            private void DocumentLoad(Aspose.Words.Document Doc, DataSet data) {

                try {

                    Cursor.Current = Cursors.WaitCursor;

                    this.MailMerge = new WordFusion.Assembly.MailMerge.MailMerge();
                    this.MailMerge.Load(Doc);

                    foreach (WordFusion.Assembly.MailMerge.MergeError error in this.MailMerge.Errors) {
                        ErrorAdd(new Exception(error.Description));
                    }

                }
                catch (Exception ex) {
                    throw ex;
                }
                finally {
                    Cursor.Current = Cursors.Default;
                }
            }
            public void LoadDocument(){

                try {

                    FileName = Classes.Application.App.ActiveDocument.FullName;

                    if (System.IO.File.Exists(FileName)) {
                        String fname = System.IO.Path.GetTempFileName();

                        System.IO.File.Copy(FileName, fname,true);

                        Aspose.Words.Document doc = new Aspose.Words.Document(fname);
                        WordFusion.Assembly.Assembler assembler = new WordFusion.Assembly.Assembler();

                        treeView1.Nodes[0].Nodes.Clear();
                        DocumentLoad(doc, new DataSet());
                        
                        foreach (WordFusion.Assembly.MailMerge.MergeRegion region in MailMerge.Regions){

                            TreeNode node = new TreeNode();

                            if (region.Type == MergeRegionType.Conditional) {
                                node.ImageKey = "ConditionalRegion";
                                node.SelectedImageKey = "ConditionalRegion";
                            }
                            else {
                                node.ImageKey = "TableRegion";
                                node.SelectedImageKey = "TableRegion";
                            }

                            node.Text = region.Name + ": " + region.Filter; node.Tag = region;
                            treeView1.Nodes[0].Nodes.Add(node);

                            //Load Child Regions
                            LoadRegion(node, region);
                        }

                        treeView1.Nodes[0].Expand();
                    }
                }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
            
            }

            private void LoadRegion(TreeNode parentnode,MergeRegion parentregion) {

                foreach (WordFusion.Assembly.MailMerge.MergeRegion region in parentregion.ChildRegions) {

                    TreeNode node = new TreeNode();            
                    if (region.Type == MergeRegionType.Conditional) {
                        node.ImageKey = "ConditionalRegion";
                        node.SelectedImageKey = "ConditionalRegion";
                    }
                    else {
                        node.ImageKey = "TableRegion";
                        node.SelectedImageKey = "TableRegion";
                    }

                    node.Text = region.Name + ": " + region.Filter;node.Tag = region;
                    parentnode.Nodes.Add(node);


                    foreach (Aspose.Words.Node fld in region.Nodes) {
                        if (fld.IsComposite) {
                            CompositeNode nodecollection = (CompositeNode)fld;
                            LoadFieldsForNodes(region, nodecollection.ChildNodes, node);
                        } 
                    }
     
                    //Load Child Regions
                    LoadRegion(node, region);
     
                }
            }

            private void LoadFieldsForNodes(MergeRegion parentregion, NodeCollection nodes, TreeNode parentnode) {

                // Add Fields             
                foreach (Aspose.Words.Node fld in nodes) {

                    if (fld.GetType() == typeof(Aspose.Words.Fields.FieldStart)) {
                    WordFusion.Assembly.MailMerge.MergeField mergefld = MailMerge.GetMergeField((Aspose.Words.Fields.FieldStart)fld);

                            if (mergefld.Name != null && !mergefld.Name.ToLower().Contains("ifend")) {
                                TreeNode nodefld = new TreeNode();
                                nodefld.ImageKey = "Field"; nodefld.SelectedImageKey = "Field";
                                nodefld.Text = mergefld.Name; nodefld.Tag = mergefld;
                                parentnode.Nodes.Add(nodefld);

                            }                    
                    }

                    // This is not a region - don't Load
                    if (fld.IsComposite) {                   
                        CompositeNode nodecollection = (CompositeNode) fld;
                        LoadFieldsForNodes(parentregion, nodecollection.ChildNodes, parentnode);             
                    }               
                }
            }
        # endregion

        # region General

        /// <summary>
        /// Adds Error record to the errors collection
        /// </summary>
        private void ErrorAdd(Exception ex) {
            Errors.Add(ex);
        }

        # endregion

        public void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            RegionSelected(sender, e);
            FieldSelect();           
        }

        private void FieldSelect() {
            if (SelectedField != null) {

                switch (Classes.MailMerge.RegionType(SelectedField)) {
                    case MergeRegionType.None:
                        SelectedField.Select();
                        break;
                    default:
                        this.SelectedFieldRange().Select();
                        break;
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            FieldStructureLoad();
        }

        //private static SystemFramework.Progress LoadMonitor() {
        //    SystemFramework.Progress retval = new SystemFramework.Progress();
        //    retval.Text = "Loading Document Fields, please wait.";
        //    retval.Title = "Loading Document";
        //    retval.Description = "WordFusion is loading the Fields from the Document.";

        //    return retval;
        //}

        //private static SystemFramework.Progress CheckingFieldsMonitor() {
        //    SystemFramework.Progress retval = new SystemFramework.Progress();
        //    retval.Text = "Checking Document Fields, please wait.";
        //    retval.Title = "Checking Document";
        //    retval.Description = "WordFusion is checking the Fields from the Document.";

        //    return retval;
        //}

        private void btnFieldEdit_Click(object sender, EventArgs e) {
            SelectedFieldEdit();
        }

        public void SelectedFieldEdit() {
            Microsoft.Office.Interop.Word.Field fld = SelectedField;

            Word.Classes.MailMergeRegion region = new Word.Classes.MailMergeRegion(); 
            String regionnamestart = "", regionfilterstart = "";

            Word.Classes.MailMerge.ParseRegionValue(SelectedField.Code.Text, out regionnamestart, out regionfilterstart);
            region.Name = regionnamestart;
            region.Filter = regionfilterstart;
            region.StartWordField = SelectedField;
            region.EndWordField = SelectedFieldEnd;

            switch (Classes.MailMerge.RegionType(fld)){
                case MergeRegionType.Conditional:
                    Classes.MailMerge.RegionEdit(WordFusion.Assembly.MailMerge.MergeRegionType.Conditional, region);
                    break;
                case MergeRegionType.ListFormat:
                    Classes.MailMerge.RegionEdit(WordFusion.Assembly.MailMerge.MergeRegionType.ListFormat, region);
                    break;
                case MergeRegionType.Table:
                    Classes.MailMerge.RegionEdit(WordFusion.Assembly.MailMerge.MergeRegionType.Table, region);
                    break;
                case MergeRegionType.None:
                    Classes.MailMerge.FieldEdit("MailMerge", fld);
                    break;
            }
        }

        public Microsoft.Office.Interop.Word.Field SelectedField {
            get {
                Microsoft.Office.Interop.Word.Field retval = null;
                if (treeView1.SelectedNode.Tag != null) {
                    Collection<Microsoft.Office.Interop.Word.Field> col = (Collection<Microsoft.Office.Interop.Word.Field>)treeView1.SelectedNode.Tag;
                    if (col != null) retval = col[0]; 
                }
                return retval;
            }
        }

        public Microsoft.Office.Interop.Word.Field SelectedFieldEnd {
            get {
                Microsoft.Office.Interop.Word.Field retval = null;
                if (treeView1.SelectedNode.Tag != null) {
                    Collection<Microsoft.Office.Interop.Word.Field> col = (Collection<Microsoft.Office.Interop.Word.Field>)treeView1.SelectedNode.Tag;
                    if (col != null) {
                        if (col.Count > 1) retval = col[1];                       
                    }
                }
                return retval;
            }
        }

        public Microsoft.Office.Interop.Word.Range SelectedFieldRange() {

            object start = SelectedField.Code.Start;
            object end = SelectedField.Code.End;

            if (SelectedFieldEnd != null) {
                end = SelectedFieldEnd.Code.End;
            }

            Microsoft.Office.Interop.Word.Range retval = Classes.MailMerge.app.ActiveDocument.Range(ref start, ref end);
            return retval;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e) {
            SelectedFieldEdit();
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e) {
            TreeNode nd = treeView1.GetNodeAt(e.X, e.Y);
            if (nd != null) {
                if (e.Button == MouseButtons.Right) {
                    treeView1.SelectedNode = nd;
                }
            }
        }
    }
}
