using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudynekInt
{
    public class Raport
    {
        // Klasa raport wykorzystywana przez klasę SystemOtwieraniaDrzwi do przechowywania informacji
        // o osobach i strefach jakie chciały przekroczyć 
        private Osoba osoba;
        int id_pietra, id_strefy;
        private DateTime czas;

        public Raport(Osoba iOsb, int iId_pietra, int iID_strefy)
        {
            osoba = iOsb;
            id_pietra = iId_pietra;
            id_strefy = iID_strefy;
            czas = DateTime.Now;
        }
        public override string ToString()
        {
            string output = "";
            output = "Data: " + czas.ToString() + " " +  osoba.ToString() + " Piętro: " + id_pietra.ToString() + " Strefa: " + id_strefy.ToString() ;
            return output;
        }
    }
}
