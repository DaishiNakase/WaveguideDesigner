using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Hslab.WaveguideDesigner.ProjectData;

namespace Hslab.WaveguideDesigner.Forms
	{
	public partial class PropertyEditor : Hslab.WaveguideDesigner.Forms.DockContentBase
		{
		/// <summary>クラス名。</summary>
		public override string ClassName { get { return "Forms.PropertyEditor"; } }


		public PropertyEditor() : this( null ) { }
		public PropertyEditor(FormBase parent)
			: base( parent )
			{
			InitializeComponent();
			}



		private DataGridViewCell GetCell(int i, int j)
			{
			return dataGridView.Rows[i].Cells[j];
			}




		public override void RefreshLanguage()
			{
			//base.RefreshLanguage();
			}



		public override void RefreshRender()
			{
			Application_SelectionChanged( this, new Application.SelectionChangedEventArgs( null, Application.Selection ) );
			//base.RefreshRender();
			}



		// プロジェクトデータの選択が変更されたとき、dataGridViewを整形する
		public override void Application_SelectionChanged(object sender, Application.SelectionChangedEventArgs e)
			{
			try
				{
				dataGridView.Rows.Clear();
				dataGridView.Columns.Clear();
				}
			catch( InvalidOperationException ) { return; }

			if( e.NewItem == null ) return;
			// else if( e.NewItem is WaveguideDesignerProjectData ) { }
			// else if( e.NewItem is ProjectManifestData ) { }
			// else if( e.NewItem is GlobalRenderSettingData ) { }
			// else if( e.NewItem is GlobalStructureNumericsData ) { }
			// else if( e.NewItem is LayerData ) { }
			else if( e.NewItem is ProjectList<ParameterData> )
				SetDataGridViewWithMathematicalData( e.NewItem as ProjectList<ParameterData> );
			else if( e.NewItem is ProjectList<FunctionData> )
				SetDataGridViewWithMathematicalData( e.NewItem as ProjectList<FunctionData> );
			else
				SetDataGridViewWithProjectDataBase( e.NewItem );

			}


		void SetDataGridViewWithMathematicalData<T>(ProjectList<T> list) where T : NamedDataBase, IMathematicalData
			{
			toolStrip.Visible = true;

			PropertyInfo[] properties = typeof( T ).GetProperties();
			List<ProjectDataProperty> projProperties = new List<ProjectDataProperty>();
			PropertyEditorAttribute attr;

			foreach( PropertyInfo p in properties )
				{
				attr = Attribute.GetCustomAttribute( p, typeof( PropertyEditorAttribute ) ) as PropertyEditorAttribute;
				if( attr != null )
					projProperties.Add( new ProjectDataProperty( attr, p ) );
				}

			projProperties.Sort();
			Dictionary<string, object> tags;
			Action<DataGridViewCell> changed;
			T data;
			DataGridViewRow row;
			DataGridViewTextBoxCell nCell, vCell;
			dataGridView.Columns.Add( "Name", "Name" );
			dataGridView.Columns.Add( "Value", projProperties[1].P.Name );
			dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			foreach( object obj in list )
				{
				data = obj as T;
				row = new DataGridViewRow();

				changed = MakeValueChangedAction( data, projProperties[0].P );
				nCell = new DataGridViewTextBoxCell();
				nCell.ValueType = typeof( string );
				nCell.Value = data.Name;
				tags = new Dictionary<string, object>();
				tags.Add( "ValueChanged", changed );
				nCell.Tag = tags;
				row.Cells.Add( nCell );
				nCell.ReadOnly = false;

				changed = MakeValueChangedAction( data, projProperties[1].P );
				vCell = new DataGridViewTextBoxCell();
				vCell.ValueType = projProperties[1].P.PropertyType;
				vCell.Value = projProperties[1].P.GetValue( data );
				tags = new Dictionary<string, object>();
				tags.Add( "ValueChanged", changed );
				vCell.Tag = tags;
				row.Cells.Add( vCell );
				vCell.ReadOnly = false;

				dataGridView.Rows.Add( row );
				}
			}



		void SetDataGridViewWithProjectDataBase(ProjectDataBase data)
			{
			// 特別な注意が必要なProjectData以外はリフレクションを利用してdataGridViewを設定する
			// toolStripは隠す
			toolStrip.Visible = false;

			PropertyInfo[] properties = data.GetType().GetProperties();
			List<ProjectDataProperty> projProperties = new List<ProjectDataProperty>();
			PropertyEditorAttribute attr;

			foreach( PropertyInfo p in properties )
				{
				attr = Attribute.GetCustomAttribute( p, typeof( PropertyEditorAttribute ) ) as PropertyEditorAttribute;
				if( attr != null )
					projProperties.Add( new ProjectDataProperty( attr, p ) );
				}

			projProperties.Sort();
			PropertyInfo descriptionStringProperty;
			Dictionary<string, object> tags;
			Action<DataGridViewCell> selected, changed;
			DataGridViewRow row;
			DataGridViewTextBoxCell nCell, vCell;
			dataGridView.Columns.Add( "Name", "Name" );
			dataGridView.Columns.Add( "Value", "Value" );
			dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			foreach( ProjectDataProperty p in projProperties )
				{
				row = new DataGridViewRow();
				descriptionStringProperty = typeof( LanguagePack.ProjectDataPropertyDescriptionText ).GetProperty( data.GetType().Name + "_" + p.P.Name );
				if( descriptionStringProperty == null )
					descriptionStringProperty = typeof( LanguagePack.ProjectDataPropertyDescriptionText ).GetProperty( p.P.DeclaringType.Name + "_" + p.P.Name );
				selected = MakeSelectedAction( p.P, descriptionStringProperty );

				nCell = new DataGridViewTextBoxCell();
				nCell.Value = p.P.Name;
				tags = new Dictionary<string, object>();
				tags.Add( "Selected", selected );
				nCell.Tag = tags;
				row.Cells.Add( nCell );
				nCell.ReadOnly = true;

				vCell = new DataGridViewTextBoxCell();
				changed = MakeValueChangedAction( data, p.P );
				vCell.ValueType = p.P.PropertyType;
				vCell.Value = p.P.GetValue( data );
				tags = new Dictionary<string, object>();
				tags.Add( "ValueChanged", changed );
				vCell.Tag = tags;
				row.Cells.Add( vCell );
				vCell.ReadOnly = !p.Attr.EditableAsString;

				dataGridView.Rows.Add( row );
				}

			}



		Action<DataGridViewCell> MakeSelectedAction(PropertyInfo projectDataProperty, PropertyInfo descriptionStringProperty)
			{
			return (DataGridViewCell cell) =>
				{
					string description = descriptionStringProperty?.GetValue( Language.ProjectDataPropertyDescription )?.ToString() ?? "";
					labelName.Text = projectDataProperty.Name;
					labelDescription.Text = description;
				};
			}



		Action<DataGridViewCell> MakeValueChangedAction(ProjectDataBase data, PropertyInfo projectDataProperty)
			{
			bool flag = projectDataProperty.DeclaringType == typeof( GlobalRenderingSettingData )
				|| projectDataProperty.DeclaringType == typeof( ParameterData )
				|| projectDataProperty.DeclaringType == typeof( FunctionData )
				|| projectDataProperty.DeclaringType == typeof( LayerRenderSettingData )
				|| projectDataProperty.DeclaringType.IsSubclassOf( typeof( GeometricObjectDataBase ) );
			return (DataGridViewCell cell) =>
				{
					if( !projectDataProperty.GetValue( data ).Equals( cell.Value ) )
						{
						Application.ChangeProperty( data, projectDataProperty, cell.Value );
						if( !projectDataProperty.GetValue( data ).Equals( cell.Value ) )
							cell.Value = projectDataProperty.GetValue( data );

						Application.ValidateProject( Application.DoesUpdateShapeAuto );
						}
				};
			}



		private void dataGridView_SelectionChanged(object sender, EventArgs e)
			{
			if( dataGridView.SelectedCells.Count == 0 ) return;
			int row = dataGridView.SelectedCells[0].RowIndex;
			foreach( DataGridViewCell cell in dataGridView.SelectedCells )
				if( cell.RowIndex != row ) return;

			Dictionary<string, object> tags = dataGridView.Rows[row].Cells[0].Tag as Dictionary<string, object>;
			if( tags == null ) return;

			Action<DataGridViewCell> action = tags.ContainsKey( "Selected" ) ? tags["Selected"] as Action<DataGridViewCell> : null;
			if( action == null ) return;

			action( dataGridView.Rows[row].Cells[0] );
			}



		private void dataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
			{
			Dictionary<string, object> tags = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag as Dictionary<string, object>;
			if( tags == null ) return;

			Action<DataGridViewCell> action = null;
			if( tags.ContainsKey( "ValueChanged" ) )
				action = tags["ValueChanged"] as Action<DataGridViewCell>;
			if( action != null )
				action( dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] );
			}



		private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
			{
			DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

			if( cell.ReadOnly ) return;

			if( cell.ValueType == typeof( string ) || cell.ValueType == typeof( object ) ) return;

			MethodInfo method = cell.ValueType.GetMethod( "TryParse", new Type[] { typeof( string ), cell.ValueType.MakeByRefType() } );
			if( method == null )
				{
				e.Cancel = true;
				return;
				}
			e.Cancel = !(bool)method.Invoke( null, new object[] { e.FormattedValue, null } );
			}



		private void toolStripButtonAdd_Click(object sender, EventArgs e)
			{
			IProjectList list = Application.Selection as IProjectList;
			if( list == null ) return;
			ProjectDataBase data = list.GenericType.GetConstructor( new Type[] { } ).Invoke( new object[] { } ) as ProjectDataBase;
			list.Add( data );
			Application_SelectionChanged( this, new Application.SelectionChangedEventArgs( null, Application.Selection ) );
			}



		private void toolStripButtonRemove_Click(object sender, EventArgs e)
			{
			IProjectList list = Application.Selection as IProjectList;
			if( list == null ) return;
			if( dataGridView.SelectedCells?[0] == null ) return;
			int index = dataGridView.SelectedCells[0].RowIndex;
			list.RemoveAt( index );
			Application_SelectionChanged( this, new Application.SelectionChangedEventArgs( null, Application.Selection ) );
			}



		private void toolStripButtonRaise_Click(object sender, EventArgs e)
			{
			IProjectList list = Application.Selection as IProjectList;
			if( list == null ) return;
			if( dataGridView.SelectedCells?[0] == null ) return;
			int index = dataGridView.SelectedCells[0].RowIndex;
			if( index <= 0 ) return;
			object obj = list[index];
			list.RemoveAt( index );
			list.Insert( index - 1, obj );
			Application_SelectionChanged( this, new Application.SelectionChangedEventArgs( null, Application.Selection ) );
			}



		private void toolStripButtonLower_Click(object sender, EventArgs e)
			{
			IProjectList list = Application.Selection as IProjectList;
			if( list == null ) return;
			if( dataGridView.SelectedCells?[0] == null ) return;
			int index = dataGridView.SelectedCells[0].RowIndex;
			if( index < 0 || index >= list.Count - 1 ) return;
			object obj = list[index];
			list.RemoveAt( index );
			list.Insert( index + 1, obj );
			Application_SelectionChanged( this, new Application.SelectionChangedEventArgs( null, Application.Selection ) );
			}
		}




	internal class ProjectDataProperty : IComparable<ProjectDataProperty>
		{
		internal PropertyEditorAttribute Attr { get; private set; }
		internal PropertyInfo P { get; private set; }

		internal ProjectDataProperty(PropertyEditorAttribute attr, PropertyInfo p)
			{
			Attr = attr;
			P = p;
			}


		public int CompareTo(ProjectDataProperty other)
			{
			return this.Attr.Index - other.Attr.Index;
			}
		}

	}
