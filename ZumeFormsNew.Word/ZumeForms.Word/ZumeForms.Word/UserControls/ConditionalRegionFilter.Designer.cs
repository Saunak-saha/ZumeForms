using Janus.Data;
using Janus.Windows.GridEX;
using System;

namespace ZumeForms.Word.UserControls {
    partial class ConditionalRegionFilter {
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
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.filterEditor1 = new Janus.Windows.FilterEditor.FilterEditor();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.radFormFields = new System.Windows.Forms.RadioButton();
            this.radDocFields = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridEX1
            // 
            this.gridEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEX1.Location = new System.Drawing.Point(0, 85);
            this.gridEX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.Size = new System.Drawing.Size(661, 358);
            this.gridEX1.TabIndex = 3;
            this.gridEX1.Visible = false;
            // 
            // filterEditor1
            // 
            this.filterEditor1.AllowFilterByFieldValue = true;
            this.filterEditor1.AutoApply = true;
            this.filterEditor1.AutomaticHeightResize = true;
            this.filterEditor1.AvailableConditionOperators = ((Janus.Windows.FilterEditor.AvailableConditionOperators)(((((((Janus.Windows.FilterEditor.AvailableConditionOperators.Equal | Janus.Windows.FilterEditor.AvailableConditionOperators.NotEqual) 
            | Janus.Windows.FilterEditor.AvailableConditionOperators.GreaterThan) 
            | Janus.Windows.FilterEditor.AvailableConditionOperators.LessThan) 
            | Janus.Windows.FilterEditor.AvailableConditionOperators.GreaterThanOrEqualTo) 
            | Janus.Windows.FilterEditor.AvailableConditionOperators.LessThanOrEqualTo) 
            | Janus.Windows.FilterEditor.AvailableConditionOperators.Contains)));
            this.filterEditor1.AvailableLogicalOperators = ((Janus.Windows.FilterEditor.AvailableLogicalOperators)((Janus.Windows.FilterEditor.AvailableLogicalOperators.And | Janus.Windows.FilterEditor.AvailableLogicalOperators.Or)));
            this.filterEditor1.BackColor = System.Drawing.Color.Aqua;
            this.filterEditor1.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterEditor1.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.UseFormatStyle;
            this.filterEditor1.Location = new System.Drawing.Point(0, 40);
            this.filterEditor1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.filterEditor1.MinSize = new System.Drawing.Size(0, 0);
            this.filterEditor1.Name = "filterEditor1";
            this.filterEditor1.ScrollMode = Janus.Windows.UI.Dock.ScrollMode.Both;
            this.filterEditor1.ScrollStep = 15;
            this.filterEditor1.Size = new System.Drawing.Size(661, 45);

            this.filterEditor1.SourceControl = this.gridEX1;
            this.filterEditor1.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            this.filterEditor1.FilterConditionChanged += new System.EventHandler(this.filterEditor1_FilterConditionChanged);
            this.filterEditor1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filterEditor1_KeyUp);
            // 
            // txtFilter
            // 
            this.txtFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilter.Location = new System.Drawing.Point(0, 85);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(661, 358);
            this.txtFilter.TabIndex = 5;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.radFormFields);
            this.pnlHeader.Controls.Add(this.radDocFields);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(661, 40);
            this.pnlHeader.TabIndex = 7;
            // 
            // radFormFields
            // 
            this.radFormFields.AutoSize = true;
            this.radFormFields.Location = new System.Drawing.Point(216, 6);
            this.radFormFields.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radFormFields.Name = "radFormFields";
            this.radFormFields.Size = new System.Drawing.Size(254, 24);
            this.radFormFields.TabIndex = 1;
            this.radFormFields.Text = "Use fields from loaded ZumeForm";
            this.radFormFields.UseVisualStyleBackColor = true;
            this.radFormFields.CheckedChanged += new System.EventHandler(this.radFormFields_CheckedChanged);
            // 
            // radDocFields
            // 
            this.radDocFields.AutoSize = true;
            this.radDocFields.Checked = true;
            this.radDocFields.Location = new System.Drawing.Point(5, 6);
            this.radDocFields.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radDocFields.Name = "radDocFields";
            this.radDocFields.Size = new System.Drawing.Size(200, 24);
            this.radDocFields.TabIndex = 0;
            this.radDocFields.TabStop = true;
            this.radDocFields.Text = "Use fields From document";
            this.radDocFields.UseVisualStyleBackColor = true;
            this.radDocFields.CheckedChanged += new System.EventHandler(this.radDocFields_CheckedChanged);
            // 
            // ConditionalRegionFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.filterEditor1);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ConditionalRegionFilter";
            this.Size = new System.Drawing.Size(661, 443);
           
           this.Load += new System.EventHandler(this.ConditionalRegionFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void GridEX1_RootTableChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        public Janus.Windows.GridEX.GridEX gridEX1;
        public Janus.Windows.FilterEditor.FilterEditor filterEditor1;
        public System.Windows.Forms.TextBox txtFilter;
        public System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.RadioButton radFormFields;
        public System.Windows.Forms.RadioButton radDocFields;
    }
}
