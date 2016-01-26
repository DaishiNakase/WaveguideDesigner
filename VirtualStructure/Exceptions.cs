using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hslab.VirtualStructure
	{
	/// <summary>シェイプを複数のレイヤーに登録しようとしたときにスローされます。</summary>
	public class ShapeMultipleRegisteredException : Exception
		{
		}



	/// <summary>レイヤーを複数のグラフィクスに登録しようとしたときにスローされます。</summary>
	public class LayerMultipleRegisteredException:Exception
		{
		}
	}
