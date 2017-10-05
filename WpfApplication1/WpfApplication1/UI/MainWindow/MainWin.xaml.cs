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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1.Layer;
using WpfApplication1.UI.MainWindow;

namespace WpfApplication1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWin : Window
    {

        public MainWin()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        public MainWin(Baronie baronie)
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(baronie);
        }
    }
}
