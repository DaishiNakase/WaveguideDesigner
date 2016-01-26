using Hslab.VirtualStructure;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Xml.Serialization;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	/// <summary>解析範囲情報のプロジェクトデータ。</summary>
	public class SimulationRegionData : ProjectDataBase
		{
		#region project data properties

		/// <summary>X方向最小値[um]。</summary>
		[PropertyEditorAttribute( 0 )]
		public double MinX
			{
			get { return _MinX; }
			set { _MinX = value; }
			}
		private double _MinX;

		/// <summary>X方向最大値[um]。</summary>
		[PropertyEditorAttribute( 1 )]
		public double MaxX
			{
			get { return _MaxX; }
			set { _MaxX = value; }
			}
		private double _MaxX;

		/// <summary>Y方向最小値[um]。</summary>
		[PropertyEditorAttribute( 2 )]
		public double MinY
			{
			get { return _MinY; }
			set { _MinY = value; }
			}
		private double _MinY;

		/// <summary>Y方向最大値[um]。</summary>
		[PropertyEditorAttribute( 3 )]
		public double MaxY
			{
			get { return _MaxY; }
			set { _MaxY = value; }
			}
		private double _MaxY;

		/// <summary>Z方向最小値[um]。</summary>
		[PropertyEditorAttribute( 4 )]
		public double MinZ
			{
			get { return _MinZ; }
			set { _MinZ = value; }
			}
		private double _MinZ;

		/// <summary>Z方向最大値[um]。</summary>
		[PropertyEditorAttribute( 5 )]
		public double MaxZ
			{
			get { return _MaxZ; }
			set { _MaxZ = value; }
			}
		private double _MaxZ;

		/// <summary>次元数。</summary>
		[PropertyEditorAttribute( 6 )]
		public Dimension Dimension
			{
			get { return _Dimension; }
			set { _Dimension = value; }
			}
		private Dimension _Dimension;

		/// <summary>PMLの厚さ[um]。</summary>
		[PropertyEditorAttribute( 7 )]
		public double PmlThickness
			{
			get { return _PmlThickness; }
			set
				{
				if( value >= 0 ) _PmlThickness = value;
				}
			}
		private double _PmlThickness;

		#endregion



		#region runtime utility properties

		/// <summary>X方向サイズ[um]。</summary>
		[XmlIgnore]
		public double SizeX { get { return MaxX - MinX; } }

		/// <summary>Y方向サイズ[um]。</summary>
		[XmlIgnore]
		public double SizeY { get { return MaxY - MinY; } }

		/// <summary>Z方向サイズ[um]。</summary>
		[XmlIgnore]
		public double SizeZ { get { return MaxZ - MinZ; } }

		/// <summary></summary>
		[XmlIgnore]
		public ReadOnlyCollection<VirtualRectangle> Shapes
			{ get { return new ReadOnlyCollection<VirtualRectangle>( _Shapes ); } }
		private List<VirtualRectangle> _Shapes;

		/// <summary></summary>
		[XmlIgnore]
		public Vector3 Center
			{
			get
				{
				return 0.5 * new Vector3( MaxX + MinX, MaxY + MinY, MaxZ + MinZ );
				}
			}
		/// <summary></summary>
		[XmlIgnore]
		public Vector3 Size
			{
			get
				{
				return new Vector3( SizeX, SizeY, SizeZ );
				}
			}

		#endregion


		/// <summary>デフォルトコンストラクタ。</summary>
		public SimulationRegionData()
			{
			_PmlThickness = 1;

			MinX = -1;
			MaxX = 1;
			MinY = -1;
			MaxY = 1;
			MinZ = -1;
			MaxZ = 1;

			_Shapes = new List<VirtualRectangle>();
			_Shapes.Add( new VirtualRectangle() );
			_Shapes[0].ShapeBorder = new Pen( Color.Green, 3 );
			_Shapes[0].ShapeFill = Brushes.Transparent;
			_Shapes.Add( new VirtualRectangle() );
			_Shapes[1].ShapeBorder = new Pen( Brushes.Transparent, 0 );
			_Shapes[1].ShapeFill = new SolidBrush( Color.FromArgb( 64, 255, 255, 255 ) );
			_Shapes.Add( new VirtualRectangle() );
			_Shapes[2].ShapeBorder = _Shapes[1].ShapeBorder;
			_Shapes[2].ShapeFill = _Shapes[1].ShapeFill;
			_Shapes.Add( new VirtualRectangle() );
			_Shapes[3].ShapeBorder = _Shapes[1].ShapeBorder;
			_Shapes[3].ShapeFill = _Shapes[1].ShapeFill;
			_Shapes.Add( new VirtualRectangle() );
			_Shapes[4].ShapeBorder = _Shapes[1].ShapeBorder;
			_Shapes[4].ShapeFill = _Shapes[1].ShapeFill;
			}



		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public SimulationRegionData(SimulationRegionData previous)
			{
			MinX = previous.MinX;
			MaxX = previous.MaxX;
			MinY = previous.MinY;
			MaxY = previous.MaxY;
			MinZ = previous.MinZ;
			MaxZ = previous.MaxZ;
			Dimension = previous.Dimension;
			PmlThickness = previous.PmlThickness;

			_Shapes = new List<VirtualRectangle>();
			_Shapes.Add( new VirtualRectangle() );
			_Shapes[0].ShapeBorder = new Pen( Color.Green, 3 );
			_Shapes[0].ShapeFill = Brushes.Transparent;
			_Shapes.Add( new VirtualRectangle() );
			_Shapes[1].ShapeBorder = new Pen( Brushes.Transparent, 0 );
			_Shapes[1].ShapeFill = new SolidBrush( Color.FromArgb( 64, 255, 255, 255 ) );
			_Shapes.Add( new VirtualRectangle() );
			_Shapes[2].ShapeBorder = _Shapes[1].ShapeBorder;
			_Shapes[2].ShapeFill = _Shapes[1].ShapeFill;
			_Shapes.Add( new VirtualRectangle() );
			_Shapes[3].ShapeBorder = _Shapes[1].ShapeBorder;
			_Shapes[3].ShapeFill = _Shapes[1].ShapeFill;
			_Shapes.Add( new VirtualRectangle() );
			_Shapes[4].ShapeBorder = _Shapes[1].ShapeBorder;
			_Shapes[4].ShapeFill = _Shapes[1].ShapeFill;
			}


		public void UpdateVirtualShape()
			{
			_Shapes[0].Location = new PointD( MinX, MinY );
			_Shapes[0].Size = new SizeD( SizeX, SizeY );

			_Shapes[1].Location = new PointD( MinX, MinY );
			_Shapes[1].Size = new SizeD( PmlThickness, SizeY );
			_Shapes[2].Location = new PointD( MinX + PmlThickness, MinY );
			_Shapes[2].Size = new SizeD( SizeX - 2 * PmlThickness, PmlThickness );
			_Shapes[3].Location = new PointD( MinX + PmlThickness, MaxY - PmlThickness );
			_Shapes[3].Size = new SizeD( SizeX - 2 * PmlThickness, PmlThickness );
			_Shapes[4].Location = new PointD( MaxX - PmlThickness, MinY );
			_Shapes[4].Size = new SizeD( PmlThickness, SizeY );

			if( ( Parent as ProjectManifestData ) != null )
				foreach( VirtualShapeBase shape in _Shapes )
					if( !( Parent as ProjectManifestData ).ManifestVisualizingLayer.Shapes.Contains( shape ) )
						( Parent as ProjectManifestData ).ManifestVisualizingLayer.Shapes.Add( shape );
			}

		}


	}
