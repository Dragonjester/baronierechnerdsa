using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using WpfApplication1.Layer;

namespace WpfApplication1.UI.StartScreen
{
    /// <summary>
    /// Interaktionslogik für StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += DoWait;
            worker.RunWorkerCompleted += gotoMainWindow;
            worker.RunWorkerAsync();

        }

        public void DoWait(object sender, System.ComponentModel.DoWorkEventArgs e)
        {


            loadBaronie();


            Thread.Sleep(3000);
        }

        Baronie baronie = null;
        private void loadBaronie()
        {
            System.IO.Directory.CreateDirectory("./Baronien");
            System.IO.Directory.CreateDirectory("./Config");
            String letzteBaronieFile = "./Config/letzteBaronie";

            Boolean lastOpenedExists = File.Exists(letzteBaronieFile);

            if (lastOpenedExists)
            {
                try
                {
                    String baronieName = File.ReadAllText(letzteBaronieFile);
                    if (baronieName != null && !baronieName.Equals(""))
                    {
                        String baronieXml = File.ReadAllText("./Baronien/" + baronieName);
                        var stringReader = new System.IO.StringReader(baronieXml);
                        var serializer = new XmlSerializer(typeof(Baronie));
                        baronie = serializer.Deserialize(stringReader) as Baronie;
                    }
                }
                catch (Exception e)
                {

                }
            }

            if (baronie != null)
            {
                foreach(Ereigniss e in baronie.Ereignisse)
                {
                    if(e.Beschreibung == null || e.Beschreibung.Equals(""))
                    {
                        baronie.Ereignisse.Remove(e);
                    }
                }
            }
        }

        public void gotoMainWindow(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MainWin programm;
            if (baronie != null)
            {
                programm = new MainWin(baronie);
                
            }
            else
            {
                programm = new MainWin();
            }
            programm.Show();
            Close();
        }
    }
}
