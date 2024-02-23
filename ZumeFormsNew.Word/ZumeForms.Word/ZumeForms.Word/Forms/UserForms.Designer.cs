namespace ZumeForms.Word.Forms {
    partial class UserForms {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForms));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.SplitContainer();
            this.ucUserForm21 = new Word.UserControls.ucUserForm2();
            this.formTreeView = new System.Windows.Forms.TreeView();
            this.ucFormFields = new Word.UserControls.FormFields();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtDomain = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtUser = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.txtUserPassword = new System.Windows.Forms.ToolStripTextBox();
            this.btnLoadForms = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).BeginInit();
            this.btnLoad.Panel1.SuspendLayout();
            this.btnLoad.Panel2.SuspendLayout();
            this.btnLoad.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 629);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1295, 47);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1167, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 37);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoad.Location = new System.Drawing.Point(0, 39);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            // 
            // btnLoad.Panel1
            // 
            this.btnLoad.Panel1.Controls.Add(this.ucUserForm21);
            // 
            // btnLoad.Panel2
            // 
            this.btnLoad.Panel2.Controls.Add(this.formTreeView);
            this.btnLoad.Panel2.Controls.Add(this.ucFormFields);
            this.btnLoad.Size = new System.Drawing.Size(1295, 590);
            this.btnLoad.SplitterDistance = 570;
            this.btnLoad.SplitterWidth = 5;
            this.btnLoad.TabIndex = 2;
            // 
            // ucUserForm21
            // 
            this.ucUserForm21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucUserForm21.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucUserForm21.Location = new System.Drawing.Point(0, 0);
            this.ucUserForm21.Margin = new System.Windows.Forms.Padding(5, 6, 5, 5);
            this.ucUserForm21.Name = "ucUserForm21";
            this.ucUserForm21.Padding = new System.Windows.Forms.Padding(5);
            this.ucUserForm21.Size = new System.Drawing.Size(570, 590);
            this.ucUserForm21.TabIndex = 0;
            this.ucUserForm21.FormSelected += new System.EventHandler(this.ucUserForm21_FormSelected);
            // 
            // formTreeView
            // 
            this.formTreeView.Location = new System.Drawing.Point(24, 24);
            this.formTreeView.Name = "formTreeView";
            this.formTreeView.Size = new System.Drawing.Size(684, 549);
            this.formTreeView.TabIndex = 1;
            // 
            // ucFormFields
            // 
            this.ucFormFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFormFields.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucFormFields.FormID = null;
            this.ucFormFields.Location = new System.Drawing.Point(0, 0);
            this.ucFormFields.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ucFormFields.Name = "ucFormFields";
            this.ucFormFields.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.ucFormFields.Size = new System.Drawing.Size(720, 590);
            this.ucFormFields.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtDomain,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.txtUser,
            this.toolStripLabel3,
            this.txtUserPassword,
            this.btnLoadForms});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1295, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(69, 34);
            this.toolStripLabel1.Text = "Server:";
            // 
            // txtDomain
            // 
            this.txtDomain.AutoCompleteCustomSource.AddRange(new string[] {
            "create.zumeforms.com",
            "create.zumeforms.com.au",
            "test.zumeforms.com.au"});
            this.txtDomain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtDomain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDomain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDomain.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomain.Margin = new System.Windows.Forms.Padding(1, 4, 1, 0);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(266, 33);
            this.txtDomain.Text = "cytest.syntaq.com";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(101, 34);
            this.toolStripLabel2.Text = "Username:";
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Margin = new System.Windows.Forms.Padding(1, 4, 1, 0);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(266, 33);
            this.txtUser.Text = "cytest";
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            this.txtUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyUp);
            this.txtUser.Click += new System.EventHandler(this.txtUser_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(95, 34);
            this.toolStripLabel3.Text = "Password:";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserPassword.Margin = new System.Windows.Forms.Padding(1, 4, 1, 0);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(266, 33);
            this.txtUserPassword.Text = "123qwe";
            this.txtUserPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUserPassword_KeyUp);
            // 
            // btnLoadForms
            // 
            this.btnLoadForms.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadForms.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadForms.Image")));
            this.btnLoadForms.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLoadForms.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadForms.Margin = new System.Windows.Forms.Padding(5, 6, 0, 2);
            this.btnLoadForms.Name = "btnLoadForms";
            this.btnLoadForms.Size = new System.Drawing.Size(133, 29);
            this.btnLoadForms.Text = "Load Forms";
            this.btnLoadForms.Click += new System.EventHandler(this.btnLoadForms_Click);
            // 
            // UserForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1295, 676);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserForms";
            this.ShowIcon = false;
            this.Text = "Syntaq";
            this.panel1.ResumeLayout(false);
            this.btnLoad.Panel1.ResumeLayout(false);
            this.btnLoad.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).EndInit();
            this.btnLoad.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer btnLoad;
        private Word.UserControls.ucUserForm2 ucUserForm21;
        private Word.UserControls.FormFields ucFormFields;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtDomain;
        private System.Windows.Forms.ToolStripTextBox txtUser;
        private System.Windows.Forms.ToolStripButton btnLoadForms;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox txtUserPassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TreeView formTreeView;
    }
}