using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public class MeepFlux : MeepObjectBase
		{
		public enum CodeType
			{
			AddFlux,
			//DisplayFlux,
			SaveFlux,
			}



		public string Name { get; set; }

		public double CenterWavelength { get; set; }
		public double CenterFrequency
			{
			get { return 1 / CenterWavelength; }
			set { CenterWavelength = 1 / value; }
			}
		public double FrequencyStep { get; set; }
		public int StepCount { get; set; }
		public FluxRegionCollection FluxRegions { get; private set; }




		public MeepFlux(string name, double centerWavelength, double freqencyStep, int stepCount, MeepFluxRegion[] fluxRegions)
			{
			Name = name;
			CenterWavelength = centerWavelength;
			FrequencyStep = freqencyStep;
			StepCount = stepCount;
			FluxRegions = new FluxRegionCollection();
			}





		public override string ToString()
			{
			string FluxRegion = "";
			foreach( MeepFluxRegion region in FluxRegions )
				FluxRegion += " " + region.ToString();
			return string.Format( "(define {0} (add-flux {1} {2} {3}{4}))", Name, CenterFrequency, FrequencyStep, StepCount, FluxRegion );
			}




		private string ToStringSaveFlux()
			{
			return string.Format( "(save-flux \"{0}\" {1})", Name, Name );
			}



		public string ToString(CodeType OutputCodeType)
			{
			switch( OutputCodeType )
				{
				case CodeType.AddFlux: return ToString();
				case CodeType.SaveFlux: return ToStringSaveFlux();
				}
			return "";
			}
		}



	public class FluxRegionCollection : Collection<MeepFluxRegion>
		{
		public FluxRegionCollection() { }

		protected override void InsertItem(int index, MeepFluxRegion item)
			{
			if( item == null ) throw new ArgumentNullException();
			base.InsertItem( index, item );
			}

		protected override void SetItem(int index, MeepFluxRegion item)
			{
			if( item == null ) throw new ArgumentNullException();
			base.SetItem( index, item );
			}
		}
	}
