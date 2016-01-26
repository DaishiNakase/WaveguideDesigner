namespace Hslab.WaveguideDesigner.Forms
	{
	partial class MaterialSystemEditorDialog
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
			if( disposing && ( components != null ) )
				{
				components.Dispose();
				}
			base.Dispose( disposing );
			}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
			{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialSystemEditorDialog));
			this.buttonOK = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.labelMinZ = new System.Windows.Forms.Label();
			this.labelMaxZ = new System.Windows.Forms.Label();
			this.panelStructure = new System.Windows.Forms.Panel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageStructure = new System.Windows.Forms.TabPage();
			this.tabPageMaterial = new System.Windows.Forms.TabPage();
			this.panelMaterialSetting = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.richTextBoxMeepCode = new System.Windows.Forms.RichTextBox();
			this.panelDielectric = new System.Windows.Forms.Panel();
			this.numericUpDownN = new System.Windows.Forms.NumericUpDown();
			this.labelSigma = new System.Windows.Forms.Label();
			this.labelN = new System.Windows.Forms.Label();
			this.numericUpDownSigma = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMu = new System.Windows.Forms.NumericUpDown();
			this.labelMu = new System.Windows.Forms.Label();
			this.groupBoxMaterialType = new System.Windows.Forms.GroupBox();
			this.radioButtonDirectCoding = new System.Windows.Forms.RadioButton();
			this.radioButtonMagneticConductor = new System.Windows.Forms.RadioButton();
			this.radioButtonNothing = new System.Windows.Forms.RadioButton();
			this.radioButtonAir = new System.Windows.Forms.RadioButton();
			this.radioButtonMetal = new System.Windows.Forms.RadioButton();
			this.radioButtonDielectric = new System.Windows.Forms.RadioButton();
			this.textBoxMaterialName = new System.Windows.Forms.TextBox();
			this.labelMaterialName = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.listBoxMedium = new System.Windows.Forms.ListBox();
			this.toolStripSources = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonMedAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonMedRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonMedRaise = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonMedLower = new System.Windows.Forms.ToolStripButton();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageStructure.SuspendLayout();
			this.tabPageMaterial.SuspendLayout();
			this.panelMaterialSetting.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panelDielectric.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSigma)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMu)).BeginInit();
			this.groupBoxMaterialType.SuspendLayout();
			this.panel3.SuspendLayout();
			this.toolStripSources.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(599, 8);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(87, 29);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.buttonApply);
			this.panel2.Controls.Add(this.buttonCancel);
			this.panel2.Controls.Add(this.buttonOK);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 620);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(884, 41);
			this.panel2.TabIndex = 3;
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Location = new System.Drawing.Point(692, 8);
			this.buttonApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(87, 29);
			this.buttonApply.TabIndex = 2;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(785, 8);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(87, 29);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.labelMinZ);
			this.panel1.Controls.Add(this.labelMaxZ);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(50, 586);
			this.panel1.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "Z=";
			// 
			// labelMinZ
			// 
			this.labelMinZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelMinZ.Location = new System.Drawing.Point(0, 238);
			this.labelMinZ.Name = "labelMinZ";
			this.labelMinZ.Size = new System.Drawing.Size(50, 16);
			this.labelMinZ.TabIndex = 1;
			this.labelMinZ.Text = "-1.00";
			this.labelMinZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelMaxZ
			// 
			this.labelMaxZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelMaxZ.Location = new System.Drawing.Point(0, 23);
			this.labelMaxZ.Name = "labelMaxZ";
			this.labelMaxZ.Size = new System.Drawing.Size(50, 16);
			this.labelMaxZ.TabIndex = 0;
			this.labelMaxZ.Text = "1.00";
			this.labelMaxZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panelStructure
			// 
			this.panelStructure.AutoScroll = true;
			this.panelStructure.BackColor = System.Drawing.Color.Transparent;
			this.panelStructure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelStructure.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelStructure.Location = new System.Drawing.Point(53, 3);
			this.panelStructure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panelStructure.Name = "panelStructure";
			this.panelStructure.Size = new System.Drawing.Size(820, 586);
			this.panelStructure.TabIndex = 5;
			this.panelStructure.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel_Scroll);
			this.panelStructure.Layout += new System.Windows.Forms.LayoutEventHandler(this.panel_Layout);
			this.panelStructure.Resize += new System.EventHandler(this.panel_Resize);
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageStructure);
			this.tabControl.Controls.Add(this.tabPageMaterial);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(884, 620);
			this.tabControl.TabIndex = 6;
			// 
			// tabPageStructure
			// 
			this.tabPageStructure.BackColor = System.Drawing.SystemColors.Control;
			this.tabPageStructure.Controls.Add(this.panelStructure);
			this.tabPageStructure.Controls.Add(this.panel1);
			this.tabPageStructure.Location = new System.Drawing.Point(4, 24);
			this.tabPageStructure.Name = "tabPageStructure";
			this.tabPageStructure.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStructure.Size = new System.Drawing.Size(876, 592);
			this.tabPageStructure.TabIndex = 0;
			this.tabPageStructure.Text = "structure";
			// 
			// tabPageMaterial
			// 
			this.tabPageMaterial.BackColor = System.Drawing.SystemColors.Control;
			this.tabPageMaterial.Controls.Add(this.panelMaterialSetting);
			this.tabPageMaterial.Controls.Add(this.panel3);
			this.tabPageMaterial.Location = new System.Drawing.Point(4, 24);
			this.tabPageMaterial.Name = "tabPageMaterial";
			this.tabPageMaterial.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMaterial.Size = new System.Drawing.Size(876, 592);
			this.tabPageMaterial.TabIndex = 1;
			this.tabPageMaterial.Text = "material";
			// 
			// panelMaterialSetting
			// 
			this.panelMaterialSetting.Controls.Add(this.panel5);
			this.panelMaterialSetting.Controls.Add(this.groupBoxMaterialType);
			this.panelMaterialSetting.Controls.Add(this.textBoxMaterialName);
			this.panelMaterialSetting.Controls.Add(this.labelMaterialName);
			this.panelMaterialSetting.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMaterialSetting.Location = new System.Drawing.Point(203, 3);
			this.panelMaterialSetting.Name = "panelMaterialSetting";
			this.panelMaterialSetting.Size = new System.Drawing.Size(670, 586);
			this.panelMaterialSetting.TabIndex = 1;
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel5.Controls.Add(this.richTextBoxMeepCode);
			this.panel5.Controls.Add(this.panelDielectric);
			this.panel5.Location = new System.Drawing.Point(6, 112);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(659, 471);
			this.panel5.TabIndex = 7;
			// 
			// richTextBoxMeepCode
			// 
			this.richTextBoxMeepCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBoxMeepCode.Enabled = false;
			this.richTextBoxMeepCode.Location = new System.Drawing.Point(0, 0);
			this.richTextBoxMeepCode.Name = "richTextBoxMeepCode";
			this.richTextBoxMeepCode.Size = new System.Drawing.Size(659, 471);
			this.richTextBoxMeepCode.TabIndex = 7;
			this.richTextBoxMeepCode.Text = "";
			this.richTextBoxMeepCode.Visible = false;
			this.richTextBoxMeepCode.TextChanged += new System.EventHandler(this.richTextBoxMeepCode_TextChanged);
			// 
			// panelDielectric
			// 
			this.panelDielectric.Controls.Add(this.numericUpDownN);
			this.panelDielectric.Controls.Add(this.labelSigma);
			this.panelDielectric.Controls.Add(this.labelN);
			this.panelDielectric.Controls.Add(this.numericUpDownSigma);
			this.panelDielectric.Controls.Add(this.numericUpDownMu);
			this.panelDielectric.Controls.Add(this.labelMu);
			this.panelDielectric.Location = new System.Drawing.Point(0, 0);
			this.panelDielectric.Name = "panelDielectric";
			this.panelDielectric.Size = new System.Drawing.Size(280, 84);
			this.panelDielectric.TabIndex = 6;
			// 
			// numericUpDownN
			// 
			this.numericUpDownN.DecimalPlaces = 6;
			this.numericUpDownN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownN.Location = new System.Drawing.Point(160, 3);
			this.numericUpDownN.Name = "numericUpDownN";
			this.numericUpDownN.Size = new System.Drawing.Size(120, 23);
			this.numericUpDownN.TabIndex = 0;
			this.numericUpDownN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownN.ValueChanged += new System.EventHandler(this.numericUpDownN_ValueChanged);
			// 
			// labelSigma
			// 
			this.labelSigma.AutoSize = true;
			this.labelSigma.Location = new System.Drawing.Point(3, 63);
			this.labelSigma.Name = "labelSigma";
			this.labelSigma.Size = new System.Drawing.Size(133, 15);
			this.labelSigma.TabIndex = 5;
			this.labelSigma.Text = "electrical conductivity";
			// 
			// labelN
			// 
			this.labelN.AutoSize = true;
			this.labelN.Location = new System.Drawing.Point(3, 5);
			this.labelN.Name = "labelN";
			this.labelN.Size = new System.Drawing.Size(98, 15);
			this.labelN.TabIndex = 1;
			this.labelN.Text = "refractive index";
			// 
			// numericUpDownSigma
			// 
			this.numericUpDownSigma.DecimalPlaces = 6;
			this.numericUpDownSigma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownSigma.Location = new System.Drawing.Point(160, 61);
			this.numericUpDownSigma.Name = "numericUpDownSigma";
			this.numericUpDownSigma.Size = new System.Drawing.Size(120, 23);
			this.numericUpDownSigma.TabIndex = 4;
			this.numericUpDownSigma.ValueChanged += new System.EventHandler(this.numericUpDownSigma_ValueChanged);
			// 
			// numericUpDownMu
			// 
			this.numericUpDownMu.DecimalPlaces = 6;
			this.numericUpDownMu.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownMu.Location = new System.Drawing.Point(160, 32);
			this.numericUpDownMu.Name = "numericUpDownMu";
			this.numericUpDownMu.Size = new System.Drawing.Size(120, 23);
			this.numericUpDownMu.TabIndex = 2;
			this.numericUpDownMu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMu.ValueChanged += new System.EventHandler(this.numericUpDownMu_ValueChanged);
			// 
			// labelMu
			// 
			this.labelMu.AutoSize = true;
			this.labelMu.Location = new System.Drawing.Point(3, 34);
			this.labelMu.Name = "labelMu";
			this.labelMu.Size = new System.Drawing.Size(138, 15);
			this.labelMu.TabIndex = 3;
			this.labelMu.Text = "magnetic permeability";
			// 
			// groupBoxMaterialType
			// 
			this.groupBoxMaterialType.Controls.Add(this.radioButtonDirectCoding);
			this.groupBoxMaterialType.Controls.Add(this.radioButtonMagneticConductor);
			this.groupBoxMaterialType.Controls.Add(this.radioButtonNothing);
			this.groupBoxMaterialType.Controls.Add(this.radioButtonAir);
			this.groupBoxMaterialType.Controls.Add(this.radioButtonMetal);
			this.groupBoxMaterialType.Controls.Add(this.radioButtonDielectric);
			this.groupBoxMaterialType.Location = new System.Drawing.Point(9, 31);
			this.groupBoxMaterialType.Name = "groupBoxMaterialType";
			this.groupBoxMaterialType.Size = new System.Drawing.Size(658, 75);
			this.groupBoxMaterialType.TabIndex = 6;
			this.groupBoxMaterialType.TabStop = false;
			this.groupBoxMaterialType.Text = "material type";
			// 
			// radioButtonDirectCoding
			// 
			this.radioButtonDirectCoding.Location = new System.Drawing.Point(418, 47);
			this.radioButtonDirectCoding.Name = "radioButtonDirectCoding";
			this.radioButtonDirectCoding.Size = new System.Drawing.Size(200, 19);
			this.radioButtonDirectCoding.TabIndex = 5;
			this.radioButtonDirectCoding.Text = "direct coding";
			this.radioButtonDirectCoding.UseVisualStyleBackColor = true;
			this.radioButtonDirectCoding.CheckedChanged += new System.EventHandler(this.radioButtonMaterialType_CheckChanged);
			// 
			// radioButtonMagneticConductor
			// 
			this.radioButtonMagneticConductor.Location = new System.Drawing.Point(6, 47);
			this.radioButtonMagneticConductor.Name = "radioButtonMagneticConductor";
			this.radioButtonMagneticConductor.Size = new System.Drawing.Size(200, 19);
			this.radioButtonMagneticConductor.TabIndex = 4;
			this.radioButtonMagneticConductor.Text = "magnetic conductor";
			this.radioButtonMagneticConductor.UseVisualStyleBackColor = true;
			this.radioButtonMagneticConductor.CheckedChanged += new System.EventHandler(this.radioButtonMaterialType_CheckChanged);
			// 
			// radioButtonNothing
			// 
			this.radioButtonNothing.Location = new System.Drawing.Point(212, 47);
			this.radioButtonNothing.Name = "radioButtonNothing";
			this.radioButtonNothing.Size = new System.Drawing.Size(200, 19);
			this.radioButtonNothing.TabIndex = 3;
			this.radioButtonNothing.Text = "nothing";
			this.radioButtonNothing.UseVisualStyleBackColor = true;
			this.radioButtonNothing.CheckedChanged += new System.EventHandler(this.radioButtonMaterialType_CheckChanged);
			// 
			// radioButtonAir
			// 
			this.radioButtonAir.Location = new System.Drawing.Point(418, 22);
			this.radioButtonAir.Name = "radioButtonAir";
			this.radioButtonAir.Size = new System.Drawing.Size(200, 19);
			this.radioButtonAir.TabIndex = 2;
			this.radioButtonAir.Text = "air";
			this.radioButtonAir.UseVisualStyleBackColor = true;
			this.radioButtonAir.CheckedChanged += new System.EventHandler(this.radioButtonMaterialType_CheckChanged);
			// 
			// radioButtonMetal
			// 
			this.radioButtonMetal.Location = new System.Drawing.Point(212, 22);
			this.radioButtonMetal.Name = "radioButtonMetal";
			this.radioButtonMetal.Size = new System.Drawing.Size(200, 19);
			this.radioButtonMetal.TabIndex = 1;
			this.radioButtonMetal.Text = "metal";
			this.radioButtonMetal.UseVisualStyleBackColor = true;
			this.radioButtonMetal.CheckedChanged += new System.EventHandler(this.radioButtonMaterialType_CheckChanged);
			// 
			// radioButtonDielectric
			// 
			this.radioButtonDielectric.Checked = true;
			this.radioButtonDielectric.Location = new System.Drawing.Point(6, 22);
			this.radioButtonDielectric.Name = "radioButtonDielectric";
			this.radioButtonDielectric.Size = new System.Drawing.Size(200, 19);
			this.radioButtonDielectric.TabIndex = 0;
			this.radioButtonDielectric.TabStop = true;
			this.radioButtonDielectric.Text = "dielectric";
			this.radioButtonDielectric.UseVisualStyleBackColor = true;
			this.radioButtonDielectric.CheckedChanged += new System.EventHandler(this.radioButtonMaterialType_CheckChanged);
			// 
			// textBoxMaterialName
			// 
			this.textBoxMaterialName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxMaterialName.Location = new System.Drawing.Point(105, 2);
			this.textBoxMaterialName.Name = "textBoxMaterialName";
			this.textBoxMaterialName.Size = new System.Drawing.Size(562, 23);
			this.textBoxMaterialName.TabIndex = 5;
			this.textBoxMaterialName.TextChanged += new System.EventHandler(this.textBoxMaterialName_TextChanged);
			this.textBoxMaterialName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxMaterialName_Validating);
			// 
			// labelMaterialName
			// 
			this.labelMaterialName.AutoSize = true;
			this.labelMaterialName.Location = new System.Drawing.Point(6, 6);
			this.labelMaterialName.Name = "labelMaterialName";
			this.labelMaterialName.Size = new System.Drawing.Size(93, 15);
			this.labelMaterialName.TabIndex = 4;
			this.labelMaterialName.Text = "material name";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.listBoxMedium);
			this.panel3.Controls.Add(this.toolStripSources);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(200, 586);
			this.panel3.TabIndex = 0;
			// 
			// listBoxMedium
			// 
			this.listBoxMedium.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxMedium.FormattingEnabled = true;
			this.listBoxMedium.ItemHeight = 15;
			this.listBoxMedium.Location = new System.Drawing.Point(0, 25);
			this.listBoxMedium.Name = "listBoxMedium";
			this.listBoxMedium.Size = new System.Drawing.Size(200, 561);
			this.listBoxMedium.TabIndex = 2;
			this.listBoxMedium.SelectedIndexChanged += new System.EventHandler(this.listBoxMaterial_SelectedIndexChanged);
			// 
			// toolStripSources
			// 
			this.toolStripSources.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMedAdd,
            this.toolStripButtonMedRemove,
            this.toolStripButtonMedRaise,
            this.toolStripButtonMedLower});
			this.toolStripSources.Location = new System.Drawing.Point(0, 0);
			this.toolStripSources.Name = "toolStripSources";
			this.toolStripSources.Size = new System.Drawing.Size(200, 25);
			this.toolStripSources.TabIndex = 1;
			this.toolStripSources.Text = "toolStrip1";
			// 
			// toolStripButtonMedAdd
			// 
			this.toolStripButtonMedAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonMedAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMedAdd.Image")));
			this.toolStripButtonMedAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonMedAdd.Name = "toolStripButtonMedAdd";
			this.toolStripButtonMedAdd.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonMedAdd.Text = "+";
			this.toolStripButtonMedAdd.Click += new System.EventHandler(this.toolStripButtonMedAdd_Click);
			// 
			// toolStripButtonMedRemove
			// 
			this.toolStripButtonMedRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonMedRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMedRemove.Image")));
			this.toolStripButtonMedRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonMedRemove.Name = "toolStripButtonMedRemove";
			this.toolStripButtonMedRemove.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonMedRemove.Text = "-";
			this.toolStripButtonMedRemove.Click += new System.EventHandler(this.toolStripButtonMedRemove_Click);
			// 
			// toolStripButtonMedRaise
			// 
			this.toolStripButtonMedRaise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonMedRaise.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMedRaise.Image")));
			this.toolStripButtonMedRaise.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonMedRaise.Name = "toolStripButtonMedRaise";
			this.toolStripButtonMedRaise.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonMedRaise.Text = "🔺";
			this.toolStripButtonMedRaise.Click += new System.EventHandler(this.toolStripButtonMedRaise_Click);
			// 
			// toolStripButtonMedLower
			// 
			this.toolStripButtonMedLower.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonMedLower.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMedLower.Image")));
			this.toolStripButtonMedLower.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonMedLower.Name = "toolStripButtonMedLower";
			this.toolStripButtonMedLower.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonMedLower.Text = "🔻";
			this.toolStripButtonMedLower.Click += new System.EventHandler(this.toolStripButtonMedLower_Click);
			// 
			// MaterialSystemEditorDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 661);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.panel2);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MaterialSystemEditorDialog";
			this.Text = "MaterialEditorDialog";
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageStructure.ResumeLayout(false);
			this.tabPageMaterial.ResumeLayout(false);
			this.panelMaterialSetting.ResumeLayout(false);
			this.panelMaterialSetting.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panelDielectric.ResumeLayout(false);
			this.panelDielectric.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSigma)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMu)).EndInit();
			this.groupBoxMaterialType.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.toolStripSources.ResumeLayout(false);
			this.toolStripSources.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panelStructure;
		private System.Windows.Forms.Label labelMinZ;
		private System.Windows.Forms.Label labelMaxZ;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageStructure;
		private System.Windows.Forms.TabPage tabPageMaterial;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ListBox listBoxMedium;
		private System.Windows.Forms.ToolStrip toolStripSources;
		private System.Windows.Forms.ToolStripButton toolStripButtonMedAdd;
		private System.Windows.Forms.ToolStripButton toolStripButtonMedRemove;
		private System.Windows.Forms.ToolStripButton toolStripButtonMedRaise;
		private System.Windows.Forms.ToolStripButton toolStripButtonMedLower;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Panel panelMaterialSetting;
		private System.Windows.Forms.TextBox textBoxMaterialName;
		private System.Windows.Forms.Label labelMaterialName;
		private System.Windows.Forms.GroupBox groupBoxMaterialType;
		private System.Windows.Forms.RadioButton radioButtonMetal;
		private System.Windows.Forms.RadioButton radioButtonDielectric;
		private System.Windows.Forms.RadioButton radioButtonNothing;
		private System.Windows.Forms.RadioButton radioButtonAir;
		private System.Windows.Forms.RadioButton radioButtonDirectCoding;
		private System.Windows.Forms.RadioButton radioButtonMagneticConductor;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label labelSigma;
		private System.Windows.Forms.NumericUpDown numericUpDownSigma;
		private System.Windows.Forms.Label labelMu;
		private System.Windows.Forms.NumericUpDown numericUpDownMu;
		private System.Windows.Forms.Label labelN;
		private System.Windows.Forms.NumericUpDown numericUpDownN;
		private System.Windows.Forms.Panel panelDielectric;
		private System.Windows.Forms.RichTextBox richTextBoxMeepCode;
		}
	}