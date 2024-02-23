using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Aspose.Words;
using System.Data;

namespace ZumeForms.Word.Classes {

    class Application {
        public static Microsoft.Office.Interop.Word._Application App;

        //public static UserControls.FormFields FormFields = new global::WordFusion.Office.Word.UserControls.FormFields();
        //public static UserControls.FieldStructure DocumentTree = new global::WordFusion.Office.Word.UserControls.FieldStructure();
        //public static WordFusionRibbon WordFusionRibbon = null;

        public static Forms.UserForms frmZumeForm = new Word.Forms.UserForms();
        public static Forms.FieldsNotInForm FieldsNotInForm = new Word.Forms.FieldsNotInForm();
        
        public static List<string> MergeTextLists = new List<string>();

        public static Boolean isActiveDocWordFusionDocument {
            get {
                Boolean retval = false;
                if (GetVariable("isDocument") != "") retval = true;
                return retval;
            }
        }

        public static Boolean isUserDocument {
            get {
                Boolean retval = false;
                if (WordFusion.SystemFramework.Helpers.Types.isGuid( GetVariable("UserFileID")) ) retval = true;
                return retval;
            }
        }

        public static Boolean isFormTemplate {
            get {
                Boolean retval = false;
                String val = GetVariable("FormID");

                if (WordFusion.SystemFramework.Helpers.Types.isGuid(val) && val != "11111111-1111-1111-1111-111111111111") retval = true;


                return retval;
            }
        }

        public static Boolean isWordFusionDocument {
            get {
                Boolean retval = false;
                if (isUserDocument || isFormTemplate) retval = true;
                return retval;
            }
        }

        public static Boolean isSaveOn {
            get;
            set;
        }
  
        //Open file in to a filestream and read data in a byte array.
        public static byte[] ReadFile(string sPath) {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            if (!System.IO.File.Exists(sPath)) return data;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file            
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read );

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            br.Close();
            return data;
        }

        public static String FormID {
            get;
            set;
        }

        private static String GetVariable(String name) {

            String retval = "";

            System.Collections.IEnumerator Ins =  Classes.Application.App.ActiveDocument.Variables.GetEnumerator();

            if (Ins != null) {
                while (Ins.MoveNext()) {

                    Microsoft.Office.Interop.Word.Variable var = (Microsoft.Office.Interop.Word.Variable)Ins.Current;

                    if (var.Name == name) {
                        retval = var.Value;
                    }                    
                }
            }

            return retval;
        }

        private static void SetVariable(String name, String value) {
            Classes.Application.App.ActiveDocument.Variables.Add(name, value);
        }

        private static Aspose.Words.SaveFormat _saveformat = SaveFormat.Docx;
        public static Aspose.Words.SaveFormat SaveFormat {
            get {
                return _saveformat;
            }
            set {
                _saveformat = value;
            }
        }
    }
}
