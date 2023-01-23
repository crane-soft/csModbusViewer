using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csFormsDesign 
{
    class csDesignerContextMenu : ContextMenu
    {
        private MenuItem NewControlMenu;
        private MenuItem DeleteControlMenu;
        private MenuItem ExitDesignMenu;

        private MouseEventArgs ContextMenuArgs;
        private object ContextMenuSender;

        public delegate void Delegate();
        public event Delegate ExitDesignModeEvent;
        public event MouseEventHandler DeleteControlEvent;
        public event MouseEventHandler NewControlEvent;

        public csDesignerContextMenu(string[] NewItemList)
        {
            NewControlMenu = new MenuItem("New");
            for (int i = 0; i < NewItemList.Length; ++i) {
                NewControlMenu.MenuItems.Add(NewItemList[i]);
                NewControlMenu.MenuItems[i].Click += NewControlMenu_Click; ;
            }

            DeleteControlMenu = new MenuItem("Delete");
            DeleteControlMenu.Shortcut = Shortcut.Del;
            DeleteControlMenu.ShowShortcut = true;
            ExitDesignMenu = new MenuItem("Exit design mode");
            DeleteControlMenu.Click += DeleteControlMenu_Click;
            ExitDesignMenu.Click += ExitDesignMenu_Click;
        }

        public void ShowMenu(object sender, MouseEventArgs e)
        {
            ContextMenuSender = sender;
            ContextMenuArgs = e;
            MenuItems.Clear();
            MenuItems.Add(NewControlMenu);

            if (sender.GetType() == typeof(csControlCover)) {
                MenuItems.Add(DeleteControlMenu);
                csControlCover cc = (csControlCover)sender;
                ContextMenuArgs = new MouseEventArgs(e.Button, e.Clicks, e.X+ cc.Left, e.Y + cc.Top,e.Delta);
            }
            MenuItems.Add("-");
            MenuItems.Add(ExitDesignMenu);
            Show((Control)sender, e.Location);
        }

        public void KeyDownEvent(object sender, KeyEventArgs e)
        {
            ContextMenuSender = sender;
            if (sender.GetType() == typeof(csControlCover)) {
                var DelShortcut = (Keys)DeleteControlMenu.Shortcut;
                if (e.KeyData == DelShortcut) {
                    DeleteControlMenu_Click(null, EventArgs.Empty);
                }
            }
        }
        private void NewControlMenu_Click(object sender, EventArgs e)
        {
            NewControlEvent?.Invoke(sender, ContextMenuArgs);
        }

        private void DeleteControlMenu_Click(object sender, EventArgs e)
        {
            DeleteControlEvent?.Invoke(ContextMenuSender, ContextMenuArgs);
        }
        private void ExitDesignMenu_Click(object sender, EventArgs e)
        {
            ExitDesignModeEvent?.Invoke();
        }
    }
}
