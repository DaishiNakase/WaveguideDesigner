using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public class MeepVolume : MeepObjectBase
		{
		public MeepVector3 Center { get; set; }
		public MeepVector3 Size { get; set; }

		public MeepVolume(MeepVector3 center, MeepVector3 size)
			{
			Center = center;
			Size = size;
			}

		public override string ToString()
			{
			return string.Format( "(volume (center {0}) (size {1}))", Center,Size );
			}
		}
	}
