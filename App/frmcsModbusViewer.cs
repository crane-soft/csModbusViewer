using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csModbusViewer.Properties;
using csModbusLib;
using csModbusView;
namespace csModbusViewer
{
    public partial class frmcsModbusViewer : Form
    {
        private csModbusLib.DeviceType ViewerType = DeviceType.NO_TYPE;

        private csModbusLib.ConnectionType InterfaceType = ConnectionType.NO_CONNECTION;

        private int RefreshCount = 0;
        private int ErrorCount = 0;
        private bool Running = false;
        private ViewerBase MbViewer;

        public frmcsModbusViewer()
        {
            InitializeComponent();
            mainSplitContainer.Panel2Collapsed = true;
            this.Load += csModsMaster_Load;
            this.FormClosing += frmModsMaster_Closing;

            this.SettingsToolStripMenuItem.Click += ConnectionSettings;
            this.openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            this.saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            this.ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            this.designerToolStripMenuItem.CheckedChanged += DesignerToolStripMenuItem_CheckedChanged;
            this.ToolButtonStart.Click  += cmStart_Click;
            this.ToolButtonStop.Click += cmStop_Click;
            this.ToolButtonConnection.Click += ConnectionSettings;


            StatusErrorCount.Text = "";
            ToolButtonStop.Enabled = false;
        }

        private void csModsMaster_Load(object sender, EventArgs e)
        {
            ReadModbusProfile (Settings.Default.JsonPath);
        }

        private void ReadModbusProfile(string JsonPath)
        {
            if (JsonPath.Length > 0) {
                List<ModbusView> ModbusViewList;
                ModbusViewList = this.ViewPanel.DeserializeModbusViews(JsonPath);
                MbViewer = new MasterViewer();
                MbViewer.ErrorCodeEvent += Invoke_DisplayErrorCode;
                MbViewer.SetViewList(ModbusViewList);
                InitConnection();

                this.Text = System.IO.Path.GetFileNameWithoutExtension(JsonPath) + " - " + this.Text;
                ViewerType = DeviceType.MASTER;
                if (ViewerType == DeviceType.MASTER) {
                    lbDeviceType.Text = "Modbus Master";
                } else if (ViewerType == DeviceType.SLAVE) {
                    lbDeviceType.Text = "Modbus Master";
                } else {
                    lbDeviceType.Text = "Type unknown";
                }
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string jsonFolder = Settings.Default.JsonFolder;

            OpenFileDialog ofDlg = new OpenFileDialog() {
                FileName = "Select a json file",
                Filter = "json files (*.json)|*.json",
                Title = "Open modbus profile",
                InitialDirectory = ""
            };
            if (jsonFolder.Length > 0) {
                ofDlg.InitialDirectory = jsonFolder;
            }

            if (ofDlg.ShowDialog() == DialogResult.OK) {
                string JsonPath = ofDlg.FileName;
                Settings.Default.JsonFolder = System.IO.Path.GetDirectoryName(JsonPath);
                Settings.Default.JsonPath = JsonPath;
                Settings.Default.Save();
                ReadModbusProfile(JsonPath);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string jsonFolder = Settings.Default.JsonFolder;
            
            SaveFileDialog ofDlg = new SaveFileDialog() {
                //FileName = "Select a json file",
                Filter = "json files (*.json)|*.json",
                Title = "Save modbus profile",
                InitialDirectory = ""
            };
            if (jsonFolder.Length > 0) {
                ofDlg.InitialDirectory = jsonFolder;
            }
            if (ofDlg.ShowDialog() == DialogResult.OK) {
                string JsonPath = ofDlg.FileName;
                this.ViewPanel.SerializeModbusViews(JsonPath);
            }
        }
        private void DesignerToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (designerToolStripMenuItem.Checked) {
                if (Running)
                    ModbusClose();
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

        private void cmStart_Click(object sender, EventArgs e)
        {
            if (Running == false)
            {
                if (ModbusConnect())
                {
                    SettingsToolStripMenuItem.Enabled = false;
                    Running = true;
                    lbLastError.Text = "Connected";
                    ToolButtonStart.Enabled = false;
                    ToolButtonStop.Enabled = true;
                    openToolStripMenuItem.Enabled = false;
                }
                else
                    lbLastError.Text = "Connection Error";
            }
        }

        private bool ModbusConnect()
        {
            if (MbViewer.IsConnected())
                return true;
            lbLastError.Text = "Connecting..";
            this.Update();
            return MbViewer.Connect();
        }

        private void cmStop_Click(object sender, EventArgs e)
        {
            // TODO Master should closed at the end of one polling cycle
            // therfor better make a close request here which is executet in the timer
            if (Running) {
                ModbusClose();
                ToolButtonStart.Enabled = true;
                ToolButtonStop.Enabled = false;
                openToolStripMenuItem.Enabled = true;
            }
        }

        private void ModbusClose()
        {
            MbViewer.Close();
            Running = false;
            StatusLabelCount.Text = "";
            RefreshCount = 0;
            SettingsToolStripMenuItem.Enabled = true;
            ErrorCount = 0;
            lbLastError.Text = "";
         }
 
        delegate void DisplayErrorCode_Callback(csModbusLib.ErrorCodes ErrCode);

        private void Invoke_DisplayErrorCode(csModbusLib.ErrorCodes ErrCode)
        {
            if (this.InvokeRequired)
            {
                DisplayErrorCode_Callback d = new DisplayErrorCode_Callback(DisplayErrorCode);
                this.BeginInvoke(d, new object[] { ErrCode });
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
                    ExceptionCodes ModbusException = MbViewer.GetModusException();
                    LbLastModbusException.Text = ModbusException.ToString();
                }
                else
                    LbLastModbusException.Text = "";

                if (InterfaceType == ConnectionType.TCP_IP)
                {
                    if ((ErrCode == csModbusLib.ErrorCodes.CONNECTION_ERROR) | (ErrCode == csModbusLib.ErrorCodes.CONNECTION_CLOSED))
                        ModbusClose();
                }
            }
        }

        private void ConnectionSettings(object sender, EventArgs e)
        {
            dlgOptions OptionsDialog = new dlgOptions(DeviceType.MASTER);
            if (OptionsDialog.ShowDialog() == DialogResult.OK)
                InitConnection();
        }

        private void InitConnection()
        {
            string ConnectionInfo;
            if (MbViewer.InitConnection(out ConnectionInfo) != ConnectionType.NO_CONNECTION) {
                lbConnectionOptions.Text = ConnectionInfo;
                ToolButtonStart.Enabled = true;
            } else {
                ToolButtonStart.Enabled = false;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmModsMaster_Closing(object sender, CancelEventArgs e)
        {
            if (MbViewer.IsConnected())
                MbViewer.Close();
        }
    }
}
