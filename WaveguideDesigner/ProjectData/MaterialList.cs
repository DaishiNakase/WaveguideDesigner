using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	public class MaterialList:ProjectList<MaterialData>
		{
		public MaterialList() : base() { }

		public MaterialList(IList<MaterialData> list) : base( list ) { }
		}
	}
