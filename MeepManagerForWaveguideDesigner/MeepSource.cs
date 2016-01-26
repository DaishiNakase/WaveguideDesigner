using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public class MeepSource : MeepObjectBase
		{
		public enum SourceType
			{
			Continuous,
			Gaussian,
			}

		public SourceType Type { get; private set; }

		public Component Component
			{
			get { return _Component; }
			set
				{
				if( (int)value % 10 == 0 || (int)value >= 30 ) throw new ArgumentException();
				_Component = value;
				}
			}
		private Component _Component;

		public MeepVector3 Center { get; set; }

		public MeepVector3 Size { get; set; }

		public double Amplitude { get; set; }

		public double Wavelength { get; set; }

		public double Frequency
			{
			get { return 1 / Wavelength; }
			set { Wavelength = 1 / value; }
			}

		public double StartTime { get; set; }

		public double EndTime { get; set; }

		public double Width { get; set; }

		public double Cutoff { get; set; }



		private MeepSource(Component component, MeepVector3 center, double wavelength)
			{
			Component = component;
			Center = center;
			Size = MeepVector3.Zero;
			Amplitude = 1.0;
			Wavelength = wavelength;
			StartTime = 0;
			}

		public static MeepSource CreateContinuousSource(Component component, MeepVector3 center, double wavelength)
			{
			MeepSource res = new MeepSource( component, center, wavelength );
			res.Type = SourceType.Continuous;
			res.EndTime = double.PositiveInfinity;
			res.Width = 0;
			res.Cutoff = 3;
			return res;
			}

		public static MeepSource CreateGaussianSource(Component component, MeepVector3 center, double wavelength, double width)
			{
			MeepSource res = new MeepSource( component, center, wavelength );
			res.Type = SourceType.Gaussian;
			res.EndTime = double.NaN;
			res.Width = width;
			res.Cutoff = 5;
			return res;
			}



		public override string ToString()
			{
			string res = "(make source", src = "";
			switch( Type )
				{
				case SourceType.Continuous:
					src += "(make continuous-src";
					src += string.Format( " (wavelength {0})",Wavelength );
					if( StartTime != 0 ) res += string.Format( " (start-time {0})", StartTime );
					if( EndTime != double.PositiveInfinity ) src += string.Format( " (end-time {0})",EndTime );
					if( Width != 0 ) src += string.Format( " (width {0})", Width );
					if( Cutoff != 3 ) src += string.Format( " (cutoff {0})",Cutoff );
					src += ")";
					break;
				case SourceType.Gaussian:
					src += "(make gaussian-src";
					src += string.Format( " (wavelength {0})", Wavelength );
					if( StartTime != 0 ) res += string.Format( " (start-time {0})", StartTime );
					src += string.Format( " (width {0})", Width );
					if( Cutoff != 3 ) src += string.Format( " (cutoff {0})", Cutoff );
					src += ")";
					break;
				}
			res += string.Format( " (src {0})", src );
			res += string.Format( " (component {0})", Component.ToStringEx() );
			res += string.Format( " (center {0})", Center );
			if(Size!=MeepVector3.Zero)res += string.Format( " (size {0})", Size );
			if( Amplitude != 1.0 ) res += string.Format( " (amplitude {0})", Amplitude );

			res += ")";
			return res;
			}
		}
	}
