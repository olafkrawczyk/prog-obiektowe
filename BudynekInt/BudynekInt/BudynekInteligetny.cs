using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudynekInt
{
    public class BudynekInteligetny
    {
        //  Podstawowe dane o budynku - nazwa, adres
        private string _adres;
        private string _nazwa;
        public string ADRES {get { return _adres; } set { _adres = value; }}
        public string NAZWA { get { return _nazwa; } set { _nazwa = value; } }
        private int ilosc_pieter;
        public int iloscPIETER { get { return ilosc_pieter; } set { this.ilosc_pieter = value; } }

        // Lista generyczna przechowująca obiekty typu piętro oraz getter 
        public List<Pietro> _pietra = new List<Pietro>();
        public IReadOnlyList<Pietro> pietraReadOnly { get { return _pietra.AsReadOnly(); } } // getter pięter

        public BudynekInteligetny()
        {
        }
        public BudynekInteligetny(string iNazwa){
            _nazwa = iNazwa;
        }


        // Metoda pozwalająca dodać nowe piętro
        public void dodajPietro(){
            _pietra.Add(new Pietro());
        }
    }
}
