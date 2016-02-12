namespace Hslab.WaveguideDesigner.Forms
	{
	partial class ManifestSettingDialog
		{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
			{
			if( disposing && ( components != null ) )
				{
				components.Dispose();
				}
			base.Dispose( disposing );
			}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
			{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManifestSettingDialog));
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.separator01 = new System.Windows.Forms.Panel();
			this.buttonApply = new System.Windows.Forms.Button();
			this.groupBoxSimulationRegion = new System.Windows.Forms.GroupBox();
			this.labelPml = new System.Windows.Forms.Label();
			this.radioButtonDim3D = new System.Windows.Forms.RadioButton();
			this.radioButtonDim2D = new System.Windows.Forms.RadioButton();
			this.numericUpDownPml = new System.Windows.Forms.NumericUpDown();
			this.separator02 = new System.Windows.Forms.Panel();
			this.labelMinX = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.numericUpDownMinX = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMaxX = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMinY = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMaxZ = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMaxY = new System.Windows.Forms.NumericUpDown();
			this.labelMaxZ = new System.Windows.Forms.Label();
			this.labelMinZ = new System.Windows.Forms.Label();
			this.labelMaxY = new System.Windows.Forms.Label();
			this.labelMinY = new System.Windows.Forms.Label();
			this.numericUpDownMinZ = new System.Windows.Forms.NumericUpDown();
			this.labelMaxX = new System.Windows.Forms.Label();
			this.groupBoxGeneralSettings = new System.Windows.Forms.GroupBox();
			this.labelBGMaterial = new System.Windows.Forms.Label();
			this.labelBackgroundMaterial = new System.Windows.Forms.Label();
			this.buttonBGMaterial = new System.Windows.Forms.Button();
			this.labelSimulationTime = new System.Windows.Forms.Label();
			this.numericUpDownTime = new System.Windows.Forms.NumericUpDown();
			this.labelResolution = new System.Windows.Forms.Label();
			this.numericUpDownResolution = new System.Windows.Forms.NumericUpDown();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageSources = new System.Windows.Forms.TabPage();
			this.listBoxSrc = new System.Windows.Forms.ListBox();
			this.toolStripSources = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonSrcAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonSrcRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonSrcRaise = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonSrcLower = new System.Windows.Forms.ToolStripButton();
			this.tabPageFluxAnalyses = new System.Windows.Forms.TabPage();
			this.listBoxFlx = new System.Windows.Forms.ListBox();
			this.toolStripFluxAnalyses = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonFlxAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonFlxRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonFlxRaise = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonFlxLower = new System.Windows.Forms.ToolStripButton();
			this.tabPageVisualizationOutputs = new System.Windows.Forms.TabPage();
			this.listBoxVis = new System.Windows.Forms.ListBox();
			this.toolStripVisualizationOptics = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonVisAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonVisRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonVisRaise = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonVisLower = new System.Windows.Forms.ToolStripButton();
			this.labelDescription = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBoxSimulationRegion.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPml)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxZ)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinZ)).BeginInit();
			this.groupBoxGeneralSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownResolution)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tabPageSources.SuspendLayout();
			this.toolStripSources.SuspendLayout();
			this.tabPageFluxAnalyses.SuspendLayout();
			this.toolStripFluxAnalyses.SuspendLayout();
			this.tabPageVisualizationOutputs.SuspendLayout();
			this.toolStripVisualizationOptics.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(375, 486);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(537, 486);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// separator01
			// 
			this.separator01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.separator01.BackColor = System.Drawing.SystemColors.ControlDark;
			this.separator01.Location = new System.Drawing.Point(6, 479);
			this.separator01.Name = "separator01";
			this.separator01.Size = new System.Drawing.Size(612, 1);
			this.separator01.TabIndex = 2;
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Location = new System.Drawing.Point(456, 486);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 23);
			this.buttonApply.TabIndex = 1;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// groupBoxSimulationRegion
			// 
			this.groupBoxSimulationRegion.Controls.Add(this.labelPml);
			this.groupBoxSimulationRegion.Controls.Add(this.radioButtonDim3D);
			this.groupBoxSimulationRegion.Controls.Add(this.radioButtonDim2D);
			this.groupBoxSimulationRegion.Controls.Add(this.numericUpDownPml);
			this.groupBoxSimulationRegion.Controls.Add(this.separator02);
			this.groupBoxSimulationRegion.Controls.Add(this.labelMinX);
			this.groupBoxSimulationRegion.Controls.Add(this.panel1);
			this.groupBoxSimulationRegion.Controls.Add(this.numericUpDownMinX);
			this.groupBoxSimulationRegion.Controls.Add(this.numericUpDownMaxX);
			this.groupBoxSimulationRegion.Controls.Add(this.numericUpDownMinY);
			this.groupBoxSimulationRegion.Controls.Add(this.numericUpDownMaxZ);
			this.groupBoxSimulationRegion.Controls.Add(this.numericUpDownMaxY);
			this.groupBoxSimulationRegion.Controls.Add(this.labelMaxZ);
			this.groupBoxSimulationRegion.Controls.Add(this.labelMinZ);
			this.groupBoxSimulationRegion.Controls.Add(this.labelMaxY);
			this.groupBoxSimulationRegion.Controls.Add(this.labelMinY);
			this.groupBoxSimulationRegion.Controls.Add(this.numericUpDownMinZ);
			this.groupBoxSimulationRegion.Controls.Add(this.labelMaxX);
			this.groupBoxSimulationRegion.Location = new System.Drawing.Point(12, 127);
			this.groupBoxSimulationRegion.Name = "groupBoxSimulationRegion";
			this.groupBoxSimulationRegion.Size = new System.Drawing.Size(244, 263);
			this.groupBoxSimulationRegion.TabIndex = 4;
			this.groupBoxSimulationRegion.TabStop = false;
			this.groupBoxSimulationRegion.Text = "simulation region";
			// 
			// labelPml
			// 
			this.labelPml.AutoSize = true;
			this.labelPml.Location = new System.Drawing.Point(6, 236);
			this.labelPml.Name = "labelPml";
			this.labelPml.Size = new System.Drawing.Size(123, 15);
			this.labelPml.TabIndex = 1009;
			this.labelPml.Text = "PML thickness [μm]";
			// 
			// radioButtonDim3D
			// 
			this.radioButtonDim3D.AutoSize = true;
			this.radioButtonDim3D.Location = new System.Drawing.Point(72, 22);
			this.radioButtonDim3D.Name = "radioButtonDim3D";
			this.radioButtonDim3D.Size = new System.Drawing.Size(41, 19);
			this.radioButtonDim3D.TabIndex = 1;
			this.radioButtonDim3D.TabStop = true;
			this.radioButtonDim3D.Text = "3D";
			this.radioButtonDim3D.UseVisualStyleBackColor = true;
			// 
			// radioButtonDim2D
			// 
			this.radioButtonDim2D.AutoSize = true;
			this.radioButtonDim2D.Location = new System.Drawing.Point(6, 22);
			this.radioButtonDim2D.Name = "radioButtonDim2D";
			this.radioButtonDim2D.Size = new System.Drawing.Size(41, 19);
			this.radioButtonDim2D.TabIndex = 0;
			this.radioButtonDim2D.TabStop = true;
			this.radioButtonDim2D.Text = "2D";
			this.radioButtonDim2D.UseVisualStyleBackColor = true;
			// 
			// numericUpDownPml
			// 
			this.numericUpDownPml.DecimalPlaces = 2;
			this.numericUpDownPml.Location = new System.Drawing.Point(140, 234);
			this.numericUpDownPml.Name = "numericUpDownPml";
			this.numericUpDownPml.Size = new System.Drawing.Size(80, 23);
			this.numericUpDownPml.TabIndex = 8;
			this.numericUpDownPml.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// separator02
			// 
			this.separator02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.separator02.BackColor = System.Drawing.SystemColors.ControlDark;
			this.separator02.Location = new System.Drawing.Point(6, 47);
			this.separator02.Name = "separator02";
			this.separator02.Size = new System.Drawing.Size(231, 1);
			this.separator02.TabIndex = 1006;
			// 
			// labelMinX
			// 
			this.labelMinX.AutoSize = true;
			this.labelMinX.Location = new System.Drawing.Point(6, 56);
			this.labelMinX.Name = "labelMinX";
			this.labelMinX.Size = new System.Drawing.Size(109, 15);
			this.labelMinX.TabIndex = 999;
			this.labelMinX.Text = "X minimum [μm]";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel1.Location = new System.Drawing.Point(6, 227);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(232, 1);
			this.panel1.TabIndex = 1007;
			// 
			// numericUpDownMinX
			// 
			this.numericUpDownMinX.DecimalPlaces = 2;
			this.numericUpDownMinX.Location = new System.Drawing.Point(140, 54);
			this.numericUpDownMinX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDownMinX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
			this.numericUpDownMinX.Name = "numericUpDownMinX";
			this.numericUpDownMinX.Size = new System.Drawing.Size(80, 23);
			this.numericUpDownMinX.TabIndex = 2;
			this.numericUpDownMinX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// numericUpDownMaxX
			// 
			this.numericUpDownMaxX.DecimalPlaces = 2;
			this.numericUpDownMaxX.Location = new System.Drawing.Point(140, 83);
			this.numericUpDownMaxX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDownMaxX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
			this.numericUpDownMaxX.Name = "numericUpDownMaxX";
			this.numericUpDownMaxX.Size = new System.Drawing.Size(80, 23);
			this.numericUpDownMaxX.TabIndex = 3;
			this.numericUpDownMaxX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// numericUpDownMinY
			// 
			this.numericUpDownMinY.DecimalPlaces = 2;
			this.numericUpDownMinY.Location = new System.Drawing.Point(140, 112);
			this.numericUpDownMinY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDownMinY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
			this.numericUpDownMinY.Name = "numericUpDownMinY";
			this.numericUpDownMinY.Size = new System.Drawing.Size(80, 23);
			this.numericUpDownMinY.TabIndex = 4;
			this.numericUpDownMinY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// numericUpDownMaxZ
			// 
			this.numericUpDownMaxZ.DecimalPlaces = 2;
			this.numericUpDownMaxZ.Location = new System.Drawing.Point(140, 199);
			this.numericUpDownMaxZ.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDownMaxZ.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
			this.numericUpDownMaxZ.Name = "numericUpDownMaxZ";
			this.numericUpDownMaxZ.Size = new System.Drawing.Size(80, 23);
			this.numericUpDownMaxZ.TabIndex = 7;
			this.numericUpDownMaxZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// numericUpDownMaxY
			// 
			this.numericUpDownMaxY.DecimalPlaces = 2;
			this.numericUpDownMaxY.Location = new System.Drawing.Point(140, 141);
			this.numericUpDownMaxY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDownMaxY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
			this.numericUpDownMaxY.Name = "numericUpDownMaxY";
			this.numericUpDownMaxY.Size = new System.Drawing.Size(80, 23);
			this.numericUpDownMaxY.TabIndex = 5;
			this.numericUpDownMaxY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelMaxZ
			// 
			this.labelMaxZ.AutoSize = true;
			this.labelMaxZ.Location = new System.Drawing.Point(6, 201);
			this.labelMaxZ.Name = "labelMaxZ";
			this.labelMaxZ.Size = new System.Drawing.Size(113, 15);
			this.labelMaxZ.TabIndex = 999;
			this.labelMaxZ.Text = "Z maximum [μm]";
			// 
			// labelMinZ
			// 
			this.labelMinZ.AutoSize = true;
			this.labelMinZ.Location = new System.Drawing.Point(6, 172);
			this.labelMinZ.Name = "labelMinZ";
			this.labelMinZ.Size = new System.Drawing.Size(109, 15);
			this.labelMinZ.TabIndex = 999;
			this.labelMinZ.Text = "Z minimum [μm]";
			// 
			// labelMaxY
			// 
			this.labelMaxY.AutoSize = true;
			this.labelMaxY.Location = new System.Drawing.Point(6, 143);
			this.labelMaxY.Name = "labelMaxY";
			this.labelMaxY.Size = new System.Drawing.Size(113, 15);
			this.labelMaxY.TabIndex = 999;
			this.labelMaxY.Text = "Y maximum [μm]";
			// 
			// labelMinY
			// 
			this.labelMinY.AutoSize = true;
			this.labelMinY.Location = new System.Drawing.Point(6, 114);
			this.labelMinY.Name = "labelMinY";
			this.labelMinY.Size = new System.Drawing.Size(109, 15);
			this.labelMinY.TabIndex = 999;
			this.labelMinY.Text = "Y minimum [μm]";
			// 
			// numericUpDownMinZ
			// 
			this.numericUpDownMinZ.DecimalPlaces = 2;
			this.numericUpDownMinZ.Location = new System.Drawing.Point(140, 170);
			this.numericUpDownMinZ.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDownMinZ.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
			this.numericUpDownMinZ.Name = "numericUpDownMinZ";
			this.numericUpDownMinZ.Size = new System.Drawing.Size(80, 23);
			this.numericUpDownMinZ.TabIndex = 6;
			this.numericUpDownMinZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelMaxX
			// 
			this.labelMaxX.AutoSize = true;
			this.labelMaxX.Location = new System.Drawing.Point(6, 85);
			this.labelMaxX.Name = "labelMaxX";
			this.labelMaxX.Size = new System.Drawing.Size(113, 15);
			this.labelMaxX.TabIndex = 999;
			this.labelMaxX.Text = "X maximum [μm]";
			// 
			// groupBoxGeneralSettings
			// 
			this.groupBoxGeneralSettings.Controls.Add(this.labelBGMaterial);
			this.groupBoxGeneralSettings.Controls.Add(this.labelBackgroundMaterial);
			this.groupBoxGeneralSettings.Controls.Add(this.buttonBGMaterial);
			this.groupBoxGeneralSettings.Controls.Add(this.labelSimulationTime);
			this.groupBoxGeneralSettings.Controls.Add(this.numericUpDownTime);
			this.groupBoxGeneralSettings.Controls.Add(this.labelResolution);
			this.groupBoxGeneralSettings.Controls.Add(this.numericUpDownResolution);
			this.groupBoxGeneralSettings.Location = new System.Drawing.Point(12, 12);
			this.groupBoxGeneralSettings.Name = "groupBoxGeneralSettings";
			this.groupBoxGeneralSettings.Size = new System.Drawing.Size(244, 109);
			this.groupBoxGeneralSettings.TabIndex = 3;
			this.groupBoxGeneralSettings.TabStop = false;
			this.groupBoxGeneralSettings.Text = "general settings";
			// 
			// labelBGMaterial
			// 
			this.labelBGMaterial.AutoSize = true;
			this.labelBGMaterial.Location = new System.Drawing.Point(140, 84);
			this.labelBGMaterial.Name = "labelBGMaterial";
			this.labelBGMaterial.Size = new System.Drawing.Size(39, 15);
			this.labelBGMaterial.TabIndex = 5;
			this.labelBGMaterial.Text = "n = 1";
			// 
			// labelBackgroundMaterial
			// 
			this.labelBackgroundMaterial.AutoSize = true;
			this.labelBackgroundMaterial.Location = new System.Drawing.Point(6, 84);
			this.labelBackgroundMaterial.Name = "labelBackgroundMaterial";
			this.labelBackgroundMaterial.Size = new System.Drawing.Size(127, 15);
			this.labelBackgroundMaterial.TabIndex = 4;
			this.labelBackgroundMaterial.Text = "background material";
			// 
			// buttonBGMaterial
			// 
			this.buttonBGMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBGMaterial.Location = new System.Drawing.Point(214, 80);
			this.buttonBGMaterial.Name = "buttonBGMaterial";
			this.buttonBGMaterial.Size = new System.Drawing.Size(23, 23);
			this.buttonBGMaterial.TabIndex = 3;
			this.buttonBGMaterial.Text = "…";
			this.buttonBGMaterial.UseVisualStyleBackColor = true;
			this.buttonBGMaterial.Click += new System.EventHandler(this.buttonBGMaterial_Click);
			// 
			// labelSimulationTime
			// 
			this.labelSimulationTime.AutoSize = true;
			this.labelSimulationTime.Location = new System.Drawing.Point(6, 53);
			this.labelSimulationTime.Name = "labelSimulationTime";
			this.labelSimulationTime.Size = new System.Drawing.Size(98, 15);
			this.labelSimulationTime.TabIndex = 2;
			this.labelSimulationTime.Text = "simulation time";
			// 
			// numericUpDownTime
			// 
			this.numericUpDownTime.DecimalPlaces = 2;
			this.numericUpDownTime.Location = new System.Drawing.Point(140, 51);
			this.numericUpDownTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDownTime.Name = "numericUpDownTime";
			this.numericUpDownTime.Size = new System.Drawing.Size(80, 23);
			this.numericUpDownTime.TabIndex = 1;
			this.numericUpDownTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelResolution
			// 
			this.labelResolution.AutoSize = true;
			this.labelResolution.Location = new System.Drawing.Point(6, 24);
			this.labelResolution.Name = "labelResolution";
			this.labelResolution.Size = new System.Drawing.Size(103, 15);
			this.labelResolution.TabIndex = 1;
			this.labelResolution.Text = "resolution [/μm]";
			// 
			// numericUpDownResolution
			// 
			this.numericUpDownResolution.DecimalPlaces = 2;
			this.numericUpDownResolution.Location = new System.Drawing.Point(140, 22);
			this.numericUpDownResolution.Name = "numericUpDownResolution";
			this.numericUpDownResolution.Size = new System.Drawing.Size(80, 23);
			this.numericUpDownResolution.TabIndex = 0;
			this.numericUpDownResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tabControl
			// 
			this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tabControl.Controls.Add(this.tabPageSources);
			this.tabControl.Controls.Add(this.tabPageFluxAnalyses);
			this.tabControl.Controls.Add(this.tabPageVisualizationOutputs);
			this.tabControl.Location = new System.Drawing.Point(270, 12);
			this.tabControl.Multiline = true;
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(348, 343);
			this.tabControl.TabIndex = 5;
			// 
			// tabPageSources
			// 
			this.tabPageSources.Controls.Add(this.listBoxSrc);
			this.tabPageSources.Controls.Add(this.toolStripSources);
			this.tabPageSources.Location = new System.Drawing.Point(25, 4);
			this.tabPageSources.Name = "tabPageSources";
			this.tabPageSources.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSources.Size = new System.Drawing.Size(319, 335);
			this.tabPageSources.TabIndex = 0;
			this.tabPageSources.Text = "Sources";
			this.tabPageSources.UseVisualStyleBackColor = true;
			// 
			// listBoxSrc
			// 
			this.listBoxSrc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxSrc.FormattingEnabled = true;
			this.listBoxSrc.ItemHeight = 15;
			this.listBoxSrc.Location = new System.Drawing.Point(3, 28);
			this.listBoxSrc.Name = "listBoxSrc";
			this.listBoxSrc.Size = new System.Drawing.Size(313, 304);
			this.listBoxSrc.TabIndex = 1;
			this.listBoxSrc.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
			this.listBoxSrc.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
			// 
			// toolStripSources
			// 
			this.toolStripSources.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSrcAdd,
            this.toolStripButtonSrcRemove,
            this.toolStripButtonSrcRaise,
            this.toolStripButtonSrcLower});
			this.toolStripSources.Location = new System.Drawing.Point(3, 3);
			this.toolStripSources.Name = "toolStripSources";
			this.toolStripSources.Size = new System.Drawing.Size(313, 25);
			this.toolStripSources.TabIndex = 0;
			this.toolStripSources.Text = "toolStrip1";
			// 
			// toolStripButtonSrcAdd
			// 
			this.toolStripButtonSrcAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonSrcAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSrcAdd.Image")));
			this.toolStripButtonSrcAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonSrcAdd.Name = "toolStripButtonSrcAdd";
			this.toolStripButtonSrcAdd.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonSrcAdd.Text = "+";
			this.toolStripButtonSrcAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
			// 
			// toolStripButtonSrcRemove
			// 
			this.toolStripButtonSrcRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonSrcRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSrcRemove.Image")));
			this.toolStripButtonSrcRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonSrcRemove.Name = "toolStripButtonSrcRemove";
			this.toolStripButtonSrcRemove.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonSrcRemove.Text = "-";
			this.toolStripButtonSrcRemove.Click += new System.EventHandler(this.toolStripButtonRemove_Click);
			// 
			// toolStripButtonSrcRaise
			// 
			this.toolStripButtonSrcRaise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonSrcRaise.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSrcRaise.Image")));
			this.toolStripButtonSrcRaise.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonSrcRaise.Name = "toolStripButtonSrcRaise";
			this.toolStripButtonSrcRaise.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonSrcRaise.Text = "🔺";
			this.toolStripButtonSrcRaise.Click += new System.EventHandler(this.toolStripButtonRaise_Click);
			// 
			// toolStripButtonSrcLower
			// 
			this.toolStripButtonSrcLower.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonSrcLower.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSrcLower.Image")));
			this.toolStripButtonSrcLower.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonSrcLower.Name = "toolStripButtonSrcLower";
			this.toolStripButtonSrcLower.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonSrcLower.Text = "🔻";
			this.toolStripButtonSrcLower.Click += new System.EventHandler(this.toolStripButtonLower_Click);
			// 
			// tabPageFluxAnalyses
			// 
			this.tabPageFluxAnalyses.Controls.Add(this.listBoxFlx);
			this.tabPageFluxAnalyses.Controls.Add(this.toolStripFluxAnalyses);
			this.tabPageFluxAnalyses.Location = new System.Drawing.Point(25, 4);
			this.tabPageFluxAnalyses.Name = "tabPageFluxAnalyses";
			this.tabPageFluxAnalyses.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageFluxAnalyses.Size = new System.Drawing.Size(319, 294);
			this.tabPageFluxAnalyses.TabIndex = 1;
			this.tabPageFluxAnalyses.Text = "Flux analyses";
			this.tabPageFluxAnalyses.UseVisualStyleBackColor = true;
			// 
			// listBoxFlx
			// 
			this.listBoxFlx.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxFlx.FormattingEnabled = true;
			this.listBoxFlx.ItemHeight = 15;
			this.listBoxFlx.Location = new System.Drawing.Point(3, 28);
			this.listBoxFlx.Name = "listBoxFlx";
			this.listBoxFlx.Size = new System.Drawing.Size(313, 263);
			this.listBoxFlx.TabIndex = 1;
			this.listBoxFlx.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
			this.listBoxFlx.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
			// 
			// toolStripFluxAnalyses
			// 
			this.toolStripFluxAnalyses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonFlxAdd,
            this.toolStripButtonFlxRemove,
            this.toolStripButtonFlxRaise,
            this.toolStripButtonFlxLower});
			this.toolStripFluxAnalyses.Location = new System.Drawing.Point(3, 3);
			this.toolStripFluxAnalyses.Name = "toolStripFluxAnalyses";
			this.toolStripFluxAnalyses.Size = new System.Drawing.Size(313, 25);
			this.toolStripFluxAnalyses.TabIndex = 0;
			this.toolStripFluxAnalyses.Text = "toolStrip1";
			// 
			// toolStripButtonFlxAdd
			// 
			this.toolStripButtonFlxAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonFlxAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFlxAdd.Image")));
			this.toolStripButtonFlxAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonFlxAdd.Name = "toolStripButtonFlxAdd";
			this.toolStripButtonFlxAdd.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonFlxAdd.Text = "+";
			this.toolStripButtonFlxAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
			// 
			// toolStripButtonFlxRemove
			// 
			this.toolStripButtonFlxRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonFlxRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFlxRemove.Image")));
			this.toolStripButtonFlxRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonFlxRemove.Name = "toolStripButtonFlxRemove";
			this.toolStripButtonFlxRemove.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonFlxRemove.Text = "-";
			this.toolStripButtonFlxRemove.Click += new System.EventHandler(this.toolStripButtonRemove_Click);
			// 
			// toolStripButtonFlxRaise
			// 
			this.toolStripButtonFlxRaise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonFlxRaise.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFlxRaise.Image")));
			this.toolStripButtonFlxRaise.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonFlxRaise.Name = "toolStripButtonFlxRaise";
			this.toolStripButtonFlxRaise.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonFlxRaise.Text = "🔺";
			this.toolStripButtonFlxRaise.Click += new System.EventHandler(this.toolStripButtonRaise_Click);
			// 
			// toolStripButtonFlxLower
			// 
			this.toolStripButtonFlxLower.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonFlxLower.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFlxLower.Image")));
			this.toolStripButtonFlxLower.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonFlxLower.Name = "toolStripButtonFlxLower";
			this.toolStripButtonFlxLower.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonFlxLower.Text = "🔻";
			this.toolStripButtonFlxLower.Click += new System.EventHandler(this.toolStripButtonLower_Click);
			// 
			// tabPageVisualizationOutputs
			// 
			this.tabPageVisualizationOutputs.Controls.Add(this.listBoxVis);
			this.tabPageVisualizationOutputs.Controls.Add(this.toolStripVisualizationOptics);
			this.tabPageVisualizationOutputs.Location = new System.Drawing.Point(25, 4);
			this.tabPageVisualizationOutputs.Name = "tabPageVisualizationOutputs";
			this.tabPageVisualizationOutputs.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageVisualizationOutputs.Size = new System.Drawing.Size(319, 294);
			this.tabPageVisualizationOutputs.TabIndex = 2;
			this.tabPageVisualizationOutputs.Text = "Visualization outputs";
			this.tabPageVisualizationOutputs.UseVisualStyleBackColor = true;
			// 
			// listBoxVis
			// 
			this.listBoxVis.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxVis.FormattingEnabled = true;
			this.listBoxVis.ItemHeight = 15;
			this.listBoxVis.Location = new System.Drawing.Point(3, 28);
			this.listBoxVis.Name = "listBoxVis";
			this.listBoxVis.Size = new System.Drawing.Size(313, 263);
			this.listBoxVis.TabIndex = 1;
			this.listBoxVis.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
			this.listBoxVis.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
			// 
			// toolStripVisualizationOptics
			// 
			this.toolStripVisualizationOptics.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonVisAdd,
            this.toolStripButtonVisRemove,
            this.toolStripButtonVisRaise,
            this.toolStripButtonVisLower});
			this.toolStripVisualizationOptics.Location = new System.Drawing.Point(3, 3);
			this.toolStripVisualizationOptics.Name = "toolStripVisualizationOptics";
			this.toolStripVisualizationOptics.Size = new System.Drawing.Size(313, 25);
			this.toolStripVisualizationOptics.TabIndex = 0;
			this.toolStripVisualizationOptics.Text = "toolStrip1";
			// 
			// toolStripButtonVisAdd
			// 
			this.toolStripButtonVisAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonVisAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonVisAdd.Image")));
			this.toolStripButtonVisAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonVisAdd.Name = "toolStripButtonVisAdd";
			this.toolStripButtonVisAdd.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonVisAdd.Text = "+";
			this.toolStripButtonVisAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
			// 
			// toolStripButtonVisRemove
			// 
			this.toolStripButtonVisRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonVisRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonVisRemove.Image")));
			this.toolStripButtonVisRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonVisRemove.Name = "toolStripButtonVisRemove";
			this.toolStripButtonVisRemove.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonVisRemove.Text = "-";
			this.toolStripButtonVisRemove.Click += new System.EventHandler(this.toolStripButtonRemove_Click);
			// 
			// toolStripButtonVisRaise
			// 
			this.toolStripButtonVisRaise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonVisRaise.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonVisRaise.Image")));
			this.toolStripButtonVisRaise.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonVisRaise.Name = "toolStripButtonVisRaise";
			this.toolStripButtonVisRaise.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonVisRaise.Text = "🔺";
			this.toolStripButtonVisRaise.Click += new System.EventHandler(this.toolStripButtonRaise_Click);
			// 
			// toolStripButtonVisLower
			// 
			this.toolStripButtonVisLower.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonVisLower.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonVisLower.Image")));
			this.toolStripButtonVisLower.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonVisLower.Name = "toolStripButtonVisLower";
			this.toolStripButtonVisLower.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonVisLower.Text = "🔻";
			this.toolStripButtonVisLower.Click += new System.EventHandler(this.toolStripButtonLower_Click);
			// 
			// labelDescription
			// 
			this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelDescription.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelDescription.Location = new System.Drawing.Point(295, 363);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Padding = new System.Windows.Forms.Padding(1, 3, 1, 3);
			this.labelDescription.Size = new System.Drawing.Size(316, 110);
			this.labelDescription.TabIndex = 6;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.panel2.Location = new System.Drawing.Point(263, 12);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 461);
			this.panel2.TabIndex = 7;
			// 
			// ManifestSettingDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(624, 521);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.groupBoxGeneralSettings);
			this.Controls.Add(this.groupBoxSimulationRegion);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.separator01);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ManifestSettingDialog";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Manifest Setting";
			this.TopMost = true;
			this.groupBoxSimulationRegion.ResumeLayout(false);
			this.groupBoxSimulationRegion.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPml)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxZ)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinZ)).EndInit();
			this.groupBoxGeneralSettings.ResumeLayout(false);
			this.groupBoxGeneralSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownResolution)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.tabPageSources.ResumeLayout(false);
			this.tabPageSources.PerformLayout();
			this.toolStripSources.ResumeLayout(false);
			this.toolStripSources.PerformLayout();
			this.tabPageFluxAnalyses.ResumeLayout(false);
			this.tabPageFluxAnalyses.PerformLayout();
			this.toolStripFluxAnalyses.ResumeLayout(false);
			this.toolStripFluxAnalyses.PerformLayout();
			this.tabPageVisualizationOutputs.ResumeLayout(false);
			this.tabPageVisualizationOutputs.PerformLayout();
			this.toolStripVisualizationOptics.ResumeLayout(false);
			this.toolStripVisualizationOptics.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Panel separator01;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.GroupBox groupBoxSimulationRegion;
		private System.Windows.Forms.Label labelMaxZ;
		private System.Windows.Forms.Label labelMinZ;
		private System.Windows.Forms.Label labelMaxY;
		private System.Windows.Forms.Label labelMinY;
		private System.Windows.Forms.Label labelMaxX;
		private System.Windows.Forms.Label labelMinX;
		private System.Windows.Forms.GroupBox groupBoxGeneralSettings;
		private System.Windows.Forms.RadioButton radioButtonDim3D;
		private System.Windows.Forms.RadioButton radioButtonDim2D;
		private System.Windows.Forms.NumericUpDown numericUpDownMaxZ;
		private System.Windows.Forms.NumericUpDown numericUpDownMinZ;
		private System.Windows.Forms.NumericUpDown numericUpDownMaxY;
		private System.Windows.Forms.NumericUpDown numericUpDownMinY;
		private System.Windows.Forms.NumericUpDown numericUpDownMaxX;
		private System.Windows.Forms.NumericUpDown numericUpDownMinX;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel separator02;
		private System.Windows.Forms.Label labelPml;
		private System.Windows.Forms.NumericUpDown numericUpDownPml;
		private System.Windows.Forms.NumericUpDown numericUpDownResolution;
		private System.Windows.Forms.Label labelResolution;
		private System.Windows.Forms.NumericUpDown numericUpDownTime;
		private System.Windows.Forms.Label labelSimulationTime;
		private System.Windows.Forms.Label labelBackgroundMaterial;
		private System.Windows.Forms.Button buttonBGMaterial;
		private System.Windows.Forms.Label labelBGMaterial;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageSources;
		private System.Windows.Forms.TabPage tabPageFluxAnalyses;
		private System.Windows.Forms.TabPage tabPageVisualizationOutputs;
		private System.Windows.Forms.ToolStrip toolStripSources;
		private System.Windows.Forms.ToolStrip toolStripFluxAnalyses;
		private System.Windows.Forms.ToolStrip toolStripVisualizationOptics;
		private System.Windows.Forms.ToolStripButton toolStripButtonSrcAdd;
		private System.Windows.Forms.ToolStripButton toolStripButtonSrcRemove;
		private System.Windows.Forms.ToolStripButton toolStripButtonSrcRaise;
		private System.Windows.Forms.ToolStripButton toolStripButtonSrcLower;
		private System.Windows.Forms.ToolStripButton toolStripButtonFlxAdd;
		private System.Windows.Forms.ToolStripButton toolStripButtonFlxRemove;
		private System.Windows.Forms.ToolStripButton toolStripButtonFlxRaise;
		private System.Windows.Forms.ToolStripButton toolStripButtonFlxLower;
		private System.Windows.Forms.ToolStripButton toolStripButtonVisAdd;
		private System.Windows.Forms.ToolStripButton toolStripButtonVisRemove;
		private System.Windows.Forms.ToolStripButton toolStripButtonVisRaise;
		private System.Windows.Forms.ToolStripButton toolStripButtonVisLower;
		private System.Windows.Forms.ListBox listBoxSrc;
		private System.Windows.Forms.ListBox listBoxFlx;
		private System.Windows.Forms.ListBox listBoxVis;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Panel panel2;
		}
	}
