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

namespace Wpf_R904_SumaNumerosIntervalo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Brush color;
        static int n1, n2;
        public MainWindow()
        {
            InitializeComponent();
            color = txbx_N1.BorderBrush;
        }

        private void Txbx_N1_TextChanged(object sender, TextChangedEventArgs e)
        {
            int numero;
            int numero2;

            if (!int.TryParse(txbx_N1.Text, out numero))
            {
                txbx_N1.BorderBrush = Brushes.Red;
                txbl_Info.Text = "Introduce en N1 un número válido.";
            }
            else if (int.TryParse(txbx_N2.Text, out numero2) && numero2 < numero)
            {
                txbx_N1.BorderBrush = Brushes.Red;
                txbl_Info.Text = "N1 debe de ser menor que N2.";
            }
            else
            {
                txbx_N1.BorderBrush = color;
                txbl_Info.Text = "";
            }
            if (int.TryParse(txbx_N1.Text, out n1) && int.TryParse(txbx_N2.Text, out n2) && n1 <= n2)
            {
                btn_Sumar.IsEnabled = true;
            }
            else
            {
                btn_Sumar.IsEnabled = false;
            }
        }

        private void Txbx_N2_TextChanged(object sender, TextChangedEventArgs e)
        {
            int numero;
            int numero2;

            if (!int.TryParse(txbx_N2.Text, out numero))
            {
                txbx_N2.BorderBrush = Brushes.Red;
                txbl_Info.Text = "Introduce en N2 un número válido.";
            }
            else if (int.TryParse(txbx_N1.Text, out numero2) && numero2 > numero)
            {
                txbx_N2.BorderBrush = Brushes.Red;
                txbl_Info.Text = "N1 debe de ser menor que N2.";
            }
            else
            {
                txbx_N2.BorderBrush = color;
                txbl_Info.Text = "";
            }

            if (int.TryParse(txbx_N1.Text, out n1) && int.TryParse(txbx_N2.Text, out n2) && n1 <= n2)
            {
                btn_Sumar.IsEnabled = true;
            }
            else
            {
                btn_Sumar.IsEnabled = false;
            }
        }

        private async void Btn_Sumar_Click(object sender, RoutedEventArgs e)
        {
            int n1, n2;
            long resultado=-1;
            if (int.TryParse(txbx_N1.Text,out n1)&& int.TryParse(txbx_N2.Text, out n2))
            {
                btn_Sumar.IsEnabled = false;
                resultado = await SumaRango(n1,n2);
                btn_Sumar.IsEnabled = true;
            }
            txbl_Info.Text = "Resultado: " + resultado.ToString("#.###");
        }
        private async Task<long> SumaRango(int n1,int n2)
        {
            long resultado = 0;
            await Task.Run(() =>
            {
                //Dispatcher.InvokeAsync(new Action(() => {

                for (int i = n1; i <= n2; i++)
                {
                    resultado += i;
                }
            });
            return resultado;
        }
    }
}

