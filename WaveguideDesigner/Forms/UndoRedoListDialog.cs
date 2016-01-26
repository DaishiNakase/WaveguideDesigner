using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hslab.WaveguideDesigner.Forms
	{
	internal partial class UndoRedoListDialog : Hslab.WaveguideDesigner.Forms.FormBase
		{
		/// <summary>クラス名。</summary>
		public override string ClassName { get { return "Forms.UndoRedoListDialog"; } }

		internal bool UndoRedoResult { get; private set; }

		internal UndoRedoListDialog()
			{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;

			this.Text = LanguagePack.MakePlainString( Language.StandardFunction.URList );
			buttonOK.Text = Language.DialogGeneral.ButtonOK;
			buttonCancel.Text = Language.DialogGeneral.ButtonCancel;

			listBox.Items.Add( "(default)" );
			IList<UndoRedoPair> urs = Application.UndoRedoPairs;
			for( int i = Application.UndoRedoCount - 1 ; i >= 0 ; i-- )
				{
				listBox.Items.Add( urs[i] );
				}
			listBox.SelectedIndex = Application.CurrentUndoDepth;

			UndoRedoResult = false;
			DialogResult = DialogResult.Cancel;
			}



		private void listBox_SelectedIndexChanged(object sender, EventArgs e)
			{
			UndoRedoPair ur = listBox.SelectedItem as UndoRedoPair;
			if( ur != null )
				{
				groupBoxURName.Text = ur.Name;
				labelURDescription.Text = ur.Message;
				}
			else
				{
				groupBoxURName.Text = "----";
				labelURDescription.Text = "";
				}
			}




		private void buttonOK_Click(object sender, EventArgs e)
			{
			UndoRedoResult = Application.UndoRedo( listBox.SelectedIndex - Application.CurrentUndoDepth );
			DialogResult = DialogResult.OK;
			Close();
			}

		}
	}
