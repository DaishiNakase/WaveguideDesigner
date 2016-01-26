namespace Hslab.WaveguideDesigner.Forms
	{
	partial class LayerMaterialEditor
		{
		/// <summary> 
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
			{
			if( disposing && ( components != null ) )
				{
				components.Dispose();
				}
			base.Dispose( disposing );
			}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
			{
			this.labelCenter = new System.Windows.Forms.Label();
			this.labelSize = new System.Windows.Forms.Label();
			this.labelMinZ = new System.Windows.Forms.Label();
			this.labelMaxZ = new System.Windows.Forms.Label();
			this.numericUpDownCenter = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMinZ = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMaxZ = new System.Windows.Forms.NumericUpDown();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.labelName = new System.Windows.Forms.Label();
			this.numericUpDownLayerNumber = new System.Windows.Forms.NumericUpDown();
			this.labelNumber = new System.Windows.Forms.Label();
			this.labelMaterial = new System.Windows.Forms.Label();
			this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinZ)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxZ)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayerNumber)).BeginInit();
			this.SuspendLayout();
			// 
			// labelCenter
			// 
			this.labelCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelCenter.AutoSize = true;
			this.labelCenter.Location = new System.Drawing.Point(3, 481);
			this.labelCenter.Name = "labelCenter";
			this.labelCenter.Size = new System.Drawing.Size(77, 15);
			this.labelCenter.TabIndex = 0;
			this.labelCenter.Text = "center [um]";
			// 
			// labelSize
			// 
			this.labelSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelSize.AutoSize = true;
			this.labelSize.Location = new System.Drawing.Point(3, 512);
			this.labelSize.Name = "labelSize";
			this.labelSize.Size = new System.Drawing.Size(62, 15);
			this.labelSize.TabIndex = 1;
			this.labelSize.Text = "size [um]";
			// 
			// labelMinZ
			// 
			this.labelMinZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelMinZ.AutoSize = true;
			this.labelMinZ.Location = new System.Drawing.Point(3, 574);
			this.labelMinZ.Name = "labelMinZ";
			this.labelMinZ.Size = new System.Drawing.Size(74, 15);
			this.labelMinZ.TabIndex = 2;
			this.labelMinZ.Text = "min Z [um]";
			// 
			// labelMaxZ
			// 
			this.labelMaxZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelMaxZ.AutoSize = true;
			this.labelMaxZ.Location = new System.Drawing.Point(3, 543);
			this.labelMaxZ.Name = "labelMaxZ";
			this.labelMaxZ.Size = new System.Drawing.Size(78, 15);
			this.labelMaxZ.TabIndex = 3;
			this.labelMaxZ.Text = "max Z [um]";
			// 
			// numericUpDownCenter
			// 
			this.numericUpDownCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownCenter.DecimalPlaces = 5;
			this.numericUpDownCenter.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownCenter.Location = new System.Drawing.Point(106, 479);
			this.numericUpDownCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.numericUpDownCenter.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownCenter.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.numericUpDownCenter.Name = "numericUpDownCenter";
			this.numericUpDownCenter.Size = new System.Drawing.Size(70, 23);
			this.numericUpDownCenter.TabIndex = 4;
			this.numericUpDownCenter.ValueChanged += new System.EventHandler(this.numericUpDownCenterSize_ValueChanged);
			// 
			// numericUpDownSize
			// 
			this.numericUpDownSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownSize.DecimalPlaces = 5;
			this.numericUpDownSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownSize.Location = new System.Drawing.Point(106, 510);
			this.numericUpDownSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.numericUpDownSize.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
			this.numericUpDownSize.Name = "numericUpDownSize";
			this.numericUpDownSize.Size = new System.Drawing.Size(70, 23);
			this.numericUpDownSize.TabIndex = 5;
			this.numericUpDownSize.ValueChanged += new System.EventHandler(this.numericUpDownCenterSize_ValueChanged);
			// 
			// numericUpDownMinZ
			// 
			this.numericUpDownMinZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownMinZ.DecimalPlaces = 5;
			this.numericUpDownMinZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownMinZ.Location = new System.Drawing.Point(106, 572);
			this.numericUpDownMinZ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.numericUpDownMinZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownMinZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.numericUpDownMinZ.Name = "numericUpDownMinZ";
			this.numericUpDownMinZ.Size = new System.Drawing.Size(70, 23);
			this.numericUpDownMinZ.TabIndex = 6;
			this.numericUpDownMinZ.ValueChanged += new System.EventHandler(this.numericUpDownMaxMin_ValueChanged);
			// 
			// numericUpDownMaxZ
			// 
			this.numericUpDownMaxZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownMaxZ.DecimalPlaces = 5;
			this.numericUpDownMaxZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownMaxZ.Location = new System.Drawing.Point(106, 541);
			this.numericUpDownMaxZ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.numericUpDownMaxZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownMaxZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.numericUpDownMaxZ.Name = "numericUpDownMaxZ";
			this.numericUpDownMaxZ.Size = new System.Drawing.Size(70, 23);
			this.numericUpDownMaxZ.TabIndex = 7;
			this.numericUpDownMaxZ.ValueChanged += new System.EventHandler(this.numericUpDownMaxMin_ValueChanged);
			// 
			// pictureBox
			// 
			this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox.BackColor = System.Drawing.Color.Black;
			this.pictureBox.Location = new System.Drawing.Point(0, 28);
			this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(180, 414);
			this.pictureBox.TabIndex = 9;
			this.pictureBox.TabStop = false;
			this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
			this.pictureBox.Resize += new System.EventHandler(this.pictureBox_Resize);
			// 
			// labelName
			// 
			this.labelName.Location = new System.Drawing.Point(0, 0);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(97, 25);
			this.labelName.TabIndex = 11;
			this.labelName.Text = "layer";
			this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// numericUpDownLayerNumber
			// 
			this.numericUpDownLayerNumber.Location = new System.Drawing.Point(131, 2);
			this.numericUpDownLayerNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownLayerNumber.Name = "numericUpDownLayerNumber";
			this.numericUpDownLayerNumber.Size = new System.Drawing.Size(45, 23);
			this.numericUpDownLayerNumber.TabIndex = 12;
			this.numericUpDownLayerNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownLayerNumber.ValueChanged += new System.EventHandler(this.numericUpDownLayerNumber_ValueChanged);
			// 
			// labelNumber
			// 
			this.labelNumber.AutoSize = true;
			this.labelNumber.Location = new System.Drawing.Point(103, 4);
			this.labelNumber.Margin = new System.Windows.Forms.Padding(0);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new System.Drawing.Size(27, 15);
			this.labelNumber.TabIndex = 13;
			this.labelNumber.Text = "No.";
			// 
			// labelMaterial
			// 
			this.labelMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelMaterial.AutoSize = true;
			this.labelMaterial.Location = new System.Drawing.Point(3, 452);
			this.labelMaterial.Name = "labelMaterial";
			this.labelMaterial.Size = new System.Drawing.Size(56, 15);
			this.labelMaterial.TabIndex = 15;
			this.labelMaterial.Text = "material";
			// 
			// comboBoxMaterial
			// 
			this.comboBoxMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.comboBoxMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMaterial.FormattingEnabled = true;
			this.comboBoxMaterial.Location = new System.Drawing.Point(65, 449);
			this.comboBoxMaterial.Name = "comboBoxMaterial";
			this.comboBoxMaterial.Size = new System.Drawing.Size(111, 23);
			this.comboBoxMaterial.TabIndex = 14;
			// 
			// LayerMaterialEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelMaterial);
			this.Controls.Add(this.comboBoxMaterial);
			this.Controls.Add(this.labelNumber);
			this.Controls.Add(this.numericUpDownLayerNumber);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.numericUpDownMaxZ);
			this.Controls.Add(this.numericUpDownMinZ);
			this.Controls.Add(this.numericUpDownSize);
			this.Controls.Add(this.numericUpDownCenter);
			this.Controls.Add(this.labelMaxZ);
			this.Controls.Add(this.labelMinZ);
			this.Controls.Add(this.labelSize);
			this.Controls.Add(this.labelCenter);
			this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "LayerMaterialEditor";
			this.Size = new System.Drawing.Size(180, 600);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinZ)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxZ)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayerNumber)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Label labelCenter;
		private System.Windows.Forms.Label labelSize;
		private System.Windows.Forms.Label labelMinZ;
		private System.Windows.Forms.Label labelMaxZ;
		private System.Windows.Forms.NumericUpDown numericUpDownCenter;
		private System.Windows.Forms.NumericUpDown numericUpDownSize;
		private System.Windows.Forms.NumericUpDown numericUpDownMinZ;
		private System.Windows.Forms.NumericUpDown numericUpDownMaxZ;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.NumericUpDown numericUpDownLayerNumber;
		private System.Windows.Forms.Label labelNumber;
		private System.Windows.Forms.Label labelMaterial;
		private System.Windows.Forms.ComboBox comboBoxMaterial;
		}
	}
