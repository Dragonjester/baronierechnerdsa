using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using WpfApplication1.Layer;
using WpfApplication1.Logik;
using WpfApplication1.Logik.Config;
using WpfApplication1.UI.MonatsWechsel;
using WpfApplication1.UI.Nachbar;

namespace WpfApplication1.UI.MainWindow
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public Baronie DieBaronie { get; set; }
        public int SelectedAngestellterIndex { get; set; }
        public int SelectedSoeldnerBannerIndex { get; set; }
        public int SelectedGardistenIndex { get; set; }
        public int SelectedNachbarIndex { get; set; }

        public ObservableCollection<String> Nachbarn
        {
            get
            {
                return new ObservableCollection<String>(DieBaronie.Nachbarn.Select(x => x.ToString()));
            }
        }

        public ObservableCollection<String> Angestellte
        {
            get
            {
                return new ObservableCollection<String>(DieBaronie.Angestellte.Select(x => x.ToString()));
            }
        }
        public ObservableCollection<String> Gardisten
        {
            get
            {
                return new ObservableCollection<String>(DieBaronie.Gardisten.Select(x => x.ToString()));
            }
        }
        public ObservableCollection<String> Söldnerbanner
        {
            get
            {
                return new ObservableCollection<String>(DieBaronie.SöldnerEinheiten.Select(x => x.ToString()));
            }
        }
        public MainWindowViewModel()
        {
            SelectedAngestellterIndex = -1;
            SelectedSoeldnerBannerIndex = -1;
            SelectedGardistenIndex = -1;

            DieBaronie = new Layer.Baronie();
            DieBaronie.Name = "Entenhausen";
            DieBaronie.AnzahlEinwohner = 10000;
            DieBaronie.Zehnt = 0.1;
            DieBaronie.SchatzKammerInDukaten = 11111;
            DieBaronie.Loyalitaet = 12;
            DieBaronie.Moral = 7;
            DieBaronie.SoDesBarons = 17;

            DieBaronie.AktuellerMonat = Monate.Praios;
            DieBaronie.AktuellesJahr = 1005;

            DieBaronie.BodenGüte = new Modifikator("Durchschnittlich", 1);

            DieBaronie.BodenGüteModifikatoren.Add(new Modifikator("Kohlebergwerk", 0.1));
            DieBaronie.BodenGüteModifikatoren.Add(new Modifikator("Anschluss an Reichsstraße", 0.1));

            DieBaronie.Angestellte.Add(new Angestellter("Hauswirt", 14, 14, 14, 7));
            DieBaronie.Angestellte.Add(new Angestellter("Baumeister", 14, 14, 14, 7));
            DieBaronie.Angestellte.Add(new Angestellter("Konkubine", 14, 14, 14, 7));

            DieBaronie.Gardisten.Add(new Layer.Gardist("Alrik Alrikson", GardistErfahrungsGrad.Oberst));
            DieBaronie.Gardisten.Add(new Layer.Gardist("Max Mustermann", GardistErfahrungsGrad.Gemeiner));
            DieBaronie.Gardisten.Add(new Layer.Gardist("Jatane Nauta", GardistErfahrungsGrad.Gemeiner));
            DieBaronie.Gardisten.Add(new Layer.Gardist("Arline Bochsbansen", GardistErfahrungsGrad.Gemeiner));
            DieBaronie.Gardisten.Add(new Layer.Gardist("Kaier Hal", GardistErfahrungsGrad.Gemeiner));


            DieBaronie.SöldnerEinheiten.Add(new SöldnerEinheit("Wilde Füchse", SöldnerEinheitsErfahrungsGrad.Vollendet, true));
            DieBaronie.SöldnerEinheiten.Add(new SöldnerEinheit("Lahme Enten", SöldnerEinheitsErfahrungsGrad.Unerfahren, false));
        }

        public MainWindowViewModel(Baronie baronie)
        {
            this.DieBaronie = baronie;
        }

        private ICommand _ChangeMoneyCmd;
        public ICommand ChangeMoneyCmd
        {
            get { return _ChangeMoneyCmd ?? (_ChangeMoneyCmd = new RelayCommand(p => ChangeMoney())); }
        }

        private void ChangeMoney()
        {
            string Response = Microsoft.VisualBasic.Interaction.InputBox("Um welchen Betrag soll das Guthaben verändert werden?\r\nKein Vorzeichen = Erhöhung des Betrages\r\n- als Vorzeichen = Senkung des Betrages", "Titel", "0", 0, 0);
            if (Response != null && !Response.Equals("0") && !Response.Equals(""))
            {
                double value = Double.Parse(Response);
                DieBaronie.AddEreigniss("Manuelle Verändung des Betrages um: " + value);
                DieBaronie.SchatzKammerInDukaten += value;
                NotifyPropertyChanged("DieBaronie");
            }
        }

        private ICommand _AngestellterRemoveCmd;
        public ICommand AngestellterRemoveCmd
        {
            get { return _AngestellterRemoveCmd ?? (_AngestellterRemoveCmd = new RelayCommand(p => RemoveAusgewählterAngestellter())); }
        }

        private void RemoveAusgewählterAngestellter()
        {
            if (SelectedAngestellterIndex > -1)
            {
                DieBaronie.Angestellte.RemoveAt(SelectedAngestellterIndex);
            }

            NotifyPropertyChanged(null);
        }



        private ICommand _BuyBoteCmd;
        public ICommand BuyBoteCmd
        {
            get { return _BuyBoteCmd ?? (_BuyBoteCmd = new RelayCommand(p => BuyBote())); }
        }

        private void BuyBote()
        {
            Process.Start("http://www.ulisses-ebooks.de/product/113126/Aventurischer-Bote-158-PDF-als-Download-kaufen");
            Process.Start("http://www.ulisses-ebooks.de/product/114753/Aventurischer-Bote-159-PDF-als-Download-kaufen");
        }



        private ICommand _NachbarRemoveCmd;
        public ICommand NachbarRemoveCmd
        {
            get { return _NachbarRemoveCmd ?? (_NachbarRemoveCmd = new RelayCommand(p => RemoveAusgewählterNachbar())); }
        }
        private void RemoveAusgewählterNachbar()
        {
            if(SelectedNachbarIndex > -1)
            {
                DieBaronie.Nachbarn.RemoveAt(SelectedNachbarIndex);
            }

            NotifyPropertyChanged(null);
        }



        private ICommand _NachbaAddCmd;
        public ICommand NachbarAddCmd
        {
            get { return _NachbaAddCmd ?? (_NachbaAddCmd = new RelayCommand(p =>AddNachbar())); }
        }
        private void AddNachbar()
        {
            NeuerNachbar fenster = new NeuerNachbar(DieBaronie);
            fenster.ShowDialog();
            NotifyPropertyChanged(null);
        }



        private ICommand _GardistRemoveCmd;
        public ICommand GardistRemoveCmd
        {
            get { return _GardistRemoveCmd ?? (_GardistRemoveCmd = new RelayCommand(p => RemoveAusgewählterGardist())); }
        }

        private void RemoveAusgewählterGardist()
        {
            if (SelectedGardistenIndex > -1)
            {
                DieBaronie.Gardisten.RemoveAt(SelectedGardistenIndex);
            }
            NotifyPropertyChanged(null);
        }

        private ICommand _SöldnerRemoveCmd;
        public ICommand SöldnerRemoveCmd
        {
            get { return _SöldnerRemoveCmd ?? (_SöldnerRemoveCmd = new RelayCommand(p => RemoveAusgewählterSöldner())); }
        }

        private void RemoveAusgewählterSöldner()
        {
            if (SelectedSoeldnerBannerIndex > -1)
            {
                DieBaronie.SöldnerEinheiten.RemoveAt(SelectedSoeldnerBannerIndex);
            }
            NotifyPropertyChanged(null);
        }

        private ICommand _FunktionKorrespondenzCmd;
        public ICommand FunktionKorrespondenzCmd
        {
            get { return _FunktionKorrespondenzCmd ?? (_FunktionKorrespondenzCmd = new RelayCommand(p => FunktionKorrespondenz())); }
        }
        private void FunktionKorrespondenz()
        {
            if (SelectedAngestellterIndex > -1)
            {
                DieBaronie.Angestellte[SelectedAngestellterIndex].FunktionKorrespondenz = true;
            }
            NotifyPropertyChanged(null);
        }

        private ICommand _FunktionFesteCmd;
        public ICommand FunktionFesteCmd
        {
            get { return _FunktionFesteCmd ?? (_FunktionFesteCmd = new RelayCommand(p => FunktionFeste())); }
        }
        private void FunktionFeste()
        {
            if (SelectedAngestellterIndex > -1)
            {
                DieBaronie.Angestellte[SelectedAngestellterIndex].FunktionFeste = true;
            }
            NotifyPropertyChanged(null);
        }

        private ICommand _FunktionArmenspeisungCmd;
        public ICommand FunktionArmenspeisungCmd
        {
            get { return _FunktionArmenspeisungCmd ?? (_FunktionArmenspeisungCmd = new RelayCommand(p => FunktionArmenspeisung())); }
        }
        private void FunktionArmenspeisung()
        {
            if (SelectedAngestellterIndex > -1)
            {
                DieBaronie.Angestellte[SelectedAngestellterIndex].FunktionArmenspeisung = true;
            }
            NotifyPropertyChanged(null);
        }

        private ICommand _FunktionInvestitionenCmd;
        public ICommand FunktionInvestitionenCmd
        {
            get { return _FunktionInvestitionenCmd ?? (_FunktionInvestitionenCmd = new RelayCommand(p => FunktionInvestitionen())); }
        }

        private void FunktionInvestitionen()
        {
            if (SelectedAngestellterIndex > -1)
            {
                DieBaronie.Angestellte[SelectedAngestellterIndex].FunktionInvestitionen = true;
            }
            NotifyPropertyChanged(null);
        }

        private ICommand _FunktionSonderabgabeCmd;
        public ICommand FunktionSonderabgabeCmd
        {
            get { return _FunktionSonderabgabeCmd ?? (_FunktionSonderabgabeCmd = new RelayCommand(p => FunktionSonderabgabe())); }
        }

        private void FunktionSonderabgabe()
        {
            if (SelectedAngestellterIndex > -1)
            {
                DieBaronie.Angestellte[SelectedAngestellterIndex].FunktionSonderabgabe = true;
            }
            NotifyPropertyChanged(null);
        }

        private ICommand _FunktionEmpfangCmd;
        public ICommand FunktionEmpfangCmd
        {
            get { return _FunktionEmpfangCmd ?? (_FunktionEmpfangCmd = new RelayCommand(p => FunktionEmpfang())); }
        }

        private void FunktionEmpfang()
        {
            if (SelectedAngestellterIndex > -1)
            {
                DieBaronie.Angestellte[SelectedAngestellterIndex].FunktionEmpfang = true;
            }
            NotifyPropertyChanged(null);
        }

        private ICommand _FunktionAbkommenCmd;
        public ICommand FunktionAbkommenCmd
        {
            get { return _FunktionAbkommenCmd ?? (_FunktionAbkommenCmd = new RelayCommand(p => FunktionAbkommen())); }
        }

        private void FunktionAbkommen()
        {
            if (SelectedAngestellterIndex > -1)
            {
                DieBaronie.Angestellte[SelectedAngestellterIndex].FunktionAbkommen = true;
            }
            NotifyPropertyChanged(null);
        }

        private ICommand _FunktionWarenschauCmd;
        public ICommand FunktionWarenschauCmd
        {
            get { return _FunktionWarenschauCmd ?? (_FunktionWarenschauCmd = new RelayCommand(p => FunktionWarenschau())); }
        }

        private void FunktionWarenschau()
        {
            if (SelectedAngestellterIndex > -1)
            {
                DieBaronie.Angestellte[SelectedAngestellterIndex].FunktionWarenschau = true;
            }

            NotifyPropertyChanged(null);
        }


        private ICommand _ExitCmd;
        public ICommand ExitCmd
        {
            get { return _ExitCmd ?? (_ExitCmd = new RelayCommand(p => Exit())); }
        }

        private void Exit()
        {
            Environment.Exit(1);
        }

        private ICommand _SaveCmd;
        public ICommand SaveCmd
        {
            get { return _SaveCmd ?? (_SaveCmd = new RelayCommand(p => SaveBaronie())); }
        }

        private void SaveBaronie()
        {
            var stringwriter = new System.IO.StringWriter();

            var serializer = new XmlSerializer(typeof(Baronie));
            serializer.Serialize(stringwriter, DieBaronie);
            String xmlString = stringwriter.ToString();

            File.WriteAllText("./Baronien/" + DieBaronie.Name, xmlString);
            File.WriteAllText("./Config/letzteBaronie", DieBaronie.Name);
        }


        private ICommand _NaechsterMonatCmd;

        public ICommand NaechsterMonatCmd
        {
            get { return _NaechsterMonatCmd ?? (_NaechsterMonatCmd = new RelayCommand(p => MacheMonat())); }
        }

        private void MacheMonat()
        {

            NächsterMonatVM vm = new NächsterMonatVM(DieBaronie);
            NächsterMonat nmWindow = new NächsterMonat(vm);
            nmWindow.ShowDialog();

            NotifyPropertyChanged("DieBaronie");


        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

