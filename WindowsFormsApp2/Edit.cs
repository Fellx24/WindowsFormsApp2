using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public static class Edit
    {
        static string origin;
        public static string Origin
        {
            get { return origin; }
            set { origin = value; }

        }
        internal static void getDateTime(RichTextBox textBox)
        {
            textBox.Text += DateTime.Now;
        }
        internal static bool isEqualToOrigin(string textToCompare)
        {
            if (textToCompare == Origin) return true;
            return false;
        }
    }
}
