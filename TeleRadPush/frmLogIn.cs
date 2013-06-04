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
using System.Data.Odbc;

namespace TeleRadPush
{
    public partial class frmLogIn : Form
    {
        bool nowConnected = false;
        string errMsg = "";
        Myconnectionclass CN = new Myconnectionclass();
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataReader Rs1;
        string UID, PWD, UType;

        public frmLogIn()
        {
            InitializeComponent();
        }

        private void Command1_Click(object sender, EventArgs e)
        {
            nowConnected = false;
            CN.OpenConnection();
            cmd = new System.Data.Odbc.OdbcCommand("SELECT * FROM UserMaster WHERE UserName='" + txtUser.Text + "' AND EncodedPass='" + txtPwd.Text + "'", CN.DBConnection);
            Rs1 = cmd.ExecuteReader();
            if (Rs1.HasRows)
            {
                modMain.UID = txtUser.Text;
                Rs1.Close();
                CN.closeconnection();
                RetrieveDialogType frmRet = new RetrieveDialogType();
                frmRet.Show();
                this.Hide();
            }
            else
            {
                Rs1.Close();
                CN.closeconnection();
                MessageBox.Show("Invalid Login");
                txtUser.Focus();
                txtUser.SelectionStart = 0;
                txtUser.SelectionLength = txtUser.Text.Length;
            }
        }

        private void frmLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Command2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void txtPwd_Enter(object sender, EventArgs e)
        {
            txtPwd.SelectionStart = 0;
            txtPwd.SelectionLength = txtPwd.Text.Length;
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            txtUser.SelectionStart = 0;
            txtUser.SelectionLength = txtUser.Text.Length;
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Command1_Click(this, e);
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Command1_Click(this, e);
        }

        private void frmLogIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                Environment.Exit(0);
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            SplashScreen spl = new SplashScreen();
            spl.Close();
        }
    }
}
