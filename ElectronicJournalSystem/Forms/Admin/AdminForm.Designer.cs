namespace ElectronicJournalSystem.Forms.Admin
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnDeleteUser;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(30, 30);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(500, 250);
            this.dgvUsers.TabIndex = 0;
            // 
            // btnAddUser
            this.btnAddUser.Location = new System.Drawing.Point(30, 300);
            this.btnAddUser.Size = new System.Drawing.Size(100, 30);
            this.btnAddUser.Text = "Qo‘shish";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnDeleteUser
            this.btnDeleteUser.Location = new System.Drawing.Point(150, 300);
            this.btnDeleteUser.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteUser.Text = "O‘chirish";
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // AdminForm
            this.ClientSize = new System.Drawing.Size(580, 370);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnDeleteUser);
            this.Text = "Admin Panel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
