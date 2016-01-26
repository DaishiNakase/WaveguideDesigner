using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Collections;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	public class CommonRenderSettings
		{
		public GlobalRenderingSettingData GlobalRenderSetting
			{
			get { return _GlobalRenderSetting ?? new GlobalRenderingSettingData(); }
			private set { _GlobalRenderSetting = value; }
			}
		private GlobalRenderingSettingData _GlobalRenderSetting = null;

		public List<LayerRenderSettingData> LayerRenderSettings { get; set; }



		public CommonRenderSettings()
			{
			LayerRenderSettings = new List<LayerRenderSettingData>();
			}



		public void WriteXml(string filepath)
			{
			XmlSerializer ser = new XmlSerializer( typeof( CommonRenderSettings ) );
			using( StreamWriter sw = new StreamWriter( filepath ) )
				{
				ser.Serialize( sw, this );
				}

			}



		public static CommonRenderSettings ReadXml(string filepath)
			{
			XmlSerializer ser = new XmlSerializer( typeof( CommonRenderSettings ) );
			using( StreamReader sr = new StreamReader( filepath ) )
				{
				return ser.Deserialize( sr ) as CommonRenderSettings;
				}
			}



		public LayerRenderSettingData GetLayerRenderSettingData(int index)
			{
			return LayerRenderSettings.Count != 0 ? LayerRenderSettings[index % LayerRenderSettings.Count] : new LayerRenderSettingData();
			}



		}
	}
