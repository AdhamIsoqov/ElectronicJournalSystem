namespace ElectronicJournalSystem.Forms.Teacher
{
    partial class TalabalarRoyxati
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
            this.TalabaComboBox = new System.Windows.Forms.ComboBox();
            this.FanComboBox = new System.Windows.Forms.ComboBox();
            this.GuruhComboBox = new System.Windows.Forms.ComboBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.upgBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TalabaFanDataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.BahoniKiritish = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.TalabaFanDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BahoniKiritish)).BeginInit();
            this.SuspendLayout();
            // 
            // TalabaComboBox
            // 
            this.TalabaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TalabaComboBox.FormattingEnabled = true;
            this.TalabaComboBox.Location = new System.Drawing.Point(503, 549);
            this.TalabaComboBox.Name = "TalabaComboBox";
            this.TalabaComboBox.Size = new System.Drawing.Size(232, 33);
            this.TalabaComboBox.TabIndex = 48;
            this.TalabaComboBox.SelectedIndexChanged += new System.EventHandler(this.TalabaComboBox_SelectedIndexChanged);
            // 
            // FanComboBox
            // 
            this.FanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FanComboBox.FormattingEnabled = true;
            this.FanComboBox.Location = new System.Drawing.Point(53, 549);
            this.FanComboBox.Name = "FanComboBox";
            this.FanComboBox.Size = new System.Drawing.Size(213, 33);
            this.FanComboBox.TabIndex = 47;
            // 
            // GuruhComboBox
            // 
            this.GuruhComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GuruhComboBox.FormattingEnabled = true;
            this.GuruhComboBox.Location = new System.Drawing.Point(272, 549);
            this.GuruhComboBox.Name = "GuruhComboBox";
            this.GuruhComboBox.Size = new System.Drawing.Size(225, 33);
            this.GuruhComboBox.TabIndex = 46;
            this.GuruhComboBox.SelectedIndexChanged += new System.EventHandler(this.GuruhComboBox_SelectedIndexChanged);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.Lime;
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(465, 589);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(163, 54);
            this.addBtn.TabIndex = 45;
            this.addBtn.Text = "Qo\'shish";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // upgBtn
            // 
            this.upgBtn.BackColor = System.Drawing.Color.Blue;
            this.upgBtn.ForeColor = System.Drawing.Color.White;
            this.upgBtn.Location = new System.Drawing.Point(634, 588);
            this.upgBtn.Name = "upgBtn";
            this.upgBtn.Size = new System.Drawing.Size(163, 54);
            this.upgBtn.TabIndex = 44;
            this.upgBtn.Text = "Yangilash";
            this.upgBtn.UseVisualStyleBackColor = false;
            this.upgBtn.Click += new System.EventHandler(this.upgBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.BackColor = System.Drawing.Color.Red;
            this.delBtn.ForeColor = System.Drawing.Color.White;
            this.delBtn.Location = new System.Drawing.Point(803, 589);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(163, 54);
            this.delBtn.TabIndex = 43;
            this.delBtn.Text = "O\'chirish";
            this.delBtn.UseVisualStyleBackColor = false;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 521);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 42;
            this.label3.Text = "Talaba";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 521);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 41;
            this.label2.Text = "Guruh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 517);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 40;
            this.label1.Text = "Fanni tanlash";
            // 
            // TalabaFanDataGridView
            // 
            this.TalabaFanDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TalabaFanDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TalabaFanDataGridView.Location = new System.Drawing.Point(53, 26);
            this.TalabaFanDataGridView.Name = "TalabaFanDataGridView";
            this.TalabaFanDataGridView.ReadOnly = true;
            this.TalabaFanDataGridView.RowHeadersWidth = 51;
            this.TalabaFanDataGridView.RowTemplate.Height = 24;
            this.TalabaFanDataGridView.Size = new System.Drawing.Size(916, 488);
            this.TalabaFanDataGridView.TabIndex = 39;
            this.TalabaFanDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TalabaFanDataGridView_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(741, 521);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 25);
            this.label4.TabIndex = 49;
            this.label4.Text = "Talaba";
            // 
            // BahoniKiritish
            // 
            this.BahoniKiritish.Location = new System.Drawing.Point(746, 549);
            this.BahoniKiritish.Name = "BahoniKiritish";
            this.BahoniKiritish.Size = new System.Drawing.Size(220, 30);
            this.BahoniKiritish.TabIndex = 50;
            // 
            // TalabalarRoyxati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 669);
            this.Controls.Add(this.BahoniKiritish);
            this.Controls.Add(this.label4);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TalabalarRoyxati";
            this.Text = "TalabalarRoyxati";
            ((System.ComponentModel.ISupportInitialize)(this.TalabaFanDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BahoniKiritish)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TalabaComboBox;
        private System.Windows.Forms.ComboBox FanComboBox;
        private System.Windows.Forms.ComboBox GuruhComboBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button upgBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView TalabaFanDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown BahoniKiritish;
    }
}