using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

namespace Hslab
	{
	/// <summary>3次元のベクトル。<br />
	/// [note]Vector3の等価性はAccuracyにより近似される。
	/// 2つのベクトルの差のAmplitudeがAccuracy以下ならば、その2つのベクトルは等価であるとみなされる。
	/// </summary>
	[Serializable, TypeConverter( typeof( ExpandableObjectConverter ) )]
	public struct Vector3 : IEquatable<Vector3>, IFormattable
		{
		/// <summary>計算精度。差がこれ以下である場合は==がtrueであるとみなす。</summary>
		public static double Accuracy
			{
			get { return _Accuracy; }
			set
				{
				if( value < 0 ) throw new ArgumentException();
				_Accuracy = value;
				}
			}
		private static double _Accuracy = 0;

		/// <summary></summary>
		public static readonly Vector3 AxisX = new Vector3( 1, 0, 0 );

		/// <summary></summary>
		public static readonly Vector3 AxisY = new Vector3( 0, 1, 0 );

		/// <summary></summary>
		public static readonly Vector3 AxisZ = new Vector3( 0, 0, 1 );

		/// <summary></summary>
		public static readonly Vector3 Zero = new Vector3();

		/// <summary>X成分。</summary>
		public double X { get { return _X; } set { _X = value; } }
		private double _X;
		/// <summary>Y成分。</summary>
		public double Y { get { return _Y; } set { _Y = value; } }
		private double _Y;
		/// <summary>Z成分。</summary>
		public double Z { get { return _Z; } set { _Z = value; } }
		private double _Z;


		/// <summary>
		/// X,Y,Z成分をそれぞれ指定するコンストラクタ。
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		public Vector3(double x, double y, double z)
			{
			_X = x;
			_Y = y;
			_Z = z;
			}



		#region override methods

		/// <summary></summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Equals(Vector3 other)
			{
			return Equals( this, (Vector3)other );
			}



		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			return String.Format( "({0}, {1}, {2})", X, Y, Z );
			}



		/// <summary></summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public string ToString(string format)
			{
			return String.Format( "({0}, {1}, {2})",
				X.ToString( format ),
				Y.ToString( format ),
				Z.ToString( format ) );
			}



		/// <summary></summary>
		/// <param name="formatProvider"></param>
		/// <returns></returns>
		public string ToString(IFormatProvider formatProvider)
			{
			return String.Format( "({0}, {1}, {2})",
				X.ToString( formatProvider ),
				Y.ToString( formatProvider ),
				Z.ToString( formatProvider ) );
			}



		/// <summary></summary>
		/// <param name="format"></param>
		/// <param name="formatProvider"></param>
		/// <returns></returns>
		public string ToString(string format, IFormatProvider formatProvider)
			{
			return String.Format( "({0}, {1}, {2})",
				X.ToString( format, formatProvider ),
				Y.ToString( format, formatProvider ),
				Z.ToString( format, formatProvider ) );
			}



		/// <summary></summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
			{
			if( !( obj is Vector3 ) ) return false;
			return Equals( this, (Vector3)obj );
			}



		/// <summary></summary>
		/// <returns></returns>
		public override int GetHashCode()
			{
			return X.GetHashCode() & Y.GetHashCode() & Z.GetHashCode();
			}

		
		#endregion



		#region static methods

		/// <summary>3次元ベクトルの文字列形式を、それと等価なVector3オブジェクトに変換します。</summary>
		/// <param name="s">変換するベクトルを格納する文字列</param>
		/// <returns>sに格納されているベクトルと等しいVector3オブジェクト。</returns>
		public static Vector3 Parse(string s)
			{
			Vector3 result;
			if( TryParse( s, out result ) ) return result;
			else throw new FormatException();
			}

		/// <summary>3次元ベクトルの文字列形式を、それと等価なVector3オブジェクトに変換します。戻り値は、変換が成功したかどうかを示します。</summary>
		/// <param name="s">変換する数値を格納する文字列。</param>
		/// <param name="result">
		///		変換が成功した場合、このメソッドが返されるときに、sに格納されているベクトルと等しいVector3オブジェクトを格納します。
		///		変換に失敗した場合はVector.Zeroを格納します。
		///	</param>
		/// <returns></returns>
		public static bool TryParse(string s, out Vector3 result)
			{
			string number = @"(?:[+-]?\d+)|(?:[+-]?\d*\.\d+)";
			Regex regex = new Regex( @"\s*\(\s*(" + number + @")\s*,\s*(" + number + @")\s*,\s*(" + number + @")\s*\)\s*" );
			Match match = regex.Match( s );

			double x, y, z;
			if( match.Success
				&& double.TryParse( match.Groups[1].Value, out x )
				&& double.TryParse( match.Groups[2].Value, out y )
				&& double.TryParse( match.Groups[3].Value, out z ) )
				{
				result = new Vector3( x, y, z );
				return true;
				}
			else
				{
				result = Vector3.Zero;
				return false;
				}
			}


		#endregion



		#region operator properties

		/// <summary></summary>
		[Browsable( false ), EditorBrowsable( EditorBrowsableState.Never )]
		public double Amplitude { get { return GetAmplitude( this ); } }

		/// <summary></summary>
		[Browsable( false ), EditorBrowsable( EditorBrowsableState.Never )]
		public Vector3 Norm { get { return GetNorm( this ); } }

		#endregion



		#region static operators

		/// <summary></summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public static Vector3 Positive(Vector3 v)
			{
			return v;
			}

		/// <summary></summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public static Vector3 Negative(Vector3 v)
			{
			return new Vector3( -v.X, -v.Y, -v.Z );
			}

		/// <summary></summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static Vector3 Add(Vector3 v1, Vector3 v2)
			{
			return new Vector3( v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z );
			}

		/// <summary></summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static Vector3 Sub(Vector3 v1, Vector3 v2)
			{
			return new Vector3( v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z );
			}

		/// <summary></summary>
		/// <param name="a"></param>
		/// <param name="v"></param>
		/// <returns></returns>
		public static Vector3 ScalarMul(double a, Vector3 v)
			{
			return new Vector3( a * v.X, a * v.Y, a * v.Z );
			}

		/// <summary></summary>
		/// <param name="a"></param>
		/// <param name="v"></param>
		/// <returns></returns>
		public static Vector3 ScalarDiv(Vector3 v, double a)
			{
			return new Vector3( v.X / a, v.Y / a, v.Z / a );
			}

		/// <summary></summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static bool Equals(Vector3 v1, Vector3 v2)
			{
			return GetAmplitude( v1 - v2 ) <= Accuracy;
			}

		/// <summary></summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public static double GetAmplitude(Vector3 v)
			{
			return Math.Sqrt( v.X * v.X + v.Y * v.Y + v.Z * v.Z );
			}

		/// <summary></summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public static Vector3 GetNorm(Vector3 v)
			{
			double amp = GetAmplitude( v );
			if( amp == 0 ) return new Vector3( 0, 0, 0 );
			return new Vector3( v.X / amp, v.Y / amp, v.Z / amp );
			}

		/// <summary></summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static double Dot(Vector3 v1, Vector3 v2)
			{
			return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
			}

		/// <summary></summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static Vector3 Cross(Vector3 v1, Vector3 v2)
			{
			return new Vector3( v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X );
			}


		/// <summary></summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public static Vector3 operator +(Vector3 v)
			{
			return Positive( v );
			}

		/// <summary></summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public static Vector3 operator -(Vector3 v)
			{
			return Negative( v );
			}

		/// <summary></summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static Vector3 operator +(Vector3 v1, Vector3 v2)
			{
			return Add( v1, v2 );
			}

		/// <summary></summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static Vector3 operator -(Vector3 v1, Vector3 v2)
			{
			return Sub( v1, v2 );
			}

		/// <summary></summary>
		/// <param name="a"></param>
		/// <param name="v"></param>
		/// <returns></returns>
		public static Vector3 operator *(double a, Vector3 v)
			{
			return ScalarMul( a, v );
			}

		/// <summary></summary>
		/// <param name="v"></param>
		/// <param name="a"></param>
		/// <returns></returns>
		public static Vector3 operator /(Vector3 v, double a)
			{
			return ScalarDiv( v, a );
			}

		/// <summary></summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static bool operator ==(Vector3 v1, Vector3 v2)
			{
			return Equals( v1, v2 );
			}

		/// <summary></summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static bool operator !=(Vector3 v1, Vector3 v2)
			{
			return !( v1 == v2 );
			}
















		#endregion




		}


	}
