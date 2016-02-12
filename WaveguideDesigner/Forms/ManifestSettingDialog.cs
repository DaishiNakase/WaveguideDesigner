using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hslab.WaveguideDesigner.ProjectData;

namespace Hslab.WaveguideDesigner.Forms
	{
	internal partial class ManifestSettingDialog : FormBase
		{
		/// <summary>クラス名。</summary>
		public override string ClassName { get { return "Forms.ManifestSettingDialog"; } }

		internal ManifestSettingDialog()
			{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;

			// フォーム要素の追加設定
			AdditionalInitializeComponent();


			LoadManifest();
			}



		private void AdditionalInitializeComponent()
			{
			Text = Language.ManifestSettingDialog.Text;
			groupBoxGeneralSettings.Text = Language.ManifestSettingDialog.GroupBoxGeneralSettings;
			labelResolution.Text = Language.ManifestSettingDialog.LabelResolution;
			labelSimulationTime.Text = Language.ManifestSettingDialog.LabelSimulationTime;
			labelBackgroundMaterial.Text = Language.ManifestSettingDialog.LabelBackgoundMaterial;
			groupBoxSimulationRegion.Text = Language.ManifestSettingDialog.GroupBoxSimulationRegion;
			radioButtonDim2D.Text = Language.ManifestSettingDialog.RadioButtonDim2D;
			radioButtonDim3D.Text = Language.ManifestSettingDialog.RadioButtonDim3D;
			labelMinX.Text = Language.ManifestSettingDialog.LabelMinX;
			labelMaxX.Text = Language.ManifestSettingDialog.LabelMaxX;
			labelMinY.Text = Language.ManifestSettingDialog.LabelMinY;
			labelMaxY.Text = Language.ManifestSettingDialog.LabelMaxY;
			labelMinZ.Text = Language.ManifestSettingDialog.LabelMinZ;
			labelMaxZ.Text = Language.ManifestSettingDialog.LabelMaxZ;
			labelPml.Text = Language.ManifestSettingDialog.LabelPml;
			tabPageSources.Text = Language.ManifestSettingDialog.TabPageSources;
			tabPageFluxAnalyses.Text = Language.ManifestSettingDialog.TabPageFluxAnalysis;
			tabPageVisualizationOutputs.Text = Language.ManifestSettingDialog.TabPageVisualizationOutput;
			buttonOK.Text = Language.DialogGeneral.ButtonOK;
			buttonApply.Text = Language.DialogGeneral.ButtonApply;
			buttonCancel.Text = Language.DialogGeneral.ButtonCancel;

			toolStripButtonSrcAdd.Tag = listBoxSrc;
			toolStripButtonSrcRemove.Tag = listBoxSrc;
			toolStripButtonSrcRaise.Tag = listBoxSrc;
			toolStripButtonSrcLower.Tag = listBoxSrc;

			toolStripButtonFlxAdd.Tag = listBoxFlx;
			toolStripButtonFlxRemove.Tag = listBoxFlx;
			toolStripButtonFlxRaise.Tag = listBoxFlx;
			toolStripButtonFlxLower.Tag = listBoxFlx;

			toolStripButtonVisAdd.Tag = listBoxVis;
			toolStripButtonVisRemove.Tag = listBoxVis;
			toolStripButtonVisRaise.Tag = listBoxVis;
			toolStripButtonVisLower.Tag = listBoxVis;
			}



		private void LoadManifest()
			{
			ProjectManifestData data = Application.OpenedProject.ProjectManifest;

			numericUpDownResolution.Value = (decimal)data.Resolution;
			numericUpDownTime.Value = (decimal)data.SimulationTime;

			switch( data.SimulationRegion.Dimension )
				{
				case Dimension.Dim2: radioButtonDim2D.Checked = true; break;
				case Dimension.Dim3: radioButtonDim3D.Checked = true; break;
				}
			numericUpDownMinX.Value = (decimal)data.SimulationRegion.MinX;
			numericUpDownMaxX.Value = (decimal)data.SimulationRegion.MaxX;
			numericUpDownMinY.Value = (decimal)data.SimulationRegion.MinY;
			numericUpDownMaxY.Value = (decimal)data.SimulationRegion.MaxY;
			numericUpDownMinZ.Value = (decimal)data.SimulationRegion.MinZ;
			numericUpDownMaxZ.Value = (decimal)data.SimulationRegion.MaxZ;
			numericUpDownPml.Value = (decimal)data.SimulationRegion.PmlThickness;

			// SourceData list
			foreach( SourceData src in data.Sources )
				listBoxSrc.Items.Add( src );
			if( listBoxSrc.Items.Count > 0 )
				listBoxSrc.Items[0].ToString();

			// FluxAnalysisData list
			foreach( FluxAnalysisData flux in data.FluxAnalyses )
				listBoxFlx.Items.Add( flux );

			// VisualizationOutputData list
			foreach( VisualizationOutputData visualization in data.VisualizationOutputs )
				listBoxVis.Items.Add( visualization );
			}



		private void ApplyManifest()
			{
			ProjectManifestData data = Application.OpenedProject.ProjectManifest;

			data.Resolution = (double)numericUpDownResolution.Value;
			data.SimulationTime = (double)numericUpDownTime.Value;
			data.BackgroundMaterial = Application.OpenedProject.ProjectManifest.BackgroundMaterial;

			SimulationRegionData region = data.SimulationRegion;
			region.Dimension = radioButtonDim2D.Checked ? Dimension.Dim2 : Dimension.Dim3;
			region.MinX = (double)numericUpDownMinX.Value;
			region.MaxX = (double)numericUpDownMaxX.Value;
			region.MinY = (double)numericUpDownMinY.Value;
			region.MaxY = (double)numericUpDownMaxY.Value;
			region.MinZ = (double)numericUpDownMinZ.Value;
			region.MaxZ = (double)numericUpDownMaxZ.Value;
			region.PmlThickness = (double)numericUpDownPml.Value;

			data.Sources.Clear();
			foreach( object obj in listBoxSrc.Items )
				data.Sources.Add( new SourceData( obj as SourceData ) );

			data.FluxAnalyses.Clear();
			foreach( object obj in listBoxFlx.Items )
				data.FluxAnalyses.Add( new FluxAnalysisData( obj as FluxAnalysisData ) );

			data.VisualizationOutputs.Clear();
			foreach( object obj in listBoxVis.Items )
				data.VisualizationOutputs.Add( new VisualizationOutputData( obj as VisualizationOutputData ) );

			Application.ValidateProject( true );
			}



		private void buttonBGMaterial_Click(object sender, EventArgs e)
			{
			if( Application.ShowMaterialEditorDialog( this ) )
				{
				labelBGMaterial.Text = "n = " + Application.OpenedProject.ProjectManifest.BackgroundMaterial.Index.ToString();
				numericUpDownMinZ.Value = (decimal)Application.OpenedProject.ProjectManifest.SimulationRegion.MinZ;
				numericUpDownMaxZ.Value = (decimal)Application.OpenedProject.ProjectManifest.SimulationRegion.MaxZ;
				}
			}




		private void toolStripButtonAdd_Click(object sender, EventArgs e)
			{
			ListBox box = ( sender as ToolStripButton ).Tag as ListBox;
			ProjectDataBase data = null;
			if( box == listBoxSrc ) data = new SourceData();
			else if( box == listBoxFlx ) data = new FluxAnalysisData();
			else if( box == listBoxVis ) data = new VisualizationOutputData();
			else return;
			box.Items.Add( data );
			}



		private void toolStripButtonRemove_Click(object sender, EventArgs e)
			{
			ListBox box = ( sender as ToolStripButton ).Tag as ListBox;
			if( box.SelectedItem != null )
				{
				int index = box.SelectedIndex;
				box.Items.Remove( box.SelectedItem );
				box.SelectedIndex = Math.Min( index, box.Items.Count - 1 );
				}
			}



		private void toolStripButtonRaise_Click(object sender, EventArgs e)
			{
			ListBox box = ( sender as ToolStripButton ).Tag as ListBox;
			int index = box.SelectedIndex;
			if( index <= 0 ) return;
			object obj = box.SelectedItem;
			box.Items.RemoveAt( index );
			box.Items.Insert( index - 1, obj );
			box.SelectedIndex = index - 1;
			}



		private void toolStripButtonLower_Click(object sender, EventArgs e)
			{
			ListBox box = ( sender as ToolStripButton ).Tag as ListBox;
			int index = box.SelectedIndex;
			if( index < 0 || index >= box.Items.Count - 1 ) return;
			object obj = box.SelectedItem;
			box.Items.RemoveAt( index );
			box.Items.Insert( index + 1, obj );
			box.SelectedIndex = index + 1;
			}



		private void listBox_SelectedIndexChanged(object sender, EventArgs e)
			{
			ListBox box = sender as ListBox;
			labelDescription.Text = ( box.SelectedItem as ProjectDataBase )?.GetDescription() ?? "";
			}

		

		

		


		private void listBox_DoubleClick(object sender, EventArgs e)
			{
			ListBox box = sender as ListBox;
			if( !( box.SelectedItem is ProjectDataBase ) ) { }
			else if( box == listBoxSrc )
				{
				SourceEditorDialog form = new SourceEditorDialog( box.SelectedItem as SourceData );
				if( form.ShowDialog( this ) == DialogResult.OK )
					box.Items[box.SelectedIndex] = form.Source;
				}
			else if( box == listBoxFlx )
				{
				FluxAnalysisEditorDialog form = new FluxAnalysisEditorDialog( box.SelectedItem as FluxAnalysisData );
				if( form.ShowDialog( this ) == DialogResult.OK )
					box.Items[box.SelectedIndex] = form.FluxAnalysis;
				}
			else if( box == listBoxVis )
				{
				VisualizationOutputEditorDialog form = new VisualizationOutputEditorDialog( box.SelectedItem as VisualizationOutputData );
				if( form.ShowDialog( this ) == DialogResult.OK )
					box.Items[box.SelectedIndex] = form.VisualizationOutput;
				}
			else return;
			}



		private void buttonOK_Click(object sender, EventArgs e)
			{
			DialogResult = DialogResult.OK;
			ApplyManifest();
			Close();
			}



		private void buttonApply_Click(object sender, EventArgs e)
			{
			ApplyManifest();
			}



		private void buttonCancel_Click(object sender, EventArgs e)
			{
			DialogResult = DialogResult.Cancel;
			Close();
			}


		}
	}
