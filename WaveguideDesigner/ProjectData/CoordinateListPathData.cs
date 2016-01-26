using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hslab.VirtualStructure;
using Hslab.MathExpression;
using Hslab.MeepManager.WaveguideDesigner;
using System.Xml.Serialization;

namespace Hslab.WaveguideDesigner.ProjectData
	{

	/// <summary>直交座標系関数により構造を定義できるパス構造オブジェクト。</summary>
	public class CoordinateListPathData : PathStructureObjectData
		{

		#region properties

		/// <summary>常にtrue。setterはInvalidOperationExceptionをスローする。</summary>
		[XmlIgnore]
		public override bool IsValid { get { return true; } protected set { throw new InvalidOperationException(); } }


		/// <summary>中心点座標の配列。</summary>
		[PropertyEditorAttribute( 5 )]
		public PointD[] Centers
			{
			get { return _Centers; }
			set
				{
				if( value.Length != PointNum ) throw new ArgumentException();
				_Centers = value;
				}
			}
		private PointD[] _Centers;


		/// <summary>パスの左翼幅の配列。</summary>
		[PropertyEditorAttribute( 6 )]
		public double[] LeftWingWidths
			{
			get { return _LeftWingWidths; }
			set
				{
				if( value.Length != PointNum ) throw new ArgumentException();
				_LeftWingWidths = value;
				}
			}
		private double[] _LeftWingWidths;


		/// <summary>パスの右翼幅の配列。</summary>
		[PropertyEditorAttribute( 7 )]
		public double[] RightWingWidths
			{
			get { return _RightWingWidths; }
			set
				{
				if( value.Length != PointNum ) throw new ArgumentException();
				_RightWingWidths = value;
				}
			}
		private double[] _RightWingWidths;

		#endregion






		#region constructors

		/// <summary>デフォルトコンストラクタ。</summary>
		public CoordinateListPathData()
			{
			VirtualShape = new VirtualPolygon();
			Name = "ListPath";
			Centers = new PointD[] { new PointD(0,0),new PointD(1,0)};
			LeftWingWidths = new double[] { 1, 1 };
			RightWingWidths = new double[2];
			}

		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public CoordinateListPathData(CoordinateListPathData previous)
			: base( previous )
			{
			VirtualShape = new VirtualPolygon();
			Centers = previous.Centers;
			LeftWingWidths = previous.LeftWingWidths;
			RightWingWidths = previous.RightWingWidths;
			}


		#endregion



		#region methods



		/// <summary></summary>
		public override List<MeepGeometricObject> MakeMeepGeometricObject()
			{
			if( UpdateVirtualShape() && ( this.State & ObjectState.ForAnalysis ) != 0 )
				{
				MeepGeometricObjectMaker maker = new MeepGeometricObjectMaker( this.ParentLayer );
				return new List<MeepGeometricObject>( maker.FromPolygon( ( (VirtualPolygon)VirtualShape ).Vertices ).Cast<MeepGeometricObject>() );
				}
			return null;
			//throw new NotImplementedException();
			}



		/// <summary>定義されたプロパティに従ってVirtualShapeを更新する。GeometricObjectDataBaseの実装。</summary>
		/// <returns>全てのプロパティが妥当であり、VirtualShapeの更新に成功したときはtrue。</returns>
		public override bool UpdateVirtualShape()
			{
			VirtualPolygon polygon = (VirtualPolygon)VirtualShape;
			polygon.Visible = true;

			double[] centerXList = new double[PointNum + 2],
				centerYList = new double[PointNum + 2],
				leftWingWidthList = new double[PointNum + 2],
				rightWingWidthList = new double[PointNum + 2];

			for( int i = 0 ; i < PointNum ; i++ )
				{
				centerXList[i + 1] = Centers[i].X;
				centerYList[i + 1] = Centers[i].Y;
				}
			LeftWingWidths.CopyTo( LeftWingWidths, 1 );
			RightWingWidths.CopyTo( RightWingWidths, 1 );
			centerXList[0] = Centers[0].X;
			centerYList[0] = Centers[0].Y;
			leftWingWidthList[0] = LeftWingWidths[0];
			rightWingWidthList[0] = RightWingWidths[0];
			centerXList[PointNum + 1] = Centers[PointNum - 1].X;
			centerYList[PointNum + 1] = Centers[PointNum - 1].Y;
			leftWingWidthList[PointNum + 1] = LeftWingWidths[PointNum - 1];
			rightWingWidthList[PointNum + 1] = RightWingWidths[PointNum - 1];

			// VirtualPolygonに頂点を反映
			int j;
			double normalAngle;
			SizeD normalVector;
			polygon.Vertices = new PointD[2 * PointNum];
			for( int i = 0 ; i < PointNum ; i++ )
				{
				j = 2 * PointNum - i - 1;
				normalAngle = Math.Atan2( centerYList[i + 2] - centerYList[i], centerXList[i + 2] - centerXList[i] ) + Math.PI / 2;
				normalVector = new SizeD( Math.Cos( normalAngle ), Math.Sin( normalAngle ) );
				polygon.Vertices[i] = new PointD( centerXList[i + 1], centerYList[i + 1] ) + leftWingWidthList[i + 1] * normalVector;
				polygon.Vertices[j] = new PointD( centerXList[i + 1], centerYList[i + 1] ) - rightWingWidthList[i + 1] * normalVector;
				}

			base.RefreshRenderSetting();
			return IsValid;
			}



		private void CopyTo(Array from, Array to)
			{
			for( int i = 0 ; i < from.Length && i < to.Length ; i++ )
				to.SetValue( from.GetValue( i ), i );
			}


		#endregion


		}

	}
