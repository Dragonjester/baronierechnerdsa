using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Logik.Maßnahmen
{
    public class Investition
    {
        public static long GetInvestitionspreis(long factor, long anzEinwohner)
        {
            return 10 * factor * anzEinwohner / 100;
        }
    }
}
