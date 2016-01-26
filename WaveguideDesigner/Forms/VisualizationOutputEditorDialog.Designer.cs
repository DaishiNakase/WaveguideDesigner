namespace Hslab.WaveguideDesigner.Forms
	{
	partial class VisualizationOutputEditorDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizationOutputEditorDialog));
			this.comboBoxFluxComponent = new System.Windows.Forms.ComboBox();
			this.labelFluxComponent = new System.Windows.Forms.Label();
			this.labelTimeStep = new System.Windows.Forms.Label();
			this.numericUpDownTimeStep = new System.Windows.Forms.NumericUpDown();
			this.vectorEditorCenter = new Hslab.WaveguideDesigner.Forms.VectorEditor();
			this.vectorEditorSize = new Hslab.WaveguideDesigner.Forms.VectorEditor();
			this.labelCenter = new System.Windows.Forms.Label();
			this.labelSize = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeStep)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBoxFluxComponent
			// 
			this.comboBoxFluxComponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFluxComponent.FormattingEnabled = true;
			this.comboBoxFluxComponent.Location = new System.Drawing.Point(153, 15);
			this.comboBoxFluxComponent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.comboBoxFluxComponent.Name = "comboBoxFluxComponent";
			this.comboBoxFluxComponent.Size = new System.Drawing.Size(140, 23);
			this.comboBoxFluxComponent.TabIndex = 0;
			// 
			// labelFluxComponent
			// 
			this.labelFluxComponent.AutoSize = true;
			this.labelFluxComponent.Location = new System.Drawing.Point(14, 19);
			this.labelFluxComponent.Name = "labelFluxComponent";
			this.labelFluxComponent.Size = new System.Drawing.Size(97, 15);
			this.labelFluxComponent.TabIndex = 1;
			this.labelFluxComponent.Text = "flux component";
			// 
			// labelTimeStep
			// 
			this.labelTimeStep.AutoSize = true;
			this.labelTimeStep.Location = new System.Drawing.Point(14, 50);
			this.labelTimeStep.Name = "labelTimeStep";
			this.labelTimeStep.Size = new System.Drawing.Size(63, 15);
			this.labelTimeStep.TabIndex = 2;
			this.labelTimeStep.Text = "time step";
			// 
			// numericUpDownTimeStep
			// 
			this.numericUpDownTimeStep.DecimalPlaces = 3;
			this.numericUpDownTimeStep.Location = new System.Drawing.Point(154, 48);
			this.numericUpDownTimeStep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.numericUpDownTimeStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.numericUpDownTimeStep.Name = "numericUpDownTimeStep";
			this.numericUpDownTimeStep.Size = new System.Drawing.Size(140, 23);
			this.numericUpDownTimeStep.TabIndex = 3;
			this.numericUpDownTimeStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// vectorEditorCenter
			// 
			this.vectorEditorCenter.DoesCancelInvalid = true;
			this.vectorEditorCenter.Location = new System.Drawing.Point(154, 79);
			this.vectorEditorCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.vectorEditorCenter.Name = "vectorEditorCenter";
			this.vectorEditorCenter.Size = new System.Drawing.Size(139, 23);
			this.vectorEditorCenter.TabIndex = 4;
			this.vectorEditorCenter.Text = "(0, 0, 0)";
			this.vectorEditorCenter.Value = ((Hslab.Vector3)(resources.GetObject("vectorEditorCenter.Value")));
			// 
			// vectorEditorSize
			// 
			this.vectorEditorSize.DoesCancelInvalid = true;
			this.vectorEditorSize.Location = new System.Drawing.Point(154, 110);
			this.vectorEditorSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.vectorEditorSize.Name = "vectorEditorSize";
			this.vectorEditorSize.Size = new System.Drawing.Size(139, 23);
			this.vectorEditorSize.TabIndex = 5;
			this.vectorEditorSize.Text = "(0, 0, 0)";
			this.vectorEditorSize.Value = ((Hslab.Vector3)(resources.GetObject("vectorEditorSize.Value")));
			// 
			// labelCenter
			// 
			this.labelCenter.AutoSize = true;
			this.labelCenter.Location = new System.Drawing.Point(14, 82);
			this.labelCenter.Name = "labelCenter";
			this.labelCenter.Size = new System.Drawing.Size(44, 15);
			this.labelCenter.TabIndex = 6;
			this.labelCenter.Text = "center";
			// 
			// labelSize
			// 
			this.labelSize.AutoSize = true;
			this.labelSize.Location = new System.Drawing.Point(14, 114);
			this.labelSize.Name = "labelSize";
			this.labelSize.Size = new System.Drawing.Size(29, 15);
			this.labelSize.TabIndex = 7;
			this.labelSize.Text = "size";
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(50, 148);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(87, 29);
			this.buttonOK.TabIndex = 8;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(166, 148);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(87, 29);
			this.buttonCancel.TabIndex = 9;
			this.buttonCancel.Text = "cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// VisualizationOutputEditorDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(308, 191);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.labelSize);
			this.Controls.Add(this.labelCenter);
			this.Controls.Add(this.vectorEditorSize);
			this.Controls.Add(this.vectorEditorCenter);
			this.Controls.Add(this.numericUpDownTimeStep);
			this.Controls.Add(this.labelTimeStep);
			this.Controls.Add(this.labelFluxComponent);
			this.Controls.Add(this.comboBoxFluxComponent);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "VisualizationOutputEditorDialog";
			this.Text = "VisualizationOutputEditorDialog";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeStep)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxFluxComponent;
		private System.Windows.Forms.Label labelFluxComponent;
		private System.Windows.Forms.Label labelTimeStep;
		private System.Windows.Forms.NumericUpDown numericUpDownTimeStep;
		private VectorEditor vectorEditorCenter;
		private VectorEditor vectorEditorSize;
		private System.Windows.Forms.Label labelCenter;
		private System.Windows.Forms.Label labelSize;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		}
	}