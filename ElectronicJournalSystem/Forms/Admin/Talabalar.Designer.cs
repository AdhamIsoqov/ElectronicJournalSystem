namespace ElectronicJournalSystem.Forms.Admin
{
    partial class Talabalar
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
            this.talabaParoltxt = new System.Windows.Forms.TextBox();
            this.talabaLogintxt = new System.Windows.Forms.TextBox();
            this.TalabaFISHtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TalabaDataGridView = new System.Windows.Forms.DataGridView();
            this.guruhNomiComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.TalabaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.Lime;
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(446, 599);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(163, 54);
            this.addBtn.TabIndex = 23;
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
            this.upgBtn.TabIndex = 22;
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
            this.delBtn.TabIndex = 21;
            this.delBtn.Text = "O\'chirish";
            this.delBtn.UseVisualStyleBackColor = false;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // talabaParoltxt
            // 
            this.talabaParoltxt.Location = new System.Drawing.Point(726, 563);
            this.talabaParoltxt.Name = "talabaParoltxt";
            this.talabaParoltxt.Size = new System.Drawing.Size(222, 30);
            this.talabaParoltxt.TabIndex = 19;
            // 
            // talabaLogintxt
            // 
            this.talabaLogintxt.Location = new System.Drawing.Point(498, 563);
            this.talabaLogintxt.Name = "talabaLogintxt";
            this.talabaLogintxt.Size = new System.Drawing.Size(222, 30);
            this.talabaLogintxt.TabIndex = 18;
            // 
            // TalabaFISHtxt
            // 
            this.TalabaFISHtxt.Location = new System.Drawing.Point(43, 562);
            this.TalabaFISHtxt.Name = "TalabaFISHtxt";
            this.TalabaFISHtxt.Size = new System.Drawing.Size(222, 30);
            this.TalabaFISHtxt.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(721, 533);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Parol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 533);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 533);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Guruh nomi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 533);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "F.I.Sh";
            // 
            // TalabaDataGridView
            // 
            this.TalabaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TalabaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TalabaDataGridView.Location = new System.Drawing.Point(34, 42);
            this.TalabaDataGridView.Name = "TalabaDataGridView";
            this.TalabaDataGridView.ReadOnly = true;
            this.TalabaDataGridView.RowHeadersWidth = 51;
            this.TalabaDataGridView.RowTemplate.Height = 24;
            this.TalabaDataGridView.Size = new System.Drawing.Size(916, 488);
            this.TalabaDataGridView.TabIndex = 12;
            this.TalabaDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TalabaDataGridView_CellClick);
            // 
            // guruhNomiComboBox
            // 
            this.guruhNomiComboBox.FormattingEnabled = true;
            this.guruhNomiComboBox.Location = new System.Drawing.Point(271, 562);
            this.guruhNomiComboBox.Name = "guruhNomiComboBox";
            this.guruhNomiComboBox.Size = new System.Drawing.Size(221, 33);
            this.guruhNomiComboBox.TabIndex = 24;
            // 
            // Talabalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 694);
            this.Controls.Add(this.guruhNomiComboBox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.upgBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.talabaParoltxt);
            this.Controls.Add(this.talabaLogintxt);
            this.Controls.Add(this.TalabaFISHtxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TalabaDataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Talabalar";
            this.Text = "Talabalar";
            this.Load += new System.EventHandler(this.Talabalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TalabaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button upgBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.TextBox talabaParoltxt;
        private System.Windows.Forms.TextBox talabaLogintxt;
        private System.Windows.Forms.TextBox TalabaFISHtxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView TalabaDataGridView;
        private System.Windows.Forms.ComboBox guruhNomiComboBox;
    }
}