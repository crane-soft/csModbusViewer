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
using csFormsDesign;


namespace csModbusViewer
{
    class MbViewDesignPanel : Panel
    {
        protected List<ModbusView> ModbusViewList;
        private csControlDesigner controldesigner;
        public event csControlDesigner.ExitDesignDelegate ExitDesignModeEvent;

        private TreeView MbControlSelect;
        private ToolTip ViewAddTip = new ToolTip();
        private TreeNode ViewAddNode;
        private AirControl CtrlPlacer = new AirControl();

        public MbViewDesignPanel()
        {
            this.MouseClick += MbViewPanel_MouseClick;

            CtrlPlacer.MouseMove += CtrlPlacer_MouseMove;
            CtrlPlacer.MouseLeave += CtrlPlacer_MouseLeave;
            CtrlPlacer.MouseDown += CtrlPlacer_MouseDown;
        }

        public void SetMbControlSelect (TreeView selectTree)
        {
            MbControlSelect = selectTree;
            MbControlSelect.NodeMouseClick += AddControlTree_NodeMouseClick; ;
        }

        private void AddControlTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MbControlSelect.SelectedNode = e.Node;
            MbControlSelect.Cursor = Cursors.Cross;
            Cursor = Cursors.Cross;
            ViewAddTip.ShowAlways = true;
            ViewAddNode = e.Node;

            CtrlPlacer.Size = this.Size;
            CtrlPlacer.Parent = this;
            CtrlPlacer.BringToFront();
        }

        private void CtrlPlacer_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            MbControlSelect.Cursor = Cursors.Default;
            MbControlSelect.SelectedNode = null;
            ViewAddTip.Hide(this);
            CtrlPlacer.Parent = null;

            if ((e.Button == MouseButtons.Left) && (ViewAddNode != null)) {
                New_MbViewControl(ViewAddNode.Index, e.Location);
            }
            ViewAddNode = null;
        }

        private void CtrlPlacer_MouseMove(object sender, MouseEventArgs e)
        {
            if (ViewAddNode != null) {
                ViewAddTip.Show(ViewAddNode.Text, this, e.X + 2, e.Y + 2);
            }
        }

        private void CtrlPlacer_MouseLeave(object sender, EventArgs e)
        {
            ViewAddTip.Hide(this);
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

        public void InitModbusViewList(List<ModbusView> ModbusViewList)
        {
            this.Controls.Clear();
            foreach (ModbusView mbView in ModbusViewList) {
                this.Controls.Add(mbView);
            }
            this.ModbusViewList = ModbusViewList;
        }


        public void EnableDesignMode(PropertyGrid properties)
        {
            MbControlSelect.ExpandAll();
            MbControlSelect.SelectedNode = null;
            properties.PropertyValueChanged += Properties_PropertyValueChanged;
            string[] NewItemList = {"Holding Register","Input Registser","Coils","Discret Inputs"};
            controldesigner = new csControlDesigner(properties);
            controldesigner.CreateContextMenu(NewItemList);
            foreach (ModbusView mbView in ModbusViewList) {
                mbView.setDesignMode(true);
                controldesigner.AddControl(mbView);
            }
            controldesigner.ExitDesignModeEvent += Controldesigner_ExitDesignModeEvent;
            controldesigner.DeleteControlEvent += Controldesigner_DeleteControlEvent;
            controldesigner.NewControlEvent += Controldesigner_NewControlEvent;

        }

        private void Properties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            ModbusView SelectedControl = (ModbusView)controldesigner.SelectedControl;
            if (SelectedControl != null) {
                SelectedControl.AdjustSize();
            }
        }

        private void Controldesigner_NewControlEvent(object sender, MouseEventArgs e)
        {
            MenuItem SubMenu = (MenuItem)sender;
            New_MbViewControl(SubMenu.Index, e.Location);
        }

        private void New_MbViewControl(int ControlIdx, Point Location)
        {
            ModbusView NewModbusView = null;
            switch (ControlIdx) {
                case 0:
                    NewModbusView = new MasterHoldingRegsGridView();
                    break;
                case 1:
                    NewModbusView = new MasterInputRegsGridView();
                    break;
                case 2:
                    NewModbusView = new MasterCoilsGridView();
                    break;
                case 3:
                    NewModbusView = new MasterDiscretInputsGridView();
                    break;
                default:
                    return;
            }
            NewModbusView.Location = Location;
            NewModbusView.setDesignMode(true);

            Controls.Add(NewModbusView);
            ModbusViewList.Add(NewModbusView);
            controldesigner.AddControl(NewModbusView, true);

        }

        private void Controldesigner_DeleteControlEvent(object sender, MouseEventArgs e)
        {
            ModbusView mbView = (ModbusView)sender;
            ModbusViewList.Remove(mbView);
            this.Controls.Remove(mbView);
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

