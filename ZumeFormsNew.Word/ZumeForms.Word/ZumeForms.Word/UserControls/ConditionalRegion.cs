using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZumeForms.Word.UserControls {
    public partial class ConditionalRegion : UserControl {
       
        public ConditionalRegion() {
            InitializeComponent();
        }

        public Classes.MailMergeRegion MailMergeRegion = new Classes.MailMergeRegion();

        public void Init() {
            if (MailMergeRegion != null) {
                txtName.Text = MailMergeRegion.Name;
                conditionalRegionFilter1.Filter = MailMergeRegion.Filter;
            }
        }

        public String RegionName {
            get {
                return txtName.Text;
            }
            set {
                txtName.Text = value;
            }
        }

        public String Filter {
            get {
                return conditionalRegionFilter1.Filter;
            }
            set {
                conditionalRegionFilter1.Filter = value;
            }
        }
       
        private String StartCode {
            get {
                String retval = "MERGEFIELD IFStart:" + MailMergeRegion.Name + " " + MailMergeRegion.Filter; 
                return retval;
            }
        }

        private String EndCode {
            get {
                String retval = "MERGEFIELD IFEnd:" + MailMergeRegion.Name;
                return retval;
            }
        }

        public void FieldCodeUpdate() {

            if (MailMergeRegion != null) {

                string fldname = txtName.Text;
                bool isNumeric = false;

                if (fldname.Length > 0) {
                    int n;
                    isNumeric = int.TryParse(fldname.Substring(0, 1), out n);
                }

                if (isNumeric) {
                    MessageBox.Show("The first character of a Region cannot be a number.");
                }
                else {
                    MailMergeRegion.Name = txtName.Text;
                    MailMergeRegion.Filter = conditionalRegionFilter1.Filter;
                    FieldCodeSetStart();
                    FieldCodeSetEnd();
                }

            }

        }

        private void FieldCodeSetStart() {
            if (MailMergeRegion.StartWordField != null) {
                MailMergeRegion.StartWordField.Code.Text = StartCode;
                MailMergeRegion.StartWordField.UpdateSource();
                MailMergeRegion.StartWordField.Update();
            }
        }

        private void FieldCodeSetEnd() {
            if (MailMergeRegion.EndWordField != null) {
                MailMergeRegion.EndWordField.Code.Text = EndCode;
                MailMergeRegion.EndWordField.Update();
            }
        }

        public Boolean ValidateRegion() {

            Boolean retval = true;
            retval = ValidateRegionName();
            return retval;

        }

        public Boolean ValidateRegionName() {

            Boolean retval = true;
                        
            Object missing = null; Object findtext = " IfStart:" + RegionName + " " ;
            Object end = Classes.MailMerge.app.ActiveDocument.Characters.Count; Object start = 0;

            Microsoft.Office.Interop.Word.Range range = Classes.MailMerge.app.ActiveDocument.Range(ref start,ref end );           
            if (range.Find.Execute(ref findtext,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing)) {

                if (MailMergeRegion.StartWordField == null) {
                    retval = false;
                }
                else {
                    if (MailMergeRegion.StartWordField.Code.Start <= range.Start && MailMergeRegion.StartWordField.Code.End >= range.End) {
                        retval = true;
                    }
                    else {
                        retval = false;
                    }
                }                    
            }

            return retval;

        }


        private void txtName_KeyPress(object sender, KeyPressEventArgs e) {

            // Check for a naughty character in the KeyDown event.
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z0-9_]*$") && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.ControlKey) {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }

        }

        public Boolean ValidateRegionOverLap() {

            Boolean retval = true;


            return retval;

        }

    }
}
