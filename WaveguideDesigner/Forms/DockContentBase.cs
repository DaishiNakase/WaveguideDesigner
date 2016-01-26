using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hslab.WaveguideDesigner.Forms
	{

	public partial class DockContentBase : WeifenLuo.WinFormsUI.Docking.DockContent, IFormBase
		{
		public virtual string ClassName { get {return ""; } }

		public Application Application { get { return Hslab.WaveguideDesigner.Application.SingletonInstance; } }



		public LanguagePack Language { get { return Application.CurrentLanguage; } }



		public new FormBase Parent { get; private set; }



		protected DockContentBase() : this( null ) { }



		protected DockContentBase(FormBase parent)
			{
			Application.WriteLog( "A " + ClassName + " object<" + GetHashCode().ToString() + "> is been constructed." );

			Parent = parent;
			HideOnClose = true;
			InitializeComponent();
			Disposed += DockContentBase_Disposed;

			Application.OpenedProjectChanged += Application_OpenedProjectChanged;
			Application.SelectionChanged += Application_SelectionChanged;
			Application.GeometricObjectInvalid += Application_GeometricObjectInvalid;
			Application.GeometricObjectCompleted += Application_GeometricObjectCompleted;
			}

		public virtual void RefreshLanguage() { throw new NotImplementedException(); }
		protected bool RefreshLanguage_Running = false;



		public virtual void RefreshRender() { throw new NotImplementedException(); }
		protected bool RefreshRender_Running = false;



		public virtual void Application_OpenedProjectChanged(object sender, Application.OpenedProjectChangedEventArgs e) { }
		protected bool Application_OpenedProjectChanged_Running = false;



		public virtual void Application_SelectionChanged(object sender, Application.SelectionChangedEventArgs e) { }
		protected bool Application_SelectionChanged_Running = false;



		public virtual void Application_GeometricObjectInvalid(object sender, Application.GeometricObjectInvalidEventArgs e) { }



		public virtual void Application_GeometricObjectCompleted(object sender, EventArgs e) { }




		private void DockContentBase_Load(object sender, EventArgs e)
			{
			Application.WriteLog( "A " + ClassName + " object<" + GetHashCode().ToString() + "> was loaded." );
			}

		private void DockContentBase_FormClosed(object sender, FormClosedEventArgs e)
			{
			Application.WriteLog( "A " + ClassName + " object<" + GetHashCode().ToString() + "> was closed." );
			}

		private void DockContentBase_Disposed(object sender, EventArgs e)
			{
			Application.WriteLog( "A " + ClassName + " object<" + GetHashCode().ToString() + "> was disposed." );
			}
		}


	}
