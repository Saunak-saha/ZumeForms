using System;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;
using WordFusion.Assembly.MailMerge;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Collections;
using System.Xml.Linq;
 
namespace ZumeForms.Word.Classes {
   public static class MailMerge {
       
       public enum FieldTypes { TableStart, TableEnd, IFStart, IFShort, IFEnd, ListStart, ListItem, ListEnd, Field , None, TOC};

       public static Microsoft.Office.Interop.Word._Application app;
       public static Boolean isFieldSelected(){
           Boolean retval = false;
           if(app.ActiveWindow.Selection.Fields.Count > 0)  retval = true;
           return retval;
        }

       public static Boolean isValidRegionName(String regionname) {
           Boolean retval = true;
           return retval;
       }

       public static Boolean isRegionSelected {
           get {
               Boolean retval = false;

               if (SelectedField != null) {
                   if (SelectedField.Code.Text.ToLower().Contains("ifstart:")) retval = true;
                   if (SelectedField.Code.Text.ToLower().Contains("listformatstart:")) retval = true;
                   if (SelectedField.Code.Text.ToLower().Contains("tablestart:")) retval = true;
                   //if (SelectedField.Code.Text.ToLower().Contains("shortifstart:")) retval = true;
                }
               return retval;
           }
       }

       public static WordFusion.Assembly.MailMerge.MergeRegionType CurrentRegionType {
           get {
                WordFusion.Assembly.MailMerge.MergeRegionType retval = MergeRegionType.None;

               if (SelectedField != null) {
                   retval = RegionType(SelectedField);
               }
               return retval;
           }
       }

       public static WordFusion.Assembly.MailMerge.MergeRegionType RegionType(Microsoft.Office.Interop.Word.Field fld)  {

            WordFusion.Assembly.MailMerge.MergeRegionType retval = MergeRegionType.None;

           if (fld.Code.Text.ToLower().Contains("ifstart:")) retval = MergeRegionType.Conditional;
           if (fld.Code.Text.ToLower().Contains("listformatstart:")) retval = MergeRegionType.ListFormat;
           if (fld.Code.Text.ToLower().Contains("tablestart:")) retval = MergeRegionType.Table;
           if (fld.Code.Text.ToLower().Contains("ifend:")) retval = MergeRegionType.Conditional;
           if (fld.Code.Text.ToLower().Contains("listformatend:")) retval = MergeRegionType.ListFormat;
           if (fld.Code.Text.ToLower().Contains("tableend:")) retval = MergeRegionType.Table;
           if (fld.Code.Text.ToLower().Contains("listitem:")) retval = MergeRegionType.None;
    
           return retval;

       }

       public static String FieldEndDescription(Microsoft.Office.Interop.Word.Field fld) {

           String retval = "";

           switch (RegionType(fld)) {
               case MergeRegionType.Conditional:
                   retval = "IfEnd";
                   break;
               case MergeRegionType.ListFormat:
                   retval = "ListFormatEnd";
                   break;
               case MergeRegionType.Table:
                   retval = "TableEnd";
                   break;
            }
           return retval;
       }

       public static Microsoft.Office.Interop.Word.Field SelectedField {
           get {
               Microsoft.Office.Interop.Word.Field retval = null;

               int start1 = Convert.ToInt32( Classes.MailMerge.app.ActiveDocument.ActiveWindow.Selection.Start);
               int end1 = Convert.ToInt32(Classes.MailMerge.app.ActiveDocument.ActiveWindow.Selection.End);

               if (Classes.MailMerge.app.ActiveDocument.Fields.Count > 0) {
                   if (app.ActiveWindow.Selection.Fields.Count == 0) {
                       Object end = Word.Classes.MailMerge.app.Selection.End; Object start = Word.Classes.MailMerge.app.Selection.Start;
                       Microsoft.Office.Interop.Word.Range range = Classes.MailMerge.app.ActiveDocument.Range(ref start, ref end);
                       while (range.Fields.Count == 0) {
                           range.Start--; range.End++;
                       }

                       retval = range.Fields[1];

                       // TODO: some very odd behaviour with the evalaution of field length
                       int fldstart = Convert.ToInt32(retval.Code.Start);
                       int fldend = Convert.ToInt32(retval.Result.End);
                      
                       int isafterstart = fldstart.CompareTo(start1); // must be less or -1, 0
                       int isbeforened = fldend.CompareTo(start1); // must be more 0 ,1

                       if (isafterstart >= 0) retval = null;
                       if (isbeforened <= 0) retval = null;

                   }
                   else {
                       retval = app.ActiveWindow.Selection.Fields[1];
                   }
               }                 
               return retval;
           }
       }

