using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZumeForms.Word.Classes;

namespace ZumeForms.Word.Forms {

    public partial class ConditionalRegion : Form {
        
        public ConditionalRegion() {
            InitializeComponent();
        }

        private int Start = 0, End = 0;

        private Microsoft.Office.Interop.Word.Selection _Selection;

        public Boolean cancelclose = false;
        public DialogResult ShowDialog(Microsoft.Office.Interop.Word.Selection selection) {

            _Selection = selection;
            Start = selection.Start; End = selection.End;

           // Classes.FormFields.LoadFieldListFromDocument();

            if (this.ShowDialog() == DialogResult.OK) {
                    conditionalRegion1.FieldCodeUpdate();
            }
            return this.DialogResult;
        }

        public String RegionName {
            get {
                return conditionalRegion1.MailMergeRegion.Name;
            }
            set {
                conditionalRegion1.Name = value;
            }
        }

        private void ConditionalRegion_Shown(object sender, EventArgs e) {
            Init();
        }

        public void Init() {
            conditionalRegion1.MailMergeRegion = MailMergeRegion;
            conditionalRegion1.Init();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private Classes.MailMergeRegion _MailMergeRegion = new Classes.MailMergeRegion();
        public Classes.MailMergeRegion MailMergeRegion {
            get {
                return _MailMergeRegion;
            }
            set {
                _MailMergeRegion = value;
            }
        }

        internal DialogResult ShowDialog(object selection)
        {
            throw new NotImplementedException();
        }

        public void AddRegion() {

            object fldtype = Microsoft.Office.Interop.Word.WdFieldType.wdFieldEmpty;
            object preserve = true;

            // Add the IFEnd
            _Selection.Start = End;
            _Selection.End = End;

            _Selection.TypeParagraph();

            object fldname = "MERGEFIELD  IFEnd:" + conditionalRegion1.RegionName;
            Microsoft.Office.Interop.Word.Field fldend = _Selection.Fields.Add(_Selection.Range, ref fldtype, ref fldname);
            _Selection.InsertAfter("WF:DelEmptyPara");
            fldend.Code.Text = fldend.Code.Text.Replace(@"\* MERGEFORMAT", "");

            // Add the IFEnd
            _Selection.Start = Start;
            _Selection.End = Start;
            fldname = "MERGEFIELD  IFStart:" + conditionalRegion1.RegionName + " " + conditionalRegion1.Filter;
            Microsoft.Office.Interop.Word.Field fldstart =  _Selection.Fields.Add(_Selection.Range, ref fldtype, ref fldname);
            fldstart.Code.Text = fldstart.Code.Text.Replace(@"\* MERGEFORMAT", "");
            _Selection.InsertAfter("WF:DelEmptyPara");
        }

        private void btnEdit_Click(object sender, EventArgs e) {

      
        }

        private DataColumn getMainDs() {

            DataTable tbl = new DataTable();
            tbl.Columns.Add("to"); tbl.Columns.Add("subject"); tbl.Columns.Add("DocumentType");
            tbl.Columns.Add("reviewerdesc"); tbl.Columns.Add("date"); tbl.Columns.Add("userName");
            tbl.TableName = "Data";
            return tbl.Columns[0];
        }

        private void ConditionalRegion_FormClosing(object sender, FormClosingEventArgs e){
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK){
                if (conditionalRegion1.RegionName == ""){
                    MessageBox.Show("Field name cannot be blank", "Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }

        }

    }
}
