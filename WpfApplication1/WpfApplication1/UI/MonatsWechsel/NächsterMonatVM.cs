using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication1.Layer;
using WpfApplication1.Logik.Maßnahmen;

namespace WpfApplication1.UI.MonatsWechsel
{
    public class NächsterMonatVM : INotifyPropertyChanged
    {
        public Baronie DieBaronie { get; set; }
        public NächsterMonat Fenster { get; set; }

        private NachbarBaronie _empfangNachbar { get; set; }
        private int _empfangIndex { get; set; }
        public int EmpfangIndex
        {
            get
            {
                return _empfangIndex;
            }
            set
            {
                _empfangIndex = value;
                if(value > 0)
                {
                    _empfangNachbar = DieBaronie.Nachbarn.ElementAt(value-1);
                    EmpfangPreis = Empfang.GetPreis(_empfangNachbar) + "D";
                }
                else
                {
                    EmpfangPreis = 0 + "D";
                    _empfangNachbar = null;
                }
                NotifyPropertyChanged(null);
            }
        }




        private NachbarBaronie _abkommenNachbar { get; set; }
        private int _abkommenIndex { get; set; }
        public int AbkommenIndex
        {
            get
            {
                return _abkommenIndex;
            }
            set
            {
                _abkommenIndex = value;
                if (value > 0)
                {
                    _abkommenNachbar = DieBaronie.Nachbarn.ElementAt(value - 1);
                    AbkommenPreis = Korrespodenz.GetPreis(_korrespodenzNachbar) + "D";
                }
                else
                {
                    AbkommenPreis = 0 + "D";
                    _abkommenNachbar = null;
                }
                NotifyPropertyChanged(null);
            }
        }






        private NachbarBaronie _korrespodenzNachbar { get; set; }
        private int _korrespodenzIndex { get; set; }
        public int KorrespondenzIndex
        {
            get
            {
                return _korrespodenzIndex;
            }
            set
            {
                _korrespodenzIndex = value;
                if (value > 0)
                {
                    _korrespodenzNachbar = DieBaronie.Nachbarn.ElementAt(value - 1);
                    KorrespodenzPreis = Korrespodenz.GetPreis(_korrespodenzNachbar) + "D";
                }
                else
                {
                    KorrespodenzPreis = 0 + "D";
                    _korrespodenzNachbar = null;
                }
                NotifyPropertyChanged(null);
            }
        }









        public List<String> Nachbarn { get; set; }

        public Boolean CanWarenschau
        {
            get
            {
                //TODO: NUR 1x IM JAHR ERLAUBT!
                return DieBaronie.Angestellte.Where(x => x.FunktionWarenschau == true).FirstOrDefault() != null;
            }
        }

        public Boolean CanAbkommen
        {
            get
            {
                //TODO: NUR 1x IM JAHR ERLAUBT!
                return DieBaronie.Angestellte.Where(x => x.FunktionAbkommen == true).FirstOrDefault() != null;
            }
        }


        public Boolean CanEmpfang
        {
            get
            {
                //TODO: NUR 1x IM JAHR ERLAUBT!
                return DieBaronie.Angestellte.Where(x => x.FunktionEmpfang == true).FirstOrDefault() != null;
            }
        }


        public Boolean CanSonderabgabe
        {
            get
            {
                //TODO: NUR 1x IM JAHR ERLAUBT!
                return DieBaronie.Angestellte.Where(x => x.FunktionKorrespondenz == true).FirstOrDefault() != null;
            }
        }

        public Boolean CanKorrespondenz
        {
            get
            {
                return DieBaronie.Angestellte.Where(x => x.FunktionKorrespondenz == true).FirstOrDefault() != null;
            }
        }

        public Boolean CanInvestition
        {
            get
            {
                return DieBaronie.Angestellte.Where(x => x.FunktionInvestitionen == true).FirstOrDefault() != null;
            }
        }

        public Boolean CanFest
        {
            get
            {
                return DieBaronie.Angestellte.Where(x => x.FunktionFeste == true).FirstOrDefault() != null;
            }
        }
        public Boolean CanArmenspeisung
        {
            get
            {
                return DieBaronie.Angestellte.Where(x => x.FunktionArmenspeisung == true).FirstOrDefault() != null;
            }
        }

        private int _selectedIndexFest = 0;
        public int SelectedIndexFest
        {
            get
            {
                return _selectedIndexFest;
            }
            set
            {
                _selectedIndexFest = value;
                long factor = Fest.FestPreisJe100Einwohner(value);

                FestPreis = factor * (DieBaronie.AnzahlEinwohner / 100) + "D";
                NotifyPropertyChanged("");
            }
        }
        private long _ArmenSpeisungVal { get; set; }
        public String ArmenSpeisungVal
        {
            get
            {
                return "" + _ArmenSpeisungVal;
            }
            set
            {
                try
                {
                    _ArmenSpeisungVal = long.Parse(value);
                    ArmenSpeisungPreis = Armenspeisung.GetPreis(_ArmenSpeisungVal) + "D";
                }
                catch (Exception e)
                {

                }
                NotifyPropertyChanged("");
            }
        }

