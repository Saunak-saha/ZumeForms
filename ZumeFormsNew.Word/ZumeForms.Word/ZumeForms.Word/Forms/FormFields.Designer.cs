namespace ZumeForms.Word.Forms {
    partial class FormFields {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ucFormFields = new Word.UserControls.FormFields();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ucUserForm21 = new Word.UserControls.ucUserForm2();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucFormFields
            // 
            this.ucFormFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucFormFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFormFields.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucFormFields.FormID = null;
            this.ucFormFields.Location = new System.Drawing.Point(0, 0);
            this.ucFormFields.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucFormFields.Name = "ucFormFields";
            this.ucFormFields.Padding = new System.Windows.Forms.Padding(5);
            this.ucFormFields.Size = new System.Drawing.Size(532, 465);
            this.ucFormFields.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(6, 471);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(871, 36);
            this.pnlFooter.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Location = new System.Drawing.Point(781, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ucUserForm21
            // 
            this.ucUserForm21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucUserForm21.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ucUserForm21.Location = new System.Drawing.Point(0, 0);
            this.ucUserForm21.Margin = new System.Windows.Forms.Padding(4, 5, 4, 4);
            this.ucUserForm21.Name = "ucUserForm21";
            this.ucUserForm21.Padding = new System.Windows.Forms.Padding(4);
            this.ucUserForm21.Size = new System.Drawing.Size(335, 465);
            this.ucUserForm21.TabIndex = 9;
            this.ucUserForm21.Load += new System.EventHandler(this.ucUserForm21_Load);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(6, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucUserForm21);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucFormFields);
            this.splitContainer1.Size = new System.Drawing.Size(871, 465);
            this.splitContainer1.SplitterDistance = 335;
            this.splitContainer1.TabIndex = 10;
            // 
            // FormFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(883, 513);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlFooter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFields";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowIcon = false;
            this.Text = "FormFields";
            this.Shown += new System.EventHandler(this.FormFields_Shown);
            this.pnlFooter.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.FormFields ucFormFields;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private Word.UserControls.ucUserForm2 ucUserForm21;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}