using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordFusion.Assembly.MailMerge;

namespace ZumeForms.Word.Forms {

    public partial class FieldsNotInForm : Form {
        public FieldsNotInForm() {
            InitializeComponent();

 
        }

        public void CheckFields() {

            try {

                List<FieldItem> data = new List<FieldItem>();
                cboFields.DisplayMember = "FieldName";

                IEnumerator oFieldEnumerator = Word.Classes.MailMerge.app.ActiveDocument.Fields.GetEnumerator();
                while (oFieldEnumerator.MoveNext()) {
                    
                    Microsoft.Office.Interop.Word.Field field = oFieldEnumerator.Current as Microsoft.Office.Interop.Word.Field;
                    String strField = field.Code.Text;

                    Word.Classes.MailMerge.FieldTypes fldtype = Word.Classes.MailMerge.FieldType(field);
                    if (fldtype == Classes.MailMerge.FieldTypes.Field || fldtype == Classes.MailMerge.FieldTypes.TableStart) {

                        String fldname = string.Empty; 
                        Classes.MailMerge.ParseMergeFieldValue(strField, out fldname, out IEnumerable<MergeFieldSwitch> switches);

                        if (Classes.Application.frmZumeForm != null) {
                            if (Classes.Application.frmZumeForm.Fields != null) {

                                bool hasfield = Classes.Application.frmZumeForm.Fields.Descendants().Where(i => i.Name == fldname).Any();
                                if (!hasfield) {
                                    data.Add(new FieldItem() { FieldName = fldname, Field= field });
                                }

                            }
                        }

                    }
                }

                cboFields.DataSource = data;

                if (Classes.Application.frmZumeForm.Fields == null) {
                    if(MessageBox.Show("No Form has been loaded. Do you want to load one now?" , "Form", MessageBoxButtons.YesNo) == DialogResult.Yes){

                        if (Classes.Application.frmZumeForm.IsDisposed) { Classes.Application.frmZumeForm = new Word.Forms.UserForms(); }
                        Classes.Application.frmZumeForm.Show();
                        Classes.Application.frmZumeForm.BringToFront();

                    }
                    this.Close();
                }
                else {

                    this.Show();
                    this.BringToFront();

                }

            }
            catch {

            }
            finally {

            }


        }

        private void lstFields_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Hide();
        }

        private void cboFields_SelectedIndexChanged(object sender, EventArgs e) {

        }

        public Microsoft.Office.Interop.Word.Field SelectedField {
            get {
                Microsoft.Office.Interop.Word.Field retval = null;

                if (cboFields.SelectedItem != null) {
                    FieldItem item = (FieldItem)cboFields.SelectedItem;
                    retval = item.Field;
                }
                return retval;
            }
        }

        private void cboFields_SelectedValueChanged(object sender, EventArgs e) {
            //RegionSelected(sender, e);
            FieldSelect();
        }

        private void FieldSelect() {
            if (SelectedField != null) {

                switch (Classes.MailMerge.RegionType(SelectedField)) {
                    case MergeRegionType.None:
                        SelectedField.Select();
                        break;
                    default:
                        //this.SelectedFieldRange().Select();
                        break;
                }
            }
        }

    }


    public class FieldItem {
        public string FieldName { get; set; }
        public Microsoft.Office.Interop.Word.Field Field { get; set; }
    }


}
