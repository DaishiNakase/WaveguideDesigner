using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	/// <summary>プロパティエディタの表示で利用するカスタム属性。</summary>
	[AttributeUsage( AttributeTargets.Property )]
	public class PropertyEditorAttribute : Attribute
		{
		public int Index { get; private set; }
		public bool EditableAsString { get; private set; }

		public PropertyEditorAttribute(int index)
			: this( index, false ) { }

		public PropertyEditorAttribute(int index, bool editableAsString)
			{
			Index = index;
			EditableAsString = editableAsString;
			}

		}






	}
