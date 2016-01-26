using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Hslab.WaveguideDesigner
	{
	/// <summary>アプリケーション言語パック。</summary>
	public class LanguagePack
		{
#pragma warning disable 1591

		public string LanguageName { get; set; } = "日本語";

		public string ProjectDataBase_ArgumentOutOfRangeExceptionMessageDefault { get; set; } = "ArgumentOutOfRangeException was occured.";

		public UndoRedoPairString ProjectDataBase_PropertyChangedDefault { get; set; } = new UndoRedoPairString( "値の変更" );
		public UndoRedoPairString ProjectList_ValueChangedDefault { get; set; } = new UndoRedoPairString( "リスト要素の変更" );

		public FunctionDataText FunctionData { get; set; } = new FunctionDataText();
		public class FunctionDataText
			{
			public UndoRedoPairString NameChanged { get; set; } = new UndoRedoPairString( "FunctionData : 関数名の変更" );
			public UndoRedoPairString VariablesChanged { get; set; } = new UndoRedoPairString( "FunctionData : 引数リストの変更" );
			public UndoRedoPairString ExpressionChanged { get; set; } = new UndoRedoPairString( "FunctionData : 関数表現の変更" );
			}

		public ParameterDataText ParameterData { get; set; } = new ParameterDataText();
		public class ParameterDataText
			{
			public UndoRedoPairString NameChanged { get; set; } = new UndoRedoPairString( "ParameterData : 変数名の変更" );
			public UndoRedoPairString ValueChanged { get; set; } = new UndoRedoPairString( "ParameterData : 値の変更" );
			}

		public LayerDataText LayerData { get; set; } = new LayerDataText();
		public class LayerDataText
			{
			public UndoRedoPairString NameChanged { get; set; } = new UndoRedoPairString( "LayerData : レイヤ名の変更" );
			}

		public MaterialDataText MaterialData { get; set; } = new MaterialDataText();
		public class MaterialDataText
			{
			public UndoRedoPairString NameChanged { get; set; } = new UndoRedoPairString( "MaterialData : 材料名の変更" );
			}

		public PolerCoordinateFunctionalPathDataText PolerCoordinateFunctionalPathData { get; set; } = new PolerCoordinateFunctionalPathDataText();
		public class PolerCoordinateFunctionalPathDataText
			{
			public UndoRedoPairString NameChanged { get; set; } = new UndoRedoPairString( "PolerCorrdinateFunctionalPathData : 名称の変更" );
			public UndoRedoPairString StateChanged { get; set; } = new UndoRedoPairString( "PolerCoordinateFunctionalPathData : ステートの変更" );
			public UndoRedoPairString XOffsetChanged { get; set; } = new UndoRedoPairString( "PolerCoordinateFunctionalPathData : Xオフセットの変更" );
			public UndoRedoPairString YOffsetChanged { get; set; } = new UndoRedoPairString( "PolerCoordinateFunctionalPathData : Yオフセットの変更" );
			public UndoRedoPairString PointNumChanged { get; set; } = new UndoRedoPairString( "PolerCoordinateFunctionalPathData : 分割点数の変更" );
			public UndoRedoPairString CenterRadiusChanged { get; set; } = new UndoRedoPairString( "PolerCoordinateFunctionalPathData : 中心線動径の変更" );
			public UndoRedoPairString CenterPhaseChanged { get; set; } = new UndoRedoPairString( "PolerCoordinateFunctionalPathData : 中心線偏角の変更" );
			public UndoRedoPairString LeftWingWidthChanged { get; set; } = new UndoRedoPairString( "PolerCoordinateFunctionalPathData : 左翼幅の変更" );
			public UndoRedoPairString RightWingWidthChanged { get; set; } = new UndoRedoPairString( "PolerCoordinateFunctionalPathData : 右翼幅の変更" );
			}

		public RectangleCoordinateFunctionalPathDataText RectangleCoordinateFunctionalPathData { get; set; } = new RectangleCoordinateFunctionalPathDataText();
		public class RectangleCoordinateFunctionalPathDataText
			{
			public UndoRedoPairString NameChanged { get; set; } = new UndoRedoPairString( "RectangleCorrdinateFunctionalPathData : 名称の変更" );
			public UndoRedoPairString XOffsetChanged { get; set; } = new UndoRedoPairString( "RectangleCorrdinateFunctionalPathData : Xオフセットの変更" );
			public UndoRedoPairString YOffsetChanged { get; set; } = new UndoRedoPairString( "RectangleCorrdinateFunctionalPathData : Yオフセットの変更" );
			public UndoRedoPairString PointNumChanged { get; set; } = new UndoRedoPairString( "RectangleCorrdinateFunctionalPathData : 分割点数の変更" );
			public UndoRedoPairString CenterXChanged { get; set; } = new UndoRedoPairString( "RectangleCorrdinateFunctionalPathData : 中心線X座標の変更" );
			public UndoRedoPairString CenterYChanged { get; set; } = new UndoRedoPairString( "RectangleCorrdinateFunctionalPathData : 中心線Y座標の変更" );
			public UndoRedoPairString LeftWingWidthChanged { get; set; } = new UndoRedoPairString( "RectangleCorrdinateFunctionalPathData : 左翼幅の変更" );
			public UndoRedoPairString RightWingWidthChanged { get; set; } = new UndoRedoPairString( "RectangleCorrdinateFunctionalPathData : 右翼幅の変更" );
			}

		public CoordinateListPathDataText CoordinateListPathData { get; set; } = new CoordinateListPathDataText();
		public class CoordinateListPathDataText
			{
			public UndoRedoPairString StateChanged { get; set; } = new UndoRedoPairString( "CoordinateListPathData : ステートの変更" );
			public UndoRedoPairString XOffsetChanged { get; set; } = new UndoRedoPairString( "CoordinateListPathData : Xオフセットの変更" );
			public UndoRedoPairString YOffsetChanged { get; set; } = new UndoRedoPairString( "CoordinateListPathData : Yオフセットの変更" );
			public UndoRedoPairString PointNumChanged { get; set; } = new UndoRedoPairString( "CoordinateListPathData : 分割点数の変更" );
			}



		public StandartFunctionText StandardFunction { get; set; } = new StandartFunctionText();
		public class StandartFunctionText
			{
			public string Undo { get; set; } = "元に戻す (&U)";
			public string Redo { get; set; } = "やり直し (&R)";
			public string URList { get; set; } = "変更履歴 (&L)";
			public string Cut { get; set; } = "切り取り (&T)";
			public string Copy { get; set; } = "コピー (&C)";
			public string Paste { get; set; } = "貼り付け (&P)";
			public string Delete { get; set; } = "削除 (&D)";
			public string Delete_UserNotice { get; set; } = "オブジェクトを削除しますか？";
			}

		

		public ApplicationText Application { get; set; } = new ApplicationText();
		public class ApplicationText
			{
			public string MessageBoxProjectCloseNotice { get; set; } = "プロジェクトを保存しますか？";
			}



		public DialogGeneralText DialogGeneral { get; set; } = new DialogGeneralText();
		public class DialogGeneralText
			{
			public string ButtonOK { get; set; } = "OK";
			public string ButtonApply { get; set; } = "適用";
			public string ButtonCancel { get; set; } = "キャンセル";
			}



		public MainFormText MainForm { get; set; } = new MainFormText();
		public class MainFormText
			{
			public string Text { get; set; } = "Waveguide Designer";
			public string TSMI_File { get; set; } = "ファイル (&F)";
			public string TSMI_CreateProject { get; set; } = "新規プロジェクト (&N)";
			public string TSMI_OpenProject { get; set; } = "プロジェクトを開く (&O)";
			public string TSMI_SaveProject { get; set; } = "プロジェクトを保存 (&S)";
			public string TSMI_SaveProjectWithNewName { get; set; } = "プロジェクトを別名で保存 (&A)";
			public string TSMI_CloseProject { get; set; } = "プロジェクトを閉じる (&C)";
			public string TSMI_Quit { get; set; } = "Waveguide Designerの終了 (&Q)";
			public string TSMI_Edit { get; set; } = "編集 (&E)";
			public string TSMI_View { get; set; } = "表示 (&V)";
			public string TSMI_Cad { get; set; } = "CAD (&C)";
			public string TSMI_Analysis { get; set; } = "解析 (&A)";
			public string TSMI_Simulate { get; set; } = "Meepでシミュレーション (&S)";
			public string TSMI_OutputCtlFile { get; set; } = "Meep用ctlファイルを作成 (&C)";
			public string TSMI_OutputShellScript { get; set; } = "Meep用シェルスクリプトを作成 (&S)";
			public string TSMI_Tools { get; set; } = "ツール (&T)";
			public string TSMI_Option { get; set; } = "オプション (&O)";
			public string TSMI_Help { get; set; } = "ヘルプ (&H)";
			public string TSMI_Version { get; set; } = "バージョン情報 (&V)";


			public string Dialog_OutputCtlFile { get; set; } = "ctlファイルの保存先";
			public string Dialog_WritingCtlFile { get; set; } = "ctlファイルを出力中";
			public string Dialog_WritedCtlFile { get; set; } = "ctlファイルの出力が完了しました。";
			public string Dialog_OutputShellScript { get; set; } = "スクリプトの保存先";
			public string Dialog_WritingShellScript { get; set; } = "スクリプトを出力中";
			public string Dialog_WritedShellScript { get; set; } = "スクリプトの出力が完了しました。";
			public string Dialog_FileSaveError { get; set; } = "ファイルの保存に失敗しました。";
			}



		public ProjectExplorerText ProjectExplorer { get; set; } = new ProjectExplorerText();
		public class ProjectExplorerText
			{
			public string Name { get; set; } = "プロジェクトエクスプローラ";
			public string NodeText_ProjectManifest { get; set; } = "シミュレーション設定";
			public string NodeText_GlobalRenderSetting { get; set; } = "グローバル描画設定";
			public string NodeText_GlobalStructureNumerics { get; set; } = "変数と関数";
			public string NodeText_Parameters { get; set; } = "変数";
			public string NodeText_Functions { get; set; } = "関数";
			public string NodeText_Layers { get; set; } = "レイヤリスト";
			public string NodeText_LayerProfile { get; set; } = "レイヤプロファイル";
			}



		public PropertyEditorText PropertyEditor { get; set; } = new PropertyEditorText();
		public class PropertyEditorText
			{
			public string Text { get; set; } = "プロパティエディタ";
			}



		public ManifestSettingDialogText ManifestSettingDialog { get; set; } = new ManifestSettingDialogText();
		public class ManifestSettingDialogText
			{
			public string Text { get; set; } = "シミュレーションの設定";
			public string GroupBoxGeneralSettings { get; set; } = "一般設定";
			public string LabelResolution { get; set; } = "解像度 [/μm]";
			public string LabelSimulationTime { get; set; } = "解析時間";
			public string LabelBackgoundMaterial { get; set; } = "背景材料";
			public string GroupBoxSimulationRegion { get; set; } = "解析領域";
			public string RadioButtonDim2D { get; set; } = "2D";
			public string RadioButtonDim3D { get; set; } = "3D";
			public string LabelMinX { get; set; } = "X最小値 [μm]";
			public string LabelMaxX { get; set; } = "X最大値 [μm]";
			public string LabelMinY { get; set; } = "Y最小値 [μm]";
			public string LabelMaxY { get; set; } = "Y最大値 [μm]";
			public string LabelMinZ { get; set; } = "Z最小値 [μm]";
			public string LabelMaxZ { get; set; } = "Z最大値 [μm]";
			public string LabelPml { get; set; } = "PML厚さ [μm]";
			public string TabPageSources { get; set; } = "光源";
			public string TabPageFluxAnalysis { get; set; } = "流束解析";
			public string TabPageVisualizationOutput { get; set; } = "電磁界成分分布画像";
			}



		public SourceEditorDialogText SourceEditorDialog { get; set; } = new SourceEditorDialogText();
		public class SourceEditorDialogText
			{
			public string Text { get; set; } = "光源の設定";
			public string LabelName { get; set; } = "名前";
			public string CheckBoxEnabled { get; set; } = "有効";
			public string LabelSourceType { get; set; } = "種別";
			public string LabelComponent { get; set; } = "成分";
			public string LabelCenter { get; set; } = "位置";
			public string LabelSize { get; set; } = "サイズ";
			public string LabelAmplitude { get; set; } = "強度";
			public string LabelWavelength { get; set; } = "波長 [nm]";
			public string LabelStartTime { get; set; } = "開始時間";
			public string LabelEndTime { get; set; } = "終了時間";
			public string LabelWidth { get; set; } = "有効時間幅";
			}



		public FluxAnalysisEditorDialogText FluxAnalysisEditoDialog { get; set; } = new FluxAnalysisEditorDialogText();
		public class FluxAnalysisEditorDialogText
			{
			public string Text { get; set; } = "流束解析の設定";
			public string LabelFluxDirection { get; set; } = "流束の向き";
			public string LabelCenter { get; set; } = "位置";
			public string LabelSize { get; set; } = "サイズ";
			}



		public VisualizationOutputEditorDialogText VisualizationOutputEditor { get; set; } = new VisualizationOutputEditorDialogText();
		public class VisualizationOutputEditorDialogText
			{
			public string Text { get; set; } = "電磁界成分分布画像の設定";
			public string LabelFluxComponent { get; set; } = "電磁界成分";
			public string LabelTimeStep { get; set; } = "時間間隔";
			public string LabelCenter { get; set; } = "位置";
			public string LabelSize { get; set; } = "サイズ";
			}



		public LayerSettingDialogText LayerSettingDialog { get; set; } = new LayerSettingDialogText();
		public class LayerSettingDialogText
			{
			public string Text { get; set; } = "レイヤの設定";
			public string LabelLayerName { get; set; } = "レイヤ名";
			public string GroupBoxMaterial { get; set; } = "媒質";
			public string ButtonMaterial { get; set; } = "媒質";
			public string LabelMaterialValue_Center { get; set; } = "位置 [um]";
			public string LabelMaterialValue_Size { get; set; } = "サイズ [um]";
			public string LabelMaterialValue_Index { get; set; } = "屈折率";
			public string GroupBoxRenderingStyle { get; set; } = "描画";
			public string ButtonBorderColor { get; set; } = "境界線の色";
			public string ButtonFillColor { get; set; } = "塗りつぶしの色";
			public string ButtonFillStyle { get; set; } = "塗りつぶしのスタイル";
			}



		public MaterialEditorGeneralText MaterialEditorGeneral { get; set; } = new MaterialEditorGeneralText();
		public class MaterialEditorGeneralText
			{
			public string LabelMaterial { get; set; } = "媒質種別";
			public string LabelCenter { get; set; } = "位置 [um]";
			public string LabelSize { get; set; } = "サイズ [um]";
			public string LabelMinZ { get; set; } = "Z最小値 [um]";
			public string LabelMaxZ { get; set; } = "Z最大値 [um]";
			public string LabelBackgroundName { get; set; } = "背景";
			}



		public MaterialSystemEditorDialogText MaterialSystemEditorDialog { get; set; } = new MaterialSystemEditorDialogText();
		public class MaterialSystemEditorDialogText
			{
			public string Text { get; set; } = "材料系の設定";
			public string TabPageStructure { get; set; } = "Z構造";
			public string TabPageMaterial { get; set; } = "材料";
			
			}




		public ProjectDataPropertyDescriptionText ProjectDataPropertyDescription { get; set; } = new ProjectDataPropertyDescriptionText();
		public class ProjectDataPropertyDescriptionText
			{
			public string WaveguideDesignerProjectData_SimulartionManifest { get; set; } = "シミュレーション設定";
			public string WaveguideDesignerProjectData_GlobalRenderSetting { get; set; } = "グローバル描画設定";
			public string WaveguideDesignerProjectData_GlobalStructureNumerics { get; set; } = "変数と関数";
			public string WaveguideDesignerProjectData_Layers { get; set; } = "レイヤリスト";
			public string ProjectManifestData_SimulationRegion { get; set; } = "シミュレーション領域";
			public string ProjectManifestData_SimulationTime { get; set; } = "シミュレーション時間";
			public string ProjectManifestData_Resolution { get; set; } = "解像度 [/um]";
			public string ProjectManifestData_BackGroundMaterial { get; set; } = "デフォルトのマテリアル";
			public string ProjectManifestData_FluxAnalyses { get; set; } = "流束解析";
			public string ProjectManifestData_VisualizationOutputs { get; set; } = "結果画像出力";
			public string SimulationRegionData_MinX { get; set; } = "X 最小値";
			public string SimulationRegionData_MaxX { get; set; } = "X 最大値";
			public string SimulationRegionData_MinY { get; set; } = "Y 最小値";
			public string SimulationRegionData_MaxY { get; set; } = "Y 最大値";
			public string SimulationRegionData_MinZ { get; set; } = "Z 最小値";
			public string SimulationRegionData_MaxZ { get; set; } = "Z 最大値";
			public string SimulationRegionData_Dimension { get; set; } = "次元";
			public string SimulationRegionData_PmlThickness { get; set; } = "PML膜厚";
			public string MaterialData_Name { get; set; } = "マテリアル名";
			public string MaterialData_Type { get; set; } = "種別";
			public string MaterialData_Index { get; set; } = "屈折率";
			public string MaterialData_Mu { get; set; } = "透磁率";
			public string FluxAnalysisData_FluxDirection { get; set; } = "流束の向き";
			public string FluxAnalysisData_Location { get; set; } = "解析範囲の位置";
			public string FluxAnalysisData_Size { get; set; } = "解析範囲のサイズ";
			public string VisualizationOutputData_Component { get; set; } = "出力対象の成分";
			public string VisualizationOutputData_TimeStep { get; set; } = "画像出力の時間ステップ";
			public string VisualizationOutputData_Location { get; set; } = "画像出力の中心位置";
			public string VisualizationOutputData_Size { get; set; } = "画像出力の範囲";
			public string GlobalRenderSettingData_BackgroundColor { get; set; } = "背景色";
			public string GlobalRenderSettingData_InvalidObjectBorder { get; set; } = "不正なオブジェクトの境界線";
			public string GlobalRenderSettingData_InvalidObjectFill { get; set; } = "不正なオブジェクトの塗りつぶし";
			public string GlobalRenderSettingData_DisabledObjectBorder { get; set; } = "無効なオブジェクトの境界線";
			public string GlobalRenderSettingData_DisabledObjectFill { get; set; } = "無効なオブジェクトの塗りつぶし";
			public string GlobalStructureNumericsData_Parameters { get; set; } = "変数";
			public string GlobalStructureNumericsData_Functions { get; set; } = "関数";
			public string ParameterData_Name { get; set; } = "変数名";
			public string ParameterData_Value { get; set; } = "変数の値";
			public string FunctionData_Name { get; set; } = "関数名";
			public string FunctionData_Variables { get; set; } = "引数のリスト";
			public string FunctionData_Expression { get; set; } = "関数表現";
			public string LayerData_Profile { get; set; } = "レイヤのプロファイル";
			public string LayerData_GeometricObjects { get; set; } = "オブジェクト";
			public string LayerProfileData_RenderSetting { get; set; } = "レイヤの描画設定";
			public string LayerProfileData_Material { get; set; } = "レイヤマテリアル";
			public string LayerProfileData_CenterZ { get; set; } = "レイヤマテリアルを配置するZ範囲の中心";
			public string LayerProfileData_SizeZ { get; set; } = "レイヤマテリアルを配置するZ範囲の幅";
			public string LayerRenderSetting_Visible { get; set; } = "レイヤの可視性";
			public string LayerRenderSetting_Border { get; set; } = "レイヤオブジェクトの境界線";
			public string LayerRenderSetting_Fill { get; set; } = "レイヤオブジェクトの塗りつぶし";
			public string GeometricObjectDataBase_State { get; set; } = "オブジェクトのステート";
			public string GeometricObjectDataBase_XOffset { get; set; } = "X座標オフセット";
			public string GeometricObjectDataBase_YOffset { get; set; } = "Y座標オフセット";
			public string PathStructureObjectData_PointNum { get; set; } = "分割点数";
			public string RectangleCoordinateFunctionalPathData_CenterX { get; set; } = "中心線X座標";
			public string RectangleCoordinateFunctionalPathData_CenterY { get; set; } = "中心線Y座標";
			public string RectangleCoordinateFunctionalPathData_LeftWingWidth { get; set; } = "左翼幅";
			public string RectangleCoordinateFunctionalPathData_RightWingWidth { get; set; } = "右翼幅";
			public string PolarCoordinateFunctionalPathData_CenterX { get; set; } = "中心線動径";
			public string PolarCoordinateFunctionalPathData_CenterY { get; set; } = "中心線偏角";
			public string PolarCoordinateFunctionalPathData_LeftWingWidth { get; set; } = "左翼幅";
			public string PolarCoordinateFunctionalPathData_RightWingWidth { get; set; } = "右翼幅";
			public string CoordinateListPathData_Centers { get; set; } = "中心線座標リスト";
			public string CoordinateListPathData_LeftWingWidths { get; set; } = "左翼幅リスト";
			public string CoordinateListPathData_RightWingWidths { get; set; } = "右翼幅リスト";
			//public string ProjectDataPropertyDescription_ { get; set; }
			//public string ProjectDataPropertyDescription_ { get; set; }
			//public string ProjectDataPropertyDescription_ { get; set; }
			//public string ProjectDataPropertyDescription_ { get; set; }
			//public string ProjectDataPropertyDescription_ { get; set; }
			//public string ProjectDataPropertyDescription_ { get; set; }
			//public string ProjectDataPropertyDescription_ { get; set; }
			//public string ProjectDataPropertyDescription_ { get; set; }
			//public string ProjectDataPropertyDescription_ { get; set; }
			}

#pragma warning restore 1591





		/// <summary>デフォルトの言語パック。</summary>
		public static LanguagePack DefaultLanguage { get { return _DefaultLanguage; } }
		private static readonly LanguagePack _DefaultLanguage = new LanguagePack();



		/// <summary>アクセスキー指定などのシステム記号テキストを除外したプレーンテキストを作成する。</summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string MakePlainString(String str)
			{
			return Regex.Replace( str, @"\s*\(&\w\)", "" ).Replace( "&", "" );
			}
		}




	/// <summary>言語パックでUndoRedoPairをサポートするためのクラス。</summary>
	public class UndoRedoPairString
		{
		/// <summary></summary>
		public string Name { get; set; }
		/// <summary></summary>
		public string Mess { get; set; }

		/// <summary></summary>
		public UndoRedoPairString(string name) : this( name, "" ) { }

		/// <summary></summary>
		public UndoRedoPairString(string name, string message)
			{
			Name = name;
			Mess = message;
			}
		}
	}
