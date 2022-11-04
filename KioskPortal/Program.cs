using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using CC.Apps.CKiosk.Config;

namespace CC.Apps.CKiosk.Ui.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            try
            {
                // Get the application config, and launch the main form.
                // This app runs from the main form's load code
                ApplicationConfig ApplicationConfig = new ApplicationConfig();
                Application.Run(new CKioskMainForm(ref ApplicationConfig));
            }
            catch (Exception ex)
            {
                StringBuilder _Error = new StringBuilder();


                _Error.AppendLine("Fatal Application Error.  Please contact IT.");
                _Error.AppendLine("");
                _Error.AppendLine("Message:");
                _Error.AppendLine(ex.Message);

                if (ex.InnerException != null)
                {
                    _Error.AppendLine("");
                    _Error.AppendLine("Inner Exception:");
                    _Error.AppendLine(ex.InnerException.Message);
                }

                _Error.AppendLine("");
                _Error.AppendLine("The application will now terminate.");

                MessageBox.Show(_Error.ToString(), "KioskPortal Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // we use Environment.Exit(-1) as we do not care about informing any windows about the close event.
                Environment.Exit(-1);
            }
        }
    }
}
