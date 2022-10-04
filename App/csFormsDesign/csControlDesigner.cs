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
        }

        public void AddControl(Control control)
        {
            csControlCover controlCover = new csControlCover(this, control);
            ControlCoverList.Add(controlCover);
            controlCover.Click += ControlCover_Click;
        }
        public void CloseDesigner()
        {
           if (selectedCover != null) {
                selectedCover.Release();
            }
            foreach (csControlCover cover in ControlCoverList) {
                cover.Visible = false;
                cover.Click -= ControlCover_Click;
            }
        }
        private void ControlCover_Click(object sender, EventArgs e)
        {
            csControlCover clickedCover = (csControlCover)sender;
            if (clickedCover != selectedCover) {
                DeselecControl();
                AssignCover(clickedCover);
                properties.SelectedObject =  clickedCover.assignedControl;
                //properties.SelectedObject = new CustomObjectWrapper(clickedCover.assignedControl);
            }
        }
        public void DeselecControl()
        {
            if (selectedCover != null) {
                selectedCover.Release();
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
 
