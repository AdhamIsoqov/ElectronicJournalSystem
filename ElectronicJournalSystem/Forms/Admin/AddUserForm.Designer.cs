using System;
using System.Windows.Forms;
using ElectronicJournalSystem.Data;
using ElectronicJournalSystem.Models;

namespace ElectronicJournalSystem.Forms.Admin
{
    public partial class AddUserForm : Form
    {
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblLogin;
        private TextBox txtLogin;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private ComboBox cmbRole;
        private Button btnSave;
        private Button btnCancel;

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
            cmbRole.Items.Add("talaba");
            cmbRole.Items.Add("oqituvchi");
            cmbRole.SelectedIndex = 0; // Default tanlov
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtLogin.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Iltimos, barcha maydonlarni to‘ldiring!");
                return;
            }

            User newUser = new User
            {
                FullName = txtFullName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Login = txtLogin.Text.Trim(),
                Password = txtPassword.Text,
                Role = cmbRole.SelectedItem.ToString()
            };

            try
            {
                db.AddUser(newUser);
                MessageBox.Show("Foydalanuvchi muvaffaqiyatli qo‘shildi.");
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
            this.Close();
        }

        private void InitializeComponent()
        {
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFullName
            // 
            this.txtFullName.PlaceholderText = "To‘liq ism";
            this.txtFullName.Location = new System.Drawing.Point(30, 20);
            this.txtFullName.Width = 200;
            // 
            // txtPhone
            // 
            this.txtPhone.PlaceholderText = "Telefon raqam";
            this.txtPhone.Location = new System.Drawing.Point(30, 60);
            this.txtPhone.Width = 200;
            // 
            // txtLogin
            // 
            this.txtLogin.PlaceholderText = "Login";
            this.txtLogin.Location = new System.Drawing.Point(30, 100);
            this.txtLogin.Width = 200;
            // 
            // txtPassword
            // 
            this.txtPassword.PlaceholderText = "Parol";
            this.txtPassword.Location = new System.Drawing.Point(30, 140);
            this.txtPassword.Width = 200;
            this.txtPassword.PasswordChar = '*';
            // 
            // cmbRole
            // 
            this.cmbRole.Location = new System.Drawing.Point(30, 180);
            this.cmbRole.Width = 200;
            // 
            // btnSave
            // 
            this.btnSave.Text = "Saqlash";
            this.btnSave.Location = new System.Drawing.Point(30, 220);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Bekor qilish";
            this.btnCancel.Location = new System.Drawing.Point(130, 220);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddUserForm
            // 
            this.ClientSize = new System.Drawing.Size(280, 270);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "AddUserForm";
            this.Text = "Foydalanuvchi qo‘shish";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}