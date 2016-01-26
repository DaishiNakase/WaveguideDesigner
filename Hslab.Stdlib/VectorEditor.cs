using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace Hslab.WaveguideDesigner.Forms
	{
	/// <summary></summary>
	[Serializable]
	public class VectorEditor : TextBox
		{
		/// <summary></summary>
		[Category("動作")]
		public bool DoesCancelInvalid { get; set; }

		/// <summary></summary>
		[Category( "表示" ),Bindable( true )]
		public Vector3 Value
			{
			get { return _Value; }
			set
				{
				_Value = value;
				Text = Value.ToString();
				ValueChanged?.Invoke( this, EventArgs.Empty );
				}
			}
		private Vector3 _Value;

		/// <summary></summary>
		public event EventHandler ValueChanged;
		
		/// <summary></summary>
		public VectorEditor()
			{
			DoesCancelInvalid = true;
			Validating += VectorEditor_Validating;
			Text = Value.ToString();
			}

		private void VectorEditor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
			{
			Vector3 tmp;
			if( Vector3.TryParse( Text, out tmp ) )
				Value = tmp;
			else
				{
				if( DoesCancelInvalid ) e.Cancel = true;
				else Text = Value.ToString();
				}
			}
		}
	}
