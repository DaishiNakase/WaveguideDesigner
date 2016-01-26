using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hslab.VirtualStructure;
using System.Drawing;
using System.Xml.Serialization;

namespace Hslab.WaveguideDesigner.ProjectData
	{

	/// <summary>レイヤープロファイル情報のプロジェクト</summary>
	public class LayerProfileData : ProjectDataBase
		{

		#region project data properties

		/// <summary>描画設定。</summary>
		[PropertyEditorAttribute( 0 )]
		public LayerRenderSettingData RenderSetting
			{
			get { return _RenderSetting; }
			set
				{
				if( _RenderSetting != null ) _RenderSetting.Parent = null;
				_RenderSetting = value;
				value.Parent = this;
				}
			}
		private LayerRenderSettingData _RenderSetting;

		/// <summary>レイヤー材料。</summary>
		[PropertyEditorAttribute( 1 )]
		public MaterialData Material
			{
			get { return _Material; }
			set
				{
				if((Parent?.Parent as WaveguideDesignerProjectData)!=null)
					{
					if( !( Parent.Parent as WaveguideDesignerProjectData ).Materials.Contains( value ) )
						( Parent.Parent as WaveguideDesignerProjectData ).Materials.Add( value );
					}
				_Material = value;
				}
			}
		private MaterialData _Material;



		/// <summary>レイヤー材料が存在するZ範囲の中心。</summary>
		[PropertyEditorAttribute( 2 )]
		public double CenterZ { get; set; }



		/// <summary>レイヤー材料が存在するZ範囲の幅。</summary>
		[PropertyEditorAttribute( 3 )]
		public double SizeZ { get; set; }

		#endregion




		#region runtime utility properties

		/// <summary>描画情報を書き込むためのVirtualLayer参照。</summary>
		[XmlIgnore]
		public VirtualLayer VirtualLayer
			{
			get
				{
				LayerData layer = Parent as LayerData;
				return layer?.VirtualLayer;
				}
			}

		/// <summary>レイヤー材料が存在するZ範囲の最低位置。</summary>
		[XmlIgnore]
		public double MinZ
			{
			get { return CenterZ - SizeZ / 2.0; }
			set { SetZ( value, MaxZ ); }
			}

		/// <summary>レイヤー材料が存在するZ範囲の最高位置。</summary>
		[XmlIgnore]
		public double MaxZ
			{
			get { return CenterZ + SizeZ / 2.0; }
			set { SetZ( MinZ, value ); }
			}


		#endregion





		/// <summary>デフォルトコンストラクタ。</summary>
		public LayerProfileData()
			{
			RenderSetting = new LayerRenderSettingData();
			Material = new MaterialData();
			MinZ = -1;
			MaxZ = 1;
			}

		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public LayerProfileData(LayerProfileData previous)
			{
			RenderSetting = new LayerRenderSettingData( previous.RenderSetting );
			Material = previous.Material;
			CenterZ = previous.CenterZ;
			SizeZ = previous.SizeZ;
			}





		private void SetZ(double min, double max)
			{
			CenterZ = ( max + min ) / 2.0;
			SizeZ = max - min;
			}

		}


	}
