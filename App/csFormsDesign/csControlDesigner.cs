using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using csModbusView;
namespace csFormsDesign
{

    /// <summary>
    /// Only the selected control is assigned to this instance of the designer
    /// </summary>
    class csControlDesigner
    {
        private List<csControlCover> ControlCoverList = new List<csControlCover>();
        private csControlCover selectedCover;
        private PropertyGrid properties;


        public csSizeFrame SizeFrame { get; private set; }
        public csDesignerContextMenu DesignContextMenu { get; set; }
        public csControlDesigner(PropertyGrid properties)
        {
            this.properties = properties;
            SizeFrame = new csSizeFrame();
            properties.PropertyValueChanged += Properties_PropertyValueChanged;
        }

        private void Properties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (selectedCover != null) {
                if (e.ChangedItem.Label == "DataType") {
                    // Refresh Properties regarding endianess or not
                    properties.SelectedObject = new mbViewProperties(selectedCover.assignedControl); 
                }
                selectedCover.PropertyChanged();
            }
        }

        public Control SelectedControl {
            get {
                if (selectedCover != null) {
                    return selectedCover.assignedControl;
                }
                return null;
            }
        }

        public void AddControl(Panel control, bool doSelct = false)
        {
            csControlCover controlCover = new csControlCover(this, control);
            controlCover.Tag = ControlCoverList.Count + 1;
            ControlCoverList.Add(controlCover);
            controlCover.MouseDown += ControlCover_MouseDown;
            controlCover.Resize += ControlCover_BoundsChanged;
            controlCover.Move += ControlCover_BoundsChanged;
            controlCover.KeyDown += ControlCover_KeyDown;
            if (doSelct)
                AssignCover(controlCover);
        }

        private void ControlCover_KeyDown(object sender, KeyEventArgs e)
        {
            DesignContextMenu?.KeyDownEvent(sender, e);
        }

        private void ControlCover_BoundsChanged(object sender, EventArgs e)
        {
            properties.Refresh();
        }

        public void CloseDesigner()
        {
            DeselecControl();
            foreach (csControlCover cover in ControlCoverList) {
                cover.Parent = null;
                cover.Dispose();
            }
            SizeFrame.Close();
         }

        private void ControlCover_MouseDown(object sender, MouseEventArgs e)
        {
            csControlCover clickedCover = (csControlCover)sender;
            AssignCover(clickedCover);

            if (e.Button == MouseButtons.Right) {
                DesignContextMenu?.ShowMenu(selectedCover,e);
            }
        }

        public void DeleteControl(csControlCover delCover)
        {
            DeselecControl();
            ControlCoverList.Remove(delCover);
            delCover.Dispose();
            delCover = null;
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
            if (cover != selectedCover) {
                DeselecControl();
            }
            selectedCover = cover;
            selectedCover.CoversSelect();
            //properties.SelectedObject =  clickedCover.assignedControl;  // nur wenn alle Properties angezeigt werden sollem
            properties.SelectedObject = new mbViewProperties(cover.assignedControl); // meine Auswahl
        }
    }
}
 
