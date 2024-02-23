using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZumeForms.Word.Forms
{
    /*public partial class ShortIf : Form {

        public Classes.MailMergeRegion MailMergeRegion = new Classes.MailMergeRegion();
        public ShortIf() {
            InitializeComponent();
        }

        private Microsoft.Office.Interop.Word.Selection _Selection;

        public DialogResult ShowDialog(Microsoft.Office.Interop.Word.Selection selection)
        {
            return this.DialogResult;
        }

        public void Init()
        {
            //shortIf1.Field = Field;
            //shortIf1.Init();
        }

        public void AddField() {
            int start = _Selection.Start;
            int end = _Selection.End;

            object fldtype = Microsoft.Office.Interop.Word.WdFieldType.wdFieldEmpty;
            object preserve = true;

            _Selection.Start = _Selection.End;
            _Selection.TypeParagraph();
            object fldname = "MERGEFIELD ShortIf:" + shortIf1;
            Microsoft.Office.Interop.Word.Field fldend = _Selection.Fields.Add(_Selection.Range, ref fldtype, ref fldname, ref preserve);
            _Selection.InsertAfter("");

            _Selection.Start = start;
            _Selection.End = start;
            Microsoft.Office.Interop.Word.Field fldstart = _Selection.Fields.Add(_Selection.Range, ref fldtype, ref fldname, ref preserve);
            fldstart.Code.Text = fldstart.Code.Text.Replace(@"\* MERGEFORMAT", "");
            fldend.Code.Text = fldend.Code.Text.Replace(@"\* MERGEFORMAT", "");

            _Selection.InsertAfter("");

            //int mystart = selection.Start; int myend = selection.End;

            //Word.Classes.MailMergeRegion region = Classes.MailMerge.CurrentRegionGet(MergeRegionType.None);
            //if (region != null)
            //{

            //object fldtype = Microsoft.Office.Interop.Word.WdFieldType.wdFieldEmpty;
            //object preserve = true;

            //object fldname = "MERGEFIELD  ShortIf:";
            //selection.Start = mystart; selection.End = myend;

            //Microsoft.Office.Interop.Word.Field newshortif = selection.Fields.Add(selection.Range, ref fldtype, ref fldname, ref preserve);
            //newshortif.Code.Text = newshortif.Code.Text.Replace(@"\* MERGEFORMAT", "");
            //}
        }

        private void btnOK_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }*/
}
