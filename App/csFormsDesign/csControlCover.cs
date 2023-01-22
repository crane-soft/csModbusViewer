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
        private csSizeFrame SizeFrame;
        private Point MouseStart = new Point();
        private bool MousIsDown = false;
        private bool PaintSelectFrame;
        public Panel assignedControl { get; set; }

        public csControlCover(csControlDesigner designer, Panel control)
        {
            controlDesigner = designer;
            SizeFrame = controlDesigner.SizeFrame;
            assignedControl = control;
            this.Parent = control.Parent;
            this.Bounds = assignedControl.Bounds;
            this.BringToFront();
            this.Cursor = Cursors.SizeAll;
            this.MouseDown += Control_MouseDown;
            this.MouseUp += Control_MouseUp;
            this.MouseMove += Control_MouseMove;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gr = e.Graphics;
            if (PaintSelectFrame) {
                Rectangle borderRectangle = this.ClientRectangle;
                ControlPaint.DrawBorder(gr, borderRectangle, Color.Blue, ButtonBorderStyle.Solid);
                //borderRectangle = new Rectangle(ClientRectangle.Top , ClientRectangle.Left, 4, 4);
                //ControlPaint.DrawBorder(gr, borderRectangle, Color.Blue, ButtonBorderStyle.Solid);
            }
        }

        public void CoversSelect()
        {
            assignedControl.BringToFront();
            this.BringToFront();
        }

        public void Release()
        {
            SizeFrame.Visible = false;
            PaintSelectFrame = false;
            ReDrawAll();
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            SizeFrame.IsUsed = !assignedControl.AutoSize;
            SizeFrame.AdjustHandles(this);
            SizeFrame.Visible = false;

            PaintSelectFrame = true;
            MouseStart = e.Location;
            MousIsDown = true;
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            MousIsDown = false;
            SizeFrame.Visible = true;
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
            SizeFrame.IsUsed = ! assignedControl.AutoSize;
            SizeFrame.AdjustHandles(this);
        }
        private void ReDrawAll()
        {
            this.Visible = false;
            assignedControl.Refresh();
            this.Visible = true;
            this.Refresh();
            SizeFrame.ReDrawAllSizeHandles();
        }
    }
}
