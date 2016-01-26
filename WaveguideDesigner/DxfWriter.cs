using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf;
using netDxf.Entities;
using netDxf.Tables;
using Hslab.VirtualStructure;
using Hslab.WaveguideDesigner.ProjectData;

namespace Hslab.WaveguideDesigner
	{
	public class DxfWriter
		{
		public static Application Application { get { return Application.SingletonInstance; } }


		public string FileName { get; private set; }

		public DxfWriter(string path)
			{
			FileName = path;
			}



		public void WriteProject(WaveguideDesignerProjectData project)
			{
			if( project == null ) return;

			Type type;
			EntityObject obj = null;
			DxfDocument doc = new DxfDocument();

			doc.Name = project.Name;

			Layer dxfLayer;
			LayerData layerData;
			foreach( VirtualLayer vLayer in project.VirtualGraphics.Layers )
				{
				layerData = null;
				foreach( LayerData tmp in project.Layers )
					if( tmp.VirtualLayer == vLayer )
						{
						layerData = tmp;
						break;
						}
				if( layerData == null ) continue;
				dxfLayer = new Layer( layerData.Name );
				dxfLayer.Color.Index = (short)layerData.LayerNumber;
				doc.Layers.Add( dxfLayer );

				foreach( VirtualShapeBase vShape in vLayer.Shapes )
					{
					type = vShape.GetType();
					if( type == typeof( VirtualRectangle ) )
						{
						VirtualRectangle rect = (VirtualRectangle)vShape;
						Polyline dxfrect = new Polyline();
						obj = new Polyline();
						dxfrect.IsClosed = true;
						dxfrect.Vertexes.Add( new PolylineVertex( rect.Location.X, rect.Location.Y, 0 ) );
						dxfrect.Vertexes.Add( new PolylineVertex( rect.Location.X + rect.Size.W, rect.Location.Y, 0 ) );
						dxfrect.Vertexes.Add( new PolylineVertex( rect.Location.X + rect.Size.W, rect.Location.Y + rect.Size.H, 0 ) );
						dxfrect.Vertexes.Add( new PolylineVertex( rect.Location.X, rect.Location.Y + rect.Size.H, 0 ) );
						dxfrect.Vertexes.Add( new PolylineVertex( rect.Location.X, rect.Location.Y, 0 ) );
						obj = dxfrect;
						}
					else if( type == typeof( VirtualPolygon ) )
						{
						VirtualPolygon poly = (VirtualPolygon)vShape;
						Polyline dxfpoly = new Polyline();
						dxfpoly.IsClosed = true;
						foreach( PointD p in poly.Vertices )
							dxfpoly.Vertexes.Add( conv( p ) );
						dxfpoly.Vertexes.Add( conv( poly.Vertices[0] ) );
						obj = dxfpoly;
						}
					else if( type == typeof( VirtualEllipse ) )
						{
						VirtualEllipse elli = (VirtualEllipse)vShape;
						Ellipse dxfelli = new Ellipse();
						dxfelli.Center = new netDxf.Vector3( elli.Center.X, elli.Center.Y, 0 );
						dxfelli.StartAngle = 0;
						dxfelli.EndAngle = 360;
						dxfelli.MajorAxis = Math.Max( elli.Radius.W, elli.Radius.H );
						dxfelli.MinorAxis = Math.Min( elli.Radius.W, elli.Radius.H );
						dxfelli.Rotation = elli.Radius.W >= elli.Radius.H ? 0 : 90;
						obj = dxfelli;
						}
					else if( type == typeof( VirtualPie ) )
						{
						VirtualPie pie = (VirtualPie)vShape;
						Ellipse dxfelli = new Ellipse();
						dxfelli.Center = new netDxf.Vector3( pie.Center.X, pie.Center.Y, 0 );
						dxfelli.StartAngle = pie.StartAngle;
						dxfelli.EndAngle = pie.EndAngle;
						dxfelli.MajorAxis = Math.Max( pie.Radius.W, pie.Radius.H );
						dxfelli.MinorAxis = Math.Min( pie.Radius.W, pie.Radius.H );
						dxfelli.Rotation = pie.Radius.W >= pie.Radius.H ? 0 : 90;
						obj = dxfelli;
						}
					else obj = null;

					if( obj == null )
						continue;
					obj.Layer = dxfLayer;
					doc.AddEntity( obj );
					}
				}

			doc.Save( FileName );
			}


		private PolylineVertex conv(PointD p)
			{
			return new PolylineVertex( p.X, p.Y, 0 );
			}

		}
	}
