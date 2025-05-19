namespace ElectronicJournalSystem.Forms.Student
{
    partial class BaholarniKorishForm
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
            this.BahoDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.BahoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BahoDataGridView
            // 
            this.BahoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BahoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BahoDataGridView.Location = new System.Drawing.Point(40, 36);
            this.BahoDataGridView.Name = "BahoDataGridView";
            this.BahoDataGridView.RowHeadersWidth = 51;
            this.BahoDataGridView.RowTemplate.Height = 24;
            this.BahoDataGridView.Size = new System.Drawing.Size(891, 605);
            this.BahoDataGridView.TabIndex = 0;
            // 
            // BaholarniKorishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 678);
            this.Controls.Add(this.BahoDataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BaholarniKorishForm";
            this.Text = "BaholarniKorishForm";
            this.Load += new System.EventHandler(this.BaholarniKorishForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BahoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView BahoDataGridView;
    }
}