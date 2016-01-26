using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public class MeepPml : MeepObjectBase
		{
		public double Thicknes { get; set; }

		public Direction Direction
			{
			get { return _Direction; }
			set
				{
				switch(value)
					{
					case WaveguideDesigner.Direction.R:
					case WaveguideDesigner.Direction.P:
						throw new ArgumentException();
					}
				_Direction = value;
				}
			}
		private Direction _Direction;

		public BoundarySide Side { get; set; }

		public double Strength { get; set; }

		public double RAsymptotic { get; set; }

		public MeepPml(double thickness)
			{
			Thicknes = thickness;
			Direction = Direction.All;
			Side = BoundarySide.All;
			Strength = 1.0;
			RAsymptotic = 1e-15;
			}

		public override string ToString()
			{
			string res = "(make pml";
			res += string.Format(" (thickness {0})",Thicknes);
			if( Direction != Direction.All ) res+=string.Format( " (direction {0})",Direction.ToStringEx() );
			if( Side != BoundarySide.All ) res += string.Format( " (side {0})",Side.ToStringEx() );
			if( Strength != 1.0 ) res += string.Format( " (strength {0})",Strength );
			if( RAsymptotic != 1e-15 ) res += string.Format( "(R-asymptotic {0})",RAsymptotic );
			res += ")";
			return res;
			}
		}
	}
