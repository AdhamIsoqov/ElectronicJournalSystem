using ElectronicJournalSystem.Forms.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicJournalSystem.Forms.Teacher
{
    public partial class OqituvchiForm : Form
    {
        public OqituvchiForm(int userId)
        {
            InitializeComponent();
            this.teacherId = userId;
        }
        int teacherId = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Fanlar form = new Fanlar();
            formPanel.Controls.Clear();
            form.TopLevel = false;
            form.BringToFront();
            formPanel.Controls.Add(form);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TalabalarRoyxati form = new TalabalarRoyxati(teacherId);
            formPanel.Controls.Clear();
            form.TopLevel = false;
            form.BringToFront();
            formPanel.Controls.Add(form);
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShaxsiyMalumotlarFormOqituvchi shaxsiyMalumotlarFormOqituvchi = new ShaxsiyMalumotlarFormOqituvchi(teacherId);
            shaxsiyMalumotlarFormOqituvchi.TopLevel = false;
            shaxsiyMalumotlarFormOqituvchi.BringToFront();
            formPanel.Controls.Clear();
            formPanel.Controls.Add(shaxsiyMalumotlarFormOqituvchi);
            shaxsiyMalumotlarFormOqituvchi.Show();
        }
    }
}
