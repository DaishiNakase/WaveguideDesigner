using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hslab.MeepManager.WaveguideDesigner;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	/// <summary>画像出力情報のプロジェクトデータ。</summary>
	public class VisualizationOutputData : ProjectDataBase
		{
		/// <summary>出力する成分。</summary>
		[PropertyEditorAttribute( 0 )]
		public FluxComponent Component
			{
			get { return _Component; }
			set { _Component = value; }
			}
		private FluxComponent _Component;



		/// <summary>出力時間幅。</summary>
		[PropertyEditorAttribute( 1 )]
		public double TimeStep
			{
			get { return _TimeStep; }
			set
				{
				if( value > 0 ) _TimeStep = value;
				}
			}
		private double _TimeStep;



		/// <summary>出力範囲の位置。</summary>
		[PropertyEditor( 2 )]
		public Vector3 Center
			{
			get { return _Center; }
			set { _Center = value; }
			}
		private Vector3 _Center;



		/// <summary></summary>
		[PropertyEditor( 3 )]
		public Vector3 Size
			{
			get { return _Size; }
			set { _Size = value; }
			}
		private Vector3 _Size;



		/// <summary>デフォルトコンストラクタ。</summary>
		public VisualizationOutputData()
			{
			Component = FluxComponent.Ez;
			_TimeStep = 1;
			Center = new Vector3();
			Size = new Vector3();
			}



		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public VisualizationOutputData(VisualizationOutputData previous)
			{
			Component = previous.Component;
			TimeStep = previous.TimeStep;
			Center = previous.Center;
			Size = previous.Size;
			}



		#region methods

		/// <summary>Meepのステップファンクションを生成する。</summary>
		/// <returns></returns>
		public virtual List<MeepStepFunction> MakeMeepStepFunction()
			{
			List<MeepStepFunction> res = new List<MeepStepFunction>();
			Component com;
			switch( Component )
				{
				case FluxComponent.Ex: com = MeepManager.WaveguideDesigner.Component.Ex; break;
				case FluxComponent.Ey: com = MeepManager.WaveguideDesigner.Component.Ey; break;
				case FluxComponent.Ez: com = MeepManager.WaveguideDesigner.Component.Ez; break;
				case FluxComponent.Hx: com = MeepManager.WaveguideDesigner.Component.Hx; break;
				case FluxComponent.Hy: com = MeepManager.WaveguideDesigner.Component.Hy; break;
				case FluxComponent.Hz: com = MeepManager.WaveguideDesigner.Component.Hz; break;
				default: return res;
				}

			MeepStepFunction atBeginning, inVolume, atEvery;

			atBeginning = MeepStepFunction.AtBeginning( new[] { MeepStepFunction.OutputEpsilon() } );
			atEvery = MeepStepFunction.AtEvery( TimeStep, new[] { MeepStepFunction.OutputFieldComponent( com ) } );
			inVolume = MeepStepFunction.InVolume( new MeepVolume( Center, Size ), new[] { atBeginning, atEvery } );
			res.Add( inVolume );
			return res;
			}



		public override string GetDescription()
			{
			string res = "";
			res += "time step : " + TimeStep + "\r\n";
			res += "location  : " + Center + "\r\n";
			res += "size      : " + Size + "\r\n";
			return res;
			}


		#endregion
		}

	}
