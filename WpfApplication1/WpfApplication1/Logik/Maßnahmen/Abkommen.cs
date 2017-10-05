using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Layer;

namespace WpfApplication1.Logik.Maßnahmen
{
    public class Abkommen
    {
        public static long GetPreis(long SO)
        {
            return SO * SO;
        }

        public static long GetPreis(NachbarBaronie nachbar)
        {
            if(nachbar == null)
            {
                return 0;
            }
            return GetPreis(nachbar.SOStatus);
        }
    }
}
