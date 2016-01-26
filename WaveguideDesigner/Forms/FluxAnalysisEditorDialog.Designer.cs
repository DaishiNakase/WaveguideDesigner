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
			this.SuspendLayout();
			// 
			// comboBoxFluxDirection
			// 
			this.comboBoxFluxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFluxDirection.FormattingEnabled = true;
			this.comboBoxFluxDirection.Location = new System.Drawing.Point(108, 15);
			this.comboBoxFluxDirection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.comboBoxFluxDirection.Name = "comboBoxFluxDirection";
			this.comboBoxFluxDirection.Size = new System.Drawing.Size(138, 23);
			this.comboBoxFluxDirection.TabIndex = 0;
			// 
			// labelFluxDirection
			// 
			this.labelFluxDirection.AutoSize = true;
			this.labelFluxDirection.Location = new System.Drawing.Point(14, 19);
			this.labelFluxDirection.Name = "labelFluxDirection";
			this.labelFluxDirection.Size = new System.Drawing.Size(82, 15);
			this.labelFluxDirection.TabIndex = 1;
			this.labelFluxDirection.Text = "flux direction";
			// 
			// vectorEditorLocation
			// 
			this.vectorEditorCenter.DoesCancelInvalid = true;
			this.vectorEditorCenter.Location = new System.Drawing.Point(108, 48);
			this.vectorEditorCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.vectorEditorCenter.Name = "vectorEditorLocation";
			this.vectorEditorCenter.Size = new System.Drawing.Size(138, 23);
			this.vectorEditorCenter.TabIndex = 2;
			this.vectorEditorCenter.Text = "(0, 0, 0)";
			this.vectorEditorCenter.Value = ((Hslab.Vector3)(resources.GetObject("vectorEditorLocation.Value")));
			// 
			// labelCenter
			// 
			this.labelCenter.AutoSize = true;
			this.labelCenter.Location = new System.Drawing.Point(14, 51);
			this.labelCenter.Name = "labelCenter";
			this.labelCenter.Size = new System.Drawing.Size(44, 15);
			this.labelCenter.TabIndex = 3;
			this.labelCenter.Text = "center";
			// 
			// vectorEditorSize
			// 
			this.vectorEditorSize.DoesCancelInvalid = true;
			this.vectorEditorSize.Location = new System.Drawing.Point(108, 79);
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
			this.labelSize.Location = new System.Drawing.Point(14, 82);
			this.labelSize.Name = "labelSize";
			this.labelSize.Size = new System.Drawing.Size(29, 15);
			this.labelSize.TabIndex = 5;
			this.labelSize.Text = "size";
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(30, 110);
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
			this.buttonCancel.Location = new System.Drawing.Point(143, 110);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(87, 29);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// FluxAnalysisEditorDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(261, 151);
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
		}
	}