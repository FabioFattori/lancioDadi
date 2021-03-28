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
using System.Threading;

namespace es_tps_per_appunti
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r;
        public MainWindow()
        {
            InitializeComponent();
            r = new Random();
            int sorteggiato = 0;
            Sorteggio(sorteggiato);
        }

        private async void Sorteggio(int sorteggiato)
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    sorteggiato = r.Next(1, 1001);
                    Thread.Sleep(250);
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        btn.Content = sorteggiato;
                    }));
                    
                }
            });
        }






        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ExecuteLongOpSincrono();
            ExecuteLongOpAsincrono();
            //MessageBox.Show("Operazione sincrona completata");
        }

        private void ExecuteLongOpSincrono()
        {
            for(int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
            }
        }

        private async void ExecuteLongOpAsincrono()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                }
                MessageBox.Show("Operazione asincrona completata");
            });
        }
    }
}
