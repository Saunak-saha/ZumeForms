namespace ZumeForms.Word.UserControls {
    partial class MailMergeField {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailMergeField));
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.chkStringFormat = new System.Windows.Forms.CheckBox();
            this.chkTextAfter = new System.Windows.Forms.CheckBox();
            this.chkTextBefore = new System.Windows.Forms.CheckBox();
            this.radCaps = new System.Windows.Forms.RadioButton();
            this.radCapsFirst = new System.Windows.Forms.RadioButton();
            this.radCaseLower = new System.Windows.Forms.RadioButton();
            this.radCaseUpper = new System.Windows.Forms.RadioButton();
            this.radNumberText = new System.Windows.Forms.RadioButton();
            this.radDollarText = new System.Windows.Forms.RadioButton();
            this.grpCase = new System.Windows.Forms.GroupBox();
            this.radCaseNone = new System.Windows.Forms.RadioButton();
            this.grpNumeric = new System.Windows.Forms.GroupBox();
            this.radNumericNone = new System.Windows.Forms.RadioButton();
            this.radNumeric = new System.Windows.Forms.RadioButton();
            this.txtNumericFormat = new System.Windows.Forms.TextBox();
            this.radDate = new System.Windows.Forms.RadioButton();
            this.cboDateFormat = new System.Windows.Forms.ComboBox();
            this.txtStringFormat = new System.Windows.Forms.TextBox();
            this.txtTextAfter = new System.Windows.Forms.TextBox();
            this.txtTextBefore = new System.Windows.Forms.TextBox();
            this.pnlField = new System.Windows.Forms.Panel();
            this.btnFieldNext = new System.Windows.Forms.Button();
            this.btnFieldPrevious = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMergeText = new System.Windows.Forms.ComboBox();
            this.chkMergeText = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbxNBSP = new System.Windows.Forms.CheckBox();
            this.grpCase.SuspendLayout();
            this.grpNumeric.SuspendLayout();
            this.pnlField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFieldName
            // 
            this.txtFieldName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFieldName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFieldName.Location = new System.Drawing.Point(39, 18);
            this.txtFieldName.Margin = new System.Windows.Forms.Padding(1);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(84, 20);
            this.txtFieldName.TabIndex = 0;
            this.txtFieldName.TextChanged += new System.EventHandler(this.txtFieldName_TextChanged);
            this.txtFieldName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFieldName_KeyDown);
            this.txtFieldName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFieldName_KeyPress);
            this.txtFieldName.Validated += new System.EventHandler(this.txtFieldName_Validated);
            // 
            // chkStringFormat
            // 
            this.chkStringFormat.Location = new System.Drawing.Point(10, 274);
            this.chkStringFormat.Margin = new System.Windows.Forms.Padding(1);
            this.chkStringFormat.Name = "chkStringFormat";
            this.chkStringFormat.Size = new System.Drawing.Size(77, 18);
            this.chkStringFormat.TabIndex = 8;
            this.chkStringFormat.Text = "String Format";
            this.toolTip1.SetToolTip(this.chkStringFormat, "You can substitute placeholders in your field with the values listed here\r\n");
            this.chkStringFormat.UseVisualStyleBackColor = true;
            this.chkStringFormat.CheckedChanged += new System.EventHandler(this.chkStringFormat_CheckedChanged);
            // 
            // chkTextAfter
            // 
            this.chkTextAfter.Location = new System.Drawing.Point(10, 251);
            this.chkTextAfter.Margin = new System.Windows.Forms.Padding(1);
            this.chkTextAfter.Name = "chkTextAfter";
            this.chkTextAfter.Size = new System.Drawing.Size(72, 20);
            this.chkTextAfter.TabIndex = 6;
            this.chkTextAfter.Text = "Text After";
            this.chkTextAfter.UseVisualStyleBackColor = true;
            this.chkTextAfter.CheckedChanged += new System.EventHandler(this.chkTextAfter_CheckedChanged);
            // 
            // chkTextBefore
            // 
            this.chkTextBefore.Location = new System.Drawing.Point(10, 232);
            this.chkTextBefore.Margin = new System.Windows.Forms.Padding(1);
            this.chkTextBefore.Name = "chkTextBefore";
            this.chkTextBefore.Size = new System.Drawing.Size(82, 15);
            this.chkTextBefore.TabIndex = 4;
            this.chkTextBefore.Text = "Text Before";
            this.chkTextBefore.UseVisualStyleBackColor = true;
            this.chkTextBefore.CheckedChanged += new System.EventHandler(this.chkTextBefore_CheckedChanged);
            // 
            // radCaps
            // 
            this.radCaps.AutoSize = true;
            this.radCaps.Location = new System.Drawing.Point(79, 14);
            this.radCaps.Margin = new System.Windows.Forms.Padding(1);
            this.radCaps.Name = "radCaps";
            this.radCaps.Size = new System.Drawing.Size(72, 17);
            this.radCaps.TabIndex = 2;
            this.radCaps.TabStop = true;
            this.radCaps.Text = "Title Case";
            this.toolTip1.SetToolTip(this.radCaps, "Capitalise first letter of each word");
            this.radCaps.UseVisualStyleBackColor = true;
            this.radCaps.CheckedChanged += new System.EventHandler(this.radCaps_CheckedChanged);
            // 
            // radCapsFirst
            // 
            this.radCapsFirst.AutoSize = true;
            this.radCapsFirst.Location = new System.Drawing.Point(79, 31);
            this.radCapsFirst.Margin = new System.Windows.Forms.Padding(1);
            this.radCapsFirst.Name = "radCapsFirst";
            this.radCapsFirst.Size = new System.Drawing.Size(98, 17);
            this.radCapsFirst.TabIndex = 3;
            this.radCapsFirst.TabStop = true;
            this.radCapsFirst.Text = "Sentence Case";
            this.toolTip1.SetToolTip(this.radCapsFirst, "Capitalise first letter of sentence");
            this.radCapsFirst.UseVisualStyleBackColor = true;
            this.radCapsFirst.CheckedChanged += new System.EventHandler(this.radCapsFirst_CheckedChanged);
            // 
            // radCaseLower
            // 
            this.radCaseLower.AutoSize = true;
            this.radCaseLower.Location = new System.Drawing.Point(3, 31);
            this.radCaseLower.Margin = new System.Windows.Forms.Padding(1);
            this.radCaseLower.Name = "radCaseLower";
            this.radCaseLower.Size = new System.Drawing.Size(81, 17);
            this.radCaseLower.TabIndex = 1;
            this.radCaseLower.TabStop = true;
            this.radCaseLower.Text = "Lower Case";
            this.radCaseLower.UseVisualStyleBackColor = true;
            this.radCaseLower.CheckedChanged += new System.EventHandler(this.radCaseLower_CheckedChanged);
            // 
            // radCaseUpper
            // 
            this.radCaseUpper.AutoSize = true;
            this.radCaseUpper.Location = new System.Drawing.Point(3, 14);
            this.radCaseUpper.Margin = new System.Windows.Forms.Padding(1);
            this.radCaseUpper.Name = "radCaseUpper";
            this.radCaseUpper.Size = new System.Drawing.Size(81, 17);
            this.radCaseUpper.TabIndex = 0;
            this.radCaseUpper.TabStop = true;
            this.radCaseUpper.Text = "Upper Case";
            this.radCaseUpper.UseVisualStyleBackColor = true;
            this.radCaseUpper.CheckedChanged += new System.EventHandler(this.radCaseUpper_CheckedChanged);
            // 
            // radNumberText
            // 
            this.radNumberText.AutoSize = true;
            this.radNumberText.Location = new System.Drawing.Point(3, 15);
            this.radNumberText.Margin = new System.Windows.Forms.Padding(1);
            this.radNumberText.Name = "radNumberText";
            this.radNumberText.Size = new System.Drawing.Size(86, 17);
            this.radNumberText.TabIndex = 0;
            this.radNumberText.TabStop = true;
            this.radNumberText.Text = "Number Text";
            this.radNumberText.UseVisualStyleBackColor = true;
            this.radNumberText.CheckedChanged += new System.EventHandler(this.radNumberText_CheckedChanged);
            // 
            // radDollarText
            // 
            this.radDollarText.AutoSize = true;
            this.radDollarText.Location = new System.Drawing.Point(3, 45);
            this.radDollarText.Margin = new System.Windows.Forms.Padding(1);
            this.radDollarText.Name = "radDollarText";
            this.radDollarText.Size = new System.Drawing.Size(76, 17);
            this.radDollarText.TabIndex = 1;
            this.radDollarText.TabStop = true;
            this.radDollarText.Text = "Dollar Text";
            this.radDollarText.UseVisualStyleBackColor = true;
            this.radDollarText.CheckedChanged += new System.EventHandler(this.radDollarText_CheckedChanged);
            // 
            // grpCase
            // 
            this.grpCase.AutoSize = true;
            this.grpCase.Controls.Add(this.radCaseNone);
            this.grpCase.Controls.Add(this.radCaps);
            this.grpCase.Controls.Add(this.radCapsFirst);
            this.grpCase.Controls.Add(this.radCaseUpper);
            this.grpCase.Controls.Add(this.radCaseLower);
            this.grpCase.Location = new System.Drawing.Point(8, 62);
            this.grpCase.Margin = new System.Windows.Forms.Padding(1);
            this.grpCase.Name = "grpCase";
            this.grpCase.Padding = new System.Windows.Forms.Padding(1);
            this.grpCase.Size = new System.Drawing.Size(179, 78);
            this.grpCase.TabIndex = 2;
            this.grpCase.TabStop = false;
            this.grpCase.Text = "Case";
            // 
            // radCaseNone
            // 
            this.radCaseNone.AutoSize = true;
            this.radCaseNone.Location = new System.Drawing.Point(3, 46);
            this.radCaseNone.Margin = new System.Windows.Forms.Padding(1);
            this.radCaseNone.Name = "radCaseNone";
            this.radCaseNone.Size = new System.Drawing.Size(51, 17);
            this.radCaseNone.TabIndex = 4;
            this.radCaseNone.TabStop = true;
            this.radCaseNone.Text = "None";
            this.radCaseNone.UseVisualStyleBackColor = true;
            this.radCaseNone.CheckedChanged += new System.EventHandler(this.radCaseNone_CheckedChanged);
            // 
            // grpNumeric
            // 
            this.grpNumeric.Controls.Add(this.radNumericNone);
            this.grpNumeric.Controls.Add(this.radNumeric);
            this.grpNumeric.Controls.Add(this.radNumberText);
            this.grpNumeric.Controls.Add(this.txtNumericFormat);
            this.grpNumeric.Controls.Add(this.radDollarText);
            this.grpNumeric.Controls.Add(this.radDate);
            this.grpNumeric.Controls.Add(this.cboDateFormat);
            this.grpNumeric.Location = new System.Drawing.Point(8, 142);
            this.grpNumeric.Margin = new System.Windows.Forms.Padding(1);
            this.grpNumeric.Name = "grpNumeric";
            this.grpNumeric.Padding = new System.Windows.Forms.Padding(1);
            this.grpNumeric.Size = new System.Drawing.Size(179, 84);
            this.grpNumeric.TabIndex = 3;
            this.grpNumeric.TabStop = false;
            this.grpNumeric.Text = "Format";
            // 
            // radNumericNone
            // 
            this.radNumericNone.AutoSize = true;
            this.radNumericNone.Location = new System.Drawing.Point(100, 16);
            this.radNumericNone.Margin = new System.Windows.Forms.Padding(1);
            this.radNumericNone.Name = "radNumericNone";
            this.radNumericNone.Size = new System.Drawing.Size(51, 17);
            this.radNumericNone.TabIndex = 6;
            this.radNumericNone.TabStop = true;
            this.radNumericNone.Text = "None";
            this.radNumericNone.UseVisualStyleBackColor = true;
            this.radNumericNone.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radNumeric
            // 
            this.radNumeric.AutoSize = true;
            this.radNumeric.Location = new System.Drawing.Point(3, 60);
            this.radNumeric.Margin = new System.Windows.Forms.Padding(1);
            this.radNumeric.Name = "radNumeric";
            this.radNumeric.Size = new System.Drawing.Size(64, 17);
            this.radNumeric.TabIndex = 4;
            this.radNumeric.TabStop = true;
            this.radNumeric.Text = "Numeric";
            this.radNumeric.UseVisualStyleBackColor = true;
            this.radNumeric.CheckedChanged += new System.EventHandler(this.chkNumeric_CheckedChanged);
            // 
            // txtNumericFormat
            // 
            this.txtNumericFormat.Enabled = false;
            this.txtNumericFormat.Location = new System.Drawing.Point(78, 57);
            this.txtNumericFormat.Margin = new System.Windows.Forms.Padding(1);
            this.txtNumericFormat.Name = "txtNumericFormat";
            this.txtNumericFormat.Size = new System.Drawing.Size(98, 20);
            this.txtNumericFormat.TabIndex = 5;
            this.txtNumericFormat.Text = "$#,##0.00";
            this.txtNumericFormat.Validated += new System.EventHandler(this.txtNumericFormat_Validated);
            // 
            // radDate
            // 
            this.radDate.AutoSize = true;
            this.radDate.Location = new System.Drawing.Point(3, 30);
            this.radDate.Margin = new System.Windows.Forms.Padding(1);
            this.radDate.Name = "radDate";
            this.radDate.Size = new System.Drawing.Size(71, 17);
            this.radDate.TabIndex = 2;
            this.radDate.TabStop = true;
            this.radDate.Text = "DateTime";
            this.radDate.UseVisualStyleBackColor = true;
            this.radDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // cboDateFormat
            // 
            this.cboDateFormat.Enabled = false;
            this.cboDateFormat.FormattingEnabled = true;
            this.cboDateFormat.Items.AddRange(new object[] {
            "dd-MM-yy",
            "dd-MMM-yyyy",
            "dd-MMMM-yyyy",
            "dd MM yy",
            "dd MMM yyyy",
            "dd MMMM yyyy"});
            this.cboDateFormat.Location = new System.Drawing.Point(78, 35);
            this.cboDateFormat.Margin = new System.Windows.Forms.Padding(1);
            this.cboDateFormat.Name = "cboDateFormat";
            this.cboDateFormat.Size = new System.Drawing.Size(98, 21);
            this.cboDateFormat.TabIndex = 3;
            this.cboDateFormat.Text = "dd/MM/yyyy";
            this.cboDateFormat.SelectedIndexChanged += new System.EventHandler(this.cboDateFormat_SelectedIndexChanged);
            this.cboDateFormat.Validated += new System.EventHandler(this.cboDateFormat_Validated);
            // 
            // txtStringFormat
            // 
            this.txtStringFormat.Enabled = false;
            this.txtStringFormat.Location = new System.Drawing.Point(94, 274);
            this.txtStringFormat.Margin = new System.Windows.Forms.Padding(1);
            this.txtStringFormat.Name = "txtStringFormat";
            this.txtStringFormat.Size = new System.Drawing.Size(94, 20);
            this.txtStringFormat.TabIndex = 9;
            this.txtStringFormat.Validated += new System.EventHandler(this.txtStringFormat_Validated);
            // 
            // txtTextAfter
            // 
            this.txtTextAfter.Enabled = false;
            this.txtTextAfter.Location = new System.Drawing.Point(94, 252);
            this.txtTextAfter.Margin = new System.Windows.Forms.Padding(1);
            this.txtTextAfter.Name = "txtTextAfter";
            this.txtTextAfter.Size = new System.Drawing.Size(94, 20);
            this.txtTextAfter.TabIndex = 7;
            this.txtTextAfter.Validated += new System.EventHandler(this.txtTextAfter_Validated);
            // 
            // txtTextBefore
            // 
            this.txtTextBefore.Enabled = false;
            this.txtTextBefore.Location = new System.Drawing.Point(94, 230);
            this.txtTextBefore.Margin = new System.Windows.Forms.Padding(1);
            this.txtTextBefore.Name = "txtTextBefore";
            this.txtTextBefore.Size = new System.Drawing.Size(94, 20);
            this.txtTextBefore.TabIndex = 5;
            this.txtTextBefore.Validated += new System.EventHandler(this.txtTextBefore_Validated);
            // 
            // pnlField
            // 
            this.pnlField.AutoSize = true;
            this.pnlField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlField.BackColor = System.Drawing.SystemColors.Window;
            this.pnlField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlField.Controls.Add(this.cbxNBSP);
            this.pnlField.Controls.Add(this.txtTextBefore);
            this.pnlField.Controls.Add(this.btnFieldNext);
            this.pnlField.Controls.Add(this.btnFieldPrevious);
            this.pnlField.Controls.Add(this.btnDelete);
            this.pnlField.Controls.Add(this.label7);
            this.pnlField.Controls.Add(this.label9);
            this.pnlField.Controls.Add(this.label6);
            this.pnlField.Controls.Add(this.txtMergeText);
            this.pnlField.Controls.Add(this.chkMergeText);
            this.pnlField.Controls.Add(this.label8);
            this.pnlField.Controls.Add(this.label5);
            this.pnlField.Controls.Add(this.label4);
            this.pnlField.Controls.Add(this.label1);
            this.pnlField.Controls.Add(this.label2);
            this.pnlField.Controls.Add(this.chkTextBefore);
            this.pnlField.Controls.Add(this.grpNumeric);
            this.pnlField.Controls.Add(this.txtFieldName);
            this.pnlField.Controls.Add(this.txtStringFormat);
            this.pnlField.Controls.Add(this.chkStringFormat);
            this.pnlField.Controls.Add(this.txtTextAfter);
            this.pnlField.Controls.Add(this.grpCase);
            this.pnlField.Controls.Add(this.chkTextAfter);
            this.pnlField.Controls.Add(this.label3);
            this.pnlField.Controls.Add(this.pictureBox1);
            this.pnlField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlField.Location = new System.Drawing.Point(1, 2);
            this.pnlField.Margin = new System.Windows.Forms.Padding(1);
            this.pnlField.Name = "pnlField";
            this.pnlField.Size = new System.Drawing.Size(445, 321);
            this.pnlField.TabIndex = 90;
            // 
            // btnFieldNext
            // 
            this.btnFieldNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFieldNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFieldNext.Location = new System.Drawing.Point(322, 18);
            this.btnFieldNext.Margin = new System.Windows.Forms.Padding(1);
            this.btnFieldNext.Name = "btnFieldNext";
            this.btnFieldNext.Size = new System.Drawing.Size(47, 19);
            this.btnFieldNext.TabIndex = 55;
            this.btnFieldNext.Text = "Next >";
            this.btnFieldNext.UseVisualStyleBackColor = true;
            this.btnFieldNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFieldPrevious
            // 
            this.btnFieldPrevious.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFieldPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFieldPrevious.Location = new System.Drawing.Point(273, 18);
            this.btnFieldPrevious.Margin = new System.Windows.Forms.Padding(1);
            this.btnFieldPrevious.Name = "btnFieldPrevious";
            this.btnFieldPrevious.Size = new System.Drawing.Size(47, 19);
            this.btnFieldPrevious.TabIndex = 54;
            this.btnFieldPrevious.Text = "< Prev";
            this.btnFieldPrevious.UseVisualStyleBackColor = true;
            this.btnFieldPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(224, 18);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(47, 19);
            this.btnDelete.TabIndex = 53;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(100)))));
            this.label7.Location = new System.Drawing.Point(205, 226);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Sample:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(100)))));
            this.label9.Location = new System.Drawing.Point(205, 239);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Assembled Field = \"your Spouse\"";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(100)))));
            this.label6.Location = new System.Drawing.Point(205, 252);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "fld = \"{S} spouse\", String Format = \"your\"";
            // 
            // txtMergeText
            // 
            this.txtMergeText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtMergeText.Enabled = false;
            this.txtMergeText.FormattingEnabled = true;
            this.txtMergeText.Items.AddRange(new object[] {
            "HisHerTheir",
            "HeSheThey",
            "HimHerThem",
            "HisHersTheirs",
            "HimHerTheir",
            "yesno",
            "DoDoNot",
            "DoesDoesNot",
            "SalHeShe",
            "SalHisHer"});
            this.txtMergeText.Location = new System.Drawing.Point(278, 62);
            this.txtMergeText.Margin = new System.Windows.Forms.Padding(1);
            this.txtMergeText.Name = "txtMergeText";
            this.txtMergeText.Size = new System.Drawing.Size(91, 99);
            this.txtMergeText.TabIndex = 15;
            this.txtMergeText.Validated += new System.EventHandler(this.txtMergeText_Validated);
            // 
            // chkMergeText
            // 
            this.chkMergeText.Location = new System.Drawing.Point(192, 62);
            this.chkMergeText.Margin = new System.Windows.Forms.Padding(1);
            this.chkMergeText.Name = "chkMergeText";
            this.chkMergeText.Size = new System.Drawing.Size(84, 22);
            this.chkMergeText.TabIndex = 14;
            this.chkMergeText.Text = "MergeText";
            this.chkMergeText.UseVisualStyleBackColor = true;
            this.chkMergeText.CheckedChanged += new System.EventHandler(this.chkMergeText_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(100)))));
            this.label8.Location = new System.Drawing.Point(189, 148);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Sample:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(100)))));
            this.label5.Location = new System.Drawing.Point(191, 174);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "he, she, they";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(100)))));
            this.label4.Location = new System.Drawing.Point(191, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "A Custom MergeText List can be entered as shown:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(189, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "MergeText";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(100)))));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Field Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(100)))));
            this.label3.Location = new System.Drawing.Point(5, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 22);
            this.label3.TabIndex = 36;
            this.label3.Text = "Formatting";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // cbxNBSP
            // 
            this.cbxNBSP.AutoSize = true;
            this.cbxNBSP.Location = new System.Drawing.Point(10, 297);
            this.cbxNBSP.Name = "cbxNBSP";
            this.cbxNBSP.Size = new System.Drawing.Size(170, 17);
            this.cbxNBSP.TabIndex = 56;
            this.cbxNBSP.Text = "Enforce Non-Breaking Spaces";
            this.cbxNBSP.UseVisualStyleBackColor = true;
            this.cbxNBSP.CheckedChanged += new System.EventHandler(this.cbxNBSP_CheckedChanged);
            // 
            // MailMergeField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnlField);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "MailMergeField";
            this.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Size = new System.Drawing.Size(447, 325);
            this.grpCase.ResumeLayout(false);
            this.grpCase.PerformLayout();
            this.grpNumeric.ResumeLayout(false);
            this.grpNumeric.PerformLayout();
            this.pnlField.ResumeLayout(false);
            this.pnlField.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.CheckBox chkStringFormat;
        private System.Windows.Forms.CheckBox chkTextAfter;
        private System.Windows.Forms.CheckBox chkTextBefore;
        private System.Windows.Forms.RadioButton radCaseLower;
        private System.Windows.Forms.RadioButton radCaseUpper;
        private System.Windows.Forms.RadioButton radCapsFirst;
        private System.Windows.Forms.RadioButton radCaps;
        private System.Windows.Forms.GroupBox grpNumeric;
        private System.Windows.Forms.GroupBox grpCase;
        private System.Windows.Forms.RadioButton radDollarText;
        private System.Windows.Forms.RadioButton radNumberText;
        private System.Windows.Forms.TextBox txtTextBefore;
        private System.Windows.Forms.TextBox txtTextAfter;
        private System.Windows.Forms.TextBox txtStringFormat;
        private System.Windows.Forms.Panel pnlField;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNumericFormat;
        private System.Windows.Forms.ComboBox cboDateFormat;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton radCaseNone;
        private System.Windows.Forms.RadioButton radNumericNone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkMergeText;
        private System.Windows.Forms.ComboBox txtMergeText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radNumeric;
        private System.Windows.Forms.RadioButton radDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFieldPrevious;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFieldNext;
        private System.Windows.Forms.CheckBox cbxNBSP;
    }
}
