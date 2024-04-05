using NatyBeautyController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NatyBeauty.UI
{
    public partial class CreateCustomers : NatyBeauty.MasterForm
    {
        private int _id;

        public CreateCustomers()
        {
            InitializeComponent();
        }

        public CreateCustomers(int id, string name, string lastName, string phone1, string phone2, string email, DateTime birthdate, string comments)
        {
            InitializeComponent();

            _id = id;
            txtName.Text = name;
            txtLastName.Text = lastName;
            txtPhone.Text = phone1;
            txtPhone2.Text = phone2;
            txtEmail.Text = email;
            dtBirthdate.Value = birthdate;
            txtComments.Text = comments;
            lblHeader.Text = "Edit Customer";

            lblHeader.Left = (ClientSize.Width - lblHeader.Width) / 2;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorName.SetError(txtName, "");
            errorLastName.SetError(txtLastName, "");

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorName.SetError(txtName, "Customer Name cannot be empty.");
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorLastName.SetError(txtLastName, "Customer last name cannot be empty.");
                txtLastName.Focus();
                return;
            }

            bool customerCreated = false;

            if (_id == 0)
                customerCreated = CustomersController.CreateCustomer(txtName.Text, txtLastName.Text, txtPhone.Text, txtPhone2.Text, txtEmail.Text, dtBirthdate.Value, txtComments.Text);
            else
                customerCreated = CustomersController.UpdateCustomer(_id, txtName.Text, txtLastName.Text, txtPhone.Text, txtPhone2.Text, txtEmail.Text, dtBirthdate.Value, txtComments.Text);

            DialogResult result = new DialogResult();

            if (customerCreated)
            {
                if (_id == 0)
                    result = new CustomDialog(this, MessageBoxButtons.YesNo, "Customer created successfully. Do you want to create another customer?").ShowDialog();
                else
                    result = new CustomDialog(this, MessageBoxButtons.OK, "Customer updated successfully.").ShowDialog();

                if (result == DialogResult.Yes)
                {
                    txtName.Text = string.Empty;
                    txtLastName.Text = string.Empty;
                    txtPhone.Text = string.Empty;
                    txtPhone2.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    dtBirthdate.Value = DateTime.Now;
                    txtComments.Text = string.Empty;
                }
                else
                {
                    ListCustomers listCustomer = new ListCustomers();
                    ChangeForm(listCustomer);
                }
            }
            else
            {
                if (_id == 0)
                    result = new CustomDialog(this, MessageBoxButtons.OK, "Error on customer creation.").ShowDialog();
                else
                    result = new CustomDialog(this, MessageBoxButtons.OK, "Error on customer update.").ShowDialog();

                ListCustomers listCustomer = new ListCustomers();
                ChangeForm(listCustomer);
            }
        }
    }
}
