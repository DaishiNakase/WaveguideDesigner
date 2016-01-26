using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	/// <summary>全体の描画情報のプロジェクトデータ。</summary>
	public class GlobalRenderingSettingData : ProjectDataBase
		{

		/// <summary>背景色。</summary>
		[PropertyEditorAttribute( 0 )]
		public ColorEx BackgroundColor { get; set; }

		/// <summary>選択されているオブジェクトの描画境界。</summary>
		[PropertyEditorAttribute( 1 )]
		public PenEx SelectedObjectBorder { get; set; }

		/// <summary>選択されているオブジェクトの塗りつぶし。</summary>
		[PropertyEditorAttribute( 2 )]
		public HatchBrushEx SelectedObjectFill { get; set; }
		/// <summary>不正なオブジェクトの描画境界。</summary>
		/// 
		[PropertyEditorAttribute( 3 )]
		public PenEx InvalidObjectBorder { get; set; }

		/// <summary>不正なオブジェクトの塗りつぶし。</summary>
		[PropertyEditorAttribute( 4 )]
		public HatchBrushEx InvalidObjectFill { get; set; }

		/// <summary>無効化中のオブジェクトの描画境界。</summary>
		[PropertyEditorAttribute( 5 )]
		public PenEx DisabledObjectBorder { get; set; }

		/// <summary>無効化中のオブジェクトの塗りつぶし。</summary>
		[PropertyEditorAttribute( 6 )]
		public HatchBrushEx DisabledObjectFill { get; set; }

		



		/// <summary>デフォルトコンストラクタ。</summary>
		public GlobalRenderingSettingData()
			{
			BackgroundColor = new ColorEx( 255, 0, 0, 0 );
			SelectedObjectBorder = Pens.Yellow;
			SelectedObjectFill = new HatchBrush( HatchStyle.Percent25, Color.Yellow );
			InvalidObjectBorder = Pens.Red;
			InvalidObjectFill = new HatchBrush( HatchStyle.Percent25, Color.Red );
			DisabledObjectBorder = Pens.Gray;
			DisabledObjectFill = new HatchBrush( HatchStyle.Percent25, Color.Gray );
			}



		/// <summary></summary>
		public GlobalRenderingSettingData(GlobalRenderingSettingData previous)
			{
			BackgroundColor = new ColorEx( previous.BackgroundColor );
			SelectedObjectBorder = new PenEx( previous.SelectedObjectBorder );
			SelectedObjectFill = new HatchBrushEx( previous.SelectedObjectFill );
			InvalidObjectBorder = new PenEx( previous.InvalidObjectBorder );
			InvalidObjectFill = new HatchBrushEx( previous.InvalidObjectFill );
			DisabledObjectBorder = new PenEx( previous.DisabledObjectBorder );
			DisabledObjectFill = new HatchBrushEx( previous.DisabledObjectFill );
			}
		}
	}
