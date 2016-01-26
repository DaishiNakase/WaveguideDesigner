using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Hslab.VirtualStructure
	{
	public partial class VirtualGraphics
		{
		/// <summary></summary>
		public class VirtualLayerCollection : Collection<VirtualLayer>
			{
			/// <summary>このコレクションを持つレイヤー。</summary>
			public VirtualGraphics ParentGraphics { get; private set; }

			/// <summary>常に最上位に表示するレイヤ。</summary>
			public VirtualLayer AlwaysTopLayer
				{
				get { return _AlwaysTopLayer; }
				set
					{
					_AlwaysTopLayer = value;
					if( value != null && !this.Contains( value ) ) this.Add( value );
					}
				}
			private VirtualLayer _AlwaysTopLayer;



			internal VirtualLayerCollection(VirtualGraphics parent)
				{
				ParentGraphics = parent;
				AlwaysTopLayer = null;
				}



			/// <summary></summary>
			/// <param name="index"></param>
			/// <param name="item"></param>
			protected override void SetItem(int index, VirtualLayer item)
				{
				if( item.ParentGraphics != null ) throw new ShapeMultipleRegisteredException();
				base.SetItem( index, item );
				item.ParentGraphics = ParentGraphics;
				}

			/// <summary></summary>
			/// <param name="index"></param>
			/// <param name="item"></param>
			protected override void InsertItem(int index, VirtualLayer item)
				{
				if( item.ParentGraphics != null ) throw new ShapeMultipleRegisteredException();
				if( item == AlwaysTopLayer )
					base.InsertItem( Count, item );
				else
					{
					if( index == Count && this[Count - 1] == AlwaysTopLayer ) index--;
					base.InsertItem( index, item );
					}
				item.ParentGraphics = ParentGraphics;
				}

			/// <summary></summary>
			/// <param name="index"></param>
			protected override void RemoveItem(int index)
				{
				VirtualLayer layer = this[index];
				base.RemoveItem( index );
				layer.ParentGraphics = null;
				}

			/// <summary></summary>
			protected override void ClearItems()
				{
				List<VirtualLayer> list = new List<VirtualLayer>( this );
				base.ClearItems();
				foreach( VirtualLayer layer in list ) layer.ParentGraphics = null;
				}
			}



		}
	}
