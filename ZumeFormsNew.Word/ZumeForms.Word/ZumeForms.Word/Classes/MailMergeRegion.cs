using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordFusion.Assembly.MailMerge;
using System.Windows.Forms;

namespace ZumeForms.Word.Classes {
    public class MailMergeRegion : WordFusion.Assembly.MailMerge.MergeRegion{

        private Microsoft.Office.Interop.Word.Field _StartWordField;
        public Microsoft.Office.Interop.Word.Field StartWordField {
            get {
                return _StartWordField;
            }
            set {
                _StartWordField = value;
                //FindEndWordField();
            }
        }

        private Microsoft.Office.Interop.Word.Field _EndWordField;
        public Microsoft.Office.Interop.Word.Field EndWordField {
            get {
                return _EndWordField;
            }
            set {
                _EndWordField = value;
            }
        }

        private void FindEndWordField() {

            foreach (Microsoft.Office.Interop.Word.Field fld in MailMerge.app.ActiveDocument.MailMerge.Fields) {
                if (fld.Code.Text.ToLower().Contains("ifend:" + Name)) {
                    EndWordField = fld;
                }
            }

        }

        public void Init() {

            String code = StartWordField.Code.Text;

            string regionName;
            string regionFilter;

            MailMerge.ParseRegionValue(code, out regionName, out regionFilter);

            this.Name = regionName;
            this.Filter = regionFilter;

        }

        public void SelectRegionByFields() {
            if (this.StartWordField != null) {
                Microsoft.Office.Interop.Word.Range range = this.StartWordField.Result;

                if (EndWordField != null) {
                    range.End = EndWordField.Result.End;

                    range.Select();
                }
                else {
                    MessageBox.Show("End of Region " + StartWordField.Code.Text + " could not be found.");
                }
            }
        }

        public void HighlightRegionByFields() {
            if (this.StartWordField != null) {
                Microsoft.Office.Interop.Word.Range range = this.StartWordField.Result;

                if (EndWordField != null) {
                    range.End = EndWordField.Result.End;
                    range.HighlightColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdYellow;

                }
                else {
                    MessageBox.Show("End of Region " + StartWordField.Code.Text + " could not be found.");
                }
            }
        }

        public void SelectRegion() {

            Object missing = null;
            Object findtext = "{ MERGEFIELD IFStart";

            Object fldtofind = ""; Object fldtofindend = "";
            int regionstart = 0; int regionend = 0;

            if (this.Type == WordFusion.Assembly.MailMerge.MergeRegionType.Conditional) {
                fldtofind = "ifstart:" + Name; fldtofindend = "ifend:" + Name;
            }
            else {
                fldtofind = "tablestart:" + Name; fldtofindend = "tableend:" + Name;
            }

            MailMerge.app.ActiveDocument.Select();
            if (MailMerge.app.ActiveDocument.Application.Selection.Find.Execute(ref fldtofind,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing)) {
                regionstart = MailMerge.app.ActiveDocument.Application.Selection.Start;
                //MessageBox.Show("Text found.");
            }
            else {
                MessageBox.Show("The text could not be located.");
            }

            MailMerge.app.ActiveDocument.Select();
            if (MailMerge.app.ActiveDocument.Application.Selection.Find.Execute(ref fldtofindend,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing)) {
                regionend = MailMerge.app.ActiveDocument.Application.Selection.Start;
                //MessageBox.Show("Text found.");
            }
            else {
                MessageBox.Show("The text could not be located.");
            }

            MailMerge.app.ActiveDocument.Application.Selection.Start = regionstart;
            MailMerge.app.ActiveDocument.Application.Selection.End = regionend;

        }  

    }
}
