using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Hslab.VirtualStructure
	{
	public partial class VirtualLayer
		{

		/// <summary>このレイヤーを持っているグラフィックス。</summary>
		public VirtualGraphics ParentGraphics { get; internal set; }
		/// <summary>デフォルトの図形境界ペン。</summary>
		public virtual Pen DefaultShapeBorder { get; set; }
		/// <summary>デフォルトの図形塗潰しブラシ。</summary>
		public virtual Brush DefaultShapeFill { get; set; }
		/// <summary>オブジェクトが可視であるか。</summary>
		public virtual bool Visible { get; set; }

		/// <summary>コンストラクタ。</summary>
		public VirtualLayer()
			{
			Shapes = new VirtualShapeBaseCollection( this );
			DefaultShapeBorder = Pens.White;
			DefaultShapeFill = Brushes.White;
			Visible = true;
			}



		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public VirtualLayer(VirtualLayer previous)
			{
			ParentGraphics = null;
			DefaultShapeBorder = previous.DefaultShapeBorder;
			DefaultShapeFill = previous.DefaultShapeFill;
			}

		/// <summary>このレイヤーに登録されたシェイプのリスト。</summary>
		public VirtualShapeBaseCollection Shapes { get; private set; }


		}
	}
