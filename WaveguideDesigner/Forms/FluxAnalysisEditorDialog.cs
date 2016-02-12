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


		public decimal CenterWavelength
			{
			get { return (decimal)FluxAnalysis.CenterWavelength*1000; }
			set { FluxAnalysis.CenterWavelength = (double)value/1000; }
			}

		public decimal WavelengthSpan
			{
			get { return (decimal)FluxAnalysis.WavelengthSpan*1000; }
			set { FluxAnalysis.WavelengthSpan = (double)value/1000; }
			}

		public decimal PointNum
			{
			get { return (decimal)FluxAnalysis.PointNum; }
			set { FluxAnalysis.PointNum = (int)value; }
			}


		internal FluxAnalysisData FluxAnalysis { get; private set; }

		internal FluxAnalysisEditorDialog(FluxAnalysisData fluxAnalysis)
			{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;

			Text = Language.FluxAnalysisEditorDialog.Text;
			labelName.Text=Language.FluxAnalysisEditorDialog.LabelName;
			labelCenterWavelength.Text=Language.FluxAnalysisEditorDialog.LabelCenterWavelength;
			labelWavelengthSpan.Text=Language.FluxAnalysisEditorDialog.LabelWavelengthSpan;
			labelPointNum.Text=Language.FluxAnalysisEditorDialog.LabelPointNum;
			labelFluxDirection.Text = Language.FluxAnalysisEditorDialog.LabelFluxDirection;
			labelCenter.Text = Language.FluxAnalysisEditorDialog.LabelCenter;
			labelSize.Text = Language.FluxAnalysisEditorDialog.LabelSize;
			buttonOK.Text = Language.DialogGeneral.ButtonOK;
			buttonCancel.Text = Language.DialogGeneral.ButtonCancel;

			comboBoxFluxDirection.DataSource = Enum.GetValues( typeof( Direction ) );
			FluxAnalysis = new FluxAnalysisData( fluxAnalysis );
			textBoxName.DataBindings.Add( "Text",FluxAnalysis,"Name" );
			numericUpDownCenterWavelength.DataBindings.Add( "Value", this, "CenterWavelength" );
			numericUpDownWavelengthSpan.DataBindings.Add( "Value",this,"WavelengthSpan" );
			numericUpDownPointNum.DataBindings.Add( "Value", this, "PointNum" );
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
