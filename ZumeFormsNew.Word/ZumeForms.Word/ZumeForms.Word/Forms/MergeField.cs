using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZumeForms.Word.Forms{
    public partial class MergeField : Form {


        public MergeField() {
            InitializeComponent();
        }

        public Classes.MailMergeField Field;

        public DialogResult ShowDialog(Microsoft.Office.Interop.Word.Selection selection) {
            return this.DialogResult;
        }

        private void MergeField_Shown(object sender, EventArgs e) {
            // Init();
        }

        public void Init() {
            mailMergeField1.Field = Field;
            mailMergeField1.Init();
        }

        private void MergeField_Load(object sender, EventArgs e) {

        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.Close();
        }

        public bool hasFieldName{
            get{
                return string.IsNullOrEmpty(mailMergeField1.FieldName) ? false : true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void MergeField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "A")
                MessageBox.Show("What the Ctrl+A?");
        }

        private void MergeField_FormClosing(object sender, FormClosingEventArgs e){
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (mailMergeField1.RegionName == "")
                {
                    MessageBox.Show("Field name cannot be blank", "Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }
    }
}
