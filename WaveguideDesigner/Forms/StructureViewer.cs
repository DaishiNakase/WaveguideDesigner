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
	public partial class StructureViewer : Hslab.WaveguideDesigner.Forms.DockContentBase
		{
		/// <summary>クラス名。</summary>
		public override string ClassName { get { return "Forms.StructureViewer"; } }



		public SizeD PerspectivePadding { get; set; }



		public StructureViewer() : this( null ) { }
		public StructureViewer(FormBase parent)
			: base( parent )
			{
			InitializeComponent();
			PerspectivePadding = new SizeD( 12, 12 );
			}



		public override void RefreshLanguage()
			{
			//base.RefreshLanguage();
			}



		public override void RefreshRender()
			{
			if( RefreshRender_Running ) return;
			RefreshRender_Running = true;
			if( Application.OpenedProject == null )
				viewer.VirtualGraphics = null;
			viewer.Refresh();
			RefreshRender_Running = false;
			}



		// 新しくプロジェクトが開かれたとき、プロジェクトのバーチャルシェイプを登録する。
		public override void Application_OpenedProjectChanged(object sender, Application.OpenedProjectChangedEventArgs e)
			{
			if( Application_OpenedProjectChanged_Running ) return;
			Application_OpenedProjectChanged_Running = true;

			if( e.NewItem != null )
				{
				Application.ValidateProject( Application.DoesUpdateShapeAuto );
				viewer.VirtualGraphics = Application.VirtualGraphics;
				viewer.VirtualGraphics.Mirroring = new SizeD( 1, -1 );
				viewer.VirtualGraphics.AxesLine = Pens.White;
				viewer.MoveViewToPerspective( PerspectivePadding );
				}
			else
				viewer.VirtualGraphics = null;

			Application_OpenedProjectChanged_Running = false;
			}


		// アプリケーションセレクションが変更されたとき、描画色の処理を行う。
		public override void Application_SelectionChanged(object sender, Application.SelectionChangedEventArgs e)
			{
			Application.ValidateGeometricObjects( false );
			RefreshRender();
			}



		// ジオメトリックオブジェクトの式にエラーが含まれているときに実行される。
		public override void Application_GeometricObjectInvalid(object sender, Application.GeometricObjectInvalidEventArgs e)
			{
			toolStripStatusLabel02.Text = e.ErrordObject.Name + " is invalid.";
			}




		// 全てのジオメトリックオブジェクトが正しいときに実行される。
		public override void Application_GeometricObjectCompleted(object sender, EventArgs e)
			{
			toolStripStatusLabel02.Text = "  ";
			}
		


		/// <summary>全体像を表示するようビュー座標を変更する。</summary>
		public void MoveViewToPerspective()
			{
			viewer.MoveViewToPerspective( PerspectivePadding );
			}




		// カーソル座標の表示
		private void viewer_MouseMove(object sender, MouseEventArgs e)
			{
			if( viewer?.VirtualGraphics == null ) return;
			PointD p = viewer.GetMouseLocationInVirtualGraphics();
			SizeD s = viewer.VirtualGraphics.ViewScale;
			int order = (int)Math.Log10( Math.Abs( s.W ) );
			string format = "##0.0";
			for( int i = 0 ; i < order ; i++ ) format += "0";
			toolStripStatusLabel01.Text = string.Format( "({0:" + format + "}, {1:" + format + "})", p.X, p.Y );
			}



		// クリックされたオブジェクトを選択
		private void viewer_MouseClick(object sender, MouseEventArgs e)
			{
			if( viewer?.VirtualGraphics == null ) return;
			PointD worldCoord = viewer.VirtualGraphics.FromViewToGlobal( e.Location );
			List<int> shapes = new List<int>( viewer.VirtualGraphics.GetContainerList( worldCoord ) );
			shapes.RemoveAll( (int t) => { return t >= Application.OpenedProject.GeometricObjects.Count; } );
			switch( e.Button )
				{
				case MouseButtons.Left:
						{
						if( shapes.Count == 0 )
							Application.Selection = null;
						else if( shapes.Count == 1 )
							Application.Selection = Application.OpenedProject.GeometricObjects[shapes[0]];
						else
							{
							for( int i = 0 ; i < shapes.Count ; i++ )
								{
								if( Application.OpenedProject.GeometricObjects[shapes[i]] == Application.Selection )
									{
									Application.Selection = Application.OpenedProject.GeometricObjects[shapes[( i + 1 ) % shapes.Count]];
									return;
									}
								}
							Application.Selection = Application.OpenedProject.GeometricObjects[shapes[0]];
							}
						}
					break;
				case MouseButtons.Right:
						{
						if( shapes.Count == 1 && Application.OpenedProject.GeometricObjects[shapes[0]] != Application.Selection )
							Application.Selection = Application.OpenedProject.GeometricObjects[shapes[0]];
						contextMenuStrip.Show( viewer, e.Location );
						}
					break;
				}
			}



		// カット
		private void cutToolStripMenuItem_Click(object sender, EventArgs e) { Application.Cut(); }



		// コピー
		private void copyToolStripMenuItem_Click(object sender, EventArgs e) { Application.Copy(); }



		// ペースト
		private void pasteToolStripMenuItem_Click(object sender, EventArgs e) { Application.Paste(); }



		// デリート
		private void deleteToolStripMenuItem_Click(object sender, EventArgs e) { Application.Delete(); }





		// 全体図にスケール
		private void scalePerspectiveToolStripButton_Click(object sender, EventArgs e)
			{
			if( viewer == null || viewer.VirtualGraphics == null ) return;
			MoveViewToPerspective();
			RefreshRender();
			}



		// 拡大
		private void scaleUpToolStripButton_Click(object sender, EventArgs e)
			{
			if( viewer == null || viewer.VirtualGraphics == null ) return;
			viewer.VirtualGraphics.ViewScale = 2 * viewer.VirtualGraphics.ViewScale;
			RefreshRender();
			}



		// 縮小
		private void scaleDownToolStripButton_Click(object sender, EventArgs e)
			{
			if( viewer == null || viewer.VirtualGraphics == null ) return;
			viewer.VirtualGraphics.ViewScale = 0.5 * viewer.VirtualGraphics.ViewScale;
			RefreshRender();
			}



		// 新規レイヤの追加
		private void newLayerToolStripButton_Click(object sender, EventArgs e)
			{
			Application.AddLayer();
			}



		// 現在レイヤの削除
		private void delLayerToolStripButton_Click(object sender, EventArgs e)
			{
			if( Application.SelectedLayer != null )
				Application.Delete( Application.SelectedLayer );
			}



		// 新規オブジェクト・直交座標関数パスの追加
		private void rectangleCoordinateFunctionalPathToolStripMenuItem_Click(object sender, EventArgs e)
			{
			Application.AddRectangleCoordinateFunctionalPathObject();
			}



		// 新規オブジェクト・極座標関数パスの追加
		private void polarCorrdinateFunctionalPathToolStripMenuItem_Click(object sender, EventArgs e)
			{
			Application.AddPolarCoordinateFunctionalPathObject();
			}



		// 新規オブジェクト・座標リストパスの追加
		private void tableDefinablePathToolStripMenuItem_Click(object sender, EventArgs e)
			{
			Application.AddCoordinateListPathObject();
			}



		// 現在オブジェクトの削除
		private void delGeometricObjectToolStripButton_Click(object sender, EventArgs e)
			{
			if( Application.Selection is GeometricObjectDataBase )
				Application.Delete();
			}



		}
	}
