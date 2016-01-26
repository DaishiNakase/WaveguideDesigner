namespace Hslab.WaveguideDesigner.Forms
	{
	partial class UndoRedoListDialog
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.listBox = new System.Windows.Forms.ListBox();
			this.groupBoxURName = new System.Windows.Forms.GroupBox();
			this.labelURDescription = new System.Windows.Forms.Label();
			this.groupBoxURName.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(376, 406);
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
			this.buttonCancel.Location = new System.Drawing.Point(457, 406);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// listBox
			// 
			this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox.FormattingEnabled = true;
			this.listBox.ItemHeight = 15;
			this.listBox.Location = new System.Drawing.Point(12, 12);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(520, 319);
			this.listBox.TabIndex = 2;
			this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
			// 
			// groupBoxURName
			// 
			this.groupBoxURName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxURName.Controls.Add(this.labelURDescription);
			this.groupBoxURName.Location = new System.Drawing.Point(13, 337);
			this.groupBoxURName.Name = "groupBoxURName";
			this.groupBoxURName.Size = new System.Drawing.Size(519, 63);
			this.groupBoxURName.TabIndex = 3;
			this.groupBoxURName.TabStop = false;
			this.groupBoxURName.Text = "----";
			// 
			// labelURDescription
			// 
			this.labelURDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelURDescription.Location = new System.Drawing.Point(3, 19);
			this.labelURDescription.Name = "labelURDescription";
			this.labelURDescription.Size = new System.Drawing.Size(513, 41);
			this.labelURDescription.TabIndex = 0;
			// 
			// UndoRedoListDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(544, 441);
			this.Controls.Add(this.groupBoxURName);
			this.Controls.Add(this.listBox);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "UndoRedoListDialog";
			this.Text = "Undo/Redo list";
			this.groupBoxURName.ResumeLayout(false);
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ListBox listBox;
		private System.Windows.Forms.GroupBox groupBoxURName;
		private System.Windows.Forms.Label labelURDescription;
		}
	}