       public static Microsoft.Office.Interop.Word.Range RegionGet(String regionstartname) {

           Microsoft.Office.Interop.Word.Range retval;

           String regiontypeend = regionstartname.Replace("start", "end");
 
           app.Selection.PreviousField();
           while (!app.Selection.Fields[1].Code.Text.ToLower().Contains(regionstartname)) {
                Microsoft.Office.Interop.Word.Field fld =  app.Selection.PreviousField();
           }

           retval = app.Selection.Range;

           app.Selection.NextField();
           while (!app.Selection.Fields[1].Code.Text.ToLower().Contains(regiontypeend)) {
               app.Selection.NextField();
           }

           retval.End  = app.Selection.Range.End;

           return retval;
       }

       public static void RegionCurrentEdit(WordFusion.Assembly.MailMerge.MergeRegionType type) {

            Word.Classes.MailMergeRegion region = Classes.MailMerge.CurrentRegionGet(type);
            if (region != null) {

                RegionEdit(type, region);

            }
        }

       public static void RegionEdit(WordFusion.Assembly.MailMerge.MergeRegionType type, Word.Classes.MailMergeRegion region) {
            if (region != null && type == region.Type) {
                switch (type) {
                    case MergeRegionType.Conditional:
                        //Load the Conditional Merge Region Form
                        Forms.ConditionalRegion frmconditional = new Forms.ConditionalRegion();
                        frmconditional.MailMergeRegion = region;
                        frmconditional.ShowDialog(Globals.ThisAddIn.Application.ActiveWindow.Selection);
                        break;
                    case MergeRegionType.Table:
                        Forms.TableRegion frmtable = new global::ZumeForms.Word.Forms.TableRegion();
                        frmtable.MailMergeRegion = region;
                        frmtable.ShowDialog(Globals.ThisAddIn.Application.ActiveWindow.Selection);
                        break;
                    case MergeRegionType.ListFormat:
                        Forms.ListFormat frmlistformat = new Word.Forms.ListFormat();
                        frmlistformat.MailMergeRegion = region;
                        frmlistformat.ShowDialog(Globals.ThisAddIn.Application.ActiveWindow.Selection);
                        break;
                }
                region.SelectRegionByFields();
            }
        }

       public static Word.Classes.MailMergeRegion RegionGet(Microsoft.Office.Interop.Word.Field fldstart) {

            Word.Classes.MailMergeRegion retval = new MailMergeRegion();

            if (fldstart != null) {
                String regionnamestart = "", regionfilterstart = "";
                ParseRegionValue(fldstart.Code.Text, out regionnamestart, out regionfilterstart);
                Microsoft.Office.Interop.Word.Field fldend = RegionGetEnd(fldstart);

                retval.Name = regionnamestart;
                retval.Filter = regionfilterstart;
                retval.StartWordField = fldstart;
                retval.EndWordField = fldend;
            }
            return retval;          
       }       

       public static void ListFormatRegionNew() {
            Forms.ListFormat frm = new Forms.ListFormat();
            frm.ShowDialog(app.Application.ActiveWindow.Selection);
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK) {
                frm.AddRegion();
            }
        }

