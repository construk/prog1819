using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf_R920_TresEnRaya
{
    public enum CaracterJuego { X, O }
    
    public partial class MainWindow : Window
    {
        #region CAMPOS
        private const CaracterJuego caracterJugador = CaracterJuego.X;  // X
        private const CaracterJuego caracterMaquina = CaracterJuego.O;  // O
        private TresEnRaya juego;                                       // Control de juego
        private SolidColorBrush colorMaquina;                           // Red
        private SolidColorBrush colorHumano;                            // Blue
        private bool IAActivada;                                        // Si está activada o no la IA.
        private bool turnoJugador1;                                     // Indica de quien es el turno -> true: jugador1. false: jugador2
        #endregion CAMPOS

        #region CONSTRUCTOR
        public MainWindow()
        {
            InitializeComponent();
            InicializarAplicacion();
        }
        #endregion CONSTRUCTOR

        #region EVENTOS

        private void EvtPonerFicha(object sender, RoutedEventArgs e)
        {
            if (IAActivada)
            {
                JugarConIA(sender);
            }
            else
            {
                JugarContraPersona(sender);
            }
        }

        private void EvtCambiarFondo(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            DesCheckearFondo();
            switch (item.Header)
            {
                case "Verde":
                    foreach (Button boton in gridJuego.Children)
                    {
                        boton.Background = Brushes.Green;
                        fondoVerde.IsChecked = true;
                    }
                    break;
                case "Blanco":
                    foreach (Button boton in gridJuego.Children)
                    {
                        boton.Background = Brushes.White;
                        fondoBlanco.IsChecked = true;
                    }
                    break;
                case "Marrón":
                    foreach (Button boton in gridJuego.Children)
                    {
                        boton.Background = Brushes.Brown;
                        fondoMarron.IsChecked = true;
                    }
                    break;
            }
        }

        #endregion EVENTOS

        #region MÉTODOS
        private void InicializarAplicacion()
        {
            juego = new TresEnRaya();
            colorMaquina = Brushes.Red;
            colorHumano = Brushes.Blue;
            IAActivada = false;
            juego.EmpezarPartida();
            turnoJugador1 = true;
        }

        private void ReiniciarPartida()
        {
            btn1.Content = "";
            btn2.Content = "";
            btn3.Content = "";
            btn4.Content = "";
            btn5.Content = "";
            btn6.Content = "";
            btn7.Content = "";
            btn8.Content = "";
            btn9.Content = "";
            juego = new TresEnRaya();
            juego.EmpezarPartida();
            turnoJugador1 = true;
        }

        private void CheckGanadorVS()
        {
            string mensaje;
            if (juego.GanadorPartida == (int)ValoresJuego.Jugador)
            {
                mensaje = "Gana el jugador 1";
                MessageBoxButton but = MessageBoxButton.YesNo;
                MessageBoxImage img = MessageBoxImage.Information;
                MessageBoxResult resultado = MessageBox.Show("¿Quieres jugar otra partida?", mensaje, but, img);
                if (resultado == MessageBoxResult.Yes)
                {
                    ReiniciarPartida();
                }
                else
                {
                    Application.Current.MainWindow.Close();
                }
            }
            else if (juego.GanadorPartida == (int)ValoresJuego.Jugador2)
            {
                mensaje = "Gana el jugador 2";
                MessageBoxButton but = MessageBoxButton.YesNo;
                MessageBoxImage img = MessageBoxImage.Information;
                MessageBoxResult resultado = MessageBox.Show("¿Quieres jugar otra partida?", mensaje, but, img);
                if (resultado == MessageBoxResult.Yes)
                {
                    ReiniciarPartida();
                }
                else
                {
                    Application.Current.MainWindow.Close();
                }
            }
            else
            {
                if (juego.IsTableroCompleto)
                {
                    mensaje = "Habeis empatado";
                    MessageBoxButton but = MessageBoxButton.YesNo;
                    MessageBoxImage img = MessageBoxImage.Information;
                    MessageBoxResult resultado = MessageBox.Show("¿Quieres jugar otra partida?", mensaje, but, img);
                    if (resultado == MessageBoxResult.Yes)
                    {
                        ReiniciarPartida();
                    }
                    else
                    {
                        App.Current.MainWindow.Close();
                    }
                }
            }
        }

        private void AccionIAAndCheckGanador()
        {
            int[] ultimoBoton = juego.UltimaJugadaIA;
            if (ultimoBoton[0] == 0 && ultimoBoton[1] == 0)
            {
                btn1.Foreground = colorMaquina;
                btn1.Content = caracterMaquina.ToString();
            }
            else if (ultimoBoton[0] == 0 && ultimoBoton[1] == 1)
            {
                btn2.Foreground = colorMaquina;
                btn2.Content = caracterMaquina.ToString();
            }
            else if (ultimoBoton[0] == 0 && ultimoBoton[1] == 2)
            {
                btn3.Foreground = colorMaquina;
                btn3.Content = caracterMaquina.ToString();
            }
            else if (ultimoBoton[0] == 1 && ultimoBoton[1] == 0)
            {
                btn4.Foreground = colorMaquina;
                btn4.Content = caracterMaquina.ToString();
            }
            else if (ultimoBoton[0] == 1 && ultimoBoton[1] == 1)
            {
                btn5.Foreground = colorMaquina;
                btn5.Content = caracterMaquina.ToString();
            }
            else if (ultimoBoton[0] == 1 && ultimoBoton[1] == 2)
            {
                btn6.Foreground = colorMaquina;
                btn6.Content = caracterMaquina.ToString();
            }
            else if (ultimoBoton[0] == 2 && ultimoBoton[1] == 0)
            {
                btn7.Foreground = colorMaquina;
                btn7.Content = caracterMaquina.ToString();
            }
            else if (ultimoBoton[0] == 2 && ultimoBoton[1] == 1)
            {
                btn8.Foreground = colorMaquina;
                btn8.Content = caracterMaquina.ToString();
            }
            else if (ultimoBoton[0] == 2 && ultimoBoton[1] == 2)
            {
                btn9.Foreground = colorMaquina;
                btn9.Content = caracterMaquina.ToString();
            }

            string mensaje;
            if (juego.GanadorPartida == (int)ValoresJuego.Jugador)
            {
                mensaje = "¡Has ganado!";
                MensajeFinPartida(mensaje);
            }
            else if (juego.GanadorPartida == (int)ValoresJuego.Jugador2)
            {
                mensaje = "Has perdido...";
                MensajeFinPartida(mensaje);
            }
            else
            {
                if (juego.IsTableroCompleto)
                {
                    mensaje = "Has empatado";
                    MensajeFinPartida(mensaje);
                }
            }
        }

        private void MensajeFinPartida(string mensaje)
        {
            MessageBoxButton but = MessageBoxButton.YesNo;
            MessageBoxImage img = MessageBoxImage.Information;
            MessageBoxResult resultado = MessageBox.Show("¿Quieres jugar otra partida?", mensaje, but, img);
            if (resultado == MessageBoxResult.Yes)
            {
                ReiniciarPartida();
            }
            else
            {
                Application.Current.MainWindow.Close();
            }
        }

        private void DesCheckearFondo()
        {
            fondoBlanco.IsChecked = false;
            fondoVerde.IsChecked = false;
            fondoMarron.IsChecked = false;
        }

        private void JugarContraPersona(object sender)
        {
            CaracterJuego jugadorTmp;
            SolidColorBrush colorTmp;
            if (turnoJugador1)
            {
                jugadorTmp = caracterJugador;
                colorTmp = colorHumano;
            }
            else
            {
                jugadorTmp = caracterMaquina;
                colorTmp = colorMaquina;
            }

            Button btn = (Button)sender;
            int i, j;
            switch (btn.Name)
            {
                case "btn1":
                    i = 0; j = 0;
                    if (juego.Tablero[i, j] == (int)ValoresJuego.Vacio)
                    {
                        btn1.Content = jugadorTmp.ToString();
                        juego.PulsarBoton(i, j, turnoJugador1);
                        btn1.Foreground = colorTmp;
                    }
                    break;
                case "btn2":
                    i = 0; j = 1;
                    if (juego.Tablero[i, j] == (int)ValoresJuego.Vacio)
                    {
                        btn2.Content = jugadorTmp.ToString();
                        juego.PulsarBoton(i, j, turnoJugador1);
                        btn2.Foreground = colorTmp;
                    }
                    break;
                case "btn3":
                    i = 0; j = 2;
                    if (juego.Tablero[i, j] == (int)ValoresJuego.Vacio)
                    {
                        btn3.Content = jugadorTmp.ToString();
                        juego.PulsarBoton(i, j, turnoJugador1);
                        btn3.Foreground = colorTmp;
                    }
                    break;
                case "btn4":
                    i = 1; j = 0;
                    if (juego.Tablero[i, j] == (int)ValoresJuego.Vacio)
                    {
                        btn4.Content = jugadorTmp.ToString();
                        juego.PulsarBoton(i, j, turnoJugador1);
                        btn4.Foreground = colorTmp;
                    }
                    break;
                case "btn5":
                    i = 1; j = 1;
                    if (juego.Tablero[i, j] == (int)ValoresJuego.Vacio)
                    {
                        btn5.Content = jugadorTmp.ToString();
                        juego.PulsarBoton(i, j, turnoJugador1);
                        btn5.Foreground = colorTmp;
                    }
                    break;
                case "btn6":
                    i = 1; j = 2;
                    if (juego.Tablero[i, j] == (int)ValoresJuego.Vacio)
                    {
                        btn6.Content = jugadorTmp.ToString();
                        juego.PulsarBoton(i, j, turnoJugador1);
                        btn6.Foreground = colorTmp;
                    }
                    break;
                case "btn7":
                    i = 2; j = 0;
                    if (juego.Tablero[i, j] == (int)ValoresJuego.Vacio)
                    {
                        btn7.Content = jugadorTmp.ToString();
                        juego.PulsarBoton(i, j, turnoJugador1);
                        btn7.Foreground = colorTmp;
                    }
                    break;
                case "btn8":
                    i = 2; j = 1;
                    if (juego.Tablero[i, j] == (int)ValoresJuego.Vacio)
                    {
                        btn8.Content = jugadorTmp.ToString();
                        juego.PulsarBoton(i, j, turnoJugador1);
                        btn8.Foreground = colorTmp;
                    }
                    break;
                case "btn9":
                    i = 2; j = 2;
                    if (juego.Tablero[i, j] == (int)ValoresJuego.Vacio)
                    {
                        btn9.Content = jugadorTmp.ToString();
                        juego.PulsarBoton(i, j, turnoJugador1);
                        btn9.Foreground = colorTmp;
                    }
                    break;
            }
            turnoJugador1 = !turnoJugador1;
            CheckGanadorVS();
        }

        private void JugarConIA(object sender)
        {
            Button btn = (Button)sender;
            int i, j;
            switch (btn.Name)
            {
                case "btn1":
                    i = 0; j = 0;
                    if (juego.Tablero[i, j] == -1)
                    {
                        btn1.Content = caracterJugador.ToString();
                        juego.PulsarBoton(i, j);
                        btn1.Foreground = colorHumano;
                    }
                    break;
                case "btn2":
                    i = 0; j = 1;
                    if (juego.Tablero[i, j] == -1)
                    {
                        btn2.Content = caracterJugador.ToString();
                        juego.PulsarBoton(i, j);
                        btn2.Foreground = colorHumano;
                    }
                    break;
                case "btn3":
                    i = 0; j = 2;
                    if (juego.Tablero[i, j] == -1)
                    {
                        btn3.Content = caracterJugador.ToString();
                        juego.PulsarBoton(i, j);
                        btn3.Foreground = colorHumano;
                    }
                    break;
                case "btn4":
                    i = 1; j = 0;
                    if (juego.Tablero[i, j] == -1)
                    {
                        btn4.Content = caracterJugador.ToString();
                        juego.PulsarBoton(i, j);
                        btn4.Foreground = colorHumano;
                    }
                    break;
                case "btn5":
                    i = 1; j = 1;
                    if (juego.Tablero[i, j] == -1)
                    {
                        btn5.Content = caracterJugador.ToString();
                        juego.PulsarBoton(i, j);
                        btn5.Foreground = colorHumano;
                    }
                    break;
                case "btn6":
                    i = 1; j = 2;
                    if (juego.Tablero[i, j] == -1)
                    {
                        btn6.Content = caracterJugador.ToString();
                        juego.PulsarBoton(i, j);
                        btn6.Foreground = colorHumano;
                    }
                    break;
                case "btn7":
                    i = 2; j = 0;
                    if (juego.Tablero[i, j] == -1)
                    {
                        btn7.Content = caracterJugador.ToString();
                        juego.PulsarBoton(i, j);
                        btn7.Foreground = colorHumano;
                    }
                    break;
                case "btn8":
                    i = 2; j = 1;
                    if (juego.Tablero[i, j] == -1)
                    {
                        btn8.Content = caracterJugador.ToString();
                        juego.PulsarBoton(i, j);
                        btn8.Foreground = colorHumano;
                    }
                    break;
                case "btn9":
                    i = 2; j = 2;
                    if (juego.Tablero[i, j] == -1)
                    {
                        btn9.Content = caracterJugador.ToString();
                        juego.PulsarBoton(i, j);
                        btn9.Foreground = colorHumano;
                    }
                    break;
            }
            AccionIAAndCheckGanador();
        }

        #endregion MÉTODOS

    }
}