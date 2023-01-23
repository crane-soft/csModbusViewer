﻿using System;
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
        public event csDesignerContextMenu.Delegate ExitDesignModeEvent;

        private TreeView MbViewlSelectTree;
        private csContolDrop  ControlDrop;
      
        private csDesignerContextMenu DesignContextMenu;

        public MbViewDesignPanel()
        {
            ControlDrop = new csContolDrop(this);
            ControlDrop.ControlDropped += ControlDrop_ControlDropped;
            this.MouseClick += MbViewPanel_MouseClick;
        }

        public void InitSelectTree (TreeView selectTree)
        {
            MbViewlSelectTree = selectTree;
            MbViewlSelectTree.NodeMouseClick += AddControlTree_NodeMouseClick; ;
        }

        private void AddControlTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0) {
                MbViewlSelectTree.SelectedNode = null;
                FinishDrop();
                return;
            }
            MbViewlSelectTree.SelectedNode = e.Node;
            MbViewlSelectTree.Cursor = Cursors.Cross;
            Cursor = Cursors.Cross;
            ControlDrop.Activate(e.Node);
        }

        private void ControlDrop_ControlDropped(object sender, MouseEventArgs e)
        {
            if (sender != null) {
                TreeNode DropObject = (TreeNode)sender;
                New_MbViewControl(DropObject.Index, e.Location);
            }
            FinishDrop();
        }

        private void FinishDrop()
        {
            Cursor = Cursors.Default;
            MbViewlSelectTree.Cursor = Cursors.Default;
            MbViewlSelectTree.SelectedNode = null;
        }

        private void MbViewPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (controldesigner != null) {
                controldesigner.DeselecControl();
                if (e.Button == MouseButtons.Right) {
                    DesignContextMenu.ShowMenu(this, e);
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
            MbViewlSelectTree.ExpandAll();
            MbViewlSelectTree.SelectedNode = null;
            controldesigner = new csControlDesigner(properties);
            CreateContextMenu();

            foreach (ModbusView mbView in ModbusViewList) {
                mbView.setDesignMode(true);
                controldesigner.AddControl(mbView);
            }
        }

        private void CreateContextMenu()
        {
            string[] NewItemList = { "Holding Register", "Input Registser", "Coils", "Discret Inputs" };
            DesignContextMenu = new csDesignerContextMenu(NewItemList);
            DesignContextMenu.NewControlEvent += DesignContextMenu_NewControlEvent;
            DesignContextMenu.DeleteControlEvent += DesignContextMenu_DeleteControlEvent;
            DesignContextMenu.ExitDesignModeEvent += DesignContextMenu_ExitDesignModeEvent; ;
            controldesigner.DesignContextMenu = DesignContextMenu;
        }

        private void DesignContextMenu_NewControlEvent(object sender, MouseEventArgs e)
        {
            controldesigner.DeselecControl();
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

        private void DesignContextMenu_DeleteControlEvent(object sender, MouseEventArgs e)
        {
            if (sender != null) {
                csControlCover delCover = (csControlCover)sender;
                ModbusView mbView = (ModbusView)delCover.assignedControl; 
                ModbusViewList.Remove(mbView);
                this.Controls.Remove(mbView);
                mbView.Dispose();
                controldesigner.DeleteControl(delCover);
            }
        }

        private void DesignContextMenu_ExitDesignModeEvent()
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

