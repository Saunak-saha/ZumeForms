using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using System.Data;
using WordFusion.Assembly.MailMerge;
using System.Collections;

namespace ZumeForms.Word.Classes {

    public struct FormField {
        public string Field { get; set; }
        public string FieldType { get; set; }
    }

    public static class FormFields {

        public static Collection<FormField> Fields {
            get; set;
        }

        public static void addField(String fldname) {
            FormField datafld = new FormField();
            datafld.Field = fldname;
            datafld.FieldType = "WordFusion.Controls.Text";
            Fields.Add(datafld);

            // comment
        }

        public static Collection<FormField> FieldsForm {
            get; set;
        }

        public static void  addFieldForm(String fldname){
            FormField datafld = new FormField();
            datafld.Field = fldname; 
            datafld.FieldType = "WordFusion.Controls.Text";
            FieldsForm.Add(datafld);
        }

        public static System.Data.DataTable FieldFormDataSet {
            get {

                DataTable retval = new DataTable();

                foreach (FormField fld in Fields) {
                    if (!fld.Field.ToLower().Contains("ifstart") && !fld.Field.ToLower().Contains("tablestart") && !fld.Field.ToLower().Contains("listformatstart") && !fld.Field.ToLower().Contains("ifend") && !fld.Field.ToLower().Contains("tableend") && !fld.Field.ToLower().Contains("listformatend")) {
                        if (! retval.Columns.Contains(fld.Field)) {
                            DataColumn col = retval.Columns.Add(fld.Field);
                            col.DataType = typeof(System.String);
                        }
                    }
                }
                return retval;
            }
        }

        public static System.Data.DataTable FieldList {
            get {

                DataTable retval = new DataTable();
                retval.TableName = "Fields";
                retval.Columns.Add("Field");

                foreach (FormField fld in Fields) {

                    if (!fld.Field.ToLower().Contains("ifstart") && !fld.Field.ToLower().Contains("tablestart") && !fld.Field.ToLower().Contains("listformatstart") && !fld.Field.ToLower().Contains("ifend") && !fld.Field.ToLower().Contains("tableend") && !fld.Field.ToLower().Contains("listformatend")) {
                        String filter = "Field = '" + fld.Field + "'";
                        System.Data.DataView dv = new System.Data.DataView(retval, filter, "Field", System.Data.DataViewRowState.CurrentRows);
                        if (dv.Count == 0) {
                            retval.Rows.Add(new Object[] { fld.Field });
                        }   
                    }

                 

                }
                return retval;
            }
        }

        public static System.Data.DataSet FieldDataSet {
            get;
            set;
        }

        public static void LoadFieldListFromDocument() {

                try {

                Fields.Clear();

                    IEnumerator oFieldEnumerator = Word.Classes.MailMerge.app.ActiveDocument.Fields.GetEnumerator();
                    while (oFieldEnumerator.MoveNext()) {
                        Microsoft.Office.Interop.Word.Field field = oFieldEnumerator.Current as Microsoft.Office.Interop.Word.Field;
                        String strField = field.Code.Text;

                        Classes.FormField datafld = new Classes.FormField();
                        Word.Classes.MailMerge.FieldTypes fldtype = Word.Classes.MailMerge.FieldType(field);

                        if (fldtype == MailMerge.FieldTypes.Field) {
                            String fldname = ""; IEnumerable<MergeFieldSwitch> switches;
                            Classes.MailMerge.ParseMergeFieldValue(strField, out fldname, out switches);
                            datafld.Field = fldname; datafld.FieldType = "WordFusion.Controls.Text";
                            Classes.FormFields.Fields.Add(datafld);
                        }
                    }

                }
                finally {

                }

        }

        public static DataSet FilterDataSet {
            get {
                DataSet retval = new DataSet();
                retval = FieldDataSet.Copy();
                LoadConditionalFieldDataSet(retval);
                return retval;
            }
        }

        private static void LoadConditionalFieldDataSet(DataSet data) {

            foreach (DataRelation rel in data.Relations) {
                LoadConditionalFieldDataSetChild(rel.ParentTable, rel.ChildTable);
            }
        }

        private static void LoadConditionalFieldDataSetChild(DataTable parenttbl, DataTable chiltbl) {
            // Add each row in as Column for the FieldName
            foreach (DataRow row in chiltbl.Rows) {
                String ctrlname = row["Field Name"].ToString();
                if (!chiltbl.Columns.Contains(ctrlname)) {
                    chiltbl.Columns.Add(ctrlname);
                }
            }
        }
    }
}