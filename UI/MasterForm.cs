using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NatyBeauty.UI;
using NatyBeautyController;

namespace NatyBeauty
{
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();

            toolTipSettings.SetToolTip(picSettings, "System settings.");
            toolTipShutdown.SetToolTip(picShutdown, "Shutdown.");
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLocalTime().ToShortTimeString();            
        }

        private void picShutdown_Click(object sender, EventArgs e)
        {
            panelDisconnect.Visible = !panelDisconnect.Visible;            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void picSettings_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = !panelSettings.Visible;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = false;
            ListUsers listUsers = new ListUsers();
            ChangeForm(listUsers);
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UsersController.LogoutUser();

            Form frm = Application.OpenForms[0];

            while (Application.OpenForms.Count > 1)
            {
                Application.OpenForms[1].Close();
            }

            foreach (Control c in frm.Controls)
            { 
                if(c.GetType() == typeof(TextBox))
                {
                    if (c.Name == "txtLogin")
                    {
                        c.Text = "Username";
                    }
                    else if (c.Name == "txtPassword")
                    {
                        c.Text = "Password";
                    }

                    c.Font = new Font(c.Font, FontStyle.Italic);
                }
            }
            frm.Show();
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
                picSettings.Visible = UsersController.ValidateCurrentUserIsAdmin();

            if (Application.OpenForms.OfType<ListCustomers>().Any())
            {
                btnCustomers.BackColor = Color.FromArgb(245, 222, 230);
                btnCustomers.ForeColor = Color.FromArgb(88, 0, 0);
            }
            else
            {
                btnCustomers.BackColor = Color.FromArgb(215, 137, 151);
                btnCustomers.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ListCustomers>().Any())
                return;

            ListCustomers listCustomers = new ListCustomers();
            ChangeForm(listCustomers);            
        }

        public void ChangeForm(Form fmOpen)
        {
            Form frm = Application.OpenForms[1];

            Point point = new Point(frm.Left, frm.Top);

            fmOpen.Location = point;
            fmOpen.StartPosition = FormStartPosition.Manual;            
            frm.Close();
            fmOpen.Show();
        }
    }
}
