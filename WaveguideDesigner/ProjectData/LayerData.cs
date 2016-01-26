using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using System.IO;
using Hslab.VirtualStructure;

namespace Hslab.WaveguideDesigner.ProjectData
	{



	/// <summary>レイヤー情報のプロジェクトデータ。</summary>
	public partial class LayerData : NamedDataBase,IComparable<LayerData>
		{
		#region project data properties

		[PropertyEditorAttribute( 1 )]
		public int LayerNumber { get { return _LayerNumber; }
			set {
				if( value < 1 ) throw new ArgumentOutOfRangeException();
				_LayerNumber = value;
				} }
		private int _LayerNumber=1;

		/// <summary>レイヤープロファイル。</summary>
		[PropertyEditorAttribute( 2 )]
		public LayerProfileData Profile
			{
			get { return _Profile; }
			set
				{
				if( _Profile != null ) _Profile.Parent = null;
				_Profile = value;
				value.Parent = this;
				if( _Profile != null && VirtualLayer != null )
					{
					VirtualLayer.DefaultShapeFill = _Profile.RenderSetting.Fill;
					VirtualLayer.DefaultShapeBorder = Profile.RenderSetting.Border;
					}
				}
			}
		private LayerProfileData _Profile;



#warning 新しいGeometricObjectのXmlArryItemを追加すること
		/// <summary>レイヤーに登録された構造オブジェクトのリスト。</summary>
		[PropertyEditorAttribute( 3 ),
		XmlArrayItem( typeof( RectangleCoordinateFunctionalPathData ) ),
		XmlArrayItem( typeof( PolarCoordinateFunctionalPathData ) ),
		XmlArrayItem( typeof( CoordinateListPathData ) )]
		public GeometricObjectList GeometricObjects { get; set; }

		#endregion



		#region runtime utility properties

		/// <summary>VirtualGraphics用レイヤ。</summary>
		[XmlIgnore]
		public VirtualLayer VirtualLayer
			{
			get { return _VirtualLayer; }
			private set
				{
				_VirtualLayer = value;
				value.DefaultShapeBorder = Profile?.RenderSetting?.Border;
				value.DefaultShapeFill = Profile?.RenderSetting?.Fill;
				}
			}
		private VirtualLayer _VirtualLayer;

		/// <summary>MeepのGeometricObjectを生成するためのクラス。</summary>
		[XmlIgnore]
		public MeepGeometricObjectMaker MeepMaker { get; private set; }

		#endregion




		#region constructors

		/// <summary>デフォルトコンストラクタ。</summary>
		public LayerData()
			{
			Name = "New Layer";
			Profile = new LayerProfileData();
			VirtualLayer = new VirtualLayer();
			GeometricObjects = new GeometricObjectList( this );
			MeepMaker = new MeepGeometricObjectMaker( this );
			}



		/// <summary>コピーコンストラクタ。</summary>
		/// <param name="previous"></param>
		public LayerData(LayerData previous) : base( previous, "_copy" )
			{
			VirtualLayer = new VirtualLayer();
			GeometricObjects = new GeometricObjectList( this );
			foreach( GeometricObjectDataBase obj in GeometricObjects )
				GeometricObjects.Add( obj.MakeDeepCopy() );
			MeepMaker = new MeepGeometricObjectMaker( this );
			}



		~LayerData()
			{
			foreach( WaveguideDesignerProjectData proj in WaveguideDesignerProjectData.Projects )
				Application.VirtualGraphics?.Layers?.Remove( VirtualLayer );
			}

		#endregion



		#region methods

		/// <summary></summary>
		/// <returns></returns>
		public override string ToString()
			{
			return base.ToString( ",material:" + Profile.Material.Name );
			}

		public int CompareTo(LayerData other)
			{
			return LayerNumber - other.LayerNumber;
			}

		#endregion



		#region inner classes

		/// <summary>GeometricObjectをレイヤーに登録するためのリスト。</summary>
		public class GeometricObjectList : ProjectList<GeometricObjectDataBase>
			{
			/// <summary>レイヤ。</summary>
			[XmlIgnore]
			public LayerData Layer { get; private set; }



			/// <summary>デフォルトコンストラクタ。</summary>
			public GeometricObjectList(LayerData layer)
				{
				ConstructorMethod( layer );
				}



			/// <summary>IListを追加するコンストラクタ。</summary>
			public GeometricObjectList(LayerData layer, IList<GeometricObjectDataBase> list)
				: base( list )
				{
				ConstructorMethod( layer );
				}



			private void ConstructorMethod(LayerData layer)
				{
				Layer = layer;
				UndoRedoName = "ListElementChanged";
				UndoRedoMessage = "Some list elements were changed.";
				ItemInserted += (obj, e) =>
					{
						e.Item.Parent = Layer;
						RefreshVirtualLayer();
					};
				ItemSet += (obj, e) =>
					{
						e.NewItem.Parent = Layer;
						e.OldItem.Parent = null;
						RefreshVirtualLayer();

					};
				ItemRemoved += (obj, e) =>
					{
						e.Item.Parent = null;
						RefreshVirtualLayer();
					};
				ItemsCleared += (obj, e) =>
					{
						foreach( GeometricObjectDataBase gobj in e.Items )
							{
							gobj.Parent = null;
							RefreshVirtualLayer();
							}
					};

				}


			private void RefreshVirtualLayer()
				{
				Layer.VirtualLayer.Shapes.Clear();
				foreach( GeometricObjectDataBase obj in this )
					Layer.VirtualLayer.Shapes.Add( obj.VirtualShape );
				}



			}

		#endregion
		}




	}
