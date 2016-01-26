using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;
using Hslab.VirtualStructure;
using Hslab.MeepManager.WaveguideDesigner;
using Hslab.MathExpression;


namespace Hslab.WaveguideDesigner.ProjectData
	{
	/* LastValid置換用正規表現
	 * <match>
	 * (\t+)\[CheckLastValidAttribute\]\r\n\s*public (\w+) (\w+)(?: |\r\n)(?:.*\r\n)+\s*public \2 \3_LastValid.+
	 * <replace>
	 * $1[CheckLastValidAttribute]\r\n$1public $2 $3\r\n$1\t{\r\n$1\tget { return _$3; }\r\n$1\tset\r\n$1\t\t{\r\n$1\t\t$2 oldValue = _$3;\r\n$1\t\tAction undo = new Action( ()=>{_$3=oldValue;});\r\n$1\t\tAction redo = new Action( ()=>{_$3=value;});\r\n$1\t\tUndoRedoPair urPair = new UndoRedoPair("構造オブジェクト : $3","",undo,redo);\r\n$1\t\tApplication.AddUndoRedoPair( urPair );\r\n$1\t\t_$3=value;\r\n$1\t\t}\r\n$1\t}\r\n$1private $2 _$3;\r\n$1public $2 $3_LastValid {get;set;}
	 */



	/// <summary>構造オブジェクトの抽象クラス。</summary>
	public abstract partial class GeometricObjectDataBase : NamedDataBase
		{
		/// <summary>オブジェクトを解析・CAD出力で利用するか否かを示す。</summary>
		public enum ObjectState : byte
			{
			/// <summary>オブジェクトは解析・CAD出力ともに無視される。</summary>
			Disabled = 0,
			/// <summary>オブジェクトは解析で利用される。</summary>
			ForAnalysis = 1,
			/// <summary>オブジェクトはCAD出力で利用される。</summary>
			ForCAD = 2,
			/// <summary>オブジェクトは解析・CAD出力ともに利用される。</summary>
			Enabled = 3,
			}



		#region project data properties


		/// <summary>オブジェクトを解析・CAD出力で利用するか否か。</summary>
		[PropertyEditorAttribute( 1 )]
		public ObjectState State{ get; set; }



		/// <summary>X方向のオフセット。</summary>
		[PropertyEditorAttribute( 2, true ), CheckLastValidAttribute]
		public string XOffset { get; set; }
		/// <summary>XOffsetのLastValid。</summary>
		public string XOffset_LastValid { get; set; }



		/// <summary>Y方向のオフセット。</summary>
		[PropertyEditorAttribute( 3, true ), CheckLastValidAttribute]
		public string YOffset { get; set; }
		/// <summary>YOffsetのLastValid。</summary>
		public string YOffset_LastValid { get; set; }





		#endregion



		#region runtime utiliry properties


		/// <summary>ProjectDataツリーにおける親オブジェクト。</summary>
		[XmlIgnore]
		public override ProjectDataBase Parent
			{
			get { return base.Parent; }
			protected internal set
				{
				base.Parent = value;
				if( value == null ) return;
				if( !ParentLayer.VirtualLayer.Shapes.Contains( this.VirtualShape ) )
					ParentLayer.VirtualLayer.Shapes.Add( this.VirtualShape );
				}
			}



		/// <summary>妥当性検証の必要がある全てのプロパティが妥当ならtrue。</summary>
		[XmlIgnore]
		public virtual bool IsValid { get; protected set; }




		/// <summary>このGeometricObjectの描画情報。</summary>
		[XmlIgnore]
		public VirtualShapeBase VirtualShape
			{
			get { return _VirtualShape; }
			set
				{
				if( _VirtualShape != null ) ParentLayer?.VirtualLayer.Shapes.Remove( _VirtualShape );
				_VirtualShape = value;
				if( _VirtualShape != null ) ParentLayer?.VirtualLayer.Shapes.Add( value );
				}
			}
		private VirtualShapeBase _VirtualShape;


		/// <summary>このGeometricObjectが登録されているレイヤ。</summary>
		[XmlIgnore]
		public LayerData ParentLayer
			{
			get { return Parent as LayerData; }
			}




		/// <summary>選択されたオブジェクトの描画境界。</summary>
		public PenEx SelectedObjectBorder { get { return Application.OpenedProject.GlobalRenderingSetting.SelectedObjectBorder; } }



		/// <summary>選択されたオブジェクトの塗りつぶし。</summary>
		public HatchBrushEx SelectedObjectFill { get { return Application.OpenedProject.GlobalRenderingSetting.SelectedObjectFill; } }



		/// <summary>不正なオブジェクトの描画境界。</summary>
		public PenEx InvalidObjectBorder { get { return Application.OpenedProject.GlobalRenderingSetting.InvalidObjectBorder; } }



		/// <summary>不正なオブジェクトの塗りつぶし。</summary>
		public HatchBrushEx InvalidObjectFill { get { return Application.OpenedProject.GlobalRenderingSetting.InvalidObjectFill; } }



		/// <summary>無効化中のオブジェクトの描画境界。</summary>
		public PenEx DisabledObjectBorder { get { return Application.OpenedProject.GlobalRenderingSetting.DisabledObjectBorder; } }



		/// <summary>無効化中のオブジェクトの塗りつぶし。</summary>
		public HatchBrushEx DisabledObjectFill { get { return Application.OpenedProject.GlobalRenderingSetting.DisabledObjectFill; } }


		#endregion




		#region constructors

		/// <summary>デフォルトコンストラクタ。</summary>
		public GeometricObjectDataBase()
			{
			Name = "New Object";
			State = ObjectState.Enabled;
			XOffset = "0";
			XOffset_LastValid = "0";
			YOffset = "0";
			YOffset_LastValid = "0";
			}

		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public GeometricObjectDataBase(GeometricObjectDataBase previous):base(previous)
			{
			State = previous.State;
			XOffset = previous.XOffset;
			XOffset_LastValid = previous.XOffset_LastValid;
			YOffset = previous.YOffset;
			YOffset_LastValid = previous.YOffset_LastValid;
			}

		~GeometricObjectDataBase()
			{
			VirtualShape = null;
			}

		#endregion



		#region methods


		/// <summary>MeepのGeometricObjectを生成する。</summary>
		/// <returns></returns>
		public abstract List<MeepGeometricObject> MakeMeepGeometricObject();


		/// <summary>定義されたプロパティに従ってVirtualShapeの形状を更新する。</summary>
		/// <returns>全てのプロパティが妥当であり、VirtualShapeの更新に成功したときはtrue。</returns>
		public virtual bool UpdateVirtualShape()
			{
			RefreshRenderSetting();
			return IsValid;
			}



		/// <summary>定義されたプロパティに従ってVirtualShapeの描画設定を更新する。</summary>
		/// <returns>全てのプロパティが妥当であり、VirtualShapeの更新に成功したときはtrue。</returns>
		public bool RefreshRenderSetting()
			{
			// Selected,StateおよびIsValidの状態に合わせてpolygonの描画色を選択する
			if( Application.Selection == this )
				{
				VirtualShape.ShapeBorder = SelectedObjectBorder;
				VirtualShape.ShapeFill = SelectedObjectFill;
				}

			else if( State == ObjectState.Disabled )
				{
				VirtualShape.ShapeBorder = DisabledObjectBorder;
				VirtualShape.ShapeFill = DisabledObjectFill;
				}
			else if( !IsValid )
				{
				VirtualShape.ShapeBorder = InvalidObjectBorder;
				VirtualShape.ShapeFill = InvalidObjectFill;
				}
			else
				{
				VirtualShape.ShapeBorder = null;
				VirtualShape.ShapeFill = null;
				}
			return IsValid;
			}


		/// <summary>派生クラスのコピーコンストラクタを実行する。</summary>
		/// <returns></returns>
		public GeometricObjectDataBase MakeDeepCopy()
			{
			return (GeometricObjectDataBase)this.GetType()
				.GetConstructor( new Type[] { this.GetType() } )
				.Invoke( new object[] { this } );
			}



		/// <summary>式を検証し、結果を返す。</summary>
		/// <param name="formula"></param>
		/// <param name="formula_LastValid"></param>
		/// <param name="result"></param>
		/// <param name="isValid"></param>
		protected void ValidateFormula(string formula, string formula_LastValid, out double result, out bool isValid)
			{
			FormulaEngine engine = Application.FormulaEngine;
			isValid = true;
			try
				{
				result = engine.Calculate( formula );
				}
			catch( FormulaResultException )
				{
				isValid = false;
				result = engine.Calculate( formula_LastValid );
				}

			}




		/// <summary>式を検証し、結果を返す。</summary>
		/// <param name="formula"></param>
		/// <param name="count"></param>
		/// <param name="formula_LastValid"></param>
		/// <param name="resultList"></param>
		/// <param name="isValid"></param>
		protected void ValidateFormula(string formula, int count, string formula_LastValid, double[] resultList, out bool isValid)
			{
			FormulaEngine engine = Application.FormulaEngine;
			double t;
			isValid = true;
			try
				{
				for( int i = 0 ; i < count ; i++ )
					{
					t = i / (double)( count - 1 );
					resultList[i + 1] = engine.CalculateWithT( t, formula );
					}
				}
			catch( FormulaResultException )
				{
				isValid = false;
				for( int i = 0 ; i < count ; i++ )
					{
					t = i / (double)( count - 1 );
					resultList[i + 1] = engine.CalculateWithT( t, formula_LastValid );
					}
				}
			try
				{
				t = -1.0 / (double)( count - 1 );
				resultList[0] = engine.CalculateWithT( t, formula );
				}
			catch( FormulaResultException )
				{
				resultList[0] = resultList[1];
				}
			try
				{
				t = count / (double)( count - 1 );
				resultList[count + 1] = engine.CalculateWithT( t, formula );
				}
			catch( FormulaResultException )
				{
				resultList[count + 1] = resultList[count];
				}

			}



		#endregion
		}



	/// <summary>妥当性検証の必要があるプロパティを示す属性。</summary>
	public class CheckLastValidAttribute : Attribute
	{ }

	}
