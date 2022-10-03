using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csModbusLib;
using csModbusView;
using csFormsDesign;
namespace csModbusViewer
{
    public partial class frmcsModbusViewer : Form
    {
        private MbMaster ModMaster;
        private MbInterface modbusConnection;
        private List<ModbusView> ModbusViewList;
        private System.Timers.Timer sysRefreshTimer;
        private int RefreshCount = 0;
        private int ErrorCount = 0;
        private bool Running = false;
        
        private csModbusLib.ConnectionType InterfaceType = ConnectionType.NO_CONNECTION;


        public frmcsModbusViewer()
        {
            InitializeComponent();
            mainSplitContainer.Panel2Collapsed = true;
            this.Load += csModsMaster_Load;
            this.FormClosing += frmModsMaster_Closing;

            this.SettingsToolStripMenuItem.Click += ConnectionSettings;
            this.ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            this.designerToolStripMenuItem.CheckedChanged += DesignerToolStripMenuItem_CheckedChanged;
            this.ToolButtonStart.Click  += cmStart_Click;
            this.ToolButtonStop.Click += cmStop_Click;
            this.ToolButtonConnection.Click += ConnectionSettings;

            ModMaster = new MbMaster();
            ModbusViewList = this.ViewPanel.DeserializeModbusViews(ModMaster);

            sysRefreshTimer = new System.Timers.Timer();
            sysRefreshTimer.Enabled = false;
            sysRefreshTimer.AutoReset = false;
            sysRefreshTimer.Interval = 20;
            sysRefreshTimer.Elapsed += OnSystemTimedEvent;

            StatusErrorCount.Text = "";
            ToolButtonStop.Enabled = false;
        }

        private void DesignerToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (designerToolStripMenuItem.Checked) {
                if (Running)
                    MasterClose();
                lbLastError.Text = "Design Mode";

                PropertyGrid properties = new PropertyGrid();
                mainSplitContainer.Panel2Collapsed = false;
                mainSplitContainer.Panel2.Controls.Add(properties);
                properties.Dock = DockStyle.Fill;
               
                ViewPanel.EnableDesignMode(properties);
            } else {
                ViewPanel.CloseDesignMode();
                

            }
        }

        private void csModsMaster_Load(object sender, EventArgs e)
        {
            InitConnection();
        }
        private bool MasterConnect()
        {
            if (ModMaster.IsConnected)
                return true;
            lbLastError.Text = "Connecting..";
            this.Update();
            return ModMaster.Connect(modbusConnection, 1);
        }

        private void cmStart_Click(object sender, EventArgs e)
        {
            if (Running == false)
            {
                if (MasterConnect())
                {
                    sysRefreshTimer.Enabled = true;
                    SettingsToolStripMenuItem.Enabled = false;
                    Running = true;
                    lbLastError.Text = "Connected";
                    ToolButtonStart.Enabled = false;
                    ToolButtonStop.Enabled = true;
                }
                else
                    lbLastError.Text = "Connection Error";
            }
          
  
        }
        private void cmStop_Click(object sender, EventArgs e)
        {
            // TODO Master should closed at the end of one polling cycle
            // therfor better make a close request here which is executet in the timer
            if (Running) {
                MasterClose();
                ToolButtonStart.Enabled = true;
                ToolButtonStop.Enabled = false;
            }
        }

        private void MasterClose()
        {
            sysRefreshTimer.Enabled = false;
            ModMaster.Close();
            Running = false;
            StatusLabelCount.Text = "";
            RefreshCount = 0;
            SettingsToolStripMenuItem.Enabled = true;
            ErrorCount = 0;
            lbLastError.Text = "";
         }

