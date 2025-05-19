namespace ElectronicJournalSystem.Forms.Admin
{
    partial class TalabalarniBiriktirish
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.GuruhComboBox = new System.Windows.Forms.ComboBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.upgBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TalabaFanDataGridView = new System.Windows.Forms.DataGridView();
            this.FanComboBox = new System.Windows.Forms.ComboBox();
            this.TalabaComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.TalabaFanDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // GuruhComboBox
            // 
            this.GuruhComboBox.FormattingEnabled = true;
            this.GuruhComboBox.Location = new System.Drawing.Point(331, 559);
            this.GuruhComboBox.Name = "GuruhComboBox";
            this.GuruhComboBox.Size = new System.Drawing.Size(303, 33);
            this.GuruhComboBox.TabIndex = 36;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(635, 531);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 28;
            this.label3.Text = "Talaba";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Guruh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Fanni tanlash";
            // 
            // TalabaFanDataGridView
            // 
            this.TalabaFanDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TalabaFanDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TalabaFanDataGridView.Location = new System.Drawing.Point(34, 36);
            this.TalabaFanDataGridView.Name = "TalabaFanDataGridView";
            this.TalabaFanDataGridView.ReadOnly = true;
            this.TalabaFanDataGridView.RowHeadersWidth = 51;
            this.TalabaFanDataGridView.RowTemplate.Height = 24;
            this.TalabaFanDataGridView.Size = new System.Drawing.Size(916, 488);
            this.TalabaFanDataGridView.TabIndex = 25;
            this.TalabaFanDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TalabaFanDataGridView_CellClick);
            // 
            // FanComboBox
            // 
            this.FanComboBox.FormattingEnabled = true;
            this.FanComboBox.Location = new System.Drawing.Point(34, 559);
            this.FanComboBox.Name = "FanComboBox";
            this.FanComboBox.Size = new System.Drawing.Size(291, 33);
            this.FanComboBox.TabIndex = 37;
            this.FanComboBox.SelectedIndexChanged += new System.EventHandler(this.FanComboBox_SelectedIndexChanged);
            // 
            // TalabaComboBox
            // 
            this.TalabaComboBox.FormattingEnabled = true;
            this.TalabaComboBox.Location = new System.Drawing.Point(640, 559);
            this.TalabaComboBox.Name = "TalabaComboBox";
            this.TalabaComboBox.Size = new System.Drawing.Size(310, 33);
            this.TalabaComboBox.TabIndex = 38;
            // 
            // TalabalarniBiriktirish
            // 
            this.ClientSize = new System.Drawing.Size(985, 694);
            this.Controls.Add(this.TalabaComboBox);
            this.Controls.Add(this.FanComboBox);
            this.Controls.Add(this.GuruhComboBox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.upgBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TalabaFanDataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TalabalarniBiriktirish";
            this.Text = "Talabalarni guruhga biriktirish";
            ((System.ComponentModel.ISupportInitialize)(this.TalabaFanDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox GuruhComboBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button upgBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView TalabaFanDataGridView;
        private System.Windows.Forms.ComboBox FanComboBox;
        private System.Windows.Forms.ComboBox TalabaComboBox;
    }
}