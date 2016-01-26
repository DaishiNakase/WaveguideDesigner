using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public class MeepRunFunction : MeepObjectBase
		{
		public enum RunType : int
			{
			Until = 1,
			Sources = 2,
			SourcesAndUntil = 3,
			}

		public RunType Type { get; private set; }

		public double Time
			{
			get { return _Time; }
			set
				{
				if( value <= 0 ) throw new ArgumentException();
				_Time = value;
				}
			}
		private double _Time;



		public StepFunctionCollection StepFunctions { get; private set; }



		private MeepRunFunction()
			{
			_Time = 0;
			StepFunctions = new StepFunctionCollection();
			}



		public static MeepRunFunction RunUntil(double time)
			{
			return new MeepRunFunction() { Type = RunType.Until, Time = time };
			}



		public static MeepRunFunction RunSources()
			{
			return new MeepRunFunction() { Type = RunType.Sources };
			}



		public static MeepRunFunction RunSourcesAndUntil(double time)
			{
			return new MeepRunFunction() { Type = RunType.SourcesAndUntil, Time = time };
			}



		public override string ToString()
			{
			string res = "";
			switch( Type )
				{
				case RunType.Until:
					res += string.Format( "(run-until {0}", Time );
					break;
				case RunType.Sources:
					res += string.Format( "(run-sources" );
					break;
				case RunType.SourcesAndUntil:
					res += string.Format( "(run-sources+ {0}", Time );
					break;
				}
			foreach( MeepStepFunction step in StepFunctions )
				res += " " + step.ToString();
			res += ")";
			return res;
			}
		}



	public abstract class MeepStepFunction : MeepObjectBase
		{
		public string FunctionName
			{
			get { return _FunctionName; }
			protected set
				{
				if( !value.IsValidNameInScheme() ) throw new ArgumentException();
				_FunctionName = value;
				}
			}
		private string _FunctionName;

		protected MeepStepFunction(string funcName)
			{
			FunctionName = funcName;
			}


		public static MeepStepFunction OutputEpsilon()
			{
			return new MeepOutputComponent( "output-epsilon" );
			}



		public static MeepStepFunction OutputMu()
			{
			return new MeepOutputComponent( "output-mu" );
			}



		public static MeepStepFunction OutputMagneticPower()
			{
			return new MeepOutputComponent( "output-hpwr" );
			}



		public static MeepStepFunction OutputElectricPower()
			{
			return new MeepOutputComponent( "output-dpwr" );
			}



		public static MeepStepFunction OutputTotalPower()
			{
			return new MeepOutputComponent( "output-tot-pwr" );
			}



		public static MeepStepFunction OutputFieldComponent(Component component)
			{
			switch( component )
				{
				case Component.Dielectric: return OutputEpsilon();
				case Component.Permeability: return OutputMu();
				}

			string res = "output-";
			switch( (Component)( ( (int)component / 10 ) * 10 ) )
				{
				case Component.E:
					res += "e";
					break;
				case Component.H:
					res += "h";
					break;
				case Component.D:
					res += "d";
					break;
				case Component.B:
					res += "b";
					break;
				}
			res += "field";
			switch( (int)component % 10 )
				{
				case 1:
					res += "-x";
					break;
				case 2:
					res += "-y";
					break;
				case 3:
					res += "-z";
					break;
				case 4:
					res += "-r";
					break;
				case 5:
					res += "-p";
					break;
				}

			return new MeepOutputComponent( res );
			}

		public static MeepStepFunction OutputFieldComponent(DerivedComponent component)
			{
			switch( component )
				{
				case DerivedComponent.HEnergyDensity: return OutputMagneticPower();
				case DerivedComponent.DEnergyDensity: return OutputElectricPower();
				case DerivedComponent.EnergyDensity: return OutputTotalPower();
				}

			string res = "output-sfield";
			switch( (int)component % 10 )
				{
				case 1:
					res += "-x";
					break;
				case 2:
					res += "-y";
					break;
				case 3:
					res += "-z";
					break;
				case 4:
					res += "-r";
					break;
				case 5:
					res += "-p";
					break;
				}

			return new MeepOutputComponent( res );
			}



		public static MeepStepFunction AtEvery(double dt,IList<MeepStepFunction> functions)
			{
			return new MeepOutputControl( "at-every", new object[] { dt }, functions );
			}



		public static MeepStepFunction AfterTime(double t,IList<MeepStepFunction> functions)
			{
			return new MeepOutputControl( "after-time", new object[] { t }, functions );
			}



		public static MeepStepFunction BeforeTime(double t,IList<MeepStepFunction> functions)
			{
			return new MeepOutputControl( "before-time",new object[]{t},functions );
			}



		public static MeepStepFunction AtTime(double t,IList<MeepStepFunction> functions)
			{
			return new MeepOutputControl( "at-time",new object[]{t},functions );
			}



		public static MeepStepFunction AfterSources(IList<MeepStepFunction> functions)
			{
			return new MeepOutputControl( "after-sources",new object[]{},functions );
			}



		public static MeepStepFunction AterSourcesAndTime(double t,IList<MeepStepFunction> functions)
			{
			return new MeepOutputControl( "after-sources+", new object[] { t }, functions );
			}



		public static MeepStepFunction DuringSources(IList<MeepStepFunction> functions)
			{
			return new MeepOutputControl( "during-sources", new object[] { }, functions );
			}



		public static MeepStepFunction AtBeginning(IList<MeepStepFunction> functions)
			{
			return new MeepOutputControl( "at-beginning", new object[] { }, functions );
			}



		public static MeepStepFunction AtEnd(IList<MeepStepFunction> functions)
			{
			return new MeepOutputControl( "at-end", new object[] { }, functions );
			}



		public static MeepStepFunction InVolume(MeepVolume v,IList<MeepStepFunction> functions)
			{
			if( v == null ) throw new ArgumentNullException();
			return new MeepOutputControl( "in-volume", new object[] { v }, functions );
			}



		public static MeepStepFunction InPoint(MeepVector3 pt,IList<MeepStepFunction> functions)
			{
			return new MeepOutputControl( "in-point",new object[]{pt},functions );
			}



		public static MeepStepFunction ToAppended(string filename,IList<MeepStepFunction> functions)
			{
			return new MeepOutputControl( "to-appended",new object[]{filename},functions );
			}



		public static MeepStepFunction WithPrefix(string prefix,IList<MeepStepFunction> functions)
			{
			return new MeepOutputControl( "with-prefix",new object[]{prefix},functions );
			}







		public class MeepOutputComponent : MeepStepFunction
			{
			internal MeepOutputComponent(string funcName)
				: base( funcName )
			{ }

			public override string ToString()
				{
				return FunctionName;
				}
			}



		public class MeepOutputControl : MeepStepFunction
			{
			public ReadOnlyCollection<object> AdditionalArguments
				{
				get { return new ReadOnlyCollection<object>( _AdditionalArguments ); }
				}
			private object[] _AdditionalArguments;

			public StepFunctionCollection ChildFunctions { get; private set; }

			internal MeepOutputControl(string funcName, object[] additionalArguments, IList<MeepStepFunction> childFunctions)
				: base( funcName )
				{
				if( additionalArguments == null ) throw new ArgumentNullException();
				_AdditionalArguments = additionalArguments;
				ChildFunctions = new StepFunctionCollection();
				if( childFunctions != null ) ChildFunctions.AddRange( childFunctions );
				}

			public override string ToString()
				{
				if( ChildFunctions.Count == 0 ) throw new ArgumentException();
				string res = "("+FunctionName;
				foreach( object arg in _AdditionalArguments ) res += " " + arg.ToString();
				foreach( MeepStepFunction func in ChildFunctions ) res += " " + func.ToString();
				res += ")";
				return res;
				}
			}
		}



	public class StepFunctionCollection:Collection<MeepStepFunction>
		{
		public StepFunctionCollection() { }

		public StepFunctionCollection(IList<MeepStepFunction> list)
			{
			this.AddRange( list );
			}

		public void AddRange(IList<MeepStepFunction> list)
			{
			if( list == null ) throw new ArgumentNullException();
			foreach( MeepStepFunction func in list ) this.Add( func );
			}

		protected override void InsertItem(int index, MeepStepFunction item)
			{
			if( item == null ) throw new ArgumentNullException();
			base.InsertItem( index, item );
			}

		protected override void SetItem(int index, MeepStepFunction item)
			{
			if( item == null ) throw new ArgumentNullException();
			base.SetItem( index, item );
			}
		}
	}
