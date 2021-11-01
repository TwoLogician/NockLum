using NockLum.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NockLum
{
    public partial class AppForm : Form
    {
        // public const int WM_NCLBUTTONDOWN = 0xA1;
        // public const int HT_CAPTION = 0x2;

        private bool _numLock = false;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        GlobalKeyboardHook _keyboardHook = new GlobalKeyboardHook();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= 0x08000000;
                return param;
            }
        }

        public AppForm()
        {
            InitializeComponent();
            InitKeyboardHook();
            InitNumpad();
        }

        private void InitKeyboardHook()
        {
            _keyboardHook.HookedKeys.AddRange(Items.KeyItems.Select(x => x.KeyCode));
            _keyboardHook.KeyDown += new KeyEventHandler(KeyboardHook_KeyDown);
        }

        private void InitNumpad()
        {
            var info = typeof(SendKeys).GetField("keywords", BindingFlags.Static | BindingFlags.NonPublic);
            var oldKeys = (Array)info.GetValue(null);
            var elementType = oldKeys.GetType().GetElementType();
            var newKeys = Array.CreateInstance(elementType, oldKeys.Length + 10);
            Array.Copy(oldKeys, newKeys, oldKeys.Length);
            for (int i = 0; i < 10; i++)
            {
                var newItem = Activator.CreateInstance(elementType, "NUMPAD" + i, (int)Keys.NumPad0 + i);
                newKeys.SetValue(newItem, oldKeys.Length + i);
            }
            info.SetValue(null, newKeys);
        }

        void KeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_numLock)
            {
                return;
            }
            var key = Items.KeyItems.FirstOrDefault(x => x.KeyCode == e.KeyCode);
            if (key != null)
            {
                SendKeys.Send(key.KeyString);
                e.Handled = true;
            }
        }

        private void numLockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _numLock = !_numLock;
            numLockToolStripMenuItem.Checked = _numLock;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
