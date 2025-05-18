namespace ElectronicJournalSystem.Forms.Admin
{
    partial class Fanlar
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
            this.kreditTxt = new System.Windows.Forms.TextBox();
            this.fannarNametxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FanlarDataGridView = new System.Windows.Forms.DataGridView();
            this.oqituvchiComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.FanlarDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.Lime;
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(446, 599);
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
            this.upgBtn.Location = new System.Drawing.Point(615, 598);
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
            this.delBtn.Location = new System.Drawing.Point(784, 599);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(163, 54);
            this.delBtn.TabIndex = 43;
            this.delBtn.Text = "O\'chirish";
            this.delBtn.UseVisualStyleBackColor = false;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // kreditTxt
            // 
            this.kreditTxt.Location = new System.Drawing.Point(671, 562);
            this.kreditTxt.Name = "kreditTxt";
            this.kreditTxt.Size = new System.Drawing.Size(276, 30);
            this.kreditTxt.TabIndex = 42;
            // 
            // fannarNametxt
            // 
            this.fannarNametxt.Location = new System.Drawing.Point(43, 562);
            this.fannarNametxt.Name = "fannarNametxt";
            this.fannarNametxt.Size = new System.Drawing.Size(276, 30);
            this.fannarNametxt.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(666, 533);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 39;
            this.label3.Text = "Kredit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 533);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 38;
            this.label2.Text = "O\'qituvchi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 533);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 37;
            this.label1.Text = "Fan nomi:";
            // 
            // FanlarDataGridView
            // 
            this.FanlarDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FanlarDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FanlarDataGridView.Location = new System.Drawing.Point(34, 42);
            this.FanlarDataGridView.Name = "FanlarDataGridView";
            this.FanlarDataGridView.ReadOnly = true;
            this.FanlarDataGridView.RowHeadersWidth = 51;
            this.FanlarDataGridView.RowTemplate.Height = 24;
            this.FanlarDataGridView.Size = new System.Drawing.Size(916, 488);
            this.FanlarDataGridView.TabIndex = 36;
            this.FanlarDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FanlarDataGridView_CellClick);
            // 
            // oqituvchiComboBox
            // 
            this.oqituvchiComboBox.FormattingEnabled = true;
            this.oqituvchiComboBox.Location = new System.Drawing.Point(325, 559);
            this.oqituvchiComboBox.Name = "oqituvchiComboBox";
            this.oqituvchiComboBox.Size = new System.Drawing.Size(340, 33);
            this.oqituvchiComboBox.TabIndex = 46;
            // 
            // Fanlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 694);
            this.Controls.Add(this.oqituvchiComboBox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.upgBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.kreditTxt);
            this.Controls.Add(this.fannarNametxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FanlarDataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Fanlar";
            this.Text = "Fanlar";
            this.Load += new System.EventHandler(this.Fanlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FanlarDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button upgBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.TextBox kreditTxt;
        private System.Windows.Forms.TextBox fannarNametxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView FanlarDataGridView;
        private System.Windows.Forms.ComboBox oqituvchiComboBox;
    }
}