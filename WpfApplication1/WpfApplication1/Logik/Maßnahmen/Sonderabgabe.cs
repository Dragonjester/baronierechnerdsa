using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Logik.Maßnahmen
{
    public class Sonderabgabe
    {
        public static long GetPreis(long dukatenJe100, long AnzEinwohner)
        {
            return -1 * dukatenJe100 * AnzEinwohner / 100;
        }
    }
}
