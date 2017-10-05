using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Layer;

namespace WpfApplication1.Logik.Maßnahmen
{
    public class Empfang
    {
        public static long GetPreis(long SO)
        {
            return SO * SO * SO;
        }

        public static long GetPreis(NachbarBaronie _empfangNachbar)
        {
            if(_empfangNachbar == null)
            {
                return 0;
            }
            return GetPreis(_empfangNachbar.SOStatus);
        }
    }
}
