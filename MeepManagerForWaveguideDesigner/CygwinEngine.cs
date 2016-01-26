using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace Hslab.MeepManager.WaveguideDesigner
	{
	public class CygwinEngine : EngineBase
		{
		public static string DefaultCygwinDirectoryPath { get { return _DefaultCygwinDirectoryPath; } set { _DefaultCygwinDirectoryPath = value; } }
		private static string _DefaultCygwinDirectoryPath = @"C:\Cygwin";

		public static string DefaultCygwinExecutionFileName { get { return _DefaultCygwinExecutionFileName; } set { _DefaultCygwinExecutionFileName = value; } }
		private static string _DefaultCygwinExecutionFileName = @"Cygwin.bat";




		public string CygwinDirectoryPath { get; set; }

		public string CygwinExecutionFilePath { get; set; }

		public override string WorkingDirectoryPath
			{
			get
				{
				return CygwinDirectoryPath + @"\" + WorkingDirectoryPathFromCygwin;
				}
			set { }
			}

		public string WorkingDirectoryPathFromCygwin { get; set; }
		private string WorkingDirectoryPathInCygwin { get { return "/" + WorkingDirectoryPathFromCygwin.Replace( "\\", "/" ); } }

		public Process CygwinProcess { get; private set; }






		public CygwinEngine()
			{
			CygwinDirectoryPath = DefaultCygwinDirectoryPath;
			CygwinExecutionFilePath = DefaultCygwinExecutionFileName;
			WorkingDirectoryPathFromCygwin = @"home\MeepManager";
			}




		public override void RunSimulation() { RunSimulation( null, null, null ); }
		public override void RunSimulation(DataReceivedEventHandler outputDataReceived, DataReceivedEventHandler errorDataReceived, EventHandler exited)
			{
			CreateCtlFile();
			CreateShellScript();

			ProcessStartInfo pInfo = new ProcessStartInfo();
			pInfo.FileName = CygwinDirectoryPath + "\\" + CygwinExecutionFilePath;
			pInfo.UseShellExecute = false;
			pInfo.CreateNoWindow = true;
			pInfo.RedirectStandardInput = true;
			pInfo.RedirectStandardOutput = true;
			pInfo.RedirectStandardError = true;
			CygwinProcess = new Process();
			CygwinProcess.StartInfo = pInfo;
			CygwinProcess.OutputDataReceived += outputDataReceived;
			CygwinProcess.ErrorDataReceived += errorDataReceived;
			CygwinProcess.Exited += exited ?? new EventHandler( (object o, EventArgs e) => { } );
			CygwinProcess.Start();
			CygwinProcess.EnableRaisingEvents = true;
			CygwinProcess.BeginOutputReadLine();
			CygwinProcess.BeginErrorReadLine();
			CygwinProcess.StandardInput.WriteLine( @"cd " + WorkingDirectoryPathInCygwin );
			CygwinProcess.StandardInput.WriteLine( @"./simulation.sh" );
			//CygwinProcess.StandardInput.WriteLine( @"" );
			//CygwinProcess.StandardInput.WriteLine( @"" );
			//CygwinProcess.StandardInput.WriteLine( @"" );
			CygwinProcess.StandardInput.WriteLine( @"exit" );
			}



		}
	}
