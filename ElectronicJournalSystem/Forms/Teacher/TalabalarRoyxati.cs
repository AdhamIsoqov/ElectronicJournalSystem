using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ElectronicJournalSystem.Forms.Teacher
{
    public partial class TalabalarRoyxati : Form
    {
        public class BahoModel
        {
            public string Fan { get; set; }
            public string Guruh { get; set; }
            public string Talaba { get; set; }
            public int Baho { get; set; }
        }

        private List<BahoModel> baholar = new List<BahoModel>();

        public TalabalarRoyxati()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            FanComboBox.Items.AddRange(new string[] { "Matematika", "Ingliz tili", "Fizika" });
            GuruhComboBox.Items.AddRange(new string[] { "1-Guruh", "2-Guruh", "3-Guruh" });
            TalabaComboBox.Items.AddRange(new string[] { "Aliyev Aziz", "Karimova Laylo", "Turgunov Sanjar" });

            FanComboBox.SelectedIndex = 0;
            GuruhComboBox.SelectedIndex = 0;
            TalabaComboBox.SelectedIndex = 0;

            BahoNumericUpDown.Minimum = 0;
            BahoNumericUpDown.Maximum = 100;

            UpdateGrid();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string fan = FanComboBox.Text;
            string guruh = GuruhComboBox.Text;
            string talaba = TalabaComboBox.Text;
            int baho = (int)BahoNumericUpDown.Value;

            // Baho tekshiruvi
            if (baho < 0 || baho > 100)
            {
                MessageBox.Show("Baho 0 dan kichik yoki 100 dan katta bo'lishi mumkin emas!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Avval qo‘yilgan bahoni tekshirish
            if (baholar.Any(b => b.Fan == fan && b.Guruh == guruh && b.Talaba == talaba))
            {
                MessageBox.Show("Bu talaba uchun ushbu fan va guruhga baho allaqachon qo‘yilgan!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            baholar.Add(new BahoModel { Fan = fan, Guruh = guruh, Talaba = talaba, Baho = baho });
            UpdateGrid();
        }

        private void upgBtn_Click(object sender, EventArgs e)
        {
            string fan = FanComboBox.Text;
            string guruh = GuruhComboBox.Text;
            string talaba = TalabaComboBox.Text;
            int baho = (int)BahoNumericUpDown.Value;

            var existing = baholar.FirstOrDefault(b => b.Fan == fan && b.Guruh == guruh && b.Talaba == talaba);
            if (existing == null)
            {
                MessageBox.Show("Ushbu talaba uchun hali baho qo‘yilmagan, yangilab bo‘lmaydi.", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            existing.Baho = baho;
            UpdateGrid();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            string fan = FanComboBox.Text;
            string guruh = GuruhComboBox.Text;
            string talaba = TalabaComboBox.Text;

            var existing = baholar.FirstOrDefault(b => b.Fan == fan && b.Guruh == guruh && b.Talaba == talaba);
            if (existing != null)
            {
                baholar.Remove(existing);
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Ushbu yozuv topilmadi.", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateGrid()
        {
            OqituvchiFanDataGridView.DataSource = null;
            OqituvchiFanDataGridView.DataSource = baholar;
        }
    }
}
