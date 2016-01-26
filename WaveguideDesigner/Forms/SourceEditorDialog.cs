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
	public partial class SourceEditorDialog : FormBase
		{
		/// <summary>クラス名。</summary>
		public override string ClassName { get { return "Forms.SourceEditorDialog"; } }

		internal SourceData Source { get; private set; }

		public decimal Source_Amplitude
			{
			get { return (decimal)Source.Amplitude; }
			set { Source.Amplitude = (double)value; }
			}

		public decimal Source_Wavelength
			{
			get { return (decimal)Source.Wavelength*1000; }
			set { Source.Wavelength = (double)value/1000; }
			}

		public decimal Source_StartTime
			{
			get { return (decimal)Source.StartTime; }
			set { Source.StartTime = (double)value; }
			}

		public decimal Source_EndTime
			{
			get { return double.IsInfinity(Source.EndTime)?0:( decimal)Source.EndTime; }
			set { Source.EndTime = (double)value; }
			}

		public bool Source_IsEndTimeInfinity
			{
			get { return double.IsInfinity( Source.EndTime ); }
			set
				{
				Source.EndTime = value?double.PositiveInfinity:(double)numericUpDownEndTime.Value;
				}
			}

		public decimal Source_Width
			{
			get { return (decimal)Source.Width; }
			set { Source.Width = (double)value; }
			}

		internal SourceEditorDialog(SourceData source)
			{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;

			Text = Language.SourceEditorDialog.Text;
			labelName.Text = Language.SourceEditorDialog.LabelName;
			checkBoxEnabled.Text = Language.SourceEditorDialog.CheckBoxEnabled;
			labelSourceType.Text = Language.SourceEditorDialog.LabelSourceType;
			labelComponent.Text = Language.SourceEditorDialog.LabelComponent;
			labelCenter.Text = Language.SourceEditorDialog.LabelCenter;
			labelSize.Text = Language.SourceEditorDialog.LabelSize;
			labelAmplitude.Text = Language.SourceEditorDialog.LabelAmplitude;
			labelWavelength.Text = Language.SourceEditorDialog.LabelWavelength;
			labelStartTime.Text = Language.SourceEditorDialog.LabelStartTime;
			labelEndTime.Text = Language.SourceEditorDialog.LabelEndTime;
			labelWidth.Text = Language.SourceEditorDialog.LabelWidth;
			buttonOK.Text = Language.DialogGeneral.ButtonOK;
			buttonCancel.Text = Language.DialogGeneral.ButtonCancel;

			comboBoxSourceType.DataSource = Enum.GetValues( typeof( SourceData.SourceType ) );
			comboBoxComponent.Items.Add( MeepManager.WaveguideDesigner.Component.Ex );
			comboBoxComponent.Items.Add( MeepManager.WaveguideDesigner.Component.Ey );
			comboBoxComponent.Items.Add( MeepManager.WaveguideDesigner.Component.Ez );
			comboBoxComponent.Items.Add( MeepManager.WaveguideDesigner.Component.Hx );
			comboBoxComponent.Items.Add( MeepManager.WaveguideDesigner.Component.Hy );
			comboBoxComponent.Items.Add( MeepManager.WaveguideDesigner.Component.Hz );

			Source = new SourceData( source );
			textBoxName.DataBindings.Add( "Text", Source, "Name" );
			checkBoxEnabled.DataBindings.Add( "Enabled", Source, "Enabled" );
			comboBoxSourceType.DataBindings.Add( "SelectedItem", Source, "Type" );
			comboBoxComponent.DataBindings.Add( "SelectedItem",Source,"Component" );
			vectorEditorCenter.DataBindings.Add( "Value",Source,"Center" );
			vectorEditorSize.DataBindings.Add( "Value",Source,"Size" );
			numericUpDownAmplitude.DataBindings.Add( "Value",this, "Source_Amplitude" );
			numericUpDownWavelength.DataBindings.Add( "Value", this, "Source_Wavelength" );
			numericUpDownStartTime.DataBindings.Add( "Value",this,"Source_StartTime" );
			numericUpDownEndTime.DataBindings.Add( "Value",this,"Source_EndTime" );
			checkBoxEndTimeInfinity.DataBindings.Add( "Checked", this, "Source_IsEndTimeInfinity" );
			numericUpDownWidth.DataBindings.Add( "Value",this,"Source_Width" );
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


		private void checkBoxEndTimeInfinity_CheckedChanged(object sender, EventArgs e)
			{
			numericUpDownEndTime.Enabled = !checkBoxEndTimeInfinity.Checked;
			}

		}

	}
