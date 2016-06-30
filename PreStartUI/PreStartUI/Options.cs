using System;
using System.Management;
using System.IO;
using System.Windows.Forms;
using System.Xml.XPath;


namespace PreStartUI
{
    public partial class Options : Form
    {

        public static bool enableSiteCongfig = true;
        
        public Options()
        {
            InitializeComponent();
        }


/*
        private void GetSMToolsURIsFromXML()
        {
            try
            {
                //settingsFilePath is a string variable storing the path of the settings file 
                XPathDocument doc = new XPathDocument(mainForm.settingsFilePath);
                XPathNavigator nav = doc.CreateNavigator();
                // Compile a standard XPath expression
                XPathExpression expr;
                expr = nav.Compile(@"/settings/SMTools/URI");
                XPathNodeIterator iterator = nav.Select(expr);
                // Iterate on the node set
                while (iterator.MoveNext())
                {
                    int newItemIndex = comboBox1.Items.Add(iterator.Current.Value);
                    if (iterator.Current.HasAttributes)
                    {
                        string selected = iterator.Current.GetAttribute("selected", nav.NamespaceURI);
                        if (selected == "true") { comboBox1.SelectedIndex = newItemIndex; }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void GetCMSitesFromXML()
        {
            try
            {
                //settingsFilePath is a string variable storing the path of the settings file 
                XPathDocument doc = new XPathDocument(mainForm.settingsFilePath);
                XPathNavigator nav = doc.CreateNavigator();
                // Compile a standard XPath expression
                XPathExpression expr;
                expr = nav.Compile(@"/settings/ConfigMgr/Site");
                XPathNodeIterator iterator = nav.Select(expr);
                // Iterate on the node set
                while (iterator.MoveNext())
                {
                    int newItemIndex = comboBox2.Items.Add(iterator.Current.Value);
                    if (iterator.Current.HasAttributes)
                    {
                        string selected = iterator.Current.GetAttribute("selected", nav.NamespaceURI);
                        if (selected == "true"){ comboBox2.SelectedIndex = newItemIndex; }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void GetTargetingFromXML()
        {
            try
            {
                //settingsFilePath is a string variable storing the path of the settings file 
                XPathDocument doc = new XPathDocument(mainForm.settingsFilePath);
                XPathNavigator nav = doc.CreateNavigator();
                // Compile a standard XPath expression
                XPathExpression expr;
                expr = nav.Compile(@"/settings/SMTools/Targeting/Mode");
                XPathNodeIterator iterator = nav.Select(expr);
                // Iterate on the node set
                while (iterator.MoveNext())
                {
                    int newItemIndex = comboBox3.Items.Add(iterator.Current.Value);
                    if (iterator.Current.HasAttributes)
                    {
                        string selected = iterator.Current.GetAttribute("selected", nav.NamespaceURI);
                        if (selected == "true"){ comboBox3.SelectedIndex = newItemIndex; }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
*/
        public static string FindVariablesFile()
        {
            mainForm.LogIt("Reading Removable Disk Info");
            try
            {
                WqlObjectQuery qry = new WqlObjectQuery("SELECT * FROM Win32_LogicalDisk WHERE ((DriveType = 2) OR (DriveType = 5))");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(qry);

                foreach (ManagementObject diskDrive in searcher.Get())
                {
                    string _drive = diskDrive["DeviceID"].ToString();
                    mainForm.LogIt("Checking " + _drive + " for " + mainForm.CMDatPath);

                    if (File.Exists(_drive + mainForm.CMDatPath + "\\variables.dat"))
                    {
                        mainForm.LogIt("Found variables dat path at " + _drive);
                        if (diskDrive["DriveType"].ToString() == "5")
                        {
                            mainForm.LogIt("WARN: variables.dat is on optical media!");
                            mainForm.LogIt("WARN: disabling site configuration");
                            enableSiteCongfig = false;
                        }
                        return _drive + mainForm.CMDatPath;
                    }
                }
                return "";

            }
            catch (System.Exception ex)
            {
                mainForm.LogIt("Error finding dat path. " + ex.Message);
                return "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string logCapScript = mainForm.ReadValueFromXML("LogCaptureScript");
            string logFolder = Environment.SystemDirectory.Split('\\')[0] + "\\OSDLogs";

            if (File.Exists(logCapScript))
            {
                //script is external to make it easy to maintain.
                this.WindowState = FormWindowState.Minimized;
                string _destination = textBox1.Text;
                string _macaddress = mainForm.PrimaryMACAddress.Replace(":", "");
                string _timeStamp = mainForm.LogTime;

                if (string.IsNullOrEmpty(_macaddress)) { _macaddress = System.Environment.MachineName; }

                string args = "-ExecutionPolicy ByPass -File " + logCapScript + " -RemoteRoot " + _destination + " -RemoteFolder \\Incoming\\" + _macaddress + "\\" + _timeStamp;

                mainForm.RunCommand(@"\WINDOWS\system32\WindowsPowerShell\v1.0\powershell.exe", args, System.Environment.CurrentDirectory, true);
                this.Close();
            }
            else
            {
                mainForm.LogIt("Warn: " + logCapScript + " not found");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            string varLoc = FindVariablesFile();
            CMSites.Enabled = enableSiteCongfig;
            if (!CMSites.Enabled)
            {
                labelOpticalMediaError.Visible = true;
                labelSiteDisableNote1.Visible = true;
            }

            for (int i = 0; i < TargetingModes.Items.Count; i++)
            {
                if (TargetingModes.Items[i].ToString() == mainForm.TargetingMode)
                {
                    TargetingModes.SelectedIndex = i;
                }
            }

            for (int i = 0; i < SMToolsSites.Items.Count; i++)
            {
                if(SMToolsSites.Items[i].ToString() == mainForm.SMToolsURI)
                {
                    SMToolsSites.SelectedIndex = i;
                }
            }

            for (int i = 0; i < CMSites.Items.Count; i++)
            {
                if (CMSites.Items[i].ToString() == mainForm.CMSite)
                {
                    CMSites.SelectedIndex = i;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainForm.CMSite != CMSites.Items[CMSites.SelectedIndex].ToString())
            {
                mainForm.CMSite = CMSites.Items[CMSites.SelectedIndex].ToString();
                mainForm.LogIt("Changing CM Site Code to " + mainForm.CMSite);
                string _datFile = System.Environment.CurrentDirectory + "\\Variables." + mainForm.CMSite;

                try
                {
                    string _datPath = FindVariablesFile();
                    mainForm.LogIt("Copying " + _datFile + " to " + _datPath + "\\variables.dat");
                    File.Copy(_datFile, _datPath + "\\variables.dat", true);
                }
                catch (System.Exception ex)
                {
                    mainForm.LogIt("Error: " + ex.Message);
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(mainForm.TargetingMode != TargetingModes.Items[TargetingModes.SelectedIndex].ToString())
            {
                mainForm.TargetingMode = TargetingModes.Items[TargetingModes.SelectedIndex].ToString();
                mainForm.LogIt("TargetingMode set to " + mainForm.TargetingMode);
            }
        }

        private void SMToolsSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainForm.SMToolsURI != SMToolsSites.Items[SMToolsSites.SelectedIndex].ToString())
            {
                mainForm.SMToolsURI = SMToolsSites.Items[SMToolsSites.SelectedIndex].ToString();
                mainForm.LogIt("SMTools set to " + mainForm.SMToolsURI);
            }
        }
    }


}
