using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public abstract class MeepGeometricObject : MeepObjectBase
		{
		protected abstract string ClassName { get; }

		public MeepMaterialType Material
			{
			get { return _Material; }
			set
				{
				if( value == null ) throw new ArgumentNullException();
				_Material = value;
				}
			}
		private MeepMaterialType _Material;
		public MeepVector3 Center { get; set; }

		public MeepGeometricObject(MeepMaterialType material, MeepVector3 center)
			{
			Material = material;
			Center = center;
			}

		public override string ToString()
			{
			return string.Format( "(make {0} (material {1}) (center {2}) {3})", ClassName, Material.Name, Center, MakeAdditionalValues() );
			}


		protected abstract string MakeAdditionalValues();
		}
	}
