using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Hslab;

namespace Hslab.VirtualStructure
	{
	/// <summary>ワールド座標系に定義されたバーチャル図形を表します。</summary>
	public abstract class VirtualShapeBase
		{
		/// <summary>このバーチャル図形を持っているバーチャルグラフィクス。</summary>
		public VirtualGraphics ParentGraphics { get { return ParentLayer.ParentGraphics; } }

		/// <summary>このバーチャル図形を持っているバーチャルレイヤー。</summary>
		public VirtualLayer ParentLayer { get; internal set; }

		/// <summary>任意に関連付けられるオブジェクト。</summary>
		public object Tag { get; set; }

		/// <summary>このバーチャル図形の塗りつぶし。nullの場合は親レイヤーのデフォルト値を返します。</summary>
		public Brush ShapeFill
			{
			get
				{
				if( _ShapeFill == null ) return ParentLayer.DefaultShapeFill;
				return _ShapeFill;
				}
			set { _ShapeFill = value; }
			}
		private Brush _ShapeFill = null;

		/// <summary>このバーチャル図形の境界線。nullの場合は親レイヤーのデフォルト値を返します。</summary>
		public Pen ShapeBorder
			{
			get
				{
				if( _ShapeBorder == null ) return ParentLayer.DefaultShapeBorder;
				return _ShapeBorder;
				}
			set { _ShapeBorder = value; }
			}
		private Pen _ShapeBorder = null;

		/// <summary>グローバル座標へのスケーリングをオフにする場合はfalse。
		/// グローバル座標へのスケーリングがオフである場合、レンダリングではビューアの状態にかかわらず絶対サイズが反映されます。</summary>
		public virtual bool DoesGlobalScale { get; set; }

		/// <summary>このオブジェクトが可視であるか。</summary>
		public bool Visible { get; set; }



		/// <summary>デフォルトコンストラクタ。</summary>
		public VirtualShapeBase()
			{
			Visible = true;
			DoesGlobalScale = true;
			}

		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public VirtualShapeBase(VirtualShapeBase previous)
			{
			Visible = previous.Visible;
			ParentLayer = null;
			Tag = previous.Tag;
			ShapeFill = previous.ShapeFill;
			ShapeBorder = previous.ShapeBorder;
			DoesGlobalScale = previous.DoesGlobalScale;
			}

		/// <summary>ビュー座標系に変換された図形をグラフィクスに描き出します。</summary>
		/// <param name="g"></param>
		public abstract void RenderToView(Graphics g);



		/// <summary>指定されたワールド座標がこのバーチャル図形に含まれているかどうかを判定します。</summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public abstract bool ContainPoint(PointD p);



		/// <summary>ワールド座標系での描画領域を取得します。</summary>
		/// <returns></returns>
		public abstract RectangleD GetDrawingRegion();



		/// <summary></summary>
		/// <returns></returns>
		public abstract override string ToString();


		/// <summary></summary>
		/// <param name="content"></param>
		/// <returns></returns>
		protected string ToString(string content)
			{
			return "[" + this.GetType().Name + ": " + content + "]";
			}
		}





	/// <summary>ワールド座標系に定義されたバーチャル長方形を表します。</summary>
	public class VirtualRectangle : VirtualShapeBase
		{
		/// <summary>長方形の始点。</summary>
		public PointD Location { get; set; }

		/// <summary>長方形のサイズ。</summary>
		public SizeD Size { get; set; }



		/// <summary>デフォルトコンストラクタ。</summary>
		public VirtualRectangle()
			{
			Location = new PointD();
			Size = new SizeD();
			}



		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public VirtualRectangle(VirtualRectangle previous)
			: base( previous )
			{
			Location = previous.Location;
			Size = previous.Size;
			}



		/// <summary>ビュー座標系に変換された長方形をグラフィクスに描き出します。(IVirtualShapeの実装)</summary>
		/// <param name="g"></param>
		public override void RenderToView(Graphics g)
			{
			PointF p = ParentGraphics.FromGlobalToView( Location );
			SizeF s = DoesGlobalScale ? ParentGraphics.ActualViewScale * Size : Size;
			if( s.Width < 0 )
				{
				p.X += s.Width;
				s.Width = -s.Width;
				}
			if( s.Height < 0 )
				{
				p.Y += s.Height;
				s.Height = -s.Height;
				}

			RectangleF r = new RectangleF( p, s );

			g.FillRectangle( ShapeFill, r );
			g.DrawRectangles( ShapeBorder, new RectangleF[] { r } );
			}



		/// <summary>指定されたワールド座標がこのバーチャル図形に含まれているかどうかを判定します。DoesGlobalScaleがfalseなら常にfalse。</summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public override bool ContainPoint(PointD p)
			{
			return DoesGlobalScale && Location.X < p.X && p.X < Location.X + Size.W && Location.Y < p.Y && p.Y < Location.Y + Size.H;
			}



		/// <summary>ワールド座標系での描画領域を取得します。(AVirtualShapeの実装)</summary>
		/// <returns></returns>
		public override RectangleD GetDrawingRegion()
			{
			return new RectangleD( Location, DoesGlobalScale ? Size : new SizeD() );
			}

		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			return ToString( "Location=" + Location.ToString( "0.00" ) + ", Size=" + Size.ToString( "0.00" ) );
			}
		}





	/// <summary>ワールド座標系に定義されたバーチャル多角形を表します。</summary>
	public class VirtualPolygon : VirtualShapeBase
		{
		/// <summary>多角形の頂点。</summary>
		public PointD[] Vertices { get; set; }

		/// <summary></summary>
		public override bool DoesGlobalScale { get { return true; } set { } }


		/// <summary>デフォルトコンストラクタ。</summary>
		public VirtualPolygon()
			{
			Vertices = null;
			}

		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public VirtualPolygon(VirtualPolygon previous)
			: base( previous )
			{
			Vertices = new PointD[previous.Vertices.Length];
			previous.Vertices.CopyTo( Vertices, 0 );
			}


		/// <summary>ビュー座標系に変換された多角形をグラフィクスに描き出します。(IVirtualShapeの実装)</summary>
		/// <param name="g"></param>
		public override void RenderToView(Graphics g)
			{
			if( Vertices == null ) return;
			PointF[] v = new PointF[Vertices.Length];
			for( int i = 0 ; i < v.Length ; i++ )
				v[i] = ParentGraphics.FromGlobalToView( Vertices[i] );

			g.FillPolygon( ShapeFill, v );
			g.DrawPolygon( ShapeBorder, v );
			}

		/// <summary>
		/// <para>指定されたワールド座標がこのバーチャル図形に含まれているかどうかを判定します。(IVirtualShapeの実装)</para>
		/// <para>アルゴリズムにはCrossNumberAlgorithmを使用します。</para>
		/// <para>参考 "http://www.nttpc.co.jp/company/r_and_d/technology/number_algorithm.html"</para>
		/// </summary>
		/// <param name="p">判定するグローバル座標。</param>
		/// <returns>内部にあるならtrue。</returns>
		public override bool ContainPoint(PointD p)
			{
			if( Vertices == null ) return false;
			int CNA = 0;
			for( int i = 0 ; i < Vertices.Length - 1 ; i++ )
				{
				if( ( ( Vertices[i].Y <= p.Y ) && ( Vertices[i + 1].Y > p.Y ) )
					|| ( ( Vertices[i].Y > p.Y ) && ( Vertices[i + 1].Y <= p.Y ) ) )
					{
					double vt = ( p.Y - Vertices[i].Y ) / ( Vertices[i + 1].Y - Vertices[i].Y );
					if( p.X < ( Vertices[i].X + ( vt * ( Vertices[i + 1].X - Vertices[i].X ) ) ) ) CNA++;
					}
				}
			if( Vertices[0] != Vertices[Vertices.Length - 1] )
				if( ( ( Vertices[Vertices.Length - 1].Y <= p.Y ) && ( Vertices[0].Y > p.Y ) )
					|| ( ( Vertices[Vertices.Length - 1].Y > p.Y ) && ( Vertices[0].Y <= p.Y ) ) )
					{
					double vt = ( p.Y - Vertices[Vertices.Length - 1].Y ) / ( Vertices[0].Y - Vertices[Vertices.Length - 1].Y );
					if( p.X < ( Vertices[Vertices.Length - 1].X + ( vt * ( Vertices[0].X - Vertices[Vertices.Length - 1].X ) ) ) ) CNA++;
					}

			return CNA % 2 == 1;
			}

		/// <summary>ワールド座標系での描画領域を取得します。(AVirtualShapeの実装)</summary>
		/// <returns></returns>
		public override RectangleD GetDrawingRegion()
			{
			if( Vertices == null ) return new RectangleD();
			double minX = Vertices[0].X, maxX = Vertices[0].X,
				minY = Vertices[0].Y, maxY = Vertices[0].Y;
			for( int i = 1 ; i < Vertices.Length ; i++ )
				{
				if( Vertices[i].X < minX ) minX = Vertices[i].X;
				if( maxX < Vertices[i].X ) maxX = Vertices[i].X;
				if( Vertices[i].Y < minY ) minY = Vertices[i].Y;
				if( maxY < Vertices[i].Y ) maxY = Vertices[i].Y;
				}
			return new RectangleD( new PointD( minX, minY ), new PointD( maxX, maxY ) );
			}


		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			if( Vertices == null ) return "null polygon";
			int i = 0;
			string s = "", f = "";
			for( int j = 0 ; j < Vertices.Length.ToString().Length ; j++ ) f += "0";
			for( ; i < Vertices.Length - 1 ; i++ )
				s += "v" + i.ToString( f ) + "=" + Vertices[i].ToString( "0.00" ) + ", ";

			s += "v" + i.ToString() + "=" + Vertices[i].ToString( "0.00" );
			return ToString( s );
			}
		}





	/// <summary>ワールド座標系に定義されたバーチャル楕円を表します。</summary>
	public class VirtualEllipse : VirtualShapeBase
		{
		/// <summary>このバーチャル楕円の中心を表します。</summary>
		public PointD Center { get; set; }

		/// <summary>このバーチャル楕円のX方向及びY方向の軸長を表します。</summary>
		public SizeD Radius { get; set; }


		/// <summary>デフォルトコンストラクタ。</summary>
		public VirtualEllipse()
			{
			Center = new PointD();
			Radius = new SizeD();
			}

		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public VirtualEllipse(VirtualEllipse previous)
			: base( previous )
			{
			Center = previous.Center;
			Radius = previous.Radius;
			}

		/// <summary>ビュー座標系に変換された図形をグラフィクスに描き出します。(IVirtualShapeの実装)</summary>
		/// <param name="g"></param>
		public override void RenderToView(Graphics g)
			{
			PointD c = ParentGraphics.FromGlobalToView( Center );
			SizeD s = DoesGlobalScale ? new SizeD( Math.Abs( ParentGraphics.ViewScale.W * Radius.W ), Math.Abs( ParentGraphics.ViewScale.H * Radius.H ) ) : Radius;
			PointD p = c - s;

			g.FillEllipse( ShapeFill, new RectangleF( p, 2 * s ) );
			g.DrawEllipse( ShapeBorder, new RectangleF( p, 2 * s ) );
			}

		/// <summary>指定されたワールド座標がこのバーチャル図形に含まれているかどうかを判定します。DoesGlobalScaleがfalseなら常にfalse。(IVirtualShapeの実装)</summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public override bool ContainPoint(PointD p)
			{
			return DoesGlobalScale && Math.Pow( ( p.X - Center.X ) / Radius.W, 2 ) + Math.Pow( ( p.Y - Center.Y ) / Radius.H, 2 ) < 1;
			}

		/// <summary>ワールド座標系での描画領域を取得します。(AVirtualShapeの実装)</summary>
		/// <returns></returns>
		public override RectangleD GetDrawingRegion()
			{
			return new RectangleD( Center - ( DoesGlobalScale ? Radius : new SizeD() ), Center + ( DoesGlobalScale ? Radius : new SizeD() ) );
			}


		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			return ToString( "Center=" + Center.ToString( "0.00" ) + ", Radius=" + Radius.ToString( "0.00" ) );
			}
		}





	/// <summary>ワールド座標系に定義されたバーチャル扇形を表します。</summary>
	public class VirtualPie : VirtualShapeBase
		{
		/// <summary>このバーチャル扇形の中心を表します。</summary>
		public PointD Center { get; set; }
		
		/// <summary>このバーチャル扇形のX方向及びY方向の軸長を表します。</summary>
		public SizeD Radius { get; set; }
		
		/// <summary>このバーチャル扇形の開始角を度数法で表します。(0～360)</summary>
		public double StartAngle
			{
			get { return _StartAngle; }
			set
				{
				_StartAngle = value;
				while( _StartAngle < 0 ) _StartAngle += 360;
				while( _StartAngle >= 360 ) _StartAngle -= 360;
				}
			}
		private double _StartAngle = 0;
		
		/// <summary>このバーチャル扇形の終了角を度数法で表します。(0～360)</summary>
		public double EndAngle
			{
			get
				{
				return ( StartAngle + SweepAngle ) % 360;
				}
			set
				{
				SweepAngle = value + ( value < StartAngle ? 360 : 0 ) - StartAngle;
				}
			}
		
		/// <summary>このバーチャル扇形の掃引角を度数法で表します。(0～360)</summary>
		public double SweepAngle
			{
			get { return _SweepAngle; }
			set
				{
				_SweepAngle = value;
				while( _SweepAngle < 0 ) _SweepAngle += 360;
				while( _SweepAngle >= 360 ) _SweepAngle -= 360;
				}
			}
		private double _SweepAngle = 90;
		
		/// <summary>このバーチャル扇形の開始角を弧度法で表します。(0～2π)</summary>
		public double StartAngleRad
			{
			get { return Math.PI * StartAngle / 180; }
			set { StartAngle = 180 * value / Math.PI; }
			}
		
		/// <summary>このバーチャル扇形の終了角を弧度法で表します。(0～2π)</summary>
		public double EndAngleRad
			{
			get { return Math.PI * EndAngle / 180; }
			set { EndAngle = 180 * value / Math.PI; }
			}
		
		/// <summary>このバーチャル扇形の掃引角を弧度法で表します。(0～2π)</summary>
		public double SweepAngleRad
			{
			get { return Math.PI * SweepAngle / 180; }
			set { SweepAngle = 180 * value / Math.PI; }
			}

		/// <summary></summary>
		public override bool DoesGlobalScale { get { return true; } set { } }



		/// <summary>デフォルトコンストラクタ。</summary>
		public VirtualPie()
			{
			StartAngle = 0;
			SweepAngle = 0;
			Radius = new SizeD();
			Center = new PointD();
			}


		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public VirtualPie(VirtualPie previous)
			: base( previous )
			{
			StartAngle = previous.StartAngle;
			SweepAngle = previous.SweepAngle;
			Radius = previous.Radius;
			Center = previous.Center;
			}

		/// <summary>ビュー座標系に変換された図形をグラフィクスに描き出します。(IVirtualShapeの実装)</summary>
		/// <param name="g"></param>
		public override void RenderToView(Graphics g)
			{
			PointD c = ParentGraphics.FromGlobalToView( Center );
			SizeD s = DoesGlobalScale ? new SizeD( Math.Abs( ParentGraphics.ViewScale.W * Radius.W ), Math.Abs( ParentGraphics.ViewScale.H * Radius.H ) ) : Radius;
			if( s.W == 0 || s.H == 0 ) return;

			PointD p = c - s;
			float startAngle = (float)StartAngle,
				sweepAngle = (float)SweepAngle;

			if( ParentGraphics.ViewScale.W < 0 )
				{
				startAngle = 180 - startAngle;
				sweepAngle = -sweepAngle;
				}
			if( ParentGraphics.ViewScale.H < 0 )
				{
				startAngle = -startAngle;
				sweepAngle = -sweepAngle;
				}


			g.FillPie( ShapeFill, (float)p.X, (float)p.Y, (float)( 2.0 * s.W ), (float)( 2.0 * s.H ), startAngle, sweepAngle );
			g.DrawPie( ShapeBorder, new RectangleF( p, 2 * s ), startAngle, sweepAngle );
			}



		/// <summary>指定されたワールド座標がこのバーチャル図形に含まれているかどうかを判定します。(IVirtualShapeの実装)</summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public override bool ContainPoint(PointD p)
			{
			if( Math.Pow( ( p.X - Center.X ) / Radius.W, 2 ) + Math.Pow( ( p.Y - Center.Y ) / Radius.H, 2 ) >= 1 ) return false;
			double angle = Math.Atan2( p.Y - Center.Y, p.X - Center.X );
			while( angle < 0 ) angle += 2 * Math.PI;
			return ( StartAngleRad < angle && angle < StartAngleRad + SweepAngleRad ) || ( StartAngleRad < angle + 2 * Math.PI && angle + 2 * Math.PI < StartAngleRad + SweepAngleRad );
			}



		/// <summary>ワールド座標系での描画領域を取得します。(AVirtualShapeの実装)</summary>
		/// <returns></returns>
		public override RectangleD GetDrawingRegion()
			{
			double minX, maxX, minY, maxY;

			if( StartAngle < 90 && 90 < StartAngle + SweepAngle )
				maxY = Center.Y + Radius.H;
			else
				maxY = Center.Y + Radius.H * Math.Max( 0, Math.Max( Math.Sin( StartAngleRad ), Math.Sin( EndAngleRad ) ) );

			if( StartAngle < 180 && 180 < StartAngle + SweepAngle )
				minX = Center.X - Radius.W;
			else
				minX = Center.X + Radius.W * Math.Min( 0, Math.Min( Math.Cos( StartAngleRad ), Math.Cos( EndAngleRad ) ) );

			if( StartAngle < 270 && 270 < StartAngle + SweepAngle )
				minY = Center.Y - Radius.H;
			else
				minY = Center.Y + Radius.H * Math.Min( 0, Math.Min( Math.Sin( StartAngleRad ), Math.Sin( EndAngleRad ) ) );

			if( StartAngle < 360 && 360 < StartAngle + SweepAngle )
				maxX = Center.X + Radius.W;
			else
				maxX = Center.X + Radius.W * Math.Max( 0, Math.Max( Math.Cos( StartAngleRad ), Math.Cos( EndAngleRad ) ) );

			return new RectangleD( new PointD( minX, minY ), new PointD( maxX, maxY ) );
			}





		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			return ToString( "Center=" + Center.ToString( "0.00" ) + ", StartAngle=" + StartAngle.ToString( "0.0" ) + ", SweepAngle=" + SweepAngle.ToString( "0.0" ) );
			}

		}




	/// <summary>ワールド座標系に定義されたバーチャル多角形を表します。</summary>
	public class VirtualLine : VirtualShapeBase
		{
		/// <summary>多角形の頂点。</summary>
		public PointD[] Vertices { get; set; }

		/// <summary></summary>
		public override bool DoesGlobalScale { get { return true; } set { } }



		/// <summary>デフォルトコンストラクタ。</summary>
		public VirtualLine()
			{
			Vertices = null;
			}

		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public VirtualLine(VirtualLine previous)
			: base( previous )
			{
			Vertices = new PointD[previous.Vertices.Length];
			previous.Vertices.CopyTo( Vertices, 0 );
			}


		/// <summary>ビュー座標系に変換された多角形をグラフィクスに描き出します。(IVirtualShapeの実装)</summary>
		/// <param name="g"></param>
		public override void RenderToView(Graphics g)
			{
			if( Vertices == null ) return;
			PointF[] v = new PointF[Vertices.Length];
			for( int i = 0 ; i < v.Length ; i++ )
				v[i] = ParentGraphics.FromGlobalToView( Vertices[i] );

			g.DrawLines( ShapeBorder, v );
			}



		/// <summary>
		/// <para>指定されたワールド座標がこのバーチャル図形に含まれているかどうかを判定します。(IVirtualShapeの実装)</para>
		/// <para>アルゴリズムにはCrossNumberAlgorithmを使用します。</para>
		/// <para>参考 "http://www.nttpc.co.jp/company/r_and_d/technology/number_algorithm.html"</para>
		/// </summary>
		/// <param name="p">判定するグローバル座標。</param>
		/// <returns>内部にあるならtrue。</returns>
		public override bool ContainPoint(PointD p)
			{
			if( Vertices == null ) return false;
			int CNA = 0;
			for( int i = 0 ; i < Vertices.Length - 1 ; i++ )
				{
				if( ( ( Vertices[i].Y <= p.Y ) && ( Vertices[i + 1].Y > p.Y ) )
					|| ( ( Vertices[i].Y > p.Y ) && ( Vertices[i + 1].Y <= p.Y ) ) )
					{
					double vt = ( p.Y - Vertices[i].Y ) / ( Vertices[i + 1].Y - Vertices[i].Y );
					if( p.X < ( Vertices[i].X + ( vt * ( Vertices[i + 1].X - Vertices[i].X ) ) ) ) CNA++;
					}
				}
			if( Vertices[0] != Vertices[Vertices.Length - 1] )
				if( ( ( Vertices[Vertices.Length - 1].Y <= p.Y ) && ( Vertices[0].Y > p.Y ) )
					|| ( ( Vertices[Vertices.Length - 1].Y > p.Y ) && ( Vertices[0].Y <= p.Y ) ) )
					{
					double vt = ( p.Y - Vertices[Vertices.Length - 1].Y ) / ( Vertices[0].Y - Vertices[Vertices.Length - 1].Y );
					if( p.X < ( Vertices[Vertices.Length - 1].X + ( vt * ( Vertices[0].X - Vertices[Vertices.Length - 1].X ) ) ) ) CNA++;
					}

			return CNA % 2 == 1;
			}

		/// <summary>ワールド座標系での描画領域を取得します。(AVirtualShapeの実装)</summary>
		/// <returns></returns>
		public override RectangleD GetDrawingRegion()
			{
			if( Vertices == null ) return new RectangleD();
			double minX = Vertices[0].X, maxX = Vertices[0].X,
				minY = Vertices[0].Y, maxY = Vertices[0].Y;
			for( int i = 1 ; i < Vertices.Length ; i++ )
				{
				if( Vertices[i].X < minX ) minX = Vertices[i].X;
				if( maxX < Vertices[i].X ) maxX = Vertices[i].X;
				if( Vertices[i].Y < minY ) minY = Vertices[i].Y;
				if( maxY < Vertices[i].Y ) maxY = Vertices[i].Y;
				}
			return new RectangleD( new PointD( minX, minY ), new PointD( maxX, maxY ) );
			}


		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			if( Vertices == null ) return "null polygon";
			int i = 0;
			string s = "", f = "";
			for( int j = 0 ; j < Vertices.Length.ToString().Length ; j++ ) f += "0";
			for( ; i < Vertices.Length - 1 ; i++ )
				s += "v" + i.ToString( f ) + "=" + Vertices[i].ToString( "0.00" ) + ", ";

			s += "v" + i.ToString() + "=" + Vertices[i].ToString( "0.00" );
			return ToString( s );
			}
		}






	/// <summary>ワールド座標系に定義された文字列を表します。</summary>
	public class VirtualString : VirtualShapeBase
		{
		/// <summary>描画位置。</summary>
		public PointD Location { get; set; }

		/// <summary>文字列。</summary>
		public String Text { get; set; }

		/// <summary>フォント。</summary>
		public Font Font { get; set; }

		/// <summary>フレームを描画するか否か。</summary>
		public bool DrawFrame { get; set; }

		/// <summary>フレーム描画時のパディング。</summary>
		public SizeD Padding { get; set; }

		/// <summary></summary>
		public override bool DoesGlobalScale { get { return true; } set { } }



		/// <summary>コンストラクタ。</summary>
		public VirtualString()
			{
			Font = SystemFonts.DefaultFont;
			DrawFrame = false;
			}


		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public VirtualString(VirtualString previous)
			{
			Tag = previous.Tag;
			ShapeFill = previous.ShapeFill;
			ShapeBorder = previous.ShapeBorder;
			Text = previous.Text;
			Font = previous.Font;
			DrawFrame = previous.DrawFrame;
			Padding = previous.Padding;
			}

		/// <summary>ビュー座標系に変換された図形をグラフィクスに描き出します。(IVirtualShapeの実装)</summary>
		/// <param name="g"></param>
		public override void RenderToView(Graphics g)
			{
			PointF p = ParentGraphics.FromGlobalToView( Location );
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			g.DrawString( Text, Font, ShapeFill, p );
			if( DrawFrame )
				{
				StringFormat sf = StringFormat.GenericDefault;
				sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
				SizeF s = g.MeasureString( Text, Font, p, sf );
				g.DrawRectangle( ShapeBorder, p.X - (float)Padding.W, p.Y - (float)Padding.H, s.Width, s.Height );
				}
			}

		/// <summary>指定されたワールド座標がこのバーチャル図形に含まれているかどうかを判定します。(IVirtualShapeの実装)</summary>
		/// <param name="p"></param>
		/// <returns>常にfalse。</returns>
		public override bool ContainPoint(PointD p)
			{
			return false;
			}

		/// <summary>ワールド座標系での描画領域を取得します。(AVirtualShapeの実装)</summary>
		/// <returns></returns>
		public override RectangleD GetDrawingRegion()
			{
			return new RectangleD( Location, new SizeD() );
			}




		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			return ToString( "Location=" + Location.ToString( "0.00" ) + ", Font=(" + Font.Name + "," + Font.Size.ToString() + "em), DrawFrame=" + DrawFrame.ToString() );
			}
		}

	}


/*


		{
		/// <summary>このバーチャル図形を持っているバーチャルグラフィクス。(IVirtualShapeの実装)</summary>
		public VirtualGraphics Parent { get; set; }

		/// <summary>ビュー座標系に変換された図形をグラフィクスに描き出します。(IVirtualShapeの実装)</summary>
		/// <param name="g"></param>
		public void RenderToView(Graphics g)
			{
			throw new NotImplementedException();
			}

		/// <summary>指定されたワールド座標がこのバーチャル図形に含まれているかどうかを判定します。(IVirtualShapeの実装)</summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public bool ContainPoint(PointD p)
			{
			throw new NotImplementedException();
			}
		}

*/
