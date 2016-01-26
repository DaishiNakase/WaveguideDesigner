using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	public class ProjectList<T> : ProjectDataBase, IList<T>, IProjectList
		{
		private List<T> list;

		public Type GenericType { get { return typeof(T); } }

		/// <summary>UndoRedoに使用する名前。</summary>
		[XmlIgnore]
		public string UndoRedoName { get; set; }
		/// <summary>UndoRedoに使用するメッセージ。</summary>
		[XmlIgnore]
		public string UndoRedoMessage { get; set; }

		/// <summary>アイテムが挿入されたとき実行される。</summary>
		public event ListChangedEventHandler ItemInserted;

		/// <summary>アイテムが設定されたとき実行される。</summary>
		public event ListChangedEventHandler ItemSet;

		/// <summary>アイテムが除外されたとき実行される。</summary>
		public event ListChangedEventHandler ItemRemoved;

		/// <summary>全てのアイテムが除外されたとき実行される。</summary>
		public event ListChangedEventHandler ItemsCleared;



		public ProjectList()
			{
			list = new List<T>();
			}



		public ProjectList(IList<T> items)
			: this()
			{
			AddRange( items );
			}



		public override string ToString()
			{
			return "[" + typeof( T ).Name + " list]";
			}



		public int IndexOf(T item)
			{
			return list.IndexOf( item );
			}
		public int IndexOf(object value)
			{
			throw new NotImplementedException();
			}






		public void RemoveAt(int index)
			{
			T oldItem = list[index];
			list.RemoveAt( index );
			if( ItemRemoved != null )
				{
				ListChangedEventArgs<T> e = new ListChangedEventArgs<T>( oldItem );
				ItemRemoved( this, e );
				}
			}



		public T this[int index]
			{
			get
				{
				return list[index];
				}
			set
				{
				T oldValue = list[index];
				list[index] = value;
				if( ItemSet != null )
					{
					ListChangedEventArgs<T> e = new ListChangedEventArgs<T>( value, oldValue );
					ItemSet( this, e );
					}
				}
			}
		object IList.this[int index]
			{
			get
				{
				return this[index];
				}

			set
				{
				if( value is T ) this[index] = (T)value;
				}
			}



		public virtual void Add(T item)
			{
			list.Add( item );
			if( ItemInserted != null )
				{
				ListChangedEventArgs<T> e = new ListChangedEventArgs<T>( item );
				ItemInserted( this, e );
				}
			}
		public int Add(object value)
			{
			if( value is T )
				{
				Add( (T)value ); return Count - 1;
				}
			return -1;
			}



		public virtual void AddRange(IList<T> items)
			{
			foreach( T item in items )
				{
				list.Add( item );
				if( ItemInserted != null )
					{
					ListChangedEventArgs<T> e = new ListChangedEventArgs<T>( item );
					ItemInserted( this, e );
					}
				}
			}


		public void Clear()
			{
			List<T> oldList = new List<T>( list );
			list.Clear();
			if( ItemsCleared != null )
				{
				ListChangedEventArgs<T> e = new ListChangedEventArgs<T>( oldList );
				ItemsCleared( this, e );
				}
			}



		public virtual void Insert(int index, T item)
			{
			list.Insert( index, item );
			if( ItemInserted != null )
				{
				ListChangedEventArgs<T> e = new ListChangedEventArgs<T>( item );
				ItemInserted( this, e );
				}
			}
		public void Insert(int index, object value)
			{
			if( value is T ) Insert( index, (T)value );
			}



		public bool Contains(T item)
			{
			return list.Contains( item );
			}
		public bool Contains(object value)
			{
			if( !( value is T ) ) return false;
			return Contains( (T)value );
			}



		public void CopyTo(T[] array, int arrayIndex)
			{
			list.CopyTo( array, arrayIndex );
			}
		public void CopyTo(Array array, int index)
			{
			if( array is T[] ) CopyTo( array as T[], index );
			}



		public int Count
			{
			get { return list.Count; }
			}



		public bool Remove(T item)
			{
			bool flag = list.Remove( item );
			if( flag )
				{
				if( ItemRemoved != null )
					{
					ListChangedEventArgs<T> e = new ListChangedEventArgs<T>( item );
					ItemRemoved( this, e );
					}
				}
			return flag;
			}
		public void Remove(object value)
			{
			if( value is T ) Remove( (T)value );
			}



		public bool IsReadOnly
			{
			get { return false; }
			}



		public bool IsFixedSize
			{
			get
				{
				return false;
				}
			}



		public object SyncRoot
			{
			get
				{
				throw new NotImplementedException();
				}
			}



		public bool IsSynchronized
			{
			get
				{
				throw new NotImplementedException();
				}
			}



		public virtual void Sort()
			{
			List<T> list = new List<T>( this );
			list.Sort();
			this.Clear();
			this.AddRange( list );
			}



		public IEnumerator<T> GetEnumerator()
			{
			return list.GetEnumerator();
			}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
			return list.GetEnumerator();
			}



		public delegate void ListChangedEventHandler(object sender, ListChangedEventArgs<T> e);
		public class ListChangedEventArgs<U> : EventArgs
			{
			public U Item
				{
				get
					{
					if( _Items.Count < 1 ) return default( U );
					return _Items[0];
					}
				}
			public U NewItem
				{
				get
					{
					if( _Items.Count < 1 ) return default( U );
					return _Items[0];
					}
				}
			public U OldItem
				{
				get
					{
					if( _Items.Count < 2 ) return default( U );
					return _Items[1];
					}
				}
			public ReadOnlyCollection<U> Items { get { return new ReadOnlyCollection<U>( _Items ); } }
			private List<U> _Items = new List<U>();

			internal ListChangedEventArgs(U item)
				{
				_Items.Add( item );
				}

			internal ListChangedEventArgs(U newItem, U oldItem)
				{
				_Items.Add( newItem );
				_Items.Add( oldItem );
				}

			internal ListChangedEventArgs(ICollection<U> items)
				{
				_Items.AddRange( items );
				}
			}

		}


	public interface IProjectList : IList
		{
		Type GenericType { get; }
		}


	/*
	/// <summary>拡張ジェネリックリスト。null非許容。</summary>
	/// <typeparam name="T"></typeparam>
	public class ProjectList<T> : Collection<T>
		{
		/// <summary>UndoRedoに使用する名前。</summary>
		[XmlIgnore]
		public string UndoRedoName { get; set; }
		/// <summary>UndoRedoに使用するメッセージ。</summary>
		[XmlIgnore]
		public string UndoRedoMessage { get; set; }

		/// <summary>アイテムが挿入されたとき実行される。</summary>
		public event ListChangedEventHandler ItemInserted;

		/// <summary>アイテムが設定されたとき実行される。</summary>
		public event ListChangedEventHandler ItemSet;

		/// <summary>アイテムが除外されたとき実行される。</summary>
		public event ListChangedEventHandler ItemRemoved;

		/// <summary>全てのアイテムが除外されたとき実行される。</summary>
		public event ListChangedEventHandler ItemsCleared;



		/// <summary>デフォルトコンストラクタ。</summary>
		public ProjectList()
			{
			UndoRedoName = Application.SingletonInstance.CurrentLanguage.ListEx_DefaultValueChanged.Name;
			UndoRedoMessage = Application.SingletonInstance.CurrentLanguage.ListEx_DefaultValueChanged.Mess;
			}



		/// <summary>IListを追加するコンストラクタ。</summary>
		public ProjectList(IList<T> list)
			: base( list )
			{
			UndoRedoName = Application.SingletonInstance.CurrentLanguage.ListEx_DefaultValueChanged.Name;
			UndoRedoMessage = Application.SingletonInstance.CurrentLanguage.ListEx_DefaultValueChanged.Mess;
			}



		public override string ToString()
			{
			return "[" + GetType().Name + "]";
			}


		/// <summary>アイテムの挿入。</summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		protected override void InsertItem(int index, T item)
			{
			if( item == null ) throw new ArgumentNullException();
			Action undo = new Action( () => { base.RemoveItem( index ); } );
			Action redo = new Action( () => { base.InsertItem( index, item ); } );
			UndoRedoPair urPair = new UndoRedoPair( UndoRedoName, UndoRedoMessage, undo, redo );
			Application.SingletonInstance.AddUndoRedoPair( urPair );
			base.InsertItem( index, item );
			if( ItemInserted != null ) ItemInserted( this, new ListChangedEventArgs<T>( item ) );
			}



		/// <summary>アイテムの変更。</summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		protected override void SetItem(int index, T item)
			{
			if( item == null ) throw new ArgumentNullException();
			T oldItem = this[index];
			Action undo = new Action( () => { base.SetItem( index, oldItem ); } );
			Action redo = new Action( () => { base.SetItem( index, item ); } );
			UndoRedoPair urPair = new UndoRedoPair( UndoRedoName, UndoRedoMessage, undo, redo );
			Application.SingletonInstance.AddUndoRedoPair( urPair );
			base.SetItem( index, item );
			if( ItemSet != null ) ItemSet( this, new ListChangedEventArgs<T>( item, oldItem ) );
			}



		/// <summary>アイテムの削除。</summary>
		/// <param name="index"></param>
		protected override void RemoveItem(int index)
			{
			T oldItem = this[index];
			Action undo = new Action( () => { base.InsertItem( index, oldItem ); } );
			Action redo = new Action( () => { base.RemoveItem( index ); } );
			UndoRedoPair urPair = new UndoRedoPair( UndoRedoName, UndoRedoMessage, undo, redo );
			Application.SingletonInstance.AddUndoRedoPair( urPair );
			base.RemoveItem( index );
			if( ItemRemoved != null ) ItemRemoved( this, new ListChangedEventArgs<T>( oldItem ) );
			}



		/// <summary>全アイテムの削除。</summary>
		protected override void ClearItems()
			{
			List<T> oldList = new List<T>( this );
			Action undo = new Action( () => { for( int i = 0 ; i < oldList.Count ; i++ )base.InsertItem( i, oldList[i] ); } );
			Action redo = new Action( () => { base.ClearItems(); } );
			UndoRedoPair urPair = new UndoRedoPair( UndoRedoName, UndoRedoMessage, undo, redo );
			Application.SingletonInstance.AddUndoRedoPair( urPair );
			base.ClearItems();
			if( ItemsCleared != null ) ItemsCleared( this, new ListChangedEventArgs<T>( oldList ) );
			}



		public delegate void ListChangedEventHandler(object sender, ListChangedEventArgs<T> e);
		public class ListChangedEventArgs<U> : EventArgs
			{
			public U Item
				{
				get
					{
					if( _Items.Count < 1 ) return default( U );
					return _Items[0];
					}
				}
			public U NewItem
				{
				get
					{
					if( _Items.Count < 1 ) return default( U );
					return _Items[0];
					}
				}
			public U OldItem
				{
				get
					{
					if( _Items.Count < 2 ) return default( U );
					return _Items[1];
					}
				}
			public ReadOnlyCollection<U> Items { get { return new ReadOnlyCollection<U>( _Items ); } }
			private List<U> _Items = new List<U>();

			internal ListChangedEventArgs(U item)
				{
				_Items.Add( item );
				}

			internal ListChangedEventArgs(U newItem, U oldItem)
				{
				_Items.Add( newItem );
				_Items.Add( oldItem );
				}

			internal ListChangedEventArgs(ICollection<U> items)
				{
				_Items.AddRange( items );
				}
			}
		}
	*/
	}
