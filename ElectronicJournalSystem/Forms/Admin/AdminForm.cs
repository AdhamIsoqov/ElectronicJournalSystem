using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using ElectronicJournalSystem.Data;
using ElectronicJournalSystem.Models;

namespace ElectronicJournalSystem.Forms.Admin
{
    public partial class AdminForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;
        DBHelper db = new DBHelper();

        public AdminForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers(string filter = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, FullName, Phone, Login, Role FROM Users";

                if (!string.IsNullOrEmpty(filter))
                {
                    query += " WHERE FullName LIKE @filter OR Login LIKE @filter OR Phone LIKE @filter";
                }

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                if (!string.IsNullOrEmpty(filter))
                    adapter.SelectCommand.Parameters.AddWithValue("@filter", "%" + filter + "%");

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvUsers.DataSource = dt;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addForm = new AddUserForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
                DialogResult dr = MessageBox.Show("Foydalanuvchini o‘chirishni xohlaysizmi?", "Tasdiqlash", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    db.DeleteUser(userId);
                    LoadUsers();
                }
            }
            else
            {
                MessageBox.Show("O‘chirish uchun foydalanuvchini tanlang.");
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
                User user = db.GetUserById(userId);

                if (user != null)
                {
                    EditUserForm editForm = new EditUserForm(user);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadUsers();
                    }
                }
            }
            else
            {
                MessageBox.Show("Tahrirlash uchun foydalanuvchini tanlang.");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUsers(txtSearch.Text.Trim());
        }
    }
}
