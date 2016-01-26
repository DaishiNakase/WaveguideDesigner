using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;



namespace Hslab.WaveguideDesigner
	{
	/// <summary>UndoとRedoの情報のペア。</summary>
	public class UndoRedoPair
		{
		/// <summary>名前。</summary>
		public string Name { get; set; }

		/// <summary>メッセージ。</summary>
		public string Message { get; set; }

		/// <summary>Undo時に実行すべきアクション。</summary>
		public virtual Action Undo { get { return _Undo; } }
		private Action _Undo;

		/// <summary>Redo時に実行すべきアクション。</summary>
		public virtual Action Redo { get { return _Redo; } }
		private Action _Redo;

		/// <summary>コンストラクタ。</summary>
		/// <param name="str"></param>
		/// <param name="undo"></param>
		/// <param name="redo"></param>
		public UndoRedoPair(UndoRedoPairString str, Action undo, Action redo)
			:this(str.Name,str.Mess,undo,redo)
			{
			}

		/// <summary>コンストラクタ。</summary>
		/// <param name="name"></param>
		/// <param name="message"></param>
		/// <param name="undo"></param>
		/// <param name="redo"></param>
		public UndoRedoPair(string name,string message, Action undo, Action redo)
			{
			Name = name;
			Message = message;
			_Undo = undo;
			_Redo = redo;
			}



		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			return LanguagePack.MakePlainString(Name);
			}
		}



	/// <summary>UndoRedoPairを保存するリスト。</summary>
	public class UndoRedoList : System.Collections.ObjectModel.Collection<UndoRedoPair>
		{
		/// <summary>アプリケーション。</summary>
		public Application Application { get { return Application.SingletonInstance; } }

		/// <summary>アイテムの挿入。</summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		protected override void InsertItem(int index, UndoRedoPair item)
			{
			if( Application.EnableUndoRedoStoring )
				base.InsertItem( index, item );
			}

		/// <summary>アイテムの変更。</summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		protected override void SetItem(int index, UndoRedoPair item)
			{
			if( Application.EnableUndoRedoStoring )
				base.SetItem( index, item );
			}

		/// <summary>アイテムの削除。</summary>
		/// <param name="index"></param>
		protected override void RemoveItem(int index)
			{
			if( Application.EnableUndoRedoStoring )
				base.RemoveItem( index );
			}

		/// <summary>全アイテムの削除。</summary>
		protected override void ClearItems()
			{
			if( Application.EnableUndoRedoStoring )
				base.ClearItems();
			}
		}

	/*
	/// <summary></summary>
	public class ChangeValueUndoRedoPair : UndoRedoPair
		{
		/// <summary>プロパティ値の変更を受けたインスタンス。</summary>
		public object TargetInstance { get; private set; }

		/// <summary>変更を受けたプロパティのプロパティ情報。</summary>
		public PropertyInfo TargetPropertyInfo { get; private set; }

		/// <summary>変更前の値。</summary>
		public object BeforeValue { get; private set; }

		/// <summary>変更後の値。</summary>
		public object AfterValue { get; private set; }

		/// <summary></summary>
		public override Action Undo
			{
			get { return new Action( delegate() { TargetPropertyInfo.SetValue( TargetInstance, BeforeValue ); } ); }
			}

		/// <summary></summary>
		public override Action Redo
			{
			get { return new Action( delegate() { TargetPropertyInfo.SetValue( TargetInstance, AfterValue ); } ); }
			}



		/// <summary></summary>
		public ChangeValueUndoRedoPair(object targetInstance,PropertyInfo targetPropertyInfo, object beforeValue, object afterValue)
			{
			TargetInstance = targetInstance;
			TargetPropertyInfo = targetPropertyInfo;
			BeforeValue = beforeValue;
			AfterValue = afterValue;
			}
		}
	 */
	}
