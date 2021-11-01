using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NockLum.Models
{
    public class KeyInfo
    {
        public Keys KeyCode { get; set; }
        public string KeyString { get; set; } = string.Empty;

        public KeyInfo() { }

        public KeyInfo(Keys code, string key)
        {
            KeyCode = code;
            KeyString = key;
        }
    }
}
