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
    public partial class ChoiseBossForm : Form
    {
        CustomUserList FoundUsers = new CustomUserList();

        CustomUser ChosenUser = null;

        public ChoiseBossForm()
        {
            InitializeComponent();
        }


        

        private void btCheckNames_Click(object sender, EventArgs e)
        {
            if (tbInput.Text == string.Empty)
            {
                MessageBox.Show("Введите имя для поиска!");
                return;
            }
            FoundUsers = DE.SearchUsers(tbInput.Text);

            int Y = 0;
            int X = 0;
            foreach (CustomUser user in FoundUsers)
            {
                LinkLabel link = new LinkLabel();
                link.Name = link + user.SAMAccountName;
                link.Tag = user.SAMAccountName;
                link.Text = user.DislpayName;
                link.AutoSize = true;
                link.LinkClicked += linkLabel1_LinkClicked;
                

                if (Y != 0)
                    link.Location = new Point(X, Y);

                Y += link.Size.Height;
                X = link.Location.X;

                pnResults.Controls.Add(link);
            }
        }

        private void ChoiseBossForm_Shown(object sender, EventArgs e)
        {
            FoundUsers.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string Samaccount = (sender as LinkLabel).Tag.ToString();
            ChosenUser = FoundUsers.GetUserBySamaccountName(Samaccount);
            CurrentBoss.boss = ChosenUser;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }
           

    }

}

