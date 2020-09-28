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

namespace Wpf_R912_MezclaColor
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ColorBinding color;
        Color resultado;
        public MainWindow()
        {
            InitializeComponent();
            color = new ColorBinding();
            resultado = new Color
            {
                A = 255
            };
        }

        private void Sl_rojo_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte valor= (byte)e.NewValue;
            lbl_rojo.Content = valor.ToString().PadLeft(3);
            color.Rojo = valor;
            resultado.R = valor;
            Rec_Relleno.Fill = new SolidColorBrush(resultado);
        }

        private void Sl_verde_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte valor = (byte)e.NewValue;
            lbl_verde.Content = valor.ToString().PadLeft(3);
            color.Verde = valor;
            resultado.G = valor;
            Rec_Relleno.Fill = new SolidColorBrush(resultado);
        }

        private void Sl_azul_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte valor = (byte)e.NewValue;
            lbl_azul.Content = valor.ToString().PadLeft(3);
            color.Azul = valor;
            resultado.B = valor;
            Rec_Relleno.Fill = new SolidColorBrush(resultado);
        }
    }
}
