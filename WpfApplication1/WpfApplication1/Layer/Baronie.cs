using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApplication1.Logik.Config;

namespace WpfApplication1.Layer
{
    public class Baronie
    {
        public string Name { get; set; }
        public double SchatzKammerInDukaten { get; set; }
        public int Moral { get; set; }
        public int Loyalitaet { get; set; }
        public int Beziehung {
            get {
                if(Nachbarn.Count == 0)
                {
                    return 3;
                }
                return Nachbarn.Select(x => x.SelectedIndexBeziehung).Sum() / Nachbarn.Count;
            }
        }

        public int AktuellesJahr;
        public Monate AktuellerMonat;

        public long AnzahlEinwohner { get; set; }
        public int SoDesBarons { get; set; }

        public double Zehnt { get; set; }

        public double EinnahmenDesJahres { get; set; }

        public double KaiserTaler { get; set; }
        
        public ObservableCollection<Ereigniss> Ereignisse { get; set; }
        public ObservableCollection<Angestellter> Angestellte { get; set; }

        public ObservableCollection<SöldnerEinheit> SöldnerEinheiten { get; set; }
        public ObservableCollection<Gardist> Gardisten { get; set; }


        public ObservableCollection<NachbarBaronie> Nachbarn { get; set; }
        

        public Modifikator BodenGüte { get; set; }
        public ObservableCollection<Modifikator> BodenGüteModifikatoren { get; set; }

        public RegionTyp RegionsTyp { get; set; }
        public long AnzahlEigenerDomänen { get; set; }

        public void AddEreigniss(Ereigniss ereigniss)
        {
            Ereignisse.Insert(0, ereigniss);
        }

        public Config MyConfig { get; set; }
        public Baronie()
        {
            Ereignisse = new ObservableCollection<Ereigniss>();
            Angestellte = new ObservableCollection<Angestellter>();
            BodenGüteModifikatoren = new ObservableCollection<Modifikator>();
            SöldnerEinheiten = new ObservableCollection<SöldnerEinheit>();
            Gardisten = new ObservableCollection<Gardist>();
            Nachbarn = new ObservableCollection<NachbarBaronie>();

            MyConfig = ConfigReader.GetDefaultConfig();
        }

        public String AktuellerMonatString
        {
            get
            {
                return AktuellesJahr + " " + AktuellerMonat;
            }
        }

        private void EntnehmeKaiserTaler()
        {
            double kaiserTaler = KaiserTaler * AnzahlEinwohner;
            AddEreigniss(new Ereigniss(AktuellerMonatString, "KaiserTaler: -" + kaiserTaler + "D"));
            SchatzKammerInDukaten -= kaiserTaler;
        }

        private void EntnehmeLebensStyle()
        {
            double lebensstilkosten;
            if (SoDesBarons >= 16)
            {
                lebensstilkosten = 500;
            }
            else if (SoDesBarons >= 13)
            {
                lebensstilkosten = 150;
            }
            else if (SoDesBarons >= 10)
            {
                lebensstilkosten = 50;
            }
            else if (SoDesBarons >= 7)
            {
                lebensstilkosten = 15;
            }
            else
            {
                lebensstilkosten = -1;
            }

            AddEreigniss(new Ereigniss(AktuellerMonatString, "Lebensstil: -" + lebensstilkosten + "D"));
            SchatzKammerInDukaten -= lebensstilkosten;
        }

        private void EntnehmeTempelzehnt()
        {
            double tempelzehnt = EinnahmenDesJahres * 0.1;
            AddEreigniss(new Ereigniss(AktuellerMonatString, "Tempelzehnt: -" + tempelzehnt + "D"));
            SchatzKammerInDukaten -= tempelzehnt;
        }


