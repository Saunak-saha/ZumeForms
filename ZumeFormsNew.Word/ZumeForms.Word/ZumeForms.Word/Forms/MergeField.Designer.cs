using ZumeForms.Word.UserControls;

namespace ZumeForms.Word.Forms
{
    partial class MergeField
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergeField));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mailMergeField1 = new Word.UserControls.MailMergeField();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 582);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 39);
            this.panel1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(713, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 31);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(811, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 31);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // mailMergeField1
            // 
            this.mailMergeField1.AutoSize = true;
            this.mailMergeField1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mailMergeField1.BackColor = System.Drawing.SystemColors.Control;
            this.mailMergeField1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mailMergeField1.Field = null;
            this.mailMergeField1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mailMergeField1.Location = new System.Drawing.Point(0, 6);
            this.mailMergeField1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 4);
            this.mailMergeField1.Name = "mailMergeField1";
            this.mailMergeField1.RegionName = "";
            this.mailMergeField1.Padding = new System.Windows.Forms.Padding(7, 0, 7, 9);
            this.mailMergeField1.Size = new System.Drawing.Size(907, 576);
            this.mailMergeField1.TabIndex = 2;
            // 
            // MergeField
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(907, 621);
            this.ControlBox = false;
            this.Controls.Add(this.mailMergeField1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MergeField";
            this.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MergeField";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MergeField_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MergeField_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
 
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private MailMergeField mailMergeField1;
 
    }
}