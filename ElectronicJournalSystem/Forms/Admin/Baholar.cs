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
    public partial class Baholar : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;

        public Baholar()
        {
            InitializeComponent();
        }

        private void Baholar_Load(object sender, EventArgs e)
        {
            LoadGradesData();
        }

        private void LoadGradesData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT g.Id, s.FullName AS Student, sb.Name AS Subject, t.FullName AS Teacher, g.Grade, g.Date
                                     FROM Grades g
                                     JOIN Students s ON g.StudentId = s.Id
                                     JOIN Subjects sb ON g.SubjectId = sb.Id
                                     JOIN Teachers t ON g.TeacherId = t.Id";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    BaholarDataGridView.DataSource = dt;
                    BaholarDataGridView.Columns["Id"].HeaderText = "ID";
                    BaholarDataGridView.Columns["Student"].HeaderText = "Talaba";
                    BaholarDataGridView.Columns["Subject"].HeaderText = "Fan";
                    BaholarDataGridView.Columns["Teacher"].HeaderText = "O'qituvchi";
                    BaholarDataGridView.Columns["Grade"].HeaderText = "Baho";
                    BaholarDataGridView.Columns["Date"].HeaderText = "Sana";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
                }
            }
        }
    }
}