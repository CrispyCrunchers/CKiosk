using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace CC.Apps.CKiosk.Config
{

    // ApplicationConfig
    // This is the class that handles most of how the program works.
    // It is responsible for settting all the properties based on the XML config.

    public class ApplicationConfig
    {
        public static string Name = Assembly.GetExecutingAssembly().GetName().Name.ToString();
        public static string Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        // Global Configs
        public string Hostname { get; } = Environment.MachineName;
        public DeviceConfig DeviceConfig { get; private set; }
        public GroupConfig GroupConfig { get; private set; }
        public AppManager AppManager { get; private set; } = new AppManager();

        // Config Paths
        public string RemoteConfigFilename { get; private set; }
        public string LocalConfigPath { get; private set; }
        public string LocalDeviceConfigFileName { get; private set; }
        public string LocalGroupConfigFileName { get; private set; }

        // AttemptRemoteFileCopy
        // Default to true
        public bool AttemptRemoteFileCopy { get; private set; }

        // SuppressDetailedErrors
        // Default to true
        public bool SuppressDetailedErrors { get; private set; }

        // SuppressFileCopyErrors
        // Default to true
        public bool SuppressFileCopyErrors { get; private set; }

        // AutoRefresh
        // Set Default to true
        public bool AutoRefresh { get; private set; }

        // AutoRefreshMinutes
        // Set default to 60
        public int AutoRefreshMinutes { get; private set; }
        
        public DateTime LastRefreshed { get; private set; }

        public string HeaderText { get; private set; } = "Public Kiosk";


        public bool EnableCmd { get; private set; }
        public bool EnablePrinterConfig { get; private set; }
        public bool EnableNetworkConfig { get; private set; }
        public bool EnableExplorer { get; private set; }
        public bool EnableTaskManager { get; private set; }
        public bool EnableRun { get; private set; }
        public bool EnableQuit { get; set; }  // Allow set to allow quit from form upon restart or shutdown
        public bool EnableRestart { get; private set; }
        public bool EnableShutdown { get; private set; }


        public ApplicationConfig()
        {
            // Set paths
            RemoteConfigFilename = ConfigurationManager.AppSettings["RemoteConfigFilename"];
            RemoteConfigFilename = RemoteConfigFilename.ToLower().Replace("[hostname]", this.Hostname);

            LocalConfigPath = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + @"\" + Name;
            LocalDeviceConfigFileName = LocalConfigPath + @"\DeviceConfig.xml";
            LocalGroupConfigFileName = LocalConfigPath + @"\GroupConfig.xml";

            AttemptRemoteFileCopy = bool.TryParse(ConfigurationManager.AppSettings["AttemptRemoteFileCopy"], out bool _AttemptRemoteFileCopy) ? _AttemptRemoteFileCopy : true;

            // SuppressDetailedErrors
            // Default to true
            SuppressDetailedErrors = bool.TryParse(ConfigurationManager.AppSettings["SuppressDetailedErrors"], out bool _SuppressDetailedErrors) ? _SuppressDetailedErrors : true;

            // SuppressFileCopyErrors
            // Default to true
            SuppressFileCopyErrors = bool.TryParse(ConfigurationManager.AppSettings["SuppressFileCopyErrors"], out bool _SuppressFileCopyErrors) ? _SuppressFileCopyErrors : true;

            // AutoRefresh
            // Set Default to true
            AutoRefresh = bool.TryParse(ConfigurationManager.AppSettings["AutoRefresh"], out bool _AutoRefresh) ? _AutoRefresh : true;

            // AutoRefreshMinutes
            // Set default to 60
            AutoRefreshMinutes = int.TryParse(ConfigurationManager.AppSettings["AutoRefreshMinutes"], out int _AutoRefreshMinutes) ? _AutoRefreshMinutes : 60;

            Refresh();
        }

        public void Refresh()
        {
            DownloadAndParseConfigs();
            SetParametersFromConfig();

            this.LastRefreshed = DateTime.Now;
        }



        private void DownloadAndParseConfigs()
        {

            // Attempt to copy computer specific config
            // Force download if file not found.
            if (AttemptRemoteFileCopy || !File.Exists(LocalDeviceConfigFileName))
            {
                try
                {
                    Directory.CreateDirectory(LocalConfigPath);
                    File.Copy(RemoteConfigFilename, LocalDeviceConfigFileName, true);
                }
                catch (Exception ex)
                {
                    if (!SuppressFileCopyErrors)
                    {
                        DisplayMessageBox("File copy error", "DeviceConfig download failed.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }


            // Device Config
            if (!File.Exists(LocalDeviceConfigFileName))
            {
                throw new Exception("No DeviceConfig file found.  Please contact IT.");
            }

            try
            {
                // Read in XML
                string _DeviceConfigXml = File.ReadAllText(LocalDeviceConfigFileName);
                DeviceConfig = XmlConvert.DeserializeObject<DeviceConfig>(_DeviceConfigXml);
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing DeviceConfig.", ex);
            }


            // Group Config

            // Attempt to download new XML.  Revert to local if one cannot be downloaded.
            // Force download if file not found.
            if (AttemptRemoteFileCopy || !File.Exists(LocalGroupConfigFileName))
            {
                try
                {
                    File.Copy(DeviceConfig.RemoteGroupConfigFileName, LocalGroupConfigFileName, true);
                }
                catch (Exception ex)
                {
                    if (!SuppressFileCopyErrors)
                    {
                        DisplayMessageBox("GroupConfig Error", "A GroupConfig file copy error occurred.  Please contact IT.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }


            if (!File.Exists(LocalGroupConfigFileName))
            {
                throw new Exception("No GroupConfig file found.  Please contact IT.");
            }

            try
            {
                // Read in XML
                string _GroupConfigXml = File.ReadAllText(LocalGroupConfigFileName);
                GroupConfig = XmlConvert.DeserializeObject<GroupConfig>(_GroupConfigXml);
            }

            catch (Exception ex)
            {
                throw new Exception("Error reading GroupConfig file.", ex);
            }
        }

        private void SetParametersFromConfig()
        {

            // When setting parameters,
            // prefer the device config, then the group config
            HeaderText = !string.IsNullOrEmpty(DeviceConfig.HeaderText) ? DeviceConfig.HeaderText : !string.IsNullOrEmpty(GroupConfig.HeaderText) ? GroupConfig.HeaderText : "Public Kiosk";

            // Cmd
            if (DeviceConfig.EnableCmd.HasValue)
            {
                EnableCmd = this.DeviceConfig.EnableCmd.Value;
            }
            else
            {
                if (GroupConfig.EnableCmd.HasValue)
                {
                    EnableCmd = GroupConfig.EnableCmd.Value;
                }
            }

            // Printers
            if (DeviceConfig.EnablePrinterConfig.HasValue)
            {
                EnablePrinterConfig = DeviceConfig.EnablePrinterConfig.Value;
            }
            else
            {
                if (GroupConfig.EnablePrinterConfig.HasValue)
                {
                    EnablePrinterConfig = GroupConfig.EnablePrinterConfig.Value;
                }
            }

            // Network
            if (DeviceConfig.EnableNetworkConfig.HasValue)
            {
                EnableNetworkConfig = DeviceConfig.EnableNetworkConfig.Value;
            }
            else
            {
                if (GroupConfig.EnableNetworkConfig.HasValue)
                {
                    EnableNetworkConfig = GroupConfig.EnableNetworkConfig.Value;
                }
            }

            // Explorer
            if (DeviceConfig.EnableExplorer.HasValue)
            {
                EnableExplorer = DeviceConfig.EnableExplorer.Value;
            }
            else
            {
                if (GroupConfig.EnableExplorer.HasValue)
                {
                    EnableExplorer = GroupConfig.EnableExplorer.Value;
                }
            }

            // Tast Manager
            if (DeviceConfig.EnableTaskManager.HasValue)
            {
                EnableTaskManager = DeviceConfig.EnableTaskManager.Value;
            }
            else
            {
                if (GroupConfig.EnableExplorer.HasValue)
                {
                    EnableTaskManager = GroupConfig.EnableTaskManager.Value;
                }
            }

            // Run
            if (DeviceConfig.EnableRun.HasValue)
            {
                EnableRun = DeviceConfig.EnableRun.Value;
            }
            else
            {
                if (GroupConfig.EnableRun.HasValue)
                {
                    EnableRun = GroupConfig.EnableRun.Value;
                }
            }

            // Quit
            if (DeviceConfig.EnableQuit.HasValue)
            {
                EnableQuit = DeviceConfig.EnableQuit.Value;
            }
            else
            {
                if (GroupConfig.EnableQuit.HasValue)
                {
                    EnableQuit = GroupConfig.EnableQuit.Value;
                }
            }


            // Restart
            if (DeviceConfig.EnableRestart.HasValue)
            {
                EnableRestart = DeviceConfig.EnableRestart.Value;
            }
            else
            {
                if (GroupConfig.EnableRestart.HasValue)
                {
                    EnableRestart = GroupConfig.EnableRestart.Value;
                }
            }

            // Shutdown
            if (DeviceConfig.EnableShutdown.HasValue)
            {
                EnableShutdown = DeviceConfig.EnableShutdown.Value;
            }
            else
            {
                if (GroupConfig.EnableShutdown.HasValue)
                {
                    EnableShutdown = GroupConfig.EnableShutdown.Value;
                }
            }



            /*
             * Apps
             */
            
            // Remove all apps
            this.AppManager.Apps.Clear();

            // Device specific apps
            if (DeviceConfig.Apps != null)
            {
                foreach (App _App in DeviceConfig.Apps)
                {
                    AppManager.Apps.Add(_App);
                }
            }

            // Group apps
            if (GroupConfig.Apps != null)
            {
                foreach (App _App in GroupConfig.Apps)
                {
                    AppManager.Apps.Add(_App);
                }

            }

        }

        private void DisplayMessageBox(string Title, string Message, string MessageDetails, MessageBoxButtons MessageBoxButtons, MessageBoxIcon MessageBoxIcon)
        {
            string _Message = Message;
            if (!string.IsNullOrEmpty(MessageDetails) && !SuppressDetailedErrors)
            {
                _Message += "\r\n\r\nDetails:\r\n" + MessageDetails;
            }
            MessageBox.Show(_Message, Title, MessageBoxButtons, MessageBoxIcon);
        }

    }
}
