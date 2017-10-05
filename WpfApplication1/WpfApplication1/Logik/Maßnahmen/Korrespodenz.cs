using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Layer;

namespace WpfApplication1.Logik.Maßnahmen
{
    public class Korrespodenz
    {
        public static long GetPreis(long SO)
        {
            return SO;
        }

        public static long GetPreis(NachbarBaronie _korrespodenzNachbar)
        {
            if(_korrespodenzNachbar == null)
            {
                return 0;
            }
            return GetPreis(_korrespodenzNachbar.SOStatus);
        }
    }
}
