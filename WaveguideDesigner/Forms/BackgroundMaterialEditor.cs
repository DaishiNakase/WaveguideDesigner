using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hslab.WaveguideDesigner.ProjectData;

namespace Hslab.WaveguideDesigner.Forms
	{
	internal partial class BackgroundMaterialEditor : UserControl
		{
		internal ProjectManifestData ProjectManifest
			{
			get { return _ProjectManifest; }
			set
				{
				_ProjectManifest = value;
				if( value != null )
					ApplyToFormFromData();
				}
			}
		private ProjectManifestData _ProjectManifest;



		internal string MeepCode { get; set; }



		internal decimal MinZ { get { return numericUpDownMinZ.Value; } }
		internal decimal MaxZ { get { return numericUpDownMaxZ.Value; } }



		internal int MaxZLocation { get { return pictureBox.Top; } }
		internal int MinZLocation { get { return pictureBox.Bottom; } }



		internal BindingList<MaterialDataBinder> Materials { get; private set; }



		internal event EventHandler ZRangeChanged
			{
			add
				{
				numericUpDownMinZ.ValueChanged += value;
				numericUpDownMaxZ.ValueChanged += value;
				}
			remove
				{
				numericUpDownMinZ.ValueChanged -= value;
				numericUpDownMaxZ.ValueChanged -= value;
				}
			}

		

		internal BackgroundMaterialEditor()
			{
			InitializeComponent();

			LanguagePack Language = Application.SingletonInstance.CurrentLanguage;

			labelMaterial.Text = Language.MaterialEditorGeneral.LabelMaterial;
			labelName.Text = Language.MaterialEditorGeneral.LabelBackgroundName;
			labelCenter.Text = Language.MaterialEditorGeneral.LabelCenter;
			labelSize.Text = Language.MaterialEditorGeneral.LabelSize;
			labelMinZ.Text = Language.MaterialEditorGeneral.LabelMinZ;
			labelMaxZ.Text = Language.MaterialEditorGeneral.LabelMaxZ;

			Materials = new BindingList<MaterialDataBinder>();
			}


		private void ApplyToFormFromData()
			{
			comboBoxMaterial.DataSource = Materials;
			comboBoxMaterial.SelectedItem = ProjectManifest.BackgroundMaterial;
			numericUpDownMinZ.Value = (decimal)ProjectManifest.SimulationRegion.MinZ;
			numericUpDownMaxZ.Value = (decimal)ProjectManifest.SimulationRegion.MaxZ;
			}




		internal void ApplyToDataFromForm()
			{
			ProjectManifest.BackgroundMaterial = comboBoxMaterial.SelectedItem as MaterialDataBinder;
			ProjectManifest.SimulationRegion.MinZ = (double)numericUpDownMinZ.Value;
			ProjectManifest.SimulationRegion.MaxZ = (double)numericUpDownMaxZ.Value;
			}



		private void textBox_Validating(object sender, CancelEventArgs e)
			{
			double dummy;
			TextBox textBox = sender as TextBox;
			e.Cancel = !double.TryParse( textBox.Text, out dummy );
			}

		



		bool IsChangingCenterSize = false;
		private void numericUpDownCenterSize_ValueChanged(object sender, EventArgs e)
			{
			if( IsChangingMaxMin ) return;
			IsChangingCenterSize = true;
			numericUpDownMaxZ.Value = numericUpDownCenter.Value + numericUpDownSize.Value / 2;
			numericUpDownMinZ.Value = numericUpDownCenter.Value - numericUpDownSize.Value / 2;
			IsChangingCenterSize = false;
			}


		bool IsChangingMaxMin = false;
		private void numericUpDownMaxMin_ValueChanged(object sender, EventArgs e)
			{
			if( sender == numericUpDownMinZ )
				numericUpDownMaxZ.Value = Math.Max( numericUpDownMinZ.Value, numericUpDownMaxZ.Value );
			else if(sender==numericUpDownMaxZ )
				numericUpDownMinZ.Value = Math.Min( numericUpDownMinZ.Value, numericUpDownMaxZ.Value );

			if( IsChangingCenterSize ) return;
			IsChangingMaxMin = true;
			numericUpDownCenter.Value = ( numericUpDownMaxZ.Value + numericUpDownMinZ.Value ) / 2;
			numericUpDownSize.Value = numericUpDownMaxZ.Value - numericUpDownMinZ.Value;
			IsChangingMaxMin = false;
			}


		private void buttonCoding_Click(object sender, EventArgs e)
			{
			TextEditorDialog dialog = new TextEditorDialog();
			dialog.Value = MeepCode;
			if( dialog.ShowDialog( this ) == DialogResult.OK )
				MeepCode = dialog.Value;
			}


		

		}
	}
