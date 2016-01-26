namespace Hslab.WaveguideDesigner.Forms
	{
	partial class PropertyEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyEditor));
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonRaise = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonLower = new System.Windows.Forms.ToolStripButton();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.dataGridView);
			this.splitContainer.Panel1.Controls.Add(this.toolStrip);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.labelDescription);
			this.splitContainer.Panel2.Controls.Add(this.labelName);
			this.splitContainer.Size = new System.Drawing.Size(224, 561);
			this.splitContainer.SplitterDistance = 450;
			this.splitContainer.TabIndex = 1;
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.AllowUserToResizeRows = false;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.EnableHeadersVisualStyles = false;
			this.dataGridView.Location = new System.Drawing.Point(0, 25);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.RowTemplate.Height = 21;
			this.dataGridView.Size = new System.Drawing.Size(224, 425);
			this.dataGridView.TabIndex = 2;
			this.dataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValidated);
			this.dataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView_CellValidating);
			this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonRemove,
            this.toolStripButtonRaise,
            this.toolStripButtonLower});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(224, 25);
			this.toolStrip.TabIndex = 1;
			// 
			// toolStripButtonAdd
			// 
			this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdd.Image")));
			this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonAdd.Name = "toolStripButtonAdd";
			this.toolStripButtonAdd.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonAdd.Text = "+";
			this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
			// 
			// toolStripButtonRemove
			// 
			this.toolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemove.Image")));
			this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonRemove.Name = "toolStripButtonRemove";
			this.toolStripButtonRemove.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonRemove.Text = "-";
			this.toolStripButtonRemove.Click += new System.EventHandler(this.toolStripButtonRemove_Click);
			// 
			// toolStripButtonRaise
			// 
			this.toolStripButtonRaise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonRaise.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRaise.Image")));
			this.toolStripButtonRaise.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonRaise.Name = "toolStripButtonRaise";
			this.toolStripButtonRaise.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonRaise.Text = "🔺";
			this.toolStripButtonRaise.Click += new System.EventHandler(this.toolStripButtonRaise_Click);
			// 
			// toolStripButtonLower
			// 
			this.toolStripButtonLower.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonLower.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLower.Image")));
			this.toolStripButtonLower.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonLower.Name = "toolStripButtonLower";
			this.toolStripButtonLower.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonLower.Text = "🔻";
			this.toolStripButtonLower.Click += new System.EventHandler(this.toolStripButtonLower_Click);
			// 
			// labelDescription
			// 
			this.labelDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelDescription.Location = new System.Drawing.Point(0, 12);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(224, 95);
			this.labelDescription.TabIndex = 1;
			this.labelDescription.Text = "description";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelName.Location = new System.Drawing.Point(0, 0);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(38, 12);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Name";
			// 
			// PropertyEditor
			// 
			this.ClientSize = new System.Drawing.Size(224, 561);
			this.Controls.Add(this.splitContainer);
			this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Name = "PropertyEditor";
			this.Text = "Property Editor";
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
		private System.Windows.Forms.ToolStripButton toolStripButtonRemove;
		private System.Windows.Forms.ToolStripButton toolStripButtonRaise;
		private System.Windows.Forms.ToolStripButton toolStripButtonLower;
		private System.Windows.Forms.DataGridView dataGridView;
		}
	}
