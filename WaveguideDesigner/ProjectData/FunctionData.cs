using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hslab.MathExpression;
using System.Text.RegularExpressions;

namespace Hslab.WaveguideDesigner.ProjectData
	{

	/// <summary>ユーザー定義関数情報のプロジェクトデータ。</summary>
	public class FunctionData : NamedDataBase, IMathematicalData
		{
		/// <summary>関数の実際の式表現。</summary>
		[PropertyEditorAttribute( 1, true )]
		public string Expression { get; set; }




		/// <summary>デフォルトコンストラクタ。</summary>
		public FunctionData()
			{
			Name = "NewFunc";
			Expression = "0";
			}


		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public FunctionData(FunctionData previous) : base( previous )
			{
			Expression = previous.Expression;
			}




		internal MathFunction GetMathFunction()
			{
			string f = "";
			string[] args = null;
			Regex regex = new Regex( @"([a-zA-Z_]\w*)\s*\((\s*(?:[a-zA-Z_]\w*)?(?:\s*,\s*[a-zA-Z_]\w*)*\s*)\)" );
			Match match = regex.Match( Name );
			if( string.IsNullOrWhiteSpace( match.Value ) )
				return new MathFunction( "InvalidFunction", new string[] { }, "0" );
			f = match.Groups[1].Value;
			args = match.Groups[2].Value.Split( new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries );
			return new MathFunction( f, args, Expression );
			}
		}



	public interface IMathematicalData { }
	}
