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

namespace Wpf_R907_MultiplicaArrays
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i, j, k, x, y, z;   //Posiciones matriz 1 y 2. Matriz 1: (i,j,k)  Matriz 2: (x,y,z)
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Stack_matrices_KeyUp(object sender, KeyEventArgs e)
        {
            btn_Calcular.IsEnabled = int.TryParse(txb_m11.Text, out i) && int.TryParse(txb_m12.Text, out j) && 
                int.TryParse(txb_m13.Text, out k) && int.TryParse(txb_m21.Text, out x) && 
                int.TryParse(txb_m22.Text, out y) && int.TryParse(txb_m23.Text, out z);

            if (e.Key==Key.Enter&& btn_Calcular.IsEnabled)
            {
                Btn_Calcular_Click(this, null);
            }
        }

        private void Btn_Calcular_Click(object sender, RoutedEventArgs e)
        {
            txbm311.Text = (i * x).ToString();
            txbm312.Text = (i * y).ToString();
            txbm313.Text = (i * z).ToString();
            txbm321.Text = (j * x).ToString();
            txbm322.Text = (j * y).ToString();
            txbm323.Text = (j * z).ToString();
            txbm331.Text = (k * x).ToString();
            txbm332.Text = (k * y).ToString();
            txbm333.Text = (k * z).ToString();
        }
    }
}
