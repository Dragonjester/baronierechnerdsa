using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Logik.Maßnahmen
{
    public class Warenschau
    {
        public static long GetWarenschauPreis(Boolean macheSchau, long anzEinwohner)
        {
            if (macheSchau)
            {
                return 50 * anzEinwohner / 100;
            }
            return 0;
        }
    }
}
