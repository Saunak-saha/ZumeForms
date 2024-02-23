using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WordFusion.Assembly.MailMerge;

namespace ZumeForms.Word.UserControls {
    public partial class MailMergeField : UserControl {

        public MailMergeField() {
            InitializeComponent();


            var source = new AutoCompleteStringCollection();

            if (Classes.Application.frmZumeForm != null) {
                if(Classes.Application.frmZumeForm.Fields != null) {
                    foreach (System.Xml.Linq.XElement xfield in Classes.Application.frmZumeForm.Fields.Descendants()) {
                        source.Add(xfield.Name.LocalName);
                    }
                }
            }

            if (Word.Classes.MailMerge.app != null) {
                if(Word.Classes.MailMerge.app.ActiveDocument != null) {
                    System.Collections.IEnumerator oFieldEnumerator = Word.Classes.MailMerge.app.ActiveDocument.Fields.GetEnumerator();
                    while (oFieldEnumerator.MoveNext()) {

                        Microsoft.Office.Interop.Word.Field field = oFieldEnumerator.Current as Microsoft.Office.Interop.Word.Field;

                        Word.Classes.MailMerge.FieldTypes fldtype = Word.Classes.MailMerge.FieldType(field);

                        String name;
                        IEnumerable<MergeFieldSwitch> switches;
                        Classes.MailMerge.ParseMergeFieldValue(field.Code.Text, out name, out switches);

                        if (fldtype == Word.Classes.MailMerge.FieldTypes.Field) {
                            source.Add(name);
                        }
                    }

                    txtFieldName.AutoCompleteCustomSource = source;
                }

            }

        }

        private Classes.MailMergeField _Field;
        public Classes.MailMergeField Field {
            get { return _Field; }
            set {
                _Field = value;
            }
        }

        public string FieldName
        {
            get { return txtFieldName.Text; }
            
        }

        public String RegionName
        {
            get
            {
                return txtFieldName.Text;
            }
            set
            {
                txtFieldName.Text = value;
            }
        }

        public void Init() {
            LoadMailMergeField();
        }

        private void LoadMailMergeField() {

            // Load Mergetext Lists
            if(Classes.Application.MergeTextLists.Count > 0) {
                txtMergeText.Items.Clear();
                foreach(string itm in Classes.Application.MergeTextLists) {
                    txtMergeText.Items.Add(itm);
                }
            }

            if (Field != null) {

                txtFieldName.Text = Field.Name;

                // Set Defaults
                //radCaseNone.Checked = true;
                //radNumericNone.Checked = true;
                //radNumeric.Checked = false;
                txtNumericFormat.Text = "";
                //radDate.Checked = false;                
                cboDateFormat.Text = "";
                chkTextBefore.Checked = false;
                txtTextBefore.Text = "";
                chkTextAfter.Checked = false;
                txtTextAfter.Text = "";
                chkStringFormat.Checked = false;
                txtStringFormat.Text = "";
                chkMergeText.Checked = false;
                txtMergeText.Text = "";
                cbxNBSP.Checked = false;

                if (GetSwitch("caps") != null) {
                    radCaps.Checked = true;
                }
                else {
                    radCaps.Checked = false;
                }

                if (GetSwitch("firstcap") != null) {
                    radCapsFirst.Checked = true;
                }
                else {
                    radCapsFirst.Checked = false;
                }

                if (GetSwitch("upper") != null) {
                    radCaseUpper.Checked = true;
                }
                else {
                    radCaseUpper.Checked = false;
                }

                if (GetSwitch("lower") != null) {
                    radCaseLower.Checked = true;
                }
                else {
                    radCaseLower.Checked = false;
                }

                if (GetSwitch("numbertext") != null) {
                    radNumberText.Checked = true;
                }
                else {
                    radNumberText.Checked = false;
                }

                if (GetSwitch("dollartext") != null) {
                    radDollarText.Checked = true;
                }
                else {
                    radDollarText.Checked = false;
                }

                if (GetSwitch("NBSP") != null)
                {
                    cbxNBSP.Checked = true;
                }
                else
                {
                    cbxNBSP.Checked = false;
                }

                WordFusion.Assembly.MailMerge.MergeFieldSwitch sw = GetSwitch("#");
                if (sw != null) {
                    txtNumericFormat.Text = sw.Value;
                    radNumeric.Checked = true;
                    txtNumericFormat.Enabled = true;
                }
                else {
                    radNumeric.Checked = false;
                }

                sw = GetSwitch("@");
                if (sw != null) {
                    cboDateFormat.Text = sw.Value;
                    radDate.Checked = true;
                    cboDateFormat.Enabled = true;
                }
                else {
                    radDate.Checked = false;
                }

                sw = GetSwitch("b");
                if (sw != null) {
                    txtTextBefore.Text = sw.Value;
                    chkTextBefore.Checked = true;
                    txtTextBefore.Enabled = true;
                }

                sw = GetSwitch("MTEXTList");
                if (sw != null) {
                    sw.Value = sw.Value.Replace("(", "");
                    sw.Value = sw.Value.Replace(")", "");

                    txtMergeText.Text = sw.Value;
                    chkMergeText.Checked = true;
                    txtMergeText.Enabled = true;

                }

                sw = GetSwitch("f");
                if (sw != null) {
                    txtTextAfter.Text = sw.Value;
                    chkTextAfter.Checked = true;
                    txtTextAfter.Enabled = true;
                }

                sw = GetSwitch("stringformat");
                if (sw != null) {
                    txtStringFormat.Text = sw.Value;
                    chkStringFormat.Checked = true;
                    txtStringFormat.Enabled = true;
                }
            }
        }

