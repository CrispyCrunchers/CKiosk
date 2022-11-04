using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CC.Apps.CKiosk.Launcher.Config
{
    class ApplicationConfig
    {
        internal const string KioskPortalFileName = "CKioskPortal.exe";
        internal const string KioskPortalConfigFileName = "CKioskPortal.exe.config";

        internal static string RemoteKioskPortalExecPath = ConfigurationManager.AppSettings["RemoteKioskPortalExecPath"];
        internal static string RemoteKioskPortalExecFile = RemoteKioskPortalExecPath + "\\" + KioskPortalFileName;
        internal static string RemoteKioskPortalConfigFile = RemoteKioskPortalExecPath + "\\" + KioskPortalConfigFileName;
        internal static string LocalKioskPortalPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        internal static string LocalKioskPortalExec = LocalKioskPortalPath + "\\" + KioskPortalFileName;
        internal static string LocalKioskPortalConfig = LocalKioskPortalPath + "\\" + KioskPortalConfigFileName;
        internal static bool AttemptRemoteUpdate = bool.Parse(ConfigurationManager.AppSettings["AttemptRemoteUpdate"]);
        internal static bool SupressFileCopyErrors = bool.Parse(ConfigurationManager.AppSettings["SupressFileCopyErrors"]);
        internal static bool SuppressDetailedErrors = bool.Parse(ConfigurationManager.AppSettings["SuppressDetailedErrors"]);
    }
}
