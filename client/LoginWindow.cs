using System;
using System.Windows.Forms;
using festival.client;
using FESTIVAL_CS;

namespace client
{
    public partial class LoginWindow : Form
    {

        private FestivalClientCtrl ctrl;
        public LoginWindow(FestivalClientCtrl ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
        }
        

        private void handle_login(object sender, EventArgs e)
        {

            String username = this.usernameText.Text;
            String password = this.passwordText.Text;
            if (username.Equals("") || password.Equals(""))
                MessageBox.Show("Invalid username or password", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ctrl.login(username, password);
                this.passwordText.Clear();
                this.usernameText.Clear();
                mainWindow chatWin=new mainWindow(ctrl);
                chatWin.win = this;
                chatWin.Text = "Festval control window for " + username;
                chatWin.Show();
                this.Hide();
            }
        }

    }
}