        private WordFusion.Assembly.MailMerge.MergeFieldSwitch GetSwitch(String name) {
            WordFusion.Assembly.MailMerge.MergeFieldSwitch retval = null;
            foreach (WordFusion.Assembly.MailMerge.MergeFieldSwitch sw in Field.Switches) {
                if (sw.Value.ToLower() == name.ToLower()) retval = sw;
                if (sw.Name.ToLower() == name.ToLower()) retval = sw;
            }
            return retval;
        }

        private void SetSwitch(String name, String value) {
            foreach (WordFusion.Assembly.MailMerge.MergeFieldSwitch sw in Field.Switches) {
                if (sw.Value.ToLower() == name.ToLower() || sw.Name.ToLower() == name.ToLower()) {

                }
            }
        }

        private void radCaps_CheckedChanged(object sender, EventArgs e) {
            SetBooleanSwitch("*", "caps", radCaps.Checked);
        }

        private void radCapsFirst_CheckedChanged(object sender, EventArgs e) {
            SetBooleanSwitch("*", "firstcap", this.radCapsFirst.Checked);
        }

        private void radCaseUpper_CheckedChanged(object sender, EventArgs e) {
            SetBooleanSwitch("*", "upper", this.radCaseUpper.Checked);
        }

        private void radCaseLower_CheckedChanged(object sender, EventArgs e) {
            SetBooleanSwitch("*", "lower", this.radCaseLower.Checked);
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e) {
            cboDateFormat.Enabled = radDate.Checked;
            SetFormatSwitch("@", cboDateFormat.Text, radDate.Checked);
        }

        private void cboDateFormat_Validated(object sender, EventArgs e) {
            SetFormatSwitch("@", cboDateFormat.Text, radDate.Checked);
        }

        private void cboDateFormat_SelectedIndexChanged(object sender, EventArgs e) {
            SetFormatSwitch("@", cboDateFormat.Text, radDate.Checked);
        }

        private void chkNumeric_CheckedChanged(object sender, EventArgs e) {
            txtNumericFormat.Enabled = radNumeric.Checked;
            SetFormatSwitch("#", this.txtNumericFormat.Text, radNumeric.Checked);
        }

        private void txtNumericFormat_Validated(object sender, EventArgs e) {
            SetFormatSwitch("#", this.txtNumericFormat.Text, radNumeric.Checked);
        }

