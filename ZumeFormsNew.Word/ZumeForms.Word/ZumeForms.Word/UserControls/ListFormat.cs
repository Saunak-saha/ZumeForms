using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZumeForms.Word.UserControls {
    public partial class ListFormat : UserControl {
        public ListFormat() {
            InitializeComponent();
        }

        public Classes.MailMergeRegion MailMergeRegion = new Classes.MailMergeRegion();

        public void Init() {
            if (MailMergeRegion != null) {
                txtName.Text = MailMergeRegion.Name;
                lstType.Text = MailMergeRegion.Filter;
            }
        }

        public String RegionName {
            get {
                return txtName.Text;
            }
            set {
                txtName.Text = value;
            }
        }

        public String Filter {
            get {
                return lstType.Text;
            }
            set {
                lstType.Text = value;
            }
        }

        private String StartCode {
            get {
                String retval = "MERGEFIELD ListFormatStart:" + MailMergeRegion.Name + " " + lstType.Text;
                return retval;
            }
        }

        private String EndCode {
            get {
                String retval = "MERGEFIELD ListFormatEnd:" + MailMergeRegion.Name;
                return retval;
            }
        }

        public void FieldCodeSet() {
            if (MailMergeRegion != null) {
                MailMergeRegion.Name = txtName.Text;
                MailMergeRegion.Filter = lstType.Text;
                FieldCodeSetStart();
                FieldCodeSetEnd();
            }
        }

        private void FieldCodeSetStart() {
            if (MailMergeRegion.StartWordField != null) {
                MailMergeRegion.StartWordField.Code.Text = StartCode;
                MailMergeRegion.StartWordField.Update();
            }
        }

        private void FieldCodeSetEnd() {
            if (MailMergeRegion.StartWordField != null) {
                MailMergeRegion.EndWordField.Code.Text = EndCode;
                MailMergeRegion.EndWordField.Update();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e) {

        }
    }
}
