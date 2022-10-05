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

        public MbViewPanel()
        {
            this.MouseClick += MbViewPanel_MouseClick;
        }

        private void MbViewPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (controldesigner != null) {
                controldesigner.DeselecControl();
            }
        }

        public List<ModbusView> DeserializeModbusViews(string jsonPath)
        {
            MbViewJson mbser = new MbViewJson(jsonPath);

            ModbusViewList = new List<ModbusView>();
            this.Controls.Clear();
            try {
                ModbusViewList = mbser.Deserialize();
                foreach (MasterGridView mbView in ModbusViewList) {
                    this.Controls.Add(mbView);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Deserialize");
            }
            return ModbusViewList;
        }

        public void SerializeModbusViews(string jsonPath)
        {
            MbViewProfile mbProfile = new MbViewProfile() {
                DeviceType = DeviceType.MASTER,
                ViewSize = new Size(this.Width, this.Height),
                ModbusViewList = ModbusViewList
            };

            MbViewJson mbser = new MbViewJson(jsonPath);
            try {
                mbser.Serialize(mbProfile);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Deserialize");
            }

        }

        public void EnableDesignMode(PropertyGrid properties)
        {
            controldesigner = new csControlDesigner(properties);
            foreach (ModbusView mbView in ModbusViewList) {
                mbView.setDesignMode(true);
                controldesigner.AddControl(mbView);
            }
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

