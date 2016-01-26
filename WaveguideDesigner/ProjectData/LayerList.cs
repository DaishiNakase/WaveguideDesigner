using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	public class LayerList : ProjectList<LayerData>
		{
		public LayerList() : base() { }

		public LayerList(IList<LayerData> list) : base( list ) { }


		public override void Add(LayerData item)
			{
			base.Add( item );
			PushLayerNumber( Count - 1 );
			}

		public override void AddRange(IList<LayerData> items)
			{
			int index = Count;
			base.AddRange( items );
			PushLayerNumber( index );
			}

		public override void Insert(int index, LayerData item)
			{
			base.Insert( index, item );
			PushLayerNumber( index );
			}

		public override void Sort()
			{
			base.Sort();
			PushLayerNumber( 1 );
			}


		// 自身がひとつ前のレイヤとレイヤ番号が同じであるとき、自身のレイヤ番号を押し出す
		private void PushLayerNumber(int index)
			{
			if( index >= Count ) return;
			if( index > 0 && this[index - 1].LayerNumber >= this[index].LayerNumber )
				{
				this[index].LayerNumber++;
				PushLayerNumber( index++ );
				}
			}
		}
	}
