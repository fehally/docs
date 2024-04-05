using System;
using System.Windows.Forms;
using NatyBeautyController;
using System.Data;

namespace NatyBeauty.UI
{
    public partial class ListUsers : NatyBeauty.MasterForm
    {
        public ListUsers()
        {
            InitializeComponent();
        }

        private void ListUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = UsersController.GetAllUsers();

            gridUsers.DataSource = dt;
            gridUsers.Columns["ID"].Visible = false;
            gridUsers.Columns["Password"].Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CreateUser createUser = new CreateUser();
            ChangeForm(createUser);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            lblEditMessage.Visible = false;
            lblDeleteMessage.Visible = false;

            if(gridUsers.SelectedRows.Count <= 0)
            {
                lblEditMessage.Visible = true;
                return;
            }

            int id = int.Parse(gridUsers.Rows[gridUsers.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());
            string name = gridUsers.Rows[gridUsers.SelectedCells[0].RowIndex].Cells["Name"].Value.ToString();
            string login = gridUsers.Rows[gridUsers.SelectedCells[0].RowIndex].Cells["Login"].Value.ToString();
            string password = UsersController.DecryptPass(gridUsers.Rows[gridUsers.SelectedCells[0].RowIndex].Cells["Password"].Value.ToString());
            bool admin = bool.Parse(gridUsers.Rows[gridUsers.SelectedCells[0].RowIndex].Cells["Admin"].Value.ToString());

            CreateUser create = new CreateUser(id, name, login, password, admin);
            ChangeForm(create);
        } 

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lblEditMessage.Visible = false;
            lblDeleteMessage.Visible = false;

            if (gridUsers.SelectedRows.Count <= 0)
            {
                lblDeleteMessage.Visible = true;
                return;
            }

            DialogResult result = new CustomDialog(this, MessageBoxButtons.YesNo, "Are you sure you want to delete this user?").ShowDialog();

            if (result == DialogResult.Yes)
            {
                int _id = int.Parse(gridUsers.Rows[gridUsers.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());

                bool ret = UsersController.DeleteUser(_id);

                if(ret)
                {
                    result = new CustomDialog(this, MessageBoxButtons.OK, "User deleted successfully.").ShowDialog();
                    ListUsers listUser = new ListUsers();
                    ChangeForm(listUser);
                }
                else
                {
                    result = new CustomDialog(this, MessageBoxButtons.OK, "Error on User delete.").ShowDialog();
                }
            }
            else
            {
                ListUsers listUser = new ListUsers();
                ChangeForm(listUser);
            }
        }
    }
}
