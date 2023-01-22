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

namespace csModbusViewer
{
    public partial class dlgNewProfile : Form
    {
        public DeviceType ViewerType { get; private set; }
        public bool GenerateTemplate { get; private set; }
        public List<ModbusView> ModbusViewList { get; private set; }

    public dlgNewProfile()
        {
            InitializeComponent();
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
            rbMaster.Checked = true;
            okButton.Select();
            //okButton.Focus();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
            
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (rbMaster.Checked) {
                ViewerType = DeviceType.MASTER;
            } else {
                ViewerType = DeviceType.SLAVE;
            }
            GenerateTemplate = cbTemplate.Checked;
            CreateModbusViewList();
            this.DialogResult = DialogResult.OK;
        }

        private void CreateModbusViewList() 
        {
            ModbusViewList = new List<ModbusView>();
            if (GenerateTemplate) {
                ModbusView TemplateView;
                if (ViewerType == DeviceType.MASTER) {
                    TemplateView = new MasterHoldingRegsGridView(10, 8); ;
                } else {
                    TemplateView = new SlaveHoldingRegsGridView(10, 8); ;
                }
                TemplateView.Location = new Point(60, 30);
                ModbusViewList.Add(TemplateView);
            }
        }
    }
}
