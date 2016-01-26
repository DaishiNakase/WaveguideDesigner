using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hslab.VirtualStructure;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	/// <summary>流束解析情報のプロジェクトデータ。</summary>
	public class FluxAnalysisData : ProjectDataBase
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

		#endregion



		#region runtime utility properties

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

			VirtualShape = new VirtualLine();
			}



		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public FluxAnalysisData(FluxAnalysisData previous)
			{
			FluxDirection = previous.FluxDirection;
			Center = previous.Center;
			Size = previous.Size;

			VirtualShape = new VirtualLine();
			}



		/// <summary></summary>
		public void UpdateVirtualShape()
			{
			PointD p1, p2;
			p1 = new PointD( Center.X - Size.X / 2, Center.Y - Size.Y / 2 );
			p2 = new PointD( Center.X + Size.X / 2, Center.Y + Size.Y / 2 );
			VirtualShape.Vertices = new PointD[] { p1, p2 };
			VirtualShape.ShapeFill = new HatchBrush( HatchStyle.Percent25, Color.Blue );
			VirtualShape.ShapeBorder = new Pen( Brushes.Blue, 1 );
			}


		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			return base.ToString( "/location:" + Center.ToString() );
			}

		}

	}
