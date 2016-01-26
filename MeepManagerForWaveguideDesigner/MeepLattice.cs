using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hslab;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public class MeepLattice: MeepObjectBase
		{
		public MeepVector3 Size { get; set; }

		public MeepLattice(MeepVector3 size) { Size = size; }

		public override string ToString()
			{
			return string.Format("(make lattice (size {0}))",Size.ToString());
			}
		}
	}
