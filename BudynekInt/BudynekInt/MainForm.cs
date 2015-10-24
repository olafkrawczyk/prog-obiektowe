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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        // Podstawowe zmienne przechowujące ilość pięter, budynek, rejestr Osob
        //
        private int iloscPieter;
        BudynekInteligetny budynek = new BudynekInteligetny();
        RejestrOsob rejestrOsob = new RejestrOsob();
        SystemOtwieraniaDrzwi systemOtwDrzwi = new SystemOtwieraniaDrzwi();

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Pobranie początkowych informacji od użytkownika i ustawienie zmiennych, nazwa, iloscPieter
            // Jeżeli dane nie zostaną przesłane poprawnie aplikacja zakończy działanie

            oknoStart okn2 = new oknoStart();
            okn2.ShowDialog();

            if (okn2.DialogResult == DialogResult.OK)
            {
                budynek.NAZWA = okn2.nazwaBud;
                this.Text = budynek.NAZWA;

                budynek.iloscPIETER = okn2.iloscPiet;
                this.iloscPieter = budynek.iloscPIETER;

                for (int i = 0; i < iloscPieter; i++)
                {
                    budynek.dodajPietro();
                }                
            }
            else
            {
                Close();
                Application.Exit();
            }
            listBox1.DataSource = budynek.pietraReadOnly;
            listBox3.DataSource = rejestrOsob.rejestrReadOnly;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            // Metoda pozwalająca wyświetlająca nowe okienko z możliwością dodawania nowych 
            // 
            menuOsoby men2 = new menuOsoby();
            men2.ShowDialog();

            if (men2.DialogResult == DialogResult.OK)
            {
                if (men2.klasa == "Mieszkaniec")
                {
                    rejestrOsob.dodajOsobe(new Mieszkaniec(men2.imie, men2.nazwisko, men2.dodatkowe));
                }
                else
                {
                    rejestrOsob.dodajOsobe(new Pracownik(men2.imie, men2.nazwisko, men2.dodatkowe));
                }
                listBox3.DataSource = rejestrOsob.rejestrReadOnly;
                label4.Text = "Ilosc osob: " + rejestrOsob.iloscOSB.ToString();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obsługa wybrania przez użytownika piętra z listbox1 wyświetlającego piętra
            // Po wybraniu piętra listbox2 będzie pokazywał strefy zawarte w zaznaczonym piętrze
            listBox2.DataSource = budynek.pietraReadOnly[listBox1.SelectedIndex].strefyReadOnly;
        }

        private void usunOsb_button_Click(object sender, EventArgs e)
        {
            // Przycisk obsługujący usuwanie osób z bazy
            // użytkownik musi potwierdzić usunięcie w wyskakującym okienku
            // metoda usuwania zawarta jest w klasie rejestr osob
            DialogResult dialogResult = MessageBox.Show("Usunąć?", "Usuwanie osoby", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes && listBox3.SelectedIndex >= 0)
            {
                rejestrOsob.usunOsobe(rejestrOsob.rejestrReadOnly[listBox3.SelectedIndex]);
                listBox3.DataSource = rejestrOsob.rejestrReadOnly;
                label4.Text = "Ilosc osob: " + rejestrOsob.iloscOSB.ToString();
            }
        }

        private void menuDane_button_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex >= 0)
            {
                // Przycisk wyświetlający menu edycji danych osoby
                string iKlasa = rejestrOsob.rejestrReadOnly[listBox3.SelectedIndex].GetType().ToString();

                menuOsoby menEdyt = new menuOsoby(rejestrOsob.rejestrReadOnly[listBox3.SelectedIndex].getImie(),
                    rejestrOsob.rejestrReadOnly[listBox3.SelectedIndex].getNazwisko(),
                    rejestrOsob.rejestrReadOnly[listBox3.SelectedIndex].pokazDodatkowe(), iKlasa);
                menEdyt.ShowDialog();

                rejestrOsob.zmienDane(listBox3.SelectedIndex, menEdyt.imie, menEdyt.nazwisko, menEdyt.dodatkowe);

                listBox3.DataSource = rejestrOsob.rejestrReadOnly;
            }
            
        }

        private void dodajStr_button_Click(object sender, EventArgs e)
        {
            // Przycisk obsługujący dodawanie nowych stref do pięter
            if (budynek.pietraReadOnly[listBox1.SelectedIndex].strefyReadOnly.Count == 0)
            {
                budynek.pietraReadOnly[listBox1.SelectedIndex].dodajStrefe(new Strefa(0));
                string uprawnienie = "P" + listBox1.SelectedIndex.ToString() + "S" + budynek.pietraReadOnly[listBox1.SelectedIndex].strefyReadOnly.Last().ID.ToString();
                budynek.pietraReadOnly[listBox1.SelectedIndex].strefyReadOnly.Last().dodajUprawnienie(new Uprawnienie(uprawnienie));
            
            }
            else
            {
                budynek.pietraReadOnly[listBox1.SelectedIndex].dodajStrefe(new Strefa());
                string uprawnienie = "P" + listBox1.SelectedIndex.ToString() + "S" + budynek.pietraReadOnly[listBox1.SelectedIndex].strefyReadOnly.Last().ID.ToString();
                budynek.pietraReadOnly[listBox1.SelectedIndex].strefyReadOnly.Last().dodajUprawnienie(new Uprawnienie(uprawnienie));
            }
            listBox2.DataSource = budynek.pietraReadOnly[listBox1.SelectedIndex].strefyReadOnly;
        }

        private void usunStr_button_Click(object sender, EventArgs e)
        {
            // Przycisk obsługujący usuwanie strefy z zaznaczonych pięter
            if (budynek.pietraReadOnly[listBox1.SelectedIndex].strefyReadOnly.Count != 0)
            {
                budynek.pietraReadOnly[listBox1.SelectedIndex].usunStrefe(budynek.pietraReadOnly[listBox1.SelectedIndex].strefyReadOnly[listBox2.SelectedIndex]);
                listBox2.DataSource = budynek.pietraReadOnly[listBox1.SelectedIndex].strefyReadOnly;
            }
        }

        private void menuUpr_button_Click(object sender, EventArgs e)
        {
            // Wyświetla okienko edycji/dodawania uprawnień wybranej osoby
            if (listBox3.SelectedIndex >= 0)
            {
                menuUprawnienia menuUpr = new menuUprawnienia(rejestrOsob.rejestrReadOnly[listBox3.SelectedIndex], budynek);
                menuUpr.ShowDialog();
            }
        }

        private void button_Otworz_Click(object sender, EventArgs e)
        {
            // Obsługa otwierania zaznaczonej strefy dla wybranej osoby
            // w zleżności od posiadanych uprawnień zostanie wyświetlony komunikat
            // informacja o próbie przekroczenia danej strefy zostanie zapisana w rejestrze
            if (listBox3.SelectedIndex >= 0 && listBox2.SelectedIndex >= 0 && listBox1.SelectedIndex >= 0){
            if( systemOtwDrzwi.otworz(rejestrOsob.rejestrReadOnly[listBox3.SelectedIndex],
                budynek.pietraReadOnly[listBox1.SelectedIndex],
                budynek.pietraReadOnly[listBox1.SelectedIndex].strefyReadOnly[listBox2.SelectedIndex])){

                MessageBox.Show("Dostęp przyznany!");
            }
            else{
                MessageBox.Show("Przejscie nieudane. Sprawdź raporty");
            }
            }
        }

        private void menuRaporty_button_Click(object sender, EventArgs e)
        {
            okienkoRaporty oknRapoty = new okienkoRaporty(systemOtwDrzwi);
            oknRapoty.ShowDialog();
        }

        private void oAutorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Inteligentny budynek v1.1\nProjekt wykonał: Olaf Krawczyk\nNr indeksu 218164\nWrocław 2015");
        }

        private void zablokujStr_button_Click_1(object sender, EventArgs e)
        {
            // Zablokwoanie wybranej strefy
            systemOtwDrzwi.zablokuj(budynek.pietraReadOnly[listBox1.SelectedIndex].strefyReadOnly[listBox2.SelectedIndex]);
        }

        private void odblokujStr_button_Click_1(object sender, EventArgs e)
        {
            // odblokowanie wybranej strefy
            systemOtwDrzwi.odblokuj(budynek.pietraReadOnly[listBox1.SelectedIndex].strefyReadOnly[listBox2.SelectedIndex]);
        }

        private void zablokowaneInfo_button_Click(object sender, EventArgs e)
        {
            // wyświetla informacje o zablokowanych piętrach
            zablokowaneStrOkno zablokowaneOkn = new zablokowaneStrOkno(systemOtwDrzwi);
            zablokowaneOkn.ShowDialog();
        }
    }
}
