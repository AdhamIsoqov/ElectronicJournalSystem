using System;
using System.Data.SqlClient;
using System.Configuration;
using ElectronicJournalSystem.Models;

namespace ElectronicJournalSystem.Data
{
    public class DBHelper
    {
        private string connectionString;

        public DBHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;
        }

        public void AddUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Users (FullName, Phone, Login, Password, Role) " +
                               "VALUES (@FullName, @Phone, @Login, @Password, @Role)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", user.FullName);
                    cmd.Parameters.AddWithValue("@Phone", user.Phone);
                    cmd.Parameters.AddWithValue("@Login", user.Login);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", user.Role);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public User GetUserById(int id)
        {
            User user = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Users WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Id = (int)reader["Id"],
                                FullName = reader["FullName"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Login = reader["Login"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = reader["Role"].ToString()
                            };
                        }
                    }
                }
            }
            return user;
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET FullName=@FullName, Phone=@Phone, Login=@Login, Password=@Password, Role=@Role WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", user.FullName);
                    cmd.Parameters.AddWithValue("@Phone", user.Phone);
                    cmd.Parameters.AddWithValue("@Login", user.Login);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Users WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
