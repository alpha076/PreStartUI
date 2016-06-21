using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.XPath;
using System.Xml;

namespace PreStartUI
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }



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
                        if (selected == "true")
                        {
                            comboBox1.SelectedIndex = newItemIndex;
                        }
                    }
                }
            }
            catch { }
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
            catch{ }
        }

        public static int RunPowershellCommand(string command, int timeout)
        {
            var processInfo = new ProcessStartInfo("poweshell.exe", "-ExecutionPolicy Bypass " + command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = "C:\\",
            };

            var process = Process.Start(processInfo);
            process.WaitForExit(timeout);
            var exitCode = process.ExitCode;
            process.Close();
            return exitCode;
        }

        private void buttonOkOptions_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(".\\UploadLogs.ps1"))
            {
                //PreStartUI.mainForm.RunPowershellCommand("-File .\\UploadLogs.ps1 -ServerShare " + textBox1.Text + " -FolderPath \\Incoming\\" + Environment.MachineName, 100000);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count == 0){ GetCMSitesFromXML(); }
            if (comboBox1.Items.Count == 0){ GetSMToolsURIsFromXML(); }

            for(int i = 0; i < comboBox1.Items.Count; i++)
            {
                if(comboBox1.Items[i].ToString() == mainForm.SMToolsURI)
                {
                    comboBox1.SelectedIndex = i;
                }
            }


            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                if (comboBox2.Items[i].ToString() == mainForm.CMSite)
                {
                    comboBox2.SelectedIndex = i;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainForm.LogIt("CM option set to " + comboBox2.Items[comboBox2.SelectedIndex].ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainForm.LogIt("SMTools option set to " + comboBox1.Items[comboBox1.SelectedIndex].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
