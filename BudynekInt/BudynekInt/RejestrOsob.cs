using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudynekInt
{
    public class RejestrOsob
    {
        static private int iloscOsob = 0;
        public int iloscOSB { get { return iloscOsob; } }

        private List<Osoba> rejestrOsob = new List<Osoba>();
        public IReadOnlyList<Osoba> rejestrReadOnly { get { return rejestrOsob.AsReadOnly(); } }

        public void dodajOsobe(Osoba iOsb)
        {
            rejestrOsob.Add(iOsb);
            iloscOsob++;
        }
        public void usunOsobe(Osoba iOsb)
        {
            rejestrOsob.Remove(iOsb);
            iloscOsob--;
        }
        public void zmienDane(int i, string imie, string nazwisko, string add = ""){
            rejestrOsob[i].setImie(imie);
            rejestrOsob[i].setNazwisko(nazwisko);
            rejestrOsob[i].setDodatkowe(add);
        }


    }
}
