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
	public partial class VisualizationOutputEditorDialog : FormBase
		{
		/// <summary>クラス名。</summary>
		public override string ClassName { get { return "Forms.VisualizationOutputEditorDialog"; } }


		internal VisualizationOutputData VisualizationOutput { get; set; }

		public decimal VisualizationOutput_TimeStep
			{
			get { return (decimal)VisualizationOutput.TimeStep; }
			set { VisualizationOutput.TimeStep = (double)value; }
			}


		internal VisualizationOutputEditorDialog(VisualizationOutputData visualizationOutput)
			{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;

			Text = Language.VisualizationOutputEditor.Text;
			labelFluxComponent.Text = Language.VisualizationOutputEditor.LabelFluxComponent;
			labelTimeStep.Text = Language.VisualizationOutputEditor.LabelTimeStep;
			labelCenter.Text = Language.VisualizationOutputEditor.LabelCenter;
			labelSize.Text = Language.VisualizationOutputEditor.LabelSize;
			buttonOK.Text = Language.DialogGeneral.ButtonOK;
			buttonCancel.Text = Language.DialogGeneral.ButtonCancel;

			comboBoxFluxComponent.DataSource = Enum.GetValues( typeof( FluxComponent ) );

			VisualizationOutput = new VisualizationOutputData( visualizationOutput );
			comboBoxFluxComponent.DataBindings.Add( "SelectedItem",VisualizationOutput,"Component" );
			numericUpDownTimeStep.DataBindings.Add( "Value", this, "VisualizationOutput_TimeStep" );
			vectorEditorCenter.DataBindings.Add( "Value",VisualizationOutput,"Center" );
			vectorEditorSize.DataBindings.Add( "Value",VisualizationOutput,"Size" );
			}


		private void buttonOK_Click(object sender, EventArgs e)
			{
			DialogResult = DialogResult.OK;
			Close();
			}


		private void buttonCancel_Click(object sender, EventArgs e)
			{
			DialogResult = DialogResult.Cancel;
			Close();
			}
		}
	}
