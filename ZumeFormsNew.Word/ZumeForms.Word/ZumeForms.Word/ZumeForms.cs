using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Collections;
using WordFusion.Assembly.MailMerge;

namespace ZumeForms.Word{

    public partial class ZumeForms {

        private void btnMergeField_Click(object sender, RibbonControlEventArgs e) {

            if (Classes.MailMerge.SelectedField != null) {
                if (!Classes.MailMerge.isRegionSelected) {
                    Classes.MailMerge.FieldEdit("MailMerge", Classes.MailMerge.SelectedField);
                }
            }
            else {
                Classes.MailMerge.FieldEdit("MailMerge", Classes.MailMerge.FieldNew());
            }

        }

        private void btnPrev_Click(object sender, RibbonControlEventArgs e) {
            Word.Classes.MailMerge.app.Selection.PreviousField();
        }

        private void btnNext_Click(object sender, RibbonControlEventArgs e) {
            Word.Classes.MailMerge.app.Selection.NextField();
        }

        /*private void btnShortIf_Click(object sender, RibbonControlEventArgs e) {
            if (Word.Classes.MailMerge.isRegionSelected) {
                Classes.MailMerge.RegionCurrentEdit(global::WordFusion.Assembly.MailMerge.MergeRegionType.None);
            } else {
                Classes.MailMerge.ShortIfNew();
            }
        }*/

        private void btnConditionalRegionEdit_Click(object sender, RibbonControlEventArgs e) {
            if (Word.Classes.MailMerge.isRegionSelected) {
                Classes.MailMerge.RegionCurrentEdit(global::WordFusion.Assembly.MailMerge.MergeRegionType.Conditional);
            }
            else {
                Classes.MailMerge.ConditionalRegionNew();
            }
        }

        private void btnIFPrev_Click(object sender, RibbonControlEventArgs e) {
            Classes.MailMergeRegion region = Word.Classes.MailMerge.RegionPrevious(Word.Classes.MailMerge.FieldTypes.IFStart);
            if (region != null) region.SelectRegionByFields();
        }

        private void btnIFNext_Click(object sender, RibbonControlEventArgs e) {
            Classes.MailMergeRegion region = Word.Classes.MailMerge.RegionNext(Word.Classes.MailMerge.FieldTypes.IFStart);
            if (region != null) region.SelectRegionByFields();
        }

        private void btnRepeat_Click(object sender, RibbonControlEventArgs e) {
            if (Word.Classes.MailMerge.isRegionSelected) {
                Classes.MailMerge.RegionCurrentEdit(global::WordFusion.Assembly.MailMerge.MergeRegionType.Table);
            }
            else {
                Classes.MailMerge.TableRegionNew();
            }
        }

        private void btnRepeatPrev_Click(object sender, RibbonControlEventArgs e) {
            Classes.MailMergeRegion region = Word.Classes.MailMerge.RegionPrevious(global::ZumeForms.Word.Classes.MailMerge.FieldTypes.TableStart);
            if (region != null) region.SelectRegionByFields();
        }

        private void btnRepeatNext_Click(object sender, RibbonControlEventArgs e) {
            Classes.MailMergeRegion region = Word.Classes.MailMerge.RegionNext(global::ZumeForms.Word.Classes.MailMerge.FieldTypes.TableStart);
            if (region != null) region.SelectRegionByFields();
        }

        private void btnListRegion_Click(object sender, RibbonControlEventArgs e) {
            if (Word.Classes.MailMerge.isRegionSelected) {
                Classes.MailMerge.RegionCurrentEdit(WordFusion.Assembly.MailMerge.MergeRegionType.ListFormat);
            }
            else {
                Classes.MailMerge.ListFormatRegionNew();
            }
        }

        private void btnListRegionAddItem_Click(object sender, RibbonControlEventArgs e) {
            Classes.MailMerge.ListFormatItemNew(Word.Classes.MailMerge.app.Selection);
        }

        private void btnListPrev_Click(object sender, RibbonControlEventArgs e) {
            Classes.MailMergeRegion region = Word.Classes.MailMerge.RegionPrevious(Word.Classes.MailMerge.FieldTypes.ListStart);
            if (region != null) region.SelectRegionByFields();
        }

        private void btnListNext_Click(object sender, RibbonControlEventArgs e) {
            Classes.MailMergeRegion region = Word.Classes.MailMerge.RegionNext(Word.Classes.MailMerge.FieldTypes.ListStart);
            if (region != null) region.SelectRegionByFields();
        }

        private void btnDelEmptyRow_Click(object sender, RibbonControlEventArgs e) {
            Classes.Application.App.ActiveWindow.Selection.InsertAfter("WF:DelRow");
        }

        private void btnDelEmptyPara_Click(object sender, RibbonControlEventArgs e) {
            Classes.Application.App.ActiveWindow.Selection.InsertAfter("WF:DelEmptyPara");
        }

        private void btnFieldStructure_Click(object sender, RibbonControlEventArgs e) {
            Forms.FieldStructure frm = new Forms.FieldStructure();
            frm.Show();
        }

        private void btnStructureValidate_Click(object sender, RibbonControlEventArgs e) {
            Classes.MailMerge.CheckFieldStructure();
        }

        private void btnLoadFormFields_Click(object sender, RibbonControlEventArgs e) {

            if(Classes.Application.frmZumeForm.IsDisposed) { Classes.Application.frmZumeForm = new Word.Forms.UserForms(); }

            Classes.Application.frmZumeForm.Show();
            Classes.Application.frmZumeForm.BringToFront();
        }

        private void btnZSWeb_Click(object sender, RibbonControlEventArgs e) {
            System.Diagnostics.Process.Start("https://syntaq.zendesk.com/hc/en-us");
        }

        private void btnFieldCheck_Click(object sender, RibbonControlEventArgs e) {

            if (Classes.Application.FieldsNotInForm.IsDisposed) { Classes.Application.FieldsNotInForm = new Word.Forms.FieldsNotInForm(); }
            Classes.Application.FieldsNotInForm.CheckFields();

        }

        private void btnConvert_Click(object sender, RibbonControlEventArgs e) {

        }
    }
}
