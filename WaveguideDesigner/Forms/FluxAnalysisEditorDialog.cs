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
	public partial class FluxAnalysisEditorDialog : FormBase
		{
		/// <summary>クラス名。</summary>
		public override string ClassName { get { return "Forms.FluxAnalysisEditorDialog"; } }

		internal FluxAnalysisData FluxAnalysis { get; private set; }

		internal FluxAnalysisEditorDialog(FluxAnalysisData fluxAnalysis)
			{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;

			Text = Language.FluxAnalysisEditoDialog.Text;
			labelFluxDirection.Text = Language.FluxAnalysisEditoDialog.LabelFluxDirection;
			labelCenter.Text = Language.FluxAnalysisEditoDialog.LabelCenter;
			labelSize.Text = Language.FluxAnalysisEditoDialog.LabelSize;
			buttonOK.Text = Language.DialogGeneral.ButtonOK;
			buttonCancel.Text = Language.DialogGeneral.ButtonCancel;

			comboBoxFluxDirection.DataSource = Enum.GetValues( typeof( Direction ) );
			FluxAnalysis = new FluxAnalysisData( fluxAnalysis );
			comboBoxFluxDirection.DataBindings.Add( "SelectedItem", FluxAnalysis, "FluxDirection" );
			vectorEditorCenter.DataBindings.Add( "Value",FluxAnalysis,"Center" );
			vectorEditorSize.DataBindings.Add( "Value",FluxAnalysis,"Size" );
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
