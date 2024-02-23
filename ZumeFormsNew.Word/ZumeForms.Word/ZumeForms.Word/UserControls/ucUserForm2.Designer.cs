namespace ZumeForms.Word.UserControls {
    partial class ucUserForm2 {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUserForm2));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cboForms = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Form");
            // 
            // cboForms
            // 
            this.cboForms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboForms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboForms.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboForms.FormattingEnabled = true;
            this.cboForms.Location = new System.Drawing.Point(5, 6);
            this.cboForms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboForms.Name = "cboForms";
            this.cboForms.Size = new System.Drawing.Size(557, 819);
            this.cboForms.Sorted = true;
            this.cboForms.TabIndex = 4;
            this.cboForms.SelectedIndexChanged += new System.EventHandler(this.cboForms_SelectedIndexChanged);
            // 
            // ucUserForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboForms);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 4);
            this.Name = "ucUserForm2";
            this.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Size = new System.Drawing.Size(567, 831);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cboForms;
    }
}
