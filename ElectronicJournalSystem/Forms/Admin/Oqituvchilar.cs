using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicJournalSystem.Forms.Admin
{
    public partial class Oqituvchilar : Form
    {
        public Oqituvchilar()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;
        private int selectedOqituvchiId = -1;
        private void Oqituvchilar_Load(object sender, EventArgs e)
        {
            OqituvchilarDataGridViewLoad();
        }
        private void OqituvchilarDataGridViewLoad()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Teachers";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    OqituvchiDataGridView.DataSource = dt;
                    OqituvchiDataGridView.Columns["Id"].HeaderText = "ID";
                    OqituvchiDataGridView.Columns["FullName"].HeaderText = "F.I.Sh";
                    OqituvchiDataGridView.Columns["Specialty"].HeaderText = "Mutaxassislik";
                    OqituvchiDataGridView.Columns["Login"].HeaderText = "Login";
                    OqituvchiDataGridView.Columns["Password"].HeaderText = "Parol";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
                }
            }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            string fullName = oqituvchiFISHtxt.Text.Trim();
            string specialty = mutaxasislikTxt.Text.Trim();
            string login = oqituvchiLogintxt.Text.Trim();
            string password = oqituvchiParoltxt.Text.Trim();
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(specialty) ||
                string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Iltimos, barcha maydonlarni to‘ldiring.", "Ogohlantirish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Teachers (FullName, Specialty, Login, Password) VALUES (@FullName, @Specialty, @Login, @Password)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Specialty", specialty);
                        cmd.Parameters.AddWithValue("@Login", login);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("O‘qituvchi muvaffaqiyatli qo‘shildi!", "Ma’lumot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                oqituvchiFISHtxt.Clear();
                mutaxasislikTxt.Clear();
                oqituvchiLogintxt.Clear();
                oqituvchiParoltxt.Clear();
                OqituvchilarDataGridViewLoad();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik yuz berdi: " + ex.Message, "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void upgBtn_Click(object sender, EventArgs e)
        {
            if (selectedOqituvchiId == -1)
            {
                MessageBox.Show("Iltimos, yangilash uchun jadvaldan o‘qituvchini tanlang.");
                return;
            }

            string fullname = oqituvchiFISHtxt.Text.Trim();
            string specialty = mutaxasislikTxt.Text.Trim();
            string login = oqituvchiLogintxt.Text.Trim();
            string password = oqituvchiParoltxt.Text.Trim();

            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(specialty) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Barcha maydonlarni to‘ldiring.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE Teachers SET FullName = @fullName, Specialty = @specialty, Login = @login, Password = @password WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullname);
                        cmd.Parameters.AddWithValue("@Specialty", specialty);
                        cmd.Parameters.AddWithValue("@Login", login);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Id", selectedOqituvchiId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("O‘qituvchi ma’lumoti muvaffaqiyatli yangilandi.");
                            OqituvchilarDataGridViewLoad(); 
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

        private void OqituvchiDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = OqituvchiDataGridView.Rows[e.RowIndex];
                oqituvchiFISHtxt.Text = selectedRow.Cells["FullName"].Value?.ToString();
                mutaxasislikTxt.Text = selectedRow.Cells["Specialty"].Value?.ToString();
                oqituvchiLogintxt.Text = selectedRow.Cells["Login"].Value?.ToString();
                oqituvchiParoltxt.Text = selectedRow.Cells["Password"].Value?.ToString();
                selectedOqituvchiId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {

        }

        private void ClearInputs()
        {
            oqituvchiFISHtxt.Clear();
            mutaxasislikTxt.Clear();
            oqituvchiLogintxt.Clear();
            oqituvchiParoltxt.Clear();
            selectedOqituvchiId = -1;
        }

    }
}
