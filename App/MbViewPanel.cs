using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csModbusLib;
using csModbusView;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//using System.Windows.Forms.Design;
using csFormsDesign;

namespace csModbusViewer
{
    class MbViewPanel : Panel
    {
        private List<ModbusView> ModbusViewList;
        private csControlDesigner controldesigner;
        public event csControlDesigner.ExitDesignModeDelegate ExitDesignModeEvent;

        public MbViewPanel()
        {
            this.MouseClick += MbViewPanel_MouseClick;
        }

        private void MbViewPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (controldesigner != null) {
                controldesigner.DeselecControl();
                if (e.Button == MouseButtons.Right) {
                    controldesigner.ShowContextMenu(this, e);
                }
            }
        }

        public List<ModbusView> DeserializeModbusViews(string jsonPath)
        {
            MbViewJson mbser = new MbViewJson(jsonPath);

            MbViewProfile mbProfile = null;
            try {
                mbProfile = mbser.Deserialize();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "DeserializeModbusViews");
            }
            if (mbProfile != null) {
                this.Size = mbProfile.ViewSize;
                // TODO Size cannoz be set here must be done in Splitpanel
                this.Controls.Clear();
                foreach (MasterGridView mbView in mbProfile.ModbusViewList) {
                    this.Controls.Add(mbView);
                }
                this.ModbusViewList = mbProfile.ModbusViewList;
                return mbProfile.ModbusViewList;
            }
            return null;
        }

        public bool SerializeModbusViews(string jsonPath)
        {
            if (ModbusViewList == null)
                return false;

            try {
                MbViewProfile mbProfile = new MbViewProfile() {
                    DeviceType = DeviceType.MASTER.ToString(),
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

        public void EnableDesignMode(PropertyGrid properties)
        {
            controldesigner = new csControlDesigner(properties);
            foreach (ModbusView mbView in ModbusViewList) {
                mbView.setDesignMode(true);
                controldesigner.AddControl(mbView);
            }
            controldesigner.ExitDesignModeEvent += Controldesigner_ExitDesignModeEvent;
            controldesigner.DeleteMbViewEvent += Controldesigner_DeleteMbViewEvent;
        }

        private void Controldesigner_DeleteMbViewEvent(csControlCover csCover)
        {
            ModbusView mbView = (ModbusView)csCover.assignedControl;
            ModbusViewList.Remove(mbView);
            mbView.Dispose();
        }

        private void Controldesigner_ExitDesignModeEvent()
        {
            ExitDesignModeEvent?.Invoke();
        }

        public void CloseDesignMode()
        {
            controldesigner.CloseDesigner();
            controldesigner = null;
            foreach (ModbusView mbView in ModbusViewList) {
                mbView.setDesignMode(false);
            }
        }
    }
}

