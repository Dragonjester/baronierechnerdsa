using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Layer
{
    public class Gardist
    {
        public string Name { get; set; }
        public GardistErfahrungsGrad ErfahrungsGrad { get; set; }

        public Gardist()
        {

        }

        public Gardist(string name, GardistErfahrungsGrad erfahrungsGrad)
        {
            this.Name = name;
            this.ErfahrungsGrad = erfahrungsGrad;
        }

        public double MonatsPreis {
            get
            {
                switch (ErfahrungsGrad)
                {
                    case GardistErfahrungsGrad.Gemeiner:
                        return 4;
                    case GardistErfahrungsGrad.Korpora:
                        return 6;
                    case GardistErfahrungsGrad.Weibel:
                        return 9;
                    case GardistErfahrungsGrad.Fähnrich:
                        return 10;
                    case GardistErfahrungsGrad.Hauptmann:
                        return 15;
                    case GardistErfahrungsGrad.Oberst:
                        return 25;
                }
                return 0;
            }
        }
        public override string ToString()
        {
            return Name + " (" + ErfahrungsGrad + ")";
        }
    }

    public enum GardistErfahrungsGrad
    {
        Gemeiner, Korpora,Weibel, Fähnrich, Hauptmann, Oberst
    }
}
