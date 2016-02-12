using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hslab.VirtualStructure;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using Hslab.MeepManager.WaveguideDesigner;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	/// <summary>流束解析情報のプロジェクトデータ。</summary>
	public class FluxAnalysisData : NamedDataBase
		{

		#region project data properties

		/// <summary>流束の方向。</summary>
		[PropertyEditorAttribute( 0 )]
		public Direction FluxDirection
			{
			get { return _FluxDirection; }
			set
				{
				if( value == Direction.X || value == Direction.Y ) _FluxDirection = value;
				}
			}
		private Direction _FluxDirection;



		/// <summary>解析領域の位置[um,um,um]。</summary>
		[PropertyEditorAttribute( 1 )]
		public Vector3 Center { get; set; }



		/// <summary>解析領域のサイズ[um,um,um]。</summary>
		[PropertyEditorAttribute( 2 )]
		public Vector3 Size
			{
			get { return _Size; }
			set
				{
				_Size = value;
				switch( FluxDirection )
					{
					case Direction.X:
						_Size.X = 0;
						break;
					case Direction.Y:
						_Size.Y = 0;
						break;
					}
				}
			}
		private Vector3 _Size;



		/// <summary>解析範囲[um]。</summary>
		[PropertyEditorAttribute( 3 )]
		public double CenterWavelength
			{
			get { return _CenterWavelength; }
			set { _CenterWavelength = Math.Max( 0.0001, value ); }
			}
		private double _CenterWavelength = 0.0001;



		/// <summary>解析範囲[um]。</summary>
		[PropertyEditorAttribute( 3 )]
		public double WavelengthSpan
			{
			get { return _WavelengthSpan; }
			set { _WavelengthSpan = Math.Max( 0.0001, value ); }
			}
		private double _WavelengthSpan = 0.0001;



		/// <summary>点数。</summary>
		[PropertyEditorAttribute( 4 )]
		public int PointNum
			{
			get { return _PointNum; }
			set { _PointNum = Math.Max( 2, value ); }
			}
		private int _PointNum = 2;


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

		/// <summary></summary>
		[System.Xml.Serialization.XmlIgnore]
		public VirtualLine VirtualShape { get; private set; }

		#endregion



		/// <summary>デフォルトコンストラクタ。</summary>
		public FluxAnalysisData()
			{
			_FluxDirection = Direction.X;
			Center = new Vector3();
			Size = new Vector3();
			Name = "flux";

			VirtualShape = new VirtualLine();
			}



		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public FluxAnalysisData(FluxAnalysisData previous) : base( previous )
			{
			CenterWavelength = previous.CenterWavelength;
			WavelengthSpan = previous.WavelengthSpan;
			PointNum = previous.PointNum;
			FluxDirection = previous.FluxDirection;
			Center = previous.Center;
			Size = previous.Size;

			VirtualShape = new VirtualLine();
			}




		/// <summary>MeepのFlux analyserを生成する。</summary>
		/// <returns></returns>
		public MeepFlux MakeMeepFlux()
			{
			MeepFluxRegion region = new MeepFluxRegion( Center ) { Size = Size, Direction = (MeepManager.WaveguideDesigner.Direction)FluxDirection };
			return new MeepFlux( Name, CenterWavelength, ( 1 / WavelengthSpan ) / PointNum, PointNum, new MeepFluxRegion[] { region } );
			}




		/// <summary></summary>
		public void UpdateVirtualShape()
			{
			PointD p1, p2;
			p1 = new PointD( Center.X - Size.X / 2, Center.Y - Size.Y / 2 );
			p2 = new PointD( Center.X + Size.X / 2, Center.Y + Size.Y / 2 );
			VirtualShape.Vertices = new PointD[] { p1, p2 };
			VirtualShape.DoesGlobalScale = false;

			VirtualShape.ShapeFill = Brushes.Blue;
			VirtualShape.ShapeBorder = new Pen( Brushes.Blue, 3 );

			if( ( Parent as ProjectManifestData ) != null )
				if( !( Parent as ProjectManifestData ).ManifestVisualizingLayer.Shapes.Contains( VirtualShape ) )
					( Parent as ProjectManifestData ).ManifestVisualizingLayer.Shapes.Add( VirtualShape );

			}



		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			return Name;
			}



		public override string GetDescription()
			{
			string res = "";
			res += "center wavelength : " + (CenterWavelength*1000) .ToString()+ " nm\r\n";
			res += "wavelength span   : " + (WavelengthSpan*1000).ToString()+" nm\r\n";
			res += "point number      : " + PointNum.ToString()+"\r\n";
			res += "location          : " + Center.ToString() + " [um,um,um]\r\n";
			res += "size              : " + Size.ToString() + " [um,um,um]\r\n";
			res += "direction         : " + FluxDirection.ToString() + "\r\n";
			return res;
			}
		}

	}
