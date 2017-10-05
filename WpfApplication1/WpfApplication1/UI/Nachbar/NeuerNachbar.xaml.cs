using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication1.Layer;

namespace WpfApplication1.UI.Nachbar
{
    /// <summary>
    /// Interaktionslogik für NeuerNachbar.xaml
    /// </summary>
    public partial class NeuerNachbar : Window
    {
        public NeuerNachbar()
        {
            InitializeComponent();
        }

        public NeuerNachbar(Baronie baronie)
        {
            NeuerNachbarVM vm = new NeuerNachbarVM(baronie);
            vm.Fenster = this;
            DataContext = vm;
            InitializeComponent();
        }
    }
}
