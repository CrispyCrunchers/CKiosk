using System;
using System.IO;

using CC.Apps.CKiosk.Launcher.Config;

namespace CC.Apps.CKiosk.Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Launching Kiosk...");

            // File Copy
            // Attempt updating the CKiosk app, if we are set to
            if (!File.Exists(ApplicationConfig.LocalKioskPortalExec) || ApplicationConfig.AttemptRemoteUpdate)
            {
                // This simply means copying down the latest release (binary & config) from the remote server
                try
                {
                    File.Copy(ApplicationConfig.RemoteKioskPortalExecFile, ApplicationConfig.LocalKioskPortalExec, true);
                    File.Copy(ApplicationConfig.RemoteKioskPortalConfigFile, ApplicationConfig.LocalKioskPortalConfig, true);
                }
                catch (Exception ex)
                {
                    WriteError("Kiosk portal update failed.  Please contact your system administrator.", ex);
                }
            }

            // Launch CKiosk (provided the binary exists)
            if (File.Exists(ApplicationConfig.LocalKioskPortalExec))
            {
                try
                {
                    System.Diagnostics.Process.Start(ApplicationConfig.LocalKioskPortalExec);
                    return;
                }
                catch (Exception ex)
                {
                    WriteError("Kiosk process failed to start.  System halted.  Please contact your system administrator.", ex);
                }
            }

            // If the binary was not found, alert the user
            else
            {
                WriteError("Kiosk portal exec not found.  System halted.  Please contact your system administrator.");
            }

            // If we make it here, then we are outside of the app and should shutdown
            Console.Write("\r\n\r\nPress any key to shutdown.");
            Console.ReadKey();

            System.Diagnostics.Process.Start(Path.Combine(System.Environment.SystemDirectory, "shutdown.exe"), "-s -t 0");

        }


        private static void WriteError(string GenericMessage)
        {
            WriteError(GenericMessage, "");
        }

        private static void WriteError(string GenericMessage, Exception ex)
        {
            WriteError(GenericMessage, ex.Message);
        }

        private static void WriteError(string GenericMessage, string DetailedError)
        {
            if (!ApplicationConfig.SupressFileCopyErrors)
            {
                string _ErrorMessage = GenericMessage;
                if (!ApplicationConfig.SuppressDetailedErrors)
                {
                    _ErrorMessage += "\r\n\r\n" + DetailedError;
                }

                Console.WriteLine("\r\n\r\n***************************\r\nERROR\r\n***************************\r\n\r\n" + _ErrorMessage);
            }
        }
    }
}
