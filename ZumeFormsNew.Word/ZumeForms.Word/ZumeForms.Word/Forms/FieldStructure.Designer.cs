namespace ZumeForms.Word.Forms {
    partial class FieldStructure {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldStructure));
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.documentTree1 = new Word.UserControls.FieldStructure();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(8, 565);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(691, 48);
            this.pnlFooter.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Location = new System.Drawing.Point(572, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 39);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // documentTree1
            // 
            this.documentTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentTree1.FileName = "";
            this.documentTree1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentTree1.Location = new System.Drawing.Point(8, 0);
            this.documentTree1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.documentTree1.Name = "documentTree1";
            this.documentTree1.Size = new System.Drawing.Size(691, 565);
            this.documentTree1.TabIndex = 8;
            this.documentTree1.RegionSelected += new System.Windows.Forms.TreeViewEventHandler(this.documentTree1_RegionSelected);
            this.documentTree1.Load += new System.EventHandler(this.documentTree1_Load);
            this.documentTree1.RegionChanged += new System.EventHandler(this.documentTree1_RegionChanged);
            // 
            // FieldStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(707, 620);
            this.Controls.Add(this.documentTree1);
            this.Controls.Add(this.pnlFooter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FieldStructure";
            this.Padding = new System.Windows.Forms.Padding(8, 0, 8, 7);
            this.ShowIcon = false;
            this.Text = "Field Structure";
            this.Shown += new System.EventHandler(this.FieldStructure_Shown);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private global::ZumeForms.Word.UserControls.FieldStructure documentTree1;
    }
}