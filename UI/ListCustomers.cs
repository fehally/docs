using NatyBeautyController;
using System;
using System.Data;
using System.Windows.Forms;

namespace NatyBeauty.UI
{
    public partial class ListCustomers : NatyBeauty.MasterForm
    {
        public ListCustomers()
        {
            InitializeComponent();
        }

        private void ListCustomers_Load(object sender, EventArgs e)
        {
            DataTable dt = CustomersController.GetAllCustomers();

            gridCustomers.DataSource = dt;
            gridCustomers.Columns["ID"].Visible = false;            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CreateCustomers createCustomer = new CreateCustomers();
            ChangeForm(createCustomer);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            lblEditMessage.Visible = false;
            lblDeleteMessage.Visible = false;

            if (gridCustomers.SelectedRows.Count <= 0)
            {
                lblEditMessage.Visible = true;
                return;
            }

            int id = int.Parse(gridCustomers.Rows[gridCustomers.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());
            string name = gridCustomers.Rows[gridCustomers.SelectedCells[0].RowIndex].Cells["Name"].Value.ToString();
            string lastName = gridCustomers.Rows[gridCustomers.SelectedCells[0].RowIndex].Cells["LastName"].Value.ToString();
            string phone1 = gridCustomers.Rows[gridCustomers.SelectedCells[0].RowIndex].Cells["Phone1"].Value.ToString();
            string phone2 = gridCustomers.Rows[gridCustomers.SelectedCells[0].RowIndex].Cells["Phone2"].Value.ToString();
            string email = gridCustomers.Rows[gridCustomers.SelectedCells[0].RowIndex].Cells["Email"].Value.ToString();
            DateTime birthdate = DateTime.Parse(gridCustomers.Rows[gridCustomers.SelectedCells[0].RowIndex].Cells["Birthdate"].Value.ToString());
            string comments = gridCustomers.Rows[gridCustomers.SelectedCells[0].RowIndex].Cells["Comments"].Value.ToString();

            CreateCustomers create = new CreateCustomers(id, name, lastName, phone1, phone2, email, birthdate, comments);
            ChangeForm(create);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lblEditMessage.Visible = false;
            lblDeleteMessage.Visible = false;

            if (gridCustomers.SelectedRows.Count <= 0)
            {
                lblDeleteMessage.Visible = true;
                return;
            }

            DialogResult result = new CustomDialog(this, MessageBoxButtons.YesNo, "Are you sure you want to delete this Customer?").ShowDialog();

            if (result == DialogResult.Yes)
            {
                int _id = int.Parse(gridCustomers.Rows[gridCustomers.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());

                bool ret = CustomersController.DeleteCustomer(_id);

                if (ret)
                {
                    result = new CustomDialog(this, MessageBoxButtons.OK, "Customer deleted successfully.").ShowDialog();
                    ListCustomers listCustomer = new ListCustomers();
                    ChangeForm(listCustomer);
                }
                else
                {
                    result = new CustomDialog(this, MessageBoxButtons.OK, "Error on Customer delete.").ShowDialog();
                }
            }
            else
            {
                ListCustomers listCustomer = new ListCustomers();
                ChangeForm(listCustomer);
            }
        }
    }
}
