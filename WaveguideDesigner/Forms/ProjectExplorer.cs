using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hslab.WaveguideDesigner.ProjectData;

namespace Hslab.WaveguideDesigner.Forms
	{
	/// <summary>プロジェクトエクスプローラ。</summary>
	public partial class ProjectExplorer : DockContentBase
		{
		/// <summary>クラス名。</summary>
		public override string ClassName { get { return "Forms.ProjectExplorer"; } }



		public TreeNode NodeProject { get; set; }
		public TreeNode NodeProjectManifest { get; set; }
		public TreeNode NodeGlobalRenderSetting { get; set; }
		public TreeNode NodeGlobalNumerics { get; set; }
		public TreeNode NodeParameters { get; set; }
		public TreeNode NodeFunctions { get; set; }
		public TreeNode NodeLayers { get; set; }



		/// <summary></summary>
		public ProjectExplorer() : this( null ) { }


		/// <summary></summary>
		public ProjectExplorer(FormBase parent)
			: base( parent )
			{
			InitializeComponent();

			imageListTreeView.Images.Add( Properties.Resources.node_proj );
			imageListTreeView.Images.Add( Properties.Resources.node_mani );
			imageListTreeView.Images.Add( Properties.Resources.node_render );
			imageListTreeView.Images.Add( Properties.Resources.node_num );
			imageListTreeView.Images.Add( Properties.Resources.node_para );
			imageListTreeView.Images.Add( Properties.Resources.node_func );
			imageListTreeView.Images.Add( Properties.Resources.node_layers );
			imageListTreeView.Images.Add( Properties.Resources.node_layer );
			imageListTreeView.Images.Add( Properties.Resources.node_layerprf );
			imageListTreeView.Images.Add( Properties.Resources.node_obj );
			}







		/// <summary></summary>
		public override void RefreshLanguage()
			{
			Text = Language.ProjectExplorer.Name;
			//throw new NotImplementedException();
			}



		/// <summary></summary>
		public override void RefreshRender()
			{
			if( RefreshRender_Running ) return;
			RefreshRender_Running = true;

			treeView.Nodes.Clear();

			if( Application.OpenedProject != null )
				{
				treeView.SuspendLayout();

				NodeProject = new TreeNode();
				NodeProjectManifest = new TreeNode();
				NodeGlobalRenderSetting = new TreeNode();
				NodeGlobalNumerics = new TreeNode();
				NodeParameters = new TreeNode();
				NodeFunctions = new TreeNode();
				NodeLayers = new TreeNode();

				NodeProject.Text = Application.OpenedProject.Name;
				NodeProject.Tag = Application.OpenedProject;
				NodeProject.ImageIndex = 0;
				NodeProject.SelectedImageIndex = NodeProject.ImageIndex;
				Application.OpenedProject.TreeNode = NodeProject;
				treeView.Nodes.Add( NodeProject );

				NodeProjectManifest.Text = Language.ProjectExplorer.NodeText_ProjectManifest;
				NodeProjectManifest.Tag = Application.OpenedProject.ProjectManifest;
				NodeProjectManifest.ImageIndex = 1;
				NodeProjectManifest.SelectedImageIndex = NodeProjectManifest.ImageIndex;
				Application.OpenedProject.ProjectManifest.TreeNode = NodeProjectManifest;
				NodeProject.Nodes.Add( NodeProjectManifest );

				NodeGlobalRenderSetting.Text = Language.ProjectExplorer.NodeText_GlobalRenderSetting;
				NodeGlobalRenderSetting.Tag = Application.OpenedProject.GlobalRenderingSetting;
				NodeGlobalRenderSetting.ImageIndex = 2;
				NodeGlobalRenderSetting.SelectedImageIndex = NodeGlobalRenderSetting.ImageIndex;
				Application.OpenedProject.GlobalRenderingSetting.TreeNode = NodeGlobalRenderSetting;
				NodeProject.Nodes.Add( NodeGlobalRenderSetting );

				NodeGlobalNumerics.Text = Language.ProjectExplorer.NodeText_GlobalStructureNumerics;
				NodeGlobalNumerics.Tag = Application.OpenedProject.GlobalStructureNumerics;
				NodeGlobalNumerics.ImageIndex = 3;
				NodeGlobalNumerics.SelectedImageIndex = NodeGlobalNumerics.ImageIndex;
				Application.OpenedProject.GlobalStructureNumerics.TreeNode = NodeGlobalNumerics;
				NodeProject.Nodes.Add( NodeGlobalNumerics );

				NodeParameters.Text = Language.ProjectExplorer.NodeText_Parameters;
				NodeParameters.Tag = Application.OpenedProject.GlobalStructureNumerics.Parameters;
				NodeParameters.ImageIndex = 4;
				NodeParameters.SelectedImageIndex = NodeParameters.ImageIndex;
				Application.OpenedProject.GlobalStructureNumerics.Parameters.TreeNode = NodeParameters;
				NodeGlobalNumerics.Nodes.Add( NodeParameters );

				NodeFunctions.Text = Language.ProjectExplorer.NodeText_Functions;
				NodeFunctions.Tag = Application.OpenedProject.GlobalStructureNumerics.Functions;
				NodeFunctions.ImageIndex = 5;
				NodeFunctions.SelectedImageIndex = NodeFunctions.ImageIndex;
				Application.OpenedProject.GlobalStructureNumerics.Functions.TreeNode = NodeFunctions;
				NodeGlobalNumerics.Nodes.Add( NodeFunctions );

				NodeLayers.Text = Language.ProjectExplorer.NodeText_Layers;
				NodeLayers.Tag = Application.OpenedProject.Layers;
				NodeLayers.ImageIndex = 6;
				NodeLayers.SelectedImageIndex = NodeLayers.ImageIndex;
				Application.OpenedProject.Layers.TreeNode = NodeLayers;
				NodeProject.Nodes.Add( NodeLayers );

				UpdateLayersNode();

				treeView.SelectedNode = Application.Selection?.TreeNode ?? treeView.SelectedNode;
				treeView.ResumeLayout();
				}

			RefreshRender_Running = false;
			}



		public override void Application_OpenedProjectChanged(object sender, WaveguideDesigner.Application.OpenedProjectChangedEventArgs e)
			{
			RefreshRender();
			}



		// アプリケーションにおいて選択オブジェクトが変更されたときに実行する
		public override void Application_SelectionChanged(object sender, Application.SelectionChangedEventArgs e)
			{
			if( Application_SelectionChanged_Running ) return;
			Application_SelectionChanged_Running = true;
			treeView.SuspendLayout();

			bool flag = true;
			foreach( TreeNode node in GetAllNode() )
				if( node.Tag == Application.Selection )
					{
					treeView.SelectedNode = node;
					flag = false;
					break;
					}
			if( flag ) treeView.SelectedNode = null;

			treeView.ResumeLayout();
			Application_SelectionChanged_Running = false;
			}



		/// <summary></summary>
		public void UpdateLayersNode()
			{
			NodeLayers.Nodes.Clear();
			foreach( LayerData layer in Application.OpenedProject.Layers )
				NodeLayers.Nodes.Add( MakeLayerNode( layer ) );
			}
		private TreeNode MakeLayerNode(LayerData layer)
			{
			TreeNode nodeLayer = new TreeNode(), nodeLayerPrf = new TreeNode(), nodeObj;
			nodeLayer.Text = layer.Name;
			nodeLayer.Tag = layer;
			nodeLayer.ImageIndex = 7;
			nodeLayer.SelectedImageIndex = 7;
			layer.TreeNode = nodeLayer;

			nodeLayerPrf.Text = layer.Name + " " + Language.ProjectExplorer.NodeText_LayerProfile;
			nodeLayerPrf.Tag = layer.Profile;
			nodeLayerPrf.ImageIndex = 8;
			nodeLayerPrf.SelectedImageIndex = 8;
			layer.Profile.TreeNode = nodeLayerPrf;
			nodeLayer.Nodes.Add( nodeLayerPrf );

			foreach( GeometricObjectDataBase obj in layer.GeometricObjects )
				{
				nodeObj = new TreeNode();
				nodeObj.Text = obj.Name;
				nodeObj.Tag = obj;
				nodeObj.ImageIndex = 9;
				nodeObj.SelectedImageIndex = 9;
				obj.TreeNode = nodeObj;
				nodeLayer.Nodes.Add( nodeObj );
				}
			return nodeLayer;
			}



		// TreeViewに登録されている全てのノードを列挙する
		private List<TreeNode> GetAllNode()
			{
			List<TreeNode> list = new List<TreeNode>();
			foreach( TreeNode child in treeView.Nodes ) list.AddRange( GetAllNode( child ) );
			return list;
			}



		// あるノードに対して、そのノードと子ノード全てを列挙する
		private List<TreeNode> GetAllNode(TreeNode node)
			{
			List<TreeNode> list = new List<TreeNode>();
			list.Add( node );
			foreach( TreeNode child in node.Nodes ) list.AddRange( GetAllNode( child ) );
			return list;
			}



		// ProjectManifestSettingDialogを表示
		private void ShowProjectManifestSettingDialog()
			{
			if( Application.OpenedProject == null ) return;
			ManifestSettingDialog dialog = new ManifestSettingDialog();
			dialog.ShowDialog( Application.MainForm );
			}


		// LayerProfileSettingDialogを表示
		private void ShowLayerProfileSettingDialog()
			{
			LayerData layer = treeView.SelectedNode.Tag as LayerData
				?? ( ( treeView.SelectedNode.Tag as LayerProfileData ).Parent as LayerData );
			if( layer == null ) return;

			LayerSettingDialog dialog = new LayerSettingDialog( layer );
			if( dialog.ShowDialog( Application.MainForm ) == DialogResult.OK )
				{
				Application.ValidateProject( true );
				treeView.SelectedNode = dialog.LayerProfile.TreeNode;
				}
			}



		// ツリービュー上で選択オブジェクトが変更されたときに実行する
		private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
			{
			if( RefreshRender_Running ) return;
			if( Application_SelectionChanged_Running ) return;
			ProjectDataBase data = e.Node.Tag as ProjectDataBase;
			Application.Selection = data;
			}



		// ノードを描画する
		private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
			{
			if( e.Node.IsSelected )
				{
				e.Graphics.FillRectangle( SystemBrushes.Highlight, e.Bounds );
				e.Graphics.DrawString( e.Node.Text, treeView.Font, SystemBrushes.HighlightText, e.Bounds.X, e.Bounds.Y );
				}
			else
				e.DrawDefault = true;
			}



		// ツリーノードをクリック		
		private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
			{
			treeView.SelectedNode = e.Node;
			switch( e.Button )
				{
				// 右クリック コンテキストメニュー
				case MouseButtons.Right:
					if( e.Node.Tag is ProjectManifestData )
						contextMenuStripProjectManifest.Show( sender as Control, e.Location );
					else if( e.Node.Tag is LayerProfileData || e.Node.Tag is LayerData )
						contextMenuStripLayerProfile.Show( sender as Control, e.Location );
					break;


				}
			}



		// ツリーノードをダブルクリック
		private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
			{
			if( e.Node.Tag is ProjectManifestData )
				ShowProjectManifestSettingDialog();
			else if( e.Node.Tag is LayerProfileData || e.Node.Tag is LayerData )
				ShowLayerProfileSettingDialog();
			}



		// ツールストリップメニューアイテム"シミュレーションの設定"をクリック
		private void configManifestToolStripMenuItem_Click(object sender, EventArgs e)
			{
			ShowProjectManifestSettingDialog();
			}

		// ツールストリップメニューアイテム"レイヤの設定"をクリック
		private void configLayerToolStripMenuItem_Click(object sender, EventArgs e)
			{
			ShowLayerProfileSettingDialog();
			}



		/**/
		}
	}
