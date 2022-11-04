using System;
using System.Windows.Forms;

namespace CC.Apps.CKiosk.Ui.Desktop
{
    partial class CKioskMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CKioskMainForm));
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsLblAppName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLblHostname = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLblGroupName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLblRefreshStats = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsKioskActions = new System.Windows.Forms.ToolStripSplitButton();
            this.tsActionsCmd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsActionsNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.tsActionsPrinters = new System.Windows.Forms.ToolStripMenuItem();
            this.tsActionsExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsActionsTaskManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsActionsRun = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsActionsQuitKiosk = new System.Windows.Forms.ToolStripMenuItem();
            this.tsActionsRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsActionsShutdown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsActionsGpUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsActionsReloadApps = new System.Windows.Forms.ToolStripMenuItem();
            this.lvAppList = new System.Windows.Forms.ListView();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Candara", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHeader.Location = new System.Drawing.Point(285, 25);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(175, 39);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "{AppName}";
            // 
            // btnLaunch
            // 
            this.btnLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.Location = new System.Drawing.Point(555, 454);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(170, 50);
            this.btnLaunch.TabIndex = 2;
            this.btnLaunch.Text = "LAUNCH";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.LaunchSelectedApps);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblAppName,
            this.tsLblHostname,
            this.tsLblGroupName,
            this.tsLblRefreshStats,
            this.tsKioskActions});
            this.statusStrip1.Location = new System.Drawing.Point(0, 515);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(735, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsLblAppName
            // 
            this.tsLblAppName.Name = "tsLblAppName";
            this.tsLblAppName.Size = new System.Drawing.Size(397, 17);
            this.tsLblAppName.Spring = true;
            this.tsLblAppName.Text = "{AppName} {AppVersion}";
            this.tsLblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsLblHostname
            // 
            this.tsLblHostname.Name = "tsLblHostname";
            this.tsLblHostname.Size = new System.Drawing.Size(70, 17);
            this.tsLblHostname.Text = "{Hostname}";
            // 
            // tsLblGroupName
            // 
            this.tsLblGroupName.Name = "tsLblGroupName";
            this.tsLblGroupName.Size = new System.Drawing.Size(80, 17);
            this.tsLblGroupName.Text = "{GroupName}";
            // 
            // tsLblRefreshStats
            // 
            this.tsLblRefreshStats.Name = "tsLblRefreshStats";
            this.tsLblRefreshStats.Size = new System.Drawing.Size(79, 17);
            this.tsLblRefreshStats.Text = "{RefreshStats}";
            // 
            // tsKioskActions
            // 
            this.tsKioskActions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsKioskActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsActionsCmd,
            this.tsActionsNetwork,
            this.tsActionsPrinters,
            this.tsActionsExplorer,
            this.tsActionsTaskManager,
            this.tsActionsRun,
            this.toolStripSeparator2,
            this.tsActionsQuitKiosk,
            this.tsActionsRestart,
            this.tsActionsShutdown,
            this.toolStripSeparator1,
            this.tsActionsGpUpdate,
            this.tsActionsReloadApps});
            this.tsKioskActions.Image = ((System.Drawing.Image)(resources.GetObject("tsKioskActions.Image")));
            this.tsKioskActions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsKioskActions.Name = "tsKioskActions";
            this.tsKioskActions.Size = new System.Drawing.Size(94, 20);
            this.tsKioskActions.Text = "Kiosk Actions";
            this.tsKioskActions.ButtonClick += new System.EventHandler(this.ReloadForm_EventHandler);
            // 
            // tsActionsCmd
            // 
            this.tsActionsCmd.Enabled = false;
            this.tsActionsCmd.Name = "tsActionsCmd";
            this.tsActionsCmd.Size = new System.Drawing.Size(153, 22);
            this.tsActionsCmd.Text = "Command";
            this.tsActionsCmd.Click += new System.EventHandler(this.Command_EventHandler);
            // 
            // tsActionsNetwork
            // 
            this.tsActionsNetwork.Enabled = false;
            this.tsActionsNetwork.Name = "tsActionsNetwork";
            this.tsActionsNetwork.Size = new System.Drawing.Size(153, 22);
            this.tsActionsNetwork.Text = "Network";
            this.tsActionsNetwork.Click += new System.EventHandler(this.Network_EventHandler);
            // 
            // tsActionsPrinters
            // 
            this.tsActionsPrinters.Enabled = false;
            this.tsActionsPrinters.Name = "tsActionsPrinters";
            this.tsActionsPrinters.Size = new System.Drawing.Size(153, 22);
            this.tsActionsPrinters.Text = "Printers";
            this.tsActionsPrinters.Click += new System.EventHandler(this.Printers_EventHandler);
            // 
            // tsActionsExplorer
            // 
            this.tsActionsExplorer.Enabled = false;
            this.tsActionsExplorer.Name = "tsActionsExplorer";
            this.tsActionsExplorer.Size = new System.Drawing.Size(153, 22);
            this.tsActionsExplorer.Text = "Explorer";
            this.tsActionsExplorer.Click += new System.EventHandler(this.tsActionsExplorer_Click);
            // 
            // tsActionsTaskManager
            // 
            this.tsActionsTaskManager.Enabled = false;
            this.tsActionsTaskManager.Name = "tsActionsTaskManager";
            this.tsActionsTaskManager.Size = new System.Drawing.Size(153, 22);
            this.tsActionsTaskManager.Text = "Task Manager";
            this.tsActionsTaskManager.Click += new System.EventHandler(this.tsActionsTaskManager_Click);
            // 
            // tsActionsRun
            // 
            this.tsActionsRun.Enabled = false;
            this.tsActionsRun.Name = "tsActionsRun";
            this.tsActionsRun.Size = new System.Drawing.Size(153, 22);
            this.tsActionsRun.Text = "Run";
            this.tsActionsRun.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(150, 6);
            // 
            // tsActionsQuitKiosk
            // 
            this.tsActionsQuitKiosk.Enabled = false;
            this.tsActionsQuitKiosk.Name = "tsActionsQuitKiosk";
            this.tsActionsQuitKiosk.Size = new System.Drawing.Size(153, 22);
            this.tsActionsQuitKiosk.Text = "Quit Kiosk App";
            this.tsActionsQuitKiosk.Click += new System.EventHandler(this.tsActionsQuitKiosk_Click);
            // 
            // tsActionsRestart
            // 
            this.tsActionsRestart.Enabled = false;
            this.tsActionsRestart.Name = "tsActionsRestart";
            this.tsActionsRestart.Size = new System.Drawing.Size(153, 22);
            this.tsActionsRestart.Text = "Restart";
            this.tsActionsRestart.Click += new System.EventHandler(this.Restart_EventHandler);
            // 
            // tsActionsShutdown
            // 
            this.tsActionsShutdown.Enabled = false;
            this.tsActionsShutdown.Name = "tsActionsShutdown";
            this.tsActionsShutdown.Size = new System.Drawing.Size(153, 22);
            this.tsActionsShutdown.Text = "Shutdown";
            this.tsActionsShutdown.Click += new System.EventHandler(this.Shutdown_EventHandler);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // tsActionsGpUpdate
            // 
            this.tsActionsGpUpdate.Name = "tsActionsGpUpdate";
            this.tsActionsGpUpdate.Size = new System.Drawing.Size(153, 22);
            this.tsActionsGpUpdate.Text = "GPUpdate";
            this.tsActionsGpUpdate.Click += new System.EventHandler(this.GpUpdate_EventHandler);
            // 
            // tsActionsReloadApps
            // 
            this.tsActionsReloadApps.Name = "tsActionsReloadApps";
            this.tsActionsReloadApps.Size = new System.Drawing.Size(153, 22);
            this.tsActionsReloadApps.Text = "Reload Apps";
            this.tsActionsReloadApps.Click += new System.EventHandler(this.ReloadForm_EventHandler);
            // 
            // lvAppList
            // 
            this.lvAppList.HideSelection = false;
            this.lvAppList.Location = new System.Drawing.Point(12, 67);
            this.lvAppList.Name = "lvAppList";
            this.lvAppList.Size = new System.Drawing.Size(713, 381);
            this.lvAppList.TabIndex = 4;
            this.lvAppList.UseCompatibleStateImageBehavior = false;
            this.lvAppList.DoubleClick += new System.EventHandler(this.LaunchSelectedApps);
            // 
            // KioskFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(735, 537);
            this.Controls.Add(this.lvAppList);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KioskFormMain";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private Label lblHeader;
        private Button btnLaunch;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsLblAppName;
        private ToolStripSplitButton tsKioskActions;
        private ToolStripMenuItem tsActionsRestart;
        private ToolStripMenuItem tsActionsShutdown;
        private ToolStripMenuItem tsActionsReloadApps;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripStatusLabel tsLblGroupName;
        private ToolStripStatusLabel tsLblRefreshStats;
        private ToolStripMenuItem tsActionsPrinters;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem tsActionsNetwork;
        private ToolStripMenuItem tsActionsCmd;
        private ToolStripMenuItem tsActionsGpUpdate;
        private ToolStripMenuItem tsActionsRun;
        private ToolStripMenuItem tsActionsExplorer;
        private ToolStripMenuItem tsActionsTaskManager;
        private ToolStripMenuItem tsActionsQuitKiosk;
        private ListView lvAppList;
        private ToolStripStatusLabel tsLblHostname;
    }
}

