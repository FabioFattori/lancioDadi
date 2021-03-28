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
                    sorteggiato = r.Next(1,13);
                    Thread.Sleep(510);
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        dado_1.Content = sorteggiato;
                    }));
                    
                }
            });
        }


        private void btn_estrai_Click(object sender, RoutedEventArgs e)
        {
            lst_numeriEstratti.Items.Add(dado_1.Content);
        }

        private void btn_pulisciLista_Click(object sender, RoutedEventArgs e)
        {
            lst_numeriEstratti.Items.Clear();
        }





        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ExecuteLongOpSincrono();
            
            //MessageBox.Show("Operazione sincrona completata");
        }
        
        private void ExecuteLongOpSincrono()
        {
            for(int i = 0; i < 10; i++)
            {
                Thread.Sleep(1500);
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
        */


    }
}
