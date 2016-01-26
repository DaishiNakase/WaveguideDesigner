using Hslab.MeepManager.WaveguideDesigner;
using Hslab.VirtualStructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	public class SourceData : NamedDataBase
		{

		public enum SourceType : int
			{
			Continuous = MeepSource.SourceType.Continuous,
			Gaussian = MeepSource.SourceType.Gaussian,
			}


		#region project data properties

		/// <summary>falseの場合、シミュレーションでこの光源は無視される。</summary>
		[PropertyEditorAttribute( 2 )]
		public bool Enabled { get; set; }



		/// <summary>光源の時間変動タイプ。</summary>
		[PropertyEditorAttribute( 3 )]
		public SourceType Type { get; set; }



		/// <summary>光源の成分。</summary>
		[PropertyEditorAttribute( 4 )]
		public Component Component
			{
			get { return _Component; }
			set
				{
				if( (int)value % 10 == 0 || (int)value >= 30 ) throw new ArgumentException();
				_Component = value;
				}
			}
		private Component _Component;



		/// <summary>光源の中心位置。</summary>
		[PropertyEditorAttribute( 5 )]
		public Vector3 Center
			{
			get { return _Center; }
			set
				{
				_Center = value;
				UpdateVirtualShape();
				}
			}
		private Vector3 _Center;



		/// <summary>光源のサイズ。</summary>
		[PropertyEditorAttribute( 6 )]
		public Vector3 Size
			{
			get { return _Size; }
			set
				{
				if( value.X < 0 || value.Y < 0 || value.Z < 0 ) throw new ArgumentException();
				_Size = value;
				UpdateVirtualShape();
				}
			}
		private Vector3 _Size;



		/// <summary>光源の強度。</summary>
		[PropertyEditorAttribute( 7 )]
		public double Amplitude { get; set; }



		/// <summary>波長。[um]</summary>
		[PropertyEditorAttribute( 8 )]
		public double Wavelength { get; set; }



		/// <summary>発光開始時間。</summary>
		[PropertyEditorAttribute( 9 )]
		public double StartTime { get; set; }



		/// <summary>発光終了時間。</summary>
		[PropertyEditorAttribute( 10 )]
		public double EndTime { get; set; }



		/// <summary>発光時間幅。</summary>
		[PropertyEditorAttribute( 11 )]
		public double Width { get; set; }



		/// <summary>カットオフ。</summary>
		[PropertyEditorAttribute( 12 )]
		public double Cutoff { get; set; }

		#endregion



		#region runtime utility properties


		/// <summary>ProjectDataツリーにおける親オブジェクト。</summary>
		[XmlIgnore]
		public override ProjectDataBase Parent
			{
			get { return base.Parent; }
			protected internal set
				{
				base.Parent = value;
				if( value == null ) return;
				}
			}


		/// <summary>このGeometricObjectの描画情報。</summary>
		[XmlIgnore]
		public VirtualShapeBase VirtualShape { get; protected set; }

		#endregion



		#region constructors

		/// <summary></summary>
		public SourceData()
			{
			Enabled = true;
			Name = "New Source";
			Type = SourceType.Continuous;
			Component = Component.Ex;
			Center = new Vector3();
			Size = new Vector3();
			Amplitude = 1;
			Wavelength = 1;
			StartTime = 0;
			EndTime = double.PositiveInfinity;
			Width = 1;
			Cutoff = 3;
			}



		/// <summary></summary>
		/// <param name="previous"></param>
		public SourceData(SourceData previous) : base( previous )
			{
			Enabled = previous.Enabled;
			Type = previous.Type;
			Component = previous.Component;
			Center = previous.Center; ;
			Size = previous.Size;
			Amplitude = previous.Amplitude;
			Wavelength = previous.Wavelength;
			StartTime = previous.StartTime;
			EndTime = previous.EndTime;
			Width = previous.Width;
			Cutoff = previous.Cutoff;
			}

		#endregion



		#region methods

		public override string ToString()
			{
			return base.ToString();
			}



		/// <summary>MeepのSourceを生成する。</summary>
		/// <returns></returns>
		public virtual List<MeepSource> MakeMeepSource()
			{
			if( !Enabled ) return new List<MeepSource>();

			SimulationRegionData data = ( Parent as ProjectManifestData ).SimulationRegion;
			double xShift = ( data.MinX + data.MaxX ) / 2,
				yShift = ( data.MinY + data.MaxY ) / 2,
				zShift = ( data.MinZ + data.MaxZ ) / 2;
			Vector3 shift = new Vector3( xShift, yShift, zShift );


			MeepSource src = null;
			switch( Type )
				{
				case SourceType.Continuous:
					src = MeepSource.CreateContinuousSource( Component, Center-shift, Wavelength );
					src.Size = Size;
					src.StartTime = StartTime;
					src.EndTime = EndTime;
					src.Width = Width;
					src.Cutoff = Cutoff;
					break;
				case SourceType.Gaussian:
					src = MeepSource.CreateGaussianSource( Component, Center-shift, Wavelength, Width );
					src.Size = Size;
					src.StartTime = StartTime;
					src.EndTime = EndTime;
					src.Cutoff = Cutoff;
					break;
				}

			if( src != null ) return new List<MeepSource>( new[] { src } );
			else return new List<MeepSource>();
			}



		/// <summary>派生クラスのコピーコンストラクタを実行する。</summary>
		/// <returns></returns>
		public SourceData MakeDeepCopy()
			{
			return this.GetType()
				.GetConstructor( new Type[] { this.GetType() } )
				.Invoke( new object[] { this } )
				as SourceData;
			}



		/// <summary>バーチャルシェイプを更新する。</summary>
		public void UpdateVirtualShape()
			{
			if( Size.Amplitude == 0 )
				{
				VirtualEllipse ellipse = VirtualShape as VirtualEllipse ?? new VirtualEllipse();
				ellipse.Center = new PointD( Center.X, Center.Y );
				ellipse.Radius = new SizeD( 3, 3 );
				ellipse.DoesGlobalScale = false;
				VirtualShape = ellipse;
				}
			else if( Size.X == 0 || Size.Y == 0 )
				{
				VirtualLine line = VirtualShape as VirtualLine ?? new VirtualLine();
				PointD p1, p2;
				p1 = new PointD( Center.X - Size.X / 2, Center.Y - Size.Y / 2 );
				p2 = new PointD( Center.X + Size.X / 2, Center.Y + Size.Y / 2 );
				line.Vertices = new PointD[] { p1, p2 };
				line.DoesGlobalScale = false;
				VirtualShape = line;
				}
			else
				{
				VirtualRectangle rect = VirtualShape as VirtualRectangle ?? new VirtualRectangle();
				rect.Location = new PointD( Center.X - Size.X / 2, Center.Y - Size.Y / 2 );
				rect.Size = new SizeD( Size.X, Size.Y );
				rect.DoesGlobalScale = false;
				VirtualShape = rect;
				}
			VirtualShape.ShapeFill = Brushes.Red;
			VirtualShape.ShapeBorder = new Pen( Brushes.Red, 3 );

			if( ( Parent as ProjectManifestData ) != null )
				if( !( Parent as ProjectManifestData ).ManifestVisualizingLayer.Shapes.Contains( VirtualShape ) )
					( Parent as ProjectManifestData ).ManifestVisualizingLayer.Shapes.Add( VirtualShape );
			}

		#endregion
		}
	}
