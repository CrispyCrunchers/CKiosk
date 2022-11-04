﻿namespace CC.Apps.CKiosk.Config
{

    // GroupConfig
    // This class holds the group config XMl file settings
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class GroupConfig
    {

        private string headerTextField;
        private string headerTextColorRgbField;
        private bool? enableCmdField;
        private bool? enableNetworkConfigField;
        private bool? enablePrinterConfigField;
        private bool? enableRunField;
        private bool? enableTaskManagerField;
        private bool? enableExplorerField;
        private bool? enableQuitField;
        private bool? enableRestartField;
        private bool? enableShutdownField;
        private App[] appsField;

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        public string HeaderText
        {
            get
            {
                return this.headerTextField;
            }
            set
            {
                this.headerTextField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public System.Drawing.Color HeaderTextColor
        {
            get
            {
                try
                {
                    return (System.Drawing.Color)System.Drawing.ColorTranslator.FromHtml(HeaderTextColorRgb.Substring(0, 1) == "#" ? HeaderTextColorRgb : "#" + HeaderTextColorRgb);
                }
                catch
                {
                    return System.Drawing.Color.Black;
                }
            }
        }

        /// <remarks/>
        public string HeaderTextColorRgb
        {
            get
            {
                return this.headerTextColorRgbField;
            }
            set
            {
                this.headerTextColorRgbField = value;
            }
        }

        /// <remarks/>
        public bool? EnableCmd
        {
            get
            {
                return this.enableCmdField;
            }
            set
            {
                this.enableCmdField = value;
            }
        }

        /// <remarks/>
        public bool? EnableNetworkConfig
        {
            get
            {
                return this.enableNetworkConfigField;
            }
            set
            {
                this.enableNetworkConfigField = value;
            }
        }

        /// <remarks/>
        public bool? EnablePrinterConfig
        {
            get
            {
                return this.enablePrinterConfigField;
            }
            set
            {
                this.enablePrinterConfigField = value;
            }
        }

        /// <remarks/>
        public bool? EnableRun
        {
            get
            {
                return this.enableRunField;
            }
            set
            {
                this.enableRunField = value;
            }
        }

        /// <remarks/>
        public bool? EnableTaskManager
        {
            get
            {
                return this.enableTaskManagerField;
            }
            set
            {
                this.enableTaskManagerField = value;
            }
        }

        /// <remarks/>
        public bool? EnableExplorer
        {
            get
            {
                return this.enableExplorerField;
            }
            set
            {
                this.enableExplorerField = value;
            }
        }

        /// <remarks/>
        public bool? EnableQuit
        {
            get
            {
                return this.enableQuitField;
            }
            set
            {
                this.enableQuitField = value;
            }
        }

        /// <remarks/>
        public bool? EnableRestart
        {
            get
            {
                return this.enableRestartField;
            }
            set
            {
                this.enableRestartField = value;
            }
        }

        /// <remarks/>
        public bool? EnableShutdown
        {
            get
            {
                return this.enableShutdownField;
            }
            set
            {
                this.enableShutdownField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("App", IsNullable = false)]
        public App[] Apps
        {
            get
            {
                return this.appsField;
            }
            set
            {
                this.appsField = value;
            }
        }
    }



}