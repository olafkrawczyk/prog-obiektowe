using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudynekInt
{
    public partial class menuUprawnienia : Form
    {
        // Okienko pozwalające na dodanie lub zabranie uprawnień wybranej osobie
        // pozwala na wybranie uprawnienia z dostępnych

        BudynekInteligetny budynek;
        Osoba osoba;

        public menuUprawnienia()
        {
            InitializeComponent();
        }
        public menuUprawnienia(Osoba iOsb, BudynekInteligetny iBud)
        {
            InitializeComponent();
            osoba = iOsb;
            budynek = iBud;
        }

        private void menuUprawnienia_Load(object sender, EventArgs e)
        {
            comboBox_Pietra.DataSource = budynek.pietraReadOnly;
            listBox1.DataSource = osoba.uprawnieniaReadOnly;
            textBox_Imie.Text = osoba.getImie();
            textBox_Nazwisko.Text = osoba.getNazwisko();
        }

        private void comboBox_Pietra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (budynek.pietraReadOnly[comboBox_Pietra.SelectedIndex].strefyReadOnly.Count == 0){
                comboBox1.Text = "";
        }
                comboBox1.DataSource = budynek.pietraReadOnly[comboBox_Pietra.SelectedIndex].strefyReadOnly;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                osoba.dodajUprawnienie(budynek.pietraReadOnly[comboBox_Pietra.SelectedIndex].strefyReadOnly[comboBox1.SelectedIndex].wymaganeUpr());
                listBox1.DataSource = osoba.uprawnieniaReadOnly;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                osoba.usunUprawnienie(osoba.uprawnieniaReadOnly[listBox1.SelectedIndex]);
                listBox1.DataSource = osoba.uprawnieniaReadOnly;
            }
        }
    }
}