       public static void ListFormatItemNew(Microsoft.Office.Interop.Word.Selection selection) {

            int mystart = selection.Start; int myend = selection.End;

            Word.Classes.MailMergeRegion region = Classes.MailMerge.CurrentRegionGet(MergeRegionType.ListFormat);
            if (region != null) {

                object fldtype = Microsoft.Office.Interop.Word.WdFieldType.wdFieldEmpty;
                object preserve = true;

                object fldname = "MERGEFIELD  ListItem:" + region.Name;
                selection.Start = mystart; selection.End = myend;

                Microsoft.Office.Interop.Word.Field newitem = selection.Fields.Add(selection.Range, ref fldtype, ref fldname, ref preserve);
                newitem.Code.Text = newitem.Code.Text.Replace(@"\* MERGEFORMAT", "");
            }
        }

        /*public static void ShortIfNew() {
            ShortIfNew("");
        }

        public static void ShortIfNew(String fieldname) {
            Forms.ShortIf frm = new Forms.ShortIf();
            //frm.FieldName = fieldname;
            frm.ShowDialog(app.Application.ActiveWindow.Selection);
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                frm.AddField();
            }
        }*/

       public static void ConditionalRegionNew() {
          ConditionalRegionNew("");
       }

       public static void ConditionalRegionNew(String regionname) {
            Forms.ConditionalRegion frm = new Forms.ConditionalRegion();
            frm.RegionName = regionname;
            if (frm.ShowDialog(app.Application.ActiveWindow.Selection) == System.Windows.Forms.DialogResult.OK) {
                frm.AddRegion();
            }
        }

        public static void TableRegionNew() {
           TableRegionNew("");
       }

