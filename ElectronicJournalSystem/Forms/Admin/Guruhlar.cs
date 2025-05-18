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

namespace ElectronicJournalSystem.Forms.Admin
{
    public partial class Guruhlar : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;
        private int selectedGroupId = -1;

        public Guruhlar()
        {
            InitializeComponent();
        }

        private void Guruhlar_Load(object sender, EventArgs e)
        {
            LoadGroupsData();
        }

        private void LoadGroupsData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id, Name, Direction, Course FROM Groups";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    GuruhDataGridView.DataSource = dt;
                    GuruhDataGridView.Columns["Id"].HeaderText = "ID";
                    GuruhDataGridView.Columns["Name"].HeaderText = "Guruh Nomi";
                    GuruhDataGridView.Columns["Direction"].HeaderText = "Yo'nalish";
                    GuruhDataGridView.Columns["Course"].HeaderText = "Kurs";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
                }
            }
        }

        private void ClearInputs()
        {
            textBox1.Clear();
            yonalishtxt.Clear();
            kurstxt.Clear();
            selectedGroupId = -1;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string direction = yonalishtxt.Text.Trim();
            int course;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(direction) || !int.TryParse(kurstxt.Text.Trim(), out course))
            {
                MessageBox.Show("Iltimos, barcha maydonlarni to'ldiring.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Groups (Name, Direction, Course) VALUES (@Name, @Direction, @Course)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Direction", direction);
                        cmd.Parameters.AddWithValue("@Course", course);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Guruh muvaffaqiyatli qo'shildi!");
                    LoadGroupsData();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
                }
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (selectedGroupId == -1)
            {
                MessageBox.Show("Iltimos, jadvaldan guruhni tanlang.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Groups WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", selectedGroupId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Guruh muvaffaqiyatli o'chirildi!");
                    LoadGroupsData();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
                }
            }
        }

        private void GuruhDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = GuruhDataGridView.Rows[e.RowIndex];
                selectedGroupId = Convert.ToInt32(row.Cells["Id"].Value);
                textBox1.Text = row.Cells["Name"].Value.ToString();
                yonalishtxt.Text = row.Cells["Direction"].Value.ToString();
                kurstxt.Text = row.Cells["Course"].Value.ToString();
            }
        }

        private void upgBtn_Click(object sender, EventArgs e)
        {
            if (selectedGroupId == -1)
            {
                MessageBox.Show("Iltimos, jadvaldan guruhni tanlang.");
                return;
            }

            string name = textBox1.Text.Trim();
            string direction = yonalishtxt.Text.Trim();
            int course;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(direction) || !int.TryParse(kurstxt.Text.Trim(), out course))
            {
                MessageBox.Show("Iltimos, barcha maydonlarni to'ldiring.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Groups SET Name=@Name, Direction=@Direction, Course=@Course WHERE Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Direction", direction);
                        cmd.Parameters.AddWithValue("@Course", course);
                        cmd.Parameters.AddWithValue("@Id", selectedGroupId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Guruh muvaffaqiyatli yangilandi!");
                    LoadGroupsData();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
                }
            }
        }
    }
}
