using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordFusion.Assembly.MailMerge;
using System.Text.RegularExpressions;

namespace ZumeForms.Word.Classes {
   public class MailMergeField: WordFusion.Assembly.MailMerge.MergeField {

        private Microsoft.Office.Interop.Word.Field _WordField;
        public Microsoft.Office.Interop.Word.Field WordField {
            get {
                return _WordField;
            }
            set {
                _WordField = value;
            }
        }

        public int SelectionStart {
            get;
            set;
        }

        public int SelectionEnd {
            get;
            set;
        }

        public void Init() {

            String code = WordField.Code.Text;
            String name;
            IEnumerable<MergeFieldSwitch> switches;
            MailMerge.ParseMergeFieldValue(code, out name, out switches);

            this.Name = name;
            this.Switches = switches;

        }
    }
}