       public static void TableRegionNew(String regionname) {
            Forms.TableRegion frm = new global::ZumeForms.Word.Forms.TableRegion();
            frm.MailMergeRegion = new MailMergeRegion();
            frm.MailMergeRegion.Name = regionname;
            frm.ShowDialog(app.Application.ActiveWindow.Selection);
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK) {
                frm.AddRegion();
            }
        }

       public static Word.Classes.MailMergeRegion CurrentRegionGet(WordFusion.Assembly.MailMerge.MergeRegionType type) {

            MailMergeRegion retval = new MailMergeRegion();
            //retval.Type =  MergeRegionType.None;
            FieldTypes RequiredField = new FieldTypes();
            switch (type) {
                case MergeRegionType.Conditional:
                    RequiredField = FieldTypes.IFStart;
                    break;
                case MergeRegionType.ListFormat:
                    RequiredField = FieldTypes.ListStart;
                    break;
                case MergeRegionType.Table:
                    RequiredField = FieldTypes.TableStart;
                    break;
                case MergeRegionType.None:
                    //??
                    break;
            }

            retval.Type = type;
            Microsoft.Office.Interop.Word.Field fldstart;
            Microsoft.Office.Interop.Word.Field fldend = null;
            Collection<String> regionstoignore = new Collection<String>();

            String regionnamestart = "", regionfilterstart = "";

            if (app.Selection.Fields.Count > 0) {
                fldstart = app.Selection.Fields[1];
            }
            else {
                Object end = Word.Classes.MailMerge.app.Selection.End; Object start = Word.Classes.MailMerge.app.Selection.Start;
                Microsoft.Office.Interop.Word.Range range = Classes.MailMerge.app.ActiveDocument.Range(ref start, ref end);

                while (range.Fields.Count == 0) {
                    range.Start--; range.End++;
                }


                var fld = range.Fields[1];

                FieldTypes CurrentField = FieldType(range.Fields[1]);
                while (CurrentField != RequiredField) {
                    range.Start--; range.End++;
                    CurrentField = FieldType(range.Fields[1]);
                }
                
                //call field check
                fldstart = range.Fields[1];
            }

            if (fldstart != null) {

                ParseRegionValue(fldstart.Code.Text, out regionnamestart, out regionfilterstart);
                String val = FieldEndDescription(fldstart).ToLower() + ":" + regionnamestart.ToLower();

                IEnumerator oFieldEnumerator = Word.Classes.MailMerge.app.ActiveDocument.Fields.GetEnumerator();

                while (oFieldEnumerator.MoveNext()) {
                    Microsoft.Office.Interop.Word.Field field = oFieldEnumerator.Current as Microsoft.Office.Interop.Word.Field;
                    //field.Select();
                    //Microsoft.Office.Interop.Word.Range FieldRange = Word.Classes.MailMerge.app.Selection.Range;
                    //string strField = FieldRange.Text;
                    // this will show the merge fields with the << >>

                    string strField = field.Code.Text;

                    if (strField.ToLower().Contains(val.ToLower())) {
                        fldend = field;
                        break;
                    }

                }

                retval.Name = regionnamestart;
                retval.Filter = regionfilterstart;
                retval.StartWordField = fldstart;
                retval.EndWordField = fldend;

                retval.Type = SetCurrentRegionType(retval);

            }

            return retval;
       }

       private static WordFusion.Assembly.MailMerge.MergeRegionType SetCurrentRegionType(Word.Classes.MailMergeRegion region) {

            WordFusion.Assembly.MailMerge.MergeRegionType retval = MergeRegionType.None;

           String val = region.StartWordField.Code.Text;

           if (val.ToLower().Contains("ifstart")) retval = MergeRegionType.Conditional;
           if (val.ToLower().Contains("tablestart")) retval = MergeRegionType.Table;
           if (val.ToLower().Contains("listformatstart")) retval = MergeRegionType.ListFormat;

           return retval;

       }

       public static Microsoft.Office.Interop.Word.Field RegionGetEnd(Microsoft.Office.Interop.Word.Field fldstart) {
           
           Microsoft.Office.Interop.Word.Field retval=null;

           String regionnamestart = "", regionfilterstart = "";
           ParseRegionValue(fldstart.Code.Text, out regionnamestart, out regionfilterstart);
           String val = FieldEndDescription(fldstart).ToLower() + ":" + regionnamestart.ToLower();

           Object start = fldstart.Code.Start; Object end = Classes.MailMerge.app.ActiveDocument.Characters.Count;
           //Microsoft.Office.Interop.Word.Range range = Classes.MailMerge.app.ActiveDocument.Range(ref start, ref end);

           //range.Select();
            retval = app.Selection.NextField();
           String regionnameend = ""; IEnumerable<MergeFieldSwitch> switches;
           ParseMergeFieldValue(retval.Code.Text, out regionnameend, out switches);

           while (regionnameend.ToLower() != val.ToLower() && retval != null ) {
               retval = app.Selection.NextField();

               if (retval != null) {                
                   if (retval.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldTOC) {
                       Word.Classes.MailMerge.app.Selection.Start = retval.Result.End + 1;
                       Word.Classes.MailMerge.app.Selection.End = retval.Result.End + 1;
                   }                   
                   ParseMergeFieldValue(retval.Code.Text, out regionnameend, out switches);
               }
           }

           return retval;
       }

       public static FieldTypes FieldType(Microsoft.Office.Interop.Word.Field fld) {

           FieldTypes retval = FieldTypes.Field;

           if (fld == null) {
               retval = FieldTypes.None;
           }
           else {
               if (fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldMergeField) {
                   if (fld.Code.Text.ToLower().Contains("ifstart:")) retval = FieldTypes.IFStart;
                   if (fld.Code.Text.ToLower().Contains("listformatstart:")) retval = FieldTypes.ListStart;
                   if (fld.Code.Text.ToLower().Contains("tablestart:")) retval = FieldTypes.TableStart;
                   if (fld.Code.Text.ToLower().Contains("ifend:")) retval = FieldTypes.IFEnd;
                   if (fld.Code.Text.ToLower().Contains("listformatend:")) retval = FieldTypes.ListEnd;
                   if (fld.Code.Text.ToLower().Contains("tableend:")) retval = FieldTypes.TableEnd;
                   if (fld.Code.Text.ToLower().Contains("listitem:")) retval = FieldTypes.ListItem;
               }
               else if (fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldIf) {
                    retval = FieldTypes.IFShort;
               }
               else if (fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldTOC) {
                   retval = FieldTypes.TOC;
               }
               else if (fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldRef) {
                   retval = FieldTypes.TOC;
               }
           }

           return retval;

       }

        public static FieldTypes FieldTypeFromXElement(XElement fld) {

            FieldTypes retval = FieldTypes.Field;

            if (fld == null) {
                retval = FieldTypes.None;
            }
            else {
                //if (fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldMergeField) {
                    //if (fld.Code.Text.ToLower().Contains("ifstart:")) retval = FieldTypes.IFStart;
                    //if (fld.Code.Text.ToLower().Contains("listformatstart:")) retval = FieldTypes.ListStart;
                    //if (fld.Code.Text.ToLower().Contains("tablestart:")) retval = FieldTypes.TableStart;
                    //if (fld.Code.Text.ToLower().Contains("ifend:")) retval = FieldTypes.IFEnd;
                    //if (fld.Code.Text.ToLower().Contains("listformatend:")) retval = FieldTypes.ListEnd;
                    //if (fld.Code.Text.ToLower().Contains("tableend:")) retval = FieldTypes.TableEnd;
                    //if (fld.Code.Text.ToLower().Contains("listitem:")) retval = FieldTypes.ListItem;
                //}
                //else if (fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldIf) {
                //    retval = FieldTypes.IFShort;
                //}
                //else if (fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldTOC) {
                //    retval = FieldTypes.TOC;
                //}
                //else if (fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldRef) {
                //    retval = FieldTypes.TOC;
                //}
            }

            return retval;

        }

        public static void FieldEdit(string type, Microsoft.Office.Interop.Word.Field fld) {

            if (fld != null && type != null) {

                if (fld.Code.Text.ToLower().Contains("tableend:") || fld.Code.Text.ToLower().Contains("ifend:") || fld.Code.Text.ToLower().Contains("listformatend:")) return;
                if (fld.Code.Text.ToLower().Contains("tablestart:") || fld.Code.Text.ToLower().Contains("ifstart:") || fld.Code.Text.ToLower().Contains("listformatstart:")) return;
            
                switch (type) {
                    case "MailMerge" :
                        Word.Classes.MailMergeField mergefld = new Word.Classes.MailMergeField();
                        mergefld.WordField = fld;

                        if (mergefld.WordField != null) {
                            mergefld.Init();
                            Forms.MergeField frm = new Forms.MergeField();
                            frm.Field = mergefld;
                            frm.Init();
                            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                                if (frm.hasFieldName) {
                                    mergefld.WordField.Code.Text = mergefld.WordField.Code.Text.Replace(@"\* MERGEFORMAT", "");
                                }
                            } else {
                                if (!frm.hasFieldName) {
                                    fld.Delete();
                                }
                            }
                        }
                        break;
                    case "ShortIf" :
                        /*Word.Classes.MailMergeField shortiffld = new Word.Classes.MailMergeField();
                        shortiffld.WordField = fld;

                        if (shortiffld.WordField != null) {
                            shortiffld.Init();
                            Forms.ShortIf frm = new Forms.ShortIf();
                            //frm.Field = mergefld;
                        }*/
                        break;
                }
            }

            

            // Todo: Tidy up
            //if (fld.Code.Text.ToLower().Contains("tableend:") || fld.Code.Text.ToLower().Contains("ifend:") || fld.Code.Text.ToLower().Contains("listformatend:")) return;
            //if (fld.Code.Text.ToLower().Contains("tablestart:") || fld.Code.Text.ToLower().Contains("ifstart:") || fld.Code.Text.ToLower().Contains("listformatstart:")) return;


            /*Word.Classes.MailMergeField mergefld = new Word.Classes.MailMergeField();
            mergefld.WordField = fld;

            if (mergefld.WordField != null) {
                mergefld.Init();
                Forms.MergeField frm = new Forms.MergeField();
                frm.Field = mergefld;
                frm.Init();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

                    // No single Doc tree must manually reload
                    // Modify the Document Tree 
                    // Find the region node in the Document Tree
                    //MailMergeRegion region = CurrentRegionGet(MergeRegionType.Conditional);

                    //TreeNode parenttreenode = null;
                    //FieldLoadStart(ref parenttreenode, region.StartWordField, Application.DocumentTree.RootNode);

                    //// Have found the Document Tree node so add the next field under it
                    //TreeNode fldtreenode = new TreeNode();
                    //Collection<Microsoft.Office.Interop.Word.Field> col = new Collection<Microsoft.Office.Interop.Word.Field>();
                    //col.Add(mergefld.WordField);

                    if (frm.hasFieldName) {

                        //String fldname = ""; IEnumerable<MergeFieldSwitch> switches;
                        //Classes.MailMerge.ParseMergeFieldValue(mergefld.WordField.Code.Text, out fldname, out switches);
                        mergefld.WordField.Code.Text = mergefld.WordField.Code.Text.Replace(@"\* MERGEFORMAT", "");
             
                    } else{
                        //fld.Delete();
                    }


                } else {                    
                    if(! frm.hasFieldName) {
                        fld.Delete();
                    }                                       
                }
            }*/
        }

       public static  Microsoft.Office.Interop.Word.Field FieldNext() {

           Microsoft.Office.Interop.Word.Field retval = Word.Classes.MailMerge.app.Selection.NextField();

           if (retval != null) {
               while (Classes.MailMerge.FieldType(retval) != FieldTypes.Field) {

                   if (retval.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldTOC) {
                       Word.Classes.MailMerge.app.Selection.Start = retval.Result.End + 1;
                       Word.Classes.MailMerge.app.Selection.End = retval.Result.End + 1;
                   }                  
                   
                   retval = Word.Classes.MailMerge.app.Selection.NextField();
                   if (retval == null) break;
               }
           }

           return retval;
       }

       public static Microsoft.Office.Interop.Word.Field FieldPrev() {

           Microsoft.Office.Interop.Word.Field retval = Word.Classes.MailMerge.app.Selection.PreviousField();

           if (retval != null) {
               while (Classes.MailMerge.FieldType(retval) != FieldTypes.Field) {

                   if (retval.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldTOC) {
                       Word.Classes.MailMerge.app.Selection.Start = retval.Result.Start - 1;
                       Word.Classes.MailMerge.app.Selection.End = retval.Result.Start - 1;
                   }  

                   retval = Word.Classes.MailMerge.app.Selection.PreviousField();
                   if (retval == null) break;
               }
           }

         

           return retval;
       }

       private static void FieldLoadStart(ref TreeNode treenode, Microsoft.Office.Interop.Word.Field regionstart, TreeNode parentnode) {
           foreach (TreeNode node in parentnode.Nodes) {
               System.Collections.ObjectModel.Collection<Microsoft.Office.Interop.Word.Field> col =
                   (System.Collections.ObjectModel.Collection<Microsoft.Office.Interop.Word.Field>)node.Tag;

               Microsoft.Office.Interop.Word.Field trefld = (Microsoft.Office.Interop.Word.Field)col[0];
               if (trefld.Code.Start == regionstart.Code.Start) {
                   treenode = node;
                    break;
               }
               FieldLoadStart(ref treenode, regionstart, node);
           }
       }

       public static void TableRegionEdit(Microsoft.Office.Interop.Word.Field SelectedField) {
           MailMergeRegion region = Classes.MailMerge.RegionGet(SelectedField);
           RegionEdit(MergeRegionType.Table, region);
       }

       public static void CheckFieldStructure() {
           UserControls.FieldStructure fld = new Word.UserControls.FieldStructure();
           if (fld.FieldStructureLoad() == true) MessageBox.Show("Document has been validated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
       }

       public static void ConditionalRegionEdit(Microsoft.Office.Interop.Word.Field SelectedField) {        
           MailMergeRegion region = Classes.MailMerge.RegionGet(SelectedField);
           RegionEdit(MergeRegionType.Conditional, region);
       }

        public static MailMergeRegion RegionNext(Classes.MailMerge.FieldTypes type) {

           MailMergeRegion retval = null;

            Microsoft.Office.Interop.Word.Field fld = Word.Classes.MailMerge.app.Selection.NextField();

            if (fld != null) {
                Application.App.ScreenUpdating = false;

                while (Classes.MailMerge.FieldType(fld) != type && fld != null) {
                    if (fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldTOC || fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldIf) {
                        Word.Classes.MailMerge.app.Selection.Start = fld.Result.End + 1;
                        Word.Classes.MailMerge.app.Selection.End = fld.Result.End + 1;
                    }
                    fld = Word.Classes.MailMerge.app.Selection.NextField();
                    if (fld == null) break;
                }

                retval = RegionGet(fld);
            }

            Application.App.ScreenUpdating = true;

            return retval;
       }

       public static MailMergeRegion RegionPrevious(Classes.MailMerge.FieldTypes type) {

           MailMergeRegion retval = null;

            Microsoft.Office.Interop.Word.Field fld = Word.Classes.MailMerge.app.Selection.PreviousField();

            if (fld != null) {
                Application.App.ScreenUpdating = false;

                while (Classes.MailMerge.FieldType(fld) != type && fld != null) {
                    if (fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldTOC || fld.Type == Microsoft.Office.Interop.Word.WdFieldType.wdFieldIf) {
                        Word.Classes.MailMerge.app.Selection.Start = fld.Result.Start - 1;
                        Word.Classes.MailMerge.app.Selection.End = fld.Result.Start - 1;
                    }
                    fld = Word.Classes.MailMerge.app.Selection.PreviousField();
                    if (fld == null) break;
                }
                retval = RegionGet(fld);
            }

            Application.App.ScreenUpdating = true;
            return retval;
       }

       public static void ListRegionEdit(Microsoft.Office.Interop.Word.Field SelectedField) {
           MailMergeRegion region = Classes.MailMerge.RegionGet(SelectedField);
           RegionEdit(MergeRegionType.ListFormat, region);
       }

       public static Microsoft.Office.Interop.Word.Field FieldNew(String fieldname) {
           return FieldNew(fieldname, app.ActiveDocument.ActiveWindow.Selection.Range);
       }

       public static Microsoft.Office.Interop.Word.Field FieldNew() {

           String fldname = "NewField";

           if (app.ActiveDocument.ActiveWindow.Selection.Text != "" && app.ActiveDocument.ActiveWindow.Selection.Text !=  "«") {
               fldname = app.ActiveDocument.ActiveWindow.Selection.Text;
           }

           return FieldNew(fldname, app.ActiveDocument.ActiveWindow.Selection.Range);
       }

       public static Microsoft.Office.Interop.Word.Field FieldNew(String fieldname, Microsoft.Office.Interop.Word.Range range) {
           
           Microsoft.Office.Interop.Word.Field retval= null;
           
           Object type = Microsoft.Office.Interop.Word.WdFieldType.wdFieldEmpty;
           Object text = "MERGEFIELD " + fieldname;
           Object preserveformatting = true;

           retval = app.ActiveDocument.ActiveWindow.Selection.Fields.Add(range, ref type, ref text, ref preserveformatting);

            String fldname = ""; IEnumerable<MergeFieldSwitch> switches;
           ParseMergeFieldValue(retval.Code.Text, out fldname, out switches);
           Classes.FormFields.addField(fldname);

           return retval;

       }

        public static void ParseMergeFieldValue(String value, out String name, out IEnumerable<MergeFieldSwitch> switches) {

            name = null;
            switches = null;

            // The structure of a Word merge field value is as follows:
            // MERGEFIELD <<FieldName>> <<Switches>>
            // e.g MERGEFIELD  FirstName  \* MERGEFORMAT

            // Split the value to get the switches
            string[] components = value.Trim().Split(@"\".ToCharArray());

            // The first component contains the word MERGEFIELD, 
            // followed by the merge field label, separated by a space

            // Set the name
            name = components[0].Replace("MERGEFIELD", "").Trim();
            name = name.Replace("mergefield", "").Trim();

            if (name.Contains("«") || name.Contains("»")) {

            }

            Regex regex = new Regex("«.*?»", RegexOptions.IgnoreCase);
            name = regex.Replace(name, "").Trim();

            name = Regex.Replace(name, "TableStart:", "", RegexOptions.IgnoreCase);

            // Set the switches
            switches = ParseMergeFieldSwitches(components);
        }


        private static IEnumerable<MergeFieldSwitch> ParseMergeFieldSwitches(string[] components) {

            List<MergeFieldSwitch> switches = new List<MergeFieldSwitch>();
            string component;
            string name;
            string value;
            int valueIndex;

            if (components.Length > 1) {
                for (int i = 1; i < components.Length; i++) {
                    component = components[i].Trim();

                    // Does this component contain a value?
                    valueIndex = component.IndexOf(" ");

                    if (valueIndex > -1) {
                        name = component.Substring(0, valueIndex).Trim();
                        value = component.Substring(valueIndex + 1).Trim();

                        Regex regex = new Regex("«.*?»", RegexOptions.IgnoreCase);
                        value = regex.Replace(value, "");

                    }
                    else {
                        name = component.Trim();
                        value = "";
                    }

                    switches.Add(new MergeFieldSwitch(name, value));
                }
            }

            return switches;
        }

        public static Boolean isRegionStart(String fldcode, MergeRegionType type) {

            Boolean retval = false;
            String regiontypestart = "";

            switch (type) {
                case MergeRegionType.Conditional:
                    regiontypestart = "ifstart:"; ;
                    break;
                case MergeRegionType.ListFormat:
                    regiontypestart = "listformatstart:"; ;
                    break;
                case MergeRegionType.Table:
                    regiontypestart = "tablestart:"; ;
                    break;
            }

            if (fldcode.ToLower().Contains(regiontypestart)) {
                retval = true;
            }

            return retval;

        }

        public static Boolean isRegionEnd(String fldcode, MergeRegionType type) {

            Boolean retval = false;
            String regiontypeend = "";

            switch (type) {
                case MergeRegionType.Conditional:
                    regiontypeend = "ifend:";
                    break;
                case MergeRegionType.ListFormat:
                    regiontypeend = "listformatend:";
                    break;
                case MergeRegionType.Table:
                    regiontypeend = "tableend:";
                    break;
            }

            if (fldcode.ToLower().Contains(regiontypeend)) {
                retval = true;
            }

            return retval;

        }

        public static void ParseRegionValue(String value, out String name, out String filter) {

            name = null;
            filter = null;

            // The structure of a Region is as follows:
            // MERGEFIELD <<RegionName>> <<Filter>>
            // e.g MERGEFIELD IfStart:Taxable Taxable = 1

            // Split the value to get the switches
            String[] components = value.Replace("\"", "").Trim().Split(":".ToCharArray());

            // The first component contains the word MERGEFIELD, 
            // followed by the merge field label, separated by a space

            // Set the name
            if (components.Length > 1) {
                String[] subComponents = components[1].Split(" ".ToCharArray());
                name = subComponents[0].Trim();

                if (subComponents.Length > 1) {
                    filter = "";
                    for (int i = 1; i < subComponents.Length; i++) {
                        if (i > 1)
                            filter += " ";
                        filter += subComponents[i].Trim();
                    }
                }
            }
            if (filter != null) {
                filter = filter.Replace(@"\* MERGEFORMAT", "");
                filter = filter.Replace(@"\* mergeformat", "");
                filter = filter.Replace(@"\* MergeFormat", "");
            }
        }
    }
}
