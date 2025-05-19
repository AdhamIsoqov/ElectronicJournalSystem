using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using ElectronicJournalSystem.Forms.Admin;
using ElectronicJournalSystem.Forms.Student;
using ElectronicJournalSystem.Forms.Teacher;

namespace ElectronicJournalSystem.Forms.Login
{
    public partial class LoginForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string studentQuery = "SELECT * FROM Students WHERE Login = @login AND Password = @password";
                SqlCommand studentCmd = new SqlCommand(studentQuery, conn);
                studentCmd.Parameters.AddWithValue("@login", login);
                studentCmd.Parameters.AddWithValue("@password", password);
                SqlDataReader studentReader = studentCmd.ExecuteReader();
                if (studentReader.Read())
                {
                    int studentId = Convert.ToInt32(studentReader["Id"]);
                    studentReader.Close();
                    MessageBox.Show("Xush kelibsiz, Talaba!");
                    this.Hide();
                    new TalabaForm(studentId).Show();
                    return;
                }
                studentReader.Close();

                // 2. O‘qituvchi tekshiruvi
                string teacherQuery = "SELECT * FROM Teachers WHERE Login = @login AND Password = @password";
                SqlCommand teacherCmd = new SqlCommand(teacherQuery, conn);
                teacherCmd.Parameters.AddWithValue("@login", login);
                teacherCmd.Parameters.AddWithValue("@password", password);
                SqlDataReader teacherReader = teacherCmd.ExecuteReader();

                if (teacherReader.Read())
                {
                    int teacherId = Convert.ToInt32(teacherReader["Id"]);
                    teacherReader.Close();

                    MessageBox.Show("Xush kelibsiz, O‘qituvchi!");
                    this.Hide();
                    new OqituvchiForm(teacherId).Show(); // O‘qituvchi formasi
                    return;
                }
                teacherReader.Close();

                // 3. Admin tekshiruvi
                string userQuery = "SELECT * FROM Users WHERE Login = @login AND Password = @password";
                SqlCommand userCmd = new SqlCommand(userQuery, conn);
                userCmd.Parameters.AddWithValue("@login", login);
                userCmd.Parameters.AddWithValue("@password", password);
                SqlDataReader userReader = userCmd.ExecuteReader();

                if (userReader.Read())
                {
                    int userId = Convert.ToInt32(userReader["Id"]);
                    userReader.Close();

                    MessageBox.Show("Xush kelibsiz, Admin!");
                    this.Hide();
                    new AdminForm(userId).Show(); // Admin formasi
                    return;
                }
                userReader.Close();

                // Agar hech biridan topilmasa:
                MessageBox.Show("Login yoki parol noto‘g‘ri!");
            }
        }
    }
}
