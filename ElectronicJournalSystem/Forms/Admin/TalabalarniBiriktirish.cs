using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ElectronicJournalSystem.Forms.Admin
{
    public partial class TalabalarniBiriktirish : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;
        private int selectedId = -1; // Bu student-subject jadvalidagi Id

        public TalabalarniBiriktirish()
        {
            InitializeComponent();
            Load += TalabalarniBiriktirish_Load;
            TalabaFanDataGridView.CellClick += TalabaFanDataGridView_CellClick;

            FanComboBox.SelectedIndexChanged += FanComboBox_SelectedIndexChanged;
            // Agar OqituvchiComboBox bo'lsa, shu yerda uning SelectedIndexChanged eventini qo'shishingiz mumkin
            // TalabaComboBox.SelectedIndexChanged ham kerak bo'lsa qo'shish mumkin

            addBtn.Click += addBtn_Click;
            upgBtn.Click += upgBtn_Click;
            delBtn.Click += delBtn_Click;
        }

        private void TalabalarniBiriktirish_Load(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadStudents();
            LoadGroups();
            LoadStudentSubjectsGrid();
        }

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

        private void LoadStudentSubjectsGrid()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT ss.Id, s.FullName AS Talaba, su.Name AS Fan, g.Name AS Guruh
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
            }
        }

        private void TalabaFanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = TalabaFanDataGridView.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["Id"].Value);

            // ComboBoxlarda tanlash:
            string talabaName = row.Cells["Talaba"].Value?.ToString();
            string fanName = row.Cells["Fan"].Value?.ToString();
            string guruhName = row.Cells["Guruh"].Value?.ToString();

            // TalabaComboBox tanlash
            int talabaIndex = TalabaComboBox.FindStringExact(talabaName);
            TalabaComboBox.SelectedIndex = talabaIndex;

            // FanComboBox tanlash
            int fanIndex = FanComboBox.FindStringExact(fanName);
            FanComboBox.SelectedIndex = fanIndex;

            // GuruhComboBox tanlash
            int guruhIndex = GuruhComboBox.FindStringExact(guruhName);
            GuruhComboBox.SelectedIndex = guruhIndex;
        }

        private void FanComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Agar fan tanlangan bo'lsa, unga tegishli o'qituvchilar yoki boshqa ma'lumotlarni yangilash uchun yoziladi
            // Hozircha bu eventda hech narsa qilinmayapti
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (TalabaComboBox.SelectedIndex == -1 || FanComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Iltimos, talaba va fanlarni tanlang.");
                return;
            }

            int studentId = (int)TalabaComboBox.SelectedValue;
            int subjectId = (int)FanComboBox.SelectedValue;

            // Tekshirish: Talaba va fan biriktirilganmi
            if (CheckIfStudentSubjectExists(studentId, subjectId))
            {
                MessageBox.Show("Bu talaba ushbu fanga allaqachon biriktirilgan.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO StudentSubjects (StudentId, SubjectId) VALUES (@StudentId, @SubjectId)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@SubjectId", subjectId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Talaba fanga muvaffaqiyatli biriktirildi.");
            LoadStudentSubjectsGrid();
            ClearSelection();
        }

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

        private void upgBtn_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Iltimos, yangilash uchun jadvaldan yozuv tanlang.");
                return;
            }
            if (TalabaComboBox.SelectedIndex == -1 || FanComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Talaba va fanlarni tanlang.");
                return;
            }

            int studentId = (int)TalabaComboBox.SelectedValue;
            int subjectId = (int)FanComboBox.SelectedValue;

            // Tekshirish: Bu yangilanish mavjud yozuv bilan to'qnashmasligi kerak
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
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
                        MessageBox.Show("Bunday talaba va fan kombinatsiyasi allaqachon mavjud.");
                        return;
                    }
                }
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE StudentSubjects SET StudentId = @StudentId, SubjectId = @SubjectId WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                    cmd.Parameters.AddWithValue("@Id", selectedId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Ma'lumot muvaffaqiyatli yangilandi.");
            LoadStudentSubjectsGrid();
            ClearSelection();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Iltimos, o'chirish uchun jadvaldan yozuv tanlang.");
                return;
            }

            var confirm = MessageBox.Show("Ushbu yozuvni o'chirmoqchimisiz?", "Tasdiqlash", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

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

            MessageBox.Show("Yozuv o'chirildi.");
            LoadStudentSubjectsGrid();
            ClearSelection();
        }

        private void ClearSelection()
        {
            selectedId = -1;
            TalabaComboBox.SelectedIndex = -1;
            FanComboBox.SelectedIndex = -1;
            GuruhComboBox.SelectedIndex = -1;
            TalabaFanDataGridView.ClearSelection();
        }
    }
}