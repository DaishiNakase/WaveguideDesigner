using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public abstract class MeepMaterialType : MeepObjectBase,IEquatable<MeepMaterialType>
		{
		public static MeepMaterialType Air { get { return new MeepDefinedMaterial( "air" ); } }
		public static MeepMaterialType Vacuum { get { return new MeepDefinedMaterial( "vacuum" ); } }
		public static MeepMaterialType PerfectElectricConductor { get { return new MeepDefinedMaterial( "perfect-electric-conductor" ); } }
		public static MeepMaterialType Metal { get { return new MeepDefinedMaterial( "metal" ); } }
		public static MeepMaterialType PerfectMetal { get { return new MeepDefinedMaterial( "__perfect-metal","(make perfect-metal)" ); } }
		public static MeepMaterialType PerfectMagneticConductor { get { return new MeepDefinedMaterial( "perfect-magnetic-conductor" ); } }
		public static MeepMaterialType Nothing { get { return new MeepDefinedMaterial( "nothing" ); } }




		public string Name
			{
			get { return _Name; }
			set
				{
				if( !value.IsValidNameInScheme() ) _Name = "NewMaterial";
				else _Name = value;
				}
			}
		private string _Name = "NewMaterial";



		public MeepMaterialType(string name)
			{
			Name = name;
			}

		

		public abstract bool Equals(MeepMaterialType other);



		public override int GetHashCode()
			{
			return Name.GetHashCode();
			}



		public class MeepDefinedMaterial : MeepMaterialType
			{
			private string MaterialName;

			internal MeepDefinedMaterial(string matName)
				: this( "__" + matName, matName )
				{
				}

			internal MeepDefinedMaterial(string name, string matName)
				: base( name )
				{
				MaterialName = matName;
				}


			public override string ToString()
				{
				return MaterialName;
				}


			public override bool Equals(MeepMaterialType other)
				{
				if( other == null || this.GetType() != other.GetType() ) return false;
				MeepDefinedMaterial _other = other as MeepDefinedMaterial;
				return this.MaterialName == _other.MaterialName;
				}


			public override int GetHashCode()
				{
				return base.GetHashCode() & MaterialName.GetHashCode();
				}
			}


		
		// Meepの形式で直接マテリアルを設定する。
		// 例:
		// MeepDirectCodingMaterial mat=new MeepDirectCodingMaterial("test-material");
		// mat.MeepCode="(make dielectric (index 2))";
		public class MeepDirectCodingMaterial : MeepMaterialType
			{
			public string MeepCode { get; set; }

			public MeepDirectCodingMaterial(string name,string code) : base( name )
				{
				MeepCode = code;
				}

			public override string ToString()
				{
				return MeepCode;
				}

			public override bool Equals(MeepMaterialType other)
				{
				if( other == null || this.GetType() != other.GetType() ) return false;
				MeepDirectCodingMaterial _other = other as MeepDirectCodingMaterial;
				return ( Name == _other.Name ) & ( MeepCode == _other.MeepCode );
				}

			public override int GetHashCode()
				{
				return base.GetHashCode()&MeepCode.GetHashCode();
				}
			}
		}


	}
