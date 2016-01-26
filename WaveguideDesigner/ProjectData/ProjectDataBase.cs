using System;
using System.Xml.Serialization;
using System.Reflection;
using System.ComponentModel;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	/// <summary>プロジェクトデータオブジェクトの基本処理を示す抽象クラス。</summary>
	public abstract class ProjectDataBase : INotifyPropertyChanged
		{
		/// <summary>プロジェクトを開いているApplicationインスタンスのエイリアス。</summary>
		public Application Application { get { return Application.SingletonInstance; } }

		/// <summary>現在適用されている言語パック。</summary>
		public LanguagePack Language { get { return Application.CurrentLanguage; } }

		/// <summary>ProjectDataツリーにおける親オブジェクト。</summary>
		[XmlIgnore]
		public virtual ProjectDataBase Parent { get; protected internal set; }

		/// <summary>ProjectExplorer上の対応するノード。</summary>
		[XmlIgnore]
		public System.Windows.Forms.TreeNode TreeNode { get; set; }



		/// <summary>デフォルトコンストラクタ。</summary>
		public ProjectDataBase()
			{
			}




		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			return "[" + GetType().Name + "]";
			}



		public virtual string ToString(string s)
			{
			return "[" + GetType().Name + ":" + s + "]";
			}



		/// <summary>このオブジェクトのディープコピーを返す。</summary>
		/// <returns></returns>
		public ProjectDataBase DeepClone()
			{
			Type type = this.GetType();
			ConstructorInfo constructor = type.GetConstructor( new[] { type } );
			return (ProjectDataBase)constructor.Invoke( new[] { this } );
			}


		/// <summary></summary>
		public event PropertyChangedEventHandler PropertyChanged;
		/// <summary></summary>
		/// <param name="info"></param>
		protected void NotifyPropertyChanged(String info)
			{
			PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( info ) );
			}
		}




	/// <summary>名前付きプロジェクトデータオブジェクトの基本処理を示す抽象クラス。</summary>
	public abstract class NamedDataBase : ProjectDataBase
		{
		/// <summary>データの名前。</summary>
		[PropertyEditorAttribute( 0, true )]
		public virtual string Name { get; set; }


		public NamedDataBase() { }


		public NamedDataBase(NamedDataBase previous)
			{
			Name = previous.Name;
			}



		public NamedDataBase(NamedDataBase previous, string suffix)
			{
			Name = previous.Name + suffix;
			}


		public override string ToString()
			{
			return base.ToString( Name );
			}




		}

	
	}
