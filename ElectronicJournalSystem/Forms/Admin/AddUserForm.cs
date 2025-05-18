using System;
using System.Windows.Forms;
using ElectronicJournalSystem.Data;
using ElectronicJournalSystem.Models;

namespace ElectronicJournalSystem.Forms.Admin
{
    public partial class AddUserForm
    {
        private DBHelper db;

        public AddUserForm()
        {
            InitializeComponent();
            db = new DBHelper();
            LoadRoles();
        }

        private void LoadRoles()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("admin");
            cmbRole.Items.Add("o'qituvchi");
            cmbRole.Items.Add("talaba");
            cmbRole.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.SelectedItem.ToString();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Iltimos, barcha majburiy maydonlarni to‘ldiring!");
                return;
            }

            User newUser = new User
            {
                FullName = fullName,
                Phone = phone,
                Login = login,
                Password = password,
                Role = role
            };

            try
            {
                db.AddUser(newUser);
                MessageBox.Show("Foydalanuvchi qo‘shildi.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
