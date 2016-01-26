using System;

namespace Hslab.WaveguideDesigner.ProjectData
	{
	public abstract class PathStructureObjectData : GeometricObjectDataBase
		{
		/// <summary>描画ポイント数。</summary>
		[PropertyEditorAttribute( 4, true )]
		public int PointNum
			{
			get { return _PointNum; }
			set { _PointNum = Math.Max( 2, value ); }
			}
		private int _PointNum;
		private static bool _PointNum_Validate(object o) { return (int)o >= 2; }



		public PathStructureObjectData()
			{
			PointNum = 2;
			}


		public PathStructureObjectData(PathStructureObjectData previous)
			: base( previous )
			{
			PointNum = previous.PointNum;
			}




		}
	}
