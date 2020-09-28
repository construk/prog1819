using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Wpf_R906_RelojDigital
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate void dlgEventoAlarma();
        event dlgEventoAlarma eventAlama;
        Brush colorBordeTextBox;
        bool eventoLanzado;
        private bool menuAlarmaActivo;
        DispatcherTimer reloj = new DispatcherTimer();
        DateTime horaAlarma;

        public MainWindow()
        {
            InitializeComponent();
            eventoLanzado = false;
            colorBordeTextBox = txb_horaAlarma.BorderBrush;
            stcHora.Visibility = Visibility.Hidden;
            btn_establecer.Visibility = Visibility.Hidden;
            eventAlama += evt_eventoAlarma;
            reloj.Start();
            reloj.Tick += Reloj_Tick;
            btb_marcha.IsEnabled = false;
        }

        private async void evt_eventoAlarma()
        {
            GameThronesThemeAlarm();
            txb_estado.Text = "¡Alarma sonando!";
            await Task.Run(() => {
                Thread.Sleep(10000);
            });
            if (reloj.IsEnabled)
            {
                txb_estado.Text = "En marcha";
            }
            else
            {
                txb_estado.Text = "Parado";
            }
            eventoLanzado = false;
        }

        private void Reloj_Tick(object sender, EventArgs e)
        {
            lbl_hora.Content = DateTime.Now.ToLongTimeString();
            if (eventAlama!=null&& DateTime.Now.Hour.Equals(horaAlarma.Hour)&& DateTime.Now.Minute.Equals(horaAlarma.Minute)&& DateTime.Now.Second.Equals(horaAlarma.Second)&&!eventoLanzado)
            {
                eventoLanzado = true;
                eventAlama();
            }
        }

        private void Btb_marcha_Click(object sender, RoutedEventArgs e)
        {
            reloj.Start();
            btb_marcha.IsEnabled = false;
            btb_parar.IsEnabled = true;
            txb_estado.Text = "En marcha";
        }

        private void Btb_parar_Click(object sender, RoutedEventArgs e)
        {
            reloj.Stop();
            btb_marcha.IsEnabled = true;
            btb_parar.IsEnabled = false;
            txb_estado.Text = "Parado";
        }

        private void Btn_alarma_Click(object sender, RoutedEventArgs e)
        {
            
            if (menuAlarmaActivo)
            {
                stcHora.Visibility = Visibility.Hidden;
                btn_establecer.Visibility = Visibility.Hidden;
            }
            else
            {
                stcHora.Visibility = Visibility.Visible;
                btn_establecer.Visibility = Visibility.Visible;
            }
            menuAlarmaActivo = !menuAlarmaActivo;
        }

        private async void Btn_establecer_Click(object sender, RoutedEventArgs e)
        {
            DateTime fecha;
            DateTime.TryParse(DateTime.Now.ToShortDateString()+" "+ txb_horaAlarma.Text+":00", out fecha);
            horaAlarma = fecha;
            txb_estado.Text = "¡Alarma establecida con éxito!";
            await Task.Run(() => {
                Thread.Sleep(10000);
            });
            if (reloj.IsEnabled)
            {
                txb_estado.Text = "En marcha";
            }
            else
            {
                txb_estado.Text = "Parado";
            }
        }

        private void Btn_salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private async void GameThronesThemeAlarm()
        {
            await Task.Run(() => {
                Console.Beep(700, 1000);
                Console.Beep(450, 1000);
                Console.Beep(550, 150);
                Console.Beep(620, 150);
                Console.Beep(700, 850);
                Console.Beep(450, 850);
                Console.Beep(550, 150);
                Console.Beep(620, 150);
                Console.Beep(520, 1000);
                Thread.Sleep(200);
                Console.Beep(620, 1000);
                Console.Beep(420, 800);
                Console.Beep(520, 150);
                Console.Beep(550, 150);
                Console.Beep(620, 1000);
                Console.Beep(420, 800);
                Console.Beep(550, 150);
                Console.Beep(520, 150);
                Console.Beep(450, 800);
            });
        }

        private void Txb_horaAlarma_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime fecha;
            if (DateTime.TryParse(DateTime.Now.ToShortDateString() + " " + txb_horaAlarma.Text + ":00", out fecha))
            {
                txb_horaAlarma.BorderBrush = colorBordeTextBox;
                btn_establecer.IsEnabled = true;
            }
            else
            {
                txb_horaAlarma.BorderBrush = Brushes.Red;
                btn_establecer.IsEnabled = false;
            }
        }
    }
}
