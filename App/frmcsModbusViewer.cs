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
        private DeviceType ViewerType = DeviceType.NO_TYPE;
        private ConnectionType InterfaceType = ConnectionType.NO_CONNECTION;

        private int RefreshCount = 0;
        private int ErrorCount = 0;
        private bool Running = false;
        private ViewerBase ModbusViewer;
        private string FormTitle;
        public frmcsModbusViewer()
        {
            InitializeComponent();
            FormTitle = this.Text;

            mainSplitContainer.Panel2Collapsed = true;

            this.saveToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Enabled = false;

            this.Load += csModsMaster_Load;
            this.FormClosing += frmModsMaster_Closing;


            this.SettingsToolStripMenuItem.Click += ConnectionSettings;

            this.openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            this.newToolStripMenuItem.Click += NewToolStripMenuItem_Click;
            this.closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            this.saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            this.saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            this.ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            this.designerToolStripMenuItem.CheckedChanged += DesignerToolStripMenuItem_CheckedChanged;
            this.ToolButtonStart.Click += cmStart_Click;
            this.ToolButtonStop.Click += cmStop_Click;
            this.ToolButtonConnection.Click += ConnectionSettings;

            EnableCommands(false);

            MbViewPanel.InitSelectTree(MbViewTree);
            MbViewPanel.ExitDesignModeEvent += ViewPanel_ExitDesignModeEvent;

            StatusErrorCount.Text = "";
            lbDeviceType.Text = "";
            ToolButtonStop.Enabled = false;
        }

        private void EnableCommands(bool enable)
        {
            this.closeToolStripMenuItem.Enabled = enable;
            this.designerToolStripMenuItem.Enabled = enable;
            this.ToolButtonStart.Enabled = enable;
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ViewerIsOpen()) {
                if (MessageBox.Show("Close Current Profile", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
                CloseToolStripMenuItem_Click(null, EventArgs.Empty);
            }
            this.Text = "New - " + FormTitle;

            dlgNewProfile dlgNew = new dlgNewProfile();
            if (dlgNew.ShowDialog() == DialogResult.Cancel)
                return;
            CreateViewer(dlgNew.ViewerType.ToString(), dlgNew.ModbusViewList);
            designerToolStripMenuItem.Checked = true;   // Start designer
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ViewerIsOpen() == false)
                return;
            ModbusStop();
            ModbusViewer.Close();
            ModbusViewer = null;
            lbDeviceType.Text = "";
            Settings.Default.JsonPath = "";
            Settings.Default.Save();
            this.Text = FormTitle;
            EnableCommands(false);

        }
  
        private void csModsMaster_Load(object sender, EventArgs e)
        {
            string JsonPath = Settings.Default.JsonPath;
            if (JsonPath.Length > 0)
                LoadModbusProfile (JsonPath);
        }

        private bool LoadModbusProfile(string JsonPath)
        {
            MbViewJson mbser = new MbViewJson(JsonPath);
            MbViewProfile mbProfile = null;
            try {
                mbProfile = mbser.Deserialize();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "DeserializeModbusViews");
                return false;
            }
            this.Text = System.IO.Path.GetFileNameWithoutExtension(JsonPath) + " - " + FormTitle;
            this.Size = mbProfile.ViewSize;

            CreateViewer(mbProfile.DeviceType, mbProfile.ModbusViewList);
            return true;
        }

        private void CreateViewer(string TypeName, List<ModbusView> ModbusViewList)
        {
            if (TypeName == DeviceType.MASTER.ToString()) {
                ViewerType = DeviceType.MASTER;
                lbDeviceType.Text = "Modbus Master";
                ModbusViewer = new MasterViewer();
            } else if (TypeName == DeviceType.SLAVE.ToString()) {
                ViewerType = DeviceType.SLAVE;
                lbDeviceType.Text = "Modbus Slave";
                ModbusViewer = new SlaveViewer();
            }
            OpenModbusViewer(ModbusViewList);
        }

        private void OpenModbusViewer(List<ModbusView> ModbusViewList)
        {
            MbViewPanel.InitModbusViewList(ModbusViewList);
            ModbusViewer.ModbusViewList = ModbusViewList;
            ModbusViewer.ErrorCodeEvent += Invoke_DisplayErrorCode;
            InitConnection();

            this.saveToolStripMenuItem.Enabled = true;
            this.saveAsToolStripMenuItem.Enabled = true;
            EnableCommands(true);
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
                if (LoadModbusProfile(JsonPath) == true) {
                    Settings.Default.JsonFolder = System.IO.Path.GetDirectoryName(JsonPath);
                    Settings.Default.JsonPath = JsonPath;
                    Settings.Default.Save();
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ViewerIsOpen() == false)
                return;

            string JsonPath = Settings.Default.JsonPath;
            if (JsonPath != null) {
                if (JsonPath.Length > 0 ) {
                    SerializeModbusProfile(JsonPath);
                }
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ViewerIsOpen() == false)
                return;

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
                SerializeModbusProfile(JsonPath);
            }
        }

        private bool SerializeModbusProfile(string jsonPath)
        {
            List<ModbusView> ModbusViewList = ModbusViewer.ModbusViewList;
            if (ModbusViewList == null)
                return false;

            try {
                MbViewProfile mbProfile = new MbViewProfile() {
                    DeviceType =  ViewerType.ToString(),
                    ViewSize = this.Size,
                    ModbusViewList = ModbusViewList
                };

                MbViewJson mbser = new MbViewJson(jsonPath);
                mbser.Serialize(mbProfile);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "SerializeModbusViews");
                return false;
            }
            return true;
        }

        private bool ViewerIsOpen()
        {
            if (ModbusViewer == null)
                return false;
            if (designerToolStripMenuItem.Checked) {
                designerToolStripMenuItem.Checked = false;
            }
            return true;
        }

        private void ViewPanel_ExitDesignModeEvent()
        {
            designerToolStripMenuItem.Checked = false;
        }

        private void DesignerToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (designerToolStripMenuItem.Checked) {
                if (Running)
                    ModbusStop();
                lbLastError.Text = "Design Mode";
                mainSplitContainer.Panel2Collapsed = false;
                MbViewPanel.EnableDesignMode(ViewerType, MbViewPropertyGrid);
                openToolStripMenuItem.Enabled = false;
                newToolStripMenuItem.Enabled = false;
                ToolButtonStart.Enabled = false;

            } else {
                MbViewPanel.CloseDesignMode();
                mainSplitContainer.Panel2Collapsed = true;
                lbLastError.Text = "";
                openToolStripMenuItem.Enabled = true;
                newToolStripMenuItem.Enabled = true;
                ToolButtonStart.Enabled = true;

            }
            Cursor = Cursors.Default;
        }

        private void cmStart_Click(object sender, EventArgs e)
        {
            if (Running == false)
            {
                if (ModbusConnect())
                {
                    SettingsToolStripMenuItem.Enabled = false;
                    Running = true;
                    if (ViewerType == DeviceType.SLAVE) {
                        lbLastError.Text = "Listening";
                    } else {
                        lbLastError.Text = "Connected";
                    }
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
            if (ModbusViewer.IsConnected())
                return true;
            lbLastError.Text = "Connecting..";
            this.Update();
            return ModbusViewer.Connect();
        }

        private void cmStop_Click(object sender, EventArgs e)
        {
            ModbusStop();
        }

        private void ModbusStop()
        {
            if (Running) {
                ModbusViewer.CloseConnection();
                Running = false;
                StatusLabelCount.Text = "";
                RefreshCount = 0;
                SettingsToolStripMenuItem.Enabled = true;
                ErrorCount = 0;
                lbLastError.Text = "";
                StatusErrorCount.Text = "";
                LbLastModbusException.Text = "";
                ToolButtonStart.Enabled = true;
                ToolButtonStop.Enabled = false;
                openToolStripMenuItem.Enabled = true;
            }
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
                    ExceptionCodes ModbusException = ModbusViewer.GetModusException();
                    LbLastModbusException.Text = ModbusException.ToString();
                }
                else
                    LbLastModbusException.Text = "";

                if (InterfaceType == ConnectionType.TCP_IP)
                {
                    if ((ErrCode == csModbusLib.ErrorCodes.CONNECTION_ERROR) | (ErrCode == csModbusLib.ErrorCodes.CONNECTION_CLOSED))
                        ModbusStop();
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
            if (ModbusViewer == null)
                return;
            if (ModbusViewer.InitConnection() != ConnectionType.NO_CONNECTION) {
                lbConnectionOptions.Text = ModbusViewer.ConnectionInfo;
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
            if (ModbusViewer != null) {
                if (ModbusViewer.IsConnected())
                    ModbusViewer.CloseConnection();
            }
        }
    }
}
