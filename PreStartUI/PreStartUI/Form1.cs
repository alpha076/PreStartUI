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
using System.Net;
using System.Threading;
using Microsoft.Win32;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace PreStartUI
{
    public partial class mainForm : Form
    {
        Options OptsDlg = new Options();
        public static string LoggingShare;
        public static string NetTestHost;
        public static string SMToolsURI;
        public static string TargetingMode;
        public static string CMDatPath;
        public static bool DoUpdate = false;
        public static bool SiteCodeChanged = false;
        public static bool URIChanged = false;
        public static string CMDatFile;
        public static string CMSite;
        public static string PrimaryMACAddress;
        public static string LogFile;
        public static string LogPath;
        public static string LogTime;
        public static string ThisIPAddress;
        Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");


        public static string settingsFilePath = Environment.CurrentDirectory + "\\options.xml";

        public mainForm()
        {

            InitializeComponent();
            if (!File.Exists(settingsFilePath))
            {
                LogPath = Environment.CurrentDirectory;
                MessageBox.Show("ERROR: " + settingsFilePath + " not found!");
            } else
            {
                LogPath = ReadValueFromXML("LocalLogPath");
                LoggingShare = ReadValueFromXML("RemoteLogPath");
                NetTestHost = ReadValueFromXML("NetTestHost");
                SMToolsURI = ReadValueFromXML("SMTools/URI");
                TargetingMode = ReadValueFromXML("SMTools/Targeting/Mode");
                CMDatPath = ReadValueFromXML("/ConfigMgr/DatPath");
                CMSite = ReadValueFromXML("/ConfigMgr/Site");
            }

            if (!Directory.Exists(LogPath))
            {
                try
                {
                    Directory.CreateDirectory(LogPath);
                } catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            LogFile = LogPath + "\\PreStartUI";

            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            LogTime = sYear + sMonth + sDay;

            LogIt("Launching PreStartUI 1.0");
            if (File.Exists(settingsFilePath))
            { LogIt("Settings: " + settingsFilePath); }
            else { LogIt("WARN: " + settingsFilePath + " not found!"); }
        }

        public static void LogIt(string LogEntry)
        {
            string PreFix = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + ": ";
            StreamWriter sw = new StreamWriter(LogFile + "_" + LogTime + ".log", true);
            sw.WriteLine(PreFix + LogEntry);
            sw.Flush();
            sw.Close();
        }

        public static int RunCommand(string command, string commandArgs, string workingDir, bool wait = false, bool threaded = false)
        {
            try
            {
                var processInfo = new ProcessStartInfo(command)
                {
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    WorkingDirectory = workingDir,
                    Arguments = commandArgs,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };


                LogIt("Starting " + processInfo.FileName + " " + processInfo.Arguments + " from " + processInfo.WorkingDirectory);

                if (threaded)
                {
                    ThreadStart ths = new ThreadStart(() => Process.Start(processInfo));
                    Thread th = new Thread(ths);
                    th.Start();
                }
                else
                {
                    var process = Process.Start(processInfo);
                    if (wait)
                    {
                        process.WaitForExit();
                        LogIt("call completed with: " + process.ExitCode);
                        LogIt("--" + process.StandardOutput.ReadToEnd());
                        LogIt("Error: " + process.StandardError.ReadToEnd());
                        return process.ExitCode;
                    }
                }
            }
            catch (System.Exception ex)
            {
                LogIt("ERROR: " + ex);
                MessageBox.Show("ERROR: " + ex);
                return 1;
            }

            return 0;

        }

        public static void RunVBScript(string script, int timeout, string workingDir = "C:\\")
        {

            string binPath = Environment.SystemDirectory + "\\cscript.exe";
            try
            {
                var processInfo = new ProcessStartInfo(binPath, script)
                {
                    CreateNoWindow = true,
                    UseShellExecute = true,
                    WorkingDirectory = workingDir,
                    WindowStyle = ProcessWindowStyle.Minimized

                };
                LogIt("starting " + processInfo.FileName + " '" + processInfo.Arguments + "'");
                var process = Process.Start(processInfo);
                while (!process.HasExited) { }
            }
            catch (System.Exception ex)
            {
                LogIt("Error: " + ex.Message);
            }

        }

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
                    else { return iterator.Current.Value; }
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

        private void populateDropDownFromXML(ComboBox comboBox, string xPath)
        {
            try
            {
                //settingsFilePath is a string variable storing the path of the settings file 
                XPathDocument doc = new XPathDocument(mainForm.settingsFilePath);
                XPathNavigator nav = doc.CreateNavigator();
                // Compile a standard XPath expression
                XPathExpression expr;
                expr = nav.Compile(xPath);
                XPathNodeIterator iterator = nav.Select(expr);
                // Iterate on the node set
                while (iterator.MoveNext())
                {
                    int newItemIndex = comboBox.Items.Add(iterator.Current.Value);
                    if (iterator.Current.HasAttributes)
                    {
                        string selected = iterator.Current.GetAttribute("selected", nav.NamespaceURI);
                        if (selected == "true") { comboBox.SelectedIndex = newItemIndex; }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
            string hostStatus = "OFFLINE";
            string connectionStatus = "Port Not-Connected";

            LogIt("Starting connection test to " + host + " on port " + port);
            toolStripStatusLabel1.Text = "";

            if (PingNetwork(host))
            {
                hostStatus = "ONLINE";

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
            LogIt("Connection Test: " + hostStatus);
            LogIt("Communications Test: " + connectionStatus);

            toolStripStatusLabel1.Text = host + ":" + port + " " + hostStatus + " " + connectionStatus;
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
                                    if (ip.Matches(addy).Count > 0) { ThisIPAddress = addy; }
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
                    catch (Exception e)
                    {
                        LogIt("ERROR: " + e);
                    }
                }
            }
        }

        public void GetCSInfo()
        {

            int fwType = (int)Registry.GetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Control", "PEFirmwareType", 0);

            switch (fwType)
            {
                case 1:
                    BootMode.Text = "Boot Mode: BIOS";
                    break;
                case 2:
                    BootMode.Text = "Boot Mode: UEFI";
                    break;
                default:
                    BootMode.Text = "Boot Mode: Unknown";
                    break;
            }

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
                        //SN.Text = "SN: " + mo["SerialNumber"];
                        LogIt(BIOSInfo.Text);
                        LogIt(BIOSVersionLabel.Text);
                        LogIt("SN: " + mo["SerialNumber"]);
                    }
                }
            }
            catch (Exception e)
            {
                LogIt("ERROR: " + e);
                return;
            }
        }

        public void GetDiskInfo()
        {
            diskTree.Nodes.Clear();
            bool TSMediaFound = false;
            LogIt("Reading Disk Info");
            try
            {
                WqlObjectQuery qry = new WqlObjectQuery("SELECT * FROM Win32_DiskDrive");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(qry);


                //Get Disk Drives
                foreach (ManagementObject diskDrive in searcher.Get())
                {
                    string _deviceID = diskDrive["DeviceID"].ToString();
                    string _status = diskDrive["Status"].ToString();
                    string _size = diskDrive["Size"].ToString();
                    string _partitions = diskDrive["Partitions"].ToString();
                    string _model = diskDrive["Model"].ToString();

                    string Pf = _deviceID + ": ";
                    LogIt(Pf + "Status: " + _status);
                    LogIt(Pf + "Size: " + _size);
                    LogIt(Pf + "Model: " + _model);
                    LogIt(Pf + "Partitions: " + _partitions);

                    TreeNode topNode = new TreeNode();
                    if (!(_status == "OK")) { topNode.ForeColor = System.Drawing.Color.Red; }
                    topNode.Text = _deviceID;

                    topNode.Nodes.Add("Status: " + _status);
                    topNode.Nodes.Add("Size: " + _size);
                    topNode.Nodes.Add("Model: " + _model);



                    //Use the device ID to get partitions
                    qry = new WqlObjectQuery("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + _deviceID + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition");
                    searcher = new ManagementObjectSearcher(qry);
                    foreach (ManagementObject diskPartition in searcher.Get())
                    {

                        //Use the partitions id to find the logical disk
                        qry = new WqlObjectQuery("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + diskPartition["DeviceID"].ToString() + "'} WHERE AssocClass = Win32_LogicalDiskToPartition");
                        searcher = new ManagementObjectSearcher(qry);
                        foreach (ManagementObject logicalDisk in searcher.Get())
                        {
                            string _driveLetter = logicalDisk["DeviceID"].ToString();
                            string _fileSystem = logicalDisk["FileSystem"].ToString();
                            string _partSize = logicalDisk["Size"].ToString();
                            string _volName = logicalDisk["VolumeName"].ToString();

                            Pf = Pf + _driveLetter;
                            LogIt(Pf + "Name: " + _volName);
                            LogIt(Pf + "FileSystem: " + _fileSystem);
                            LogIt(Pf + "Size: " + _partSize);

                            TreeNode partNode = new TreeNode();
                            partNode.Text = _driveLetter;
                            partNode.Nodes.Add("Name: " + _volName);
                            partNode.Nodes.Add("FileSystem: " + _fileSystem);
                            partNode.Nodes.Add("Size: " + _partSize);

                            mainForm.LogIt("Checking " + _driveLetter + " for " + mainForm.CMDatPath);

                            if (File.Exists(_driveLetter + mainForm.CMDatPath + "\\variables.dat"))
                            {
                                LogIt("Found variables dat path at " + _driveLetter);
                                TSMediaFound = true;
                                TSMediaErrorLabel.Visible = true;
                                TSMediaErrorLabel.ForeColor = System.Drawing.Color.Green;
                                TSMediaErrorLabel.Text = "task sequence media found on " + _driveLetter.Split('\\')[0];
                                partNode.ForeColor = System.Drawing.Color.Green;
                            } else
                            {
                                TSMediaErrorLabel.Visible = true;
                                TSMediaErrorLabel.ForeColor = System.Drawing.Color.Red;
                                TSMediaErrorLabel.Text = "Could not locate task sequence media. (click to refresh)";
                            }

                            topNode.Nodes.Add(partNode);
                        }
                    }

                    diskTree.Nodes.Add(topNode);
                }

            }
            catch (System.Exception ex)
            {
                LogIt("Error: " + ex.Message);
            }

            if (!TSMediaFound)
            {
                try
                {
                    LogIt("Checking Optical Media for variables.dat");
                    WqlObjectQuery qry = new WqlObjectQuery("SELECT * FROM Win32_LogicalDisk WHERE DriveType = 5");
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(qry);

                    foreach (ManagementObject diskDrive in searcher.Get())
                    {
                        string _driveletter = diskDrive["DeviceID"].ToString();
                        mainForm.LogIt("Checking " + _driveletter + " for " + mainForm.CMDatPath);

                        if (File.Exists(_driveletter + mainForm.CMDatPath + "\\variables.dat"))
                        {
                            TSMediaFound = true;
                            TSMediaErrorLabel.Visible = true;
                            LogIt("Found variables dat path at " + _driveletter);
                            LogIt("WARN: variables.dat is on optical media!");
                            TSMediaErrorLabel.ForeColor = System.Drawing.Color.Green;
                            TSMediaErrorLabel.Text = "task sequence media found on " + _driveletter.Split('\\')[0];

                        }
                    }
                }
                catch (System.Exception ex)
                {
                    LogIt("Error: " + ex.Message);
                }
            }

        }

        public void SelfUpdate()
        {
            var meProcess = Process.GetCurrentProcess();
            string mePath = meProcess.MainModule.FileName;
            string UpdateScript = Environment.CurrentDirectory + "\\Get-Updates.ps1"; //external script to make it easier to maintain.
            if (File.Exists(UpdateScript))
            {
                LogIt("Running update sync");
                string args = "-ExecutionPolicy ByPass -File " + UpdateScript;
                mainForm.RunCommand(@"\WINDOWS\system32\WindowsPowerShell\v1.0\powershell.exe", args, System.Environment.CurrentDirectory, true);
                LogIt("Update complete");
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            TestNetworkConnection(NetTestHost, 80);
            HWGroupBox.Text = System.Environment.MachineName;
            GetCSInfo();
            GetNWInfo();
            GetDiskInfo();


            OptsDlg.textBox1.Text = LoggingShare;
            populateDropDownFromXML(OptsDlg.CMSites, @"/settings/ConfigMgr/Site");
            populateDropDownFromXML(OptsDlg.SMToolsSites, @"/settings/SMTools/URI");
            populateDropDownFromXML(OptsDlg.TargetingModes, @"/settings/SMTools/Targeting/Mode");
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            LogIt("Process Canceled");
            OptsDlg.Dispose();
            this.Close();
        }

        private int WebServiceCall(string queryString)
        {
            int retVal = 1;


            try
            {
                WebRequest req = WebRequest.Create(queryString);
                req.Method = "POST";
                req.Timeout = 30000;
                req.ContentType = "application/xml";
                LogIt("Sending web request to " + req.RequestUri);
                LogIt("Timout: " + req.Timeout);
                LogIt("Method: " + req.Method);
                LogIt("ContentType: " + req.ContentType);
                LogIt("ContentLength: " + req.ContentLength);

                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    LogIt("the web request was accepted");

                    retVal = 0;
                    using (Stream respStream = resp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                        LogIt(reader.ReadToEnd());
                    }
                }
                else
                {
                    retVal = (int)resp.StatusCode;
                    using (Stream respStream = resp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                        LogIt("Error: " + reader.ReadToEnd());
                    }
                }
            }
            catch (WebException we)
            {
                if (we.Status.ToString() == "Timeout")
                {
                    LogIt("Error: the request timed out");
                    retVal = 1;  //I know error 1 isn't decriptive at all, just read the log....
                }
                else
                {
                    LogIt(we.Message);
                    if (we.Status == System.Net.WebExceptionStatus.NameResolutionFailure) { retVal = 1; }
                    else if ((HttpWebResponse)we.Response != null) { retVal = (int)((HttpWebResponse)we.Response).StatusCode; } //make sure we talked to the service before checking status code.
                    else { retVal = 1; }
                }
            }
            catch (Exception ex)
            {
                LogIt("Error: " + ex.Message);
                retVal = 1;
            }


            return retVal;
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


            if (!string.IsNullOrEmpty(primaryUser.Text))
            {
                if (primaryUser.Text.IndexOf("\\") > 0)
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

            if (!string.IsNullOrEmpty(installerID.Text))
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
                            queryStringPF = "?macAddress=" + PrimaryMACAddress.Replace(":", "-");
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
                            queryStringPF = "?smBiosGuid=" + UUIDTextBox.Text;
                        }
                        else
                        {
                            UUIDError.Visible = true;
                            Submit = false;
                            LogIt("missing data for UUID field (" + UUIDTextBox.Text + ")");
                        }
                        break;
                }

                string queryString = queryStringPF.Trim() + "&primaryUserDomain=" + userDomain.Trim() + "&primaryUserID=" + userName.Trim() + "&smtoolsUserID=" + SMToolsiD.Trim();
                LogIt("Calling " + SMToolsURI + queryString);
                int rtnVal = WebServiceCall(SMToolsURI + queryString);

                if (rtnVal == 0)
                {
                    toolStripStatusLabel1.Text = "Data sent to SMTools successfully. Complete provisioning in SMtools, then close this Dialog";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Green;
                    OKButton.Enabled = false;
                    Continue.Enabled = true;
                }
                else
                {
                    toolStripStatusLabel1.Text = "There was an error processing the request. (" + rtnVal + ")";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Submit_ToSMTools();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Attention: The options available in this dialog should only be used at the direction of Engineering or CM Support.", "Advanced Options", MessageBoxButtons.OKCancel);
            if (ans == DialogResult.OK)
            {
                //this.WindowState = FormWindowState.Minimized;

                LogIt("Loading options dialog");
                OptsDlg.TopMost = true;
                OptsDlg.ShowDialog(this); //Wait for this to close before continuing
                this.OKButton.Enabled = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void TSMediaErrorLabel_Click(object sender, EventArgs e)
        {
            TSMediaErrorLabel.Text = "Scanning....";
            GetDiskInfo();
        }

        private void openShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIt("open shell selected");
            try
            {
                var processInfo = new ProcessStartInfo("cmd.exe")
                {
                    CreateNoWindow = false,
                    UseShellExecute = true,
                    WorkingDirectory = Environment.SystemDirectory,
                };
                this.TopMost = false;
                var process = Process.Start(processInfo);
                int processID = process.Id;

            } catch (System.Exception ex)
            { LogIt(ex.Message); }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            GetDiskInfo();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            GetNWInfo();
            TestNetworkConnection(NetTestHost, 80);
        }

        private void mainForm_Closing(object sender, EventArgs e)
        {
            LogIt("Exiting with Close Control");
            OptsDlg.Dispose(); 
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            OptsDlg.Dispose();
            string PostCommand = ReadValueFromXML("PostCommand");
            string PostCommandArgs = ReadValueFromXML("PostCommandArgs");
            string PostCommandWD = ReadValueFromXML("PostCommandWD");

            if (!String.IsNullOrEmpty(PostCommand))
            {
                this.WindowState = FormWindowState.Minimized;
                RunCommand(PostCommand, PostCommandArgs, PostCommandWD);
            }
            this.Close();
            this.Dispose();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog(this);
            about.TopMost = true;
            if (mainForm.DoUpdate)
            {
                SelfUpdate();
            }
        }

        private void startRemoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var command = new[] { ReadValueFromXML("RemoteCommand") };
            string daemon = ReadValueFromXML("RemoteCommand", "daemon");
            int c = 0;
            if ( (File.Exists(ReadValueFromXML("RemoteCommand") ) ) )
            {
                Process[] server = Process.GetProcessesByName(daemon);
                if (server.Length == 0)  //if the daemon service isn't already running, start it. This avoids a pop-up message from VNC.
                {
                    ManagementClass mc;
                    try
                    {
                        mc = new ManagementClass("Win32_Process");
                        mc.InvokeMethod("Create", command);
                    }
                    catch (System.Exception ex)
                    {
                        LogIt("ERROR: " + ex);
                        return;
                    }


                    do
                    {
                        Thread.Sleep(5000);
                        server = Process.GetProcessesByName(daemon);
                        if (server.Length > 0)
                        {
                            MessageBox.Show(this, "Remote service active: My IP: " + ThisIPAddress, "OSD Automation Support", MessageBoxButtons.OK);
                            return;
                        }
                        c++;
                    } while ((server.Length == 0) && (c < 10));
                } else { MessageBox.Show(this, "Remote service active: (" + ThisIPAddress + ")", "OSD Automation Support", MessageBoxButtons.OK); }
            } else { MessageBox.Show(command + " not found!"); }
        }
    }
}
