using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public class MeepBlock:MeepGeometricObject
		{
		protected override string ClassName
			{
			get { return "block"; }
			}

		public MeepVector3 Size { get; set; }

		public MeepVector3 E1 { get; set; }

		public MeepVector3 E2 { get; set; }

		public MeepVector3 E3 { get; set; }


		public MeepBlock(MeepMaterialType material, MeepVector3 center, MeepVector3 size)
			:base(material,center)
			{
			Size = size;
			E1 = MeepVector3.AxisX;
			E2 = MeepVector3.AxisY;
			E3 = MeepVector3.AxisZ;
			}

		protected override string MakeAdditionalValues()
			{
			string res = "";
			res += "(size "+Size.ToString()+")";
			if( E1 != MeepVector3.AxisX ) res += " (e1 " + E1.ToString() + ")";
			if( E2 != MeepVector3.AxisY ) res += " (e2 " + E2.ToString() + ")";
			if( E3 != MeepVector3.AxisZ ) res += " (e3 " + E3.ToString() + ")";
			return res;
			}
		}
	}