        private void chkTextBefore_CheckedChanged(object sender, EventArgs e) {
            txtTextBefore.Enabled = chkTextBefore.Checked;
            SetFormatSwitch("b", this.txtTextBefore.Text, chkTextBefore.Checked);
        }

        private void txtTextBefore_Validated(object sender, EventArgs e) {
            SetFormatSwitch("b", this.txtTextBefore.Text, chkTextBefore.Checked);
        }

        private void chkTextAfter_CheckedChanged(object sender, EventArgs e) {
            txtTextAfter.Enabled = chkTextAfter.Checked;
            SetFormatSwitch("f", this.txtTextAfter.Text, chkTextAfter.Checked);
        }

        private void txtTextAfter_Validated(object sender, EventArgs e) {
            SetFormatSwitch("f", this.txtTextAfter.Text, chkTextAfter.Checked);
        }

        private void chkStringFormat_CheckedChanged(object sender, EventArgs e) {
            txtStringFormat.Enabled = chkStringFormat.Checked;
            SetFormatSwitch("stringformat", this.txtStringFormat.Text, chkStringFormat.Checked);
        }

        private void txtStringFormat_Validated(object sender, EventArgs e) {
            SetFormatSwitch("stringformat", this.txtStringFormat.Text, chkStringFormat.Checked);
        }

        private void radNumberText_CheckedChanged(object sender, EventArgs e) {
            SetBooleanSwitch("numbertext", "", this.radNumberText.Checked);
        }


        private void chkMergeText_CheckedChanged(object sender, EventArgs e) {
            txtMergeText.Enabled = chkMergeText.Checked;
            SetFormatSwitch("MTEXTList", "(" + txtMergeText.Text + ")", this.chkMergeText.Checked);
        }

        private void txtMergeText_Validated(object sender, EventArgs e) {
            SetFormatSwitch("MTEXTList", "(" + txtMergeText.Text + ")", this.chkMergeText.Checked);
        }

        private void radDollarText_CheckedChanged(object sender, EventArgs e) {
            SetBooleanSwitch("dollartext", "", this.radDollarText.Checked);
        }

        private void cbxNBSP_CheckedChanged(object sender, EventArgs e) {
            SetBooleanSwitch("NBSP", "", this.cbxNBSP.Checked);
        }

        private void SetBooleanSwitch(String name, String type, Boolean selected) {

            // Always remove the switch before adding it back-in
            System.Collections.Generic.List<WordFusion.Assembly.MailMerge.MergeFieldSwitch> lst = (System.Collections.Generic.List<WordFusion.Assembly.MailMerge.MergeFieldSwitch>)Field.Switches;
            foreach (WordFusion.Assembly.MailMerge.MergeFieldSwitch sw in lst) {
                if (sw.Value.ToLower() == name.ToLower() || sw.Name.ToLower() == name.ToLower()) {
                    lst.Remove(sw); break;
                }
            }

            if (selected) lst.Add(new global::WordFusion.Assembly.MailMerge.MergeFieldSwitch(name, type));
            Field.WordField.Code.Text = FieldCode;
            Field.WordField.Update();

        }

        private void SetFormatSwitch(String name, String value, Boolean selected) {

            // Always remove the switch before adding it back-in
            System.Collections.Generic.List<WordFusion.Assembly.MailMerge.MergeFieldSwitch> lst = (System.Collections.Generic.List<WordFusion.Assembly.MailMerge.MergeFieldSwitch>)Field.Switches;
            foreach (WordFusion.Assembly.MailMerge.MergeFieldSwitch sw in lst) {
                if (sw.Value.ToLower() == name.ToLower() || sw.Name.ToLower() == name.ToLower()) {
                    lst.Remove(sw); break;
                }
            }

            if (selected) lst.Add(new global::WordFusion.Assembly.MailMerge.MergeFieldSwitch(name, value));
            Field.WordField.Code.Text = FieldCode;

            //Field.WordField.Update();
            //Field.WordField.ShowCodes = true;
            //Field.WordField.Update();

        }

