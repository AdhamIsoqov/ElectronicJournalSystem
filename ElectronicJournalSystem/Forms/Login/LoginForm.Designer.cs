namespace ElectronicJournalSystem.Forms.Login
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Text = "Login:";
            // 
            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 70);
            this.label2.Text = "Parol:";
            // 
            // txtLogin
            this.txtLogin.Location = new System.Drawing.Point(120, 27);
            this.txtLogin.Size = new System.Drawing.Size(150, 22);
            // 
            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(120, 67);
            this.txtPassword.Size = new System.Drawing.Size(150, 22);
            this.txtPassword.PasswordChar = '*';
            // 
            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(120, 110);
            this.btnLogin.Size = new System.Drawing.Size(150, 30);
            this.btnLogin.Text = "Kirish";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LoginForm
            this.ClientSize = new System.Drawing.Size(320, 180);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Text = "Kirish";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
