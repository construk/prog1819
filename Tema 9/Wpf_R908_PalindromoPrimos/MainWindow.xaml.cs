using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf_R908_PalindromoPrimos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        #region Métodos
        public static bool EsPalindromo(string texto)
        {
            while (texto.Contains(' '))
            {
                int posicion = texto.IndexOf(' ');
                if (posicion != -1)
                {
                    texto = texto.Remove(posicion, 1);
                }
            }
            string auxiliar = texto.ToUpper();
            StringBuilder texto2 = new StringBuilder();
            for (int i = auxiliar.Length - 1; i >= 0; i--)
            {
                texto2.Append(auxiliar[i]);
            }
            if (texto2.ToString().Equals(auxiliar))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool EsPrimo(int numero) //Función que recibe un número de tipo int que devuelve true si es primo y false si no lo es
        {
            int divisor = 2;      //Desde donde comenzamos a comprobar divisibles
            if (numero < 0)
            {
                throw new ArgumentException("El número introducido no puede ser negativo.");
            }
            if (numero < 2)       //Controlamos el caso del número 0 y 1, que no son primos
            {
                return false;
            }
            else if (numero < 4) //Controlamos el caso del número 2 y 3, que son primos
            {
                return true;
            }
            else                //Controlamos el resto de casos (hasta el máximo aceptado por un uint)
            {
                checked
                {
                    while (numero % divisor != 0 && divisor <= numero / 2)   //Mientras el número no sea divisible y el divisor sea menor a la mitad del número comprobado, incrementa divisor
                    {                                                   //Cuando termine de comprobar las condiciones se evaluará el último valor contemplado como divisor
                        divisor++;
                    }
                }
                return numero % divisor == 0 ? false : true;        //y si el numero entre el divisor es 0 será falso y si no será verdadero
            }
        }
        public async static Task<int[]> Primos(int numero)    //FUNCIÓN QUE TE DEVUELVE UN ARRAY INT RELLENO DE TANTOS PRIMOS COMO INDIQUES
        {
            int[] tmp = new int[numero];
            int[] resultado = new int[numero];

            await Task.Run(() =>
            {
                int pruebaSiPrimo = 2;                 //VA PROBANDO LOS NÚMEROS SI SON PRIMOS O NO, EMPIEZA DESDE EL 2
                int contadorPrimos = 0;                   //CUENTA LOS PRIMOS INTRODUCIDOS
                if (numero < 0)
                {
                    throw new ArgumentException("No puedes obtener n números primos negativos.");
                }
                while (pruebaSiPrimo <= numero)         //MIENTRAS EL CONTADOR DE PRIMOS SEA MENOR O IGUAL AL NÚMERO DE PRIMOS REQUERIDOS
                {
                    if (EsPrimo(pruebaSiPrimo))                             //SI ES PRIMO EL NÚMERO PROBADO
                    {
                        tmp[contadorPrimos] = pruebaSiPrimo;          //GUARDA EL NÚMERO
                        contadorPrimos++;                                   //AUMENTA EL CONTADOR DE LOS PRIMOS GUARDADOS 
                    }
                    pruebaSiPrimo++;                                        //PRUEBA OTRO NÚMERO
                }
                resultado = new int[contadorPrimos];
                Array.Copy(tmp, resultado, contadorPrimos);
            });
            return resultado;
        }
        #endregion
        #region Eventos
        private void evt_seleccionarPalindromo(object sender, RoutedEventArgs e)
        {
            ComboBoxItem elemento = (ComboBoxItem)sender;
            if (!(txb_textoPalindromo is null))
            {
                if (elemento.Content.ToString().Equals("--"))
                {
                    txb_textoPalindromo.Text = "";
                }
                else
                {
                    txb_textoPalindromo.Text = elemento.Content.ToString();
                }
            }
        }

        private void Btn_comprobarPalindroma_Click(object sender, RoutedEventArgs e)
        {
            if (!txb_textoPalindromo.Text.Equals(""))
            {
                if (EsPalindromo(txb_textoPalindromo.Text))
                {
                    txbl_resultPalindroma.Text = "El texto introducido es palíndromo.";
                }
                else
                {
                    txbl_resultPalindroma.Text = "El texto introducido NO es palíndromo.";
                }
            }
            else
            {
                txbl_resultPalindroma.Text = "Introduzca algún texto...";
            }
        }

        private async void Btn_Calcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numeroACalcularDePrimos = int.Parse(txb_numerosPrimos.Text);
                //Operación pesada opción de salir.
                if (numeroACalcularDePrimos>9999)
                {
                    string mensajeTitulo = "Atención: Operación pesada";
                    string mensajeOpciones = "El número a calcular es muy grande, tenga en cuenta que esto puede provocar que la aplicación no responda.¿Deseas continuar?";
                    MessageBoxResult opcionElegida = MessageBox.Show(mensajeOpciones, mensajeTitulo, MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (opcionElegida!=MessageBoxResult.Yes)
                    {
                        return;
                    }
                }

                //Operar
                ltv_listaPrimos.Items.Clear();
                int[] primos = await Primos(numeroACalcularDePrimos);
                for (int i = 0; i < primos.Length; i++)
                {
                    ListViewItem elemento = new ListViewItem();
                    elemento.Content = primos[i].ToString();
                    ltv_listaPrimos.Items.Add(elemento);
                }
            }
            catch (Exception)
            {
                ListViewItem elemento = new ListViewItem();
                elemento.Foreground = Brushes.Red;
                elemento.Content = "Solo puedes introducir números positivos";
                ltv_listaPrimos.Items.Add(elemento);
            }
        }
        #endregion
    }
}
