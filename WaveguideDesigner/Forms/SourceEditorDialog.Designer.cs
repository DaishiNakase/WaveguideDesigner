namespace Hslab.WaveguideDesigner.Forms
	{
	partial class SourceEditorDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourceEditorDialog));
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
			this.comboBoxSourceType = new System.Windows.Forms.ComboBox();
			this.labelSourceType = new System.Windows.Forms.Label();
			this.comboBoxComponent = new System.Windows.Forms.ComboBox();
			this.labelComponent = new System.Windows.Forms.Label();
			this.labelCenter = new System.Windows.Forms.Label();
			this.vectorEditorCenter = new Hslab.WaveguideDesigner.Forms.VectorEditor();
			this.labelSize = new System.Windows.Forms.Label();
			this.vectorEditorSize = new Hslab.WaveguideDesigner.Forms.VectorEditor();
			this.numericUpDownAmplitude = new System.Windows.Forms.NumericUpDown();
			this.labelAmplitude = new System.Windows.Forms.Label();
			this.numericUpDownWavelength = new System.Windows.Forms.NumericUpDown();
			this.labelWavelength = new System.Windows.Forms.Label();
			this.numericUpDownStartTime = new System.Windows.Forms.NumericUpDown();
			this.labelStartTime = new System.Windows.Forms.Label();
			this.labelEndTime = new System.Windows.Forms.Label();
			this.numericUpDownEndTime = new System.Windows.Forms.NumericUpDown();
			this.checkBoxEndTimeInfinity = new System.Windows.Forms.CheckBox();
			this.labelWidth = new System.Windows.Forms.Label();
			this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
			this.border1 = new System.Windows.Forms.Panel();
			this.border2 = new System.Windows.Forms.Panel();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmplitude)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWavelength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
			this.SuspendLayout();
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(12, 15);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(32, 12);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "name";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(88, 12);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(328, 19);
			this.textBoxName.TabIndex = 1;
			// 
			// checkBoxEnabled
			// 
			this.checkBoxEnabled.AutoSize = true;
			this.checkBoxEnabled.Location = new System.Drawing.Point(14, 37);
			this.checkBoxEnabled.Name = "checkBoxEnabled";
			this.checkBoxEnabled.Size = new System.Drawing.Size(63, 16);
			this.checkBoxEnabled.TabIndex = 2;
			this.checkBoxEnabled.Text = "enabled";
			this.checkBoxEnabled.UseVisualStyleBackColor = true;
			// 
			// comboBoxSourceType
			// 
			this.comboBoxSourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSourceType.FormattingEnabled = true;
			this.comboBoxSourceType.Location = new System.Drawing.Point(88, 60);
			this.comboBoxSourceType.Name = "comboBoxSourceType";
			this.comboBoxSourceType.Size = new System.Drawing.Size(121, 20);
			this.comboBoxSourceType.TabIndex = 5;
			// 
			// labelSourceType
			// 
			this.labelSourceType.AutoSize = true;
			this.labelSourceType.Location = new System.Drawing.Point(12, 63);
			this.labelSourceType.Name = "labelSourceType";
			this.labelSourceType.Size = new System.Drawing.Size(65, 12);
			this.labelSourceType.TabIndex = 6;
			this.labelSourceType.Text = "source type";
			// 
			// comboBoxComponent
			// 
			this.comboBoxComponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxComponent.FormattingEnabled = true;
			this.comboBoxComponent.Location = new System.Drawing.Point(88, 85);
			this.comboBoxComponent.Name = "comboBoxComponent";
			this.comboBoxComponent.Size = new System.Drawing.Size(121, 20);
			this.comboBoxComponent.TabIndex = 7;
			// 
			// labelComponent
			// 
			this.labelComponent.AutoSize = true;
			this.labelComponent.Location = new System.Drawing.Point(12, 88);
			this.labelComponent.Name = "labelComponent";
			this.labelComponent.Size = new System.Drawing.Size(60, 12);
			this.labelComponent.TabIndex = 8;
			this.labelComponent.Text = "component";
			// 
			// labelCenter
			// 
			this.labelCenter.AutoSize = true;
			this.labelCenter.Location = new System.Drawing.Point(12, 113);
			this.labelCenter.Name = "labelCenter";
			this.labelCenter.Size = new System.Drawing.Size(37, 12);
			this.labelCenter.TabIndex = 9;
			this.labelCenter.Text = "center";
			// 
			// vectorEditorCenter
			// 
			this.vectorEditorCenter.DoesCancelInvalid = true;
			this.vectorEditorCenter.Location = new System.Drawing.Point(88, 110);
			this.vectorEditorCenter.Name = "vectorEditorCenter";
			this.vectorEditorCenter.Size = new System.Drawing.Size(121, 19);
			this.vectorEditorCenter.TabIndex = 10;
			this.vectorEditorCenter.Text = "(0, 0, 0)";
			this.vectorEditorCenter.Value = ((Hslab.Vector3)(resources.GetObject("vectorEditorCenter.Value")));
			// 
			// labelSize
			// 
			this.labelSize.AutoSize = true;
			this.labelSize.Location = new System.Drawing.Point(12, 138);
			this.labelSize.Name = "labelSize";
			this.labelSize.Size = new System.Drawing.Size(25, 12);
			this.labelSize.TabIndex = 11;
			this.labelSize.Text = "size";
			// 
			// vectorEditorSize
			// 
			this.vectorEditorSize.DoesCancelInvalid = true;
			this.vectorEditorSize.Location = new System.Drawing.Point(88, 135);
			this.vectorEditorSize.Name = "vectorEditorSize";
			this.vectorEditorSize.Size = new System.Drawing.Size(121, 19);
			this.vectorEditorSize.TabIndex = 12;
			this.vectorEditorSize.Text = "(0, 0, 0)";
			this.vectorEditorSize.Value = ((Hslab.Vector3)(resources.GetObject("vectorEditorSize.Value")));
			// 
			// numericUpDownAmplitude
			// 
			this.numericUpDownAmplitude.DecimalPlaces = 4;
			this.numericUpDownAmplitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDownAmplitude.Location = new System.Drawing.Point(317, 36);
			this.numericUpDownAmplitude.Name = "numericUpDownAmplitude";
			this.numericUpDownAmplitude.Size = new System.Drawing.Size(99, 19);
			this.numericUpDownAmplitude.TabIndex = 13;
			this.numericUpDownAmplitude.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// labelAmplitude
			// 
			this.labelAmplitude.AutoSize = true;
			this.labelAmplitude.Location = new System.Drawing.Point(222, 38);
			this.labelAmplitude.Name = "labelAmplitude";
			this.labelAmplitude.Size = new System.Drawing.Size(54, 12);
			this.labelAmplitude.TabIndex = 14;
			this.labelAmplitude.Text = "amplitude";
			// 
			// numericUpDownWavelength
			// 
			this.numericUpDownWavelength.DecimalPlaces = 2;
			this.numericUpDownWavelength.Location = new System.Drawing.Point(317, 61);
			this.numericUpDownWavelength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownWavelength.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDownWavelength.Name = "numericUpDownWavelength";
			this.numericUpDownWavelength.Size = new System.Drawing.Size(99, 19);
			this.numericUpDownWavelength.TabIndex = 15;
			this.numericUpDownWavelength.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// labelWavelength
			// 
			this.labelWavelength.AutoSize = true;
			this.labelWavelength.Location = new System.Drawing.Point(222, 63);
			this.labelWavelength.Name = "labelWavelength";
			this.labelWavelength.Size = new System.Drawing.Size(89, 12);
			this.labelWavelength.TabIndex = 16;
			this.labelWavelength.Text = "wavelength [nm]";
			// 
			// numericUpDownStartTime
			// 
			this.numericUpDownStartTime.Location = new System.Drawing.Point(317, 86);
			this.numericUpDownStartTime.Name = "numericUpDownStartTime";
			this.numericUpDownStartTime.Size = new System.Drawing.Size(99, 19);
			this.numericUpDownStartTime.TabIndex = 17;
			// 
			// labelStartTime
			// 
			this.labelStartTime.AutoSize = true;
			this.labelStartTime.Location = new System.Drawing.Point(222, 88);
			this.labelStartTime.Name = "labelStartTime";
			this.labelStartTime.Size = new System.Drawing.Size(55, 12);
			this.labelStartTime.TabIndex = 18;
			this.labelStartTime.Text = "start time";
			// 
			// labelEndTime
			// 
			this.labelEndTime.AutoSize = true;
			this.labelEndTime.Location = new System.Drawing.Point(222, 113);
			this.labelEndTime.Name = "labelEndTime";
			this.labelEndTime.Size = new System.Drawing.Size(49, 12);
			this.labelEndTime.TabIndex = 20;
			this.labelEndTime.Text = "end time";
			// 
			// numericUpDownEndTime
			// 
			this.numericUpDownEndTime.Enabled = false;
			this.numericUpDownEndTime.Location = new System.Drawing.Point(317, 111);
			this.numericUpDownEndTime.Name = "numericUpDownEndTime";
			this.numericUpDownEndTime.Size = new System.Drawing.Size(57, 19);
			this.numericUpDownEndTime.TabIndex = 19;
			// 
			// checkBoxEndTimeInfinity
			// 
			this.checkBoxEndTimeInfinity.AutoSize = true;
			this.checkBoxEndTimeInfinity.Checked = true;
			this.checkBoxEndTimeInfinity.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxEndTimeInfinity.Location = new System.Drawing.Point(380, 112);
			this.checkBoxEndTimeInfinity.Name = "checkBoxEndTimeInfinity";
			this.checkBoxEndTimeInfinity.Size = new System.Drawing.Size(36, 16);
			this.checkBoxEndTimeInfinity.TabIndex = 21;
			this.checkBoxEndTimeInfinity.Text = "∞";
			this.checkBoxEndTimeInfinity.UseVisualStyleBackColor = true;
			this.checkBoxEndTimeInfinity.CheckedChanged += new System.EventHandler(this.checkBoxEndTimeInfinity_CheckedChanged);
			// 
			// labelWidth
			// 
			this.labelWidth.AutoSize = true;
			this.labelWidth.Location = new System.Drawing.Point(222, 138);
			this.labelWidth.Name = "labelWidth";
			this.labelWidth.Size = new System.Drawing.Size(32, 12);
			this.labelWidth.TabIndex = 22;
			this.labelWidth.Text = "width";
			// 
			// numericUpDownWidth
			// 
			this.numericUpDownWidth.Location = new System.Drawing.Point(317, 136);
			this.numericUpDownWidth.Name = "numericUpDownWidth";
			this.numericUpDownWidth.Size = new System.Drawing.Size(99, 19);
			this.numericUpDownWidth.TabIndex = 23;
			// 
			// border1
			// 
			this.border1.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.border1.Location = new System.Drawing.Point(215, 37);
			this.border1.Name = "border1";
			this.border1.Size = new System.Drawing.Size(1, 118);
			this.border1.TabIndex = 24;
			// 
			// border2
			// 
			this.border2.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.border2.Location = new System.Drawing.Point(14, 160);
			this.border2.Name = "border2";
			this.border2.Size = new System.Drawing.Size(402, 1);
			this.border2.TabIndex = 25;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(341, 167);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 26;
			this.buttonCancel.Text = "cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(260, 167);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 27;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// SourceEditorDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(433, 199);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.border2);
			this.Controls.Add(this.border1);
			this.Controls.Add(this.numericUpDownWidth);
			this.Controls.Add(this.labelWidth);
			this.Controls.Add(this.checkBoxEndTimeInfinity);
			this.Controls.Add(this.labelEndTime);
			this.Controls.Add(this.numericUpDownEndTime);
			this.Controls.Add(this.labelStartTime);
			this.Controls.Add(this.numericUpDownStartTime);
			this.Controls.Add(this.labelWavelength);
			this.Controls.Add(this.numericUpDownWavelength);
			this.Controls.Add(this.labelAmplitude);
			this.Controls.Add(this.numericUpDownAmplitude);
			this.Controls.Add(this.vectorEditorSize);
			this.Controls.Add(this.labelSize);
			this.Controls.Add(this.vectorEditorCenter);
			this.Controls.Add(this.labelCenter);
			this.Controls.Add(this.labelComponent);
			this.Controls.Add(this.comboBoxComponent);
			this.Controls.Add(this.labelSourceType);
			this.Controls.Add(this.comboBoxSourceType);
			this.Controls.Add(this.checkBoxEnabled);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SourceEditorDialog";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "SourceEditorDialog";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmplitude)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWavelength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.CheckBox checkBoxEnabled;
		private System.Windows.Forms.ComboBox comboBoxSourceType;
		private System.Windows.Forms.Label labelSourceType;
		private System.Windows.Forms.ComboBox comboBoxComponent;
		private System.Windows.Forms.Label labelComponent;
		private System.Windows.Forms.Label labelCenter;
		private VectorEditor vectorEditorCenter;
		private System.Windows.Forms.Label labelSize;
		private VectorEditor vectorEditorSize;
		private System.Windows.Forms.NumericUpDown numericUpDownAmplitude;
		private System.Windows.Forms.Label labelAmplitude;
		private System.Windows.Forms.NumericUpDown numericUpDownWavelength;
		private System.Windows.Forms.Label labelWavelength;
		private System.Windows.Forms.NumericUpDown numericUpDownStartTime;
		private System.Windows.Forms.Label labelStartTime;
		private System.Windows.Forms.Label labelEndTime;
		private System.Windows.Forms.NumericUpDown numericUpDownEndTime;
		private System.Windows.Forms.CheckBox checkBoxEndTimeInfinity;
		private System.Windows.Forms.Label labelWidth;
		private System.Windows.Forms.NumericUpDown numericUpDownWidth;
		private System.Windows.Forms.Panel border1;
		private System.Windows.Forms.Panel border2;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		}
	}