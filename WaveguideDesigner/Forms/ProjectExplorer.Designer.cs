namespace Hslab.WaveguideDesigner.Forms
	{
	partial class ProjectExplorer
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
			this.treeView = new System.Windows.Forms.TreeView();
			this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);
			this.contextMenuStripProjectManifest = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.configManifestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStripLayerProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.configLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStripProjectManifest.SuspendLayout();
			this.contextMenuStripLayerProfile.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeView
			// 
			this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
			this.treeView.HideSelection = false;
			this.treeView.ImageIndex = 0;
			this.treeView.ImageList = this.imageListTreeView;
			this.treeView.Location = new System.Drawing.Point(0, 0);
			this.treeView.Name = "treeView";
			this.treeView.SelectedImageIndex = 0;
			this.treeView.Size = new System.Drawing.Size(224, 561);
			this.treeView.TabIndex = 0;
			this.treeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView_DrawNode);
			this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
			this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
			this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseDoubleClick);
			// 
			// imageListTreeView
			// 
			this.imageListTreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageListTreeView.ImageSize = new System.Drawing.Size(16, 16);
			this.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// contextMenuStripProjectManifest
			// 
			this.contextMenuStripProjectManifest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configManifestToolStripMenuItem});
			this.contextMenuStripProjectManifest.Name = "contextMenuStripProjectManifest";
			this.contextMenuStripProjectManifest.Size = new System.Drawing.Size(178, 26);
			// 
			// configManifestToolStripMenuItem
			// 
			this.configManifestToolStripMenuItem.Name = "configManifestToolStripMenuItem";
			this.configManifestToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.configManifestToolStripMenuItem.Text = "シミュレーションの設定";
			this.configManifestToolStripMenuItem.Click += new System.EventHandler(this.configManifestToolStripMenuItem_Click);
			// 
			// contextMenuStripLayerProfile
			// 
			this.contextMenuStripLayerProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configLayerToolStripMenuItem});
			this.contextMenuStripLayerProfile.Name = "contextMenuStripLayerProfile";
			this.contextMenuStripLayerProfile.Size = new System.Drawing.Size(137, 26);
			// 
			// configLayerToolStripMenuItem
			// 
			this.configLayerToolStripMenuItem.Name = "configLayerToolStripMenuItem";
			this.configLayerToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.configLayerToolStripMenuItem.Text = "レイヤの設定";
			this.configLayerToolStripMenuItem.Click += new System.EventHandler(this.configLayerToolStripMenuItem_Click);
			// 
			// ProjectExplorer
			// 
			this.ClientSize = new System.Drawing.Size(224, 561);
			this.Controls.Add(this.treeView);
			this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Name = "ProjectExplorer";
			this.Text = "Project Explorer";
			this.contextMenuStripProjectManifest.ResumeLayout(false);
			this.contextMenuStripLayerProfile.ResumeLayout(false);
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.ImageList imageListTreeView;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripProjectManifest;
		private System.Windows.Forms.ToolStripMenuItem configManifestToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripLayerProfile;
		private System.Windows.Forms.ToolStripMenuItem configLayerToolStripMenuItem;
		}
	}
