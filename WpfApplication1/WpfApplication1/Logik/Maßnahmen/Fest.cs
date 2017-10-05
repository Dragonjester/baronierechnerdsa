using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Logik.Maßnahmen
{
    public class Fest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="festStufe">0 = kein Fest!</param>
        /// <returns></returns>
        public static long FestPreisJe100Einwohner(int festStufe)
        {
            long[] preise = { 0, 1, 5, 20, 60, 200, 600 };
            return preise[festStufe];
        }

        public static long FestPreis(int festStufe, long anzEinwohner)
        {
            return FestPreisJe100Einwohner(festStufe) * anzEinwohner / 100;
        }
    }
}
