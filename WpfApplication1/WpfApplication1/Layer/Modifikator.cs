using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Logik.Config
{
    public class Modifikator
    {
        public string Name { get; set; }
        public double Factor { get; set; }

        public Modifikator(string name, double factor)
        {
            this.Name = name;
            this.Factor = factor;
        }

        public Modifikator()
        {

        }
    }
}
