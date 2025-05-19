using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicJournalSystem.Forms.Student
{
    public partial class TalabaForm : Form
    {
        public TalabaForm(int userId)
        {
            InitializeComponent();
            this.studentId = userId;
        }
        int studentId = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            ShaxsiyMalumotlarForm form = new ShaxsiyMalumotlarForm();
            formPanel.Controls.Clear();
            form.TopLevel = false;
            form.BringToFront();
            formPanel.Controls.Add(form);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BaholarniKorishForm form = new BaholarniKorishForm(studentId);
            formPanel.Controls.Clear();
            form.TopLevel = false;
            form.BringToFront();
            formPanel.Controls.Add(form);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
