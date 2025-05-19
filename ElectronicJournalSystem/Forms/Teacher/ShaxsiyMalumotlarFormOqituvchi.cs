using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ElectronicJournalSystem.Forms.Teacher
{
    public partial class ShaxsiyMalumotlarFormOqituvchi : Form
    {
        private int currentTeacherId;
        private string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;

        public ShaxsiyMalumotlarFormOqituvchi(int teacherId)
        {
            InitializeComponent();
            currentTeacherId = teacherId;
        }

        private void ShaxsiyMalumotlarFormOqituvchi_Load(object sender, EventArgs e)
        {
            LoadTeacherInfo();
        }

        private void LoadTeacherInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT FullName, Specialty, Login FROM Teachers WHERE Id = @TeacherId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherId", currentTeacherId);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            FishLbl.Text = reader["FullName"].ToString();
                            MutaxasislikLbl.Text = reader["Specialty"].ToString();
                            LoginLbl.Text = reader["Login"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("O‘qituvchi ma’lumotlari topilmadi.", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ma’lumotlarni yuklashda xatolik: " + ex.Message, "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
