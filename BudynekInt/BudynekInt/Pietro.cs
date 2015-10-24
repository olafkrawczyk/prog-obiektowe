using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudynekInt
{
    public class Pietro
    {
        private static int id = 0;
        private int id_pietra;
        public int ID { get { return id_pietra; } }
        private List<Strefa> strefy = new List<Strefa>();
        public IReadOnlyList<Strefa> strefyReadOnly { get { return strefy.AsReadOnly(); } }
        public Pietro()
        {
            id_pietra = id;
            id++;
        }
        public void dodajStrefe(Strefa iStref)
        {
            strefy.Add(iStref);
        }
        public void usunStrefe(Strefa iStref)
        {
            strefy.Remove(iStref);
        }
        public string wypiszStr(){
            string output = "";
            foreach (Strefa str in strefy){
                output += str.ID.ToString() + " ";
            }
            return output;
        }
        public override string ToString()
        {
            return "Piętro " + id_pietra.ToString();
        }
    }
}
