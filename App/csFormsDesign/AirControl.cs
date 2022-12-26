using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace csFormsDesign
{
    class AirControl : Control
    {
        // make it transparent
        // https://stackoverflow.com/questions/40049506/in-c-sharp-winforms-is-there-a-way-to-put-dotted-border-around-all-controls-and

        const int WS_EX_TRANSPARENT = 0x20;

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
    }
}
