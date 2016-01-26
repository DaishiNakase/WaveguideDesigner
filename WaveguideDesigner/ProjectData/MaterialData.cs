using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hslab.MeepManager.WaveguideDesigner;
using System.Xml.Serialization;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	/// <summary>材料情報のプロジェクトデータ。</summary>
	public class MaterialData : NamedDataBase
		{

		/// <summary></summary>
		public enum MaterialType
			{
			/// <summary></summary>
			Dielectric,
			/// <summary></summary>
			Metal,
			/// <summary></summary>
			Nothing,
			/// <summary></summary>
			Air,
			/// <summary></summary>
			MagneticConductor,
			/// <summary></summary>
			DirectCoding,
			}


		#region project data properties

		/// <summary></summary>
		[PropertyEditorAttribute( 0 )]
		public override string Name
			{
			get { return base.Name; }
			set
				{
				if( MeepMaterial as MeepDielectric != null ) MeepMaterial.Name = value;
				base.Name = value;
				}
			}



		/// <summary>Meepにおける材料タイプ。</summary>
		[PropertyEditorAttribute( 1 )]
		public MaterialType Type
			{
			get { return _Type; }
			set
				{
				_Type = value;
				}
			}
		private MaterialType _Type;



		/// <summary>屈折率。TypeがDielectricの時のみ有効。</summary>
		[PropertyEditorAttribute( 2 )]
		public double Index
			{
			get { return _Index; }
			set { _Index = value; }
			}
		private double _Index = 1;



		/// <summary>透磁率。TypeがDielectricの時のみ有効。</summary>
		[PropertyEditorAttribute( 3 )]
		public double Mu
			{
			get { return _Mu; }
			set { _Mu = value; }
			}
		private double _Mu = 1;


		/// <summary>導電率。TypeがDielectricの時のみ有効。</summary>
		[PropertyEditorAttribute( 3 )]
		public double Conductivity
			{
			get { return _Conductivity; }
			set { _Conductivity = value; }
			}
		private double _Conductivity = 1;



		/// <summary>Meepのコードによって直接マテリアルを設定するためのコード。TypeがDirectCodingの時のみ有効。</summary>
		[PropertyEditorAttribute( 4 )]
		public string MeepCode
			{
			get { return _MeepCode; }
			set { _MeepCode = value; }
			}
		private string _MeepCode = "(make dielectric (index 1))";

		#endregion



		#region runtime utility properties

		/// <summary></summary>
		[XmlIgnore]
		public MeepMaterialType MeepMaterial
			{
			get
				{
				MeepMaterialType mat;
				switch( Type )
					{
					case MaterialType.Dielectric:
						mat = new MeepDielectric( Name, Index, Mu, Conductivity ); break;
					case MaterialType.Metal:
						mat = MeepMaterialType.Metal; break;
					case MaterialType.Nothing:
						mat = MeepMaterialType.Nothing; break;
					case MaterialType.Air:
						mat = MeepMaterialType.Air; break;
					case MaterialType.MagneticConductor:
						mat = MeepMaterialType.PerfectMagneticConductor; break;
					case MaterialType.DirectCoding:
						mat = new MeepMaterialType.MeepDirectCodingMaterial( Name, MeepCode );
						break;
					default:
						throw new InvalidOperationException();
					}
				return mat;
				}
			}

		#endregion




		#region constructors

		/// <summary>デフォルトコンストラクタ。非推奨。Xmlデシリアイズのために定義してある。</summary>
		public MaterialData()
			: this( MaterialType.Dielectric )
			{
			Name = "NewMaterial";
			}



		/// <summary>通常のコンストラクタ。</summary>
		/// <param name="type"></param>
		public MaterialData(MaterialType type)
			{
			Name = "NewMaterial";
			Type = type;
			Index = 1;
			Mu = 1;
			Conductivity = 0;
			}



		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public MaterialData(MaterialData previous) : base( previous )
			{
			Type = previous.Type;
			Index = previous.Index;
			Mu = previous.Mu;
			Conductivity = previous.Conductivity;
			}

		#endregion





		#region methods

		/// <summary> 等値演算子</summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
			{
			if( obj == null || this.GetType() != obj.GetType() ) return false;
			MaterialData mat = obj as MaterialData;
			switch(Type)
				{
				case MaterialType.Air:
				case MaterialType.MagneticConductor:
				case MaterialType.Metal:
				case MaterialType.Nothing:
					return Type == mat.Type;
				case MaterialType.Dielectric:
					return ( Name == mat.Name ) & ( Index == mat.Index ) & ( Mu == mat.Mu ) & ( Conductivity == mat.Conductivity );
				case MaterialType.DirectCoding:
					return ( Name == mat.Name ) & ( MeepCode == mat.MeepCode );
				}
			return base.Equals( obj );
			}

		#endregion



		#region inner classes

		#endregion
		}


	}
