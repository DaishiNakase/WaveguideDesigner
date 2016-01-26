using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;

namespace Hslab.WaveguideDesigner
	{
	/// <summary>System.Drawing.ColorのXmlシリアライズ用エミュレートクラス。</summary>
	public class ColorEx
		{
		/// <summary>透過。</summary>
		public int A { get; set; }
		/// <summary>赤。</summary>
		public int R { get; set; }
		/// <summary>緑。</summary>
		public int G { get; set; }
		/// <summary>青。</summary>
		public int B { get; set; }



		/// <summary>デフォルトコンストラクタ。</summary>
		public ColorEx()
			{
			A = 255;
			R = 255;
			G = 255;
			B = 255;
			}

		/// <summary>色成分を指定するコンストラクタ。</summary>
		/// <param name="a"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		public ColorEx(int a, int r, int g, int b)
			{
			A = a;
			R = r;
			G = g;
			B = b;
			}


		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public ColorEx(ColorEx previous)
			{
			A = previous.A;
			R = previous.R;
			G = previous.G;
			B = previous.B;
			}


		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			return string.Format( "({0},{1},{2},{3})", A, R, G, B );
			}


		/// <summary>ColorEx → System.Drawing.Colorの暗黙的キャスト。</summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static implicit operator Color(ColorEx obj)
			{
			return Color.FromArgb( obj.A, obj.R, obj.G, obj.B );
			}

		/// <summary>System.Drawing.Color → ColorExの暗黙的キャスト。</summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static implicit operator ColorEx(Color obj)
			{
			return new ColorEx( obj.A, obj.R, obj.G, obj.B );
			}
		}



	/// <summary>System.Drawing.PenのXmlシリアライズ用エミュレートクラス。</summary>
	public class PenEx
		{
		/// <summary>Penの配置。</summary>
		public PenAlignment Alignment { get; set; }
		/// <summary>Penの色。</summary>
		public ColorEx Color { get; set; }
		/// <summary>破線のスタイル。</summary>
		public DashStyle DashStyle { get; set; }
		/// <summary>ペン幅。</summary>
		public float Width { get; set; }

		/// <summary>デフォルトコンストラクタ。</summary>
		public PenEx()
			{
			Pen p = new Pen( System.Drawing.Color.White );
			Alignment = p.Alignment;
			Color = p.Color;
			DashStyle = p.DashStyle;
			Width = p.Width;
			}

		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public PenEx(PenEx previous)
			{
			Alignment = previous.Alignment;
			Color = previous.Color;
			DashStyle = previous.DashStyle;
			Width = previous.Width;
			}

		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			return string.Format( "Color={0}, Width={1}", Color, Width );
			}

		/// <summary>PenEx → System.Drawing.Penの暗黙的キャスト。</summary>
		public static implicit operator Pen(PenEx p)
			{
			Pen P = new Pen( System.Drawing.Color.FromArgb( 255, 255, 255, 255 ) );
			P.Alignment = p.Alignment;
			P.Color = p.Color;
			P.DashStyle = p.DashStyle;
			P.Width = p.Width;
			return P;
			}

		/// <summary>System.Drawing.Pen → PenExの暗黙的キャスト。</summary>
		public static implicit operator PenEx(Pen p)
			{
			PenEx P = new PenEx();
			P.Alignment = p.Alignment;
			P.Color = p.Color;
			P.DashStyle = p.DashStyle;
			P.Width = p.Width;
			return P;
			}
		}



	/// <summary>System.Drawing.Draiwng2D.HatchBrushのXmlシリアライズ用エミュレートクラス。</summary>
	public class HatchBrushEx
		{
		/// <summary>背景色。</summary>
		public ColorEx BackgroundColor { get; set; }
		/// <summary>前景色。</summary>
		public ColorEx ForegroundColor { get; set; }
		/// <summary>ハッチスタイル。</summary>
		public HatchStyleEx HatchStyle { get; set; }

		/// <summary>デフォルトコンストラクタ。</summary>
		public HatchBrushEx()
			{
			BackgroundColor = Color.Transparent;
			ForegroundColor = Color.White;
			HatchStyle = HatchStyleEx.SolidDiamond;
			}

		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public HatchBrushEx(HatchBrushEx previous)
			{
			BackgroundColor = previous.BackgroundColor;
			ForegroundColor = previous.ForegroundColor;
			HatchStyle = previous.HatchStyle;
			}


		public override string ToString()
			{
			return string.Format( "Color={0}, Style={1}", ForegroundColor, HatchStyle );
			}

		/// <summary>HatchBrushEx → System.Drawing.Drawing2D.HatchBrushの暗黙的キャスト。</summary>
		public static implicit operator Brush(HatchBrushEx b)
			{
			switch( b.HatchStyle )
				{
				case HatchStyleEx.Fill:
					return new SolidBrush( b.ForegroundColor );
				case HatchStyleEx.None:
					return new SolidBrush( b.BackgroundColor );
				default:
					return new HatchBrush( (HatchStyle)b.HatchStyle, b.ForegroundColor, b.BackgroundColor );
				}
			}

		/// <summary>System.Drawing.Drawing2D.HatchBrush → HatchBrushExの暗黙的キャスト。</summary>
		public static implicit operator HatchBrushEx(Brush b)
			{
			if( b is HatchBrush )
				{
				HatchBrush _b = b as HatchBrush;
				HatchBrushEx B = new HatchBrushEx();
				B.BackgroundColor = _b.BackgroundColor;
				B.ForegroundColor = _b.ForegroundColor;
				B.HatchStyle = (HatchStyleEx)_b.HatchStyle;
				return B;
				}
			else if( b is SolidBrush )
				{
				SolidBrush _b = b as SolidBrush;
				HatchBrushEx B = new HatchBrushEx();
				B.BackgroundColor = Color.Transparent;
				B.ForegroundColor = _b.Color;
				B.HatchStyle = HatchStyleEx.Fill;
				return B;
				}
			else throw new ArgumentException( "Only HatchBrush or SolidBrush objects are allowed to be casted to HatchBrushEx." );
			}
		}



	/// <summary>次元。</summary>
	public enum Dimension
		{
		/// <summary>二次元。</summary>
		Dim2,
		/// <summary>三次元。</summary>
		Dim3,
		}


	/// <summary>電磁界成分。</summary>
	public enum FluxComponent
		{
		/// <summary>電界のX成分。</summary>
		Ex,
		/// <summary>電界のY成分。</summary>
		Ey,
		/// <summary>電界のZ成分。</summary>
		Ez,
		/// <summary>磁界のX成分。</summary>
		Hx,
		/// <summary>磁界のY成分。</summary>
		Hy,
		/// <summary>磁界のZ成分。</summary>
		Hz,
		}


	/// <summary>拡張ハッチスタイル。</summary>
	public enum HatchStyleEx
		{
		Horizontal = HatchStyle.Horizontal,
		Min = HatchStyle.Min,
		Vertical = HatchStyle.Vertical,
		ForwardDiagonal = HatchStyle.ForwardDiagonal,
		BackwardDiagonal = HatchStyle.BackwardDiagonal,
		Cross = HatchStyle.Cross,
		LargeGrid = HatchStyle.LargeGrid,
		Max = HatchStyle.Max,
		DiagonalCross = HatchStyle.DiagonalCross,
		Percent05 = HatchStyle.Percent05,
		Percent10 = HatchStyle.Percent10,
		Percent20 = HatchStyle.Percent20,
		Percent25 = HatchStyle.Percent25,
		Percent30 = HatchStyle.Percent30,
		Percent40 = HatchStyle.Percent40,
		Percent50 = HatchStyle.Percent50,
		Percent60 = HatchStyle.Percent60,
		Percent70 = HatchStyle.Percent70,
		Percent75 = HatchStyle.Percent75,
		Percent80 = HatchStyle.Percent80,
		Percent90 = HatchStyle.Percent90,
		LightDownwardDiagonal = HatchStyle.LightDownwardDiagonal,
		LightUpwardDiagonal = HatchStyle.LightUpwardDiagonal,
		DarkDownwardDiagonal = HatchStyle.DarkDownwardDiagonal,
		DarkUpwardDiagonal = HatchStyle.DarkUpwardDiagonal,
		WideDownwardDiagonal = HatchStyle.WideDownwardDiagonal,
		WideUpwardDiagonal = HatchStyle.WideUpwardDiagonal,
		LightVertical = HatchStyle.LightVertical,
		LightHorizontal = HatchStyle.LightHorizontal,
		NarrowVertical = HatchStyle.NarrowVertical,
		NarrowHorizontal = HatchStyle.NarrowHorizontal,
		DarkVertical = HatchStyle.DarkVertical,
		DarkHorizontal = HatchStyle.DarkHorizontal,
		DashedDownwardDiagonal = HatchStyle.DashedDownwardDiagonal,
		DashedUpwardDiagonal = HatchStyle.DashedUpwardDiagonal,
		DashedHorizontal = HatchStyle.DashedHorizontal,
		DashedVertical = HatchStyle.DashedVertical,
		SmallConfetti = HatchStyle.SmallConfetti,
		LargeConfetti = HatchStyle.LargeConfetti,
		ZigZag = HatchStyle.ZigZag,
		Wave = HatchStyle.Wave,
		DiagonalBrick = HatchStyle.DiagonalBrick,
		HorizontalBrick = HatchStyle.HorizontalBrick,
		Weave = HatchStyle.Weave,
		Plaid = HatchStyle.Plaid,
		Divot = HatchStyle.Divot,
		DottedGrid = HatchStyle.DottedGrid,
		DottedDiamond = HatchStyle.DottedDiamond,
		Shingle = HatchStyle.Shingle,
		Trellis = HatchStyle.Trellis,
		Sphere = HatchStyle.Sphere,
		SmallGrid = HatchStyle.SmallGrid,
		SmallCheckerBoard = HatchStyle.SmallCheckerBoard,
		LargeCheckerBoard = HatchStyle.LargeCheckerBoard,
		OutlinedDiamond = HatchStyle.OutlinedDiamond,
		SolidDiamond = HatchStyle.SolidDiamond,
		Fill = 100,
		None = 101,
		}
	}
