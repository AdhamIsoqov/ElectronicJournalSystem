using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ElectronicJournalSystem.Forms.Admin
{
    public partial class Fanlar : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;
        private int selectedFanId = -1;

        public Fanlar()
        {
            InitializeComponent();
        }

        private void Fanlar_Load(object sender, EventArgs e)
        {
            FanlarDataGridViewLoad();
            LoadOqituvchilarIntoComboBox();
        }

        private void FanlarDataGridViewLoad()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            f.Id, f.Name AS FanName, t.FullName AS Oqituvchi, f.Credit 
                        FROM Subjects f
                        LEFT JOIN Teachers t ON f.TeacherId = t.Id";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    FanlarDataGridView.DataSource = dt;
                    FanlarDataGridView.Columns["Id"].HeaderText = "ID";
                    FanlarDataGridView.Columns["FanName"].HeaderText = "Fan nomi";
                    FanlarDataGridView.Columns["Oqituvchi"].HeaderText = "O‘qituvchi";
                    FanlarDataGridView.Columns["Credit"].HeaderText = "Kredit";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
                }
            }
        }

        private void LoadOqituvchilarIntoComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id, FullName FROM Teachers";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    oqituvchiComboBox.DisplayMember = "FullName";
                    oqituvchiComboBox.ValueMember = "Id";
                    oqituvchiComboBox.DataSource = dt;
                    oqituvchiComboBox.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("O‘qituvchilarni yuklashda xatolik: " + ex.Message);
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string fanName = fannarNametxt.Text.Trim();
            int credit = int.Parse(kreditTxt.Text);
            int teacherId = (int)oqituvchiComboBox.SelectedValue;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Subjects (Name, TeacherId, Credit) VALUES (@Name, @TeacherId, @Credit)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", fanName);
                        cmd.Parameters.AddWithValue("@TeacherId", teacherId);
                        cmd.Parameters.AddWithValue("@Credit", credit);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Fan muvaffaqiyatli qo‘shildi!");
                ClearInputs();
                FanlarDataGridViewLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
            }
        }

        private void FanlarDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = FanlarDataGridView.Rows[e.RowIndex];
                selectedFanId = Convert.ToInt32(row.Cells["Id"].Value);
                fannarNametxt.Text = row.Cells["FanName"].Value.ToString();
                kreditTxt.Text = row.Cells["Credit"].Value.ToString();

                string teacherName = row.Cells["Oqituvchi"].Value?.ToString();
                int index = oqituvchiComboBox.FindStringExact(teacherName);
                oqituvchiComboBox.SelectedIndex = (index != -1) ? index : -1;
            }
        }

        private void upgBtn_Click(object sender, EventArgs e)
        {
            if (selectedFanId == -1) return;

            string fanName = fannarNametxt.Text.Trim();
            int credit = int.Parse(kreditTxt.Text);
            int teacherId = (int)oqituvchiComboBox.SelectedValue;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Subjects SET Name=@Name, TeacherId=@TeacherId, Credit=@Credit WHERE Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", fanName);
                        cmd.Parameters.AddWithValue("@TeacherId", teacherId);
                        cmd.Parameters.AddWithValue("@Credit", credit);
                        cmd.Parameters.AddWithValue("@Id", selectedFanId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Fan ma’lumotlari yangilandi!");
                ClearInputs();
                FanlarDataGridViewLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {

        }

        private void ClearInputs()
        {
            fannarNametxt.Clear();
            kreditTxt.Clear();
            oqituvchiComboBox.SelectedIndex = -1;
            selectedFanId = -1;
        }
    }
}
