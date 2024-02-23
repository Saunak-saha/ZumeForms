using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZumeForms.Word.UserControls {
    public partial class TableRegion : UserControl {
        public TableRegion() {
            InitializeComponent();
        }

        public Classes.MailMergeRegion MailMergeRegion = new Classes.MailMergeRegion();

        public void Init() {
            txtName.Text = MailMergeRegion.Name;
        }

        public String RegionName {
            get {
                return txtName.Text;
            }
            set {
                txtName.Text = value;
            }
        }

        public void FieldCodeSet() {

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
                FieldCodeSetStart();
                FieldCodeSetEnd();
            }

        }

        private String StartCode {
            get {
                String retval = "MERGEFIELD TableStart:" + MailMergeRegion.Name;
                return retval;
            }
        }

        private String EndCode {
            get {
                String retval = "MERGEFIELD TableEnd:" + MailMergeRegion.Name;
                return retval;
            }
        }


        private void FieldCodeSetStart() {
            if (MailMergeRegion.StartWordField != null) {
                MailMergeRegion.StartWordField.Code.Text = StartCode;
                MailMergeRegion.StartWordField.Update();
            }
        }

        private void FieldCodeSetEnd() {
            if (MailMergeRegion.StartWordField != null) {
                MailMergeRegion.EndWordField.Code.Text = EndCode;
                MailMergeRegion.EndWordField.Update();
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e) {

            // Check for a naughty character in the KeyDown event.
            // Check for a naughty character in the KeyDown event.
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z0-9_]*$") && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.ControlKey) {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }
        }
    }
}
