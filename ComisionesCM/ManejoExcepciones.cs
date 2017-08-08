using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComisionesCM
{
    public class ManejoExcepciones
    {
        public static void ShowException(string message, string value, string title)
        {
            Cursor.Current = Cursors.Default;
            MessageBox.Show(string.Format(message, value),
                title,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
