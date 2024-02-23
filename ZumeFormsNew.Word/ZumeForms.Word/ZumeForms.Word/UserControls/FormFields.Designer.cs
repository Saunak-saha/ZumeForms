namespace ZumeForms.Word.UserControls {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            Janus.Windows.GridEX.GridEXLayout grdFields_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference grdFields_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.Image");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFields));
            this.grdFields = new Janus.Windows.GridEX.GridEX();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFormOpen = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdFields)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdFields
            // 
            this.grdFields.AllowColumnDrag = false;
            this.grdFields.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdFields.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.grdFields.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            grdFields_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("grdFields_DesignTimeLayout_Reference_0.Instance")));
            grdFields_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            grdFields_DesignTimeLayout_Reference_0});
            grdFields_DesignTimeLayout.LayoutString = resources.GetString("grdFields_DesignTimeLayout.LayoutString");
            this.grdFields.DesignTimeLayout = grdFields_DesignTimeLayout;
            this.grdFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFields.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdFields.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdFields.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdFields.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.grdFields.GroupByBoxVisible = false;
            this.grdFields.ImageList = this.imgList;
            this.grdFields.Location = new System.Drawing.Point(0, 6);
            this.grdFields.Margin = new System.Windows.Forms.Padding(4, 0, 4, 5);
            this.grdFields.Name = "grdFields";
            this.grdFields.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Black;
            this.grdFields.Size = new System.Drawing.Size(337, 711);
            this.grdFields.TabIndex = 3;
            this.grdFields.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grdFields.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grdFields_RowDoubleClick);
            this.grdFields.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdFields_LoadingRow);
            this.grdFields.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdFields_DragDrop);
            this.grdFields.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstItems_MouseDown);
            this.grdFields.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstItems_MouseMove);
            this.grdFields.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstItems_MouseUp);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(4)))), ((int)(((byte)(255)))));
            this.imgList.Images.SetKeyName(0, "Checkbox");
            this.imgList.Images.SetKeyName(1, "Choices");
            this.imgList.Images.SetKeyName(2, "DateControl");
            this.imgList.Images.SetKeyName(3, "Numeric");
            this.imgList.Images.SetKeyName(4, "RichText");
            this.imgList.Images.SetKeyName(5, "ScriptField");
            this.imgList.Images.SetKeyName(6, "Textbox");
            this.imgList.Images.SetKeyName(7, "YesNo");
            this.imgList.Images.SetKeyName(8, "MaskedInput");
            this.imgList.Images.SetKeyName(9, "Repeat");
            this.imgList.Images.SetKeyName(10, "Form");
            this.imgList.Images.SetKeyName(11, "Section");
            this.imgList.Images.SetKeyName(12, "Combobox");
            this.imgList.Images.SetKeyName(13, "MultiLineText");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFormOpen});
            this.toolStrip1.Location = new System.Drawing.Point(5, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(333, 38);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // btnFormOpen
            // 
            this.btnFormOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnFormOpen.Image")));
            this.btnFormOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFormOpen.Name = "btnFormOpen";
            this.btnFormOpen.Size = new System.Drawing.Size(87, 35);
            this.btnFormOpen.Text = "Open Form";
            this.btnFormOpen.Click += new System.EventHandler(this.btnLoadForm_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdFields);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel1.Size = new System.Drawing.Size(337, 717);
            this.panel1.TabIndex = 6;
            // 
            // FormFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormFields";
            this.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Size = new System.Drawing.Size(347, 729);
            ((System.ComponentModel.ISupportInitialize)(this.grdFields)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grdFields;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFormOpen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imgList;
    }
}
