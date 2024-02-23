using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZumeForms.Word.Forms {
    public partial class FieldStructure : Form {
        public FieldStructure() {
            InitializeComponent();
        }

        public void Init() {
            documentTree1.FieldStructureLoad();
        }

        private void FieldStructure_Shown(object sender, EventArgs e) {
            Init();
        }

        private void documentTree1_RegionChanged(object sender, EventArgs e) {

        }

        private void documentTree1_RegionSelected(object sender, TreeViewEventArgs e) {
            
        }

        private void documentTree1_Load(object sender, EventArgs e) {

        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
