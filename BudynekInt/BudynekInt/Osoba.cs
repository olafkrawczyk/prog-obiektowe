using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudynekInt
{
    public class Osoba
    {
        public static int id = 0;

        private int id_osoby;
        public int getID { get { return id_osoby; } }
        private string imie;
        private string nazwisko;

        public string Text { get { return imie + " " + nazwisko; } }

        private List<Uprawnienie> uprawnienia = new List<Uprawnienie>();
        public IReadOnlyList<Uprawnienie> uprawnieniaReadOnly { get { return uprawnienia.AsReadOnly(); } }

        public Osoba()
        {
        }
        public Osoba(string iImie, string iNazwisko)
        {
            id_osoby = id;
            id++;
            imie = iImie;
            nazwisko = iNazwisko;

        }

        // Wirtualna metoda wyświetlająca imformacje o firmie lub nr mieszkania
        // w zależności od klasy
        public virtual string pokazDodatkowe()
        {
            return "";
        }

        // Wirtualna metoda ustalająca dodatkowy parametr firma/nr mieszkania
        public virtual void setDodatkowe(string add)
        {

        }


        // gettery i settery klasy osoba
        public string getImie()
        {
            return imie;
        }
        public string getNazwisko(){
            return nazwisko;
        }

        public void setImie(string iImie)
        {
            imie = iImie;
        }
        public void setNazwisko(string iNazwisko)
        {
            nazwisko = iNazwisko;
        }

        // Metody do obsługi uprawnień osoby
        public void dodajUprawnienie(Uprawnienie iUpr)
        {
            uprawnienia.Add(iUpr);
        }
        public void usunUprawnienie(Uprawnienie iUpr)
        {
            uprawnienia.Remove(iUpr);
        }
        public bool maUprawnienie(Uprawnienie iUpr)
        {
            return uprawnienia.Contains(iUpr);
        }
        public string wypiszUpr()
        {
            string output = "";
            foreach (Uprawnienie upr in uprawnienia)
            {
                output = upr.ToString() + " ";
            }
            return output;
        }

        public bool Equals(Osoba iOsb)
        {
            if (this.id_osoby == iOsb.id_osoby)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return id_osoby.ToString() + " " + imie + " " + nazwisko;
        }
        
    }
}
