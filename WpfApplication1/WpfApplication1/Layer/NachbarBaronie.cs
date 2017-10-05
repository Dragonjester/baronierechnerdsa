using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Layer
{
    public class NachbarBaronie
    {
        public int SelectedIndexBeziehung { get; set; }
        public int SOStatus { get; set; }

        public String NameDerBaronie { get; set; }

        public NachbarBaronie()
        {
            SelectedIndexBeziehung = -1;
            SOStatus = 10;
            NameDerBaronie = "";
        }

        private static String[] Beziehungsstufen = { "Verfeindet", "Abgeneigt", "Skeptisch", "Neutral", "Offen", "Verbündet", "freundschaftlich"};

        public string GetBeziehungsName()
        {
            if(SelectedIndexBeziehung >= 0) { 
                return Beziehungsstufen[SelectedIndexBeziehung];
            }
            return "Unbekannter Wert: " + SelectedIndexBeziehung;
        }

        public override string ToString()
        {
            return NameDerBaronie + " SO: " + SOStatus + " (" + GetBeziehungsName() + ")";
        }
    }
}
