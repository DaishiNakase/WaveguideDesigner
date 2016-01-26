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
	internal partial class TextEditorDialog : Form
		{
		internal string Value
			{
			get { return _Value; }
			set
				{
				_Value = value;
				richTextBox.Text = value;
				}
			}
		private string _Value;


		internal TextEditorDialog()
			{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;
			}



		private void buttonOK_Click(object sender, EventArgs e)
			{
			DialogResult = DialogResult.OK;
			Value=richTextBox.Text;
			Close();
			}



		private void buttonCancel_Click(object sender, EventArgs e)
			{
			DialogResult = DialogResult.Cancel;
			Close();
			}
		}
	}
