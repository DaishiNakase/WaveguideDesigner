using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hslab.WaveguideDesigner.ProjectData;

namespace Hslab.WaveguideDesigner.Forms
	{
	internal partial class MaterialSystemEditorDialog : FormBase
		{
		/// <summary>クラス名。</summary>
		public override string ClassName { get { return "Forms.MaterialEditorDialog"; } }

		private BackgroundMaterialEditor backgroundMaterialEditor;

		private List<LayerMaterialEditor> Editors;

		private BindingList<MaterialDataBinder> Materials;

		internal MaterialSystemEditorDialog()
			{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;

			SetLanguage();
			MakeMaterialsPage();
			MakeStructureEditorsPage();
			}


		private void SetLanguage()
			{
			Text = Language.MaterialSystemEditorDialog.Text;
			tabPageStructure.Text = Language.MaterialSystemEditorDialog.TabPageStructure;
			tabPageMaterial.Text = Language.MaterialSystemEditorDialog.TabPageMaterial;
			}



		private void MakeMaterialsPage()
			{
			Materials = new BindingList<MaterialDataBinder>();
			foreach( MaterialData material in Application.OpenedProject.Materials )
				Materials.Add( new MaterialDataBinder( new MaterialData( material ) ) );
			listBoxMedium.DataSource = Materials;
			}


		private void MakeStructureEditorsPage()
			{
			int x = 0;

			backgroundMaterialEditor = new BackgroundMaterialEditor();
			foreach( MaterialDataBinder binder in Materials )
				backgroundMaterialEditor.Materials.Add( binder );
			backgroundMaterialEditor.ProjectManifest = Application.OpenedProject.ProjectManifest;
			panelStructure.Controls.Add( backgroundMaterialEditor );
			backgroundMaterialEditor.Font = new Font( "Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ) );
			backgroundMaterialEditor.Location = new Point( 0, 0 );
			backgroundMaterialEditor.Margin = new Padding( 3, 4, 3, 4 );
			backgroundMaterialEditor.Name = "backgroundMaterialEditor";
			backgroundMaterialEditor.TabIndex = 0;
			backgroundMaterialEditor.ZRangeChanged += BackgroundMaterialEditor_ZRangeChanged;
			backgroundMaterialEditor.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
			x += backgroundMaterialEditor.Width;

			Editors = new List<LayerMaterialEditor>();
			LayerMaterialEditor editor;
			foreach( LayerData layer in Application.OpenedProject.Layers )
				{
				editor = new LayerMaterialEditor();
				foreach( MaterialDataBinder binder in Materials )
					editor.Materials.Add( binder );
				Editors.Add( editor );
				panelStructure.Controls.Add( editor );
				editor.Location = new Point( x, 0 );
				editor.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
				editor.LayerNumberChanged += Editor_LayerNumberChanged;
				editor.Layer = layer;

				x += editor.Width;
				}
			BackgroundMaterialEditor_ZRangeChanged( this, EventArgs.Empty );
			}



		private void Editor_LayerNumberChanged(object sender, LayerMaterialEditor.LayerNumberChangedEventArgs e)
			{
			int index = Editors.IndexOf( sender as LayerMaterialEditor );
			if( e.BeforeLayerNumber < e.AfterLayerNumber ) index++;
			else index--;
			if( index < 0 || Editors.Count <= index ) return;
			if( Editors[index].LayerNumber == e.AfterLayerNumber )
				{
				Editors[index].LayerNumber = e.BeforeLayerNumber;
				SortLayer();
				}
			}



		private void SortLayer()
			{
			Editors.Sort();
			int x = backgroundMaterialEditor.Width;
			foreach( LayerMaterialEditor editor in Editors )
				{
				editor.Location = new Point( x, 0 );
				x += editor.Width;
				}
			}



		private void BackgroundMaterialEditor_ZRangeChanged(object sender, EventArgs e)
			{
			labelMinZ.Text = backgroundMaterialEditor.MinZ.ToString( "0.00###" );
			labelMaxZ.Text = backgroundMaterialEditor.MaxZ.ToString( "0.00###" );
			foreach( LayerMaterialEditor editor in Editors )
				{
				editor.MinZ = backgroundMaterialEditor.MinZ;
				editor.MaxZ = backgroundMaterialEditor.MaxZ;
				}
			Refresh();
			}



		private void panel_Layout(object sender, LayoutEventArgs e)
			{
			panelStructure.HorizontalScroll.Visible = true;
			panel_Resize( sender, e );
			}



		private void panel_Scroll(object sender, ScrollEventArgs e)
			{
			panelStructure.Refresh();
			}





		private void panel_Resize(object sender, EventArgs e)
			{
			if( backgroundMaterialEditor != null )
				{
				labelMinZ.Location = new Point( labelMinZ.Left, backgroundMaterialEditor.MinZLocation - 7 );
				labelMaxZ.Location = new Point( labelMaxZ.Left, backgroundMaterialEditor.MaxZLocation - 7 );
				}
			}




		private void toolStripButtonMedAdd_Click(object sender, EventArgs e)
			{
			MaterialDataBinder binder = new MaterialDataBinder( new MaterialData( MaterialData.MaterialType.Dielectric ) );
			string defName = binder.Data.Name;
			bool accepted;
			for( int suffix = 1 ; true ; suffix++ )
				{
				accepted = true;
				foreach( MaterialDataBinder item in Materials )
					if( binder.Data.Name == item.Data.Name )
						{
						accepted = false;
						break;
						}
				if( accepted )
					{
					break;
					}
				binder.Data.Name = defName + suffix.ToString();
				}

			Materials.Add( binder );
			Materials.ResetBindings();
			backgroundMaterialEditor.Materials.Add( binder );
			backgroundMaterialEditor.Materials.ResetBindings();
			foreach( LayerMaterialEditor editor in Editors )
				{
				editor.Materials.Add( binder );
				editor.Materials.ResetBindings();
				}
			}



		private void toolStripButtonMedRemove_Click(object sender, EventArgs e)
			{
			if( listBoxMedium.SelectedItem != null )
				{
				if( Materials.Count > 1 )
					{
					int index = listBoxMedium.SelectedIndex;
					MaterialDataBinder binder = listBoxMedium.SelectedItem as MaterialDataBinder;
					Materials.Remove( binder );
					Materials.ResetBindings();
					backgroundMaterialEditor.Materials.Remove( binder );
					backgroundMaterialEditor.Materials.ResetBindings();
					foreach( LayerMaterialEditor editor in Editors )
						{
						editor.Materials.Remove( binder );
						editor.Materials.ResetBindings();
						}
					listBoxMedium.SelectedIndex = Math.Min( index, listBoxMedium.Items.Count - 1 );
					}
				else
					{
					MaterialDataBinder binder = new MaterialDataBinder( new MaterialData() );
					Materials[0] = binder;
					Materials.ResetBindings();
					backgroundMaterialEditor.Materials[0] = binder;
					backgroundMaterialEditor.Materials.ResetBindings();
					foreach( LayerMaterialEditor editor in Editors )
						{
						editor.Materials[0] = binder;
						editor.Materials.ResetBindings();
						}
					}
				}
			}



		private void toolStripButtonMedRaise_Click(object sender, EventArgs e)
			{
			int index = listBoxMedium.SelectedIndex;
			if( index <= 0 ) return;
			MaterialDataBinder binder = listBoxMedium.SelectedItem as MaterialDataBinder;
			Materials.RemoveAt( index );
			Materials.Insert( index - 1, binder );
			Materials.ResetBindings();
			backgroundMaterialEditor.Materials.RemoveAt( index );
			backgroundMaterialEditor.Materials.Insert( index - 1, binder );
			backgroundMaterialEditor.Materials.ResetBindings();
			foreach( LayerMaterialEditor editor in Editors )
				{
				editor.Materials.RemoveAt( index );
				editor.Materials.Insert( index - 1, binder );
				editor.Materials.ResetBindings();
				}
			listBoxMedium.SelectedIndex = index - 1;
			}



		private void toolStripButtonMedLower_Click(object sender, EventArgs e)
			{
			int index = listBoxMedium.SelectedIndex;
			if( index < 0 || index >= listBoxMedium.Items.Count - 1 ) return;
			MaterialDataBinder binder = listBoxMedium.SelectedItem as MaterialDataBinder;
			Materials.RemoveAt( index );
			Materials.Insert( index + 1, binder );
			Materials.ResetBindings();
			backgroundMaterialEditor.Materials.RemoveAt( index );
			backgroundMaterialEditor.Materials.Insert( index + 1, binder );
			backgroundMaterialEditor.Materials.ResetBindings();
			foreach( LayerMaterialEditor editor in Editors )
				{
				editor.Materials.RemoveAt( index );
				editor.Materials.Insert( index + 1, binder );
				editor.Materials.ResetBindings();
				}
			listBoxMedium.SelectedIndex = index + 1;
			}



		private void buttonOK_Click(object sender, EventArgs e)
			{
			DialogResult = DialogResult.OK;
			ApplyEditData();
			Close();
			}


		private void buttonApply_Click(object sender, EventArgs e)
			{
			ApplyEditData();

			}



		private void ApplyEditData()
			{
			backgroundMaterialEditor.ApplyToDataFromForm();
			foreach( LayerMaterialEditor editor in Editors )
				editor.ApplyToDataFromForm();
			Application.OpenedProject.Materials.Clear();
			foreach( object item in listBoxMedium.Items )
				Application.OpenedProject.Materials.Add( ( item as MaterialData ) ?? ( item as MaterialDataBinder ) );
			Application.ValidateProject( false );
			}



		private void buttonCancel_Click(object sender, EventArgs e)
			{
			Close();
			}



		private bool IsInListBoxMaterial_SelectedIndexChanged = false;
		private void listBoxMaterial_SelectedIndexChanged(object sender, EventArgs e)
			{
			IsInListBoxMaterial_SelectedIndexChanged = true;
			MaterialData data = ( listBoxMedium.SelectedItem as MaterialDataBinder ).Data;
			if( data == null )
				panelMaterialSetting.Enabled = false;
			else
				{
				panelMaterialSetting.Enabled = true;
				textBoxMaterialName.Text = data.Name;
				panelDielectric.Visible = false;
				panelDielectric.Enabled = false;
				richTextBoxMeepCode.Visible = false;
				richTextBoxMeepCode.Enabled = false;
				switch( data.Type )
					{
					case MaterialData.MaterialType.Dielectric:
						radioButtonDielectric.Checked = true;
						panelDielectric.Visible = true;
						panelDielectric.Enabled = true;
						break;
					case MaterialData.MaterialType.Metal:
						radioButtonMetal.Checked = true;
						break;
					case MaterialData.MaterialType.Air:
						radioButtonAir.Checked = true;
						break;
					case MaterialData.MaterialType.MagneticConductor:
						radioButtonMagneticConductor.Checked = true;
						break;
					case MaterialData.MaterialType.Nothing:
						radioButtonNothing.Checked = true;
						break;
					case MaterialData.MaterialType.DirectCoding:
						radioButtonDirectCoding.Checked = true;
						richTextBoxMeepCode.Visible = true;
						richTextBoxMeepCode.Enabled = true;
						break;
					}
				numericUpDownN.Value = (decimal)data.Index;
				numericUpDownMu.Value = (decimal)data.Mu;
				numericUpDownSigma.Value = (decimal)data.Conductivity;
				richTextBoxMeepCode.Text = data.MeepCode;
				}
			IsInListBoxMaterial_SelectedIndexChanged = false;
			}



		private void textBoxMaterialName_Validating(object sender, CancelEventArgs e)
			{
			if( IsInListBoxMaterial_SelectedIndexChanged ) return;
			if( !MeepManager.WaveguideDesigner.StaticMethods.IsValidNameInScheme( textBoxMaterialName.Text ) )
				{
				MessageBox.Show( "材料名に指定できない文字列です。" );
				e.Cancel = true;
				}
			else
				{
				foreach( MaterialDataBinder binder in Materials )
					if( binder != listBoxMedium.SelectedItem && binder.Data.Name == textBoxMaterialName.Text )
						{
						MessageBox.Show( "材料名は固有である必要があります。" );
						e.Cancel = true; break;
						}
				}
			}



		private void textBoxMaterialName_TextChanged(object sender, EventArgs e)
			{
			if( IsInListBoxMaterial_SelectedIndexChanged ) return;
			MaterialData data = ( listBoxMedium.SelectedItem as MaterialDataBinder ).Data;
			if( data == null ) return;
			data.Name = textBoxMaterialName.Text;
			Materials.ResetBindings();
			backgroundMaterialEditor.Materials.ResetBindings();
			foreach( LayerMaterialEditor editor in Editors )
				editor.Materials.ResetBindings();
			}



		private void radioButtonMaterialType_CheckChanged(object sender, EventArgs e)
			{
			if( IsInListBoxMaterial_SelectedIndexChanged ) return;
			MaterialData data = ( listBoxMedium.SelectedItem as MaterialDataBinder ).Data;
			if( data == null ) return;
			panelDielectric.Visible = false;
			panelDielectric.Enabled = false;
			richTextBoxMeepCode.Visible = false;
			richTextBoxMeepCode.Enabled = false;
			MaterialData.MaterialType type = MaterialData.MaterialType.Dielectric;
			if( radioButtonDielectric.Checked )
				{
				type = MaterialData.MaterialType.Dielectric;
				panelDielectric.Visible = true;
				panelDielectric.Enabled = true;
				}
			else if( radioButtonMetal.Checked ) type = MaterialData.MaterialType.Metal;
			else if( radioButtonAir.Checked ) type = MaterialData.MaterialType.Air;
			else if( radioButtonMagneticConductor.Checked ) type = MaterialData.MaterialType.MagneticConductor;
			else if( radioButtonNothing.Checked ) type = MaterialData.MaterialType.Nothing;
			else if( radioButtonDirectCoding.Checked )
				{
				type = MaterialData.MaterialType.DirectCoding;
				richTextBoxMeepCode.Visible = true;
				richTextBoxMeepCode.Enabled = true;
				}
			data.Type = type;
			}



		private void numericUpDownN_ValueChanged(object sender, EventArgs e)
			{
			if( IsInListBoxMaterial_SelectedIndexChanged ) return;
			MaterialData data = ( listBoxMedium.SelectedItem as MaterialDataBinder ).Data;
			if( data == null ) return;
			data.Index = (double)numericUpDownN.Value;
			}



		private void numericUpDownMu_ValueChanged(object sender, EventArgs e)
			{
			if( IsInListBoxMaterial_SelectedIndexChanged ) return;
			MaterialData data = ( listBoxMedium.SelectedItem as MaterialDataBinder ).Data;
			if( data == null ) return;
			data.Mu = (double)numericUpDownMu.Value;
			}



		private void numericUpDownSigma_ValueChanged(object sender, EventArgs e)
			{
			if( IsInListBoxMaterial_SelectedIndexChanged ) return;
			MaterialData data = ( listBoxMedium.SelectedItem as MaterialDataBinder ).Data;
			if( data == null ) return;
			data.Conductivity = (double)numericUpDownSigma.Value;
			}



		private void richTextBoxMeepCode_TextChanged(object sender, EventArgs e)
			{
			if( IsInListBoxMaterial_SelectedIndexChanged ) return;
			MaterialData data = ( listBoxMedium.SelectedItem as MaterialDataBinder ).Data;
			if( data == null ) return;
			data.MeepCode = richTextBoxMeepCode.Text;
			}



		}






	internal class MaterialDataBinder
		{
		internal MaterialDataBinder(MaterialData data) { Data = data; }

		internal MaterialData Data { get; private set; }

		public override string ToString()
			{
			return Data.Name;
			}

		public override bool Equals(object obj)
			{
			if( obj is MaterialDataBinder ) return ( obj as MaterialDataBinder ).Data.Equals( this.Data );
			else if( obj is MaterialData ) return this.Data.Equals( obj );
			else return false;
			}


		public static implicit operator MaterialData(MaterialDataBinder binder) { return binder.Data; }
		public static implicit operator MaterialDataBinder(MaterialData data) { return new MaterialDataBinder( data ); }
		}

	}
