using System;
using System.Windows.Forms;

namespace ZumeForms.Word.Forms
{
    public partial class ListFormat : Form {
        public ListFormat() {
            InitializeComponent();
        }

        private Microsoft.Office.Interop.Word.Selection _Selection;
        public void ShowDialog(Microsoft.Office.Interop.Word.Selection selection) {
            _Selection = selection;
            if (this.ShowDialog() == DialogResult.OK) {
                listFormatRegion1.FieldCodeSet();
            }
        }

        private void ListFormat_Shown(object sender, EventArgs e) {
            Init();
        }

        public void Init() {
            listFormatRegion1.MailMergeRegion = MailMergeRegion;
            listFormatRegion1.Init();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private Classes.MailMergeRegion _MailMergeRegion = new Word.Classes.MailMergeRegion();
        public Classes.MailMergeRegion MailMergeRegion {
            get {
                return _MailMergeRegion;
            }
            set {
                _MailMergeRegion = value;
            }
        }

        public void AddRegion() {

            int start = _Selection.Start; int end = _Selection.End;

            object fldtype = Microsoft.Office.Interop.Word.WdFieldType.wdFieldEmpty;
            object preserve = true;

            // Add the IFEnd
            _Selection.Start = _Selection.End;

            //_Selection.ParagraphFormat.Shading.BackgroundPatternColor = Microsoft.Office.Interop.Word.WdColor.wdColorAqua;
            _Selection.TypeParagraph();

            object fldname = "MERGEFIELD  ListFormatEnd:" + listFormatRegion1.RegionName;
            
            Microsoft.Office.Interop.Word.Field fldend = _Selection.Fields.Add(_Selection.Range, ref fldtype, ref fldname, ref preserve);
            fldend.Code.Text = fldend.Code.Text.Replace(@"\* MERGEFORMAT", "");
            //fldend.Code.HighlightColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBrightGreen; doesn't work
            //fldend.Code.ParagraphFormat.Shading.BackgroundPatternColor = Microsoft.Office.Interop.Word.WdColor.wdColorAqua; partially works
            //fldend.Code.FormattedText.HighlightColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBrightGreen; doesn't work
            //fldend.Code.Shading.BackgroundPatternColor = Microsoft.Office.Interop.Word.WdColor.wdColorAqua; doesn't work
            //_Selection.Range.Shading.BackgroundPatternColor = Microsoft.Office.Interop.Word.WdColor.wdColorAqua; partially works
            //_Selection.InsertAfter("WF:DelEmptyPara"); partially works
            //_Selection.Range.Shading.BackgroundPatternColor = Microsoft.Office.Interop.Word.WdColor.wdColorAqua; partially works
            // Add the IFStart
            _Selection.Start = start;
            _Selection.End = start;

            fldname = "MERGEFIELD  ListFormatStart:" + listFormatRegion1.RegionName + " " + listFormatRegion1.Filter;
            Microsoft.Office.Interop.Word.Field fldstart = _Selection.Fields.Add(_Selection.Range, ref fldtype, ref fldname, ref preserve);
            fldstart.Code.Text = fldstart.Code.Text.Replace(@"\* MERGEFORMAT", "");
            _Selection.InsertAfter("WF:DelEmptyPara");
            var test = _Selection;
            //_Selection.Range.Shading.BackgroundPatternColor = Microsoft.Office.Interop.Word.WdColor.wdColorAqua; think doesn't work
            //_Selection.Range.HighlightColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdTurquoise; partially works

        }

        private void ListFormat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (listFormatRegion1.RegionName == "")
                {
                    MessageBox.Show("Field name cannot be blank", "Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }

        }

    }
}
