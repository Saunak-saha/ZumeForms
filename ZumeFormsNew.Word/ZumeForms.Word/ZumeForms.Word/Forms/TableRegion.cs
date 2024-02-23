using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZumeForms.Word.Forms {

    public partial class TableRegion : Form {

        public Classes.MailMergeRegion MailMergeRegion = new Classes.MailMergeRegion();

        public TableRegion() {
            InitializeComponent();
        }

        private Microsoft.Office.Interop.Word.Selection _Selection;

        public void ShowDialog(Microsoft.Office.Interop.Word.Selection selection) {
            _Selection = selection;
            if (this.ShowDialog() == DialogResult.OK) {
                tableregion1.FieldCodeSet();
            }
        }

        private void TableRegion_Shown(object sender, EventArgs e) {
            Init();
        }

        public void Init() {
            tableregion1.MailMergeRegion = MailMergeRegion;
            tableregion1.Init();
        }


        public String RegionName {
            get {

                return tableregion1.RegionName;
            }
            set {
                tableregion1.RegionName = value;
            }
        }

        public void AddRegion() {

            int start = _Selection.Start; int end = _Selection.End;

            object fldtype = Microsoft.Office.Interop.Word.WdFieldType.wdFieldEmpty;
            object preserve = true;

            // Add the IFEnd


            _Selection.Start = _Selection.End;
            _Selection.TypeParagraph();
            object fldname = "MERGEFIELD  TableEnd:" + tableregion1.RegionName;
            Microsoft.Office.Interop.Word.Field fldend = _Selection.Fields.Add(_Selection.Range, ref fldtype, ref fldname, ref preserve);
            _Selection.InsertAfter("WF:DelEmptyPara");

            // Add the IFEnd
            _Selection.Start = start;
            _Selection.End = start;
            fldname = "MERGEFIELD  TableStart:" + tableregion1.RegionName;
            Microsoft.Office.Interop.Word.Field fldstart = _Selection.Fields.Add(_Selection.Range, ref fldtype, ref fldname, ref preserve);

            fldstart.Code.Text = fldstart.Code.Text.Replace(@"\* MERGEFORMAT", "");
            fldend.Code.Text = fldend.Code.Text.Replace(@"\* MERGEFORMAT", "");

            _Selection.InsertAfter("WF:DelEmptyPara");

        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void TableRegion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (tableregion1.RegionName == "")
                {
                    MessageBox.Show("Field name cannot be blank", "Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }
    }
}
