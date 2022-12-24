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
        private MenuItem NewMbViewMenu;
        private MenuItem DeleteMbViewMenu;
        private MenuItem ExitDesignModeMenu;

        public delegate void ExitDesignModeDelegate();
        public event ExitDesignModeDelegate ExitDesignModeEvent;

        public delegate void ControlCoverDelegate(csControlCover csCover);
        public event ControlCoverDelegate DeleteMbViewEvent;

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
            CreateDesignContextMenu();
            AllSizeHandleVisible = false;

        }

        private void CreateDesignContextMenu()
        {
            DesignContextMenu = new ContextMenu();

            NewMbViewMenu = new MenuItem("New");
            DeleteMbViewMenu = new MenuItem("Delete");
            ExitDesignModeMenu = new MenuItem("Exit design mode");

            NewMbViewMenu.Click += NewMbViewMenu_Click;
            DeleteMbViewMenu.Click += DeleteMbViewMenu_Click;
            ExitDesignModeMenu.Click += ExitDesignModeMenu_Click;
        }
        private void NewMbViewMenu_Click(object sender, EventArgs e)
        {
        }

        private void DeleteMbViewMenu_Click(object sender, EventArgs e)
        {
            if (selectedCover != null) {
                ControlCoverList.Remove(selectedCover);
                DeleteMbViewEvent?.Invoke(selectedCover);
                DeselecControl();
            }
        }

        private void ExitDesignModeMenu_Click(object sender, EventArgs e)
        {
            ExitDesignModeEvent?.Invoke();
        }

        public void AddControl(Control control)
        {
            csControlCover controlCover = new csControlCover(this, control);
            ControlCoverList.Add(controlCover);
            controlCover.MouseDown += ControlCover_MouseDown;
        }

        public void CloseDesigner()
        {
           if (selectedCover != null) {
                selectedCover.Release();
            }
            foreach (csControlCover cover in ControlCoverList) {
                cover.Visible = false;
                cover.MouseDown -= ControlCover_MouseDown;
            }
        }

        public void ShowContextMenu(object sender, MouseEventArgs e)
        {
            DesignContextMenu.MenuItems.Clear();
            DesignContextMenu.MenuItems.Add(NewMbViewMenu);
            if (sender.GetType() == typeof(csControlCover)) {
                DesignContextMenu.MenuItems.Add(DeleteMbViewMenu);
            }
            DesignContextMenu.MenuItems.Add("-");
            DesignContextMenu.MenuItems.Add(ExitDesignModeMenu);
            DesignContextMenu.Show((Control)sender, e.Location);
        }

        private void ControlCover_MouseDown(object sender, MouseEventArgs e)
        {
            csControlCover clickedCover = (csControlCover)sender;
            if (clickedCover != selectedCover) {
                DeselecControl();
                AssignCover(clickedCover);
                //properties.SelectedObject =  clickedCover.assignedControl;  // nur wenn alle Properties angezeigt werden sollem
                properties.SelectedObject = new mbViewProperties(clickedCover.assignedControl); // meine Auswahl
            }
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
            selectedCover = cover;
            selectedCover.CoversSelect();
            foreach (cSizeHandle sizeHandle in sizeHandleList) {
                sizeHandle.Parent = selectedCover.Parent;
                sizeHandle.AssignControl(selectedCover);
            }
            AllSizeHandleVisible = true;
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
 
