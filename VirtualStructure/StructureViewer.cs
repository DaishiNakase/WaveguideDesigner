using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hslab;

namespace Hslab.VirtualStructure
	{
	/// <summary><para>バーチャルグラフィクスを表示するビューア。</para>
	/// <para>[機能]</para>
	/// </summary>
	public partial class StructureViewer : UserControl
		{
		#region 中央ボタンドラッグによるビュー移動をサポートするためのWndProcメッセージ
		private const int WM_MBUTTONDOWN = 0x0207;
		private const int WM_MBUTTONUP = 0x0208;
		private const int WM_NCMBUTTONUP = 0x00a7;
		private const int WM_MOUSEMOVE = 0x0200;
		private const int WM_NCMOUSEMOVE = 0x00a0;
		#endregion


		#region Private Member vals

		// 中央ボタンドラッグによるビュー移動が行われているかどうかを判定
		// WndProc中でのみ使用する
		bool ViewTargetMoving = false;

		// 中央ボタンドラッグによるビュー移動について、前回のマウス座標(スクリーン座標)
		// 差分取得用
		Point ViewTargetBeforeLocation;

		// ビュー座標移動時に移動前をストアする点。
		PointD TempStoreViewOffset;

		#endregion



		/// <summary>バーチャルグラフィクス。</summary>
		public VirtualGraphics VirtualGraphics
			{
			get
				{
				if( _VirtualGraphics == null )
					{
					VirtualGraphics = new VirtualGraphics();
					VirtualGraphics.Background = Color.Black;
					VirtualGraphics.AxesLine = Pens.White;
					VirtualGraphics.ViewScale = new SizeD( 1, -1 );
					}
				return _VirtualGraphics;
				}
			set { _VirtualGraphics = value; }
			}
		private VirtualGraphics _VirtualGraphics;

		/// <summary>デフォルトのコンストラクタ。</summary>
		public StructureViewer()
			{
			InitializeComponent();

			// 描画の設定
			this.DoubleBuffered = true;

			// イベントの登録
			this.Paint += StructureViewer_Paint;
			this.MouseWheel += StructureViewer_MouseWheel;
			this.MouseEnter += StructureViewer_MouseEnter;
			}




		// 画面の再描画を行う。this.Paintイベントのデリゲートメソッド
		void StructureViewer_Paint(object sender, PaintEventArgs e)
			{
			if( VirtualGraphics == null )
				{
				e.Graphics.Clear( Color.Black );
				return;
				}
			VirtualGraphics.RenderToView( e.Graphics );
			}



		// マウスがコントロール内に入った時点でフォーカスを自動取得する
		void StructureViewer_MouseEnter(object sender, EventArgs e)
			{
			this.Focus();
			}



		// マウスホイールによる拡大縮小を行う。this.MouseWheelイベントのデリゲートメソッド
		void StructureViewer_MouseWheel(object sender, MouseEventArgs e)
			{
			if( VirtualGraphics == null ) return;
			if( e.Delta != 0 )
				{
				TempStoreViewOffset = VirtualGraphics.ViewOffset;
				VirtualGraphics.MoveViewWithFixedGlobal( e.Location );
				VirtualGraphics.ViewScale *= Math.Pow( 2, Math.Sign( e.Delta ) );
				VirtualGraphics.MoveViewWithFixedGlobal( TempStoreViewOffset );
				this.ParentForm.Refresh();
				}
			}



		/// <summary>機能のうち、中央ボタンドラッグによるビュー移動のみWndProcでサポートする</summary>
		/// <param name="m"></param>
		protected override void WndProc(ref Message m)
			{
			base.WndProc( ref m );

			if( VirtualGraphics == null ) return;
			if( this.Focused )
				{
				// 移動モードでない
				if( !ViewTargetMoving )
					{
					switch( m.Msg )
						{
						case WM_MBUTTONDOWN:
							ViewTargetMoving = true;
							ViewTargetBeforeLocation = Cursor.Position;
							TempStoreViewOffset = VirtualGraphics.ViewOffset;
							this.ParentForm.Refresh();
							return;
						}
					}
				// 移動モード
				else
					{
					switch( m.Msg )
						{
						case WM_MOUSEMOVE:
						case WM_NCMOUSEMOVE:
							int diffX = Cursor.Position.X - ViewTargetBeforeLocation.X,
								diffY = Cursor.Position.Y - ViewTargetBeforeLocation.Y;
							VirtualGraphics.ViewOffset += new SizeD( diffX, diffY );
							ViewTargetBeforeLocation = Cursor.Position;
							this.ParentForm.Refresh();
							return;
						case WM_MBUTTONUP:
						case WM_NCMBUTTONUP:
							ViewTargetMoving = false;
							VirtualGraphics.MoveViewWithFixedGlobal( TempStoreViewOffset );
							this.ParentForm.Refresh();
							return;
						}
					}
				}
			}



		/// <summary>全体像を表示するようビュー座標を変更する。</summary>
		/// <param name="padding"></param>
		public void MoveViewToPerspective(SizeD padding)
			{
			if( VirtualGraphics == null ) return;
			VirtualGraphics.MoveViewToPerspective( this.CreateGraphics(), padding );
			}



		/// <summary>現在のマウスカーソルが存在するバーチャルグラフィクスの座標を取得する。</summary>
		/// <returns></returns>
		public PointD GetMouseLocationInVirtualGraphics()
			{
			Point location = this.PointToClient( System.Windows.Forms.Cursor.Position );
			return VirtualGraphics.FromViewToGlobal( location );
			}
		}
	}
