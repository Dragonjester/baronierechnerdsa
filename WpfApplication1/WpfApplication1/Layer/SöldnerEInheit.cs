using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Layer
{
    public class SöldnerEinheit
    {

        public SöldnerEinheit()
        {

        }
        public override string ToString()
        {
            return Name + " (" + ErfahrungsGrad + "), Beritten: " + Beritten;
        }

        public String Name { get; set; }
        public SöldnerEinheitsErfahrungsGrad ErfahrungsGrad { get; set; }
        public Boolean Beritten { get; set; }

        public SöldnerEinheit(String name, SöldnerEinheitsErfahrungsGrad erfahrung, Boolean beritten)
        {
            this.Name = name;
            this.ErfahrungsGrad = erfahrung;
            this.Beritten = beritten;
        }


        public double SoldFaktor
        {
            
            get
            {
                double soldFaktor = 1;
                if (Beritten)
                {
                    soldFaktor = 1.5;
                }
                switch (ErfahrungsGrad)
                {
                    case SöldnerEinheitsErfahrungsGrad.Unerfahren:
                        return soldFaktor;
                    case SöldnerEinheitsErfahrungsGrad.Erfahren:
                        return soldFaktor * 2;
                    case SöldnerEinheitsErfahrungsGrad.Durchschnittlich:
                        return soldFaktor * 3;
                    case SöldnerEinheitsErfahrungsGrad.Kompetent:
                        return soldFaktor * 4;
                    case SöldnerEinheitsErfahrungsGrad.Meisterlich:
                        return soldFaktor * 5;
                    case SöldnerEinheitsErfahrungsGrad.Brilliant:
                        return soldFaktor * 6;
                    case SöldnerEinheitsErfahrungsGrad.Vollendet:
                        return soldFaktor * 7;
                }


                return soldFaktor;
            }
        }
    }

    public enum SöldnerEinheitsErfahrungsGrad
    {
        Unerfahren, Erfahren, Durchschnittlich, Kompetent, Meisterlich, Brilliant, Vollendet
    }
}
