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
	internal partial class LayerMaterialEditor : UserControl, IComparable<LayerMaterialEditor>
		{
		internal LayerData Layer
			{
			get { return _Layer; }
			set
				{
				_Layer = value;
				if( value != null )
					ApplyToFormFromData();
				}
			}
		private LayerData _Layer;



		internal string MeepCode { get; set; }



		internal decimal MinZ { get; set; }



		internal decimal MaxZ { get; set; }



		internal int LayerNumber
			{
			get { return (int)numericUpDownLayerNumber.Value; }
			set { numericUpDownLayerNumber.Value = Math.Min(Math.Max(value,numericUpDownLayerNumber.Minimum),numericUpDownLayerNumber.Maximum); }
			}
		private int BeforeLayerNumber;



		internal BindingList<MaterialDataBinder> Materials { get; private set; }



		internal event LayerNumberChangedEventHandler LayerNumberChanged;
		internal delegate void LayerNumberChangedEventHandler(object sender, LayerNumberChangedEventArgs e);
		internal class LayerNumberChangedEventArgs : EventArgs
			{
			internal int AfterLayerNumber { get; set; }
			internal int BeforeLayerNumber { get; set; }
			}



		internal LayerMaterialEditor()
			{
			InitializeComponent();

			LanguagePack Language = Application.SingletonInstance.CurrentLanguage;

			labelMaterial.Text = Language.MaterialEditorGeneral.LabelMaterial;
			labelCenter.Text = Language.MaterialEditorGeneral.LabelCenter;
			labelSize.Text = Language.MaterialEditorGeneral.LabelSize;
			labelMinZ.Text = Language.MaterialEditorGeneral.LabelMinZ;
			labelMaxZ.Text = Language.MaterialEditorGeneral.LabelMaxZ;

			Materials = new BindingList<MaterialDataBinder>();
			}


		private void ApplyToFormFromData()
			{
			comboBoxMaterial.DataSource = Materials;
			labelName.Text = Layer.Name;
			numericUpDownLayerNumber.Value = Layer.LayerNumber;
			comboBoxMaterial.SelectedItem = Layer.Profile.Material;
			numericUpDownCenter.Value = (decimal)Layer.Profile.CenterZ;
			numericUpDownSize.Value = (decimal)Layer.Profile.SizeZ;
			}



		//
		internal void ApplyToDataFromForm()
			{
			Layer.Profile.Material = comboBoxMaterial.SelectedItem as MaterialDataBinder;
			Layer.Profile.CenterZ = (double)numericUpDownCenter.Value;
			Layer.Profile.SizeZ = (double)numericUpDownSize.Value;
			}



		private void textBoxMaterialName_Validating(object sender, CancelEventArgs e)
			{

			}



		private void textBoxValue_Validating(object sender, CancelEventArgs e)
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
			this.Refresh();
			IsChangingCenterSize = false;
			}


		bool IsChangingMaxMin = false;
		private void numericUpDownMaxMin_ValueChanged(object sender, EventArgs e)
			{
			if( sender == numericUpDownMinZ )
				numericUpDownMaxZ.Value = Math.Max( numericUpDownMinZ.Value, numericUpDownMaxZ.Value );
			else if( sender == numericUpDownMaxZ )
				numericUpDownMinZ.Value = Math.Min( numericUpDownMinZ.Value, numericUpDownMaxZ.Value );

			if( IsChangingCenterSize ) return;
			IsChangingMaxMin = true;
			numericUpDownCenter.Value = ( numericUpDownMaxZ.Value + numericUpDownMinZ.Value ) / 2;
			numericUpDownSize.Value = numericUpDownMaxZ.Value - numericUpDownMinZ.Value;
			this.Refresh();
			IsChangingMaxMin = false;
			}



		private void buttonCoding_Click(object sender, EventArgs e)
			{
			TextEditorDialog dialog = new TextEditorDialog();
			dialog.Value = MeepCode;
			if( dialog.ShowDialog( this ) == DialogResult.OK )
				MeepCode = dialog.Value;
			}



		private void pictureBox_Paint(object sender, PaintEventArgs e)
			{

			Graphics g = e.Graphics;
			g.Clear( Color.Black );
			if( MaxZ <= MinZ ) return;
			float min_ratio = (float)( ( numericUpDownMinZ.Value - MinZ ) / ( MaxZ - MinZ ) );
			float max_ratio = (float)( ( numericUpDownMaxZ.Value - MinZ ) / ( MaxZ - MinZ ) );
			float maxY = e.ClipRectangle.Height * ( 1 - min_ratio );
			float minY = e.ClipRectangle.Height * ( 1 - max_ratio );
			g.FillRectangle( Layer.Profile.RenderSetting.Fill, e.ClipRectangle.X, e.ClipRectangle.Y + minY, e.ClipRectangle.Width - 1, maxY - minY );
			g.DrawRectangle( Layer.Profile.RenderSetting.Border, e.ClipRectangle.X, e.ClipRectangle.Y + minY, e.ClipRectangle.Width - 1, maxY - minY );
			}



		private void pictureBox_Resize(object sender, EventArgs e)
			{
			Refresh();
			}




		public int CompareTo(LayerMaterialEditor other)
			{
			return LayerNumber - other.LayerNumber;
			}



		private void numericUpDownLayerNumber_ValueChanged(object sender, EventArgs e)
			{
			LayerNumberChangedEventArgs eargs = new LayerNumberChangedEventArgs();
			eargs.AfterLayerNumber = LayerNumber;
			eargs.BeforeLayerNumber = BeforeLayerNumber;
			LayerNumberChanged?.Invoke( this, eargs );
			BeforeLayerNumber = LayerNumber;
			}


		


		}
	}
