using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hslab.WaveguideDesigner.Forms
	{
	internal partial class FillStyleDialog : FormBase
		{
		/// <summary>クラス名。</summary>
		public override string ClassName { get { return "Forms.FillStyleDialog"; } }

		internal HatchStyleEx HatchStyle { get; set; }

		private List<RadioButton> RadioButtons { get; set; }

		internal FillStyleDialog()
			{

			InitializeComponent();
			DialogResult = DialogResult.Cancel;

			HashSet<int> list = new HashSet<int>();
			foreach( HatchStyleEx style in Enum.GetValues( typeof( HatchStyleEx ) ) )
				list.Add( (int)style );

			Height += 45 * ( list.Count / 10 + 1 );

			int i = 0;
			RadioButtons = new List<RadioButton>();
			RadioButton radioButton;
			foreach( int style in list )
				{
				radioButton = new RadioButton();
				Controls.Add( radioButton );
				radioButton.Appearance = Appearance.Button;
				radioButton.AutoSize = false;
				radioButton.Text = "";
				radioButton.Width = 33;
				radioButton.Height = 33;
				radioButton.Location = new Point( 12 + 45 * ( i % 10 ), 12 + 45 * ( i / 10 ) );
				radioButton.Tag = style;
				radioButton.Paint += RadioButton_Paint;
				radioButton.CheckedChanged += RadioButton_CheckedChanged;
				radioButton.Checked = ( (int)HatchStyle == style );
				RadioButtons.Add( radioButton );
				i++;
				}
			}



		private void RadioButton_CheckedChanged(object sender, EventArgs e)
			{
			RadioButton radioButton = sender as RadioButton;
			if( radioButton.Checked )
				labelHatchStyle.Text = ( (HatchStyleEx)radioButton.Tag ).ToString();
			}



		private void RadioButton_Paint(object sender, PaintEventArgs e)
			{
			RadioButton radioButton = ( sender as RadioButton );
			HatchBrushEx brush = new HatchBrushEx();
			brush.HatchStyle = (HatchStyleEx)radioButton.Tag;
			e.Graphics.Clear( Color.Black );
			if( radioButton.Checked ) e.Graphics.DrawRectangle( new Pen( Color.Yellow, 3 ), e.ClipRectangle.X + 2, e.ClipRectangle.Y + 2, e.ClipRectangle.Width - 5, e.ClipRectangle.Height - 5 );
			e.Graphics.FillRectangle( brush, e.ClipRectangle.X + 4, e.ClipRectangle.Y + 4, e.ClipRectangle.Width - 8, e.ClipRectangle.Height - 8 );
			}

		private void button1_Click(object sender, EventArgs e)
			{
			DialogResult = DialogResult.OK;
			foreach( RadioButton radioButton in RadioButtons )
				if( radioButton.Checked )
					{
					HatchStyle = (HatchStyleEx)radioButton.Tag;
					break;
					}
			Close();
			}

		private void buttonCancel_Click(object sender, EventArgs e)
			{
			DialogResult = DialogResult.Cancel;
			Close();
			}
		}
	}
