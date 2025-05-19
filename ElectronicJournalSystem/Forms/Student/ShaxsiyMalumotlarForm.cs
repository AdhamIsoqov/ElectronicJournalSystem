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
    public partial class ShaxsiyMalumotlarForm : Form
    {
        private int studentId;
        string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;

        public ShaxsiyMalumotlarForm(int id)
        {
            InitializeComponent();
            studentId = id;
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT s.FullName, g.Name AS GroupName, g.Course, g.Direction
                FROM Students s
                LEFT JOIN Groups g ON s.GroupId = g.Id
                WHERE s.Id = @StudentId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", studentId);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        FishLbl.Text = reader["FullName"].ToString();
                        GuruhNomiLbl.Text = reader["GroupName"]?.ToString() ?? "Ma'lumot yo'q";
                        KursiLbl.Text = reader["Course"]?.ToString() ?? "Ma'lumot yo'q";
                        YonalishiLbl.Text = reader["Direction"]?.ToString() ?? "Ma'lumot yo'q";
                    }
                    else
                    {
                        MessageBox.Show("Talaba topilmadi!");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xatolik yuz berdi: " + ex.Message);
                }
            }
        }
    }

}