        private void SetMergeTextSwitch(String name, String value, Boolean selected) {

            // Always remove the switch before adding it back-in
            System.Collections.Generic.List<WordFusion.Assembly.MailMerge.MergeFieldSwitch> lst = (System.Collections.Generic.List<WordFusion.Assembly.MailMerge.MergeFieldSwitch>)Field.Switches;
            foreach (WordFusion.Assembly.MailMerge.MergeFieldSwitch sw in lst) {
                if (sw.Value.ToLower() == name.ToLower() || sw.Name.ToLower() == name.ToLower()) {
                    lst.Remove(sw); break;
                }
            }

            if (selected) lst.Add(new global::WordFusion.Assembly.MailMerge.MergeFieldSwitch(name, value));
            Field.WordField.Code.Text = FieldCode;
            Field.WordField.Update();

        }

        private String FieldCode {
            get {
                String retval = "MERGEFIELD " + txtFieldName.Text + " ";

                foreach (WordFusion.Assembly.MailMerge.MergeFieldSwitch sw in Field.Switches) {
                    retval = retval + " \\" + sw.Name + " " + sw.Value;
                }
                return retval;
            }
        }

        private void radCaseNone_CheckedChanged(object sender, EventArgs e) {
            Field.WordField.Code.Text = FieldCode;
            Field.WordField.Update();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            Field.WordField.Code.Text = FieldCode;
            Field.WordField.Update();
        }

        private void btnNext_Click(object sender, EventArgs e) {
            FieldNext();
        }

        private void btnPrevious_Click(object sender, EventArgs e) {
            FieldPrev();
        }

        private void FieldNext() {

            Word.Classes.MailMergeField mergefld = new Word.Classes.MailMergeField();
            mergefld.WordField = Classes.MailMerge.FieldNext();
            if (mergefld.WordField != null) {
                mergefld.Init();
                this.Field = mergefld;
                this.Init();
            }
            else {
                this.Field = null;
            }
        }

        private void FieldPrev() {

            Word.Classes.MailMergeField mergefld = new Word.Classes.MailMergeField();
            mergefld.WordField = Classes.MailMerge.FieldPrev();
            if (mergefld.WordField != null) {
                mergefld.Init();
                this.Field = mergefld;
                this.Init();
            }
            else {
                this.Field = null;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {

            if (Field != null) {

                Field.WordField.Delete();
                FieldNext();

                if (Field == null) {
                    pnlField.Enabled = false;

                    btnDelete.Enabled = false;
                    btnFieldNext.Enabled = false;
                    btnFieldNext.Enabled = false;

                }

                txtFieldName.Text = "";
            }
        }

        private void btnField_Click(object sender, EventArgs e) {
            LoadField();
        }

        private void LoadField() {
            //Forms.FieldList frm = new global::WordFusion.Office.Word.Forms.FieldList();
            //if (frm.ShowDialog() == DialogResult.OK) {
            //    txtFieldName.Text = frm.SelectedFieldName;
            //    UpdateField();
            //}
        }

        private void txtFieldName_Validated(object sender, EventArgs e) {
            UpdateField();
        }

        private void UpdateField() {

            string fldname = txtFieldName.Text;
            bool isNumeric = false;

            if (fldname.Length > 0) {
                int n;
                isNumeric = int.TryParse(fldname.Substring(0, 1), out n);
            }

            if (isNumeric) {
                MessageBox.Show("The first character of a fieldname cannot be a number.");
            }
            else {
                Field.Name = txtFieldName.Text;
                Field.WordField.Code.Text = FieldCode;
                Field.WordField.Update();
            }

        }

        private void txtFieldName_TextChanged(object sender, EventArgs e) {

        }

        private void txtFieldName_KeyDown(object sender, KeyEventArgs e) {
            
        }

        private void txtFieldName_KeyPress(object sender, KeyPressEventArgs e) {

            // Check for a naughty character in the KeyDown event.
            if (! System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z0-9_]*$") && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.ControlKey  && e.KeyChar != ':') {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }

        }
    }
}
