using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PreStartUI
{

    public partial class Credentials : Form
    {
        public Credentials()
        {
            InitializeComponent();
        }

        private void ConnectShare()
        {
            NetworkShareAccesser loggingServer = NetworkShareAccesser.Access(mainForm.LoggingShare);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
        }
    }
}
