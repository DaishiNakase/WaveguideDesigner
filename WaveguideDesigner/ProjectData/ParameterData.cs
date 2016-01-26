using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	/// <summary>変数情報のプロジェクトデータ。</summary>
	public class ParameterData : NamedDataBase,IMathematicalData
		{
		/// <summary>変数の値。</summary>
		[PropertyEditorAttribute( 1 ,true)]
		public double Value { get; set; }

		/// <summary>デフォルトコンストラクタ。</summary>
		public ParameterData()
			{
			Name = "NewParameter";
			Value = 0;
			}


		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public ParameterData(ParameterData previous):base(previous)
			{
			Value = previous.Value;
			}
		}


	}