        private void OnSystemTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            sysRefreshTimer.Enabled = false;
            csModbusLib.ErrorCodes ErrCode;
            ErrCode = RequestData();
            Invoke_DisplayErrorCode(ErrCode);
        }

        private csModbusLib.ErrorCodes RequestData()
        {
            csModbusLib.ErrorCodes ErrCode;

            foreach (MasterGridView mbView in ModbusViewList)
            {
                ErrCode = mbView.Update_ModbusData();
                if (ErrCode != ErrorCodes.NO_ERROR)
                    return ErrCode;
            }
            return ErrorCodes.NO_ERROR;
        }

        delegate void DisplayErrorCode_Callback(csModbusLib.ErrorCodes ErrCode);

        private void Invoke_DisplayErrorCode(csModbusLib.ErrorCodes ErrCode)
        {
            if (this.InvokeRequired)
            {
                DisplayErrorCode_Callback d = new DisplayErrorCode_Callback(DisplayErrorCode);
                this.Invoke(d, new object[] { ErrCode });
            }
            else
                DisplayErrorCode(ErrCode);
        }

        private void DisplayErrorCode(csModbusLib.ErrorCodes ErrCode)
        {
            if (ErrCode == ErrorCodes.NO_ERROR)
            {
                RefreshCount += 1;
                StatusLabelCount.Text = RefreshCount.ToString();
            }
            else
            {
                ErrorCount += 1;
                StatusErrorCount.Text = "Errors "+ ErrorCount.ToString();
                lbLastError.Text = ErrCode.ToString();
                if (ErrCode == ErrorCodes.MODBUS_EXCEPTION)
                {
                    ExceptionCodes ModbusException = ModMaster.GetModusException();
                    LbLastModbusException.Text = ModbusException.ToString();
                }
                else
                    LbLastModbusException.Text = "";

                if (InterfaceType == ConnectionType.TCP_IP)
                {
                    if ((ErrCode == csModbusLib.ErrorCodes.CONNECTION_ERROR) | (ErrCode == csModbusLib.ErrorCodes.CONNECTION_CLOSED))
                        MasterClose();
                }
            }

            if (Running)
                sysRefreshTimer.Enabled = true;
        }

        private void ConnectionSettings(object sender, EventArgs e)
        {
            dlgOptions OptionsDialog = new dlgOptions(DeviceType.MASTER);
            if (OptionsDialog.ShowDialog() == DialogResult.OK)
                InitConnection();
        }

        private void InitConnection()
        {
            switch (Properties.Settings.Default.Connection)
            {
                case "RTU":
                    {
                        InterfaceType = csModbusLib.ConnectionType.SERIAL_RTU;
                        modbusConnection = new MbRTU(Properties.Settings.Default.ComPort, Properties.Settings.Default.Baudrate);
                        lbConnectionOptions.Text = string.Format("RTU {0},{1}", Properties.Settings.Default.ComPort, Properties.Settings.Default.Baudrate);
                        break;
                    }

                case "ASCII":
                    {
                        InterfaceType = csModbusLib.ConnectionType.SERIAL_ASCII;
                        modbusConnection = new MbASCII(Properties.Settings.Default.ComPort, Properties.Settings.Default.Baudrate);
                        lbConnectionOptions.Text = string.Format("ASCII {0},{1}", Properties.Settings.Default.ComPort, Properties.Settings.Default.Baudrate);
                        break;
                    }

                case "TCP":
                    {
                        InterfaceType = csModbusLib.ConnectionType.TCP_IP;
                        modbusConnection = new MbTCPMaster(Properties.Settings.Default.Hostname, Properties.Settings.Default.TCPport);
                        lbConnectionOptions.Text = string.Format("TCP {0} Port {1}", Properties.Settings.Default.Hostname, Properties.Settings.Default.TCPport);
                        break;
                    }

                case "UDP":
                    {
                        InterfaceType = csModbusLib.ConnectionType.UDP_IP;
                        modbusConnection = new MbUDPMaster(Properties.Settings.Default.Hostname, Properties.Settings.Default.TCPport);
                        lbConnectionOptions.Text = string.Format("UDP {0}:{1}", Properties.Settings.Default.Hostname, Properties.Settings.Default.TCPport);
                        break;
                    }

                default:
                    {
                        MessageBox.Show (Properties.Settings.Default.Connection + "\r\n" + "not supported");
                        ToolButtonStart.Enabled = false;
                        return;
                    }
            }
            ToolButtonStart.Enabled = true;
        }

        private void GridViewRegs_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            sysRefreshTimer.Enabled = false;
        }

        private void cmTest_Click_1(object sender, EventArgs e)
        {
  
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmModsMaster_Closing(object sender, CancelEventArgs e)
        {
            if (ModMaster.IsConnected)
                MasterClose();
            //mbser.Serialize(ModbusViewList);
        }
    }
}
