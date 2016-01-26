using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Hslab.VirtualStructure
	{
	/// <summary></summary>
	public partial class VirtualLayer
		{
		/// <summary></summary>
		public class VirtualShapeBaseCollection : Collection<VirtualShapeBase>
			{
			/// <summary>このコレクションを持つレイヤー。</summary>
			public VirtualLayer ParentLayer { get; private set; }

			/// <summary>デフォルトコンストラクタ。</summary>
			public VirtualShapeBaseCollection() { }

			/// <summary>コンストラクタ。</summary>
			/// <param name="items">追加する要素のリスト。</param>
			public VirtualShapeBaseCollection(IEnumerable<VirtualShapeBase> items)
				{
				AddRange( items );
				}



			/// <summary></summary>
			/// <param name="items"></param>
			public void AddRange(IEnumerable<VirtualShapeBase> items)
				{
				foreach( VirtualShapeBase item in items )
					this.Add( item );
				}


			internal VirtualShapeBaseCollection(VirtualLayer parent)
				{
				ParentLayer = parent;
				}

			/// <summary></summary>
			/// <param name="index"></param>
			/// <param name="item"></param>
			protected override void SetItem(int index, VirtualShapeBase item)
				{
				if( item.ParentLayer != null ) throw new ShapeMultipleRegisteredException();
				base.SetItem( index, item );
				item.ParentLayer = ParentLayer;
				}

			/// <summary></summary>
			/// <param name="index"></param>
			/// <param name="item"></param>
			protected override void InsertItem(int index, VirtualShapeBase item)
				{
				if( item.ParentLayer != null ) throw new ShapeMultipleRegisteredException();
				base.InsertItem( index, item );
				item.ParentLayer = ParentLayer;
				}

			/// <summary></summary>
			/// <param name="index"></param>
			protected override void RemoveItem(int index)
				{
				VirtualShapeBase shape = this[index];
				base.RemoveItem( index );
				shape.ParentLayer = null;
				}

			/// <summary></summary>
			protected override void ClearItems()
				{
				List<VirtualShapeBase> list = new List<VirtualShapeBase>( this );
				base.ClearItems();
				foreach( VirtualShapeBase shape in list ) shape.ParentLayer = null;
				}

			}
		}
	}
