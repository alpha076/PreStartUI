using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Xml.XPath;
using System.Xml;

namespace PreStartUI
{
    public partial class mainForm : Form
    {
        public static string settingsFilePath = Environment.CurrentDirectory + "\\options.xml";
        public static string LoggingShare = ReadValueFromXML("RemoteLogPath");
        public static string NetTestHost = ReadValueFromXML("NetTestHost");
        public static string SMToolsURI = ReadValueFromXML("SMTools/URI");
        public static string TargetingMode = ReadValueFromXML("TargetingMode");
        public static string CMDatFile;
        public static string CMSite;
        public static string PrimaryMACAddress;
        public static string LogFile;
        public static string LogPath;
        public static string LogTime;


        public mainForm()
        {
            LogPath = ReadValueFromXML("LocalLogPath");
            LogFile = LogPath + "\\PreStartUI";

            InitializeComponent();
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            LogTime = sYear + sMonth + sDay;

            LogIt("Launching PreStartUI 1.0");
            LogIt("Settings: " + settingsFilePath);
        }

        public static void LogIt(string LogEntry)
        {
            string PreFix = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + ": ";

            StreamWriter sw = new StreamWriter(LogFile + "_" + LogTime + ".log", true);
            sw.WriteLine(PreFix + LogEntry);
            sw.Flush();
            sw.Close();
        }


        //public static int RunPowershellCommand(string command, int timeout)
        //{
        //var processInfo = new ProcessStartInfo("poweshell.exe", "-ExecutionPolicy Bypass " + command)
        //{
        //    CreateNoWindow = true,
        //    UseShellExecute = false,
        //    WorkingDirectory = "C:\\",
        //};

        //var process = Process.Start(processInfo);
        //process.WaitForExit(timeout);
        //var exitCode = process.ExitCode;
        //process.Close();
        //return exitCode;
        //}

        public static string ReadValueFromXML(string ValueToRead, string attribute = "")
        {
            try
            {
                //settingsFilePath is a string variable storing the path of the settings file 
                XPathDocument doc = new XPathDocument(settingsFilePath);
                XPathNavigator nav = doc.CreateNavigator();
                // Compile a standard XPath expression
                XPathExpression expr;
                expr = nav.Compile(@"/settings/" + ValueToRead);
                XPathNodeIterator iterator = nav.Select(expr);
                // Iterate on the node set
                while (iterator.MoveNext())
                {
                    if (attribute.Length > 0)
                    {
                        if (iterator.Current.HasAttributes)
                        { return iterator.Current.GetAttribute(attribute, nav.NamespaceURI); }
                    }
                    else{ return iterator.Current.Value; }
                }
                return string.Empty;
            }
            catch (System.Exception e)
            {
                LogIt("Error reading XML Value. " + e.Message + ":: ValuetoRead=" + ValueToRead + " attribute=" + attribute);
                return string.Empty;
            }
        }

        public bool WriteValueTOXML(string ValueToRead, string ValueToWrite)
        {
            try
            {
                //settingsFilePath is a string variable storing the path of the settings file 
                XmlTextReader reader = new XmlTextReader(settingsFilePath);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                //we have loaded the XML, so it's time to close the reader.
                reader.Close();
                XmlNode oldNode;
                XmlElement root = doc.DocumentElement;
                oldNode = root.SelectSingleNode("/settings/" + ValueToRead);
                oldNode.InnerText = ValueToWrite;
                doc.Save(settingsFilePath);
                return true;
            }
            catch
            {
                //properly you need to log the exception here. But as this is just an
                //example, I am not doing that. 
                return false;
            }
        }

        public bool PingNetwork(string hostNameOrAddress)
        {
            bool pingStatus = false;

            using (Ping p = new Ping())
            {
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;

                try
                {
                    PingReply reply = p.Send(hostNameOrAddress, timeout, buffer);
                    pingStatus = (reply.Status == IPStatus.Success);
                }
                catch (Exception)
                {
                    pingStatus = false;
                }
            }

            return pingStatus;
        }

        public void TestNetworkConnection(string host, Int32 port, Int32 timeout = 10000)
        {
            string hostStatus = "Testing";
            string connectionStatus = "Testing";

            LogIt("Starting connection test to " + host + " on port " + port);
            toolStripStatusLabel1.Text = host + ":" + port + " " + hostStatus + " " + connectionStatus;

            if (PingNetwork(host))
            {
                hostStatus = "ONLINE";
                toolStripStatusLabel1.Text = host + ":" + port + " " + hostStatus + " " + connectionStatus;

                try
                {
                    TcpClient sock = new TcpClient();
                    var cnxn = sock.BeginConnect(host, port, null, null);
                    cnxn.AsyncWaitHandle.WaitOne(timeout, false);
                    if (sock.Connected) { connectionStatus = "Port Connected"; }
                    else { connectionStatus = "Port Not-Connected"; }
                    sock.Close();
                }
                catch
                {
                    connectionStatus = "Port Error: ";
                }
            }
            toolStripStatusLabel1.Text = host + ":" + port + " " + hostStatus + " " + connectionStatus;

            LogIt("Connection Test: " + hostStatus);
            LogIt("Communications Test: " + connectionStatus);
        }

