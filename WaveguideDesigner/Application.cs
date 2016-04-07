using Hslab.MathExpression;
using Hslab.VirtualStructure;
using Hslab.WaveguideDesigner.ProjectData;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Hslab.WaveguideDesigner
	{
	/// <summary>アプリケーションメインコントローラ。</summary>
	public class Application
		{
		#region public properties

		/// <summary>アプリケーションメインフォーム。</summary>
		public Forms.MainForm MainForm { get; private set; }

		/// <summary>現在実行されているただ一つのアプリケーションインスタンス。</summary>
		public static Application SingletonInstance { get { return _SingletonInstance; } }
		private static Application _SingletonInstance = new Application();


		/// <summary>現在開かれているプロジェクトのファイルパス。</summary>
		public String OpenedProjectFilePath { get; set; }


		/// <summary>現在開かれているプロジェクト。</summary>
		public WaveguideDesignerProjectData OpenedProject
			{
			get { return _OpenedProject; }
			set
				{
				WaveguideDesignerProjectData oldItem = _OpenedProject;
				_OpenedProject = value;
				if( OpenedProjectChanged != null )
					{
					OpenedProjectChanged( this, new OpenedProjectChangedEventArgs( oldItem, value ) );
					ValidateProject( true );
					}
				}
			}
		private WaveguideDesignerProjectData _OpenedProject = null;



		// 次に実行されるUndoはUndoRedoPairList[UndoRedoCount - 1 - CurrentUndoDepth].Undo();
		// 次に実行されるRedoはUndoRedoPairList[UndoRedoPairList.Count  - CurrentUndoDepth].Redo();
		public ReadOnlyCollection<UndoRedoPair> UndoRedoPairs
			{
			get { return new ReadOnlyCollection<UndoRedoPair>( _UndoRedoPairs ); }
			}
		private UndoRedoList _UndoRedoPairs = new UndoRedoList();



		/// <summary>このプロパティがfalseであるとき、UndoRedo情報の追加が行われない。</summary>
		public bool EnableUndoRedoStoring { get; set; }



		/// <summary>現在ストックされているUndo/Redoのペア数。</summary>
		public int UndoRedoCount { get { return _UndoRedoPairs.Count; } }



		/// <summary>現在のUndo深さ。</summary>
		public int CurrentUndoDepth
			{
			get { return _CurrentUndoDepth; }
			private set
				{
				_CurrentUndoDepth = value;
				if( CurrentUndoDepthChanged != null )
					CurrentUndoDepthChanged( this, EventArgs.Empty );
				}
			}
		private int _CurrentUndoDepth;



		/// <summary>関数処理エンジン。</summary>
		public FormulaEngine FormulaEngine { get; private set; }



		/// <summary>仮想グラフィクス。</summary>
		public VirtualGraphics VirtualGraphics
			{
			get { return OpenedProject?.VirtualGraphics; }
			}



		/// <summary>選択中のProjectDataオブジェクト。</summary>
		public ProjectDataBase Selection
			{
			get { return _Selection; }
			set
				{
				ProjectDataBase old = _Selection;
				_Selection = value;
				if( SelectionChanged != null ) SelectionChanged( this, new SelectionChangedEventArgs( old, value ) );
				}
			}
		private ProjectDataBase _Selection;



		/// <summary>Selectionにより自動決定される、現在選択中のレイヤ。</summary>
		public LayerData SelectedLayer
			{
			get
				{
				if( Selection is LayerData ) return Selection as LayerData;
				if( Selection is LayerProfileData ) return Selection.Parent as LayerData;
				if( Selection is GeometricObjectDataBase ) return ( Selection as GeometricObjectDataBase ).ParentLayer;
				return null;
				}
			}



		/// <summary>現在のSelectionがクリップボードに保存できる型(GeometricObjectDataBase)ならtrue。</summary>
		public bool SelectionIsStockable
			{
			get { return Selection is GeometricObjectDataBase; }
			}



		/// <summary>クリップボード。</summary>
		public GeometricObjectDataBase Clipboard
			{
			get { return _Clipboard; }
			set
				{
				_Clipboard = value;
				if( ClipboardChanged != null ) ClipboardChanged( this, EventArgs.Empty );
				}
			}
		private GeometricObjectDataBase _Clipboard;



		/// <summary>現在の言語パック。</summary>
		public LanguagePack CurrentLanguage
			{
			get
				{
				if( _CurrentLanguage == null ) return LanguagePack.DefaultLanguage;
				return _CurrentLanguage;
				}
			set { _CurrentLanguage = value; }

			}
		private LanguagePack _CurrentLanguage;



		/// <summary>構造オブジェクト形状を自動アップデートするならtrue。</summary>
		public bool DoesUpdateShapeAuto { get; set; } = true;



		/// <summary>プロジェクトが検証中であるならばtrue。</summary>
		public bool ValidateProjectRunning { get; private set; }



		/// <summary>OpenedProjectが変更されたときに実行される。</summary>
		public event OpenedProjectChangedEventHandler OpenedProjectChanged;
		public delegate void OpenedProjectChangedEventHandler(object sender, OpenedProjectChangedEventArgs e);



		/// <summary>Selectionが変更されたときに実行される。</summary>
		public event SelectionChangedEventHandler SelectionChanged;
		public delegate void SelectionChangedEventHandler(object sender, SelectionChangedEventArgs e);



		/// <summary>UndoRedoDepthが変更されたときに実行される。Undo/Redoの実行、編集などでDepthは変化する。</summary>
		public event EventHandler CurrentUndoDepthChanged;



		/// <summary>クリップボードが変更されたときに実行される。</summary>
		public event EventHandler ClipboardChanged;


		/// <summary>プロジェクトが検証される前に実行される。</summary>
		public event EventHandler ProjectValidating;



		/// <summary>プロジェクトが検証された後に実行される。</summary>
		public event EventHandler ProjectValidated;



		/// <summary>ジオメトリックオブジェクトの式にエラーが含まれているときに実行される。</summary>
		public event GeometricObjectInvalidEventHandler GeometricObjectInvalid;
		public delegate void GeometricObjectInvalidEventHandler(object sender, GeometricObjectInvalidEventArgs e);



		/// <summary>全てのジオメトリックオブジェクトが正しいときに実行される。</summary>
		public event EventHandler GeometricObjectCompleted;



		#endregion



		#region private properties

		private StreamWriter LogWriter { get; set; }

		#endregion



		#region general system methods

		/// <summary>アプリケーションエントリーポイント。</summary>
		internal void EntryPoint(string[] args)
			{
			try
				{
				LogWriter = new StreamWriter( "WaveguideDesigner.log" );
				}
			catch { MessageBox.Show( "ログファイルを開けませんでした。ログ出力はされません。", "", MessageBoxButtons.OK, MessageBoxIcon.Error ); }
			LogMethodStart();

			CurrentUndoDepth = 0;
			FormulaEngine = new FormulaEngine();
			DoesUpdateShapeAuto = true;
			EnableUndoRedoStoring = true;
			if( args.Length != 0 ) OpenProject( args[0] );

			if( MainForm != null ) throw new InvalidOperationException();

			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault( false );
			MainForm = new Forms.MainForm();
			try
				{
				System.Windows.Forms.Application.Run( MainForm );
				}
			catch( Exception e )
				{
				WriteLog( e.ToString() );
				}

			LogMethodEnd();
			LogWriter?.Dispose();
			}



		/// <summary>プロジェクトデータのプロパティを変更する。変更はUndo/Redoリストに追加される。</summary>
		/// <param name="targetObject"></param>
		/// <param name="targetProperty"></param>
		/// <param name="newValue"></param>
		public void ChangeProperty(object targetObject, PropertyInfo targetProperty, object newValue)
			{
			LogMethodStart();
			WriteLog( GetIndents( 1 ) + "target object   : " + targetObject.ToString() );
			WriteLog( GetIndents( 1 ) + "target property : " + targetProperty.DeclaringType.FullName + "." + targetProperty.Name );
			WriteLog( GetIndents( 1 ) + "new value       : " + newValue.ToString() );
			// targetObjectがtargetPropertyを持たないクラスであればArgumentExceptionをスローする。
			if( !IsTypeOf( targetObject, targetProperty.DeclaringType ) )
				throw new ArgumentException( "Type of targetObject doesn't have property of targetProperty." );
			// newValueがtargetPropertyの型でなければArgumentExceptionをスローする。
			if( !IsTypeOf( newValue, targetProperty.PropertyType ) )
				throw new ArgumentException( "Type of newValue isn't targetProperty type." );

			// 現在の値。Undo作成に利用。
			object oldValue = targetProperty.GetValue( targetObject );

			// 値の変更。
			targetProperty.SetValue( targetObject, newValue );

			// Undo/Redoの言語対応文字列を取得する
			UndoRedoPairString urString;
			try
				{
				PropertyInfo urStringContainerGetter = typeof( LanguagePack ).GetProperty( targetObject.GetType().Name )
					?? typeof( LanguagePack ).GetProperty( targetProperty.DeclaringType.Name );
				object container = urStringContainerGetter?.GetValue( CurrentLanguage );
				PropertyInfo urStringGetter = container?.GetType().GetProperty( targetProperty.Name + "Changed" );
				urString = urStringGetter.GetValue( container ) as UndoRedoPairString;
				}
			catch
				{
				urString = CurrentLanguage.ProjectDataBase_PropertyChangedDefault;
				}

			// Undo/Redoの作成
			Action undo = () => { targetProperty.SetValue( targetObject, oldValue ); };
			Action redo = () => { targetProperty.SetValue( targetObject, newValue ); };
			UndoRedoPair urPair = new UndoRedoPair( urString, undo, redo );
			AddUndoRedoPair( urPair );
			LogMethodEnd();
			}



		/// <summary>FormulaEngineに登録されている変数・関数を更新する。</summary>
		public void UpdateNumericsSetting()
			{
			LogMethodStart();
			GlobalStructureNumericsData numerics = OpenedProject.GlobalStructureNumerics;
			FormulaEngine.VariablesList.Clear();
			FormulaEngine.CustomFuncList.Clear();
			foreach( ParameterData par in numerics.Parameters )
				FormulaEngine.VariablesList.Add( par.Name, par.Value );
			foreach( FunctionData func in numerics.Functions )
				FormulaEngine.CustomFuncList.Add( func.GetMathFunction() );
			FormulaEngine.InitializeInterpreter();
			LogMethodEnd();
			}



		/// <summary>全てのGeometricObjectを検証し更新する。</summary>
		/// <param name="updateShape"></param>
		public void ValidateGeometricObjects(bool updateShape)
			{
			LogMethodStart();

			if( OpenedProject == null ) return;
			if( UpdateShape_Running ) return;
			UpdateShape_Running = true;
			bool isValid = true;
			if( updateShape )
				{
				foreach( GeometricObjectDataBase obj in OpenedProject.GeometricObjects )
					if( !obj.UpdateVirtualShape() )
						{
						isValid = false;
						if( GeometricObjectInvalid != null )
							GeometricObjectInvalid( this, new GeometricObjectInvalidEventArgs( obj ) );
						}
				if( isValid )
					if( GeometricObjectCompleted != null )
						GeometricObjectCompleted( this, EventArgs.Empty );
				}
			else
				foreach( GeometricObjectDataBase obj in OpenedProject.GeometricObjects )
					obj.RefreshRenderSetting();
			UpdateShape_Running = false;

			LogMethodEnd();
			}
		private bool UpdateShape_Running = false;



		/// <summary>プロジェクトとアプリケーションの状態を全て検証し、必要な更新を行う。</summary>
		/// <param name="updateShape">構造オブジェクトの再計算をすべて行うならtrue。計算コストが重いため省略できるように用意された引数。</param>
		public void ValidateProject(bool updateShape)
			{
			LogMethodStart();

			if( ProjectValidating != null ) ProjectValidating( this, EventArgs.Empty );
			if( ValidateProjectRunning ) return;
			ValidateProjectRunning = true;

			if( OpenedProject != null )
				{
				OpenedProject.ProjectManifest.RefreshVisualization();
				OpenedProject.Layers.Sort();
				UpdateNumericsSetting();
				ValidateGeometricObjects( updateShape );
				}
			MainForm.RefreshRender();
			if( ProjectValidated != null ) ProjectValidated( this, EventArgs.Empty );

			ValidateProjectRunning = false;

			LogMethodEnd();
			}



		// ファイルパスとして有効な文字列かどうかを判定
		private bool IsValidFilePath(string path)
			{
			if( string.IsNullOrEmpty( path ) ) return false;
			if( Path.GetInvalidPathChars().Any( str => path.Contains( str ) ) ) return false;
			return true;
			}



		// 設定済SaveFileDialogを作成
		private SaveFileDialog MakeSaveFileDialog(FileType type)
			{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.InitialDirectory = GetInitialDirectoryPath( type );
			dialog.Filter = GetFileFilter( type );
			return dialog;
			}



		// 設定済OpenFileDialogを作成
		private OpenFileDialog MakeOpenFileDialog(FileType type)
			{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.InitialDirectory = GetInitialDirectoryPath( type );
			dialog.Filter = GetFileFilter( type );
			return dialog;
			}



		private enum FileType
			{
			Project,
			DxfCad,
			MeepScript,
			ShellScript,
			ApplicationConfig,
			Log,
			}
		private string GetInitialDirectoryPath(FileType type)
			{
			switch( type )
				{
				case FileType.Project:
				case FileType.DxfCad:
				case FileType.MeepScript:
				case FileType.ShellScript:
					return IsValidFilePath( OpenedProjectFilePath ) ? ( new FileInfo( OpenedProjectFilePath ) ).DirectoryName : Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory );
				case FileType.ApplicationConfig:
				case FileType.Log:
					return ( new FileInfo( Assembly.GetEntryAssembly().Location ) ).DirectoryName;
				}
			throw new InvalidOperationException();
			}
		private string GetFileFilter(FileType type)
			{
			switch( type )
				{
				case FileType.Project: return "WaveguideDesigner project file|*.wgproj";
				case FileType.DxfCad: return "DXF CAD file|*.dxf";
				case FileType.MeepScript: return "Meep script file|*.ctl";
				case FileType.ShellScript: return "Shell script file|*.sh";
				case FileType.ApplicationConfig: return "Application config file|*.cfg";
				case FileType.Log: return "Application log file|*.log";
				}
			throw new InvalidOperationException();
			}



		#endregion



		#region application methods : File

		/// <summary></summary>
		/// <returns>ファイルの作成が完了したらtrue。キャンセルされたり、失敗したらfalse。</returns>
		public bool CreateProject()
			{
			LogMethodStart();

			bool res;
			if( !CloseProject() ) res = false;
			else
				{
				res = true;
				OpenedProject = new WaveguideDesignerProjectData();
				}

			LogMethodEnd();
			return res;
			}



		/// <summary></summary>
		/// <returns>ファイルの読み込みが完了したらtrue。キャンセルされたり、失敗したらfalse。</returns>
		public bool OpenProject()
			{ return OpenProject( "" ); }
		/// <summary></summary>
		/// <param name="filename"></param>
		/// <returns>ファイルの読み込みが完了したらtrue。キャンセルされたり、失敗したらfalse。</returns>
		public bool OpenProject(string filename)
			{
			LogMethodStart();
			bool res = _OpenProject( filename );
			LogMethodEnd();
			return res;
			}
		private bool _OpenProject(string filename)
			{
			if( OpenedProject != null && !CloseProject() ) return false;
			string path = filename;
			if( !IsValidFilePath( path ) )
				{
				OpenFileDialog dialog = MakeOpenFileDialog( FileType.Project );
				if( dialog.ShowDialog( MainForm ) == DialogResult.OK )
					path = dialog.FileName;
				if( !IsValidFilePath( path ) ) return false;
				}
			try
				{
				OpenedProject = WaveguideDesignerProjectData.ReadProjectFile( path );
				OpenedProjectFilePath = path;
				}
			catch
				{
				return false;
				}
			return true;
			}



		/// <summary></summary>
		/// <returns>ファイルの保存が完了したらtrue。キャンセルされたり、失敗したらfalse。</returns>
		public bool SaveProject()
			{ return SaveProject( OpenedProjectFilePath ); }
		/// <summary></summary>
		/// <param name="filename"></param>
		/// <returns>ファイルの保存が完了したらtrue。キャンセルされたり、失敗したらfalse。</returns>
		public bool SaveProject(string filename)
			{
			LogMethodStart();
			bool res = _SaveProject( filename );
			LogMethodEnd();
			return res;
			}
		private bool _SaveProject(string filename)
			{
			if( OpenedProject == null ) return false;

			string path = filename;
			if( !IsValidFilePath( path ) )
				{
				SaveFileDialog dialog = MakeSaveFileDialog( FileType.Project );
				if( dialog.ShowDialog( MainForm ) == DialogResult.OK )
					path = dialog.FileName;
				if( !IsValidFilePath( path ) ) return false;
				}
			OpenedProject.WriteProjectFile( path );
			return true;
			}



		/// <summary></summary>
		/// <returns>ファイルの終了が完了したらtrue。キャンセルされたり、失敗したらfalse。</returns>
		public bool CloseProject()
			{
			LogMethodStart();
			bool res = _CloseProject();
			LogMethodEnd();
			return res;
			}
		private bool _CloseProject()
			{
			if( OpenedProject != null )
				switch( MessageBox.Show( MainForm, CurrentLanguage.Application.MessageBoxProjectCloseNotice, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information ) )
					{
					case DialogResult.Yes:
						SaveProject();
						goto case DialogResult.No;
					case DialogResult.No:
						break;
					case DialogResult.Cancel:
						return false;
					}
			OpenedProject = null;
			ValidateProject( true );
			return true;
			}



		/// <summary></summary>
		public void Quit()
			{
			LogMethodStart();
			_Quit();
			LogMethodEnd();
			}
		private void _Quit()
			{
			if( !CloseProject() ) return;
			MainForm.Close();
			}

		#endregion



		#region application methods : Edit

		/// <summary>新しいUndoRedoPairを追加する。CurrentUndoDepthが0出ない場合、現時点よりも新しいUndoRedoPairは破棄される。</summary>
		/// <param name="pair"></param>
		private void AddUndoRedoPair(UndoRedoPair pair)
			{
			string methodName = "Application.AddUndoRedoPair";
			LogMethodStart( methodName );
			WriteLog( GetIndents( 1 ) + "pair : " + pair.ToString() );
			_AddUndoRedoPair( pair );
			LogMethodEnd( methodName );
			}
		private void _AddUndoRedoPair(UndoRedoPair pair)
			{
			for( int i = 0 ; i < CurrentUndoDepth ; i++ )
				_UndoRedoPairs.RemoveAt( UndoRedoCount - 1 );
			_UndoRedoPairs.Add( pair );
			CurrentUndoDepth = 0;
			}



		/// <summary>1回Undoを行う。</summary>
		/// <returns>これ以上Undoできなかった場合はfalseが返る。</returns>
		public bool Undo() { return Undo( true ); }
		/// <summary>1回Undoを行う。</summary>
		/// <param name="doesValidate"></param>
		/// <returns>これ以上Undoできなかった場合はfalseが返る。</returns>
		public bool Undo(bool doesValidate)
			{
			LogMethodStart();
			bool res = _Undo( doesValidate );
			LogMethodEnd();
			WriteLog( GetIndents( 1 ) + "return : " + res.ToString() );
			return res;
			}
		private bool _Undo(bool doesValidate)
			{
			EnableUndoRedoStoring = false;
			if( CurrentUndoDepth >= UndoRedoCount ) return false;
			_UndoRedoPairs[UndoRedoCount - 1 - CurrentUndoDepth].Undo();
			CurrentUndoDepth++;
			EnableUndoRedoStoring = true;
			ValidateProject( DoesUpdateShapeAuto && doesValidate );
			return true;
			}



		/// <summary>1回Redoを行う。</summary>
		/// <returns>これ以上Redoできなかった場合はfalseが返る。</returns>
		public bool Redo() { return Redo( true ); }
		/// <summary>1回Redoを行う。</summary>
		/// <param name="doesValidate"></param>
		/// <returns>これ以上Redoできなかった場合はfalseが返る。</returns>
		public bool Redo(bool doesValidate)
			{
			LogMethodStart();
			bool res = _Redo( doesValidate );
			LogMethodEnd();
			WriteLog( GetIndents( 1 ) + "return : " + res.ToString() );
			return res;
			}
		private bool _Redo(bool doesValidate)
			{
			EnableUndoRedoStoring = false;
			if( UndoRedoCount <= 0 ) return false;
			_UndoRedoPairs[UndoRedoCount - CurrentUndoDepth].Redo();
			CurrentUndoDepth--;
			EnableUndoRedoStoring = true;
			ValidateProject( DoesUpdateShapeAuto && doesValidate );
			return true;
			}



		/// <summary>Undo/Redoリストを表示する。</summary>
		/// <returns></returns>
		public bool ShowUndoRedoList()
			{
			LogMethodStart();
			bool res = _ShowUndoRedoList();
			LogMethodEnd();
			WriteLog( GetIndents( 1 ) + "return : " + res.ToString() );
			return res;
			}
		private bool _ShowUndoRedoList()
			{
			Forms.UndoRedoListDialog dialog = new Forms.UndoRedoListDialog();
			dialog.ShowDialog( MainForm );
			return dialog.UndoRedoResult;
			}



		/// <summary>depthShiftの分だけUndo/Redoを行う。</summary>
		/// <param name="depthShift">
		/// 正の値なら、その回数だけUndoを行う。
		/// 負の値なら、その回数だけRedoを行う。
		/// 0は無視される。
		/// </param>
		/// <returns>指定された回数だけUndo/Redoすることができず停止した場合はfalseが返る。</returns>
		public bool UndoRedo(int depthShift)
			{
			LogMethodStart();
			bool res = _UndoRedo( depthShift );
			LogMethodEnd();
			WriteLog( GetIndents( 1 ) + "return : " + res.ToString() );
			return res;
			}
		private bool _UndoRedo(int depthShift)
			{
			EnableUndoRedoStoring = false;
			if( depthShift > 0 )
				for( int i = 0 ; i < depthShift ; i++ )
					{
					if( !Undo( false ) ) return false;
					}
			else if( depthShift < 0 )
				{
				for( int i = 0 ; i > depthShift ; i-- )
					{
					if( !Redo( false ) ) return false;
					}
				}
			EnableUndoRedoStoring = true;
			ValidateProject( DoesUpdateShapeAuto );
			return true;
			}



		/// <summary>選択中のデータを上位データからカットしてクリップボードに保存する。構造オブジェクトにのみ適用。</summary>
		public void Cut()
			{
			LogMethodStart();
			_Cut();
			LogMethodEnd();
			}
		private void _Cut()
			{
			if( !SelectionIsStockable ) return;

			Action undo, redo;
			GeometricObjectDataBase target = Selection as GeometricObjectDataBase;
			LayerData parent = target.Parent as LayerData;
			int index = parent.GeometricObjects.IndexOf( target );
			undo = () => { parent.GeometricObjects.Insert( index, target ); };
			redo = () => { parent.GeometricObjects.Remove( target ); };
			Clipboard = Selection as GeometricObjectDataBase;
			Clipboard.ParentLayer.GeometricObjects.Remove( Clipboard );
			Selection = parent;

			UndoRedoPair urPair = new UndoRedoPair( new UndoRedoPairString( CurrentLanguage.StandardFunction.Cut + " : " + Clipboard.ToString(), "" ), undo, redo );
			AddUndoRedoPair( urPair );

			ValidateProject( DoesUpdateShapeAuto );
			}




		/// <summary>選択中のデータをコピーしてクリップボードに保存する。構造オブジェクトにのみ適用。</summary>
		public void Copy()
			{
			LogMethodStart();
			_Copy();
			LogMethodEnd();
			}
		private void _Copy()
			{
			if( !SelectionIsStockable ) return;
			Clipboard = Selection.DeepClone() as GeometricObjectDataBase;
			}



		/// <summary>選択中のクリップボードを選択中のデータにペーストする。構造オブジェクトにのみ適用。</summary>
		public void Paste()
			{
			LogMethodStart();
			_Paste();
			LogMethodEnd();
			}
		private void _Paste()
			{
			if( !( Selection is LayerData || Selection is GeometricObjectDataBase ) ) return;
			if( Clipboard == null ) return;

			EnableUndoRedoStoring = false;

			GeometricObjectDataBase obj = Clipboard.DeepClone() as GeometricObjectDataBase;
			LayerData target = SelectedLayer;

			target.GeometricObjects.Add( obj );
			Action undo = () => { target.GeometricObjects.Remove( obj ); };
			Action redo = () => { target.GeometricObjects.Add( obj ); };
			UndoRedoPair urPair = new UndoRedoPair( new UndoRedoPairString( CurrentLanguage.StandardFunction.Paste + " : " + obj.Name, "" ), undo, redo );
			EnableUndoRedoStoring = true;
			AddUndoRedoPair( urPair );

			ValidateProject( DoesUpdateShapeAuto );
			}




		/// <summary>選択中のデータをデリートする。レイヤまたは構造オブジェクトにのみ適用。</summary>
		public void Delete() { Delete( Selection ); }
		/// <summary>データをデリートする。レイヤまたは構造オブジェクトにのみ適用。</summary>
		/// <param name="data"></param>
		public void Delete(ProjectDataBase data)
			{
			LogMethodStart();
			_Delete( data );
			LogMethodEnd();
			}
		private void _Delete(ProjectDataBase data)
			{
			if( data is LayerData ) DeleteLayer( data as LayerData );
			else if( data is GeometricObjectDataBase ) DeleteGeometricObject( data as GeometricObjectDataBase );
			else return;
			ValidateProject( DoesUpdateShapeAuto );
			}
		private void DeleteLayer(LayerData layer)
			{
			string notice = CurrentLanguage.StandardFunction.Delete_UserNotice;
			if( MessageBox.Show( notice, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information ) != DialogResult.OK ) return;

			WaveguideDesignerProjectData parent = layer.Parent as WaveguideDesignerProjectData;
			int index = parent.Layers.IndexOf( layer );
			Action undo = () => { parent.Layers.Insert( index, layer ); };
			Action redo = () => { parent.Layers.Remove( layer ); };
			parent.Layers.Remove( layer );
			Selection = parent;

			UndoRedoPair urPair = new UndoRedoPair( new UndoRedoPairString( CurrentLanguage.StandardFunction.Delete + " : Layer[" + layer.Name + "]", "" ), undo, redo );
			AddUndoRedoPair( urPair );
			}
		private void DeleteGeometricObject(GeometricObjectDataBase obj)
			{
			string notice = CurrentLanguage.StandardFunction.Delete_UserNotice.Replace( "%s", obj.Name );
			if( MessageBox.Show( notice, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information ) != DialogResult.OK ) return;

			LayerData parent = obj.ParentLayer;
			int index = parent.GeometricObjects.IndexOf( obj );
			Action undo = () => { parent.GeometricObjects.Insert( index, obj ); };
			Action redo = () => { parent.GeometricObjects.Remove( obj ); };
			parent.GeometricObjects.Remove( obj );
			Selection = parent;

			UndoRedoPair urPair = new UndoRedoPair( new UndoRedoPairString( CurrentLanguage.StandardFunction.Delete + " : GeometricObject[" + obj.Name + "]", "" ), undo, redo );
			AddUndoRedoPair( urPair );
			}

		#endregion



		#region application methods : Edit - Layers and GeometricObjects

		/// <summary>レイヤを追加する。</summary>
		public LayerData AddLayer() { return AddLayer( new LayerData() ); }
		/// <summary>レイヤを追加する。</summary>
		/// <param name="layer"></param>
		public LayerData AddLayer(LayerData layer)
			{
			LogMethodStart();
			_AddLayer( layer );
			LogMethodEnd();
			return layer;
			}
		private void _AddLayer(LayerData layer)
			{
			if( OpenedProject == null ) return;

			int oldLayerNo = layer.LayerNumber, newLayerNo = ( OpenedProject.Layers.Count > 0 ) ? ( OpenedProject.Layers[OpenedProject.Layers.Count - 1].LayerNumber + 1 ) : 1;
			Action undo = () => { OpenedProject.Layers.Remove( layer ); layer.LayerNumber = oldLayerNo; };
			Action redo = () => { OpenedProject.Layers.Add( layer ); layer.LayerNumber = newLayerNo; };
			OpenedProject.Layers.Add( layer );
			layer.LayerNumber = newLayerNo;
			AddUndoRedoPair( new UndoRedoPair( CurrentLanguage.ProjectList_ValueChangedDefault, undo, redo ) );
			ValidateProject( false );
			}



		/// <summary>ジオメトリックオブジェクトを追加する。</summary>
		/// <param name="obj"></param>
		public GeometricObjectDataBase AddGeometricObject(GeometricObjectDataBase obj)
			{
			LogMethodStart();
			_AddGeometricObject( obj );
			LogMethodEnd();
			return obj;
			}
		private void _AddGeometricObject(GeometricObjectDataBase obj)
			{
			if( OpenedProject == null ) return;
			if( SelectedLayer == null ) return;

			SelectedLayer.GeometricObjects.Add( obj );
			ValidateProject( DoesUpdateShapeAuto );
			Selection = obj;
			}



		/// <summary>RectangleCoordinateFunctionalPathを作成して追加する。</summary>
		public RectangleCoordinateFunctionalPathData AddRectangleCoordinateFunctionalPathObject()
			{
			LogMethodStart();
			RectangleCoordinateFunctionalPathData res = _AddRectangleCoordinateFunctionalPathObject();
			LogMethodEnd();
			return res;
			}
		private RectangleCoordinateFunctionalPathData _AddRectangleCoordinateFunctionalPathObject()
			{
			RectangleCoordinateFunctionalPathData res = new RectangleCoordinateFunctionalPathData();
			AddGeometricObject( res );
			return res;
			}



		/// <summary>PolarCoordinateFunctionalPathを追加する。</summary>
		public PolarCoordinateFunctionalPathData AddPolarCoordinateFunctionalPathObject()
			{
			LogMethodStart();
			PolarCoordinateFunctionalPathData res = _AddPolarCoordinateFunctionalPathObject();
			LogMethodEnd();
			return res;
			}
		private PolarCoordinateFunctionalPathData _AddPolarCoordinateFunctionalPathObject()
			{
			PolarCoordinateFunctionalPathData res = new PolarCoordinateFunctionalPathData();
			AddGeometricObject( res );
			return res;
			}



		/// <summary>TableDefinablePathを追加する。</summary>
		public CoordinateListPathData AddCoordinateListPathObject()
			{
			LogMethodStart();
			CoordinateListPathData res = _AddCoordinateListPathObject();
			LogMethodEnd();
			return res;
			}
		private CoordinateListPathData _AddCoordinateListPathObject()
			{
			CoordinateListPathData res = new CoordinateListPathData();
			AddGeometricObject( res );
			return res;
			}

		#endregion



		// Viewはフォーム外観の制御に用いられるため、
		// MainForm内に動作を記述するものとする。



		#region application methods : CAD

		public bool OutputDxf()
			{
			return OutputDxf( Path.GetFileNameWithoutExtension( OpenedProjectFilePath ) + ".dxf" );
			}
		public bool OutputDxf(string filename)
			{
			LogMethodStart();
			bool res = outputDxf( filename );
			LogMethodEnd();
			WriteLog( GetIndents( 1 ) + "return : " + res.ToString() );
			return res;
			}
		private bool outputDxf(string filename)
			{
			if( OpenedProject == null ) return false;
			string path = filename;
			if( !IsValidFilePath( path ) )
				{
				SaveFileDialog dialog = MakeSaveFileDialog( FileType.DxfCad );
				if( dialog.ShowDialog( MainForm ) == DialogResult.OK )
					path = dialog.FileName;
				if( !IsValidFilePath( path ) ) return false;
				}
			try
				{
				DxfWriter dw = new DxfWriter( path );
				dw.WriteProject( OpenedProject );
				}
			catch
				{
				return false;
				}
			return true;
			}


		#endregion



		#region application methods : Analysis

		public void OutputCtlFile()
			{
			LogMethodStart();
			_OutputCtlFile();
			LogMethodEnd();
			}
		private void _OutputCtlFile()
			{
			if( OpenedProject == null ) return;
			SaveFileDialog dialog = MakeSaveFileDialog( FileType.MeepScript );
			dialog.Title = CurrentLanguage.MainForm.Dialog_OutputCtlFile;
			if( dialog.ShowDialog() == DialogResult.OK )
				{
				try
					{
					OpenedProject.WriteCtlFile( dialog.FileName, (sender, e) => { WriteLog( Indent + e.Message ); } );
					}
				catch
					{
					MessageBox.Show( CurrentLanguage.MainForm.Dialog_FileSaveError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
					}
				}
			}

		#endregion



		#region application methods : Tools

		public bool ShowMaterialEditorDialog(IWin32Window owner)
			{
			LogMethodStart();
			bool res = _ShowMaterialEditorDialog( owner );
			LogMethodEnd();
			return res;
			}
		public bool _ShowMaterialEditorDialog(IWin32Window owner)
			{
			Forms.MaterialSystemEditorDialog dialog = new Forms.MaterialSystemEditorDialog();
			return dialog.ShowDialog( owner ) == DialogResult.OK;
			}

		#endregion



		#region application methods : Help

		/// <summary>バージョン情報を表示する。</summary>
		public void ShowVersionInfo()
			{
			LogMethodStart();
			_ShowVersionInfo();
			LogMethodEnd();
			}
		private void _ShowVersionInfo()
			{

			}

		#endregion



		#region log output methods and properties

		/// <summary>ログ情報を書き出す。Dateを同時に出力する。</summary>
		/// <param name="log"></param>
		public void WriteLog(string log) { WriteLog( log, true ); }
		/// <summary>ログ情報を書き出す。</summary>
		/// <param name="log"></param>
		/// <param name="doesWriteDate"></param>
		public void WriteLog(string log, bool doesWriteDate)
			{
			if( LogWriter == null ) return;
			if( doesWriteDate ) LogWriter.Write( DateTime.Now.ToString( "[yyyy/MM/dd HH:mm:ss.fff] " ) );
			LogWriter.WriteLine( log );
			LogWriter.Flush();
			}

		/// <summary>メソッド開始のログ情報を書き出す。</summary>
		/// <param name="methodFullName"></param>
		public void LogMethodStart([CallerMemberName]string methodName = "")
			{
			WriteLog( "--> " + methodName, true );
			}

		/// <summary>メソッド終了のログ情報を書き出す。</summary>
		/// <param name="methodFullName"></param>
		public void LogMethodEnd([CallerMemberName]string methodName = "")
			{
			WriteLog( "<-- " + methodName, true );
			}

		/// <summary>指定回数分のインデントを取得する。</summary>
		/// <param name="times"></param>
		/// <returns></returns>
		public string GetIndents(int times)
			{
			string res = "";
			for( int i = 0 ; i < times ; i++ ) res += Indent;
			return res;
			}

		/// <summary>ログファイルの標準インデント。</summary>
		public static readonly string Indent = "    ";

		#endregion



		#region private utility methods

		// Type型による型判定のis構文代替
		private bool IsTypeOf(object obj, Type type)
			{
			return obj.GetType().Equals( type ) || obj.GetType().IsSubclassOf( type );
			}

		#endregion




		public class OpenedProjectChangedEventArgs : EventArgs
			{
			public WaveguideDesignerProjectData OldItem { get; private set; }
			public WaveguideDesignerProjectData NewItem { get; private set; }

			public OpenedProjectChangedEventArgs(WaveguideDesignerProjectData oldItem, WaveguideDesignerProjectData newItem)
				{
				OldItem = oldItem;
				NewItem = newItem;
				}
			}



		public class SelectionChangedEventArgs : EventArgs
			{
			public ProjectDataBase OldItem { get; private set; }
			public ProjectDataBase NewItem { get; private set; }

			public SelectionChangedEventArgs(ProjectDataBase oldItem, ProjectDataBase newItem)
				{
				OldItem = oldItem;
				NewItem = newItem;
				}
			}



		public class GeometricObjectInvalidEventArgs : EventArgs
			{
			public GeometricObjectDataBase ErrordObject { get; private set; }

			public GeometricObjectInvalidEventArgs(GeometricObjectDataBase obj)
				{
				ErrordObject = obj;
				}
			}
		}






	}
