using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Logik.Config
{
    public class ConfigReader
    {
        public static Config GetDefaultConfig()
        {
            Config config = new Logik.Config.Config();
            config.NameLabel = "Baronie:";
            config.GeldbestandLabel = "Goldkammer:";
            config.AnzBeschäftigteLabel = "Anzahl Einwohner:";
            config.LoyalitätLabel = "Loyalität:";
            config.MoralLabel = "Moral:";
            config.SoLabel = "SO des Barons:";
            config.GroupboxSöldnerLabel = "Söldnerbanner";
            config.GroupboxGardistenLabel = "Gardisten";
            config.GroupboxEreignisseLabel = "Ereignisse";

            config.ModifikatorenZuBodenTyp.Add(new Modifikator("Wenige Straßen", -0.2 ));
            config.ModifikatorenZuBodenTyp.Add(new Modifikator("Anschluss an Reichsstraße", 0.1));
            config.ModifikatorenZuBodenTyp.Add(new Modifikator("Schiffbarer Fluss", 0.1));
            config.ModifikatorenZuBodenTyp.Add(new Modifikator("Flusshafen mit Stapelrecht", 0.1));
            config.ModifikatorenZuBodenTyp.Add(new Modifikator("Flusshafen mit Stapelrecht", 0.1));
            config.ModifikatorenZuBodenTyp.Add(new Modifikator("Kohlebergwerk", 0.1));
            config.ModifikatorenZuBodenTyp.Add(new Modifikator("Miene", 0.2));
            config.ModifikatorenZuBodenTyp.Add(new Modifikator("Silbermiene", 0.3));
            config.ModifikatorenZuBodenTyp.Add(new Modifikator("Goldmiene", 0.5));


            config.BodenTypen.Add(new Modifikator("Karg", 0.25));
            config.BodenTypen.Add(new Modifikator("Unwirtlich", 0.5));
            config.BodenTypen.Add(new Modifikator("Durchschnittlich", 1));
            config.BodenTypen.Add(new Modifikator("Fruchtbar", 1.5));
            config.BodenTypen.Add(new Modifikator("Sehr Fruchtbar", 2));

            return config;
        }
    }
}
