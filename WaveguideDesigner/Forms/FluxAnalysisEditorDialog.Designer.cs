namespace Hslab.WaveguideDesigner.Forms
	{
	partial class FluxAnalysisEditorDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FluxAnalysisEditorDialog));
			this.comboBoxFluxDirection = new System.Windows.Forms.ComboBox();
			this.labelFluxDirection = new System.Windows.Forms.Label();
			this.vectorEditorCenter = new Hslab.WaveguideDesigner.Forms.VectorEditor();
			this.labelCenter = new System.Windows.Forms.Label();
			this.vectorEditorSize = new Hslab.WaveguideDesigner.Forms.VectorEditor();
			this.labelSize = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelName = new System.Windows.Forms.Label();
			this.numericUpDownCenterWavelength = new System.Windows.Forms.NumericUpDown();
			this.labelCenterWavelength = new System.Windows.Forms.Label();
			this.labelWavelengthSpan = new System.Windows.Forms.Label();
			this.numericUpDownWavelengthSpan = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownPointNum = new System.Windows.Forms.NumericUpDown();
			this.labelPointNum = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterWavelength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWavelengthSpan)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointNum)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBoxFluxDirection
			// 
			this.comboBoxFluxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFluxDirection.FormattingEnabled = true;
			this.comboBoxFluxDirection.Location = new System.Drawing.Point(166, 129);
			this.comboBoxFluxDirection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.comboBoxFluxDirection.Name = "comboBoxFluxDirection";
			this.comboBoxFluxDirection.Size = new System.Drawing.Size(138, 23);
			this.comboBoxFluxDirection.TabIndex = 0;
			// 
			// labelFluxDirection
			// 
			this.labelFluxDirection.AutoSize = true;
			this.labelFluxDirection.Location = new System.Drawing.Point(12, 132);
			this.labelFluxDirection.Name = "labelFluxDirection";
			this.labelFluxDirection.Size = new System.Drawing.Size(82, 15);
			this.labelFluxDirection.TabIndex = 1;
			this.labelFluxDirection.Text = "flux direction";
			// 
			// vectorEditorCenter
			// 
			this.vectorEditorCenter.DoesCancelInvalid = true;
			this.vectorEditorCenter.Location = new System.Drawing.Point(166, 160);
			this.vectorEditorCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.vectorEditorCenter.Name = "vectorEditorCenter";
			this.vectorEditorCenter.Size = new System.Drawing.Size(138, 23);
			this.vectorEditorCenter.TabIndex = 2;
			this.vectorEditorCenter.Text = "(0, 0, 0)";
			this.vectorEditorCenter.Value = ((Hslab.Vector3)(resources.GetObject("vectorEditorCenter.Value")));
			// 
			// labelCenter
			// 
			this.labelCenter.AutoSize = true;
			this.labelCenter.Location = new System.Drawing.Point(12, 163);
			this.labelCenter.Name = "labelCenter";
			this.labelCenter.Size = new System.Drawing.Size(44, 15);
			this.labelCenter.TabIndex = 3;
			this.labelCenter.Text = "center";
			// 
			// vectorEditorSize
			// 
			this.vectorEditorSize.DoesCancelInvalid = true;
			this.vectorEditorSize.Location = new System.Drawing.Point(166, 191);
			this.vectorEditorSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.vectorEditorSize.Name = "vectorEditorSize";
			this.vectorEditorSize.Size = new System.Drawing.Size(138, 23);
			this.vectorEditorSize.TabIndex = 4;
			this.vectorEditorSize.Text = "(0, 0, 0)";
			this.vectorEditorSize.Value = ((Hslab.Vector3)(resources.GetObject("vectorEditorSize.Value")));
			// 
			// labelSize
			// 
			this.labelSize.AutoSize = true;
			this.labelSize.Location = new System.Drawing.Point(12, 194);
			this.labelSize.Name = "labelSize";
			this.labelSize.Size = new System.Drawing.Size(29, 15);
			this.labelSize.TabIndex = 5;
			this.labelSize.Text = "size";
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(73, 222);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(87, 29);
			this.buttonOK.TabIndex = 6;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(166, 222);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(87, 29);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(166, 12);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(138, 23);
			this.textBoxName.TabIndex = 8;
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(12, 15);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(40, 15);
			this.labelName.TabIndex = 9;
			this.labelName.Text = "name";
			// 
			// numericUpDownCenterWavelength
			// 
			this.numericUpDownCenterWavelength.DecimalPlaces = 2;
			this.numericUpDownCenterWavelength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownCenterWavelength.Location = new System.Drawing.Point(166, 41);
			this.numericUpDownCenterWavelength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownCenterWavelength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDownCenterWavelength.Name = "numericUpDownCenterWavelength";
			this.numericUpDownCenterWavelength.Size = new System.Drawing.Size(138, 23);
			this.numericUpDownCenterWavelength.TabIndex = 10;
			this.numericUpDownCenterWavelength.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// labelCenterWavelength
			// 
			this.labelCenterWavelength.AutoSize = true;
			this.labelCenterWavelength.Location = new System.Drawing.Point(12, 43);
			this.labelCenterWavelength.Name = "labelCenterWavelength";
			this.labelCenterWavelength.Size = new System.Drawing.Size(148, 15);
			this.labelCenterWavelength.TabIndex = 11;
			this.labelCenterWavelength.Text = "center wavelength [nm]";
			// 
			// labelWavelengthSpan
			// 
			this.labelWavelengthSpan.AutoSize = true;
			this.labelWavelengthSpan.Location = new System.Drawing.Point(12, 72);
			this.labelWavelengthSpan.Name = "labelWavelengthSpan";
			this.labelWavelengthSpan.Size = new System.Drawing.Size(138, 15);
			this.labelWavelengthSpan.TabIndex = 12;
			this.labelWavelengthSpan.Text = "wavelength span [nm]";
			// 
			// numericUpDownWavelengthSpan
			// 
			this.numericUpDownWavelengthSpan.DecimalPlaces = 4;
			this.numericUpDownWavelengthSpan.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownWavelengthSpan.Location = new System.Drawing.Point(166, 70);
			this.numericUpDownWavelengthSpan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            327680});
			this.numericUpDownWavelengthSpan.Name = "numericUpDownWavelengthSpan";
			this.numericUpDownWavelengthSpan.Size = new System.Drawing.Size(138, 23);
			this.numericUpDownWavelengthSpan.TabIndex = 13;
			this.numericUpDownWavelengthSpan.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			// 
			// numericUpDownPointNum
			// 
			this.numericUpDownPointNum.Location = new System.Drawing.Point(166, 99);
			this.numericUpDownPointNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownPointNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numericUpDownPointNum.Name = "numericUpDownPointNum";
			this.numericUpDownPointNum.Size = new System.Drawing.Size(138, 23);
			this.numericUpDownPointNum.TabIndex = 14;
			this.numericUpDownPointNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// labelPointNum
			// 
			this.labelPointNum.AutoSize = true;
			this.labelPointNum.Location = new System.Drawing.Point(12, 101);
			this.labelPointNum.Name = "labelPointNum";
			this.labelPointNum.Size = new System.Drawing.Size(85, 15);
			this.labelPointNum.TabIndex = 15;
			this.labelPointNum.Text = "point number";
			// 
			// FluxAnalysisEditorDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(320, 261);
			this.Controls.Add(this.labelPointNum);
			this.Controls.Add(this.numericUpDownPointNum);
			this.Controls.Add(this.numericUpDownWavelengthSpan);
			this.Controls.Add(this.labelWavelengthSpan);
			this.Controls.Add(this.labelCenterWavelength);
			this.Controls.Add(this.numericUpDownCenterWavelength);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.labelSize);
			this.Controls.Add(this.vectorEditorSize);
			this.Controls.Add(this.labelCenter);
			this.Controls.Add(this.vectorEditorCenter);
			this.Controls.Add(this.labelFluxDirection);
			this.Controls.Add(this.comboBoxFluxDirection);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FluxAnalysisEditorDialog";
			this.Text = "FluxAnalysisEditorDialog";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterWavelength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWavelengthSpan)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointNum)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxFluxDirection;
		private System.Windows.Forms.Label labelFluxDirection;
		private VectorEditor vectorEditorCenter;
		private System.Windows.Forms.Label labelCenter;
		private VectorEditor vectorEditorSize;
		private System.Windows.Forms.Label labelSize;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.NumericUpDown numericUpDownCenterWavelength;
		private System.Windows.Forms.Label labelCenterWavelength;
		private System.Windows.Forms.Label labelWavelengthSpan;
		private System.Windows.Forms.NumericUpDown numericUpDownWavelengthSpan;
		private System.Windows.Forms.NumericUpDown numericUpDownPointNum;
		private System.Windows.Forms.Label labelPointNum;
		}
	}