using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using ElectronicJournalSystem.Data;
using ElectronicJournalSystem.Models;

namespace ElectronicJournalSystem.Forms.Admin
{
    public partial class AdminForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ElectronicJurnalDB"].ConnectionString;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Oqituvchilar form = new Oqituvchilar();
            form.TopLevel = false;
            formPanel.Controls.Clear();
            form.BringToFront();
            formPanel.Controls.Add(form);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Talabalar form = new Talabalar();
            form.TopLevel = false;
            formPanel.Controls.Clear();
            form.BringToFront();
            formPanel.Controls.Add(form);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Guruhlar form = new Guruhlar();
            form.TopLevel = false;
            formPanel.Controls.Clear();
            form.BringToFront();
            formPanel.Controls.Add(form);
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fanlar form = new Fanlar();
            form.TopLevel = false;
            formPanel.Controls.Clear();
            form.BringToFront();
            formPanel.Controls.Add(form);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Baholar form = new Baholar();
            form.TopLevel = false;
            formPanel.Controls.Clear();
            form.BringToFront();
            formPanel.Controls.Add(form);
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }
    }
}
