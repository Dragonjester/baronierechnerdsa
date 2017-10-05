using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Logik
{
    public class Wuerfelbecher
    {
        static Random rnd = new Random();

        public static int GetD6()
        {
            return rnd.Next(1, 7);
        }

        public static int GetD100()
        {
            return rnd.Next(1, 101);
        }

        public static int GetD12()
        {
            return rnd.Next(1, 13);
        }

        public static int GetD13()
        {
            return rnd.Next(1, 14);
        }

        public static int GetD20()
        {
            return rnd.Next(1, 21);
        }

        /// <summary>
        /// Talentprobe für DSA 4.1. Es werden nur die TaP* ausgerechnet. Weder 2 bzw. 3x 1 bzw. 20 werden berücksichtigt.
        /// Die Probe wurde geschaft, wenn der RückgabeWert >= 1 ist.
        /// </summary>
        /// <param name="e1">Eigenschaft 1</param>
        /// <param name="e2">Eigenschaft 2</param>
        /// <param name="e3">Eigenschaft 3</param>
        /// <param name="taw">Talentwert</param>
        /// <param name="mod">Modifikator (Minus = Erleichterung, Plus = Erschwerniss)</param>
        /// <returns>TaP* bzw. Punkte die die Probe daneben ist</returns>
        public static int Dsa41TalentProbe(int e1, int e2, int e3, int taw, int mod)
        {
            int modTaw = taw - mod;
            int restTaP = modTaw - Math.Max(0, GetD20() - e1) - Math.Max(0, GetD20() - e2) - Math.Max(0, GetD20() - e3);

            //eine genau bestandene Probe ist bestanden. 
            //eine bestandene Probe hat min. 1 TaP*
            if (restTaP == 0)
            {
                restTaP = 1;
            }

            if(restTaP > taw)
            {
                restTaP = taw;
            }

            return restTaP;
        }
    }
}
