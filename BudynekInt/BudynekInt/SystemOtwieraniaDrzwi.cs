    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudynekInt
{
    public class SystemOtwieraniaDrzwi
    {
        private List<Raport> udanePrzejscia = new List<Raport>();
        private List<Raport> nieudanePrzejscia = new List<Raport>();
        private List<Strefa> zablokowane = new List<Strefa>();

        //gettery i settery do list;
        public IReadOnlyList<Raport> udaneReadOnly { get { return udanePrzejscia.AsReadOnly(); } }
        public IReadOnlyList<Raport> nieudaneReadOnly { get { return nieudanePrzejscia.AsReadOnly(); } }
        public IReadOnlyList<Strefa> zablokowaneReadOnly { get { return zablokowane.AsReadOnly(); } }
      
        public SystemOtwieraniaDrzwi()
        {
        }

        public bool otworz(Osoba iOsb, Pietro iPiet, Strefa iStref)
        {
            bool isBlocked = zablokowane.Contains(iStref);

            if (!isBlocked && iOsb.maUprawnienie(iStref.wymaganeUpr()))
            {
                udanePrzejscia.Add(new Raport(iOsb, iPiet.ID, iStref.ID));
                return true;
            }
            else
            {
                nieudanePrzejscia.Add(new Raport(iOsb, iPiet.ID, iStref.ID));
                return false;
            }
        }
        public void zablokuj(Strefa iStref)
        {
            zablokowane.Add(iStref);
        }
        public void odblokuj(Strefa iStref)
        {
            zablokowane.Remove(iStref);
        }
        public void wyczysc()
        {
            nieudanePrzejscia.Clear();
            udanePrzejscia.Clear();
        }
    }
}
