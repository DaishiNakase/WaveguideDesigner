using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.ObjectModel;

namespace Hslab.VirtualStructure
	{
	/// <summary>バーチャルグラフィクスを表します。</summary>
	public partial class VirtualGraphics
		{
		/// <summary>描画中心になるグローバル座標の点を表します。描画はGlobalOffsetとViewOffsetの座標が一致するように行われます。</summary>
		public PointD GlobalOffset { get; set; }
		/// <summary>描画中心になるビュー座標の点を表します。描画はGlobalOffsetとViewOffsetの座標が一致するように行われます。</summary>
		public PointD ViewOffset { get; set; }
		/// <summary>描画時の拡大率。</summary>
		public SizeD ViewScale
			{
			get { return _ViewScale; }
			set
				{
				if( value.W == 0 || value.H == 0 ) throw new ArgumentException();
				if( value.W > short.MaxValue || value.H > short.MaxValue ) return;
				_ViewScale = value;
				}
			}
		private SizeD _ViewScale = new SizeD( 1, 1 );

		/// <summary>ミラーリングを考慮した実際の描画時拡大率。</summary>
		public SizeD ActualViewScale
			{
			get { return ViewScale * Mirroring; }
			}

		/// <summary>ミラーリングを指定します。-1または1のいずれかを指定してください。</summary>
		public SizeD Mirroring
			{
			get { return _Mirroring; }
			set
				{
				if( Math.Abs( value.W ) != 1.0 || Math.Abs( value.H ) != 1.0 ) throw new ArgumentException();
				_Mirroring = value;
				}
			}
		private SizeD _Mirroring;

		/// <summary>背景色。</summary>
		public Color Background { get; set; }

		/// <summary>軸描画時のペン。nullの場合軸を描画しません。</summary>
		public Pen AxesLine { get; set; }

		/// <summary></summary>
		public VirtualLayerCollection Layers { get; private set; }

		/// <summary>図形のリスト。</summary>
		public ReadOnlyCollection<VirtualShapeBase> Shapes
			{
			get
				{
				List<VirtualShapeBase> shapes = new List<VirtualShapeBase>();
				foreach( VirtualLayer layer in Layers ) foreach( VirtualShapeBase shape in layer.Shapes ) shapes.Add( shape );
				return new ReadOnlyCollection<VirtualShapeBase>( shapes );
				}
			}



		/// <summary>コンストラクタ。</summary>
		public VirtualGraphics()
			{
			Layers = new VirtualLayerCollection( this );
			Background = Color.Black;
			AxesLine = null;
			Mirroring = new SizeD( 1, 1 );
			}


		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public VirtualGraphics(VirtualGraphics previous)
			{
			Layers = new VirtualLayerCollection( this );
			foreach( VirtualLayer layer in previous.Layers ) Layers.Add( new VirtualLayer( layer ) );
			AxesLine = (Pen)previous.AxesLine.Clone();
			Background = previous.Background;
			GlobalOffset = previous.GlobalOffset;
			ViewOffset = previous.ViewOffset;
			ViewScale = previous.ViewScale;
			Mirroring = previous.Mirroring;
			}

		/// <summary>座標変換をしたうえで指定されたグラフィクスに描画します。</summary>
		/// <param name="g"></param>
		public void RenderToView(Graphics g)
			{
			g.Clear( Background );

			g.SmoothingMode = SmoothingMode.AntiAlias;
			foreach( VirtualShapeBase shape in Shapes )
				{
				if( !shape.ParentLayer.Visible || !shape.Visible ) continue;
				shape.RenderToView( g );
				}

			if( AxesLine != null )
				{
				g.SmoothingMode = SmoothingMode.None;
				g.DrawLine( AxesLine, new Point( 0, (int)FromGlobalToView( new PointD() ).Y ), new Point( (int)g.VisibleClipBounds.Width, (int)FromGlobalToView( new PointD() ).Y ) );
				g.DrawLine( AxesLine, new Point( (int)FromGlobalToView( new PointD() ).X, 0 ), new Point( (int)FromGlobalToView( new PointD() ).X, (int)g.VisibleClipBounds.Height ) );
				}
			}



		/// <summary>ビュー座標をワールド座標に変換します。</summary>
		/// <param name="locationOnView"></param>
		/// <returns></returns>
		public PointD FromViewToGlobal(PointD locationOnView)
			{
			return GlobalOffset + new SizeD( 1.0 / ActualViewScale.W, 1.0 / ActualViewScale.H ) * ( locationOnView - ViewOffset );
			}



		/// <summary>ワールド座標をビュー座標に変換します。</summary>
		public PointD FromGlobalToView(PointD locationOnWorld)
			{
			return ViewOffset + ActualViewScale * ( locationOnWorld - GlobalOffset );
			}



		/// <summary>指定されたワールド座標を包含する図形のインデックスを取得します。</summary>
		public int[] GetContainerList(PointD worldCoord)
			{
			List<int> list = new List<int>();
			for( int i = 0 ; i < Shapes.Count ; i++ )
				if( Shapes[i].ContainPoint( worldCoord ) ) list.Add( i );

			return list.ToArray();
			}


		/// <summary>描画領域全体の矩形情報を取得します。</summary>
		/// <returns></returns>
		public RectangleD GetGraphicsRegion()
			{
			if( Shapes.Count == 0 ) return new RectangleD();

			RectangleD r;
			double minX = double.MaxValue, maxX = double.MinValue, minY = double.MaxValue, maxY = double.MinValue;
			foreach( VirtualShapeBase shape in Shapes )
				{
				r = shape.GetDrawingRegion();
				if( r.LeftTop.X < minX ) minX = r.LeftTop.X;
				if( r.LeftTop.Y < minY ) minY = r.LeftTop.Y;
				if( maxX < r.RightBottom.X ) maxX = r.RightBottom.X;
				if( maxY < r.RightBottom.Y ) maxY = r.RightBottom.Y;
				}

			return new RectangleD( new PointD( minX, minY ), new PointD( maxX, maxY ) );
			}


		/// <summary>全体像の表示をするよう、ビュー座標を変更します。</summary>
		/// <param name="g"></param>
		/// <param name="padding"></param>
		public void MoveViewToPerspective(Graphics g, SizeD padding)
			{
			RectangleD world = GetGraphicsRegion(), view = g.VisibleClipBounds;

			double scaleW = world.Size.W != 0 ? ( view.Size.W - 2 * padding.W ) / world.Size.W : 1;
			double scaleH = world.Size.H != 0 ? ( view.Size.H - 2 * padding.H ) / world.Size.H : 1;
			double scale;
			if( scaleW < scaleH )
				{
				scale = scaleW;
				this.ViewOffset = new PointD( padding.W, ( view.Size.H - scale * world.Size.H ) / 2 );
				}
			else
				{
				scale = scaleH;
				this.ViewOffset = new PointD( ( view.Size.W - scale * world.Size.W ) / 2, padding.H );
				}

			if( Mirroring.W == -1 )
				this.ViewOffset = new PointD( view.RightBottom.X - this.ViewOffset.X, this.ViewOffset.Y );
			if( Mirroring.H == -1 )
				this.ViewOffset = new PointD( this.ViewOffset.X, view.RightBottom.Y - this.ViewOffset.Y );

			this.ViewScale = new SizeD( scale, scale );
			this.GlobalOffset = world.Location;
			}




		/// <summary><para>グローバル座標とビュー座標の相対関係を保ったままビュー座標を変更します。</para>
		/// <para>このメソッドによりビュー座標を移動すると、表示が変更されないようにグローバル座標も移動されます。</para></summary>
		/// <param name="p">新しいビュー座標。</param>
		public void MoveViewWithFixedGlobal(PointD p)
			{
			GlobalOffset = FromViewToGlobal( p );
			ViewOffset = p;
			}

		/// <summary><para>グローバル座標とビュー座標の相対関係を保ったままグローバル座標を変更します。</para>
		/// <para>このメソッドによりグローバル座標を移動すると、表示が変更されないようにビュー座標も移動されます。</para></summary>
		/// <param name="p">新しいグローバル座標。</param>
		public void MoveGlobalWithFixedView(PointD p)
			{
			GlobalOffset = p;
			ViewOffset = FromGlobalToView( p );
			}




		}



	}
