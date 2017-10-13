using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace PatientMonitor
{
    public partial class LogIn : Form
    {
        //String connectionString;
        public LogIn()
        {
            InitializeComponent();
            
        }
        
        //VARIABLES (the systems username and password)
        private string username = "hospital1";
        private string password = "password1";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if the username and password input is the same as the assigned username and password it will launch the main window
            if (username == txtUser.Text && password == txtPassword.Text)
            {
                Main m = new Main();
                m.Show();
                this.Hide();

            }
            //if the username and password input is NOT the assigned username and password it will display a message
            else
            {
                MessageBox.Show("username: hospital1 / password: password1");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }
    }
}
