using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Layer
{
    public class Ereigniss
    {
        public Ereigniss()
        {

        }
        public Ereigniss(string datum, string beschreibung)
        {
            this.Datum = datum;
            this.Beschreibung = beschreibung;
        }

      
        public string Datum { get; set; }
        public string Beschreibung { get; set; }
    }
}
