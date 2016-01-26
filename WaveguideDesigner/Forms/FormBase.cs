using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Hslab.WaveguideDesigner.Forms
	{
#pragma warning disable 1591

	public partial class FormBase : Form, IFormBase
		{
		public virtual string ClassName { get { return ""; } }


		public Application Application { get { return Hslab.WaveguideDesigner.Application.SingletonInstance; } }

		public LanguagePack Language { get { return Application.CurrentLanguage; } }



		protected FormBase()
			{
			Application.WriteLog( "A " + ClassName + " object<" + GetHashCode().ToString() + "> is been constructed." );
			InitializeComponent();
			Load += FormBase_Load;
			FormClosed += FormBase_FormClosed;
			Disposed += FormBase_Disposed;
			}

		public virtual void RefreshLanguage() { throw new NotImplementedException(); }

		public virtual void RefreshRender() { throw new NotImplementedException(); }



		private void FormBase_Load(object sender, EventArgs e)
			{
			Application.WriteLog( "A " + ClassName + " object<" + GetHashCode().ToString() + "> was loaded." );
			}

		private void FormBase_FormClosed(object sender, FormClosedEventArgs e)
			{
			Application.WriteLog( "A " + ClassName + " object<" + GetHashCode().ToString() + "> was closed." );
			}

		private void FormBase_Disposed(object sender, EventArgs e)
			{
			Application.WriteLog( "A " + ClassName + " object<" + GetHashCode().ToString() + "> was disposed." );
			}
		}



#pragma warning restore 1591
	}
