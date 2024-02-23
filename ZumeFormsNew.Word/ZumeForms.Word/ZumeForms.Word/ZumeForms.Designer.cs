namespace ZumeForms.Word
{
    partial class ZumeForms : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ZumeForms()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZumeForms));
            this.tabZumeForms = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnMergeField = this.Factory.CreateRibbonButton();
            this.btnPrev = this.Factory.CreateRibbonButton();
            this.btnNext = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.btnConditionalRegionEdit = this.Factory.CreateRibbonButton();
            this.btnIFPrev = this.Factory.CreateRibbonButton();
            this.btnIFNext = this.Factory.CreateRibbonButton();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.btnRepeat = this.Factory.CreateRibbonButton();
            this.btnRepeatPrev = this.Factory.CreateRibbonButton();
            this.btnRepeatNext = this.Factory.CreateRibbonButton();
            this.separator3 = this.Factory.CreateRibbonSeparator();
            this.btnListRegion = this.Factory.CreateRibbonButton();
            this.btnListRegionPrev = this.Factory.CreateRibbonButton();
            this.btnListRegionNext = this.Factory.CreateRibbonButton();
            this.btnListRegionAddItem = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.btnDelEmptyPara = this.Factory.CreateRibbonButton();
            this.btnDelEmptyRow = this.Factory.CreateRibbonButton();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.btnConvert = this.Factory.CreateRibbonButton();
            this.btnLoadFormFields = this.Factory.CreateRibbonButton();
            this.separator5 = this.Factory.CreateRibbonSeparator();
            this.btnFieldStructure = this.Factory.CreateRibbonButton();
            this.btnFieldCheck = this.Factory.CreateRibbonButton();
            this.btnStructureValidate = this.Factory.CreateRibbonButton();
            this.separator4 = this.Factory.CreateRibbonSeparator();
            this.btnZSWeb = this.Factory.CreateRibbonButton();
            this.tabZumeForms.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabZumeForms
            // 
            this.tabZumeForms.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabZumeForms.Groups.Add(this.group1);
            this.tabZumeForms.Groups.Add(this.group2);
            this.tabZumeForms.Groups.Add(this.group4);
            this.tabZumeForms.Label = "Syntaq";
            this.tabZumeForms.Name = "tabZumeForms";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnMergeField);
            this.group1.Items.Add(this.btnPrev);
            this.group1.Items.Add(this.btnNext);
            this.group1.Items.Add(this.separator1);
            this.group1.Items.Add(this.btnConditionalRegionEdit);
            this.group1.Items.Add(this.btnIFPrev);
            this.group1.Items.Add(this.btnIFNext);
            this.group1.Items.Add(this.separator2);
            this.group1.Items.Add(this.btnRepeat);
            this.group1.Items.Add(this.btnRepeatPrev);
            this.group1.Items.Add(this.btnRepeatNext);
            this.group1.Items.Add(this.separator3);
            this.group1.Items.Add(this.btnListRegion);
            this.group1.Items.Add(this.btnListRegionPrev);
            this.group1.Items.Add(this.btnListRegionNext);
            this.group1.Items.Add(this.btnListRegionAddItem);
            this.group1.Label = "Fields, Sections and Conditions";
            this.group1.Name = "group1";
            // 
            // btnMergeField
            // 
            this.btnMergeField.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnMergeField.Image = ((System.Drawing.Image)(resources.GetObject("btnMergeField.Image")));
            this.btnMergeField.Label = "Field";
            this.btnMergeField.Name = "btnMergeField";
            this.btnMergeField.ShowImage = true;
            this.btnMergeField.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnMergeField_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.Label = "Previous";
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.ShowImage = true;
            this.btnPrev.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Label = "Next";
            this.btnNext.Name = "btnNext";
            this.btnNext.ShowImage = true;
            this.btnNext.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnNext_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // btnConditionalRegionEdit
            // 
            this.btnConditionalRegionEdit.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnConditionalRegionEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnConditionalRegionEdit.Image")));
            this.btnConditionalRegionEdit.Label = "If Condition";
            this.btnConditionalRegionEdit.Name = "btnConditionalRegionEdit";
            this.btnConditionalRegionEdit.ShowImage = true;
            this.btnConditionalRegionEdit.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConditionalRegionEdit_Click);
            // 
            // btnIFPrev
            // 
            this.btnIFPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnIFPrev.Image")));
            this.btnIFPrev.Label = "Previous";
            this.btnIFPrev.Name = "btnIFPrev";
            this.btnIFPrev.ShowImage = true;
            this.btnIFPrev.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnIFPrev_Click);
            // 
            // btnIFNext
            // 
            this.btnIFNext.Image = ((System.Drawing.Image)(resources.GetObject("btnIFNext.Image")));
            this.btnIFNext.Label = "Next";
            this.btnIFNext.Name = "btnIFNext";
            this.btnIFNext.ShowImage = true;
            this.btnIFNext.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnIFNext_Click);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // btnRepeat
            // 
            this.btnRepeat.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnRepeat.Image = ((System.Drawing.Image)(resources.GetObject("btnRepeat.Image")));
            this.btnRepeat.Label = "Repeat Section";
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.ShowImage = true;
            this.btnRepeat.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnRepeat_Click);
            // 
            // btnRepeatPrev
            // 
            this.btnRepeatPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnRepeatPrev.Image")));
            this.btnRepeatPrev.Label = "Previous";
            this.btnRepeatPrev.Name = "btnRepeatPrev";
            this.btnRepeatPrev.ShowImage = true;
            this.btnRepeatPrev.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnRepeatPrev_Click);
            // 
            // btnRepeatNext
            // 
            this.btnRepeatNext.Image = ((System.Drawing.Image)(resources.GetObject("btnRepeatNext.Image")));
            this.btnRepeatNext.Label = "Next";
            this.btnRepeatNext.Name = "btnRepeatNext";
            this.btnRepeatNext.ShowImage = true;
            this.btnRepeatNext.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnRepeatNext_Click);
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            // 
            // btnListRegion
            // 
            this.btnListRegion.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnListRegion.Image = ((System.Drawing.Image)(resources.GetObject("btnListRegion.Image")));
            this.btnListRegion.Label = "List Section";
            this.btnListRegion.Name = "btnListRegion";
            this.btnListRegion.ShowImage = true;
            this.btnListRegion.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnListRegion_Click);
            // 
            // btnListRegionPrev
            // 
            this.btnListRegionPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnListRegionPrev.Image")));
            this.btnListRegionPrev.Label = "Previous";
            this.btnListRegionPrev.Name = "btnListRegionPrev";
            this.btnListRegionPrev.ShowImage = true;
            this.btnListRegionPrev.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnListPrev_Click);
            // 
            // btnListRegionNext
            // 
            this.btnListRegionNext.Image = ((System.Drawing.Image)(resources.GetObject("btnListRegionNext.Image")));
            this.btnListRegionNext.Label = "Next";
            this.btnListRegionNext.Name = "btnListRegionNext";
            this.btnListRegionNext.ShowImage = true;
            this.btnListRegionNext.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnListNext_Click);
            // 
            // btnListRegionAddItem
            // 
            this.btnListRegionAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnListRegionAddItem.Image")));
            this.btnListRegionAddItem.Label = "Add Item";
            this.btnListRegionAddItem.Name = "btnListRegionAddItem";
            this.btnListRegionAddItem.ShowImage = true;
            this.btnListRegionAddItem.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnListRegionAddItem_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.btnDelEmptyPara);
            this.group2.Items.Add(this.btnDelEmptyRow);
            this.group2.Label = "Insert";
            this.group2.Name = "group2";
            // 
            // btnDelEmptyPara
            // 
            this.btnDelEmptyPara.Image = ((System.Drawing.Image)(resources.GetObject("btnDelEmptyPara.Image")));
            this.btnDelEmptyPara.Label = "WF:DelEmptyPara";
            this.btnDelEmptyPara.Name = "btnDelEmptyPara";
            this.btnDelEmptyPara.ShowImage = true;
            this.btnDelEmptyPara.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDelEmptyPara_Click);
            // 
            // btnDelEmptyRow
            // 
            this.btnDelEmptyRow.Image = ((System.Drawing.Image)(resources.GetObject("btnDelEmptyRow.Image")));
            this.btnDelEmptyRow.Label = "WF:DelRow";
            this.btnDelEmptyRow.Name = "btnDelEmptyRow";
            this.btnDelEmptyRow.ShowImage = true;
            this.btnDelEmptyRow.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDelEmptyRow_Click);
            // 
            // group4
            // 
            this.group4.Items.Add(this.btnConvert);
            this.group4.Items.Add(this.btnLoadFormFields);
            this.group4.Items.Add(this.separator5);
            this.group4.Items.Add(this.btnFieldStructure);
            this.group4.Items.Add(this.btnFieldCheck);
            this.group4.Items.Add(this.btnStructureValidate);
            this.group4.Items.Add(this.separator4);
            this.group4.Items.Add(this.btnZSWeb);
            this.group4.Label = "Your Document";
            this.group4.Name = "group4";
            // 
            // btnConvert
            // 
            this.btnConvert.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnConvert.Label = "Convert [] Fields";
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.ShowImage = true;
            this.btnConvert.Visible = false;
            this.btnConvert.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConvert_Click);
            // 
            // btnLoadFormFields
            // 
            this.btnLoadFormFields.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnLoadFormFields.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadFormFields.Image")));
            this.btnLoadFormFields.Label = "Load Fields from a Form";
            this.btnLoadFormFields.Name = "btnLoadFormFields";
            this.btnLoadFormFields.ShowImage = true;
            this.btnLoadFormFields.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnLoadFormFields_Click);
            // 
            // separator5
            // 
            this.separator5.Name = "separator5";
            // 
            // btnFieldStructure
            // 
            this.btnFieldStructure.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnFieldStructure.Image = ((System.Drawing.Image)(resources.GetObject("btnFieldStructure.Image")));
            this.btnFieldStructure.Label = "View Field Structure";
            this.btnFieldStructure.Name = "btnFieldStructure";
            this.btnFieldStructure.ShowImage = true;
            this.btnFieldStructure.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnFieldStructure_Click);
            // 
            // btnFieldCheck
            // 
            this.btnFieldCheck.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnFieldCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnFieldCheck.Image")));
            this.btnFieldCheck.Label = "Check Field Names";
            this.btnFieldCheck.Name = "btnFieldCheck";
            this.btnFieldCheck.ShowImage = true;
            this.btnFieldCheck.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnFieldCheck_Click);
            // 
            // btnStructureValidate
            // 
            this.btnStructureValidate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnStructureValidate.Image = ((System.Drawing.Image)(resources.GetObject("btnStructureValidate.Image")));
            this.btnStructureValidate.Label = "Check Structure";
            this.btnStructureValidate.Name = "btnStructureValidate";
            this.btnStructureValidate.ShowImage = true;
            this.btnStructureValidate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnStructureValidate_Click);
            // 
            // separator4
            // 
            this.separator4.Name = "separator4";
            // 
            // btnZSWeb
            // 
            this.btnZSWeb.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnZSWeb.Image = ((System.Drawing.Image)(resources.GetObject("btnZSWeb.Image")));
            this.btnZSWeb.Label = "Support";
            this.btnZSWeb.Name = "btnZSWeb";
            this.btnZSWeb.ShowImage = true;
            this.btnZSWeb.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnZSWeb_Click);
            // 
            // ZumeForms
            // 
            this.Name = "ZumeForms";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tabZumeForms);
            this.tabZumeForms.ResumeLayout(false);
            this.tabZumeForms.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabZumeForms;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnMergeField;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPrev;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnNext;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConditionalRegionEdit;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnIFPrev;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnIFNext;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRepeat;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRepeatPrev;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRepeatNext;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnListRegion;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnListRegionPrev;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnListRegionNext;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnListRegionAddItem;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDelEmptyPara;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDelEmptyRow;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnStructureValidate;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFieldStructure;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnLoadFormFields;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnZSWeb;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFieldCheck;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator5;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConvert;
    }

    partial class ThisRibbonCollection
    {
        internal ZumeForms ZumeForms
        {
            get { return this.GetRibbon<ZumeForms>(); }
        }
    }
}
