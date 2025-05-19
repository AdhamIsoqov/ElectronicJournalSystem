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
                        INNER JOIN StudentSubjects ss ON g.StudentSubjectId = ss.Id
                        INNER JOIN Subjects sub ON ss.SubjectId = sub.Id
                        LEFT JOIN Teachers t ON g.TeacherId = t.Id
                        WHERE ss.StudentId = @StudentId
                        ORDER BY g.Date DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentId", currentStudentId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    BahoDataGridView.DataSource = dt;
                    if (BahoDataGridView.Columns.Contains("Fan"))
                        BahoDataGridView.Columns["Fan"].HeaderText = "Fan nomi";
                    if (BahoDataGridView.Columns.Contains("Oqituvchi"))
                        BahoDataGridView.Columns["Oqituvchi"].HeaderText = "O‘qituvchi";
                    if (BahoDataGridView.Columns.Contains("Baho"))
                        BahoDataGridView.Columns["Baho"].HeaderText = "Baho";
                    if (BahoDataGridView.Columns.Contains("Sana"))
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