        public void SetzeAufNaechsteNonat()
        {
            SetzeMonatsEreignisse();

            switch (AktuellerMonat)
            {
                case Monate.Praios:
                    AktuellerMonat = Monate.Rondra;
                    break;
                case Monate.Rondra:
                    AktuellerMonat = Monate.Efferd;
                    break;
                case Monate.Efferd:
                    AktuellerMonat = Monate.Travia;
                    break;
                case Monate.Travia:
                    AktuellerMonat = Monate.Boron;
                    break;
                case Monate.Boron:
                    AktuellerMonat = Monate.Hesinde;
                    break;
                case Monate.Hesinde:
                    AktuellerMonat = Monate.Firun;
                    break;
                case Monate.Firun:
                    AktuellerMonat = Monate.Tsa;
                    break;
                case Monate.Tsa:
                    AktuellerMonat = Monate.Phex;
                    break;
                case Monate.Phex:
                    AktuellerMonat = Monate.Peraine;
                    break;
                case Monate.Peraine:
                    AktuellerMonat = Monate.Ingerimm;
                    break;
                case Monate.Ingerimm:
                    AktuellerMonat = Monate.Rahja;
                    break;
                case Monate.Rahja:
                    BevölkerungsEntwicklung();
                    AktuellerMonat = Monate.Praios;
                    AktuellesJahr++;
                    break;
            }
        }

        private void BevölkerungsEntwicklung()
        {
            long bez = ProbenModifikatorBeziehung;
            long loya = ProbenModifikatorLoyalität;
            long moral = ProbenModifikatorMoral;

            double totalMod = bez + loya + moral;

            totalMod *= -1;
            totalMod /= 100.0;

            long entwicklung = (long) Math.Floor(AnzahlEinwohner * totalMod);
            AddEreigniss("Bevölkerungsveränderung: " + entwicklung);
            AnzahlEinwohner += entwicklung;
        }

        public void AddEreigniss(string message)
        {
            AddEreigniss(new Ereigniss(AktuellerMonatString, message));
        }

        private void SetzeMonatsEreignisse()
        {
            switch (AktuellerMonat)
            {
                case Monate.Praios:
                    EntnehmeKaiserTaler();
                    EntnehmeTempelzehnt();
                    EinnahmenDesJahres = 0;
                    break;
                case Monate.Rondra:
                    EinnahmenDesJahres += AddeBannerGeld();
                    break;
                case Monate.Efferd:
                    break;
                case Monate.Travia:
                    EinnahmenDesJahres += AddeHalbenJahresZehnt();
                    EinnahmenDesJahres += AddeEigeneDämonenGeldHalbJahr();
                    break;
                case Monate.Boron:
                    break;
                case Monate.Hesinde:
                    break;
                case Monate.Firun:
                    break;
                case Monate.Tsa:
                    break;
                case Monate.Phex:
                    break;
                case Monate.Peraine:
                    EinnahmenDesJahres += AddeHalbenJahresZehnt();
                    EinnahmenDesJahres += AddeEigeneDämonenGeldHalbJahr();
                    break;
                case Monate.Ingerimm:
                    break;
                case Monate.Rahja:
                    break;
            }

            EinnahmenDesJahres += AddeWeinGeld();
            EinnahmenDesJahres += AddeSterbeGeld();
            EinnahmenDesJahres += AddeRechtssprechungsGeld();
            EinnahmenDesJahres += AddeZollEinnahmen();

            EntnehmeLebensStyle();
            EntnehmeSöldnerSold();
            EntnehmeInstandHaltung();
            EntnehmeGardistenSold();

            SchatzKammerInDukaten = Math.Round(SchatzKammerInDukaten, 3);
        }

        private double EntnehmeGardistenSold()
        {
            double total = 0;
            foreach(Gardist garde in Gardisten)
            {
                total += garde.MonatsPreis;
                SchatzKammerInDukaten -= garde.MonatsPreis;
            }
            if(total > 0) { 
                AddEreigniss(new Ereigniss(AktuellerMonatString, "Gardisten: -" + total + "D"));
            }
            return total;
        }
        private double EntnehmeInstandHaltung()
        {
            double kosten = 0;
            switch (RegionsTyp)
            {
                case RegionTyp.Niemandsland:
                    kosten = 1;
                    break;
                case RegionTyp.Pionierland:
                    kosten = 2.5;
                    break;
                case RegionTyp.Ländlich:
                    kosten = 4;
                    break;
                case RegionTyp.Durchschnitt:
                    kosten = 5;
                    break;
                case RegionTyp.Urban:
                    kosten = 6;
                    break;
            }

            AddEreigniss(new Ereigniss(AktuellerMonatString, "Instandhaltung: -" + kosten + "D"));

            SchatzKammerInDukaten -= kosten;
            return kosten;
        }

