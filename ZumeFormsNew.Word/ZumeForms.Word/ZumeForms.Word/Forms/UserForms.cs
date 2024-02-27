using Janus.Windows.GridEX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ZumeForms.Word.UserControls;

namespace ZumeForms.Word.Forms {
    public partial class UserForms : Form {

        public System.Xml.Linq.XElement Fields;
        public static GridEX GridEXNewFromUSer { get; set; }

        public UserForms() {
            InitializeComponent();

            txtUserPassword.TextBox.PasswordChar = '*';
        }

        public static string ConditionalRegionText { get; set; }
        private void ucUserForm21_FormSelected(object sender, EventArgs e) {

            ComboboxItem itm = (ComboboxItem)sender;

            if (itm != null) {
                ucFormFields.LoadFormFieldsFromFormScheme(itm.Value.ToString());

                formTreeView.Nodes.Clear();
                AddNodesToTreeView(ucFormFields.xComponentTreeData, formTreeView.Nodes);

                formTreeView.Show();

                if (ConditionalRegionFilter.radDocFieldsChecked)
                {
                    Classes.Application.frmZumeForm.Fields = ucFormFields.xComponentTreeData;
                    ConditionalRegionFilter.isUserFormSelected = true;
                    ConditionalRegionFilter.radDocFieldsChecked = false;
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
                        ConditionalRegionFilter.GridEXNew.DataMember = "Form";
                        ConditionalRegionFilter.GridEXNew.DataSource = Classes.FormFields.FieldFormDataSet;
                    }
                    ConditionalRegionFilter.GridEXNew.RetrieveStructure(true);
                    Classes.Application.frmZumeForm.Close();
                }
                
                //ucFormFields.LoadForm(itm.Value.ToString());
                //Fields = ucFormFields.xSummaryData;
            }

        }
        public static void AddNodesToTreeView(XElement element, TreeNodeCollection nodes)
        {
            TreeNode newNode = new TreeNode(element.Name.LocalName);

            // Recursively add child nodes
            foreach (XElement childElement in element.Elements())
            {
                AddNodesToTreeView(childElement, newNode.Nodes);
            }

            nodes.Add(newNode);
        }

        private void btnLoadForms_Click(object sender, EventArgs e) {

            LoadFields();

        }

        private void txtUser_Click(object sender, EventArgs e) {

        }

        private void LoadFields() {
            if (string.IsNullOrEmpty(txtDomain.Text) || string.IsNullOrEmpty(txtUser.Text)) {
                MessageBox.Show("ServerURL and UserName is required");
                return;
            }

            ucUserForm21.LoadUsers(txtDomain.Text, txtUser.Text, txtUserPassword.Text);
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                LoadFields();
            }        
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Hide();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void txtUserPassword_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                LoadFields();
            }
        }

        private void formTreeView_Click(object sender, EventArgs e)
        {
            TreeViewHitTestInfo info = formTreeView.HitTest(formTreeView.PointToClient(Cursor.Position));
            if (info != null)
                MessageBox.Show(info.Node.Text);
        }

        private void formTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeViewHitTestInfo info = formTreeView.HitTest(formTreeView.PointToClient(Cursor.Position));
            if (info != null)
                MessageBox.Show(info.Node.Text);
        }

        public void formTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (ConditionalRegionFilter.radDocFieldsChecked)
            {
                ConditionalRegion conditionalRegion = new ConditionalRegion();
                conditionalRegion.conditionalRegion1.RegionName = e.Node.Text;
                ConditionalRegionText = e.Node.Text;
                //MessageBox.Show(e.Node.Text);
            }
        }
    }
}
