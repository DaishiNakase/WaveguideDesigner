namespace Hslab.WaveguideDesigner.Forms
	{
	partial class StructureViewer
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
			this.components = new System.ComponentModel.Container();
			Hslab.VirtualStructure.VirtualGraphics virtualGraphics1 = new Hslab.VirtualStructure.VirtualGraphics();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.scalePerspectiveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.scaleUpToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.scaleDownToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.newLayerToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.delLayerToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.newGeometricObjectToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.rectangleCoordinateFunctionalPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.polarCorrdinateFunctionalPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableDefinablePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.delGeometricObjectToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel01 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel02 = new System.Windows.Forms.ToolStripStatusLabel();
			this.viewer = new Hslab.VirtualStructure.StructureViewer();
			this.toolStrip.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scalePerspectiveToolStripButton,
            this.scaleUpToolStripButton,
            this.scaleDownToolStripButton,
            this.toolStripSeparator1,
            this.newLayerToolStripButton,
            this.delLayerToolStripButton,
            this.toolStripSeparator2,
            this.newGeometricObjectToolStripDropDownButton,
            this.delGeometricObjectToolStripButton});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(464, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip";
			// 
			// scalePerspectiveToolStripButton
			// 
			this.scalePerspectiveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.scalePerspectiveToolStripButton.Image = global::Hslab.WaveguideDesigner.Properties.Resources.scale_pers;
			this.scalePerspectiveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.scalePerspectiveToolStripButton.Name = "scalePerspectiveToolStripButton";
			this.scalePerspectiveToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.scalePerspectiveToolStripButton.Text = "toolStripButton1";
			this.scalePerspectiveToolStripButton.ToolTipText = "scale to whole view";
			this.scalePerspectiveToolStripButton.Click += new System.EventHandler(this.scalePerspectiveToolStripButton_Click);
			// 
			// scaleUpToolStripButton
			// 
			this.scaleUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.scaleUpToolStripButton.Image = global::Hslab.WaveguideDesigner.Properties.Resources.scale_up;
			this.scaleUpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.scaleUpToolStripButton.Name = "scaleUpToolStripButton";
			this.scaleUpToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.scaleUpToolStripButton.Text = "toolStripButton1";
			this.scaleUpToolStripButton.ToolTipText = "scale up";
			this.scaleUpToolStripButton.Click += new System.EventHandler(this.scaleUpToolStripButton_Click);
			// 
			// scaleDownToolStripButton
			// 
			this.scaleDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.scaleDownToolStripButton.Image = global::Hslab.WaveguideDesigner.Properties.Resources.scale_down;
			this.scaleDownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.scaleDownToolStripButton.Name = "scaleDownToolStripButton";
			this.scaleDownToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.scaleDownToolStripButton.Text = "toolStripButton1";
			this.scaleDownToolStripButton.ToolTipText = "scale down";
			this.scaleDownToolStripButton.Click += new System.EventHandler(this.scaleDownToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// newLayerToolStripButton
			// 
			this.newLayerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newLayerToolStripButton.Image = global::Hslab.WaveguideDesigner.Properties.Resources.new_layer;
			this.newLayerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newLayerToolStripButton.Name = "newLayerToolStripButton";
			this.newLayerToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.newLayerToolStripButton.Text = "toolStripButton1";
			this.newLayerToolStripButton.ToolTipText = "create new layer";
			this.newLayerToolStripButton.Click += new System.EventHandler(this.newLayerToolStripButton_Click);
			// 
			// delLayerToolStripButton
			// 
			this.delLayerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.delLayerToolStripButton.Image = global::Hslab.WaveguideDesigner.Properties.Resources.del_layer;
			this.delLayerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.delLayerToolStripButton.Name = "delLayerToolStripButton";
			this.delLayerToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.delLayerToolStripButton.Text = "toolStripButton2";
			this.delLayerToolStripButton.ToolTipText = "delete layer";
			this.delLayerToolStripButton.Click += new System.EventHandler(this.delLayerToolStripButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// newGeometricObjectToolStripDropDownButton
			// 
			this.newGeometricObjectToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newGeometricObjectToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleCoordinateFunctionalPathToolStripMenuItem,
            this.polarCorrdinateFunctionalPathToolStripMenuItem,
            this.tableDefinablePathToolStripMenuItem});
			this.newGeometricObjectToolStripDropDownButton.Image = global::Hslab.WaveguideDesigner.Properties.Resources.new_obj;
			this.newGeometricObjectToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newGeometricObjectToolStripDropDownButton.Name = "newGeometricObjectToolStripDropDownButton";
			this.newGeometricObjectToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
			this.newGeometricObjectToolStripDropDownButton.Text = "toolStripDropDownButton1";
			this.newGeometricObjectToolStripDropDownButton.ToolTipText = "create new geometric object";
			// 
			// rectangleCoordinateFunctionalPathToolStripMenuItem
			// 
			this.rectangleCoordinateFunctionalPathToolStripMenuItem.Image = global::Hslab.WaveguideDesigner.Properties.Resources.GO_rect;
			this.rectangleCoordinateFunctionalPathToolStripMenuItem.Name = "rectangleCoordinateFunctionalPathToolStripMenuItem";
			this.rectangleCoordinateFunctionalPathToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
			this.rectangleCoordinateFunctionalPathToolStripMenuItem.Text = "Path by rectangle coordinate function";
			this.rectangleCoordinateFunctionalPathToolStripMenuItem.Click += new System.EventHandler(this.rectangleCoordinateFunctionalPathToolStripMenuItem_Click);
			// 
			// polarCorrdinateFunctionalPathToolStripMenuItem
			// 
			this.polarCorrdinateFunctionalPathToolStripMenuItem.Image = global::Hslab.WaveguideDesigner.Properties.Resources.GO_pol;
			this.polarCorrdinateFunctionalPathToolStripMenuItem.Name = "polarCorrdinateFunctionalPathToolStripMenuItem";
			this.polarCorrdinateFunctionalPathToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
			this.polarCorrdinateFunctionalPathToolStripMenuItem.Text = "Path by polar coordinate function";
			this.polarCorrdinateFunctionalPathToolStripMenuItem.Click += new System.EventHandler(this.polarCorrdinateFunctionalPathToolStripMenuItem_Click);
			// 
			// tableDefinablePathToolStripMenuItem
			// 
			this.tableDefinablePathToolStripMenuItem.Image = global::Hslab.WaveguideDesigner.Properties.Resources.GO_tbl;
			this.tableDefinablePathToolStripMenuItem.Name = "tableDefinablePathToolStripMenuItem";
			this.tableDefinablePathToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
			this.tableDefinablePathToolStripMenuItem.Text = "Path by coordinate list";
			this.tableDefinablePathToolStripMenuItem.Click += new System.EventHandler(this.tableDefinablePathToolStripMenuItem_Click);
			// 
			// delGeometricObjectToolStripButton
			// 
			this.delGeometricObjectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.delGeometricObjectToolStripButton.Image = global::Hslab.WaveguideDesigner.Properties.Resources.del_obj;
			this.delGeometricObjectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.delGeometricObjectToolStripButton.Name = "delGeometricObjectToolStripButton";
			this.delGeometricObjectToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.delGeometricObjectToolStripButton.Text = "toolStripButton1";
			this.delGeometricObjectToolStripButton.ToolTipText = "delete geometric object";
			this.delGeometricObjectToolStripButton.Click += new System.EventHandler(this.delGeometricObjectToolStripButton_Click);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(117, 92);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.cutToolStripMenuItem.Text = "Cut (&T)";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.deleteToolStripMenuItem.Text = "&Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel01,
            this.toolStripStatusLabel02});
			this.statusStrip.Location = new System.Drawing.Point(0, 299);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(464, 22);
			this.statusStrip.TabIndex = 3;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel01
			// 
			this.toolStripStatusLabel01.Name = "toolStripStatusLabel01";
			this.toolStripStatusLabel01.Size = new System.Drawing.Size(89, 17);
			this.toolStripStatusLabel01.Text = "(0.000, 0.000)";
			// 
			// toolStripStatusLabel02
			// 
			this.toolStripStatusLabel02.Name = "toolStripStatusLabel02";
			this.toolStripStatusLabel02.Size = new System.Drawing.Size(15, 17);
			this.toolStripStatusLabel02.Text = "  ";
			// 
			// viewer
			// 
			this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewer.Location = new System.Drawing.Point(0, 25);
			this.viewer.Name = "viewer";
			this.viewer.Size = new System.Drawing.Size(464, 274);
			this.viewer.TabIndex = 4;
			virtualGraphics1.AxesLine = null;
			virtualGraphics1.Background = System.Drawing.Color.Black;
			this.viewer.VirtualGraphics = virtualGraphics1;
			// 
			// StructureViewer
			// 
			this.ClientSize = new System.Drawing.Size(464, 321);
			this.Controls.Add(this.viewer);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.toolStrip);
			this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Name = "StructureViewer";
			this.Text = "Structure Viewer";
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.contextMenuStrip.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton scalePerspectiveToolStripButton;
		private System.Windows.Forms.ToolStripButton scaleUpToolStripButton;
		private System.Windows.Forms.ToolStripButton scaleDownToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton newGeometricObjectToolStripDropDownButton;
		private System.Windows.Forms.ToolStripMenuItem rectangleCoordinateFunctionalPathToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem polarCorrdinateFunctionalPathToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tableDefinablePathToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton delGeometricObjectToolStripButton;
		private System.Windows.Forms.ToolStripButton newLayerToolStripButton;
		private System.Windows.Forms.ToolStripButton delLayerToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel01;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel02;
		private VirtualStructure.StructureViewer viewer;
		}
	}
