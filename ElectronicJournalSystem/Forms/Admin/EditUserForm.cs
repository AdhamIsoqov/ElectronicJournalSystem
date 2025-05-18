using ElectronicJournalSystem.Data;
using ElectronicJournalSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicJournalSystem.Forms.Admin
{
    public partial class EditUserForm : Form
    {
        public EditUserForm()
        {
            InitializeComponent();
        }
        private DBHelper db;
        private User currentUser;

        public EditUserForm(User user)
        {
            InitializeComponent();
            db = new DBHelper();
            currentUser = user;
            LoadRoles();
            LoadUserData();
        }

        private void LoadRoles()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("admin");
            cmbRole.Items.Add("o'qituvchi");
            cmbRole.Items.Add("talaba");
        }

        private void LoadUserData()
        {
            txtFullName.Text = currentUser.FullName;
            txtPhone.Text = currentUser.Phone;
            txtLogin.Text = currentUser.Login;
            txtPassword.Text = currentUser.Password;
            cmbRole.SelectedItem = currentUser.Role;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            currentUser.FullName = txtFullName.Text.Trim();
            currentUser.Phone = txtPhone.Text.Trim();
            currentUser.Login = txtLogin.Text.Trim();
            currentUser.Password = txtPassword.Text.Trim();
            currentUser.Role = cmbRole.SelectedItem.ToString();

            if (string.IsNullOrEmpty(currentUser.FullName) || string.IsNullOrEmpty(currentUser.Login) || string.IsNullOrEmpty(currentUser.Password))
            {
                MessageBox.Show("Iltimos, barcha majburiy maydonlarni to‘ldiring!");
                return;
            }

            try
            {
                db.UpdateUser(currentUser);
                MessageBox.Show("Foydalanuvchi yangilandi.");
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
