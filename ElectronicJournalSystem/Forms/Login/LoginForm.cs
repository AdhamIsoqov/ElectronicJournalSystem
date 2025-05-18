using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using ElectronicJournalSystem.Forms.Admin;

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
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Users WHERE Login = @login AND Password = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    new AdminForm().Show();
                    this.Hide();
                    string role = reader["Role"].ToString();
                    // MessageBox.Show("Xush kelibsiz, " + role);
                }
                else
                {
                    MessageBox.Show("Login yoki parol noto‘g‘ri!");
                }
                reader.Close();
            }
        }
    }
}
