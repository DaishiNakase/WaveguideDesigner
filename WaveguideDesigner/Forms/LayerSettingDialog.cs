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
	internal partial class LayerSettingDialog : FormBase
		{
		/// <summary>クラス名。</summary>
		public override string ClassName { get { return "Forms.LayerSettingDialog"; } }

		internal LayerData Layer { get; private set; }

		internal LayerProfileData LayerProfile { get; private set; }

		private PenEx Border { get; set; }

		private HatchBrushEx Fill { get; set; }

		internal LayerSettingDialog(LayerData layer)
			{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;

			Layer = layer;
			LayerProfile = Layer.Profile;
			textBoxLayerName.Text = Layer.Name;
			Border = new PenEx( LayerProfile.RenderSetting.Border );
			Fill = new HatchBrushEx( LayerProfile.RenderSetting.Fill );

			Text = Language.LayerSettingDialog.Text;
			labelName.Text = Language.LayerSettingDialog.LabelLayerName;
			groupBoxMaterial.Text = Language.LayerSettingDialog.GroupBoxMaterial;
			buttonMaterial.Text = Language.LayerSettingDialog.ButtonMaterial;
			groupBoxRenderingStyle.Text = Language.LayerSettingDialog.GroupBoxRenderingStyle;
			buttonBorderColor.Text = Language.LayerSettingDialog.ButtonBorderColor;
			buttonFillColor.Text = Language.LayerSettingDialog.ButtonFillColor;
			buttonFillStyle.Text = Language.LayerSettingDialog.ButtonFillStyle;
			buttonOK.Text = Language.DialogGeneral.ButtonOK;
			buttonCancel.Text = Language.DialogGeneral.ButtonCancel;
			}



		private void WriteMaterialText()
			{
			labelMaterialValue.Text = string.Format( "{0} : {1}\r\n{2} : {3}\r\n{4} : {5}",
				Language.LayerSettingDialog.LabelMaterialValue_Center, LayerProfile.CenterZ,
				Language.LayerSettingDialog.LabelMaterialValue_Size, LayerProfile.SizeZ,
				Language.LayerSettingDialog.LabelMaterialValue_Index, LayerProfile.Material.Index );
			}



		private void pictureBoxRenderingStyle_Paint(object sender, PaintEventArgs e)
			{
			Graphics g = e.Graphics;
			g.Clear( Color.Black );
			Rectangle r = new Rectangle( (int)g.ClipBounds.X + 4, (int)g.ClipBounds.Y + 4, (int)g.ClipBounds.Width - 9, (int)g.ClipBounds.Height - 9 );
			g.FillRectangle( Fill, r );
			g.DrawRectangle( Border, r );
			}



		// マテリアル設定ダイアログ
		// マテリアル設定ダイアログの編集結果は、レイヤ設定ダイヤログの編集結果と独立しているため、
		// このオブジェクトのLayerProfileを更新する必要がある
		private void buttonMaterial_Click(object sender, EventArgs e)
			{
			if( Application.ShowMaterialEditorDialog( this ) )
				WriteMaterialText();
			}



		private void buttonBorderColor_Click(object sender, EventArgs e)
			{
			colorDialog.Color = LayerProfile.RenderSetting.Border.Color;
			if( colorDialog.ShowDialog() == DialogResult.OK )
				{
				Border = new Pen( colorDialog.Color );
				pictureBoxRenderingStyle.Refresh();
				}
			}



		private void buttonFillColor_Click(object sender, EventArgs e)
			{
			colorDialog.Color = LayerProfile.RenderSetting.Fill.ForegroundColor;
			if( colorDialog.ShowDialog() == DialogResult.OK )
				{
				Fill.ForegroundColor = colorDialog.Color;
				pictureBoxRenderingStyle.Refresh();
				}
			}



		private void buttonFillStyle_Click(object sender, EventArgs e)
			{
			FillStyleDialog dialog = new FillStyleDialog();
			dialog.HatchStyle = LayerProfile.RenderSetting.Fill.HatchStyle;
			if( dialog.ShowDialog() == DialogResult.OK )
				{
				Fill.HatchStyle = dialog.HatchStyle;
				pictureBoxRenderingStyle.Refresh();
				}
			}

		// マテリアル設定ダイアログの編集結果は、レイヤ設定ダイヤログの編集結果と独立しているため、
		// このオブジェクトのLayerProfileを更新する必要がある
		private void buttonOK_Click(object sender, EventArgs e)
			{
			DialogResult = DialogResult.OK;
			Layer.Name = textBoxLayerName.Text;
			LayerProfile.RenderSetting.Border = Border;
			LayerProfile.RenderSetting.Fill = Fill;
			Close();
			}

		private void buttonCancel_Click(object sender, EventArgs e)
			{
			DialogResult = DialogResult.Cancel;
			Close();
			}
		}
	}
