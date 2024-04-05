using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NatyBeautyController;

namespace NatyBeauty.UI
{
    public partial class CreateUser : NatyBeauty.MasterForm
    {
        private int _id;
        public CreateUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// CreateUser constructor to be used for Update User
        /// </summary>
        /// <param name="id">User's id to be updated.</param>
        /// <param name="name">User's name to be updated.</param>
        /// <param name="login">User's login to be updated.</param>
        /// <param name="password">User's password to be updated.</param>
        /// <param name="admin">User's admin to be updated.</param>
        public CreateUser(int id, string name, string login, string password, bool admin)
        {
            InitializeComponent();

            _id = id;
            txtName.Text = name;
            txtLogin.Text = login;
            txtPassword.Text = password;
            chkAdmin.Checked = admin;

            lblHeader.Text = "Edit User";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorName.SetError(txtName, "");
            errorLogin.SetError(txtLogin, "");
            errorPassword.SetError(txtPassword, "");

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorName.SetError(txtName, "User Name cannot be empty.");
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                errorLogin.SetError(txtLogin, "User Login cannot be empty.");
                txtLogin.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorPassword.SetError(txtPassword, "Password cannot be empty.");
                txtPassword.Focus();
                return;
            }

            bool userCreated = false;
            
            if (_id == 0)
                userCreated = UsersController.CreateUsers(txtName.Text, txtLogin.Text, txtPassword.Text, chkAdmin.Checked);
            else
                userCreated = UsersController.UpdateUser(_id, txtName.Text, txtLogin.Text, txtPassword.Text, chkAdmin.Checked);

            DialogResult result = new DialogResult();

            if (userCreated)            
            {
                if (_id == 0)
                    result = new CustomDialog(this, MessageBoxButtons.YesNo, "User created successfully. Do you want to create another user?").ShowDialog(); 
                else
                    result = new CustomDialog(this, MessageBoxButtons.OK, "User updated successfully.").ShowDialog();

                if (result == DialogResult.Yes) 
                {
                    txtName.Text = string.Empty;
                    txtLogin.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    chkAdmin.Checked = false;
                }
                else
                {
                    ListUsers listUser = new ListUsers();
                    
                }                
            }
            else
            {
                if (_id == 0)
                    result = new CustomDialog(this, MessageBoxButtons.OK, "Error on user creation.").ShowDialog();
                else
                    result = new CustomDialog(this, MessageBoxButtons.OK, "Error on user update.").ShowDialog();

                ListUsers listUser = new ListUsers();
                ChangeForm(listUser);
            }
        }
    }
}
