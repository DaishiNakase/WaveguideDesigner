using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Hslab.WaveguideDesigner.Forms
	{
	/// <summary>アプリケーションメインフォーム。</summary>
	public partial class MainForm : FormBase
		{
		/// <summary>クラス名。</summary>
		public override string ClassName { get { return "Forms.MainForm"; } }



		Dictionary<byte, DockContentBase> ChildWindows { get; set; }

		public ProjectExplorer ProjectExplorer
			{
			get { return ChildWindows[0] as ProjectExplorer; }
			private set { ChildWindows[0] = value; }
			}
		public StructureViewer StructureViewer
			{
			get { return ChildWindows[1] as StructureViewer; }
			private set { ChildWindows[1] = value; }
			}
		public PropertyEditor PropertyEditor
			{
			get { return ChildWindows[2] as PropertyEditor; }
			private set { ChildWindows[2] = value; }
			}

		/// <summary>コンストラクタ。</summary>
		public MainForm()
			{
			InitializeComponent();

			ChildWindows = new Dictionary<byte, DockContentBase>();

			RefreshLanguage();
			}



		public override void RefreshLanguage()
			{
			Text = Language.MainForm.Text;
			fileToolStripMenuItem.Text = Language.MainForm.TSMI_File;
			createProjectToolStripMenuItem.Text = Language.MainForm.TSMI_CreateProject;
			openProjectToolStripMenuItem.Text = Language.MainForm.TSMI_OpenProject;
			saveProjectToolStripMenuItem.Text = Language.MainForm.TSMI_SaveProject;
			saveProjectWithNewNameToolStripMenuItem.Text = Language.MainForm.TSMI_SaveProjectWithNewName;
			closeProjectToolStripMenuItem.Text = Language.MainForm.TSMI_CloseProject;
			quitToolStripMenuItem.Text = Language.MainForm.TSMI_Quit;
			editToolStripMenuItem.Text = Language.MainForm.TSMI_Edit;
			undoToolStripMenuItem.Text = Language.StandardFunction.Undo;
			redoToolStripMenuItem.Text = Language.StandardFunction.Redo;
			urListToolStripMenuItem.Text = Language.StandardFunction.URList;
			cutToolStripMenuItem.Text = Language.StandardFunction.Cut;
			copyToolStripMenuItem.Text = Language.StandardFunction.Copy;
			pasteToolStripMenuItem.Text = Language.StandardFunction.Paste;
			deleteToolStripMenuItem.Text = Language.StandardFunction.Delete;
			viewToolStripMenuItem.Text = Language.MainForm.TSMI_View;
			cadToolStripMenuItem.Text = Language.MainForm.TSMI_Cad;
			analysisAToolStripMenuItem.Text = Language.MainForm.TSMI_Analysis;
			toolsToolStripMenuItem.Text = Language.MainForm.TSMI_Tools;
			helpToolStripMenuItem.Text = Language.MainForm.TSMI_Help;

			foreach( DockContentBase content in ChildWindows.Values )
				content.RefreshLanguage();
			}



		public override void RefreshRender()
			{
			foreach( DockContentBase content in ChildWindows.Values )
				content.RefreshRender();
			//throw new NotImplementedException();
			}





		// フォームロードイベント。起動時にコンストラクタの次に実行される
		private void MainForm_Load(object sender, EventArgs e)
			{
			Application.CurrentUndoDepthChanged += Application_CurrentUndoDepthChanged;
			Application.ProjectValidated += (_sender, _e) => { RefreshRender(); };

			ProjectExplorer = new Forms.ProjectExplorer( this );
			ProjectExplorer.Show( dockPanel, DockState.DockLeft );
			ProjectExplorer.IsHiddenChanged += ProjectExplorer_IsHiddenChanged;

			StructureViewer = new Forms.StructureViewer( this );
			StructureViewer.Show( dockPanel, DockState.Document );
			StructureViewer.IsHiddenChanged += StructureViewer_IsHiddenChanged;

			PropertyEditor = new Forms.PropertyEditor( this );
			PropertyEditor.Show( dockPanel, DockState.DockRight );
			PropertyEditor.IsHiddenChanged += PropertyEditor_IsHiddenChanged;

			Application.OpenedProject = Application.OpenedProject;
			StructureViewer.MoveViewToPerspective();
			RefreshRender();
			}




		// Undo/Redoの深さが変更されたとき、Editツールストリップドロップダウン以下のundo/redoのEnabledを設定する。
		void Application_CurrentUndoDepthChanged(object sender, EventArgs e)
			{
			undoToolStripMenuItem.Enabled = Application.CurrentUndoDepth != Application.UndoRedoCount;
			redoToolStripMenuItem.Enabled = Application.CurrentUndoDepth != 0;
			}



		// フォームクロージングイベント。必要ななDispose処理を行う
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
			{
			//foreach( DockContentBase content in dockPanel.Contents )
			//	content.Dispose();
			}



		#region TSMI-File

		private void createProjectToolStripMenuItem_Click(object sender, EventArgs e)
			{ Application.CreateProject(); }

		private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
			{ Application.OpenProject(); }

		private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
			{ Application.SaveProject(); }

		private void saveProjectWithNewNameToolStripMenuItem_Click(object sender, EventArgs e)
			{
			Application.SaveProject( null );
			}

		private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
			{ Application.CloseProject(); }

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
			{ Application.Quit(); }

		#endregion



		#region TSMI-Edit

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
			{ Application.Undo(); }

		private void redoToolStripMenuItem_Click(object sender, EventArgs e)
			{ Application.Redo(); }

		private void urListToolStripMenuItem_Click(object sender, EventArgs e)
			{ Application.ShowUndoRedoList(); }

		private void cutToolStripMenuItem_Click(object sender, EventArgs e)
			{ Application.Cut(); }

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
			{ Application.Copy(); }

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
			{ Application.Paste(); }

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
			{ Application.Delete(); }

		#endregion



		#region TSMI-View

		private void projectExplorerToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
			{
			if( ProjectExplorer.IsHidden == projectExplorerToolStripMenuItem.Checked )
				ProjectExplorer.IsHidden = !projectExplorerToolStripMenuItem.Checked;
			}
		void ProjectExplorer_IsHiddenChanged(object sender, EventArgs e)
			{
			if( projectExplorerToolStripMenuItem.Checked == ProjectExplorer.IsHidden )
				projectExplorerToolStripMenuItem.Checked = !ProjectExplorer.IsHidden;
			}



		private void structureViewerToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
			{
			if( StructureViewer.IsHidden == structureViewerToolStripMenuItem.Checked )
				StructureViewer.IsHidden = !structureViewerToolStripMenuItem.Checked;
			}
		void StructureViewer_IsHiddenChanged(object sender, EventArgs e)
			{
			if( structureViewerToolStripMenuItem.Checked != StructureViewer.IsHidden )
				structureViewerToolStripMenuItem.Checked = !StructureViewer.IsHidden;
			}



		private void propertyEditorToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
			{
			if( PropertyEditor.IsHidden == propertyEditorToolStripMenuItem.Checked )
				PropertyEditor.IsHidden = !propertyEditorToolStripMenuItem.Checked;
			}
		void PropertyEditor_IsHiddenChanged(object sender, EventArgs e)
			{
			if( propertyEditorToolStripMenuItem.Checked == PropertyEditor.IsHidden )
				propertyEditorToolStripMenuItem.Checked = !PropertyEditor.IsHidden;
			}


		#endregion



		#region TSMI-CAD
		
		private void outputDxfFileToolStripMenuItem_Click(object sender, EventArgs e)
			{
			Application.OutputDxf("");
			}

		#endregion



		#region TSMI-Analysis

		private async void outputctlFileToolStripMenuItem_Click(object sender, EventArgs e)
			{
			Application.OutputCtlFile();
			}




		#endregion



		#region TSMI-Tools

		private void materialEditorToolStripMenuItem_Click(object sender, EventArgs e)
			{
			Application.ShowMaterialEditorDialog( this );
			}

		#endregion

		}
	}
