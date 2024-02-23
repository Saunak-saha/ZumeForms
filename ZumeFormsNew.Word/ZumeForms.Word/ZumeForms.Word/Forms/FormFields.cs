using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZumeForms.Word.Forms {
    public partial class FormFields : Form {
        public FormFields() {
            InitializeComponent();
        }

        public DialogResult ShowDialog(string formid) {

            DialogResult retval = System.Windows.Forms.DialogResult.OK;
            this.ShowDialog();
            if (Classes.FormFields.FieldDataSet == null) retval = System.Windows.Forms.DialogResult.Cancel;

            return retval;
        }

        private void FormFields_Shown(object sender, EventArgs e) {

            if (ucFormFields.FormID == "" || ucFormFields.FormID == null) {
                ucFormFields.LoadForm();
            }

        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ucUserForm21_Load(object sender, EventArgs e) {

        }
    }
}
