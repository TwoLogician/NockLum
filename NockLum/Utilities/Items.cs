using NockLum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NockLum.Utilities
{
    public class Items
    {
        public static List<KeyInfo> KeyItems = new List<KeyInfo>
        {
            new KeyInfo(Keys.D0, "{NUMPAD0}"),
            new KeyInfo(Keys.D1, "{NUMPAD1}"),
            new KeyInfo(Keys.D2, "{NUMPAD2}"),
            new KeyInfo(Keys.D3, "{NUMPAD3}"),
            new KeyInfo(Keys.D4, "{NUMPAD4}"),
            new KeyInfo(Keys.D5, "{NUMPAD5}"),
            new KeyInfo(Keys.D6, "{NUMPAD6}"),
            new KeyInfo(Keys.D7, "{NUMPAD7}"),
            new KeyInfo(Keys.D8, "{NUMPAD8}"),
            new KeyInfo(Keys.D9, "{NUMPAD9}"),
            new KeyInfo(Keys.OemMinus, "{SUBTRACT}"),
            new KeyInfo(Keys.OemPeriod, "{MULTIPLY}"),
            new KeyInfo(Keys.Oemplus, "{ADD}"),
            new KeyInfo(Keys.OemQuestion, "{DIVIDE}"),
        };
    }
}
