namespace csModbusViewer
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
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ViewPanel = new csModbusViewer.MbViewPanel();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuStrip1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.mainToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
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
            this.MenuStrip1.Size = new System.Drawing.Size(948, 24);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem,
            this.designerToolStripMenuItem});
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.OptionsToolStripMenuItem.Text = "Options";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.SettingsToolStripMenuItem.Text = "Settings";
            // 
            // designerToolStripMenuItem
            // 
            this.designerToolStripMenuItem.CheckOnClick = true;
            this.designerToolStripMenuItem.Name = "designerToolStripMenuItem";
            this.designerToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
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
            this.StatusStrip1.Location = new System.Drawing.Point(0, 500);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(948, 22);
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
            this.springLabel.Size = new System.Drawing.Size(717, 17);
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
            this.mainToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolButtonStart,
            this.ToolButtonStop,
            this.ToolButtonConnection});
            this.mainToolBar.Location = new System.Drawing.Point(0, 24);
            this.mainToolBar.Name = "mainToolBar";
            this.mainToolBar.Size = new System.Drawing.Size(948, 39);
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
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 63);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.ViewPanel);
            this.mainSplitContainer.Size = new System.Drawing.Size(948, 437);
            this.mainSplitContainer.SplitterDistance = 700;
            this.mainSplitContainer.TabIndex = 13;
            // 
            // ViewPanel
            // 
            this.ViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewPanel.Location = new System.Drawing.Point(0, 0);
            this.ViewPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Size = new System.Drawing.Size(700, 437);
            this.ViewPanel.TabIndex = 11;
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // frmcsModbusViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 522);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.mainToolBar);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.MenuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmcsModbusViewer";
            this.Text = "cs Modbus Viewer";
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.mainToolBar.ResumeLayout(false);
            this.mainToolBar.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
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
        private MbViewPanel ViewPanel;
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
    }
}

