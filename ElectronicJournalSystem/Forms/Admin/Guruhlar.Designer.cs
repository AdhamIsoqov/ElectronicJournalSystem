namespace ElectronicJournalSystem.Forms.Admin
{
    partial class Guruhlar
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
            this.addBtn = new System.Windows.Forms.Button();
            this.upgBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.kurstxt = new System.Windows.Forms.TextBox();
            this.yonalishtxt = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GuruhDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GuruhDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.Lime;
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(446, 599);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(163, 54);
            this.addBtn.TabIndex = 35;
            this.addBtn.Text = "Qo\'shish";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // upgBtn
            // 
            this.upgBtn.BackColor = System.Drawing.Color.Blue;
            this.upgBtn.ForeColor = System.Drawing.Color.White;
            this.upgBtn.Location = new System.Drawing.Point(615, 598);
            this.upgBtn.Name = "upgBtn";
            this.upgBtn.Size = new System.Drawing.Size(163, 54);
            this.upgBtn.TabIndex = 34;
            this.upgBtn.Text = "Yangilash";
            this.upgBtn.UseVisualStyleBackColor = false;
            this.upgBtn.Click += new System.EventHandler(this.upgBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.BackColor = System.Drawing.Color.Red;
            this.delBtn.ForeColor = System.Drawing.Color.White;
            this.delBtn.Location = new System.Drawing.Point(784, 599);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(163, 54);
            this.delBtn.TabIndex = 33;
            this.delBtn.Text = "O\'chirish";
            this.delBtn.UseVisualStyleBackColor = false;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // kurstxt
            // 
            this.kurstxt.Location = new System.Drawing.Point(671, 562);
            this.kurstxt.Name = "kurstxt";
            this.kurstxt.Size = new System.Drawing.Size(276, 30);
            this.kurstxt.TabIndex = 31;
            // 
            // yonalishtxt
            // 
            this.yonalishtxt.Location = new System.Drawing.Point(325, 563);
            this.yonalishtxt.Name = "yonalishtxt";
            this.yonalishtxt.Size = new System.Drawing.Size(340, 30);
            this.yonalishtxt.TabIndex = 30;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(43, 562);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(276, 30);
            this.textBox1.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(666, 533);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 27;
            this.label3.Text = "Kurs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 533);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Yo\'nalishi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 533);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Guruh Nomi:";
            // 
            // GuruhDataGridView
            // 
            this.GuruhDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GuruhDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GuruhDataGridView.Location = new System.Drawing.Point(34, 42);
            this.GuruhDataGridView.Name = "GuruhDataGridView";
            this.GuruhDataGridView.ReadOnly = true;
            this.GuruhDataGridView.RowHeadersWidth = 51;
            this.GuruhDataGridView.RowTemplate.Height = 24;
            this.GuruhDataGridView.Size = new System.Drawing.Size(916, 488);
            this.GuruhDataGridView.TabIndex = 24;
            this.GuruhDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GuruhDataGridView_CellClick);
            // 
            // Guruhlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 694);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.upgBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.kurstxt);
            this.Controls.Add(this.yonalishtxt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GuruhDataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Guruhlar";
            this.Text = "Guruhlar";
            this.Load += new System.EventHandler(this.Guruhlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GuruhDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button upgBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.TextBox kurstxt;
        private System.Windows.Forms.TextBox yonalishtxt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GuruhDataGridView;
    }
}