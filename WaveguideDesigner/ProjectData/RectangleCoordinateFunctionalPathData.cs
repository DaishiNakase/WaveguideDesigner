using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hslab.VirtualStructure;
using Hslab.MathExpression;
using Hslab.MeepManager.WaveguideDesigner;

namespace Hslab.WaveguideDesigner.ProjectData
	{

	/// <summary>直交座標系関数により構造を定義できるパス構造オブジェクト。</summary>
	public class RectangleCoordinateFunctionalPathData : PathStructureObjectData
		{

		#region properties




		/// <summary>パス中心のX座標の関数表現。パラメータt(0≦t≦1)を使用可能。</summary>
		[PropertyEditorAttribute( 5 ,true),CheckLastValidAttribute]
		public string CenterX { get; set; }
		/// <summary>CenterXのLastValid。</summary>
		public string CenterX_LastValid { get; set; }



		/// <summary>パス中心のY座標の関数表現。パラメータt(0≦t≦1)を使用可能。</summary>
		[PropertyEditorAttribute( 6 ,true),CheckLastValidAttribute]
		public string CenterY { get; set; }
		/// <summary>CenterYのLastValid。</summary>
		public string CenterY_LastValid { get; set; }





		/// <summary>パスの左側太さの関数表現。パラメータt(0≦t≦1)を使用可能。<br />
		/// [note] パスの左側とは、tが増加する方向に向かって左側であることを指す。
		/// </summary>
		[PropertyEditorAttribute( 7 ,true), CheckLastValidAttribute]
		public string LeftWingWidth { get; set; }
		/// <summary>LeftWingWidthのLastValid。</summary>
		public string LeftWingWidth_LastValid { get; set; }



		/// <summary>パスの右側太さの関数表現。パラメータt(0≦t≦1)を使用可能。<br />
		/// [note] パスの右側とは、tが増加する方向に向かって右側であることを指す。
		/// </summary>
		[PropertyEditorAttribute( 8 ,true), CheckLastValidAttribute]
		public string RightWingWidth { get; set; }
		/// <summary>RightWingWidthのLastValid。</summary>
		public string RightWingWidth_LastValid { get; set; }

		#endregion






		#region constructors

		/// <summary>デフォルトコンストラクタ。</summary>
		public RectangleCoordinateFunctionalPathData()
			{
			VirtualShape = new VirtualPolygon();
			Name = "RectPath";
			CenterX = "t";
			CenterX_LastValid = "t";
			CenterY = "0";
			CenterY_LastValid = "0";
			LeftWingWidth = "1";
			LeftWingWidth_LastValid = "1";
			RightWingWidth = "0";
			RightWingWidth_LastValid = "0";
			}

		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public RectangleCoordinateFunctionalPathData(RectangleCoordinateFunctionalPathData previous)
			: base( previous )
			{
			VirtualShape = new VirtualPolygon();
			CenterX = previous.CenterX;
			CenterX_LastValid = previous.CenterX_LastValid;
			CenterY = previous.CenterY;
			CenterY_LastValid = previous.CenterY_LastValid;
			LeftWingWidth = previous.LeftWingWidth;
			LeftWingWidth_LastValid = previous.LeftWingWidth_LastValid;
			RightWingWidth = previous.RightWingWidth;
			RightWingWidth_LastValid = previous.RightWingWidth_LastValid;
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

			bool validOX = true, validOY = true, validX = true, validY = true, validLeft = true, validRight = true;
			double xOffset, yOffset;
			double[] CenterXList = new double[PointNum + 2],
				CenterYList = new double[PointNum + 2],
				LeftWingWidthList = new double[PointNum + 2],
				RightWingWidthList = new double[PointNum + 2];

			// 検証
			ValidateFormula( XOffset, XOffset_LastValid, out xOffset, out validOX );
			ValidateFormula( YOffset, YOffset_LastValid, out yOffset, out validOY );
			ValidateFormula( CenterX, PointNum, CenterX_LastValid, CenterXList, out validX );
			ValidateFormula( CenterY, PointNum, CenterY_LastValid, CenterYList, out validY );
			ValidateFormula( LeftWingWidth, PointNum, LeftWingWidth_LastValid, LeftWingWidthList, out validLeft );
			ValidateFormula( RightWingWidth, PointNum, RightWingWidth_LastValid, RightWingWidthList, out validRight );

			// IsValidの評価
			IsValid = validOX && validOY && validX && validY && validLeft && validRight;
			if( validOX ) XOffset_LastValid = XOffset;
			if( validOY ) YOffset_LastValid = YOffset;
			if( validX ) CenterX_LastValid = CenterX;
			if( validY ) CenterY_LastValid = CenterY;
			if( validLeft ) LeftWingWidth_LastValid = LeftWingWidth;
			if( validRight ) RightWingWidth_LastValid = RightWingWidth;


			// VirtualPolygonに頂点を反映
			int j;
			double normalAngle;
			SizeD normalVector;
			polygon.Vertices = new PointD[2 * PointNum];
			for( int i = 0 ; i < PointNum ; i++ )
				{
				j = 2 * PointNum - i - 1;
				normalAngle = Math.Atan2( CenterYList[i + 2] - CenterYList[i], CenterXList[i + 2] - CenterXList[i] ) + Math.PI / 2;
				normalVector = new SizeD( Math.Cos( normalAngle ), Math.Sin( normalAngle ) );
				polygon.Vertices[i] = new PointD( CenterXList[i + 1] + xOffset, CenterYList[i + 1] + yOffset ) + LeftWingWidthList[i + 1] * normalVector;
				polygon.Vertices[j] = new PointD( CenterXList[i + 1] + xOffset, CenterYList[i + 1] + yOffset ) - RightWingWidthList[i + 1] * normalVector;
				}

			base.RefreshRenderSetting();
			return IsValid;
			}



		


		#endregion


		}

	}
