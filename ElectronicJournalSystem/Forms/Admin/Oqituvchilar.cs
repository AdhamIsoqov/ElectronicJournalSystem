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
            string fish = oqituvchiFISHtxt.Text.Trim();
            string mutaxassislik = mutaxasislikTxt.Text.Trim();
            string login = oqituvchiLogintxt.Text.Trim();
            string parol = oqituvchiParoltxt.Text.Trim();
            if (string.IsNullOrWhiteSpace(fish) || string.IsNullOrWhiteSpace(mutaxassislik) ||
                string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(parol))
            {
                MessageBox.Show("Iltimos, barcha maydonlarni to‘ldiring.", "Ogohlantirish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Oqituvchilar (FISH, Mutaxassislik, Login, Parol) VALUES (@FISH, @Mutaxassislik, @Login, @Parol)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FISH", fish);
                        cmd.Parameters.AddWithValue("@Mutaxassislik", mutaxassislik);
                        cmd.Parameters.AddWithValue("@Login", login);
                        cmd.Parameters.AddWithValue("@Parol", parol);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("O‘qituvchi muvaffaqiyatli qo‘shildi!", "Ma’lumot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                oqituvchiFISHtxt.Clear();
                mutaxasislikTxt.Clear();
                oqituvchiLogintxt.Clear();
                oqituvchiParoltxt.Clear();
                OqituvchilarDataGridViewLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik yuz berdi: " + ex.Message, "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