        private double EntnehmeSöldnerSold()
        {
            double total = 0;
            foreach(SöldnerEinheit einheit in SöldnerEinheiten)
            {
                double dieseEinheitSold = 200 * einheit.SoldFaktor;
                SchatzKammerInDukaten -= dieseEinheitSold;
                total += dieseEinheitSold;
            }
            if(total > 0) { 
                AddEreigniss(new Ereigniss(AktuellerMonatString, "Söldner: -" + total + "D"));
            }
            return total;
        }

        private double AddeRechtssprechungsGeld()
        {
            double factor = 1;
            switch (RegionsTyp)
            {
                case RegionTyp.Niemandsland:
                    factor = 1;
                    break;
                case RegionTyp.Pionierland:
                    factor = 2;
                    break;
                case RegionTyp.Ländlich:
                    factor = 3;
                    break;
                case RegionTyp.Durchschnitt:
                    factor = 4;
                    break;
                case RegionTyp.Urban:
                    factor = 6;
                    break;
            }
            double rechtssprechungsGeld = factor * AnzahlEinwohner / 100.0;
            AddEreigniss(new Ereigniss(AktuellerMonatString, "rechtssprechungsGeld: +" + rechtssprechungsGeld + "D"));

            SchatzKammerInDukaten += rechtssprechungsGeld;

            return rechtssprechungsGeld;
        }

        /// <summary>
        /// MONATLICH
        /// </summary>
        private double AddeZollEinnahmen()
        {
            double factor = 1;
            switch (RegionsTyp)
            {
                case RegionTyp.Niemandsland:
                    factor = 1;
                    break;
                case RegionTyp.Pionierland:
                    factor = 2.5;
                    break;
                case RegionTyp.Ländlich:
                    factor = 5;
                    break;
                case RegionTyp.Durchschnitt:
                    factor = 6;
                    break;
                case RegionTyp.Urban:
                    factor = 6;
                    break;
            }

            double zollEinnahmen = factor * AnzahlEinwohner / 100.0;
            AddEreigniss(new Ereigniss(AktuellerMonatString, "Zolleinnahmen: +" + zollEinnahmen + "D"));

            SchatzKammerInDukaten += zollEinnahmen;


            return zollEinnahmen;
        }


        /// <summary>
        /// MONATLICH
        /// </summary>
        private double AddeSterbeGeld()
        {
            double sterbeGeld = (AnzahlEinwohner / 100.0) * 3;
            AddEreigniss(new Ereigniss(AktuellerMonatString, "Sterbegeld: +" + sterbeGeld + "D"));

            SchatzKammerInDukaten += sterbeGeld;

            return sterbeGeld;
        }

        /// <summary>
        /// Jährlich!
        /// </summary>
        private double AddeBannerGeld()
        {
            double factor = 1;
            switch (RegionsTyp)
            {
                case RegionTyp.Niemandsland:
                    factor = 0;
                    break;
                case RegionTyp.Pionierland:
                    factor = 1;
                    break;
                case RegionTyp.Ländlich:
                    factor = 2;
                    break;
                case RegionTyp.Durchschnitt:
                    factor = 4;
                    break;
                case RegionTyp.Urban:
                    factor = 8;
                    break;

            }

            double bannerGeld = (AnzahlEinwohner / 100.0) * 20 * factor;
            AddEreigniss(new Ereigniss(AktuellerMonatString, "BannerGeld: +" + bannerGeld + "D"));
            SchatzKammerInDukaten += bannerGeld;

            return bannerGeld;
        }

        private double AddeEigeneDämonenGeldHalbJahr()
        {
            double eigeneDomänenGeld = 0.5 * (AnzahlEinwohner / 100.0) * AnzahlEigenerDomänen * 5;
            AddEreigniss(new Ereigniss(AktuellerMonatString, "Eigene Domänen: +" + eigeneDomänenGeld + "D"));
            SchatzKammerInDukaten += eigeneDomänenGeld;

            return eigeneDomänenGeld;
        }

