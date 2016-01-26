#if DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hslab.WaveguideDesigner.Forms;
using Hslab.WaveguideDesigner.ProjectData;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Hslab.WaveguideDesigner
	{
	public static class TestCode
		{
		public static void MakeTestProject()
			{
			Application app = Application.SingletonInstance;
			app.OpenedProject = new WaveguideDesignerProjectData();
			app.OpenedProject.Name = "Test Project";
			ProjectManifestData manifest = new ProjectManifestData();
			manifest.SimulationRegion.Dimension = Dimension.Dim2;
			manifest.SimulationRegion.MinX = 0;
			manifest.SimulationRegion.MaxX = 15;
			manifest.SimulationRegion.MinY = -4;
			manifest.SimulationRegion.MaxY = 4;
			manifest.Resolution = 50;
			app.OpenedProject.ProjectManifest = manifest;
			app.OpenedProject.GlobalRenderSetting = new GlobalRenderSettingData();
			app.OpenedProject.GlobalStructureNumerics = new GlobalStructureNumericsData();
			app.OpenedProject.Layers.Add( new LayerData() );
			app.OpenedProject.Layers[0].Name = "Layer1";
			app.OpenedProject.Layers[0].Profile.Material = new MaterialData( MaterialData.MaterialType.Dielectric ) { Name = "material1", Index = 2, };
			RectangleCoordinateFunctionalPathData s = new RectangleCoordinateFunctionalPathData();
			s.PointNum = 100;
			s.XOffset = "0";
			s.YOffset = "1";
			s.CenterX = "15*t";
			s.CenterY = "3*sin(6*pi*t)*t";
			s.LeftWingWidth = "0.2";
			s.RightWingWidth = "0.2";
			app.OpenedProject.Layers[0].GeometricObjects.Add( s );
			s = new RectangleCoordinateFunctionalPathData();
			s.PointNum = 50;
			s.XOffset = "0";
			s.YOffset = "1";
			s.CenterX = "10*t";
			s.CenterY = "-5*t";
			s.LeftWingWidth = "0.2";
			s.RightWingWidth = "0.2*sin(10*t)";
			app.OpenedProject.Layers[0].GeometricObjects.Add( s );
			app.OpenedProject.Layers.Add( new LayerData() );
			app.OpenedProject.Layers[1].Name = "Layer2";
			app.OpenedProject.Layers[1].Profile.Material = new MaterialData( MaterialData.MaterialType.Dielectric ) { Name = "material2", Index = 3, }; ;
			app.OpenedProject.Layers[1].Profile.RenderSetting.Border = Pens.LightGreen;
			app.OpenedProject.Layers[1].Profile.RenderSetting.Fill = new HatchBrush(HatchStyle.DarkDownwardDiagonal,Color.LightGreen);
			s = new RectangleCoordinateFunctionalPathData();
			s.PointNum = 2;
			s.XOffset = "0";
			s.YOffset = "1";
			s.CenterX = "10*t";
			s.CenterY = "5*t";
			s.LeftWingWidth = "0.2";
			s.RightWingWidth = "0.2";
			app.OpenedProject.Layers[1].GeometricObjects.Add( s );

			app.OpenedProject.Layers.Add( new LayerData() );
			app.OpenedProject.Layers[2].Name = "Layer3";
			app.OpenedProject.Layers[2].Profile.Material = new MaterialData( MaterialData.MaterialType.Dielectric ) { Name = "material3", Index = 4, }; ;
			app.OpenedProject.Layers[2].Profile.RenderSetting.Border = Pens.Purple;
			app.OpenedProject.Layers[2].Profile.RenderSetting.Fill = new HatchBrush( HatchStyle.DarkDownwardDiagonal, Color.Purple );
			PolarCoordinateFunctionalPathData p = new PolarCoordinateFunctionalPathData();
			p.PointNum = 10;
			p.XOffset = "10";
			p.YOffset = "0";
			p.CenterRadius = "5*t";
			p.CenterPhase = "4*pi*t";
			p.LeftWingWidth = "0.5*t";
			p.RightWingWidth = "0.25*(1+sin(16*pi*t))";
			app.OpenedProject.Layers[2].GeometricObjects.Add( p );

			app.OpenedProject.Layers.Add( new LayerData() );
			app.OpenedProject.Layers[3].Name = "Layer4";
			app.OpenedProject.Layers[3].Profile.Material = new MaterialData( MaterialData.MaterialType.Dielectric ) { Name = "material1", Index = 2, }; ;
			app.OpenedProject.Layers[3].Profile.RenderSetting.Border = Pens.Aqua;
			app.OpenedProject.Layers[3].Profile.RenderSetting.Fill = new HatchBrush( HatchStyle.Percent05, Color.Aqua );
			p = new PolarCoordinateFunctionalPathData();
			p.PointNum = 10;
			p.XOffset = "5";
			p.YOffset = "0";
			p.CenterRadius = "1*t";
			p.CenterPhase = "-4*pi*t";
			p.LeftWingWidth = "0.5*t";
			p.RightWingWidth = "0.25*(1+sin(5*pi*t))";
			app.OpenedProject.Layers[3].GeometricObjects.Add( p );

			SourceData src = new SourceData();
			src.Name = "TestSrc";
			src.Wavelength = 1.55;
			src.Center = new Vector3( 1, 0, 0 );
			src.Size = new Vector3( 0, 0, 0 );
			src.Type = SourceData.SourceType.Continuous;
			manifest.Sources.Add( src );

			}
		}
	}
#endif
