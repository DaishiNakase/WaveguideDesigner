namespace Hslab.WaveguideDesigner.Forms
	{
	partial class MainForm
		{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
			{
			if( disposing && ( components != null ) )
				{
				components.Dispose();
				}
			base.Dispose( disposing );
			}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
			{
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveProjectWithNewNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.urListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.structureViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.propertyEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.analysisAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.simulateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.outputctlFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.outputShellScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.materialEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.outputDxfFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.cadToolStripMenuItem,
            this.analysisAToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(784, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.saveProjectWithNewNameToolStripMenuItem,
            this.closeProjectToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// createProjectToolStripMenuItem
			// 
			this.createProjectToolStripMenuItem.Name = "createProjectToolStripMenuItem";
			this.createProjectToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
			this.createProjectToolStripMenuItem.Text = "&Create new projet";
			this.createProjectToolStripMenuItem.Click += new System.EventHandler(this.createProjectToolStripMenuItem_Click);
			// 
			// openProjectToolStripMenuItem
			// 
			this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
			this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
			this.openProjectToolStripMenuItem.Text = "&Open project";
			this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
			// 
			// saveProjectToolStripMenuItem
			// 
			this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
			this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
			this.saveProjectToolStripMenuItem.Text = "&Save project";
			this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
			// 
			// saveProjectWithNewNameToolStripMenuItem
			// 
			this.saveProjectWithNewNameToolStripMenuItem.Name = "saveProjectWithNewNameToolStripMenuItem";
			this.saveProjectWithNewNameToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
			this.saveProjectWithNewNameToolStripMenuItem.Text = "Save project with other name (&A)";
			this.saveProjectWithNewNameToolStripMenuItem.Click += new System.EventHandler(this.saveProjectWithNewNameToolStripMenuItem_Click);
			// 
			// closeProjectToolStripMenuItem
			// 
			this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
			this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
			this.closeProjectToolStripMenuItem.Text = "&Close project";
			this.closeProjectToolStripMenuItem.Click += new System.EventHandler(this.closeProjectToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(268, 6);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
			this.quitToolStripMenuItem.Text = "&Quit Waveguide Designer";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.urListToolStripMenuItem,
            this.toolStripSeparator2,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Enabled = false;
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.undoToolStripMenuItem.Text = "&Undo";
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Enabled = false;
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.redoToolStripMenuItem.Text = "&Redo";
			this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
			// 
			// urListToolStripMenuItem
			// 
			this.urListToolStripMenuItem.Name = "urListToolStripMenuItem";
			this.urListToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.urListToolStripMenuItem.Text = "Undo/Redo list (&L)";
			this.urListToolStripMenuItem.Click += new System.EventHandler(this.urListToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.cutToolStripMenuItem.Text = "Cut (&T)";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.deleteToolStripMenuItem.Text = "&Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectExplorerToolStripMenuItem,
            this.structureViewerToolStripMenuItem,
            this.propertyEditorToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// projectExplorerToolStripMenuItem
			// 
			this.projectExplorerToolStripMenuItem.Checked = true;
			this.projectExplorerToolStripMenuItem.CheckOnClick = true;
			this.projectExplorerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.projectExplorerToolStripMenuItem.Name = "projectExplorerToolStripMenuItem";
			this.projectExplorerToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.projectExplorerToolStripMenuItem.Text = "Project Explorer";
			this.projectExplorerToolStripMenuItem.CheckedChanged += new System.EventHandler(this.projectExplorerToolStripMenuItem_CheckedChanged);
			// 
			// structureViewerToolStripMenuItem
			// 
			this.structureViewerToolStripMenuItem.Checked = true;
			this.structureViewerToolStripMenuItem.CheckOnClick = true;
			this.structureViewerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.structureViewerToolStripMenuItem.Name = "structureViewerToolStripMenuItem";
			this.structureViewerToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.structureViewerToolStripMenuItem.Text = "Structure Viewer";
			this.structureViewerToolStripMenuItem.CheckedChanged += new System.EventHandler(this.structureViewerToolStripMenuItem_CheckedChanged);
			// 
			// propertyEditorToolStripMenuItem
			// 
			this.propertyEditorToolStripMenuItem.Checked = true;
			this.propertyEditorToolStripMenuItem.CheckOnClick = true;
			this.propertyEditorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.propertyEditorToolStripMenuItem.Name = "propertyEditorToolStripMenuItem";
			this.propertyEditorToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.propertyEditorToolStripMenuItem.Text = "Property Editor";
			this.propertyEditorToolStripMenuItem.CheckedChanged += new System.EventHandler(this.propertyEditorToolStripMenuItem_CheckedChanged);
			// 
			// cadToolStripMenuItem
			// 
			this.cadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputDxfFileToolStripMenuItem});
			this.cadToolStripMenuItem.Name = "cadToolStripMenuItem";
			this.cadToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.cadToolStripMenuItem.Text = "&CAD";
			// 
			// analysisAToolStripMenuItem
			// 
			this.analysisAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulateToolStripMenuItem,
            this.toolStripSeparator3,
            this.outputctlFileToolStripMenuItem,
            this.outputShellScriptToolStripMenuItem});
			this.analysisAToolStripMenuItem.Name = "analysisAToolStripMenuItem";
			this.analysisAToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.analysisAToolStripMenuItem.Text = "&Analysis";
			// 
			// simulateToolStripMenuItem
			// 
			this.simulateToolStripMenuItem.Enabled = false;
			this.simulateToolStripMenuItem.Name = "simulateToolStripMenuItem";
			this.simulateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.simulateToolStripMenuItem.Text = "Simulate";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
			// 
			// outputctlFileToolStripMenuItem
			// 
			this.outputctlFileToolStripMenuItem.Name = "outputctlFileToolStripMenuItem";
			this.outputctlFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.outputctlFileToolStripMenuItem.Text = "Output .ctl file";
			this.outputctlFileToolStripMenuItem.Click += new System.EventHandler(this.outputctlFileToolStripMenuItem_Click);
			// 
			// outputShellScriptToolStripMenuItem
			// 
			this.outputShellScriptToolStripMenuItem.Name = "outputShellScriptToolStripMenuItem";
			this.outputShellScriptToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.outputShellScriptToolStripMenuItem.Text = "Output shell script";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materialEditorToolStripMenuItem,
            this.toolStripSeparator4,
            this.optionToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// materialEditorToolStripMenuItem
			// 
			this.materialEditorToolStripMenuItem.Name = "materialEditorToolStripMenuItem";
			this.materialEditorToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.materialEditorToolStripMenuItem.Text = "Material Editor";
			this.materialEditorToolStripMenuItem.Click += new System.EventHandler(this.materialEditorToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(156, 6);
			// 
			// optionToolStripMenuItem
			// 
			this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
			this.optionToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.optionToolStripMenuItem.Text = "Option";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// versionToolStripMenuItem
			// 
			this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
			this.versionToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.versionToolStripMenuItem.Text = "Version";
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 539);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(784, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripProgressBar
			// 
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(23, 17);
			this.toolStripStatusLabel.Text = "    ";
			// 
			// dockPanel
			// 
			this.dockPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
			this.dockPanel.Location = new System.Drawing.Point(0, 24);
			this.dockPanel.Name = "dockPanel";
			this.dockPanel.Size = new System.Drawing.Size(784, 515);
			this.dockPanel.TabIndex = 2;
			// 
			// outputDxfFileToolStripMenuItem
			// 
			this.outputDxfFileToolStripMenuItem.Name = "outputDxfFileToolStripMenuItem";
			this.outputDxfFileToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.outputDxfFileToolStripMenuItem.Text = "Output .dxf file";
			this.outputDxfFileToolStripMenuItem.Click += new System.EventHandler(this.outputDxfFileToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.dockPanel);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.Text = "Waveguide Designer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem analysisAToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveProjectWithNewNameToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem urListToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
		private System.Windows.Forms.ToolStripMenuItem projectExplorerToolStripMenuItem;
		public System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripMenuItem structureViewerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem simulateToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem outputctlFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem propertyEditorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem outputShellScriptToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
		private System.Windows.Forms.ToolStripMenuItem materialEditorToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem outputDxfFileToolStripMenuItem;
		}
	}