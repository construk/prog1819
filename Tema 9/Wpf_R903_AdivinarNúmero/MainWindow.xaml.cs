using System;
using System.Windows;
using System.Windows.Input;

namespace Wpf_R903_AdivinarNúmero
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd;
        static int nIntentos = 0;
        static int? numeroGenerado;
        public MainWindow()
        {
            InitializeComponent();
            txbl_NumeroGuardado.Visibility = Visibility.Hidden;
            rnd = new Random();
            btn_generar.Focus();
        }

        private void Btn_generar_Click(object sender, RoutedEventArgs e)
        {
            btn_Probar.IsEnabled = true;
            numeroGenerado = rnd.Next(100);
            txbl_NumeroGuardado.Text = numeroGenerado.ToString();
            btn_generar.IsEnabled = false;
            txbx_Numero.Focus();
        }

        private void Chbx_Mostrar_Checked(object sender, RoutedEventArgs e)
        {
            txbl_NumeroGuardado.Visibility = Visibility.Visible;
        }

        private void Chbx_Mostrar_Unchecked(object sender, RoutedEventArgs e)
        {
            txbl_NumeroGuardado.Visibility = Visibility.Hidden;
        }

        private void Btn_Probar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbl_NumeroGuardado.Visibility==Visibility.Visible)
                {
                    txbl_NumeroGuardado.Visibility = Visibility.Hidden;
                }

                if (!(numeroGenerado is null))
                {
                    Dispatcher.BeginInvoke(new Action(() => { chbx_Mostrar.IsChecked = false; }));
                    Dispatcher.BeginInvoke(new Action(() => { txbl_NumeroGuardado.Visibility = Visibility.Hidden; }));
                    nIntentos++;
                    if (numeroGenerado == int.Parse(txbx_Numero.Text))
                    {
                        txb_Info.Text = "";
                        MessageBox.Show(string.Format("Acertaste en {0} intentos", nIntentos));
                        numeroGenerado = null;
                        txbl_NumeroGuardado.Text = "";
                        nIntentos = 0;
                        txbx_Numero.Text = "";
                        btn_Probar.IsEnabled = false;
                        btn_generar.IsEnabled = true;
                    }
                    else
                    {
                        txbx_Numero.Focus();
                        txbx_Numero.SelectAll();
                        if (numeroGenerado>int.Parse(txbx_Numero.Text))
                        {
                            txb_Info.Text= string.Format("NO, el número buscado es MAYOR. Llevas {0} intentos.",nIntentos);
                        }
                        else
                        {
                            txb_Info.Text = string.Format("NO, el número buscado es MENOR. Llevas {0} intentos.", nIntentos);
                        }
                    }
                }
                else
                {
                    txb_Info.Text = "No hay introducido/generado ningún número para acertar.";
                }
            }
            catch (Exception)
            {
                txb_Info.Text = "ERROR: El número introducido no es válido.";
            }
        }

        private void Txbx_Numero_KeyUp(object sender, KeyEventArgs e)
        {
            int numero;
            bool condicionNumero = int.TryParse(txbx_Numero.Text, out numero);
            bool condicionSube = (e.Key == Key.Right || e.Key == Key.Up) && numero < 100;
            bool condicionBaja = (e.Key == Key.Left || e.Key == Key.Down) && numero > 0;

            if (e.Key == Key.Enter)
            {
                if (btn_Probar.IsEnabled&&!txbx_Numero.Text.Equals(""))
                {
                    Btn_Probar_Click(this, null);
                }
                else
                {
                    btn_generar.Focus();
                }
            }
            else if (condicionNumero && condicionSube)
            {
                txbx_Numero.Text = (numero + 1).ToString();
            }
            else if (condicionNumero && condicionBaja)
            {
                txbx_Numero.Text = (numero - 1).ToString();
            }
        }
    }
}
