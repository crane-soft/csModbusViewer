using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csFormsDesign
{
    class csContolDrop : AirControl
    {
        public event MouseEventHandler ControlDropped;

        private Control ParentControl;
        private TreeNode _DropNode;
        private ToolTip DropNodeTip = new ToolTip();

        public csContolDrop(Control Parent)
        {
            ParentControl = Parent;
            this.MouseMove += CtrlDropper_MouseMove;
            this.MouseLeave += CtrlDropper_MouseLeave;
            this.MouseDown += CtrlDropper_MouseDown;

        }

        public void Activate(TreeNode DropNode)
        {
            _DropNode = DropNode;
            this.Parent = ParentControl;
            this.Size = Parent.Size;
            this.Visible = true;

            this.BringToFront();
            DropNodeTip.ShowAlways = true;

        }

        public void Close()
        {
            DropNodeTip.Hide(this);
            Parent = null;
            Visible = false;
            _DropNode = null;

        }
        private void CtrlDropper_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (_DropNode != null)) {
                ControlDropped?.Invoke(_DropNode,e);
            }
            Close();
        }

        private void CtrlDropper_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_DropNode != null) {
                DropNodeTip.Show(_DropNode.Text, this, e.X + 2, e.Y + 2);
            }
        }

        private void CtrlDropper_MouseLeave(object sender, EventArgs e)
        {
            DropNodeTip.Hide(this);

        }

    }
}
