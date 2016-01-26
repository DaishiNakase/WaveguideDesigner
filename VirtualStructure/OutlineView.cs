using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hslab.VirtualStructure
	{
	/// <summary></summary>
	public partial class OutlineView : UserControl
		{
		/// <summary></summary>
		public static Pen DefaultFocusBoxBorder { get { return _DefaultFocusBoxBorder; } set { _DefaultFocusBoxBorder = value; } }
		private static Pen _DefaultFocusBoxBorder=new Pen(Color.Red,2f);
		
		/// <summary></summary>
		public static Brush DefaultFocusBoxFill { get { return _DefaultFocusBoxFill; } set { _DefaultFocusBoxFill = value; } }
		private static Brush _DefaultFocusBoxFill = new SolidBrush( Color.FromArgb( 16, 255, 0, 0 ) );

		/// <summary></summary>
		public StructureViewer ViewerTarget { get; set; }

		/// <summary></summary>
		public Pen FocusBoxBorder { get; set; }

		/// <summary></summary>
		public Brush FocusBoxFill { get; set; }

		/// <summary></summary>
		public PointD ViewPadding { get; set; }

		/// <summary></summary>
		public OutlineView()
			{
			InitializeComponent();

			if( FocusBoxBorder == null ) FocusBoxBorder = new Pen( Color.Red, 2 );

			this.DoubleBuffered = true;
			}



		void OutlineView_Paint(object sender, PaintEventArgs e)
			{
			if( ViewerTarget == null ) return;
			VirtualGraphics vg = new VirtualGraphics(ViewerTarget.VirtualGraphics);
			//for( int i = vg.Shapes.Count - 1 ; i >= 0 ; i-- ) if( vg.Shapes[i].GetType() == typeof( VirtualString ) ) vg.Shapes.RemoveAt( i );

			PointD LeftTop = new PointD();
			PointD RightBottom = new PointD( ViewerTarget.Width, ViewerTarget.Height );

			LeftTop = ViewerTarget.VirtualGraphics.FromViewToGlobal( LeftTop );
			RightBottom = ViewerTarget.VirtualGraphics.FromViewToGlobal( RightBottom );

			double X = Math.Min( LeftTop.X, RightBottom.X ),
				Y = Math.Min( LeftTop.Y, RightBottom.Y ),
				W = Math.Max( LeftTop.X, RightBottom.X ) - X,
				H = Math.Max( LeftTop.Y, RightBottom.Y ) - Y;

			if( W < 1 ) { X -= 0.5; W += 1; }
			if( H < 1 ) { Y -= 0.5; H += 1; }

			VirtualRectangle rect = new VirtualRectangle();
			rect.Location = new PointD( X, Y );
			rect.Size = new SizeD( W, H );

			rect.ShapeBorder = ( FocusBoxBorder != null ) ? FocusBoxBorder : DefaultFocusBoxBorder;
			rect.ShapeFill = ( FocusBoxFill != null ) ? FocusBoxFill : DefaultFocusBoxFill;

			//vg.Shapes.Add( rect );

			vg.AxesLine = null;
			vg.MoveViewToPerspective( e.Graphics, ViewPadding );
			vg.Mirroring= new SizeD( 1, -1 ) ;
			vg.RenderToView( e.Graphics );


			}


		}
	}
