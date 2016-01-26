using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public struct MeepVector3
		{
		public static MeepVector3 Zero { get { return new MeepVector3( 0, 0, 0 ); } }
		public static MeepVector3 AxisX { get { return new MeepVector3( 1, 0, 0 ); } }
		public static MeepVector3 AxisY { get { return new MeepVector3( 0, 1, 0 ); } }
		public static MeepVector3 AxisZ { get { return new MeepVector3( 0, 0, 1 ); } }

		public double X;
		public double Y;
		public double Z;


		public MeepVector3(double x, double y, double z)
			{
			X = x;
			Y = y;
			Z = z;
			}

		public override string ToString()
			{
			return string.Format( "(vector3 {0} {1} {2})", DoubleToString( X ), DoubleToString( Y ), DoubleToString( Z ) );
			}

		private string DoubleToString(double d)
			{
			if( double.IsNaN( d ) ) return "no-size";
			else if( double.IsInfinity( d ) ) return "infinity";
			return d.ToString();
			}



		public static bool operator ==(MeepVector3 v1, MeepVector3 v2)
			{
			return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
			}

		public static bool operator !=(MeepVector3 v1, MeepVector3 v2)
			{
			return !( v1 == v2 );
			}

		public override bool Equals(object obj)
			{
			if( !( obj is MeepVector3 ) ) return false;
			return this == (MeepVector3)obj;
			}

		public override int GetHashCode()
			{
			return X.GetHashCode() & Y.GetHashCode() & Z.GetHashCode();
			}


		public static implicit operator MeepVector3(Vector3 v)
			{
			return new MeepVector3( v.X, v.Y, v.Z );
			}

		public static implicit operator Vector3(MeepVector3 v)
			{
			return new Vector3( v.X, v.Y, v.Z );
			
			}

		}
	}
