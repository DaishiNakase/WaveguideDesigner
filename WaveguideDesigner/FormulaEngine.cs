using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Text.RegularExpressions;


namespace Hslab.MathExpression
	{
	/// <summary>数値計算エンジン。内部的にIronPythonを利用。</summary>
	public class FormulaEngine : IDisposable
		{
		/// <summary>IronPythonのmathモジュール関数のエイリアスリスト。</summary>
		public static readonly MathFunction[] SystemFuncList = new MathFunction[]{
			new MathFunction("ceil",        new string[]{"x"},          "math.ceil(x)"),
			new MathFunction("abs",         new string[]{"x"},          "math.fabs(x)"),
			new MathFunction("factrial",    new string[]{"x"},          "math.factrial(x)"),
			new MathFunction("floor",       new string[]{"x"},          "math.floor(x)"),
			new MathFunction("exp",         new string[]{"x"},          "math.exp(x)"),
			new MathFunction("log",         new string[]{"x"},          "math.log(x)"),
			new MathFunction("log",         new string[]{"x","base"},   "math.log(x,base)"),
			new MathFunction("log10",       new string[]{"x"},          "math.log10(x)"),
			new MathFunction("pow",         new string[]{"x,y"},        "math.pow(x,y)"),
			new MathFunction("sqrt",        new string[]{"x"},          "math.sqrt(x)"),
			new MathFunction("acos",        new string[]{"x"},          "math.acos(x)"),
			new MathFunction("asin",        new string[]{"x"},          "asin(x)"),
			new MathFunction("atan",        new string[]{"x"},          "atan(x)"),
			new MathFunction("atan2",       new string[]{"y","x"},      "atan2(y,x)"),
			new MathFunction("cos",         new string[]{"x"},          "math.cos(x)"),
			new MathFunction("sin",         new string[]{"x"},          "math.sin(x)"),
			new MathFunction("tan",         new string[]{"x"},          "math.tan(x)"),
			new MathFunction("hypot",       new string[]{"x","y"},      "math.hypot(x,y)"),
			new MathFunction("toDegrees",   new string[]{"x"},          "math.degrees(x)"),
			new MathFunction("toRadians",   new string[]{"x"},          "math.radians(x)"),
			new MathFunction("acosh",       new string[]{"x"},          "math.acosh(x)"),
			new MathFunction("asinh",       new string[]{"x"},          "math.asinh(x)"),
			new MathFunction("atanh",       new string[]{"x"},          "math.atanh(x)"),
			new MathFunction("cosh",        new string[]{"x"},          "math.cosh(x)"),
			new MathFunction("sinh",        new string[]{"x"},          "math.sinh(x)"),
			new MathFunction("tanh",        new string[]{"x"},          "math.tanh(x)"),
			//new MathFunction("max"),
			//new MathFunction("min"),
			//new MathFunction("round"),
			//new MathFunction("sum")
			};



		// このFormulaEngineが利用するIronPythonインタプリタエンジン。
		private ScriptEngine PythonEngine { get; set; }

		// PythonEngineの現在のスコープ。
		private ScriptScope PythonScope { get; set; }

		// PythonEngineの出力を一時的に保管するための動的変数。
		private dynamic EngineResult;

		/// <summary>ユーザー定義関数のリスト。</summary>
		public List<MathFunction> CustomFuncList { get; private set; }

		/// <summary>変数リスト。</summary>
		public Dictionary<string, double> VariablesList { get; private set; }






		/// <summary>コンストラクタ。</summary>
		public FormulaEngine()
			{
			PythonEngine = Python.CreateEngine();

			CustomFuncList = new List<MathFunction>();
			VariablesList = new Dictionary<string, double>();

			InitializeInterpreter();
			}



		/// <summary>Pythonインタプリタの再構成</summary>
		public void InitializeInterpreter()
			{
			string cmd;

			// 新しいスコープを作り、sys・mathパッケージをインポート
			PythonScope = PythonEngine.CreateScope();
			PythonEngine.Execute( "import sys", PythonScope );
			PythonEngine.Execute( "import math", PythonScope );

			// 変数を定義
			foreach( KeyValuePair<string, double> val in VariablesList )
				PythonEngine.Execute( String.Format( "{0}={1}", val.Key, val.Value ), PythonScope );
			PythonEngine.Execute( "t=0", PythonScope );
			PythonEngine.Execute( "pi=math.pi", PythonScope );
			PythonEngine.Execute( "e=math.e", PythonScope );

			// Python組み込み関数エイリアスを定義
			foreach( MathFunction func in SystemFuncList )
				{
				cmd = "def " + func.Name + "(";
				for( int i = 0 ; i < func.Vals.Length ; i++ )
					{
					if( i != 0 ) cmd += ",";
					cmd += func.Vals[i];
					}
				cmd += "):\r\n";
				cmd += "\treturn " + func.Expression + "\r\n";
				cmd += "\r\n";
				PythonEngine.Execute( cmd, PythonScope );
				}

			// ユーザー定義関数を定義
			foreach( MathFunction func in CustomFuncList )
				{
				cmd = "def " + func.Name + "(";
				for( int i = 0 ; i < func.Vals.Length ; i++ )
					{
					if( i != 0 ) cmd += ",";
					cmd += func.Vals[i];
					}
				cmd += "):\r\n";
				cmd += "\treturn " + func.Expression + "\r\n";
				cmd += "\r\n";
				PythonEngine.Execute( cmd, PythonScope );
				}
			}



		/// <summary>パラメータtを設定して式を計算する。</summary>
		/// <param name="t"></param>
		/// <param name="formula"></param>
		/// <returns></returns>
		public double CalculateWithT(double t, string formula)
			{
			PythonEngine.Execute( "t=" + ( Math.Round( t ) == t ? t.ToString( "0.0" ) : t.ToString() ), PythonScope );
			return Calculate( formula );
			}




		/// <summary>式を計算する。</summary>
		/// <param name="formula"></param>
		/// <returns></returns>
		public double Calculate(string formula)
			{
			try
				{
				EngineResult = PythonEngine.Execute( formula, PythonScope );
				return double.Parse( EngineResult.ToString() );
				}
			catch( Exception e )
				{
				throw new FormulaResultException( "", e );
				}
			}



		/// <summary></summary>
		public void Dispose()
			{

			}
		}






	/// <summary>関数情報を格納するクラス。</summary>
	public class MathFunction
		{
		/// <summary>関数の名前。</summary>
		public string Name { get; private set; }

		/// <summary>関数の実際の式。</summary>
		public string Expression { get; set; }

		/// <summary>引数のリスト。</summary>
		public string[] Vals { get; set; }

		/// <summary>コンストラクタ。</summary>
		public MathFunction(string name, string[] vals, string expression)
			{
			Name = name;
			Expression = Regex.Replace( expression, @"\s", "" );
			Vals = vals;
			}


		}



	/// <summary>計算中エラーが発生したことを示す例外。</summary>
	public class FormulaResultException : Exception
		{
		// コンストラクタ。
		internal FormulaResultException(string message, Exception innerException)
			: base( message, innerException )
			{

			}

		}


	}

