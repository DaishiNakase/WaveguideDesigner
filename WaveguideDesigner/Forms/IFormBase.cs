using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.WaveguideDesigner.Forms
	{
	public interface IFormBase
		{
		string ClassName { get; }

		Application Application { get; }

		LanguagePack Language { get; }

		void RefreshLanguage();

		void RefreshRender();
		}
	}
