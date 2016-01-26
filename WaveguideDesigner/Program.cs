using Hslab.WaveguideDesigner.Forms;
using System;

namespace Hslab.WaveguideDesigner
	{
	static class Program
		{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
			{
#if DEBUG
			args = new string[] {"test.wgproj" };
			//TestCode.MakeTestProject();
#endif


			Application.SingletonInstance.EntryPoint(args);
			}


		}
	}
