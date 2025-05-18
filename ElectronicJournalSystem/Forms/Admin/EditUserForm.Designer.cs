namespace ElectronicJournalSystem.Forms.Admin
{
    partial class EditUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            this.txtFullName.Location = new System.Drawing.Point(30, 20);
            this.txtFullName.Width = 200;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(30, 60);
            this.txtPhone.Width = 200;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(30, 100);
            this.txtLogin.Width = 200;
            // 
            // txtPassword
            // 
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

        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        #endregion
    }
}