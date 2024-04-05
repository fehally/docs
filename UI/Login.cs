using System;
using System.Drawing;
using System.Windows.Forms;
using NatyBeautyController;

namespace NatyBeauty
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button Login, validate inputs and call LoginController to ValidateLogin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsernameErrorProvider.SetError(txtLogin, string.Empty);
            PasswordErrorProvider.SetError(txtPassword, string.Empty);

            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                UsernameErrorProvider.SetError(txtLogin, "Username cannot be empty.");
                txtLogin.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                PasswordErrorProvider.SetError(txtPassword, "Password cannot be empty.");
                txtPassword.Focus();
                return;
            }

            bool isAuthenticated = UsersController.ValidateLogin(txtLogin.Text, txtPassword.Text);

            if (isAuthenticated)
            {
                this.Hide(); 
                MainPage mainPage = new MainPage();
                //mainPage.Closed += (s, args) => this.Close();
                mainPage.Show();
            }
            else
            {
                lblErrorMessage.Visible = true;
            }
        }

        /// <summary>
        /// Event triggered when enter the Username textbox. Removes placeholder and sets font to default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLogin_Enter(object sender, EventArgs e)
        {
            if (txtLogin.Text == "Username")
            {
                txtLogin.Text = string.Empty;
                txtLogin.Font = new Font(txtLogin.Font, FontStyle.Regular);
            }
        }

        /// <summary>
        /// Event triggered when enter the Password textbox. Removes placeholder, sets font to default and enable password chars.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = string.Empty;
                txtPassword.Font = new Font(txtPassword.Font, FontStyle.Regular);
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// Event triggered on Display Load. Centralize the controls with the container.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Load(object sender, EventArgs e)
        {
            int alignControls(int width) => (ClientSize.Width - width) / 2;

            picLogo.Left = alignControls(picLogo.Width);
            txtLogin.Left = alignControls(txtLogin.Width);
            txtPassword.Left = alignControls(txtPassword.Width);
            btnLogin.Left = alignControls(btnLogin.Width);
            lblErrorMessage.Left = alignControls(lblErrorMessage.Width);
        }

        /// <summary>
        /// Event triggered when leaves the Password textbox. Add placeholder and sets font to italic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLogin_Leave(object sender, EventArgs e)
        {
            if (txtLogin.Text == string.Empty)
            {
                txtLogin.Text = "Username";
                txtLogin.Font = new Font(txtLogin.Font, FontStyle.Italic);
            }
        }

        /// <summary>
        /// Event triggered when leaves the Password textbox. Add placeholder, sets font to italic and disable password chars.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == string.Empty)
            {
                txtPassword.Text = "Password";
                txtPassword.Font = new Font(txtPassword.Font, FontStyle.Italic);
                txtPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
