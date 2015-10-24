using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudynekInt
{
    public class Strefa
    {
        private static int id = 0;
        private int id_strefy;
        public int statID { get { return id; } set { id = value; }}
        public int ID { get { return id_strefy; } } // Getter id

        Uprawnienie wymaganeUprawnienie;

        public Strefa(int startId)
        {
            id = startId;
            id++;
        }
        public Strefa()
        {
            id_strefy = id;
            id++;
        }

        //zmiana uprawnien
        public void dodajUprawnienie(Uprawnienie iUpr)
        {
            wymaganeUprawnienie = iUpr;
        }

        //zwraca wymagane uprawnienia
        public Uprawnienie wymaganeUpr()
        {
            return wymaganeUprawnienie;
        }

        // porównanie stref ze względu na id oraz wymagane uprawnienia
        public bool Equals(Strefa iStr){
            if (this.id_strefy == iStr.id_strefy && this.wymaganeUprawnienie == iStr.wymaganeUprawnienie)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return "Strefa " + id_strefy.ToString();
        }
    }
}
