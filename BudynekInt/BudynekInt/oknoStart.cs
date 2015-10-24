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
    public partial class oknoStart : Form
    {
        // Okno startowe pobiera od użytkownika początkowe informacje potrzebne do inicjalizacji programu (ilość pięter oraz nazwa
        // budynku)

        int _iloscPieter;
        string _nazwaBudynku;

        // gettery do atrybutów
        public int iloscPiet { get { return _iloscPieter; } }
        public string nazwaBud { get { return _nazwaBudynku; } }

        public oknoStart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Sprawdzamy czy wszystkie pola zostały wypełnione

            if (nazwaBox.Text != "" && int.TryParse(iloscPiBox.Text, out _iloscPieter) && _iloscPieter > 0)
            {
                _nazwaBudynku = nazwaBox.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Wypełnij poprawnie wszystkie pola", "Błąd");
            }
        }

        private void oknoStart_Load(object sender, EventArgs e)
        {

        }
    }
}
