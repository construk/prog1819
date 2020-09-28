using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_R910_Calculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string numero;
        private string operacion;
        private string operador;
        bool escrito, igualado;
        public event PropertyChangedEventHandler PropertyChanged;
        double resultado,operandoIgualado;
        public string Numero
        {
            get { return numero; }
            set
            {
                numero = value;
                OnPropertyChanged();
            }
        }
        public string Operacion
        {
            get { return operacion; }
            set
            {
                operacion = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Numero = "0";
            Operacion = "";
            operador = "";
            escrito = false;
            resultado = double.NaN;
            igualado = false;
            operandoIgualado = double.NaN;
        }

        private void Btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;        //Comprobar el boton que ha mandado el evento           
            if (Numero.Equals("0") || !escrito) //Si no está escrito el campo o es 0, lo reinicia.
            {
                Numero = "";
            }
            escrito = true;                     //Está escrito el campo, por lo tanto hay número
            switch (btn.Content.ToString())     //Según el número lo introduce
            {
                case "0":
                    Numero += "0";
                    break;
                case "1":
                    Numero += "1";
                    break;
                case "2":
                    Numero += "2";
                    break;
                case "3":
                    Numero += "3";
                    break;
                case "4":
                    Numero += "4";
                    break;
                case "5":
                    Numero += "5";
                    break;
                case "6":
                    Numero += "6";
                    break;
                case "7":
                    Numero += "7";
                    break;
                case "8":
                    Numero += "8";
                    break;
                case "9":
                    Numero += "9";
                    break;
                case ".":
                    if (Numero.Equals(""))      //Si es un punto añade el cero delante.
                    {
                        Numero += "0";
                    }
                    Numero += ",";
                    break;
            }
        }
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            Numero = "0";
            Operacion = "";
            resultado = 0;
            operador = "";
            escrito = false;
            igualado = false;
        }
        private void Btn_operar_Click(object sender, RoutedEventArgs e)
        {
            igualado = false;
            Button btn = (Button)sender;
            Numero = Numero.TrimEnd('.', ' ');
            Numero = Numero.TrimStart('.', ' ');
                      
            if (!escrito)                   //Si no ha escrito ningún número
            {
                if (operador.Length > 0)    //Y ya hay un operador introducido: Lo sustituye
                {
                    Operacion = Operacion.TrimEnd(operador[0],' ');
                    operador = btn.Content.ToString();              //Operador el utilizado
                    Operacion += " "+operador;
                }
            }
            else                            //Si ha escrito algún número
            {
                
                if (resultado is double.NaN || resultado == 0)  //Si no hay resultado, el resultado es 
                {                                               //el número introducido
                    resultado = double.Parse(Numero);
                }
                else                                            //Si existe un resultado, opera
                { 
                    double nuevoNumero = double.Parse(Numero);
                    resultado = Operar(resultado, nuevoNumero, operador[0]);
                }
                operador = btn.Content.ToString();              //Operador el utilizado
                //Introducir texto en subresultado --> Operación
                Operacion += " " + Numero + " " + operador;
                //Introducir el resultado como el número
                Numero = resultado.ToString();
            }
            escrito = false;    //Para que se sustituya el resultado si se introduce un nuevo número
        }

        private void Mn_copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txb_subresultado.Text);
        }
        private void Mn_cut_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txb_subresultado.Text);
            Numero = "0";
            Operacion = "";
            resultado = 0;
            operador = "";
            escrito = false;
            igualado = false;
        }
        private void Btn_masMenos_Click(object sender, RoutedEventArgs e)
        {
            if (Numero!="0")
            {
                Numero = (-1 * double.Parse(Numero)).ToString();
            }
        }
        private void Btn_raiz_Click(object sender, RoutedEventArgs e)
        {
            string resultTmp = Math.Sqrt(double.Parse(Numero)).ToString();
            string resultTmpFormat = Math.Sqrt(double.Parse(Numero)).ToString("0.##########");
            Operacion = "Sqrt(" + Numero + ") = " + resultTmp;           
            Numero = resultTmpFormat;
            resultado = double.Parse(Numero);
        }

        private void Mn_paste_Click(object sender, RoutedEventArgs e)
        {
            string copiado= Clipboard.GetText();
            Regex regex = new Regex(@"[0-9,+-/x=]");
            if (regex.IsMatch(copiado))
            {
                Operacion = copiado;
            }
            else
            {
                Operacion = "Error al pegar";
            }
        }

        private void Mn_about_Click(object sender, RoutedEventArgs e)
        {
            win_acercaDe ventana = new win_acercaDe();
            ventana.InitializeComponent();
            ventana.ShowDialog();
        }

        private void Btn_igual_Click(object sender, RoutedEventArgs e)
        {
            Numero = Numero.TrimEnd('.', ' ');
            Numero = Numero.TrimStart('.', ' ');
           
            //Si no hay nada en resultado o resultado = 0
            if (resultado==double.NaN||resultado==0)    
            {
                resultado = double.Parse(Numero);
            }
            //Si hay algo en resultado
            else
            {
                if (!igualado)
                {
                    operandoIgualado = double.Parse(Numero);
                    resultado = Operar(resultado, double.Parse(Numero), operador[0]);
                    Operacion += " " + Numero + " = "+resultado+" ";
                    Numero = resultado.ToString();
                    
                    //operador = "=";
                }
                else
                {
                    if (operacion.Length>0)
                    {
                        resultado = Operar(resultado, operandoIgualado, operador[0]);
                        Operacion += operador + " " + operandoIgualado + " = " + resultado + " ";
                        Numero = resultado.ToString();
                    }
                }
            }
            escrito = false;
            igualado = true;
        }
        private static double Operar(double numero1, double numero2, char operador)
        {
            try { 
            switch (operador)
            {
                case '+':
                    return numero1 + numero2;
                case '-':
                    return numero1 - numero2;
                case 'x':
                    return numero1 * numero2;
                case '/':
                    return numero1 / numero2;
            }
            return double.NaN;
            }
            catch
            {
                return double.NaN;
            }
        }
    }
}
