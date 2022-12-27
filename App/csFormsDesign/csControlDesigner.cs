using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace csFormsDesign
{

    /// <summary>
    /// Only the selected control is assigned to this instance of the designer
    /// </summary>
    class csControlDesigner
    {
        private List<csControlCover> ControlCoverList = new List<csControlCover>();
        private List<cSizeHandle> sizeHandleList = new List<cSizeHandle>();
        private csControlCover selectedCover;
        private PropertyGrid properties;

        private ContextMenu DesignContextMenu;
        private MenuItem NewControlMenu;
        private MenuItem DeleteControlMenu;
        private MenuItem ExitDesignMenu;
        private MouseEventArgs ContextMenuArgs;

        public delegate void ExitDesignDelegate();
        public event  ExitDesignDelegate ExitDesignModeEvent;

        //public delegate void DesignEventHandler (Control ClickedControl, MouseEventArgs e);
        public event MouseEventHandler DeleteControlEvent;
        public event MouseEventHandler NewControlEvent;

        public csControlDesigner(PropertyGrid properties)
        {
            this.properties = properties;
            sizeHandleList.Add(new cTopSizehandle());
            sizeHandleList.Add(new cBottomSizehandle());
            sizeHandleList.Add(new cLeftSizehandle());
            sizeHandleList.Add(new cRightSizehandle());
            sizeHandleList.Add(new cTopLefSizehandle());
            sizeHandleList.Add(new cTopRightSizehandle());
            sizeHandleList.Add(new cBottomLeftSizehandle());
            sizeHandleList.Add(new cBottomRightSizehandle());
            AllSizeHandleVisible = false;
            properties.PropertyValueChanged += Properties_PropertyValueChanged;
        }

        private void Properties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            selectedCover.UpdateBoundsFromControl();
            AdjustHandles();
        }

        public Control SelectedControl {
            get {
                if (selectedCover != null) {
                    return selectedCover.assignedControl;
                }
                return null;
            }
        }

        public void CreateContextMenu(string[] NewItemList)
        {
            DesignContextMenu = new ContextMenu();

            NewControlMenu = new MenuItem("New");
            for (int i = 0; i < NewItemList.Length; ++i) {
                NewControlMenu.MenuItems.Add(NewItemList[i]);
                NewControlMenu.MenuItems[i].Click += NewControlMenu_Click;
            }

            DeleteControlMenu = new MenuItem("Delete");
            ExitDesignMenu = new MenuItem("Exit design mode");


            DeleteControlMenu.Click += DeleteControlMenu_Click;
            ExitDesignMenu.Click += ExitDesignMenu_Click;
        }

        public void ShowContextMenu(object sender, MouseEventArgs e)
        {
            ContextMenuArgs = e;
            DesignContextMenu.MenuItems.Clear();
            DesignContextMenu.MenuItems.Add(NewControlMenu);

            if (sender.GetType() == typeof(csControlCover)) {
                DesignContextMenu.MenuItems.Add(DeleteControlMenu);
            }
            DesignContextMenu.MenuItems.Add("-");
            DesignContextMenu.MenuItems.Add(ExitDesignMenu);
            DesignContextMenu.Show((Control)sender, e.Location);
        }

        private void NewControlMenu_Click(object sender, EventArgs e)
        {
            DeselecControl();
            NewControlEvent?.Invoke(sender, ContextMenuArgs);
        }

        private void DeleteControlMenu_Click(object sender, EventArgs e)
        {
            if (selectedCover != null) {
                csControlCover delCover = selectedCover;
                Control assignedControl = delCover.assignedControl;
                DeselecControl();
                DeleteControlEvent?.Invoke(delCover.assignedControl, ContextMenuArgs);

                ControlCoverList.Remove(delCover);
                delCover.Dispose();
                delCover = null;
            }
        }

        private void ExitDesignMenu_Click(object sender, EventArgs e)
        {
            ExitDesignModeEvent?.Invoke();
        }

        public void AddControl(Control control, bool doSelct = false)
        {
            csControlCover controlCover = new csControlCover(this, control);
            controlCover.Tag = ControlCoverList.Count + 1;
            ControlCoverList.Add(controlCover);
            controlCover.MouseDown += ControlCover_MouseDown;
            controlCover.Resize += ControlCover_BoundsChanged;
            controlCover.Move += ControlCover_BoundsChanged;
            if (doSelct)
                AssignCover(controlCover);
        }

        private void ControlCover_BoundsChanged(object sender, EventArgs e)
        {
            properties.Refresh();
        }

        public void CloseDesigner()
        {
           if (selectedCover != null) {
                selectedCover.Release();
            }
            foreach (csControlCover cover in ControlCoverList) {
                cover.Parent = null;
                cover.Dispose();
            }
            foreach (cSizeHandle sizeHandle in sizeHandleList) {
                sizeHandle.Parent = null;
                sizeHandle.Dispose();
            }
        }

        private void ControlCover_MouseDown(object sender, MouseEventArgs e)
        {
            csControlCover clickedCover = (csControlCover)sender;
            AssignCover(clickedCover);

            if (e.Button == MouseButtons.Right) {
                ShowContextMenu(selectedCover,e);
            }
        }
  
        public void DeselecControl()
        {
            if (selectedCover != null) {
                selectedCover.Release();
                selectedCover = null;
                properties.SelectedObject = null;
            }
        }

        public void AssignCover(csControlCover cover)
        {
            if (cover == selectedCover)
                return;
            DeselecControl();
            selectedCover = cover;
            selectedCover.CoversSelect();
            AdjustHandles();
            AllSizeHandleVisible = true;
            //properties.SelectedObject =  clickedCover.assignedControl;  // nur wenn alle Properties angezeigt werden sollem
            properties.SelectedObject = new mbViewProperties(cover.assignedControl); // meine Auswahl
        }

        private void AdjustHandles()
        {
            foreach (cSizeHandle sizeHandle in sizeHandleList) {
                sizeHandle.Parent = selectedCover.Parent;
                sizeHandle.AssignControl(selectedCover);
            }
        }

        public bool AllSizeHandleVisible {
            set {
                foreach (cSizeHandle sizeHandle in sizeHandleList) {
                    sizeHandle.Visible = value;
                }
            }
        }
        public void ReDrawAllSizeHandles()
        {
            foreach (cSizeHandle sizeHandle in sizeHandleList) {
                sizeHandle.ReDraw();
            }
        }
    }
}
 
