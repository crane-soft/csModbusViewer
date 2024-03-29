﻿namespace csModbusViewer
{
    partial class frmcsModbusViewer
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
            try {
                if (disposing && components != null) {
                    components.Dispose();
                }
            } finally {
                base.Dispose(disposing);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmcsModbusViewer));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Holding Register");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Input Register");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Coils");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Discrete Inputs");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Modbus Views  -", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbConnectionOptions = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbLastError = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusErrorCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbLastModbusException = new System.Windows.Forms.ToolStripStatusLabel();
            this.springLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainToolBar = new System.Windows.Forms.ToolStrip();
            this.ToolButtonStart = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonStop = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonConnection = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelSpace = new System.Windows.Forms.ToolStripLabel();
            this.lbDeviceType = new System.Windows.Forms.ToolStripLabel();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.MbViewPanel = new csModbusViewer.MbViewDesignPanel();
            this.DesignerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.MbViewTree = new System.Windows.Forms.TreeView();
            this.MbViewPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.MenuStrip1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.mainToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DesignerSplitContainer)).BeginInit();
            this.DesignerSplitContainer.Panel1.SuspendLayout();
            this.DesignerSplitContainer.Panel2.SuspendLayout();
            this.DesignerSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.OptionsToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MenuStrip1.Size = new System.Drawing.Size(594, 24);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.newToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveAsDeviceToolStripMenuItem,
            this.toolStripSeparator2,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            // 
            // saveAsDeviceToolStripMenuItem
            // 
            this.saveAsDeviceToolStripMenuItem.Name = "saveAsDeviceToolStripMenuItem";
            this.saveAsDeviceToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.saveAsDeviceToolStripMenuItem.Text = "Save as device";
            this.saveAsDeviceToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem,
            this.designerToolStripMenuItem});
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.OptionsToolStripMenuItem.Text = "Options";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.SettingsToolStripMenuItem.Text = "Settings";
            // 
            // designerToolStripMenuItem
            // 
            this.designerToolStripMenuItem.CheckOnClick = true;
            this.designerToolStripMenuItem.Name = "designerToolStripMenuItem";
            this.designerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.designerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.designerToolStripMenuItem.Text = "Design Mode";
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbConnectionOptions,
            this.lbLastError,
            this.StatusErrorCount,
            this.LbLastModbusException,
            this.springLabel,
            this.StatusLabelCount});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 429);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(594, 22);
            this.StatusStrip1.TabIndex = 6;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // lbConnectionOptions
            // 
            this.lbConnectionOptions.Name = "lbConnectionOptions";
            this.lbConnectionOptions.Size = new System.Drawing.Size(69, 17);
            this.lbConnectionOptions.Text = "Connection";
            // 
            // lbLastError
            // 
            this.lbLastError.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.lbLastError.Name = "lbLastError";
            this.lbLastError.Size = new System.Drawing.Size(51, 17);
            this.lbLastError.Text = "No Error";
            // 
            // StatusErrorCount
            // 
            this.StatusErrorCount.Name = "StatusErrorCount";
            this.StatusErrorCount.Size = new System.Drawing.Size(37, 17);
            this.StatusErrorCount.Text = "Errors";
            // 
            // LbLastModbusException
            // 
            this.LbLastModbusException.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.LbLastModbusException.Name = "LbLastModbusException";
            this.LbLastModbusException.Size = new System.Drawing.Size(12, 17);
            this.LbLastModbusException.Text = "-";
            // 
            // springLabel
            // 
            this.springLabel.Name = "springLabel";
            this.springLabel.Size = new System.Drawing.Size(363, 17);
            this.springLabel.Spring = true;
            // 
            // StatusLabelCount
            // 
            this.StatusLabelCount.Name = "StatusLabelCount";
            this.StatusLabelCount.Size = new System.Drawing.Size(12, 17);
            this.StatusLabelCount.Text = "-";
            // 
            // mainToolBar
            // 
            this.mainToolBar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mainToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolButtonStart,
            this.ToolButtonStop,
            this.ToolButtonConnection,
            this.toolStripLabelSpace,
            this.lbDeviceType});
            this.mainToolBar.Location = new System.Drawing.Point(0, 24);
            this.mainToolBar.Name = "mainToolBar";
            this.mainToolBar.Size = new System.Drawing.Size(594, 39);
            this.mainToolBar.TabIndex = 12;
            this.mainToolBar.Text = "toolStrip1";
            // 
            // ToolButtonStart
            // 
            this.ToolButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonStart.Image")));
            this.ToolButtonStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonStart.Name = "ToolButtonStart";
            this.ToolButtonStart.Size = new System.Drawing.Size(36, 36);
            this.ToolButtonStart.Text = "Start Refresh Timer";
            // 
            // ToolButtonStop
            // 
            this.ToolButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonStop.Image")));
            this.ToolButtonStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonStop.Name = "ToolButtonStop";
            this.ToolButtonStop.Size = new System.Drawing.Size(36, 36);
            this.ToolButtonStop.Text = "Stop Refresh Timer";
            // 
            // ToolButtonConnection
            // 
            this.ToolButtonConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonConnection.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonConnection.Image")));
            this.ToolButtonConnection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonConnection.Name = "ToolButtonConnection";
            this.ToolButtonConnection.Size = new System.Drawing.Size(36, 36);
            this.ToolButtonConnection.Text = "Connection Oprions";
            // 
            // toolStripLabelSpace
            // 
            this.toolStripLabelSpace.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelSpace.AutoSize = false;
            this.toolStripLabelSpace.Name = "toolStripLabelSpace";
            this.toolStripLabelSpace.Size = new System.Drawing.Size(40, 36);
            // 
            // lbDeviceType
            // 
            this.lbDeviceType.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbDeviceType.Name = "lbDeviceType";
            this.lbDeviceType.Size = new System.Drawing.Size(71, 36);
            this.lbDeviceType.Text = "Devicetype";
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 63);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.MbViewPanel);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.DesignerSplitContainer);
            this.mainSplitContainer.Panel2MinSize = 200;
            this.mainSplitContainer.Size = new System.Drawing.Size(594, 366);
            this.mainSplitContainer.SplitterDistance = 375;
            this.mainSplitContainer.TabIndex = 13;
            // 
            // MbViewPanel
            // 
            this.MbViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MbViewPanel.Location = new System.Drawing.Point(0, 0);
            this.MbViewPanel.Modified = false;
            this.MbViewPanel.Name = "MbViewPanel";
            this.MbViewPanel.Size = new System.Drawing.Size(375, 366);
            this.MbViewPanel.TabIndex = 0;
            // 
            // DesignerSplitContainer
            // 
            this.DesignerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DesignerSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.DesignerSplitContainer.Name = "DesignerSplitContainer";
            this.DesignerSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // DesignerSplitContainer.Panel1
            // 
            this.DesignerSplitContainer.Panel1.Controls.Add(this.MbViewTree);
            this.DesignerSplitContainer.Panel1MinSize = 100;
            // 
            // DesignerSplitContainer.Panel2
            // 
            this.DesignerSplitContainer.Panel2.Controls.Add(this.MbViewPropertyGrid);
            this.DesignerSplitContainer.Panel2MinSize = 100;
            this.DesignerSplitContainer.Size = new System.Drawing.Size(215, 366);
            this.DesignerSplitContainer.SplitterDistance = 118;
            this.DesignerSplitContainer.TabIndex = 0;
            // 
            // MbViewTree
            // 
            this.MbViewTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MbViewTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MbViewTree.Location = new System.Drawing.Point(0, 0);
            this.MbViewTree.Name = "MbViewTree";
            treeNode1.Name = "ndHoldingRegs";
            treeNode1.Text = "Holding Register";
            treeNode2.Name = "ndInputRegs";
            treeNode2.Text = "Input Register";
            treeNode3.Name = "ndCoils";
            treeNode3.Text = "Coils";
            treeNode4.Name = "ndDiscreteInputs";
            treeNode4.Text = "Discrete Inputs";
            treeNode5.Name = "MbViewList";
            treeNode5.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode5.SelectedImageIndex = -2;
            treeNode5.Text = "Modbus Views  -";
            this.MbViewTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.MbViewTree.Size = new System.Drawing.Size(215, 118);
            this.MbViewTree.TabIndex = 1;
            // 
            // MbViewPropertyGrid
            // 
            this.MbViewPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MbViewPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.MbViewPropertyGrid.Name = "MbViewPropertyGrid";
            this.MbViewPropertyGrid.Size = new System.Drawing.Size(215, 244);
            this.MbViewPropertyGrid.TabIndex = 2;
            // 
            // frmcsModbusViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 451);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.mainToolBar);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.MenuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmcsModbusViewer";
            this.Text = "csModbusViewer";
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.mainToolBar.ResumeLayout(false);
            this.mainToolBar.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.DesignerSplitContainer.Panel1.ResumeLayout(false);
            this.DesignerSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DesignerSplitContainer)).EndInit();
            this.DesignerSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        System.Windows.Forms.MenuStrip MenuStrip1;
        System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        System.Windows.Forms.StatusStrip StatusStrip1;
        System.Windows.Forms.ToolStripStatusLabel lbConnectionOptions;
        System.Windows.Forms.ToolStripStatusLabel lbLastError;
        System.Windows.Forms.ToolStripStatusLabel LbLastModbusException;
        private System.Windows.Forms.ToolStripMenuItem designerToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel StatusErrorCount;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelCount;
        private System.Windows.Forms.ToolStripStatusLabel springLabel;
        private System.Windows.Forms.ToolStrip mainToolBar;
        private System.Windows.Forms.ToolStripButton ToolButtonStart;
        private System.Windows.Forms.ToolStripButton ToolButtonStop;
        private System.Windows.Forms.ToolStripButton ToolButtonConnection;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lbDeviceType;
        private System.Windows.Forms.ToolStripLabel toolStripLabelSpace;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.TreeView MbViewTree;
        private System.Windows.Forms.PropertyGrid MbViewPropertyGrid;
        private System.Windows.Forms.SplitContainer DesignerSplitContainer;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private MbViewDesignPanel MbViewPanel;
        private System.Windows.Forms.ToolStripMenuItem saveAsDeviceToolStripMenuItem;
    }
}

