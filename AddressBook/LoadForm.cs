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
    public partial class LoadForm : Form
    {

        public LoadForm()
        {
            InitializeComponent();
            this.Text = this.Text + " v." + this.ProductVersion;
        }

        private void LoadForm_Shown(object sender, EventArgs e)
        {           
            DM.GetInstance().LoadUsers();//приуэт
        }

          

    }

}

