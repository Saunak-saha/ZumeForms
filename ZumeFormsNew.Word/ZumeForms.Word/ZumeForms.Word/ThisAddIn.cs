using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.Net;

namespace ZumeForms.Word{

    public partial class ThisAddIn    {

        Microsoft.Office.Tools.Word.Document _vstoDoc;

        private void ThisAddIn_Startup(object sender, System.EventArgs e) {

            

            Classes.FormFields.Fields = new System.Collections.ObjectModel.Collection<Classes.FormField>();

            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense("Aspose.Words.lic");

            System.Net.ServicePointManager.CertificatePolicy = new WordFusion.SystemFramework.Helpers.MyPolicy();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            this.Application.DocumentOpen += Application_DocumentOpen;

            this.Application.DocumentChange += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentChangeEventHandler(Application_WindowChanged);
            this.Application.DocumentBeforeSave += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeSaveEventHandler(Application_DocumentBeforeSave);

            Word.Classes.MailMerge.app = (Microsoft.Office.Interop.Word._Application)this.Application;
            Classes.Application.App = this.Application;

            //InitDocument();

            Classes.Application.isSaveOn = true;       
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e){

        }

        private void Application_DocumentOpen(Microsoft.Office.Interop.Word.Document Doc) {

            // Init the MailMerge Util module
            _vstoDoc = Globals.Factory.GetVstoObject(Doc);
            _vstoDoc.SelectionChange += new SelectionEventHandler(ThisDocument_SelectionChange);

            _vstoDoc.BeforeDoubleClick += new ClickEventHandler(ThisDocument_BeforeDoubleClick);
            _vstoDoc.BeforeRightClick += new ClickEventHandler(ThisDocument_BeforeRightClick);

            _vstoDoc.New += new Microsoft.Office.Interop.Word.DocumentEvents2_NewEventHandler(_vstoDoc_New);
            _vstoDoc.Open += new Microsoft.Office.Interop.Word.DocumentEvents2_OpenEventHandler(_vstoDoc_Open);

            Classes.FormFields.LoadFieldListFromDocument();
 
        }

        private void InitDocument() {



        }

        void ThisDocument_SelectionChange(object sender, Microsoft.Office.Tools.Word.SelectionEventArgs e) {

        }

        void ThisDocument_BeforeDoubleClick(object sender, Microsoft.Office.Tools.Word.ClickEventArgs e) {

            Microsoft.Office.Interop.Word.Field fld = Classes.MailMerge.SelectedField;

            if (fld != null) {
                if (Classes.MailMerge.isRegionSelected) {
                    Classes.MailMerge.RegionCurrentEdit(Classes.MailMerge.CurrentRegionType);
                }
                else {
                    if (fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldMergeField) Classes.MailMerge.FieldEdit("MailMerge", fld);
                }
            }
        }

        void ThisDocument_BeforeRightClick(object sender, Microsoft.Office.Tools.Word.ClickEventArgs e) {

        }

        void _vstoDoc_New() {

        }

        void _vstoDoc_Open() {

        }

        void Application_WindowChanged() {

        }


        private void Application_DocumentBeforeSave(Microsoft.Office.Interop.Word.Document Doc, ref bool SaveAsUI, ref bool Cancel) {

            //// isSaveOn: Addin is Saving a tempoaray file for Aspose to read
            //if (Classes.Application.isSaveOn){

            //    if (MessageBox.Show("Do you want to save this document to WordFusion?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){

            //        if (!Classes.Application.isActiveDocWordFusionDocument){
            //            if (Classes.Application.SetNewWordFusionUserFile() != DialogResult.OK){
            //                Cancel = true;
            //                return;
            //            }
            //        }
            //        SaveDocument();
            //        Cancel = true;
            //    }
            //} else{

            //}
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup(){
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
