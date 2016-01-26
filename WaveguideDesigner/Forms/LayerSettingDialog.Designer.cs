namespace Hslab.WaveguideDesigner.Forms
	{
	partial class LayerSettingDialog
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
			this.buttonMaterial = new System.Windows.Forms.Button();
			this.labelMaterialValue = new System.Windows.Forms.Label();
			this.groupBoxMaterial = new System.Windows.Forms.GroupBox();
			this.groupBoxRenderingStyle = new System.Windows.Forms.GroupBox();
			this.buttonFillStyle = new System.Windows.Forms.Button();
			this.buttonFillColor = new System.Windows.Forms.Button();
			this.pictureBoxRenderingStyle = new System.Windows.Forms.PictureBox();
			this.buttonBorderColor = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxLayerName = new System.Windows.Forms.TextBox();
			this.groupBoxMaterial.SuspendLayout();
			this.groupBoxRenderingStyle.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxRenderingStyle)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonMaterial
			// 
			this.buttonMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMaterial.Location = new System.Drawing.Point(6, 22);
			this.buttonMaterial.Name = "buttonMaterial";
			this.buttonMaterial.Size = new System.Drawing.Size(188, 23);
			this.buttonMaterial.TabIndex = 1;
			this.buttonMaterial.Text = "material...";
			this.buttonMaterial.UseVisualStyleBackColor = true;
			this.buttonMaterial.Click += new System.EventHandler(this.buttonMaterial_Click);
			// 
			// labelMaterialValue
			// 
			this.labelMaterialValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelMaterialValue.Location = new System.Drawing.Point(6, 48);
			this.labelMaterialValue.Name = "labelMaterialValue";
			this.labelMaterialValue.Size = new System.Drawing.Size(188, 66);
			this.labelMaterialValue.TabIndex = 2;
			this.labelMaterialValue.Text = "center : 0\r\nsize : 0\r\nindex : 1";
			// 
			// groupBoxMaterial
			// 
			this.groupBoxMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxMaterial.Controls.Add(this.labelMaterialValue);
			this.groupBoxMaterial.Controls.Add(this.buttonMaterial);
			this.groupBoxMaterial.Location = new System.Drawing.Point(12, 41);
			this.groupBoxMaterial.Name = "groupBoxMaterial";
			this.groupBoxMaterial.Size = new System.Drawing.Size(200, 117);
			this.groupBoxMaterial.TabIndex = 3;
			this.groupBoxMaterial.TabStop = false;
			this.groupBoxMaterial.Text = "material";
			// 
			// groupBoxRenderingStyle
			// 
			this.groupBoxRenderingStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxRenderingStyle.Controls.Add(this.buttonFillStyle);
			this.groupBoxRenderingStyle.Controls.Add(this.buttonFillColor);
			this.groupBoxRenderingStyle.Controls.Add(this.pictureBoxRenderingStyle);
			this.groupBoxRenderingStyle.Controls.Add(this.buttonBorderColor);
			this.groupBoxRenderingStyle.Location = new System.Drawing.Point(12, 164);
			this.groupBoxRenderingStyle.Name = "groupBoxRenderingStyle";
			this.groupBoxRenderingStyle.Size = new System.Drawing.Size(200, 105);
			this.groupBoxRenderingStyle.TabIndex = 4;
			this.groupBoxRenderingStyle.TabStop = false;
			this.groupBoxRenderingStyle.Text = "rendering style";
			// 
			// buttonFillStyle
			// 
			this.buttonFillStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFillStyle.Location = new System.Drawing.Point(9, 77);
			this.buttonFillStyle.Name = "buttonFillStyle";
			this.buttonFillStyle.Size = new System.Drawing.Size(140, 23);
			this.buttonFillStyle.TabIndex = 5;
			this.buttonFillStyle.Text = "fill style...";
			this.buttonFillStyle.UseVisualStyleBackColor = true;
			this.buttonFillStyle.Click += new System.EventHandler(this.buttonFillStyle_Click);
			// 
			// buttonFillColor
			// 
			this.buttonFillColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFillColor.Location = new System.Drawing.Point(9, 48);
			this.buttonFillColor.Name = "buttonFillColor";
			this.buttonFillColor.Size = new System.Drawing.Size(140, 23);
			this.buttonFillColor.TabIndex = 4;
			this.buttonFillColor.Text = "fill color...";
			this.buttonFillColor.UseVisualStyleBackColor = true;
			this.buttonFillColor.Click += new System.EventHandler(this.buttonFillColor_Click);
			// 
			// pictureBoxRenderingStyle
			// 
			this.pictureBoxRenderingStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxRenderingStyle.BackColor = System.Drawing.Color.Black;
			this.pictureBoxRenderingStyle.Location = new System.Drawing.Point(155, 40);
			this.pictureBoxRenderingStyle.Name = "pictureBoxRenderingStyle";
			this.pictureBoxRenderingStyle.Size = new System.Drawing.Size(37, 37);
			this.pictureBoxRenderingStyle.TabIndex = 3;
			this.pictureBoxRenderingStyle.TabStop = false;
			this.pictureBoxRenderingStyle.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxRenderingStyle_Paint);
			// 
			// buttonBorderColor
			// 
			this.buttonBorderColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBorderColor.Location = new System.Drawing.Point(8, 19);
			this.buttonBorderColor.Name = "buttonBorderColor";
			this.buttonBorderColor.Size = new System.Drawing.Size(140, 23);
			this.buttonBorderColor.TabIndex = 2;
			this.buttonBorderColor.Text = "border color...";
			this.buttonBorderColor.UseVisualStyleBackColor = true;
			this.buttonBorderColor.Click += new System.EventHandler(this.buttonBorderColor_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(56, 286);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 5;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(137, 286);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(9, 15);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(40, 15);
			this.labelName.TabIndex = 7;
			this.labelName.Text = "name";
			// 
			// textBox1
			// 
			this.textBoxLayerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLayerName.Location = new System.Drawing.Point(72, 12);
			this.textBoxLayerName.Name = "textBox1";
			this.textBoxLayerName.Size = new System.Drawing.Size(140, 23);
			this.textBoxLayerName.TabIndex = 8;
			// 
			// LayerSettingDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(224, 321);
			this.Controls.Add(this.textBoxLayerName);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupBoxRenderingStyle);
			this.Controls.Add(this.groupBoxMaterial);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "LayerSettingDialog";
			this.Text = "LayerSettingDialog";
			this.groupBoxMaterial.ResumeLayout(false);
			this.groupBoxRenderingStyle.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxRenderingStyle)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion
		private System.Windows.Forms.Button buttonMaterial;
		private System.Windows.Forms.Label labelMaterialValue;
		private System.Windows.Forms.GroupBox groupBoxMaterial;
		private System.Windows.Forms.GroupBox groupBoxRenderingStyle;
		private System.Windows.Forms.PictureBox pictureBoxRenderingStyle;
		private System.Windows.Forms.Button buttonBorderColor;
		private System.Windows.Forms.Button buttonFillStyle;
		private System.Windows.Forms.Button buttonFillColor;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textBoxLayerName;
		}
	}