        public void GetNWInfo()
        {
            LogIt("Reading Network Information");
            ManagementObjectCollection naInfo;
            treeView1.Nodes.Clear();

            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapter");
                naInfo = mc.GetInstances();
            }
            catch (Exception e)
            {
                LogIt("ERROR: " + e);
                return;
            }

            if (naInfo.Count != 0)
            {
                foreach (ManagementObject mo in naInfo)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = mo["Name"].ToString();
                    string DeviceID = mo["DeviceID"].ToString();
                    string Pf = "NIC-" + DeviceID + ": ";
                    treeView1.Nodes.Add(tn);

                    
                    LogIt(Pf + mo["Name"].ToString());

                    try
                    {
                        WqlObjectQuery qry = new WqlObjectQuery("Select * From Win32_NetworkAdapterConfiguration Where Index=" + mo["Index"].ToString());
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher(qry);

                        foreach (ManagementObject netConfig in searcher.Get())
                        {
                            if (netConfig["IPEnabled"].ToString() == "True")
                            {
                                string[] addys = (string[])(netConfig["IPAddress"]);
                                TreeNode ipNode = new TreeNode();
                                ipNode.Text = "IPAddress(s)";
                                foreach (string addy in addys)
                                {
                                    ipNode.Nodes.Add(addy);
                                    LogIt(Pf + " IPAddress: " + addy);
                                }

                                tn.Nodes.Add("MACAddress: " + netConfig["MACAddress"].ToString());
                                tn.Nodes.Add("Speed: " + mo["Speed"].ToString());
                                tn.Nodes.Add(ipNode);

                                LogIt(Pf + " MACAddress: " + netConfig["MACAddress"].ToString());
                                LogIt(Pf + " Speed: " + mo["Speed"].ToString());

                                PrimaryMACAddress = netConfig["MACAddress"].ToString();

                            }
                        }
                    }
                    catch(Exception e)
                    {
                        LogIt("ERROR: " + e);
                    }
                }
            }
        }

        public void GetCSInfo()
        {

            ManagementObjectCollection csInfo;
            ManagementClass mc;
            LogIt("Reading Computer System Info");
            try
            {
                mc = new ManagementClass("Win32_ComputerSystem");
                csInfo = mc.GetInstances();
            }
            catch (Exception e)
            {
                LogIt("ERROR: " + e);
                return;
            }

            try
            {
                if (csInfo.Count != 0)
                {
                    foreach (ManagementObject mo in csInfo)
                    {
                        WMIHWInfo.Text = mo["Manufacturer"].ToString() + " " + mo["Model"].ToString();
                        LogIt(WMIHWInfo.Text);
                    }
                }

                mc = new ManagementClass("Win32_ComputerSystemProduct");
                ManagementObjectCollection cspInfo = mc.GetInstances();

                if (cspInfo.Count != 0)
                {
                    foreach (ManagementObject mo in cspInfo)
                    {
                        UUIDTextBox.Text = mo["UUID"].ToString();
                        LogIt(UUIDTextBox.Text);
                    }
                }

                mc = new ManagementClass("Win32_BIOS");
                ManagementObjectCollection biosInfo = mc.GetInstances();
                if (biosInfo.Count != 0)
                {
                    foreach (ManagementObject mo in biosInfo)
                    {
                        BIOSInfo.Text = "BIOS: " + mo["Name"].ToString();
                        BIOSVersionLabel.Text = "BIOS Ver: " + mo["Version"].ToString();
                        SN.Text = "SN: " + mo["SerialNumber"];
                        LogIt(BIOSInfo.Text);
                        LogIt(BIOSVersionLabel.Text);
                        LogIt(SN.Text);
                    }
                }
            }
            catch (Exception e)
            {
                LogIt("ERROR: " + e);
                return;
            }
        }

        public static string FindVariablesFile()
        {

            const int HARD_DISK = 3;
            const int REMO_DISK = 2;

            string CMDatPath = ReadValueFromXML("/ConfigMgr/DatPath");

            LogIt("Reading Disk Info");
            try
            {
                WqlObjectQuery qry = new WqlObjectQuery("SELECT * FROM Win32_LogicalDisk WHERE DriveType = " + REMO_DISK + "");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(qry);

                foreach (ManagementObject diskDrive in searcher.Get())
                {
                    string _drive = diskDrive["DeviceID"].ToString();
                    LogIt("Checking " + _drive  + " for " + CMDatPath);

                    if (File.Exists(_drive + CMDatPath + "\\variables.dat"))
                    {
                        LogIt("Found variables dat path at " + _drive);
                        return _drive + CMDatPath;
                    }
                }
                return "";

            }catch (System.Exception ex)
            {
                LogIt("Error finding dat path. " + ex.Message);
                return "";
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            HWGroupBox.Text = System.Environment.MachineName;
            GetCSInfo();
            GetNWInfo();

            TestNetworkConnection(NetTestHost, 80);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            LogIt("Exiting with Close Button");
            this.Close();
        }

        private void OpenCMTrace(string logfile)
        {
            try
            {
                var processInfo = new ProcessStartInfo("cmtrace.exe", logfile)
                {
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    WorkingDirectory = "C:\\",
                };

                var process = Process.Start(processInfo);
            }
            catch (Exception e)
            {
                LogIt("ERROR: " + e);
                MessageBox.Show("ERROR: " + e);
                return;
            }
        }

        private void Submit_ToSMTools()
        {
            string userDomain = "";
            string userName = "";
            string SMToolsiD = "";
            string queryStringPF = "";

            bool Submit = true;

            SMToolsIDError.Visible = false;
            PriUserError.Visible = false;


            if (primaryUser.Text.Length > 4)
            {
                if(primaryUser.Text.IndexOf("\\") > 0)
                {
                    userDomain = primaryUser.Text.Split('\\')[0];
                    userName = primaryUser.Text.Split('\\')[1];
                }
                else
                {
                    primaryUser.Focus();
                    PriUserError.Visible = true;
                    Submit = false;
                    LogIt("invalid format for Primary User field (" + primaryUser.Text + ")");
                }
            }
            else
            {
                primaryUser.Focus();
                PriUserError.Visible = true;
                Submit = false;
                LogIt("missing data for Primary User field (" + primaryUser.Text + ")");

            }

            if (installerID.Text.Length > 4)
            {
                SMToolsiD = installerID.Text;
                if (SMToolsiD.IndexOf("\\") > 0)
                {
                    installerID.Focus();
                    SMToolsIDError.Visible = true;
                    Submit = false;
                    LogIt("invalid data for SMTools ID field (" + installerID.Text + ")");

                }
            }

            else
            {
                installerID.Focus();
                SMToolsIDError.Visible = true;
                Submit = false;

                LogIt("missing data for SMTools ID field (" + installerID.Text + ")");
            }

 

            if (Submit)
            {
                LogIt("Data Validated. Submitting data to SMTools");
                LogIt("Targeting Mode = " + TargetingMode);
                switch (TargetingMode)
                {
                    case "MACAddress":
                        LogIt("Processing MACAddress for submission");
                        if (PrimaryMACAddress.Length > 5)
                        {
                            queryStringPF = "?MACAddress=" + PrimaryMACAddress.Replace(":", "-");
                        }
                        else
                        {
                            Submit = false;
                            LogIt("missing data for MACAddress. Validate network connection.");
                        }
                        break;
                    default:
                        LogIt("Processing SMBIOSGuid for Submission");
                        if (UUIDTextBox.Text.Length > 5)
                        {
                            queryStringPF = "?UUID=" + UUIDTextBox.Text;
                        }
                        else
                        {
                            UUIDError.Visible = true;
                            Submit = false;
                            LogIt("missing data for UUID field (" + UUIDTextBox.Text + ")");
                        }
                        break;
                }

                string queryString = queryStringPF + "&primaryUserDomain=" + userDomain + "&primaryUserID=" + userName + "&smtoolsUserID=" + SMToolsiD;

                Uri address = new Uri(SMToolsURI + queryString);
                LogIt(address.ToString());
                smtoolsStatusLabel.Text = "Job submitted. Please continue provisioning in SMTools before closing this window.";


                /*
                HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                request.Method = "POST";
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                { StreamReader reader = new StreamReader(response.GetResponseStream()); }
                */

                OKButton.Enabled = false;
            }

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Submit_ToSMTools();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            TestNetworkConnection(NetTestHost, 80);
            GetNWInfo();
        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Attention: The options available in this dialog can break the provisioning process and should only be used at the direction of Engineering or CM Support.", "Advanced Options", MessageBoxButtons.OKCancel);
            if(ans == DialogResult.OK)
            {
                LogIt("Loading options dialog");
                Options OptionsDialog = new Options();
                OptionsDialog.textBox1.Text = LoggingShare;

                OptionsDialog.ShowDialog(this); //Wait for this to close before continuing

                if(OptionsDialog.DialogResult == DialogResult.OK)
                {
                    LogIt("Options Dialog closed with Ok button");

                    SMToolsURI = OptionsDialog.comboBox1.Text;
                    LogIt("SMToolsURI: " + SMToolsURI);
                    CMSite = OptionsDialog.comboBox2.Text;
                    LogIt("CMSite: " + CMSite);
                    LoggingShare = OptionsDialog.textBox1.Text;
                    LogIt("Logging Share: " + LoggingShare);

                    string _datFile = System.Environment.CurrentDirectory + "\\Variables." + CMSite;

                    try
                    {
                        string _datPath = FindVariablesFile();
                        LogIt("Copying " + _datFile + " to " + _datPath + "\\Variables.dat");
                        File.Copy(_datFile, _datPath + "\\variables.dat", true);
                    }
                    catch (System.Exception ex)
                    {
                        LogIt("Error: " + ex.Message);
                        MessageBox.Show("ERROR: " + ex.Message);
                    }
                }else
                {
                    LogIt("Options dialog canceled");
                }
                OptionsDialog.Dispose();
            }
        }
    }
}
