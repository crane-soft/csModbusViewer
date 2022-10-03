using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace csFormsDesign
{
    class cSizeHandle : Label
    {
        protected const int handleSize = 7;
        protected const int handleCenter = 3;
        protected const int MinBounds = 7;
        protected Rectangle handleRect;
        protected bool hasDottedLine;
        protected Point dLineP1;
        protected Point dLineP2;

        protected csControlCover assignedCover;
        protected Rectangle controlBounds;
        private Point MouseStart = new Point();
        private bool MousIsDown = false;

        public cSizeHandle(Cursor cursor)
        {
            this.Cursor = cursor;
            this.Height = handleSize;
            this.Width = handleSize;
            this.Visible = false;
            this.BorderStyle = BorderStyle.None;
            hasDottedLine = false;
            handleRect = new Rectangle(0, 0, handleSize - 1, handleSize - 1);

            this.MouseDown += CSizeHandle_MouseDown;
            this.MouseUp += CSizeHandle_MouseUp;
            this.MouseMove += CSizeHandle_MouseMove;
        }

        private void CSizeHandle_MouseDown(object sender, MouseEventArgs e)
        {
            MouseStart = e.Location;
            MousIsDown = true;
        }
        private void CSizeHandle_MouseUp(object sender, MouseEventArgs e)
        {
            MousIsDown = false;
        }
        private void CSizeHandle_MouseMove(object sender, MouseEventArgs e)
        {
            if (MousIsDown) {
                Point OffsetPos = new Point(e.Location.X - MouseStart.X, e.Location.Y - MouseStart.Y);
                if ((OffsetPos.X != 0) || (OffsetPos.Y != 0)) {
                    Point newLocation = assignedCover.LimitBounds (new Point(Location.X + OffsetPos.X, Location.Y + OffsetPos.Y));
                   
                    controlBounds = assignedCover.Bounds;
                    CSizeHandle_Move(newLocation);
                    assignedCover.UpdateBounds(controlBounds);
                }
            }
        }
        protected virtual void CSizeHandle_Move(Point newLocation)
        {
        }

        public void AssignControl(csControlCover cover)
        {
            assignedCover = cover;
            ReDraw();
        }

        public void ReDraw()
        {
            InitDraw();
            this.BringToFront();
            this.Visible = true;
            this.Refresh();
        }

        public virtual void InitDraw() { }

        protected void SetHorizontalSize()
        {
            if (assignedCover != null) {
                this.Height = handleSize;
                this.Width = assignedCover.Width;
                handleRect = new Rectangle(this.Width / 2 - handleCenter, 0, handleSize - 1, handleSize - 1);
                dLineP1 = new Point(0, handleCenter);
                dLineP2 = new Point(this.Width, handleCenter);
                hasDottedLine = true;
            }
        }

        protected void SetVerticalSize()
        {
            if (assignedCover != null) {
                this.Height = assignedCover.Height;
                this.Width = handleSize;
                handleRect = new Rectangle(0, this.Height / 2 - handleCenter, handleSize - 1, handleSize - 1);
                dLineP1 = new Point(handleCenter, 0);
                dLineP2 = new Point(handleCenter, this.Height);
                hasDottedLine = true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gr = e.Graphics;
            if (hasDottedLine) {
                Pen dottedLinePen = new Pen(Color.Black);
                dottedLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                gr.DrawLine(dottedLinePen, dLineP1, dLineP2);
            }

            if (handleRect != null)
                gr.DrawRectangle(Pens.Black, handleRect);
        }

        protected void MoveLeftBound(Point newLocation)
        {
            int newLeft = newLocation.X + this.Width;
            controlBounds.Width -= (newLeft - controlBounds.X);
            controlBounds.X = newLeft;
        }

        protected void MoveRightBound(Point newLocation)
        {
            controlBounds.Width = newLocation.X - controlBounds.X;
            if (controlBounds.Width < MinBounds)
                controlBounds.Width = MinBounds;
        }

        protected void MoveTopBound(Point newLocation)
        {
            int newTop = newLocation.Y + this.Height;
            controlBounds.Height -= (newTop - controlBounds.Y);
            controlBounds.Y = newTop;
        }

        protected void MoveBottomBound(Point newLocation)
        {
            controlBounds.Height = newLocation.Y - controlBounds.Y;
            if (controlBounds.Height < MinBounds)
                controlBounds.Height = MinBounds;
        }
    }

    class cTopSizehandle : cSizeHandle
    {
        public cTopSizehandle() : base(Cursors.SizeNS) { }
        public override void InitDraw()
        {
            this.Top = assignedCover.Top - handleSize;
            this.Left = assignedCover.Left;
            this.SetHorizontalSize();
        }
        protected override void CSizeHandle_Move(Point newLocation)
        {
            MoveTopBound(newLocation);
         }
    }

    class cBottomSizehandle : cSizeHandle
    {
        public cBottomSizehandle() : base(Cursors.SizeNS) { }
        public override void InitDraw()
        {
            this.Top = assignedCover.Top + assignedCover.Height;
            this.Left = assignedCover.Left;
            this.SetHorizontalSize();
        }
        protected override void CSizeHandle_Move(Point newLocation)
        {
            MoveBottomBound(newLocation);
        }
    }

    class cLeftSizehandle : cSizeHandle
    {
        public cLeftSizehandle() : base(Cursors.SizeWE) { }
        public override void InitDraw()
        {
            this.Top = assignedCover.Top;
            this.Left = assignedCover.Left - handleSize; ;
            SetVerticalSize();
        }
        protected override void CSizeHandle_Move(Point newLocation)
        {
            MoveLeftBound(newLocation);
        }
    }

    class cRightSizehandle : cSizeHandle
    {
        public cRightSizehandle() : base(Cursors.SizeWE) { }
        public override void InitDraw()
        {
            this.Top = assignedCover.Top;
            this.Left = assignedCover.Left + assignedCover.Width; ;
            SetVerticalSize();
        }
        protected override void CSizeHandle_Move(Point newLocation)
        {
            MoveRightBound(newLocation);
        }
    }

    class cTopLefSizehandle : cSizeHandle
    {
        public cTopLefSizehandle() : base(Cursors.SizeNWSE) { }
        public override void InitDraw()
        {
            this.Top = assignedCover.Top - handleSize;
            this.Left = assignedCover.Left - handleSize;
        }
        protected override void CSizeHandle_Move(Point newLocation)
        {
            MoveTopBound(newLocation);
            MoveLeftBound(newLocation);
        }
    }

    class cTopRightSizehandle : cSizeHandle
    {
        public cTopRightSizehandle() : base(Cursors.SizeNESW) { }
        public override void InitDraw()
        {
            this.Top = assignedCover.Top - handleSize;
            this.Left = assignedCover.Left + assignedCover.Width;
        }
        protected override void CSizeHandle_Move(Point newLocation)
        {
            MoveTopBound(newLocation);
            MoveRightBound(newLocation);
        }
    }

    class cBottomLeftSizehandle : cSizeHandle
    {
        public cBottomLeftSizehandle() : base(Cursors.SizeNESW) { }
        public override void InitDraw()
        {
            this.Top = assignedCover.Top + assignedCover.Height;
            this.Left = assignedCover.Left - handleSize;
        }
        protected override void CSizeHandle_Move(Point newLocation)
        {
            MoveBottomBound(newLocation);
            MoveLeftBound(newLocation);
        }
    }
    class cBottomRightSizehandle : cSizeHandle
    {
        public cBottomRightSizehandle() : base(Cursors.SizeNWSE) { }
        public override void InitDraw()
        {
            this.Top = assignedCover.Top + assignedCover.Height;
            this.Left = assignedCover.Left + assignedCover.Width;
        }
        protected override void CSizeHandle_Move(Point newLocation)
        {
            MoveBottomBound(newLocation);
            MoveRightBound(newLocation);
         }
    }

}
