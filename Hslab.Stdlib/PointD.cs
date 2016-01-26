using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Hslab;

namespace Hslab
	{
	/// <summary></summary>
	public struct PointD
		{
		/// <summary></summary>
		/// <param name="radius"></param>
		/// <param name="phase"></param>
		/// <returns></returns>
		public static PointD FromPolar (double radius,double phase)
			{
			return new PointD( radius * Math.Cos( phase ), radius * Math.Sin( phase ) );
			}


		/// <summary></summary>
		public double X		{ get { return _X; } set { _X = value; } }
		private double _X;

		/// <summary></summary>
		public double Y { get { return _Y; } set { _Y = value; } }
		private double _Y;



		/// <summary> </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public PointD(double x, double y) { _X = x; _Y = y; }



		/// <summary> </summary>
		/// <returns></returns>
		public override string ToString()
			{
			return String.Format( "({0},{1})", X, Y );
			}



		/// <summary> </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public string ToString(string format)
			{
			return "(" + X.ToString( format ) + "," + Y.ToString( format ) + ")";
			}



		/// <summary> </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
			{
			return this.X == ( (PointD)obj ).X && this.Y == ( (PointD)obj ).Y;
			}



		/// <summary> </summary>
		/// <returns></returns>
		public override int GetHashCode()
			{
			return base.GetHashCode();
			}



		/// <summary> </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public static implicit operator PointF(PointD p)
			{
			return new PointF( (float)p.X, (float)p.Y );
			}



		/// <summary> </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public static implicit operator PointD(PointF p)
			{
			return new PointD( (double)p.X, (double)p.Y );
			}



		/// <summary> </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public static implicit operator PointD(Point p)
			{
			return new PointD( p.X, p.Y );
			}



		/// <summary> </summary>
		/// <param name="p"></param>
		/// <param name="s"></param>
		/// <returns></returns>
		public static PointD operator +(PointD p, SizeD s)
			{
			return new PointD( p.X + s.W, p.Y + s.H );
			}



		/// <summary> </summary>
		/// <param name="p"></param>
		/// <param name="s"></param>
		/// <returns></returns>
		public static PointD operator -(PointD p, SizeD s)
			{
			return p + ( -1 ) * s;
			}

		
		
		/// <summary> </summary>
		/// <param name="d"></param>
		/// <param name="p"></param>
		/// <returns></returns>
		public static PointD operator *(double d, PointD p)
			{
			return new PointD( d * p.X, d * p.Y );
			}



		/// <summary> </summary>
		/// <param name="s"></param>
		/// <param name="p"></param>
		/// <returns></returns>
		public static PointD operator *(SizeD s, PointD p)
			{
			return new PointD( s.W * p.X, s.H * p.Y );
			}



		/// <summary> </summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <returns></returns>
		public static bool operator ==(PointD p1, PointD p2)
			{
			return p1.X == p2.X && p1.Y == p2.Y;
			}



		/// <summary> </summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <returns></returns>
		public static bool operator !=(PointD p1, PointD p2)
			{
			return p1.X != p2.X || p1.Y != p2.Y;
			}



		/// <summary> </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public static implicit operator SizeD(PointD p)
			{
			return new SizeD( p.X, p.Y );
			}


		/// <summary></summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <returns></returns>
		public static SizeD operator -(PointD p1, PointD p2)
			{
			return new SizeD( p1.X - p2.X, p1.Y - p2.Y );
			}

		}





	/// <summary></summary>
	public struct SizeD
		{

		/// <summary> </summary>
		public double W { get { return _W; } set { _W = value; } }
		private double _W;
		
		/// <summary> </summary>
		public double H { get { return _H; } set { _H = value; } }
		private double _H;



		/// <summary> </summary>
		/// <param name="w"></param>
		/// <param name="h"></param>
		public SizeD(double w, double h) { _W = w; _H = h; }


		/// <summary> </summary>
		public double Magnitude { get { return Math.Sqrt( W * W + H * H ); } }


		/// <summary> </summary>
		public double Angle { get { return Math.Atan2( H, W ); } }


		/// <summary> </summary>
		/// <returns></returns>
		public override string ToString()
			{
			return String.Format( "({0},{1})", W, H );
			}



		/// <summary></summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public string ToString(string format)
			{
			return "(" + W.ToString( format ) + "," + H.ToString( format ) + ")";
			}



		/// <summary></summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static implicit operator SizeF(SizeD s)
			{
			return new SizeF( (float)s.W, (float)s.H );
			}



		/// <summary></summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static implicit operator SizeD(SizeF s)
			{
			return new SizeD( (double)s.Width, (double)s.Height );
			}



		/// <summary></summary>
		/// <param name="s1"></param>
		/// <param name="s2"></param>
		/// <returns></returns>
		public static SizeD operator +(SizeD s1, SizeD s2)
			{
			return new SizeD( s1.W + s2.W, s1.H + s2.H );
			}



		/// <summary></summary>
		/// <param name="s1"></param>
		/// <param name="s2"></param>
		/// <returns></returns>
		public static SizeD operator -(SizeD s1, SizeD s2)
			{
			return s1 + ( -1.0 ) * s2;
			}



		/// <summary></summary>
		/// <param name="r"></param>
		/// <param name="s"></param>
		/// <returns></returns>
		public static SizeD operator *(double r, SizeD s)
			{
			return new SizeD( r * s.W, r * s.H );
			}



		/// <summary></summary>
		/// <param name="s"></param>
		/// <param name="r"></param>
		/// <returns></returns>
		public static SizeD operator *(SizeD s, double r)
			{
			return new SizeD( r * s.W, r * s.H );
			}



		/// <summary></summary>
		/// <param name="s1"></param>
		/// <param name="s2"></param>
		/// <returns></returns>
		public static SizeD operator *(SizeD s1, SizeD s2)
			{
			return new SizeD( s1.W * s2.W, s1.H * s2.H );
			}


		}






	/// <summary></summary>
	public struct RectangleD
		{
		/// <summary></summary>
		public PointD Location
			{
			get { return _Location; }
			set { _Location = value; }
			}
		private PointD _Location;

		/// <summary></summary>
		public SizeD Size
			{
			get { return _Size; }
			set { _Size = value; }
			}
		private SizeD _Size;

		/// <summary></summary>
		public PointD LeftTop { get { return Location; } set { Location = value; } }

		/// <summary></summary>
		public PointD RightBottom
			{
			get { return Location + Size; }
			set
				{
				Size = value - Location;
				}
			}



		/// <summary></summary>
		public RectangleD(PointD location, SizeD size)
			{
			_Location = location;
			_Size = size;
			}



		/// <summary></summary>
		public RectangleD(PointD leftTop, PointD rightBottom)
			{
			_Location = leftTop;
			_Size = rightBottom - leftTop;
			}



		/// <summary></summary>
		public static implicit operator RectangleF(RectangleD r)
			{
			return new RectangleF( r.Location, r.Size );
			}



		/// <summary></summary>
		public static implicit operator RectangleD(RectangleF r)
			{
			return new RectangleD( r.Location, r.Size );
			}

		}
	
	
	
	
	
	}
