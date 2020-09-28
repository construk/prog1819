using System.Windows;
using System.Windows.Media;

namespace Wpf_R901_SumaNPrimerosNumeros
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Brush colorDefecto;
        public delegate void dlgParaHilo();

        public MainWindow()
        {
            InitializeComponent();
            colorDefecto = txb_numero.Background;
        }
        public static long SumaNNumerosIterativa(long sumarHasta)
        {
            long resultado = 0;
            for (int i = 1; i <= sumarHasta; i++)
            {
                resultado += i;
            }
            return resultado;
        }

        private void Btn_Calcular(object sender, RoutedEventArgs e)
        {
            lbl_resultado.Content = "Calculando...";
            btn_calcular.IsEnabled = false;
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new dlgParaHilo(Calcular));
            btn_calcular.IsEnabled = true;
        }
        public void Calcular()
        {
            long numero;
            lbl_resultado.Content = "";
            Brush colorDefecto = txb_numero.Background;
            if (txb_numero.Text.TrimEnd(' ').Equals("") || !long.TryParse(txb_numero.Text, out numero))
            {
                txb_numero.Background = Brushes.Red;
                if (txb_numero.Text.TrimEnd(' ').Equals(""))
                {
                    lbl_resultado.Content = "Introduce algún número";
                }
                else
                {
                    lbl_resultado.Content = "Introduce un número válido";
                }
            }
            else
            {
                //lbl_resultado.Content = SumaNNumerosIterativa(numero);
                lbl_resultado.Content = ((1 + numero) / 2.0) * numero;
            }
            //txb_numero.Background = colorDefecto;
        }

        private void Txb_numero_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_numero.Background = colorDefecto;
        }

        private void Btn_cerrar_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}
