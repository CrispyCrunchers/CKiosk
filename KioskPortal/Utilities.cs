using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CC.Apps.CKiosk.Config;

namespace CC.Apps.CKiosk.Ui.Desktop
{
    public static class Utilities
    {
        public static void DisplayMessageBox(ref ApplicationConfig ApplicationConfig, string Title, string Message, string MessageDetails, MessageBoxButtons MessageBoxButtons, MessageBoxIcon MessageBoxIcon)
        {
            string _Message = Message;
            if (!string.IsNullOrEmpty(MessageDetails) && !ApplicationConfig.SuppressDetailedErrors)
            {
                _Message += "\r\n\r\nDetails:\r\n" + MessageDetails;
            }
            MessageBox.Show(_Message, Title, MessageBoxButtons, MessageBoxIcon);
        }
    }
}
