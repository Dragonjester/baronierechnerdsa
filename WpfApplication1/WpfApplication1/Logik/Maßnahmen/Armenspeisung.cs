using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Logik.Maßnahmen
{
    class Armenspeisung
    {
        public static long GetPreis(long faktor)
        {
            return faktor * 50;
        }
    }
}
