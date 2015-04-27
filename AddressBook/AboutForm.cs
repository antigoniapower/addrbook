using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace AddressBook
{
    public partial class AboutForm : Form
    {

        public AboutForm()
        {
            InitializeComponent();
            this.Text = this.Text + " v." + this.ProductVersion;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MailTo.Send((sender as LinkLabel).Text);
        }
           

    }

}

