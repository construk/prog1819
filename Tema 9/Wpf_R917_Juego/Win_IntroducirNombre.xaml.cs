using System;
using System.Windows;
using System.Windows.Controls;
namespace Wpf_R917_Juego
{
    /// <summary>
    /// Lógica de interacción para Win_IntroducirNombre.xaml
    /// </summary>
    public partial class Win_IntroducirNombre : Window
    {
        public Win_IntroducirNombre()
        {
            InitializeComponent();
        }

        private void NombreNuevo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!NombreNuevo.Text.TrimEnd(' ').Equals(""))
            {
                btn_InsertarNombre.IsEnabled = true;
            }
            else
            {
                btn_InsertarNombre.IsEnabled = false;
            }
        }

        private void Btn_InsertarNombre_Click(object sender, RoutedEventArgs e)
        { 
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).Nombre.Text = NombreNuevo.Text; 
                }
            }
            DialogResult = true;
        }

        
    }
}
