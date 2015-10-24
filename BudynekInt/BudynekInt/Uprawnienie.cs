using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudynekInt
{
    public class Uprawnienie : IEquatable<Uprawnienie>
    {
        public static int id_start = 0;
        private int id;
        private string uprawnienie;

        public Uprawnienie(String iUpr)
        {
            uprawnienie = iUpr;
            id = id_start;
            id_start++;
        }

        public override bool Equals(System.Object iObject)
        {
            if (iObject == null) return false;
            Uprawnienie objAsUpr = iObject as Uprawnienie;
            if (objAsUpr == null) return false;
            else return Equals(objAsUpr);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(Uprawnienie iUpr)
        {
            return iUpr.ToString() == this.uprawnienie;
        }
        public override string ToString()
        {
            return uprawnienie;
        }
    }
}
