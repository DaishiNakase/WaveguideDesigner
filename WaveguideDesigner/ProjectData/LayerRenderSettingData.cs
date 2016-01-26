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
	/// <summary>描画設定情報のプロジェクトデータ。</summary>
	public class LayerRenderSettingData : ProjectDataBase
		{
		#region project data properties

		/// <summary>可視状態ならtrue。</summary>
		[PropertyEditorAttribute( 0 )]
		public bool Visible
			{
			get { return _Visible; }
			set
				{
				_Visible = value;
				if( VirtualLayer != null )
					VirtualLayer.Visible = value;
				}
			}
		private bool _Visible;

		/// <summary>境界線。</summary>
		[PropertyEditorAttribute( 1 )]
		public PenEx Border
			{
			get { return _Border; }
			set
				{
				_Border = value;
				if( VirtualLayer != null )
					VirtualLayer.DefaultShapeBorder = value;
				}
			}
		private PenEx _Border;

		/// <summary>塗りつぶし。</summary>
		[PropertyEditorAttribute( 2 )]
		public HatchBrushEx Fill
			{
			get { return _Fill; }
			set
				{
				_Fill = value;
				if( VirtualLayer != null )
					VirtualLayer.DefaultShapeFill = value;
				}
			}
		private HatchBrushEx _Fill;

		#endregion

		#region runtime utility properties

		/// <summary>描画情報を書き込むためのVirtualLayer参照。</summary>
		[System.Xml.Serialization.XmlIgnore]
		public VirtualLayer VirtualLayer
			{
			get { return ( Parent?.Parent as LayerData )?.VirtualLayer; }
			}

		#endregion


		/// <summary>デフォルトコンストラクタ。</summary>
		public LayerRenderSettingData()
			{
			Visible = true;
			Border = Pens.White;
			Fill = new HatchBrush( HatchStyle.Percent25, Color.White );
			}

		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public LayerRenderSettingData(LayerRenderSettingData previous)
			{
			Visible = previous.Visible;
			Border = new PenEx( previous.Border );
			Fill = new HatchBrushEx( previous.Fill );
			}
		}

	}
