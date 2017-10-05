using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication1.Layer;

namespace WpfApplication1.UI.Nachbar
{
    class NeuerNachbarVM : INotifyPropertyChanged
    {
        public NachbarBaronie Nachbar { get; set; }
        private Baronie DieBaronie { get; set; }
        public NeuerNachbar Fenster { get; set; }



        public int SelectedIndexBeziehung { get
            {
                return Nachbar.SelectedIndexBeziehung;
            } set
            {
                Nachbar.SelectedIndexBeziehung = value;
                NotifyPropertyChanged(null);
            }
        }
   

        public String NameDerBaronie { get { return Nachbar.NameDerBaronie; } set
            {
                Nachbar.NameDerBaronie = value;
                NotifyPropertyChanged(null);
            }
        }


        public Boolean IsOkayAllowed
        {
            get
            {
                if (Nachbar == null)
                {
                    return false;
                }

                if (Nachbar.SOStatus <= 0 || Nachbar.SOStatus >= 22)
                {
                    return false;
                }

                if (Nachbar.SelectedIndexBeziehung == -1)
                {
                    return false;
                }

                if(Nachbar.NameDerBaronie == null || Nachbar.NameDerBaronie.Equals(""))
                {
                    return false;
                }

                return true;
            }
        }


        public String SoDerBaronie
        {
            get
            {
                return Nachbar.SOStatus + "";
            }
            set
            {
                try { Nachbar.SOStatus = int.Parse(value); } catch (Exception e) { }
                NotifyPropertyChanged(null);
            }
        }

        public NeuerNachbarVM(Baronie dieBaronie)
        {
            this.DieBaronie = dieBaronie;
            Nachbar = new NachbarBaronie();
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

            DieBaronie.Nachbarn.Add(Nachbar);
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
