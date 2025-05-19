using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ElectronicJournalSystem.Forms.Teacher
{
    public partial class TalabalarRoyxati : Form
    {
        private int currentTeacherId;
        private string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;

        public TalabalarRoyxati(int teacherId)
        {
            InitializeComponent();
            currentTeacherId = teacherId;
        }

        private void TalabalarRoyxati_Load(object sender, EventArgs e)
        {
            LoadGroups();
            LoadStudentSubjectData();
        }

        private void LoadGroups()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM [dbo].[Groups]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable groupsTable = new DataTable();
                adapter.Fill(groupsTable);

                GuruhComboBox.DataSource = groupsTable;
                GuruhComboBox.DisplayMember = "Name";
                GuruhComboBox.ValueMember = "Id";
            }
        }

        private void LoadStudents(int groupId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, FullName FROM [dbo].[Students] WHERE GroupId = @GroupId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@GroupId", groupId);
                DataTable studentsTable = new DataTable();
                adapter.Fill(studentsTable);

                TalabaComboBox.DataSource = studentsTable;
                TalabaComboBox.DisplayMember = "FullName";
                TalabaComboBox.ValueMember = "Id";
            }
        }

        private void LoadSubjects(int studentId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT s.Id, s.Name 
                                 FROM [dbo].[StudentSubjects] ss 
                                 JOIN [dbo].[Subjects] s ON ss.SubjectId = s.Id 
                                 WHERE ss.StudentId = @StudentId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@StudentId", studentId);
                DataTable subjectsTable = new DataTable();
                adapter.Fill(subjectsTable);

                FanComboBox.DataSource = subjectsTable;
                FanComboBox.DisplayMember = "Name";
                FanComboBox.ValueMember = "Id";
            }
        }

        private void LoadStudentSubjectData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                                    st.Id AS StudentId,
                                    st.FullName AS Student,
                                    su.Id AS SubjectId,
                                    su.Name AS Subject,
                                    g.Grade,
                                    g.Date
                                 FROM [dbo].[Grades] g
                                 JOIN [dbo].[StudentSubjects] ss ON g.StudentSubjectId = ss.Id
                                 JOIN [dbo].[Students] st ON ss.StudentId = st.Id
                                 JOIN [dbo].[Subjects] su ON ss.SubjectId = su.Id";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                TalabaFanDataGridView.DataSource = dataTable;

                // Yashirin ustunlar
                if (TalabaFanDataGridView.Columns.Contains("StudentId"))
                    TalabaFanDataGridView.Columns["StudentId"].Visible = false;
                if (TalabaFanDataGridView.Columns.Contains("SubjectId"))
                    TalabaFanDataGridView.Columns["SubjectId"].Visible = false;
            }
        }

        private void GuruhComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GuruhComboBox.SelectedValue is int groupId)
            {
                LoadStudents(groupId);
            }
        }

        private void TalabaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TalabaComboBox.SelectedValue is int studentId)
            {
                LoadSubjects(studentId);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            int studentId = (int)TalabaComboBox.SelectedValue;
            int subjectId = (int)FanComboBox.SelectedValue;
            int grade = (int)BahoniKiritish.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM [dbo].[StudentSubjects] WHERE StudentId = @StudentId AND SubjectId = @SubjectId";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@StudentId", studentId);
                checkCmd.Parameters.AddWithValue("@SubjectId", subjectId);
                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    string insertQuery = "INSERT INTO [dbo].[StudentSubjects] (StudentId, SubjectId) VALUES (@StudentId, @SubjectId)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@StudentId", studentId);
                    insertCmd.Parameters.AddWithValue("@SubjectId", subjectId);
                    insertCmd.ExecuteNonQuery();
                }

                string gradeQuery = @"INSERT INTO [dbo].[Grades] (TeacherId, Grade, Date, StudentSubjectId)
                                      VALUES (@TeacherId, @Grade, @Date, 
                                      (SELECT Id FROM [dbo].[StudentSubjects] WHERE StudentId = @StudentId AND SubjectId = @SubjectId))";
                SqlCommand gradeCmd = new SqlCommand(gradeQuery, conn);
                gradeCmd.Parameters.AddWithValue("@TeacherId", currentTeacherId);
                gradeCmd.Parameters.AddWithValue("@Grade", grade);
                gradeCmd.Parameters.AddWithValue("@Date", DateTime.Now);
                gradeCmd.Parameters.AddWithValue("@StudentId", studentId);
                gradeCmd.Parameters.AddWithValue("@SubjectId", subjectId);
                gradeCmd.ExecuteNonQuery();

                MessageBox.Show("Yangi baho muvaffaqiyatli qo'shildi!");
                LoadStudentSubjectData();
            }
        }

        private void upgBtn_Click(object sender, EventArgs e)
        {
            if (TalabaFanDataGridView.SelectedRows.Count > 0)
            {
                int studentId = (int)TalabaComboBox.SelectedValue;
                int subjectId = (int)FanComboBox.SelectedValue;
                int grade = (int)BahoniKiritish.Value;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"UPDATE [dbo].[Grades]
                                     SET Grade = @Grade
                                     WHERE StudentSubjectId = (
                                         SELECT Id FROM [dbo].[StudentSubjects]
                                         WHERE StudentId = @StudentId AND SubjectId = @SubjectId
                                     )";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Grade", grade);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Baho muvaffaqiyatli yangilandi!");
                    LoadStudentSubjectData();
                }
            }
            else
            {
                MessageBox.Show("Iltimos, yangilamoqchi bo'lgan qatorni tanlang.");
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (TalabaFanDataGridView.SelectedRows.Count > 0)
            {
                int studentId = (int)TalabaComboBox.SelectedValue;
                int subjectId = (int)FanComboBox.SelectedValue;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"DELETE FROM [dbo].[Grades]
                                     WHERE StudentSubjectId = (
                                         SELECT Id FROM [dbo].[StudentSubjects]
                                         WHERE StudentId = @StudentId AND SubjectId = @SubjectId
                                     )";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Baho muvaffaqiyatli o'chirildi!");
                    LoadStudentSubjectData();
                }
            }
            else
            {
                MessageBox.Show("Iltimos, o'chirmoqchi bo'lgan qatorni tanlang.");
            }
        }

        private void TalabaFanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = TalabaFanDataGridView.Rows[e.RowIndex];
                int studentId = Convert.ToInt32(row.Cells["StudentId"].Value);
                int subjectId = Convert.ToInt32(row.Cells["SubjectId"].Value);
                int grade = Convert.ToInt32(row.Cells["Grade"].Value);

                TalabaComboBox.SelectedValue = studentId;
                LoadSubjects(studentId); // combo boxni qayta to‘ldirish
                FanComboBox.SelectedValue = subjectId;
                BahoniKiritish.Value = grade;
            }
        }
    }
}
