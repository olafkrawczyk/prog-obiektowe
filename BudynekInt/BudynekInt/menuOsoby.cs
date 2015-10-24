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
    public partial class menuOsoby : Form
    {
        // Okienko obsługujące dodawanie oraz edycję danych 
        // komunikacja z oknem, z którego zostałow wywołane menuOsoby 
        // realizowana jest przez gettery
        // atrybut określa czy następuje edycja, czy dodanie nowej osoby

        private string _imie, _nazwisko, _dodatkowe, _klasa;
        private bool edit;

        //gettery
        public string imie { get { return _imie; } }
        public string nazwisko { get { return _nazwisko; } }
        public string dodatkowe { get { return _dodatkowe; } }
        public string klasa { get { return _klasa; } }

        public menuOsoby()
        {
            InitializeComponent();
        }
        public menuOsoby(string iImie, string iNazwisko, string iDod, string iKlasa)
        {
            InitializeComponent();
            _imie = iImie;
            _nazwisko = iNazwisko;
            _dodatkowe = iDod;
            _klasa = iKlasa;
            edit = true;
        }


        private void menuOsoby_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            if (edit)
            {
                if (_klasa == "BudynekInt.Mieszkaniec")
                {
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    comboBox1.SelectedIndex = 1;
                }
                comboBox1.Enabled = false;

                textBox_Imie.Text = _imie;
                textBox_Nazwisko.Text = _nazwisko;
                textBox_Dodatkowe.Text = _dodatkowe;
                button1.Text = "Aktualizuj";
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label3.Text = "Nr mieszkania";
            }
            else
            {
                label3.Text = "Firma";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox_Imie.Text != "" &&
                textBox_Nazwisko.Text != "" &&
                textBox_Dodatkowe.Text != "")
            {

                _imie = textBox_Imie.Text;
                _nazwisko = textBox_Nazwisko.Text;
                _dodatkowe = textBox_Dodatkowe.Text;

                if (comboBox1.SelectedIndex == 0)
                {
                    _klasa = "Mieszkaniec";
                }
                else
                {
                    _klasa = "Pracownik";
                }
                this.DialogResult = DialogResult.OK;
            }

            else
            {
                MessageBox.Show("Wypełnij poprawnie wszystkie pola");
            }
        }

        private void textBox_Imie_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