        public long _InvestitionsVal { get; set; }
        public String InvestitionsVal
        {
            get
            {
                return _InvestitionsVal + "";
            }
            set
            {
                try
                {
                    _InvestitionsVal = long.Parse(value);
                    InvestitionsPreis = Investition.GetInvestitionspreis(long.Parse(value), DieBaronie.AnzahlEinwohner) + "D";
                }
                catch (Exception e)
                {

                }
                NotifyPropertyChanged("");
            }
        }

        
        public long _SonderabgabeVal { get; set; }
        public String SonderabgabeVal
        {
            get
            {
                return _SonderabgabeVal + "";
            }
            set
            {
                try
                {
                    _SonderabgabeVal = long.Parse(value);
                    SonderabgabePreis = Sonderabgabe.GetPreis(_SonderabgabeVal, DieBaronie.AnzahlEinwohner) + "D";
                }
                catch (Exception e)
                {

                }
                NotifyPropertyChanged("");
            }
        }

  

        public long _AbkommenVal { get; set; }
        public String AbkommenVal
        {
            get { return "" + _AbkommenVal; }
            set
            {
                try
                {
                    _AbkommenVal = long.Parse(value);
                    AbkommenPreis = Abkommen.GetPreis(_AbkommenVal) + "D";
                }
                catch (Exception e)
                {

                }
                NotifyPropertyChanged("");
            }
        }

        public Boolean _WarenschauVal { get; set; }
        public Boolean WarenschauVal
        {
            get
            {
                return _WarenschauVal;
            }
            set
            {
                _WarenschauVal = value;
                WarenschauPreis = Warenschau.GetWarenschauPreis(value, DieBaronie.AnzahlEinwohner) + "D";
                NotifyPropertyChanged("");
            }
        }

        public long _GesamtPreis { get; set; }
        public String GesamtPreis
        {
            get
            {
                return Abkommen.GetPreis(_AbkommenVal) + Armenspeisung.GetPreis(_ArmenSpeisungVal) + Empfang.GetPreis(_empfangNachbar) + Fest.FestPreis(_selectedIndexFest, DieBaronie.AnzahlEinwohner) + Investition.GetInvestitionspreis(_InvestitionsVal, DieBaronie.AnzahlEinwohner) + Korrespodenz.GetPreis(_korrespodenzNachbar) + Sonderabgabe.GetPreis(_SonderabgabeVal, DieBaronie.AnzahlEinwohner) + Warenschau.GetWarenschauPreis(_WarenschauVal, DieBaronie.AnzahlEinwohner) + "D";
            }
        }


        public String FestPreis { get; set; }
        public String ArmenSpeisungPreis { get; set; }
        public String InvestitionsPreis { get; set; }
        public String KorrespodenzPreis { get; set; }
        public String SonderabgabePreis { get; set; }
        public String EmpfangPreis { get; set; }
        public String AbkommenPreis { get; set; }
        public String WarenschauPreis { get; set; }

        public NächsterMonatVM(Baronie baronie)
        {
            List<String> nachbarListe = new List<String>();
            nachbarListe.Insert(0, "Kein");
            foreach(NachbarBaronie n in baronie.Nachbarn)
            {
                nachbarListe.Add(n.ToString());
            }
            
            
            Nachbarn = nachbarListe;
            
            DieBaronie = baronie;
            SelectedIndexFest = 0;
            ArmenSpeisungVal = "0";
            InvestitionsVal = "0";
            SonderabgabeVal = "0";
            AbkommenVal = "0";
            WarenschauVal = false;

            FestPreis = "0D";
            ArmenSpeisungPreis = "0D";
            InvestitionsPreis = "0D";
            KorrespodenzPreis = "0D";
            SonderabgabePreis = "0D";
            EmpfangPreis = "0D";
            AbkommenPreis = "0D";
            WarenschauPreis = "0D";
        }

        private ICommand _CancelCmd;
        public ICommand CancelCmd
        {
            get
            {
                return _CancelCmd ?? (_CancelCmd = new RelayCommand(p =>
              Fenster.Close()));
            }
        }


        private ICommand _OkCmd;
        public ICommand OkCmd
        {
            get
            {
                return _OkCmd ?? (_OkCmd = new RelayCommand(p => OkMethod()));
            }
        }

        private void OkMethod()
        {
            //TODO: Maßnahmen!
            DieBaronie.SetzeAufNaechsteNonat();
            Fenster.Close();
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
