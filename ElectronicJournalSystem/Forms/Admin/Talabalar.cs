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
using static System.Net.Mime.MediaTypeNames;

namespace ElectronicJournalSystem.Forms.Admin
{
    public partial class Talabalar : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;
        private int selectedTalabaId = -1;
        public Talabalar()
        {
            InitializeComponent();
        }
        private void Talabalar_Load(object sender, EventArgs e)
        {
            TalabaDataGridViewLoad();
            LoadGroupsIntoComboBox();
        }
        private void TalabaDataGridViewLoad()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            s.Id, s.FullName, g.Name as GroupName, s.Login, s.Password 
                        FROM Students s
                        LEFT JOIN Groups g ON s.GroupId = g.Id";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    TalabaDataGridView.DataSource = dt;
                    TalabaDataGridView.Columns["Id"].HeaderText = "ID";
                    TalabaDataGridView.Columns["FullName"].HeaderText = "F.I.Sh";
                    TalabaDataGridView.Columns["GroupName"].HeaderText = "Guruh nomi";
                    TalabaDataGridView.Columns["Login"].HeaderText = "Login";
                    TalabaDataGridView.Columns["Password"].HeaderText = "Parol";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
                }
            }
        }
        private void LoadGroupsIntoComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id, Name FROM Groups";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        guruhNomiComboBox.DisplayMember = "Name";
                        guruhNomiComboBox.ValueMember = "Id";
                        guruhNomiComboBox.DataSource = dt;
                        guruhNomiComboBox.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Guruhlarni yuklashda xatolik: " + ex.Message);
                }
            }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            string fullName = TalabaFISHtxt.Text.Trim();
            string login = talabaLogintxt.Text.Trim();
            string password = talabaParoltxt.Text.Trim();
            int? groupId = (guruhNomiComboBox.SelectedValue != null && guruhNomiComboBox.SelectedIndex != -1) ? (int?)guruhNomiComboBox.SelectedValue : null;
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || groupId == null)
            {
                MessageBox.Show("Iltimos, barcha maydonlarni to‘ldiring.", "Ogohlantirish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Students (FullName, GroupId, Login, Password) VALUES (@FullName, @GroupId, @Login, @Password)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@GroupId", groupId);
                        cmd.Parameters.AddWithValue("@Login", login);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Talaba muvaffaqiyatli qo‘shildi!", "Ma’lumot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                TalabaDataGridViewLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik yuz berdi: " + ex.Message, "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TalabaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = TalabaDataGridView.Rows[e.RowIndex];
                selectedTalabaId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                TalabaFISHtxt.Text = selectedRow.Cells["FullName"].Value?.ToString();
                string groupName = selectedRow.Cells["GroupName"].Value?.ToString();
                if (!string.IsNullOrEmpty(groupName))
                {
                    int index = guruhNomiComboBox.FindStringExact(groupName);
                    if (index != -1)
                        guruhNomiComboBox.SelectedIndex = index;
                    else
                        guruhNomiComboBox.SelectedIndex = -1;
                }
                else
                {
                    guruhNomiComboBox.SelectedIndex = -1;
                }

                talabaLogintxt.Text = selectedRow.Cells["Login"].Value?.ToString();
                talabaParoltxt.Text = selectedRow.Cells["Password"].Value?.ToString();
            }
        }

        private void upgBtn_Click(object sender, EventArgs e)
        {
            if (selectedTalabaId == -1)
            {
                MessageBox.Show("Iltimos, yangilash uchun jadvaldan talabani tanlang.");
                return;
            }
            string fullName = TalabaFISHtxt.Text.Trim();
            string login = talabaLogintxt.Text.Trim();
            string password = talabaParoltxt.Text.Trim();
            int? groupId = (guruhNomiComboBox.SelectedValue != null && guruhNomiComboBox.SelectedIndex != -1) ? (int?)guruhNomiComboBox.SelectedValue : null;
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || groupId == null)
            {
                MessageBox.Show("Barcha maydonlarni to‘ldiring.");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Students SET FullName=@FullName, GroupId=@GroupId, Login=@Login, Password=@Password WHERE Id=@Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@GroupId", groupId);
                        cmd.Parameters.AddWithValue("@Login", login);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Id", selectedTalabaId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Talaba ma’lumoti muvaffaqiyatli yangilandi.");
                            TalabaDataGridViewLoad();
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Yangilash amalga oshmadi.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (selectedTalabaId == -1)
            {
                MessageBox.Show("Iltimos, o‘chirish uchun talabani jadvaldan tanlang.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Students WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", selectedTalabaId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Talaba muvaffaqiyatli o‘chirildi.");
                            TalabaDataGridViewLoad();
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("O‘chirish amalga oshmadi.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
            }
        }
        private void ClearInputs()
        {
            TalabaFISHtxt.Clear();
            talabaLogintxt.Clear();
            talabaParoltxt.Clear();
            guruhNomiComboBox.SelectedIndex = -1;
            selectedTalabaId = -1;
        }
    }
}