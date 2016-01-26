using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hslab;
using Hslab.MeepManager.WaveguideDesigner;
using Hslab.WaveguideDesigner.ProjectData;

namespace Hslab.WaveguideDesigner
	{
	/// <summary></summary>
	public class MeepGeometricObjectMaker
		{
		/// <summary>double値の等価性評価の精度。差がこれ以下である場合は等価とみなす。</summary>
		public static double Accuracy
			{
			get { return _Accuracy; }
			set
				{
				if( value < 0 ) throw new ArgumentException();
				_Accuracy = value;
				}
			}
		private static double _Accuracy = 1e-10;
		private static bool Equals(double a, double b)
			{
			return Math.Abs( a - b ) <= Accuracy;
			}
		private static bool Equals(PointD a, PointD b)
			{
			return Math.Sqrt( Math.Pow( a.X - b.X, 2 ) + Math.Pow( a.Y - b.Y, 2 ) ) <= Accuracy;
			}



		/// <summary>GeometricObjectのレイヤ。</summary>
		public LayerData Layer { get; private set; }

		/// <summary></summary>
		public MeepMaterialType MeepMaterial
			{
			get
				{
				return Layer.Profile.Material.MeepMaterial;
				}
			}



		/// <summary></summary>
		public double CenterZ { get { return Layer.Profile.CenterZ; } }
		/// <summary></summary>
		public double SizeZ { get { return Layer.Profile.SizeZ; } }
		/// <summary></summary>
		public double MinZ { get { return Layer.Profile.MinZ; } }
		/// <summary></summary>
		public double MaxZ { get { return Layer.Profile.MaxZ; } }




		/// <summary></summary>
		public MeepGeometricObjectMaker(LayerData layer)
			{
			Layer = layer;
			}




		/// <summary></summary>
		public List<MeepBlock> FromPolygon(PointD[] vertices)
			{
			List<MeepBlock> list = new List<MeepBlock>();

			PointD[] tetragon;
			for( int i = 0 ; i < vertices.Length / 2 - 1 ; i++ )
				{
				tetragon = new PointD[4];
				tetragon[0] = vertices[i];
				tetragon[1] = vertices[i + 1];
				tetragon[2] = vertices[vertices.Length - i - 2];
				tetragon[3] = vertices[vertices.Length - i - 1];
				foreach( MeepBlock geometricObj in FromTetragon( tetragon ) )
					list.Add( geometricObj );
				}

			return list;
			}



		/// <summary></summary>
		public List<MeepBlock> FromTetragon(PointD[] vertices)
			{
			if( vertices.Length != 4 ) throw new ArgumentException();
			List<MeepBlock> list = new List<MeepBlock>();

			List<PointD> _vertices = new List<PointD>();				// 三角形判定用リスト
			for( int i = 4 ; i < 8 ; i++ )
				if( vertices[i % 4] != vertices[( i - 1 ) % 4] )
					_vertices.Add( vertices[i % 4] );

			if( _vertices.Count == 3 )
				foreach( MeepBlock geometricObj in FromTriangle( _vertices.ToArray() ) )
					list.Add( geometricObj );
			if( _vertices.Count == 4 )
				{
				foreach( MeepBlock geometricObj in FromTriangle( new[] { vertices[0], vertices[1], vertices[2] } ) )
					list.Add( geometricObj );
				foreach( MeepBlock geometricObj in FromTriangle( new[] { vertices[2], vertices[3], vertices[0] } ) )
					list.Add( geometricObj );
				}

			return list;
			}



		/// <summary></summary>
		public List<MeepBlock> FromTriangle(PointD[] vertices)
			{
			if( vertices.Length != 3 ) throw new ArgumentException();
			List<MeepBlock> list = new List<MeepBlock>();
			if( vertices[0] == vertices[1] || vertices[1] == vertices[2] ) return list;
			list.Add( FromParallelogram( vertices[0], 0.5 * ( vertices[1] - vertices[0] ), 0.5 * ( vertices[2] - vertices[0] ) ) );
			list.Add( FromParallelogram( vertices[1], 0.5 * ( vertices[2] - vertices[1] ), 0.5 * ( vertices[0] - vertices[1] ) ) );
			list.Add( FromParallelogram( vertices[2], 0.5 * ( vertices[0] - vertices[2] ), 0.5 * ( vertices[1] - vertices[2] ) ) );
			return list;
			}



		/// <summary></summary>
		public MeepBlock FromParallelogram(PointD origin, SizeD vector1, SizeD vector2)
			{
			MeepVector3 center = Convert( origin + 0.5 * vector1 + 0.5 * vector2, CenterZ );
			MeepVector3 size = new MeepVector3( vector1.Magnitude, vector2.Magnitude, SizeZ );
			return new MeepBlock( MeepMaterial, center, size )
			{
				E1 = Convert( ( 1 / vector1.Magnitude ) * vector1, 0 ),
				E2 = Convert( ( 1 / vector2.Magnitude ) * vector2, 0 ),
				E3 = MeepVector3.AxisZ,
			};
			}






		private MeepVector3 Convert(PointD p, double z) { return new MeepVector3( p.X, p.Y, z ); }
		private MeepVector3 Convert(SizeD s, double z) { return new MeepVector3( s.W, s.H, z ); }
		}
	}
