using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Hslab.MeepManager.WaveguideDesigner
	{
	public class SchemeCodeFormatter
		{
		private enum State : byte
			{
			Default = 0,
			Comment = 1,
			String = 2,
			Escape = 8,
			}





		public string Format(string code)
			{
			Regex regex;
			code = code.Replace( "\r\n", "\n" ).Replace( "\r", "\n" );
			int depth = 0;
			string res = "";
			State state = State.Default;
			for( int i = 0 ; i < code.Length ; i++ )
				{
				if( state == State.Default )
					{
					switch( code[i] )
						{
						case '(':
							if( depth == 0 ) res += "\n";
							res += code[i];
							depth++;
							break;
						case ')':
							res += "\n" + MakeTab( depth ) + code[i];
							depth--;
							break;
						case ' ':
						case '\t':
							res += "\n" + MakeTab( depth );
							break;
						case '\n':
							res += code[i] + MakeTab( depth );
							break;
						default: res += code[i]; break;
						}
					}
				else
					{
					if( code[i] == '\n' ) res += code[i] + MakeTab( depth );
					else res += code[i];
					}
				state = CheckNextState( state, code[i] );
				}

			string former, replace, later;
			int currentPos = 0;
			regex = new Regex( @"\([^()]+\)" );
			for( Match match = regex.Match( res ) ; match != Match.Empty ; match = regex.Match( res, currentPos ) )
				{
				former = res.Substring( 0, match.Index );
				replace = match.Value.Replace( "\n", " " ).Replace( "\t", "" ).Replace( " )", ")" );
				later = res.Substring( match.Index + match.Length );
				res = former + replace + later;
				currentPos = former.Length + replace.Length;
				}

			regex = new Regex( @"\)(?:\n\t+)+(\n\t+)\)" );
			while( regex.IsMatch( res ) )
				res = regex.Replace( res, @")$1)" );

			res = res.Replace( "\n", System.Environment.NewLine );
			return res;
			}



		private string MakeTab(int depth)
			{
			string res = "";
			for( int i = 0 ; i < depth ; i++ ) res += "\t";
			return res;
			}



		private State CheckNextState(State currentState, char c)
			{
			switch( currentState )
				{
				case State.Default:
					if( c == ';' ) return State.Comment;
					if( c == '"' ) return State.String;
					if( c == '\\' ) return currentState | State.Escape;
					return currentState;
				case State.String:
					if( c == '"' ) return State.Default;
					if( c == '\\' ) return currentState | State.Escape;
					return currentState;
				case State.Comment:
					if( c == '\n' ) return State.Default;
					return currentState;
				case State.Escape:
					return currentState ^ State.Escape;
				}
			return currentState;
			}

		}
	}
