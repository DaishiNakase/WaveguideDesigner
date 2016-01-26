using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using System.IO;

namespace Hslab.WaveguideDesigner.ProjectData
	{



	/// <summary>プロジェクト全体に作用する構造用変数および関数を格納するプロジェクトデータ。</summary>
	public class GlobalStructureNumericsData : ProjectDataBase
		{
		#region project data properties

		/// <summary>変数リスト。</summary>
		[PropertyEditorAttribute( 0 )]
		public ProjectList<ParameterData> Parameters
			{
			get { return _Parameters; }
			private set
				{
				_Parameters = value;

				value.ItemInserted += (obj, e) => { e.Item.Parent = this; };
				value.ItemSet += (obj, e) =>
				{
					e.NewItem.Parent = this;
					e.OldItem.Parent = null;

				};
				value.ItemRemoved += (obj, e) => { e.Item.Parent = null; };
				value.ItemsCleared += (obj, e) => { foreach( ParameterData p in e.Items ) p.Parent = null; };
				}
			}
		private ProjectList<ParameterData> _Parameters;



		/// <summary>ユーザー定義関数リスト。</summary>
		[PropertyEditorAttribute( 1 )]
		public ProjectList<FunctionData> Functions
			{
			get { return _Functions; }
			private set
				{
				_Functions = value;

				value.ItemInserted += (obj, e) => { e.Item.Parent = this; };
				value.ItemSet += (obj, e) =>
				{
					e.NewItem.Parent = this;
					e.OldItem.Parent = null;

				};
				value.ItemRemoved += (obj, e) => { e.Item.Parent = null; };
				value.ItemsCleared += (obj, e) => { foreach( FunctionData p in e.Items ) p.Parent = null; };
				}
			}
		private ProjectList<FunctionData> _Functions;

		#endregion



		#region constructors

		/// <summary>デフォルトコンストラクタ。</summary>
		public GlobalStructureNumericsData()
			{
			Parameters = new ProjectList<ParameterData>();
			Functions = new ProjectList<FunctionData>();
			}

		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public GlobalStructureNumericsData(GlobalStructureNumericsData previous)
			{
			Parameters = new ProjectList<ParameterData>( previous.Parameters );
			Functions = new ProjectList<FunctionData>( previous.Functions );
			}

		#endregion



		#region methods


		#endregion

		}


	}
