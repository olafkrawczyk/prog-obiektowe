using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudynekInt
{
    public class Pracownik : Osoba
    {
        private string _firma;
        public string firma { get { return _firma; } set { this._firma = value; } }

        public Pracownik(string iImie, string iNazwisko, string iFirma)
            : base(iImie, iNazwisko)
        {
            firma = iFirma;
        }
        public override string pokazDodatkowe()
        {
            return firma;
        }
        public override void setDodatkowe(string add)
        {
            firma = add;
        }

        public override string ToString()
        {
            return base.ToString() + " " + firma + " [P] ";
        }
    }
}
