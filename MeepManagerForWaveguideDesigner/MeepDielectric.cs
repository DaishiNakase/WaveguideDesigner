using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public class MeepDielectric : MeepMaterialType
		{
		public string VariableName { get; set; }

		public double Index { get; set; }

		public double Mu { get; set; }

		public double Conductivity { get; set; }

		public MeepDielectric(string name, double index)
			: this( name, index, 1, 0 )
			{

			}

		public MeepDielectric(string name, double index, double mu, double conductivity)
			: base( name )
			{
			Index = index;
			Mu = mu;
			Conductivity = conductivity;
			}

		public override string ToString()
			{
			string res=string.Format("(make dielectric (index {0})",Index);
			if( Mu != 1 ) res += string.Format(" (mu {0})",Mu);
			if( Conductivity != 0 ) res += string.Format( " (D-conductivity {0})",Conductivity );
			res += ")";
			return res;
			}

		public override bool Equals(MeepMaterialType other)
			{
			if( other == null || this.GetType() != other.GetType() ) return false;
			MeepDielectric _other = other as MeepDielectric;
			return ( Name == _other.Name )
				& ( VariableName == _other.VariableName )
				& ( Index == _other.Index )
				& ( Mu == _other.Mu )
				& ( Conductivity == _other.Conductivity );
			}
		}
	}
