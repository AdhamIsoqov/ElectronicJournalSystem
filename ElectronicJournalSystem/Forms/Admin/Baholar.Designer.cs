namespace ElectronicJournalSystem.Forms.Admin
{
    partial class Baholar
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
            this.BaholarDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.BaholarDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BaholarDataGridView
            // 
            this.BaholarDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BaholarDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BaholarDataGridView.Location = new System.Drawing.Point(34, 42);
            this.BaholarDataGridView.Name = "BaholarDataGridView";
            this.BaholarDataGridView.ReadOnly = true;
            this.BaholarDataGridView.RowHeadersWidth = 51;
            this.BaholarDataGridView.RowTemplate.Height = 24;
            this.BaholarDataGridView.Size = new System.Drawing.Size(916, 611);
            this.BaholarDataGridView.TabIndex = 46;
            // 
            // Baholar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 694);
            this.Controls.Add(this.BaholarDataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Baholar";
            this.Text = "Baholar";
            this.Load += new System.EventHandler(this.Baholar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaholarDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView BaholarDataGridView;
    }
}