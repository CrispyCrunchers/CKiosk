using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Apps.CKiosk.Config
{
    // AppManager
    // This class holds the list of apps assigned to the Kiosk

    public class AppManager
    {
        private List<App> _AppList = new List<App>();

        public List<App> Apps
        {
            get
            {
                return _AppList;
            }
        }


        public App this[int Index]
        {
            get
            {
                return _AppList[Index];
            }
        }

        public App this[string AppName]
        {
            get
            {
                return GetApp(AppName);
            }
        }

        public App GetApp(int Index)
        {
            return _AppList[Index];
        }

        public App GetApp(string AppName)
        {
            foreach (App _App in _AppList)
            {
                if (_App.Name == AppName)
                {
                    return _App;
                }
            }

            return null;
        }
    }


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class App
    {

        private string groupField;
        private string nameField;
        private string execPathField;
        private string argumentsField;
        private int imageIndexField;
        private bool autoLaunchField;

        /// <remarks/>
        public string Group
        {
            get
            {
                return this.groupField;
            }
            set
            {
                this.groupField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string ExecPath
        {
            get
            {
                return Environment.ExpandEnvironmentVariables(this.execPathField);
            }
            set
            {
                this.execPathField = value;
            }
        }

        /// <remarks/>
        public string Arguments
        {
            get
            {
                return this.argumentsField;
            }
            set
            {
                this.argumentsField = value;
            }
        }

        public bool AutoLaunch
        {
            get
            {
                return this.autoLaunchField;
            }
            set
            {
                this.autoLaunchField = value;
            }
        }
    }

}
