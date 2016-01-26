using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using System.IO;
using Hslab.VirtualStructure;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	/// <summary>シミュレーション設定情報のプロジェクトデータ。</summary>
	public class ProjectManifestData : ProjectDataBase
		{
		#region static properties

		[XmlIgnore]
		public const double MinimumSimulationTime = 0.01;

		#endregion



		#region project data properties

		/// <summary>解析範囲。</summary>
		[PropertyEditorAttribute( 0 )]
		public SimulationRegionData SimulationRegion
			{
			get { return _SimulationRegion; }
			set
				{
				if( _SimulationRegion != null )
					{
					foreach( VirtualShapeBase shape in _SimulationRegion.Shapes )
						ManifestVisualizingLayer.Shapes.Remove( shape );
					_SimulationRegion.Parent = null;
					}

				_SimulationRegion = value;
				ManifestVisualizingLayer.Shapes.AddRange( value.Shapes );
				value.Parent = this;
				}
			}
		private SimulationRegionData _SimulationRegion;



		/// <summary>解析時間。</summary>
		[PropertyEditorAttribute( 1, true )]
		public double SimulationTime
			{
			get { return _SimulationTime; }
			set { _SimulationTime = Math.Max( MinimumSimulationTime, value ); }
			}
		private double _SimulationTime;



		/// <summary>解像度[/um]</summary>
		[PropertyEditorAttribute( 2, true )]
		public double Resolution
			{
			get { return _Resolution; }
			set
				{
				if( value > 0 ) _Resolution = value;
				}
			}
		private double _Resolution;



		/// <summary>背景材料。</summary>
		[PropertyEditorAttribute( 3 )]
		public MaterialData BackgroundMaterial
			{
			get { return _BackgroundMaterial; }
			set
				{
				if( ( Parent as WaveguideDesignerProjectData ) != null )
					if( !( Parent as WaveguideDesignerProjectData ).Materials.Contains( value ) )
						{
						( Parent as WaveguideDesignerProjectData ).Materials.Add( value );
						}
				_BackgroundMaterial = value;
				}
			}
		private MaterialData _BackgroundMaterial;



#warning 新しいSourceのXmlArryItemを追加すること
		/// <summary>光源。</summary>
		[PropertyEditorAttribute( 4 ),
		XmlArrayItem( typeof( SourceData ) )]
		public ProjectList<SourceData> Sources
			{
			get { return _Sources; }
			private set
				{
				_Sources = value;

				value.ItemInserted += (obj, e) =>
					{
						e.Item.Parent = this;
						ManifestVisualizingLayer.Shapes.Add( e.Item.VirtualShape );
					};
				value.ItemSet += (obj, e) =>
					{
						e.NewItem.Parent = this;
						ManifestVisualizingLayer.Shapes.Add( e.NewItem.VirtualShape );
						e.OldItem.Parent = null;
						ManifestVisualizingLayer.Shapes.Remove( e.OldItem.VirtualShape );
					};
				value.ItemRemoved += (obj, e) =>
					{
						e.Item.Parent = null;
						ManifestVisualizingLayer.Shapes.Remove( e.Item.VirtualShape );
					};
				value.ItemsCleared += (obj, e) =>
					{
						foreach( SourceData src in e.Items )
							{
							src.Parent = null;
							ManifestVisualizingLayer.Shapes.Remove( src.VirtualShape );
							}
					};
				}
			}
		private ProjectList<SourceData> _Sources;



		/// <summary>流束解析情報のリスト。</summary>
		[PropertyEditorAttribute( 5 )]
		public ProjectList<FluxAnalysisData> FluxAnalyses
			{
			get { return _FluxAnalyses; }
			private set
				{
				_FluxAnalyses = value;

				value.ItemInserted += (obj, e) => { e.Item.Parent = this; };
				value.ItemSet += (obj, e) =>
					{
						e.NewItem.Parent = this;
						e.OldItem.Parent = null;

					};
				value.ItemRemoved += (obj, e) => { e.Item.Parent = null; };
				value.ItemsCleared += (obj, e) => { foreach( FluxAnalysisData l in e.Items ) l.Parent = null; };
				}
			}
		private ProjectList<FluxAnalysisData> _FluxAnalyses;



		/// <summary>画像出力の設定。</summary>
		[PropertyEditorAttribute( 6 )]
		public ProjectList<VisualizationOutputData> VisualizationOutputs
			{
			get { return _VisualizationOutputs; }
			private set
				{
				_VisualizationOutputs = value;

				value.ItemInserted += (obj, e) => { if( e.Item != null ) e.Item.Parent = this; };
				value.ItemSet += (obj, e) =>
					{
						e.NewItem.Parent = this;
						e.OldItem.Parent = null;
					};
				value.ItemRemoved += (obj, e) => { e.Item.Parent = null; };
				value.ItemsCleared += (obj, e) => { foreach( VisualizationOutputData l in e.Items ) l.Parent = null; };
				}
			}
		private ProjectList<VisualizationOutputData> _VisualizationOutputs;

		#endregion



		#region runtime utility properties

		/// <summary>シミュレーション設定の可視化用レイヤ。</summary>
		[XmlIgnore]
		public VirtualLayer ManifestVisualizingLayer
			{
			get { return _MainifestVisualizingLayer; }
			private set
				{
				_MainifestVisualizingLayer = value;
				}
			}
		private VirtualLayer _MainifestVisualizingLayer;

		#endregion





		#region constructors

		/// <summary>デフォルトコンストラクタ。</summary>
		public ProjectManifestData()
			{
			ManifestVisualizingLayer = new VirtualLayer();

			SimulationRegion = new SimulationRegionData();
			SimulationTime = 0;
			Resolution = 10;
			BackgroundMaterial = new MaterialData();
			Sources = new ProjectList<SourceData>();
			FluxAnalyses = new ProjectList<FluxAnalysisData>();
			VisualizationOutputs = new ProjectList<VisualizationOutputData>();

			SimulationRegion.Parent = this;
			BackgroundMaterial.Parent = this;
			}



		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public ProjectManifestData(ProjectManifestData previous)
			{
			ManifestVisualizingLayer = new VirtualLayer();

			_SimulationRegion = new SimulationRegionData( previous.SimulationRegion );
			SimulationTime = previous.SimulationTime;
			Resolution = previous.Resolution;
			_BackgroundMaterial = new MaterialData( previous.BackgroundMaterial );

			Sources = new ProjectList<SourceData>();
			foreach( SourceData src in previous.Sources )
				Sources.Add( src.MakeDeepCopy() );

			FluxAnalyses = new ProjectList<FluxAnalysisData>( previous.FluxAnalyses );
			foreach( FluxAnalysisData flx in previous.FluxAnalyses )
				FluxAnalyses.Add( new FluxAnalysisData( flx ) );

			VisualizationOutputs = new ProjectList<VisualizationOutputData>( previous.VisualizationOutputs );
			foreach( VisualizationOutputData vis in previous.VisualizationOutputs )
				VisualizationOutputs.Add( new VisualizationOutputData( vis ) );

			ManifestVisualizingLayer.Shapes.AddRange( SimulationRegion.Shapes );
			SimulationRegion.Parent = this;
			BackgroundMaterial.Parent = this;
			}

		#endregion



		#region methods

		/// <summary>シミュレーション設定の可視化を更新する。</summary>
		public void RefreshVisualization()
			{
			ManifestVisualizingLayer.Shapes.Clear();
			SimulationRegion.UpdateVirtualShape();
			foreach(SourceData src in Sources)
				{
				src.UpdateVirtualShape();
				}
			}

		#endregion
		}
	}