        /// <summary>
        /// Monatlich!
        /// </summary>
        private double AddeWeinGeld()
        {
            double Weingeld = (AnzahlEinwohner / 100.0) * 2;
            AddEreigniss(new Ereigniss(AktuellerMonatString, "Weingeld: +" + Weingeld + "D"));

            SchatzKammerInDukaten += Weingeld;

            return Weingeld;
        }

        private double AddeHalbenJahresZehnt()
        {
            double halbesJahresZehnt = 0.5 * JahresZehnt;
            AddEreigniss(new Ereigniss(AktuellerMonatString, "Zehnt: +" + halbesJahresZehnt + "D"));
            SchatzKammerInDukaten += halbesJahresZehnt;

            return halbesJahresZehnt;
        }

        private double JahresZehnt
        {
            get
            {
                return JahresEinkommenderEinwohner * Zehnt;
            }
        }

        private double JahresEinkommenderEinwohner
        {
            get
            {
                double billige = 0;
                double einfache = 0;
                double qualifizierte = 0;
                double hochqualifizierte = 0;

                switch (RegionsTyp)
                {
                    case RegionTyp.Durchschnitt:
                        billige = AnzahlEinwohner * 0.1;
                        einfache = AnzahlEinwohner * 0.8;
                        qualifizierte = AnzahlEinwohner * 0.08;
                        hochqualifizierte = AnzahlEinwohner * 0.02;
                        break;
                    case RegionTyp.Ländlich:
                        billige = AnzahlEinwohner * 0.2;
                        einfache = AnzahlEinwohner * 0.75;
                        qualifizierte = AnzahlEinwohner * 0.04;
                        hochqualifizierte = AnzahlEinwohner * 0.01;
                        break;
                    case RegionTyp.Niemandsland:
                        billige = AnzahlEinwohner * 0.69;
                        einfache = AnzahlEinwohner * 0.3;
                        qualifizierte = AnzahlEinwohner * 0.01;
                        break;
                    case RegionTyp.Pionierland:
                        billige = AnzahlEinwohner * 0.58;
                        einfache = AnzahlEinwohner * 0.4;
                        qualifizierte = AnzahlEinwohner * 0.02;
                        break;
                    case RegionTyp.Urban:
                        billige = AnzahlEinwohner * 0.1;
                        einfache = AnzahlEinwohner * 0.7;
                        qualifizierte = AnzahlEinwohner * 0.15;
                        hochqualifizierte = AnzahlEinwohner * 0.05;
                        break;
                    default:
                        break;
                }

                double einKommenDerEinWohner = billige * 1.5 + einfache * 8 + qualifizierte * 20 + hochqualifizierte * 90;
                einKommenDerEinWohner *= ModifikatorSumme;

                return einKommenDerEinWohner;
            }
        }

        private long ProbenModifikatorBeziehung
        {
            get
            {
                if (Beziehung == 0)
                {
                    return 7;
                }

                if (Beziehung == 1)
                {
                    return 4;
                }

                if (Beziehung == 2)
                {
                    return 2;
                }

                if (Beziehung == 3)
                {
                    return 0;
                }

                if (Beziehung == 4)
                {
                    return -2;
                }

                if (Beziehung == 5)
                {
                    return -4;
                }

                if (Beziehung == 6)
                {
                    return -7;
                }

                return 0;
            }
        }

        private long ProbenModifikatorLoyalität
        {
            get
            {
                if(Loyalitaet == 10)
                {
                    return 0;
                }

                long dif = Loyalitaet - 10;

                dif = dif * -1;

                return dif / 2;

            }
        }

        private long ProbenModifikatorMoral
        {
            get
            {
                if(Moral == 1)
                {
                    return 7;
                }

                if(Moral == 2)
                {
                    return 4;
                }

                if(Moral == 3)
                {
                    return 2;
                }

                if(Moral == 4)
                {
                    return 0;
                }

                if(Moral == 5)
                {
                    return -2;
                }

                if(Moral == 6)
                {
                    return -4;
                }

                if(Moral == 7)
                {
                    return -7;
                }

                return 0;
            }
        }

        private double ModifikatorSumme
        {
            get
            {
                double result = BodenGüte.Factor;

                foreach (Modifikator mod in BodenGüteModifikatoren)
                {
                    result += mod.Factor;
                }

                return result;
            }
        }
    }
}
