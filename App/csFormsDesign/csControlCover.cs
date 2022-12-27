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
    /// Each Control which should be designed needs a DesignCover for selecton and manage mouse events
    /// </summary>

    class csControlCover : AirControl
    {
        private csControlDesigner controlDesigner;
        private Point MouseStart = new Point();
        private bool MousIsDown = false;
        public Control assignedControl { get; set; }

        public csControlCover(csControlDesigner designer, Control control)
        {
            controlDesigner = designer;
            assignedControl = control;
            this.Parent = control.Parent;
            this.Bounds = assignedControl.Bounds;
            this.BringToFront();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gr = e.Graphics;
            if (MousIsDown) {
                Rectangle borderRectangle = this.ClientRectangle;
                ControlPaint.DrawBorder(gr, borderRectangle, Color.Blue, ButtonBorderStyle.Solid);
            }
        }

        public void CoversSelect()
        {
            this.Cursor = Cursors.SizeAll;
            assignedControl.BringToFront();
            this.BringToFront();

            this.MouseDown += Control_MouseDown;
            this.MouseUp += Control_MouseUp;
            this.MouseMove += Control_MouseMove;
        }

        public void Release()
        {
            controlDesigner.AllSizeHandleVisible = false;
            this.MouseDown -= Control_MouseDown;
            this.MouseUp -= Control_MouseUp;
            this.MouseMove -= Control_MouseMove;

        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            controlDesigner.AllSizeHandleVisible = false;
            MouseStart = e.Location;
            MousIsDown = true;
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            MousIsDown = false;
            ReDrawAll();

        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (MousIsDown) {
                Point OffsetPos = new Point(e.Location.X - MouseStart.X, e.Location.Y - MouseStart.Y);
                Point newLocation = LimitBounds(new Point(this.Location.X + OffsetPos.X, this.Location.Y + OffsetPos.Y));
                           
                this.Location = newLocation;
                assignedControl.Location = newLocation;
                assignedControl.Refresh();
                this.Refresh();
            }
        }

        public Point LimitBounds (Point  Loaction)
        {
            Loaction.X = CheckBounds(Loaction.X, 0, this.Parent.Width - 5);
            Loaction.Y = CheckBounds(Loaction.Y, 0, this.Parent.Height - 5);
            return Loaction;
        }

        public int CheckBounds(int value, int Minimum, int Maximum)
        {
            if (value < Minimum)
                return Minimum;
            if (value > Maximum)
                return Maximum;
            return value;
        }

        public void UpdateBounds(Rectangle newBounds)
        {
            this.Bounds = newBounds;
            assignedControl.Bounds = newBounds;
            ReDrawAll();
        }

        public void UpdateBoundsFromControl()
        {
            UpdateBounds(assignedControl.Bounds);
        }
    
        private void ReDrawAll()
        {
            assignedControl.Refresh();
            this.Refresh();
            controlDesigner.ReDrawAllSizeHandles();
        }
    }
}
