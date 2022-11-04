using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text;
using CC.Apps.CKiosk.Config;

namespace CC.Apps.CKiosk.Ui.Desktop
{
    public partial class CKioskMainForm : Form
    {
        const int LayoutLvAppListHeightFromTop = 100;
        const int LayoutFormControlBorderBuffer = 10;
        const int LayoutStatusBarHiehgt = 22;

        private readonly Timer ReloadTimer = new Timer();

        private ApplicationConfig ApplicationConfig;
        
        public CKioskMainForm()
        {
            InitializeComponent();
        }

        public CKioskMainForm(ref ApplicationConfig ApplicationConfig)
        {
            // Throw an exception if we don't get a valid ApplicationConfig object
            if (ApplicationConfig == null)
            {
                throw new ArgumentNullException("ApplicationConfig", "ApplicationConfig cannot be null.");
            }

            // Set the applicationconfig property and continue loading
            this.ApplicationConfig = ApplicationConfig;

            InitializeComponent();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.ApplicationConfig = new ApplicationConfig();
            }
            catch (Exception ex)
            {
                StringBuilder _Error = new StringBuilder();

                _Error.AppendLine("Error setting ApplicationConfig.  Please contact IT.");
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

                MessageBox.Show(_Error.ToString(), "KioskPortal load failure", MessageBoxButtons.OK, MessageBoxIcon.Error );

                // we use Environment.Exit(-1) as we do not care about informing any windows about the close event.
                Environment.Exit(-1);
            }
            


            // Set the inital label text and positions
            lblHeader.Text = ApplicationConfig.Name;
            tsLblAppName.Text = ApplicationConfig.Name + " v" + ApplicationConfig.Version;

            AdjustFormLayout();

