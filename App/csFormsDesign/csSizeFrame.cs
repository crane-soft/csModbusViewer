
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csFormsDesign
{
    class csSizeFrame
    {
        private List<cSizeHandle> sizeHandleList = new List<cSizeHandle>();
        //private bool _IsUsed;
        private bool _Visible;
        public csSizeFrame()
        {
            sizeHandleList.Add(new cTopSizehandle());
            sizeHandleList.Add(new cBottomSizehandle());
            sizeHandleList.Add(new cLeftSizehandle());
            sizeHandleList.Add(new cRightSizehandle());
            sizeHandleList.Add(new cTopLefSizehandle());
            sizeHandleList.Add(new cTopRightSizehandle());
            sizeHandleList.Add(new cBottomLeftSizehandle());
            sizeHandleList.Add(new cBottomRightSizehandle());
            Visible = false;
        }

        public bool Visible
        {
            get {
                return _Visible;
            }
            set {
                _Visible = value;
               SetVisible();
            }
        }
        public void Close()
        {
            foreach (cSizeHandle sizeHandle in sizeHandleList) {
                sizeHandle.Parent = null;
                sizeHandle.Dispose();
            }
        }

        public void AdjustHandles(csControlCover selectedCover)
        {
            foreach (cSizeHandle sizeHandle in sizeHandleList) {
                sizeHandle.Parent = selectedCover.Parent;
                sizeHandle.AssignControl(selectedCover);
                sizeHandle.Visible = _Visible;
            }
        }

        public void ReDrawAllSizeHandles()
        {
            if (_Visible) {
                foreach (cSizeHandle sizeHandle in sizeHandleList) {
                    sizeHandle.ReDraw();
                    sizeHandle.Visible = _Visible;
                }
            }
        }

        private void SetVisible()
        {
            foreach (cSizeHandle sizeHandle in sizeHandleList) {
                sizeHandle.Visible = _Visible;
            }
        }
    }
}
