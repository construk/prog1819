using System.Windows;
namespace Wpf_R916_Craps
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Craps juegoCraps;
        public MainWindow()
        {
            InitializeComponent();
            juegoCraps = (Craps)Resources["JuegoCraps"];
            juegoCraps.Evt_ResultadoPartida += JuegoCraps_Evt_ResultadoPartida;
        }
        private void JuegoCraps_Evt_ResultadoPartida(bool victoria)
        {
            if (victoria)
            {
                MessageBox.Show("¡Has ganado!");
            }
            else
            {
                MessageBox.Show("Has perdido...");
            }
            ((Craps)Resources["JuegoCraps"]).ReiniciarPartida();
        }
    }
}