            // Load the lvApps;
            try
            {
                LoadForm();
            }
            catch (Exception ex)
            {
                DisplayMessageBox("Config Parse Error", ex.Message, ex.InnerException != null? ex.InnerException.Message : "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Auto-Launch on first run
            foreach (App _App in ApplicationConfig.AppManager.Apps)
            {
                if (_App.AutoLaunch)
                {
                    LaunchApp(_App.ExecPath, _App.Arguments);
                }
            }
        }



        private void LoadForm()
        {
            lvAppList.Items.Clear();
            lvAppList.Groups.Clear();

            /* 
             * Form Display
             */

            // Labels & Such

            this.Text = ApplicationConfig.HeaderText;
            lblHeader.Text = ApplicationConfig.HeaderText;


            /*
             * Status bar
             */

            // Labels
            tsLblHostname.Text = "Host: " + ApplicationConfig.Hostname;
            tsLblGroupName.Text = "Group: " + ApplicationConfig.GroupConfig.Name;
            tsLblRefreshStats.Text = "Last Refreshed: " + ApplicationConfig.LastRefreshed.ToString("G");

            // Actions - Enable/Disable
            tsActionsCmd.Enabled = ApplicationConfig.EnableCmd;
            tsActionsPrinters.Enabled = ApplicationConfig.EnablePrinterConfig;
            tsActionsNetwork.Enabled = ApplicationConfig.EnableNetworkConfig;
            tsActionsExplorer.Enabled = ApplicationConfig.EnableExplorer;
            tsActionsTaskManager.Enabled = ApplicationConfig.EnableTaskManager;
            tsActionsRun.Enabled = ApplicationConfig.EnableRun;
            tsActionsQuitKiosk.Enabled = ApplicationConfig.EnableQuit;
            tsActionsRestart.Enabled = ApplicationConfig.EnableRestart;
            tsActionsShutdown.Enabled = ApplicationConfig.EnableShutdown;


            /*
             * APPS
             */

            lvAppList.BeginUpdate();

            ImageList _ImageList = new ImageList();
            _ImageList.ImageSize = new Size(32, 32);
            _ImageList.ColorDepth = ColorDepth.Depth32Bit;


            lvAppList.LargeImageList = _ImageList;

            foreach (App _App in ApplicationConfig.AppManager.Apps)
            {
                if (File.Exists(_App.ExecPath))
                {
                    _ImageList.Images.Add(_App.Name, Icon.ExtractAssociatedIcon(_App.ExecPath).ToBitmap());

                    ListViewItem _lviApp = new ListViewItem();

                    _lviApp.Text = _App.Name;
                    _lviApp.ImageKey = _App.Name;
                    _lviApp.Group = FindOrCreateAppGroupByName(_App.Group);

                    lvAppList.Items.Add(_lviApp);
                }
            }

            lvAppList.EndUpdate();

            /* 
             * Finalize View
             */
            AdjustFormLayout();
            lblHeader.ForeColor = ApplicationConfig.GroupConfig.HeaderTextColor;


            // Auto-Refresh timer
            if (ApplicationConfig.AutoRefresh)
            {
                ReloadTimer.Interval = ApplicationConfig.AutoRefreshMinutes * 60 * 1000;
                ReloadTimer.Enabled = true;
                ReloadTimer.Tick += ReloadForm_EventHandler;
                ReloadTimer.Start();
            }
        }

        private void AdjustFormLayout()
        {
            /* 
            * 
            * Form Layout (After load so we know how big everything needs to be)
            * 
            */

            // lblHeader
            lblHeader.Left = (this.Width / 2) - (lblHeader.Width / 2);

            // lvAppList
            lvAppList.Top = LayoutLvAppListHeightFromTop;
            lvAppList.Left = LayoutFormControlBorderBuffer;
            lvAppList.Width = this.Width - (LayoutFormControlBorderBuffer * 2);
            lvAppList.Height = this.Height - btnLaunch.Height - LayoutLvAppListHeightFromTop - LayoutStatusBarHiehgt - (LayoutFormControlBorderBuffer * 2);

            // btnLaunch
            btnLaunch.Top = this.Height - LayoutFormControlBorderBuffer - LayoutStatusBarHiehgt - btnLaunch.Height;
            btnLaunch.Left = this.Width - btnLaunch.Width - LayoutFormControlBorderBuffer;
        }


        private void LaunchApp(string ExecPath)
        {
            LaunchApp(ExecPath, "");
        }
        private void LaunchApp(string ExecPath, string Arguments)
        {
            if (File.Exists(ExecPath))
            {
                if (string.IsNullOrEmpty(Arguments))
                {
                    System.Diagnostics.Process.Start(ExecPath);

                }
                else
                {
                    System.Diagnostics.Process.Start(ExecPath, Arguments );
                }
            }
            else
            {
                MessageBox.Show("Application not found.  Please contact IT.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private ListViewGroup FindAppGroupByName(string GroupName)
        {
            foreach (ListViewGroup _lviGroup in lvAppList.Groups)
            {
                if (_lviGroup.Header == GroupName)
                {
                    return _lviGroup;
                }
            }

            return null;
        }

        private ListViewGroup FindOrCreateAppGroupByName(string GroupName)
        {
            ListViewGroup _FindGroup = FindAppGroupByName(GroupName);

            if (_FindGroup == null)
            {
                ListViewGroup _lvg = new ListViewGroup(GroupName);
                lvAppList.Groups.Add(_lvg);

                return _lvg;
            }
            else
            {
                return _FindGroup;
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            // Check if we are exiting because of an ApplicationConfig init error.
            if (ApplicationConfig != null && !ApplicationConfig.EnableQuit)
            {
                MessageBox.Show("Action Cancelled.  This kiosk window cannot be closed.", "Action Aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void Restart_EventHandler(object sender, EventArgs e)
        {
            if (MessageBox.Show("Restart?", "Confirm Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ApplicationConfig.EnableQuit = true;
                LaunchApp(Path.Combine(System.Environment.SystemDirectory, "shutdown.exe"), "-r -t 0");
            }
        }

        private void Shutdown_EventHandler(object sender, EventArgs e)
        {
            if (MessageBox.Show("Shutdown?", "Confirm Shutdown", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ApplicationConfig.EnableQuit = true;
                LaunchApp(Path.Combine(System.Environment.SystemDirectory, "shutdown.exe"), "-s -t 0");
            }
        }

        private void Command_EventHandler(object sender, EventArgs e)
        {
            LaunchApp(Path.Combine(System.Environment.SystemDirectory, "cmd.exe"));
        }


        private void Printers_EventHandler(object sender, EventArgs e)
        {
            LaunchApp(Path.Combine(System.Environment.SystemDirectory, "control.exe"), "printers");
        }

        private void Network_EventHandler(object sender, EventArgs e)
        {
            LaunchApp(Path.Combine(System.Environment.SystemDirectory, "ncpa.cpl"));
        }

        private void GpUpdate_EventHandler(object sender, EventArgs e)
        {
            LaunchApp(Path.Combine(System.Environment.SystemDirectory, "gpupdate.exe"));
        }


        private void LaunchSelectedApps(object sender, EventArgs e)
        {
            foreach (ListViewItem _lvi in lvAppList.SelectedItems)
            {
                App _App = ApplicationConfig.AppManager[lvAppList.Items.IndexOf(_lvi)];
                LaunchApp(_App.ExecPath, _App.Arguments);
            }

        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shell32.Shell _Shell = new Shell32.Shell();
            _Shell.FileRun();
        }

        private void tsActionsExplorer_Click(object sender, EventArgs e)
        {
            LaunchApp(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe"));
        }

        private void tsActionsTaskManager_Click(object sender, EventArgs e)
        {
            LaunchApp(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "taskmgr.exe"));
        }

        private void tsActionsQuitKiosk_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DisplayMessageBox(string Title, string Message, string MessageDetails, MessageBoxButtons MessageBoxButtons, MessageBoxIcon MessageBoxIcon)
        {
            string _Message = Message;
            if (!string.IsNullOrEmpty(MessageDetails) && !ApplicationConfig.SuppressDetailedErrors)
            {
                _Message += "\r\n\r\nDetails:\r\n" + MessageDetails;
            }
            MessageBox.Show(_Message, Title, MessageBoxButtons, MessageBoxIcon);
        }


        private void ReloadForm_EventHandler(object sender, EventArgs e)
        {
            // Refresh App Config
            ApplicationConfig.Refresh();

            LoadForm();
        }
    }
}
