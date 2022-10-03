namespace csModbusViewer
{
    partial class dlgOptions
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
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.gbSerial = new System.Windows.Forms.GroupBox();
            this.tbComPort = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cbBaud = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.tbSlaveID = new System.Windows.Forms.TextBox();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.gbEthernet = new System.Windows.Forms.GroupBox();
            this.tbHostname = new System.Windows.Forms.TextBox();
            this.lbHostname = new System.Windows.Forms.Label();
            this.tbTCPport = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.TableLayoutPanel1.SuspendLayout();
            this.gbSerial.SuspendLayout();
            this.gbEthernet.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(324, 188);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(195, 36);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.Location = new System.Drawing.Point(4, 4);
            this.OK_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(89, 28);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "OK";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(101, 4);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(89, 28);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancel";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(49, 27);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(43, 17);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Mode";
            // 
            // gbSerial
            // 
            this.gbSerial.Controls.Add(this.tbComPort);
            this.gbSerial.Controls.Add(this.Label4);
            this.gbSerial.Controls.Add(this.cbBaud);
            this.gbSerial.Controls.Add(this.Label3);
            this.gbSerial.Location = new System.Drawing.Point(272, 15);
            this.gbSerial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbSerial.Name = "gbSerial";
            this.gbSerial.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbSerial.Size = new System.Drawing.Size(235, 130);
            this.gbSerial.TabIndex = 2;
            this.gbSerial.TabStop = false;
            this.gbSerial.Text = "RTU / ASCII";
            // 
            // tbComPort
            // 
            this.tbComPort.Location = new System.Drawing.Point(93, 23);
            this.tbComPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbComPort.Name = "tbComPort";
            this.tbComPort.Size = new System.Drawing.Size(95, 22);
            this.tbComPort.TabIndex = 9;
            this.tbComPort.Text = "1";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(23, 27);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(62, 17);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "ComPort";
            // 
            // cbBaud
            // 
            this.cbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaud.FormattingEnabled = true;
            this.cbBaud.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "9600",
            "19200",
            "38400",
            "115200"});
            this.cbBaud.Location = new System.Drawing.Point(93, 55);
            this.cbBaud.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbBaud.Name = "cbBaud";
            this.cbBaud.Size = new System.Drawing.Size(97, 24);
            this.cbBaud.TabIndex = 7;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(40, 60);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(41, 17);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Baud";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(35, 60);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(56, 17);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "SlaveID";
            // 
            // tbSlaveID
            // 
            this.tbSlaveID.Location = new System.Drawing.Point(103, 57);
            this.tbSlaveID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSlaveID.Name = "tbSlaveID";
            this.tbSlaveID.Size = new System.Drawing.Size(95, 22);
            this.tbSlaveID.TabIndex = 3;
            this.tbSlaveID.Text = "1";
            // 
            // cbMode
            // 
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "TCP",
            "UDP",
            "RTU",
            "ASCII"});
            this.cbMode.Location = new System.Drawing.Point(103, 23);
            this.cbMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(95, 24);
            this.cbMode.TabIndex = 5;
            // 
            // gbEthernet
            // 
            this.gbEthernet.Controls.Add(this.tbHostname);
            this.gbEthernet.Controls.Add(this.lbHostname);
            this.gbEthernet.Controls.Add(this.tbTCPport);
            this.gbEthernet.Controls.Add(this.Label5);
            this.gbEthernet.Location = new System.Drawing.Point(17, 123);
            this.gbEthernet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbEthernet.Name = "gbEthernet";
            this.gbEthernet.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbEthernet.Size = new System.Drawing.Size(235, 100);
            this.gbEthernet.TabIndex = 6;
            this.gbEthernet.TabStop = false;
            this.gbEthernet.Text = "TCP / UDP";
            // 
            // tbHostname
            // 
            this.tbHostname.Location = new System.Drawing.Point(95, 52);
            this.tbHostname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbHostname.Name = "tbHostname";
            this.tbHostname.Size = new System.Drawing.Size(117, 22);
            this.tbHostname.TabIndex = 7;
            this.tbHostname.Text = "127.0.0.1";
            // 
            // lbHostname
            // 
            this.lbHostname.AutoSize = true;
            this.lbHostname.Location = new System.Drawing.Point(13, 55);
            this.lbHostname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHostname.Name = "lbHostname";
            this.lbHostname.Size = new System.Drawing.Size(72, 17);
            this.lbHostname.TabIndex = 6;
            this.lbHostname.Text = "Hostname";
            // 
            // tbTCPport
            // 
            this.tbTCPport.Location = new System.Drawing.Point(95, 25);
            this.tbTCPport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTCPport.Name = "tbTCPport";
            this.tbTCPport.Size = new System.Drawing.Size(117, 22);
            this.tbTCPport.TabIndex = 5;
            this.tbTCPport.Text = "502";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(52, 28);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(34, 17);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Port";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.tbSlaveID);
            this.GroupBox3.Controls.Add(this.Label2);
            this.GroupBox3.Controls.Add(this.cbMode);
            this.GroupBox3.Controls.Add(this.Label1);
            this.GroupBox3.Location = new System.Drawing.Point(17, 15);
            this.GroupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox3.Size = new System.Drawing.Size(233, 101);
            this.GroupBox3.TabIndex = 7;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "General";
            // 
            // dlgOptions
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(535, 239);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.gbEthernet);
            this.Controls.Add(this.gbSerial);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modbus Options";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.gbSerial.ResumeLayout(false);
            this.gbSerial.PerformLayout();
            this.gbEthernet.ResumeLayout(false);
            this.gbEthernet.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.GroupBox gbSerial;
        private System.Windows.Forms.TextBox tbSlaveID;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.TextBox tbComPort;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.ComboBox cbBaud;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.GroupBox gbEthernet;
        private System.Windows.Forms.TextBox tbTCPport;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.TextBox tbHostname;
        private System.Windows.Forms.Label lbHostname;
    }
}