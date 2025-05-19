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

namespace ElectronicJournalSystem.Forms.Student
{
    public partial class BaholarniKorishForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;
        private int currentStudentId;

        public BaholarniKorishForm(int studentId)
        {
            InitializeComponent();
            currentStudentId = studentId;
        }

        private void BaholarniKorishForm_Load(object sender, EventArgs e)
        {
            LoadGradesForStudent();
        }

        private void LoadGradesForStudent()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            sub.Name AS Fan,
                            t.FullName AS Oqituvchi,
                            g.Grade AS Baho,
                            g.Date AS Sana
                        FROM Grades g
                        LEFT JOIN Subjects sub ON g.SubjectId = sub.Id
                        LEFT JOIN Teachers t ON g.TeacherId = t.Id
                        WHERE g.StudentId = @StudentId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentId", currentStudentId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    BahoDataGridView.DataSource = dt;
                    BahoDataGridView.Columns["Fan"].HeaderText = "Fan nomi";
                    BahoDataGridView.Columns["Oqituvchi"].HeaderText = "O‘qituvchi";
                    BahoDataGridView.Columns["Baho"].HeaderText = "Baho";
                    BahoDataGridView.Columns["Sana"].HeaderText = "Sana";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Baholarni yuklashda xatolik: " + ex.Message);
                }
            }
        }
    }
}
