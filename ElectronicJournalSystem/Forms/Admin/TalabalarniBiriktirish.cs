using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ElectronicJournalSystem.Forms.Admin
{
    public partial class TalabalarniBiriktirish : Form
    {
        // SQL serverga ulanish satri (App.config yoki Web.config ichidan olinadi)
        string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;

        // Tanlangan yozuv ID sini saqlash uchun
        private int selectedId = -1;

        public TalabalarniBiriktirish()
        {
            InitializeComponent();

            // Form yuklanganda kerakli ma'lumotlarni yuklash
            Load += TalabalarniBiriktirish_Load;

            // DataGridView dagi qator tanlanganida
            TalabaFanDataGridView.CellClick += TalabaFanDataGridView_CellClick;

            // Tugmalarga eventlar
            addBtn.Click += addBtn_Click;
            upgBtn.Click += upgBtn_Click;
            delBtn.Click += delBtn_Click;

            // Guruh va Talaba ComboBox o'zgarganda
            GuruhComboBox.SelectedIndexChanged += GuruhComboBox_SelectedIndexChanged;
            TalabaComboBox.SelectedIndexChanged += TalabaComboBox_SelectedIndexChanged;
        }

        // Form yuklanganda ma'lumotlarni yuklash
        private void TalabalarniBiriktirish_Load(object sender, EventArgs e)
        {
            LoadGroups();
            LoadSubjects();
            LoadStudents();
            LoadStudentSubjectsGrid();
        }

        // Guruhlarni yuklash
        private void LoadGroups()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM Groups";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GuruhComboBox.DisplayMember = "Name";
                GuruhComboBox.ValueMember = "Id";
                GuruhComboBox.DataSource = dt;
                GuruhComboBox.SelectedIndex = -1;
            }
        }

        // Fanni yuklash (butun fanlar)
        private void LoadSubjects()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM Subjects";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                FanComboBox.DisplayMember = "Name";
                FanComboBox.ValueMember = "Id";
                FanComboBox.DataSource = dt;
                FanComboBox.SelectedIndex = -1;
            }
        }

        // Talabalarni yuklash (barcha talabalar)
        private void LoadStudents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, FullName FROM Students";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                TalabaComboBox.DisplayMember = "FullName";
                TalabaComboBox.ValueMember = "Id";
                TalabaComboBox.DataSource = dt;
                TalabaComboBox.SelectedIndex = -1;
            }
        }

        // Talaba-Fan bog‘lanishlarini DataGridView ga yuklash
        private void LoadStudentSubjectsGrid()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT ss.Id, s.FullName AS Talaba, su.Name AS Fan, g.Name AS Guruh, ss.Grade AS Baho
                    FROM StudentSubjects ss
                    INNER JOIN Students s ON ss.StudentId = s.Id
                    INNER JOIN Subjects su ON ss.SubjectId = su.Id
                    LEFT JOIN Groups g ON s.GroupId = g.Id";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                TalabaFanDataGridView.DataSource = dt;
                TalabaFanDataGridView.Columns["Id"].Visible = false;
                TalabaFanDataGridView.Columns["Talaba"].HeaderText = "Talaba";
                TalabaFanDataGridView.Columns["Fan"].HeaderText = "Fan";
                TalabaFanDataGridView.Columns["Guruh"].HeaderText = "Guruh";
                TalabaFanDataGridView.Columns["Baho"].HeaderText = "Baho";
            }
        }

        // DataGridView da qator tanlanganida ma'lumotlarni form elementlariga yuklash
        private void TalabaFanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = TalabaFanDataGridView.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["Id"].Value);

            string talabaName = row.Cells["Talaba"].Value?.ToString();
            string fanName = row.Cells["Fan"].Value?.ToString();
            string guruhName = row.Cells["Guruh"].Value?.ToString();

            TalabaComboBox.SelectedIndex = TalabaComboBox.FindStringExact(talabaName);
            FanComboBox.SelectedIndex = FanComboBox.FindStringExact(fanName);
            GuruhComboBox.SelectedIndex = GuruhComboBox.FindStringExact(guruhName);

            if (row.Cells["Baho"].Value != DBNull.Value)
                BahoniKiritish.Value = Convert.ToDecimal(row.Cells["Baho"].Value);
            else
                BahoniKiritish.Value = 0;
        }

        // Qo‘shish tugmasi - yangi bog‘lanish qo‘shish
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (TalabaComboBox.SelectedIndex == -1 || FanComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Iltimos, talaba va fanlarni tanlang.");
                return;
            }

            int studentId = (int)TalabaComboBox.SelectedValue;
            int subjectId = (int)FanComboBox.SelectedValue;
            int grade = (int)BahoniKiritish.Value;

            if (CheckIfStudentSubjectExists(studentId, subjectId))
            {
                MessageBox.Show("Bu talaba ushbu fanga allaqachon biriktirilgan.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO StudentSubjects (StudentId, SubjectId, Grade) VALUES (@StudentId, @SubjectId, @Grade)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                    cmd.Parameters.AddWithValue("@Grade", grade);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Talaba fanga muvaffaqiyatli biriktirildi.");
            LoadStudentSubjectsGrid();
            ClearSelection();
        }

        // Yangilash tugmasi - mavjud bog‘lanishni o‘zgartirish
        private void upgBtn_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Iltimos, yangilash uchun yozuv tanlang.");
                return;
            }

            if (TalabaComboBox.SelectedIndex == -1 || FanComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Talaba va fan tanlanmagan.");
                return;
            }

            int studentId = (int)TalabaComboBox.SelectedValue;
            int subjectId = (int)FanComboBox.SelectedValue;
            int grade = (int)BahoniKiritish.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Takrorlanishni tekshirish
                string checkQuery = @"
                    SELECT COUNT(*) FROM StudentSubjects 
                    WHERE StudentId = @StudentId AND SubjectId = @SubjectId AND Id <> @Id";
                using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@StudentId", studentId);
                    cmdCheck.Parameters.AddWithValue("@SubjectId", subjectId);
                    cmdCheck.Parameters.AddWithValue("@Id", selectedId);
                    conn.Open();
                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Bu bog‘lanish allaqachon mavjud.");
                        return;
                    }
                }
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE StudentSubjects SET StudentId = @StudentId, SubjectId = @SubjectId, Grade = @Grade WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                    cmd.Parameters.AddWithValue("@Grade", grade);
                    cmd.Parameters.AddWithValue("@Id", selectedId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Ma'lumot yangilandi.");
            LoadStudentSubjectsGrid();
            ClearSelection();
        }

        // O‘chirish tugmasi - tanlangan bog‘lanishni o‘chirish
        private void delBtn_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("O‘chirish uchun yozuv tanlang.");
                return;
            }

            var result = MessageBox.Show("Haqiqatan ham ushbu bog‘lanishni o‘chirmoqchimisiz?", "Tasdiqlash", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM StudentSubjects WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", selectedId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Ma'lumot o'chirildi.");
            LoadStudentSubjectsGrid();
            ClearSelection();
        }

        // Guruh tanlanganda, faqat shu guruhdagi talabalarni yuklash
        private void GuruhComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GuruhComboBox.SelectedIndex == -1)
            {
                LoadStudents();
                return;
            }

            int selectedGroupId = (int)GuruhComboBox.SelectedValue;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, FullName FROM Students WHERE GroupId = @GroupId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@GroupId", selectedGroupId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                TalabaComboBox.DisplayMember = "FullName";
                TalabaComboBox.ValueMember = "Id";
                TalabaComboBox.DataSource = dt;
                TalabaComboBox.SelectedIndex = -1;
            }
        }

        // Talaba tanlanganda, faqat shu talaba uchun fanlarni yuklash
        private void TalabaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TalabaComboBox.SelectedIndex == -1)
            {
                LoadSubjects();
                return;
            }

            int selectedStudentId = (int)TalabaComboBox.SelectedValue;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT su.Id, su.Name
                    FROM Subjects su
                    INNER JOIN StudentSubjects ss ON su.Id = ss.SubjectId
                    WHERE ss.StudentId = @StudentId";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@StudentId", selectedStudentId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                FanComboBox.DisplayMember = "Name";
                FanComboBox.ValueMember = "Id";
                FanComboBox.DataSource = dt;
                FanComboBox.SelectedIndex = -1;
            }
        }

        // Takroriy bog‘lanishni tekshirish
        private bool CheckIfStudentSubjectExists(int studentId, int subjectId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM StudentSubjects WHERE StudentId = @StudentId AND SubjectId = @SubjectId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Tanlovlarni tozalash
        private void ClearSelection()
        {
            selectedId = -1;
            TalabaComboBox.SelectedIndex = -1;
            FanComboBox.SelectedIndex = -1;
            GuruhComboBox.SelectedIndex = -1;
            BahoniKiritish.Value = 0;
        }
    }
}
