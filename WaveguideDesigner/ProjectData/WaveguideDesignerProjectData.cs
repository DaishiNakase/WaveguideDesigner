using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using System.IO;
using Hslab.VirtualStructure;
using System.Collections.ObjectModel;
using Hslab.MeepManager.WaveguideDesigner;

namespace Hslab.WaveguideDesigner.ProjectData
	{

	/// <summary>プロジェクトデータのデータ構造のトップレベル。</summary>
	public class WaveguideDesignerProjectData : NamedDataBase
		{
		#region project data properties

		/// <summary>
		/// ProjectManifestはUndoRedoPairを生成しない。
		/// </summary>
		[PropertyEditorAttribute( 1 )]
		public ProjectManifestData ProjectManifest
			{
			get { return _ProjectManifest; }
			set
				{
				if( _ProjectManifest != null )
					{
					_ProjectManifest.Parent = null;
					VirtualGraphics.Layers.Remove( _ProjectManifest.ManifestVisualizingLayer );
					}
				_ProjectManifest = value;
				if( !Materials.Contains( value.BackgroundMaterial ) )
					Materials.Add( value.BackgroundMaterial );
				value.Parent = this;
				VirtualGraphics.Layers.AlwaysTopLayer = value.ManifestVisualizingLayer;
				value.RefreshVisualization();
				}
			}
		private ProjectManifestData _ProjectManifest;



		/// <summary></summary>
		[PropertyEditorAttribute( 2 )]
		public GlobalRenderingSettingData GlobalRenderingSetting
			{
			get { return _GlobalRenderingSetting; }
			set
				{
				if( _GlobalRenderingSetting != null ) _GlobalRenderingSetting.Parent = null;
				_GlobalRenderingSetting = value;
				value.Parent = this;
				}
			}
		private GlobalRenderingSettingData _GlobalRenderingSetting;



		/// <summary>プロジェクト全体に作用する構造用変数および関数。</summary>
		[PropertyEditorAttribute( 3 )]
		public GlobalStructureNumericsData GlobalStructureNumerics
			{
			get { return _GlobalStructureNumerics; }
			set
				{
				if( _GlobalStructureNumerics != null ) _GlobalStructureNumerics.Parent = null;
				_GlobalStructureNumerics = value;
				value.Parent = this;
				}
			}
		private GlobalStructureNumericsData _GlobalStructureNumerics;


		public MaterialList Materials
			{
			get { return _Materials; }
			private set
				{
				_Materials = value;
				value.ItemInserted += (obj, e) =>
				{
					e.Item.Parent = this;
				};
				value.ItemSet += (obj, e) =>
				{
					e.NewItem.Parent = this;
					e.OldItem.Parent = null;
				};
				value.ItemRemoved += (obj, e) =>
				{
					e.Item.Parent = null;
				};
				value.ItemsCleared += (obj, e) =>
				{
					foreach( MaterialData m in e.Items )
						{
						m.Parent = null;
						}
				};
				}
			}
		private MaterialList _Materials;


		/// <summary>レイヤー情報。</summary>
		[PropertyEditorAttribute( 5 )]
		public LayerList Layers
			{
			get { return _Layers; }
			private set
				{
				_Layers = value;
				value.ItemInserted += (obj, e) =>
					{
						VirtualGraphics.Layers.Add( e.Item.VirtualLayer );
						if( !Materials.Contains( e.Item.Profile.Material ) )
							Materials.Add( e.Item.Profile.Material );
						e.Item.Parent = this;
					};
				value.ItemSet += (obj, e) =>
					{
						VirtualGraphics.Layers.Add( e.NewItem.VirtualLayer );
						if( !Materials.Contains( e.Item.Profile.Material ) )
							Materials.Add( e.Item.Profile.Material );
						e.NewItem.Parent = this;
						VirtualGraphics.Layers.Remove( e.OldItem.VirtualLayer );
						e.OldItem.Parent = null;
					};
				value.ItemRemoved += (obj, e) =>
					{
						VirtualGraphics.Layers.Remove( e.Item.VirtualLayer );
						e.Item.Parent = null;
					};
				value.ItemsCleared += (obj, e) =>
					{
						foreach( LayerData l in e.Items )
							{
							VirtualGraphics.Layers.Remove( l.VirtualLayer );
							l.Parent = null;
							}
					};
				}
			}
		private LayerList _Layers;

		#endregion



		#region runtime utility properties

		/// <summary>存在する全てのプロジェクト。</summary>
		[XmlIgnore]
		public static ReadOnlyCollection<WaveguideDesignerProjectData> Projects
			{ get { return new ReadOnlyCollection<WaveguideDesignerProjectData>( _Projects ); } }
		private static List<WaveguideDesignerProjectData> _Projects = new List<WaveguideDesignerProjectData>();



		/// <summary>プロジェクトのバーチャルレイヤ。</summary>
		[XmlIgnore]
		public VirtualGraphics VirtualGraphics { get; private set; }



		/// <summary>登録済み構造オブジェクトのリスト。</summary>
		[XmlIgnore]
		public ReadOnlyCollection<GeometricObjectDataBase> GeometricObjects
			{
			get
				{
				List<GeometricObjectDataBase> list = new List<GeometricObjectDataBase>();
				foreach( LayerData layer in Layers )
					list.AddRange( layer.GeometricObjects );
				return new ReadOnlyCollection<GeometricObjectDataBase>( list );
				}
			}

		#endregion



		#region constructors

		/// <summary>デフォルトコンストラクタ。</summary>
		public WaveguideDesignerProjectData()
			{
			VirtualGraphics = new VirtualGraphics();

			Name = "New Project";
			Layers = new LayerList();
			Materials = new MaterialList();
			ProjectManifest = new ProjectManifestData();
			GlobalRenderingSetting = new GlobalRenderingSettingData();
			GlobalStructureNumerics = new GlobalStructureNumericsData();

			_Projects.Add( this );
			}



		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public WaveguideDesignerProjectData(WaveguideDesignerProjectData previous) : base( previous )
			{
			VirtualGraphics = new VirtualGraphics();

			Layers = new LayerList( previous.Layers );
			Materials = new MaterialList( previous.Materials );
			ProjectManifest = new ProjectManifestData( previous.ProjectManifest );
			GlobalRenderingSetting = new GlobalRenderingSettingData( previous.GlobalRenderingSetting );
			GlobalStructureNumerics = new GlobalStructureNumericsData( previous.GlobalStructureNumerics );

			_Projects.Add( this );
			}



		// デストラクタ。
		~WaveguideDesignerProjectData()
			{
			_Projects.Remove( this );
			}

		#endregion



		#region methods

		/// <summary>プロジェクトデータをファイルに書き込む。</summary>
		public void WriteProjectFile(string filename)
			{
			XmlSerializer ser = null;
			try
				{
				ser = new XmlSerializer( typeof( WaveguideDesignerProjectData ) );
				}
			catch
				{ }
			StreamWriter sw = new StreamWriter( filename, false, new UTF8Encoding( false ) );
			ser?.Serialize( sw, this );
			sw.Close();
			}



		/// <summary>プロジェクトデータをファイルから読み込む。</summary>
		public static WaveguideDesignerProjectData ReadProjectFile(string filename)
			{
			WaveguideDesignerProjectData res=null;
			XmlSerializer ser = null;
			try
				{
				ser = new XmlSerializer( typeof( WaveguideDesignerProjectData ) );
				}
			catch { }
			StreamReader sr = new StreamReader( filename, new UTF8Encoding( false ) );
			res = (WaveguideDesignerProjectData)ser?.Deserialize( sr );
			return res;
			}



		/// <summary>CTLファイルを出力する。</summary>
		/// <param name="filename"></param>
		/// <param name="eHandler"></param>
		public void WriteCtlFile(string filename, EngineBase.LogTextOutputEventHandler eHandler)
			{
			EngineBase engine = CreateReadySimulationEngine();
			engine.LogTextOutput += eHandler;
			engine.CreateCtlFile( filename );
			}



		/// <summary>Meepシミュレーション用のシェルスクリプトを出力する。</summary>
		/// <param name="file"></param>
		public void WriteShellScriptFile(string file)
			{

			}



		/// <summary>解析情報の準備を整えたMeepシミュレーションエンジンを生成する。</summary>
		/// <returns></returns>
		public EngineBase CreateReadySimulationEngine()
			{
			SimpleEngine engine = new SimpleEngine();

			engine.DefaultMaterial = ProjectManifest.BackgroundMaterial.MeepMaterial;
			engine.GeometricLattice = new MeepLattice( ProjectManifest.SimulationRegion.Size );
			foreach( SourceData src in ProjectManifest.Sources )
				engine.Sources.AddRange( src.MakeMeepSource() );
			foreach( GeometricObjectDataBase obj in GeometricObjects )
				engine.Geometry.AddRange( obj.MakeMeepGeometricObject() );
			engine.GlobalShift = -ProjectManifest.SimulationRegion.Center;
			engine.PmlLayers.Add( new MeepPml( ProjectManifest.SimulationRegion.PmlThickness ) );
			engine.Resolution = ProjectManifest.Resolution;
			MeepRunFunction run = MeepRunFunction.RunUntil( ProjectManifest.SimulationTime );
			foreach( VisualizationOutputData vis in ProjectManifest.VisualizationOutputs )
				run.StepFunctions.AddRange( vis.MakeMeepStepFunction() );
			engine.RunFunction = run;

			return engine;
			}

		#endregion




		}

	}
