using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.XPath;

namespace Wpf_R902_ExpresionMatematica
{
    class ExpresionMalFormadaException : Exception
    {
        public ExpresionMalFormadaException() : base() { }
        public ExpresionMalFormadaException(string mensaje) : base(mensaje) { }
    }
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static double Calcular(string numero)
        {
            //string xsltExpression = string.Format("number({0})", new Regex(@"([\+\-\*])").Replace(numero, " ${1} ").Replace("/", " div ").Replace("%", " mod "));
            try
            {
                //xsltExpression=xsltExpression.Replace(",", ".");
                numero = numero.Replace(",", ".");
                DataTable tabla = new DataTable();
                DataColumn columna = new DataColumn("Columna", typeof(double), numero);
                tabla.Columns.Add(columna);
               
                tabla.Rows.Add(tabla.NewRow());
                return (double)tabla.Rows[0]["Columna"];

                /*double resultado;
                if ((resultado=(double)new XPathDocument(new StringReader("<r/>")).CreateNavigator().Evaluate(xsltExpression)).ToString().Equals("NaN"))
                {
                    throw new XPathException();
                }
                else
                {
                    return resultado;
                }*/
            }
            catch
            {
                throw;
            }
        }
        private void Btn_Calcular_Click(object sender, RoutedEventArgs e)
        {
            txb_resultado.Dispatcher.BeginInvoke(new Action(() => { txb_resultado.Foreground = Brushes.Black; })); 
            
            btn_Calcular.Dispatcher.BeginInvoke(new Action(() => { btn_Calcular.IsEnabled = false; })); //Deshabilita botón de calcular mientras está calculando.                                                                                                           
            try
            {
                double numero = Calcular(txb_expresion.Text);
                if (numero<0.000001&&numero>0||numero>-0.000001&&numero<0||Math.Abs(numero)>1000000000)
                {
                    txb_resultado.Text =numero.ToString("#0.0############## e0");
                }
                else
                {
                    txb_resultado.Text = Calcular(txb_expresion.Text).ToString("#,##0.##############"); //Cambiar valor en la interfaz
                }
            }
            catch (InvalidExpressionException)
            {
                txb_resultado.Dispatcher.BeginInvoke(new Action(() => { txb_resultado.Foreground = Brushes.Red; }));
                txb_resultado.Text = "Error: La expresión está mal formada.";
            }/*
            catch (XPathException)
            {
                txb_resultado.Dispatcher.BeginInvoke(new Action(() => { txb_resultado.Foreground = Brushes.Red; }));
                txb_resultado.Text = "Error: La expresión está mal formada.";
            }*/
            catch (Exception)
            {
                txb_resultado.Dispatcher.BeginInvoke(new Action(() => { txb_resultado.Foreground = Brushes.Red; }));
                txb_resultado.Text = "Error: Algo inesperado ha ocurrido...";
            }finally
            {
                btn_Calcular.Dispatcher.BeginInvoke(new Action(() => { btn_Calcular.IsEnabled = true; }));//Habilita botón de calcular cuando ha terminado de calcular.
            }
        }

        private void Txb_expresion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                Btn_Calcular_Click(this, e);
            }   
        }

        private void Txb_expresion_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9,+-/*%]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
