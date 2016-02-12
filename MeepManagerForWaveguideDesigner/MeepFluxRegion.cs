using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public class MeepFluxRegion : MeepObjectBase
		{
		public MeepVector3 Center { get; set; }

		public MeepVector3 Size { get; set; }

		public Direction Direction { get; set; }

		public double Weight { get; set; }


		
		public MeepFluxRegion(MeepVector3 center)
			{
			Center = center;
			Size = MeepVector3.Zero;
			Direction = Direction.Automatic;
			Weight = 1;
			}



		public override string ToString()
			{
			string res = "(make flux-region";
			res += string.Format( " (center {0})",Center.ToString() );
			if( Size != MeepVector3.Zero ) res += string.Format( " (size {0})", Size.ToString() );
			if( Direction != Direction.Automatic ) res += string.Format( " (direction {0})", Direction.ToStringEx() );
			if( Weight != 1 ) res += string.Format( " (weight {0})", Weight);
			res += ")";
			return res;
			}
		}
	}
