using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_R918_SimuladorJarra
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Jarra jarraA;
        Jarra jarraB;
        public MainWindow()
        {
            InitializeComponent();
            jarraA = new Jarra();
            jarraB = new Jarra();
            txbInfoJarraA.DataContext = jarraA;
            txbInfoJarraB.DataContext = jarraB;
            prbJarraA.DataContext = jarraA;
            prbJarraB.DataContext = jarraB;
            EstadoBotonesIniciales();
        }
        private void ComenzarPartida()
        {
            btnCrearJarras.IsEnabled = false;
            txtCapJarraA.IsEnabled = false;
            txtCapJarraB.IsEnabled = false;

            btnLlenarDesdeJarraA.IsEnabled = true;
            btnLlenarDesdeJarraB.IsEnabled = true;
            btnFinalizar.IsEnabled = true;

            btnLlenarJarraA.IsEnabled = true;
            btnVaciarJarraA.IsEnabled = true;
            btnLlenarJarraB.IsEnabled = true;
            btnVaciarJarraB.IsEnabled = true;

            txbInfo.Text = "Las jarras se han inicializado";
            RellenarAcciones(string.Format("¡Partida comenzada! Jarra A: {0} Jarra B: {1}", jarraA.ToString(), jarraB.ToString()));
        }
        private void EstadoBotonesIniciales()
        {
            btnCrearJarras.IsEnabled = false;
            txtCapJarraA.IsEnabled = true;
            txtCapJarraB.IsEnabled = true;

            btnLlenarDesdeJarraA.IsEnabled = false;
            btnLlenarDesdeJarraB.IsEnabled = false;
            btnFinalizar.IsEnabled = false;

            btnLlenarJarraA.IsEnabled = false;
            btnVaciarJarraA.IsEnabled = false;
            btnLlenarJarraB.IsEnabled = false;
            btnVaciarJarraB.IsEnabled = false;
        }
        private void TerminarPartida()
        {
            btnCrearJarras.IsEnabled = true;
            txtCapJarraA.IsEnabled = true;
            txtCapJarraB.IsEnabled = true;

            btnLlenarDesdeJarraA.IsEnabled = false;
            btnLlenarDesdeJarraB.IsEnabled = false;
            btnFinalizar.IsEnabled = false;

            btnLlenarJarraA.IsEnabled = false;
            btnVaciarJarraA.IsEnabled = false;
            btnLlenarJarraB.IsEnabled = false;
            btnVaciarJarraB.IsEnabled = false;

            txbInfo.Text = "La partida ha sido finalizada";
            RellenarAcciones("¡Partida finalizada!");
        }
        private void BtnCrearJarras_Click(object sender, RoutedEventArgs e)
        {
            jarraA.Capacidad = int.Parse(txtCapJarraA.Text);
            jarraB.Capacidad = int.Parse(txtCapJarraB.Text);
            ComenzarPartida();
        }
        private void BtnLlenarJarraA_Click(object sender, RoutedEventArgs e)
        {
            jarraA.Llenar();
            RellenarAcciones("¡Jarra A rellenada completamente!");
        }
        private void BtnLlenarJarraB_Click(object sender, RoutedEventArgs e)
        {
            jarraB.Llenar();
            RellenarAcciones("¡Jarra B rellenada completamente!");
        }
        private void BtnVaciarJarraA_Click(object sender, RoutedEventArgs e)
        {
            jarraA.Vaciar();
            RellenarAcciones("¡Jarra A vaciada completamente!");
        }
        private void BtnVaciarJarraB_Click(object sender, RoutedEventArgs e)
        {
            jarraB.Vaciar();
            RellenarAcciones("¡Jarra B vaciada completamente!");
        }
        private void BtnLlenarDesdeJarraA_Click(object sender, RoutedEventArgs e)
        {
            jarraB.LlenarDesdeJarra(jarraA);
            RellenarAcciones("Se vuelca la jarra A sobre la jarra B");
        }
        private void BtnLlenarDesdeJarraB_Click(object sender, RoutedEventArgs e)
        {
            jarraA.LlenarDesdeJarra(jarraB);
            RellenarAcciones("Se vuelca la jarra B sobre la jarra A");
        }
        private void TxtCapJarra_TextChanged(object sender, TextChangedEventArgs e)
        {
            int aux;
            if (int.TryParse(txtCapJarraA.Text, out aux) && aux > 0 && int.TryParse(txtCapJarraB.Text, out aux) && aux > 0)
            {
                btnCrearJarras.IsEnabled = true;
            }
            else
            {
                btnCrearJarras.IsEnabled = false;
            }
        }
        private void BtnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            jarraA.Cantidad = 0;
            jarraA.Capacidad = 0;
            jarraB.Cantidad = 0;
            jarraB.Capacidad = 0;
            TerminarPartida();
        }
        private void RellenarAcciones(string texto)
        {
            TextBlock textoAnadido = new TextBlock
            {
                Text = texto
            };
            stcAcciones.Children.Add(textoAnadido);
        }
        private async void BtnDemo_Click(object sender, RoutedEventArgs e)
        {
            jarraA.Capacidad = 7;
            jarraB.Capacidad = 5;
            ComenzarPartida();
            await Task.Run(() => { Thread.Sleep(1000); });
            BtnLlenarJarraB_Click(this, null);
            await Task.Run(() => { Thread.Sleep(1000); });
            BtnLlenarDesdeJarraB_Click(this, null);
            await Task.Run(() => { Thread.Sleep(1000); });
            BtnLlenarJarraB_Click(this, null);
            await Task.Run(() => { Thread.Sleep(1000); });
            BtnLlenarDesdeJarraB_Click(this, null);
            await Task.Run(() => { Thread.Sleep(1000); });
            BtnVaciarJarraA_Click(this, null);
            await Task.Run(() => { Thread.Sleep(1000); });
            BtnLlenarDesdeJarraB_Click(this, null);
            await Task.Run(() => { Thread.Sleep(1000); });
            BtnLlenarJarraB_Click(this, null);
            await Task.Run(() => { Thread.Sleep(1000); });
            BtnLlenarDesdeJarraB_Click(this, null);
        }
    }
}
