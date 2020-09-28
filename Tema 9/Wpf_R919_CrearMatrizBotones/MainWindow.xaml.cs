using System.Windows;
using System.Windows.Controls;

namespace Wpf_R919_CrearMatrizBotones
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CBotones botones;

        public MainWindow()
        {
            botones = new CBotones();

            InitializeComponent();
            stcPanel.Children.Add(botones.Botones);
            btnCrear.DataContext = botones;
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            //botones.Alto = int.Parse(((ComboBoxItem)(cmbFilas.SelectedValue)).Content.ToString());
            //botones.Ancho = int.Parse(((ComboBoxItem)(cmbColumnas.SelectedValue)).Content.ToString());
            //stcPanel.Children[0] = botones.Botones;
            botones.InsertarBotones();
        }

        private void CmbFilas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int aux;
            if (int.TryParse(((ComboBoxItem)(cmbFilas.SelectedItem)).Content.ToString(), out aux) && ((ComboBoxItem)(cmbColumnas.SelectedItem))!=null && int.TryParse(((ComboBoxItem)(cmbColumnas.SelectedItem)).Content.ToString(), out aux))
            {
                botones.Alto = int.Parse(((ComboBoxItem)(cmbFilas.SelectedItem)).Content.ToString());
                botones.Ancho = int.Parse(((ComboBoxItem)(cmbColumnas.SelectedItem)).Content.ToString());
                btnCrear.IsEnabled = true;
            }
            else
            {
                btnCrear.IsEnabled = false;
            }
        }
        private void CmbColumnas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int aux;
            if (((ComboBoxItem)(cmbFilas.SelectedItem)) != null && int.TryParse(((ComboBoxItem)(cmbFilas.SelectedItem)).Content.ToString(), out aux) && int.TryParse(((ComboBoxItem)(cmbColumnas.SelectedItem)).Content.ToString(), out aux))
            {
                botones.Alto = int.Parse(((ComboBoxItem)(cmbFilas.SelectedItem)).Content.ToString());
                botones.Ancho = int.Parse(((ComboBoxItem)(cmbColumnas.SelectedItem)).Content.ToString());
                btnCrear.IsEnabled = true;
            }
            else
            {
                btnCrear.IsEnabled = false;
            }
        }
    }
}
