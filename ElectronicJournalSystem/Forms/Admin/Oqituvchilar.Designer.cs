namespace ElectronicJournalSystem.Forms.Admin
{
    partial class Oqituvchilar
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
            this.OqituvchiDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.oqituvchiFISHtxt = new System.Windows.Forms.TextBox();
            this.mutaxasislikTxt = new System.Windows.Forms.TextBox();
            this.oqituvchiLogintxt = new System.Windows.Forms.TextBox();
            this.oqituvchiParoltxt = new System.Windows.Forms.TextBox();
            this.delBtn = new System.Windows.Forms.Button();
            this.upgBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OqituvchiDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OqituvchiDataGridView
            // 
            this.OqituvchiDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OqituvchiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OqituvchiDataGridView.Location = new System.Drawing.Point(33, 41);
            this.OqituvchiDataGridView.Name = "OqituvchiDataGridView";
            this.OqituvchiDataGridView.ReadOnly = true;
            this.OqituvchiDataGridView.RowHeadersWidth = 51;
            this.OqituvchiDataGridView.RowTemplate.Height = 24;
            this.OqituvchiDataGridView.Size = new System.Drawing.Size(916, 488);
            this.OqituvchiDataGridView.TabIndex = 0;
            this.OqituvchiDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OqituvchiDataGridView_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 532);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "F.I.Sh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 532);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mutaxasislik";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 532);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Login";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(720, 532);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Parol";
            // 
            // oqituvchiFISHtxt
            // 
            this.oqituvchiFISHtxt.Location = new System.Drawing.Point(42, 561);
            this.oqituvchiFISHtxt.Name = "oqituvchiFISHtxt";
            this.oqituvchiFISHtxt.Size = new System.Drawing.Size(222, 30);
            this.oqituvchiFISHtxt.TabIndex = 5;
            // 
            // mutaxasislikTxt
            // 
            this.mutaxasislikTxt.Location = new System.Drawing.Point(269, 561);
            this.mutaxasislikTxt.Name = "mutaxasislikTxt";
            this.mutaxasislikTxt.Size = new System.Drawing.Size(222, 30);
            this.mutaxasislikTxt.TabIndex = 6;
            // 
            // oqituvchiLogintxt
            // 
            this.oqituvchiLogintxt.Location = new System.Drawing.Point(497, 561);
            this.oqituvchiLogintxt.Name = "oqituvchiLogintxt";
            this.oqituvchiLogintxt.Size = new System.Drawing.Size(222, 30);
            this.oqituvchiLogintxt.TabIndex = 7;
            // 
            // oqituvchiParoltxt
            // 
            this.oqituvchiParoltxt.Location = new System.Drawing.Point(725, 561);
            this.oqituvchiParoltxt.Name = "oqituvchiParoltxt";
            this.oqituvchiParoltxt.Size = new System.Drawing.Size(222, 30);
            this.oqituvchiParoltxt.TabIndex = 8;
            // 
            // delBtn
            // 
            this.delBtn.BackColor = System.Drawing.Color.Red;
            this.delBtn.ForeColor = System.Drawing.Color.White;
            this.delBtn.Location = new System.Drawing.Point(783, 598);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(163, 54);
            this.delBtn.TabIndex = 9;
            this.delBtn.Text = "O\'chirish";
            this.delBtn.UseVisualStyleBackColor = false;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // upgBtn
            // 
            this.upgBtn.BackColor = System.Drawing.Color.Blue;
            this.upgBtn.ForeColor = System.Drawing.Color.White;
            this.upgBtn.Location = new System.Drawing.Point(614, 597);
            this.upgBtn.Name = "upgBtn";
            this.upgBtn.Size = new System.Drawing.Size(163, 54);
            this.upgBtn.TabIndex = 10;
            this.upgBtn.Text = "Yangilash";
            this.upgBtn.UseVisualStyleBackColor = false;
            this.upgBtn.Click += new System.EventHandler(this.upgBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.Lime;
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(445, 598);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(163, 54);
            this.addBtn.TabIndex = 11;
            this.addBtn.Text = "Qo\'shish";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // Oqituvchilar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 694);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.upgBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.oqituvchiParoltxt);
            this.Controls.Add(this.oqituvchiLogintxt);
            this.Controls.Add(this.mutaxasislikTxt);
            this.Controls.Add(this.oqituvchiFISHtxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OqituvchiDataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Oqituvchilar";
            this.Text = "Oqituvchilar";
            this.Load += new System.EventHandler(this.Oqituvchilar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OqituvchiDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView OqituvchiDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox oqituvchiFISHtxt;
        private System.Windows.Forms.TextBox mutaxasislikTxt;
        private System.Windows.Forms.TextBox oqituvchiLogintxt;
        private System.Windows.Forms.TextBox oqituvchiParoltxt;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button upgBtn;
        private System.Windows.Forms.Button addBtn;
    }
}