
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WpfApplication1.Logik.Config
{
    public class Config
    {
        public string NameLabel { get; set; }
        public string GeldbestandLabel { get; set; }
        public string AnzBeschäftigteLabel { get; set; }
        public string LoyalitätLabel { get; set; }
        public string MoralLabel { get; set; }
        public string SoLabel { get; set; }
        public string GroupboxSöldnerLabel { get; set; }
        public string GroupboxGardistenLabel { get; set; }
        public string GroupboxEreignisseLabel { get; set; }

        [XmlArray(ElementName = "ModifikatorenZuBodenTyp")]
        [XmlArrayItem(ElementName = "ModifikatorZuBodenTyp")]
        public List<Modifikator> ModifikatorenZuBodenTyp { get; set; }
        [XmlArray(ElementName = "BodenTypen")]
        [XmlArrayItem(ElementName = "BodenTyp")]
        public List<Modifikator> BodenTypen { get; set; }


        public Config()
        {
            ModifikatorenZuBodenTyp = new List<Modifikator>();
            BodenTypen = new List<Modifikator>();
        }
    }
}