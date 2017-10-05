using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Layer
{
    public class Angestellter  : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }




        public Angestellter()
        {

        }
        public string Name { get; set; }
        public int E1 { get; set; }
        public int E2 { get; set; }
        public int E3 { get; set; }
        public int TaW { get; set; }

        public Angestellter(String name, int e1, int e2, int e3, int taw)
        {
            this.Name = name;
            this.E1 = e1;
            this.E2 = e2;
            this.E3 = e3;
            this.TaW = taw;
        }


        private Boolean _FunktionFeste { get; set; }
        public Boolean FunktionFeste
        {
            get
            {
                return _FunktionFeste;
            }
            set
            {
                if (value)
                {
                    _FunktionFeste = false;
                    _FunktionArmenspeisung = false;
                    _FunktionInvestitionen = false;
                    _FunktionKorrespondenz = false;
                    _FunktionSonderabgabe = false;
                    _FunktionEmpfang = false;
                    _FunktionAbkommen = false;
                    _FunktionWarenschau = false;
                }
                _FunktionFeste = value;
            }
        }

        private Boolean _FunktionArmenspeisung { get; set; }
        public Boolean FunktionArmenspeisung
        {
            get
            {
                return _FunktionArmenspeisung;
            }
            set
            {
                if (value)
                {
                    _FunktionFeste = false;
                    _FunktionArmenspeisung = false;
                    _FunktionInvestitionen = false;
                    _FunktionKorrespondenz = false;
                    _FunktionSonderabgabe = false;
                    _FunktionEmpfang = false;
                    _FunktionAbkommen = false;
                    _FunktionWarenschau = false;
                }
                _FunktionArmenspeisung = value;
            }
        }

        private Boolean _FunktionInvestitionen { get; set; }
        public Boolean FunktionInvestitionen
        {
            get
            {
                return _FunktionInvestitionen;
            }
            set
            {
                if (value)
                {
                    _FunktionFeste = false;
                    _FunktionArmenspeisung = false;
                    _FunktionInvestitionen = false;
                    _FunktionKorrespondenz = false;
                    _FunktionSonderabgabe = false;
                    _FunktionEmpfang = false;
                    _FunktionAbkommen = false;
                    _FunktionWarenschau = false;
                }
                _FunktionInvestitionen = value;
            }
        }

        private Boolean _FunktionKorrespondenz { get; set; }
        public Boolean FunktionKorrespondenz
        {
            get
            {
                return _FunktionKorrespondenz;
            }
            set
            {
                if (value)
                {
                    _FunktionFeste = false;
                    _FunktionArmenspeisung = false;
                    _FunktionInvestitionen = false;
                    _FunktionKorrespondenz = false;
                    _FunktionSonderabgabe = false;
                    _FunktionEmpfang = false;
                    _FunktionAbkommen = false;
                    _FunktionWarenschau = false;
                }
                _FunktionKorrespondenz = value;
            }
        }

        private Boolean _FunktionSonderabgabe { get; set; }
        public Boolean FunktionSonderabgabe
        {
            get
            {
                return _FunktionSonderabgabe;
            }
            set
            {
                if (value)
                {
                    _FunktionFeste = false;
                    _FunktionArmenspeisung = false;
                    _FunktionInvestitionen = false;
                    _FunktionKorrespondenz = false;
                    _FunktionSonderabgabe = false;
                    _FunktionEmpfang = false;
                    _FunktionAbkommen = false;
                    _FunktionWarenschau = false;
                }
                _FunktionSonderabgabe = value;
            }
        }

        private Boolean _FunktionEmpfang { get; set; }
        public Boolean FunktionEmpfang
        {
            get
            {
                return _FunktionEmpfang;
            }
            set
            {
                if (value)
                {
                    _FunktionFeste = false;
                    _FunktionArmenspeisung = false;
                    _FunktionInvestitionen = false;
                    _FunktionKorrespondenz = false;
                    _FunktionSonderabgabe = false;
                    _FunktionEmpfang = false;
                    _FunktionAbkommen = false;
                    _FunktionWarenschau = false;
                }
                _FunktionEmpfang = value;
            }
        }


        private Boolean _FunktionAbkommen { get; set; }
        public Boolean FunktionAbkommen
        {
            get
            {
                return _FunktionAbkommen;
            }
            set
            {
                if (value)
                {
                    _FunktionFeste = false;
                    _FunktionArmenspeisung = false;
                    _FunktionInvestitionen = false;
                    _FunktionKorrespondenz = false;
                    _FunktionSonderabgabe = false;
                    _FunktionEmpfang = false;
                    _FunktionAbkommen = false;
                    _FunktionWarenschau = false;
                }
                _FunktionAbkommen = value;
            }
        }

        private Boolean _FunktionWarenschau { get; set; }
        public Boolean FunktionWarenschau
        {
            get
            {
                return _FunktionWarenschau;
            }
            set
            {
                if (value)
                {
                    _FunktionFeste = false;
                    _FunktionArmenspeisung = false;
                    _FunktionInvestitionen = false;
                    _FunktionKorrespondenz = false;
                    _FunktionSonderabgabe = false;
                    _FunktionEmpfang = false;
                    _FunktionAbkommen = false;
                    _FunktionWarenschau = false;
                }
                _FunktionWarenschau = value;
                NotifyPropertyChanged();
            }
        }


        public override string ToString()
        {
            String val = Name + " (" + E1 + "/" + E2 + "/" + E3 + ") TaW: " + TaW + " ";
            if(_FunktionFeste)
            {
                val += "(Feste)";
            }
            if (_FunktionArmenspeisung)
            {
                val += "(Armenspeisung)";
            }
            if (_FunktionInvestitionen)
            {
                val += "(Investitionen)";
            }
            if (_FunktionKorrespondenz)
            {
                val += "(Korrespondenz)";
            }
            if (_FunktionSonderabgabe)
            {
                val += "(Sonderabgabe)";
            }
            if (_FunktionEmpfang)
            {
                val += "(Empfang)";
            }
            if (_FunktionAbkommen)
            {
                val += "(Abkommen)";
            }
            if (_FunktionWarenschau)
            {
                val += "(Warenschau)";
            }
            return val;
        }
    }
}
