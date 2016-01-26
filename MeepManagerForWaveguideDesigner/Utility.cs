using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public static class StaticMethods
		{
		public static string ToStringEx(this Direction dir)
			{
			switch( dir )
				{
				case Direction.X: return "X";
				case Direction.Y: return "Y";
				case Direction.Z: return "Z";
				case Direction.R: return "R";
				case Direction.P: return "P";
				case Direction.All: return "ALL";
				case Direction.Automatic: return "AUTOMATIC";
				default: return "";
				}
			}

		public static string ToStringEx(this BoundarySide side)
			{
			switch( side )
				{
				case BoundarySide.Low: return "Low";
				case BoundarySide.High: return "High";
				case BoundarySide.All: return "ALL";
				default: return "";
				}
			}

		public static string ToStringEx(this Component com)
			{
			switch( com )
				{
				case Component.Ex: return "Ex";
				case Component.Ey: return "Ey";
				case Component.Ez: return "Ez";
				case Component.Er: return "Er";
				case Component.Ep: return "Ep";
				case Component.Hx: return "Hx";
				case Component.Hy: return "Hy";
				case Component.Hz: return "Hz";
				case Component.Hr: return "Hy";
				case Component.Hp: return "Hp";
				case Component.Bx: return "Bx";
				case Component.By: return "By";
				case Component.Bz: return "Bz";
				case Component.Br: return "By";
				case Component.Bp: return "Bp";
				case Component.Dx: return "Dx";
				case Component.Dy: return "Dy";
				case Component.Dz: return "Dz";
				case Component.Dr: return "Dr";
				case Component.Dp: return "Dp";
				case Component.Dielectric: return "Dielectric";
				case Component.Permeability: return "Permeability";
				default: return "";
				}
			}
		
		public static string ToStringEx(this DerivedComponent dcom)
			{
			switch(dcom)
				{
				case DerivedComponent.Sx:return "Sx";
				case DerivedComponent.Sy:return "Sy";
				case DerivedComponent.Sz:return "Sz";
				case DerivedComponent.Sr:return "Sr";
				case DerivedComponent.Sp:return "Sp";
				case DerivedComponent.EnergyDensity:return "EnergyDensity";
				case DerivedComponent.DEnergyDensity:return "DEnergyDensity";
				case DerivedComponent.HEnergyDensity:return "HEnergyDensity";
				default: return "";
				}
			}
		
		public static bool IsValidNameInScheme(this string str)
			{
			if( str == null ) return false;
			if( string.IsNullOrWhiteSpace( str ) ) return false;
			if( Regex.IsMatch( str, @"[^\w!$%&*+-./:<=>?@^_~]" ) ) return false;
			if( Regex.IsMatch( str, @"\b[+-]?\d+" ) ) return false;
			return true;
			}
		}


	public enum Direction:int
		{
		X=1, Y=2, Z=3, R=4, P=5, All=100,Automatic=101,
		}


	public enum BoundarySide:int
		{
		Low=1, High=2,All=100,
		}

	public enum Component:int
		{
		E =10,
		Ex=11,
		Ey=12,
		Ez=13,
		Er=14,
		Ep=15,
		H =20,
		Hx=21,
		Hy=22,
		Hz=23,
		Hr=24,
		Hp=25,
		B =30,
		Bx=31,
		By=32,
		Bz=33,
		Br=34,
		Bp=35,
		D =40,
		Dx=41,
		Dy=42,
		Dz=43,
		Dr=44,
		Dp=45,
		Dielectric  =98,
		Permeability=99,
		}

	public enum DerivedComponent:int
		{
		S =50,
		Sx=51,
		Sy=52,
		Sz=53,
		Sr=54,
		Sp=55,
		EnergyDensity =95,
		DEnergyDensity=96,
		HEnergyDensity=97,
		}
	}




