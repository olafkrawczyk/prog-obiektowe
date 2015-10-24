using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudynekInt
{
    class Mieszkaniec : Osoba
    {
        // Klasa mieszkaniec, rozszerza klasę osoba o dodatkowe informacje - nr mieszkania
        private string _nrMieszkania { get; set; }
        public string nrMieszkania {
            set { this._nrMieszkania = value; }
            get { return this._nrMieszkania; }
        }

        public Mieszkaniec(string iImie, string iNazwisko, string iNrMieszkania) : base(iImie, iNazwisko)
        {
            _nrMieszkania = iNrMieszkania;
        }
        public override string pokazDodatkowe()
        {
            return _nrMieszkania;
        }
        public override void setDodatkowe(string add)
        {
            nrMieszkania = add;
        }

        public override string ToString()
        {
            return base.ToString() + " " + _nrMieszkania + " [M]";
        }

    }
}
