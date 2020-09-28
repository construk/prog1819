using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Wpf_R917_Juego
{
    [Serializable]
    public class Score : IComparer<Score>
    {
        const int LONG_MAX_NOMBRE = 30;
        private string nombre;
        public long score;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Length > LONG_MAX_NOMBRE)
                {
                    nombre = value.Substring(LONG_MAX_NOMBRE);
                }
                else
                {
                    nombre = value;
                }
            }
        }
        public Score() { }
        public Score(string nombre, long score)
        {
            Nombre = nombre;
            this.score = score;
        }
        public int Compare(Score x, Score y)
        {
            return y.score.CompareTo(x.score);
        }
    }
    public class Scores
    {
        public delegate void dlgNuevoRecord(Score sc);
        public event dlgNuevoRecord EvtNuevoRecord;
        List<Score> lista;
        public Score this[int i]
        {
            get { return lista[i]; }
        }
        public Scores()
        {
            lista = new List<Score>(10);
        }
        public void LeerScores(string rutaFichero)
        {
            if (File.Exists(rutaFichero))
            {
                using (Stream flujo = File.Open(rutaFichero, FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    try
                    {
                        while (true)
                        {
                            lista.Add((Score)binaryFormatter.Deserialize(flujo));
                        }
                    }
                    catch { }
                }
            }
        }
        public void GuardarScores(string rutaFichero)
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (Stream flujo = File.Open(rutaFichero, FileMode.Create))
            {
                // var : BinaryFormatter [ IFormatter ]
                foreach (Score score in lista)
                {
                    binaryFormatter.Serialize(flujo, score);
                }
            }
        }
        public int Count()
        {
            return lista.Count();
        }
        public void AnadirScore(Score score)
        {
            Score recibido = new Score(score.Nombre, score.score);
            bool record = false;
            if (lista.Count < 10)
            {
                record = true;
            }
            else
            {
                for (int i = 0; i < lista.Count && i < 10; i++)
                {
                    if (recibido.score > lista[i].score)
                    {
                        record = true;
                    }
                }
            }
            

            if (record)
            {
                //Evento si está entre los 10 primeros jugadores
                if (EvtNuevoRecord != null)
                {
                    EvtNuevoRecord(score);
                }
                lista.Add(score);
                OrdenarLista();
                TruncarListaDesdePos10();
            }


            /*
            bool mejorUltimoScore;
            if (lista.Count <= 10)
            {
                mejorUltimoScore = true;
            }
            else
            {
                if (lista.IndexOf(score) <= 9)
                {
                    mejorUltimoScore = true;
                }
                else
                {
                    mejorUltimoScore = false;
                }
            }
            */
        }
        private void OrdenarLista()
        {
            Score score = new Score();
            lista.Sort(score);
        }
        private void TruncarListaDesdePos10()
        {
            try { while (true) { lista.RemoveAt(10); } } catch { }
        }
    }

    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Campos
        DispatcherTimer reloj;                  //Reloj para eventos de movimiento                                                //CONSTANTES
        #region Constantes
        #region Pala
        const double MAX_PALA = 895;            //Canvas.Left=895   --> MAX
        const double MIN_PALA = 0;              //Canvas.Left=0     --> MIN
        #endregion
        #region Colision Pala/Bola
        const double DIF_IZQ_BOLA = -10;        //Para colisión Canvas.Left de pala y bola diferencia máxima por izquierda
        const double DIF_DER_BOLA = 90;         //Para colisión Canvas.Left de pala y bola diferencia máxima por derecha
        #endregion
        #region Bola
        const double MAX_ALTO_BOLA_MAX = 395;       //Canvas.Botton=395 --> MAX
        const double POS_ALTO_BOLA_MIN = 40;    //Canvas.Botton=40  --> Posición fija de la pala en altura.
        const double MAX_BOLA = 965;            //Canvas.Left=965   --> MAX
        const double MIN_BOLA = 0;              //Canvas.Left=0     --> MIN
        #endregion
        #region Juego
        string rutaFichero = "./score.bin";
        #endregion
        #endregion
        #region Variables
        #region Juego
        Scores scores;
        double contadorPuntosReloj; // Contador para tiempo de partida y puntos
        bool condicionGameOver;     // Cuando pierdes es verdad, sino falso
        bool started;               // Si no está pausada la partida es verdad, sino falso
        bool gameOver;              // Si pierdes es verdad, sino falso
        bool controlMouse;
        #endregion
        #region Bola
        int subeBajaBola;           // -1 baja      |   1 sube;
        int izquierdaDerechaBola;   // -1 izquierda |   1 derecha;
        double velocidadBola;       // La velocidad con la que se mueve la bola (multiplica subeBajaBola e izquierdaDerechaBola)
        #endregion
        #region Pala
        double desplazamientoPala;  // Movimiento que realiza la pala al desplazarse
        double posicionPala;        // Posición de la pala en el juego (controlado con propiedad) 
        int margenErrorPala;        // Margen de error para poder darle "laterlmente" a la bola
        #endregion
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;   //Evento interfaz
        #endregion
        public MainWindow()
        {
            /*condicionGameOver = Canvas.GetBottom(Bola) < POS_ALTO_PALA;*/
            scores = new Scores();
            scores.LeerScores(rutaFichero);
            scores.EvtNuevoRecord += Evt_NuevoRecord;
            InitializeComponent();
            contadorPuntosReloj = 0;
            desplazamientoPala = 15;
            posicionPala = 500;
            velocidadBola = 1;
            margenErrorPala = 20;
            PrepararJuego();
            reloj = new DispatcherTimer //Reloj de paso del tiempo, gestiona evento de movimiento
            {
                Interval = new TimeSpan(0, 0, 0, 0, 1) //Tiempo de un 1 milisegundo
            };
            reloj.Start();
            reloj.Tick += TiempoJuegoMovPelota;
            controlMouse = false;
        }
        #region Binding
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
        #region Pelota
        #region Info
        /***************************************** MOVIMIENTO PELOTA *****************************************/
        /*  Comienza moverse hacia abajo y hacia la izquierda.  */
        /*  Si colisiona izquierda, cambia dirección derecha. --> Si Canvas.Left=MIN_BOLA */
        /*  Si colisiona derecha, cambia dirección izquierda. --> Si Canvas.Left=MAX_BOLA */
        /*  Si colisiona con pala, cambia dirección arriba.   --> 
                 -Colisión pala: 
                        + Colisión dentro de los parámetros de la pala y la altura de la misma.
                        +bool condicionColisionPala= Pelota.Canvas.Left>=Pala.Canvas.Left+DIF_IZQ_BOLA &&
                                                    Pelota.Canvas.Left<=Pala.Canvas.Left+DIF_DER_BOLA &&
                                                    Pelota.Canvas.Bottom==POS_ALTA_PALA;
                        + Si no colosiona con pala pierdes.                                                 */
        /*  Si colisiona arriba, cambia dirección abajo.      -->
                -Colisión techo;
                        +bool condicionReboteTecho = Pelota.Canvas.Botton== MAX_ALTO_BOLA;                  */
        #endregion
        #region Métodos
        private void Izquierda() { izquierdaDerechaBola = -1; }
        private void Derecha() { izquierdaDerechaBola = 1; }
        private void Arriba() { subeBajaBola = 1; }
        private void Abajo() { subeBajaBola = -1; }
        private void Parar() { subeBajaBola = 0; izquierdaDerechaBola = 0; }
        private void EstablecerDireccion()
        {
            bool reboteParedIzquierda = Canvas.GetLeft(Bola) <= MIN_BOLA;
            bool reboteParedDerecha = Canvas.GetLeft(Bola) >= MAX_BOLA;
            bool condicionColisionPala = Canvas.GetLeft(Bola) >= Canvas.GetLeft(Pala) + DIF_IZQ_BOLA &&
                                                    Canvas.GetLeft(Bola) <= Canvas.GetLeft(Pala) + DIF_DER_BOLA &&
                                                    Canvas.GetBottom(Bola) <= POS_ALTO_BOLA_MIN && Canvas.GetBottom(Bola) >= POS_ALTO_BOLA_MIN - velocidadBola - margenErrorPala;
            bool condicionReboteTecho = Canvas.GetBottom(Bola) >= MAX_ALTO_BOLA_MAX;
            condicionGameOver = Canvas.GetBottom(Bola) < POS_ALTO_BOLA_MIN - velocidadBola - margenErrorPala;
            //IZQUIERDA O DERECHA
            if (reboteParedIzquierda)
            {
                Derecha();
            }
            else if (reboteParedDerecha)
            {
                Izquierda();
            }
            //ARRIBA O ABAJO
            if (condicionColisionPala)
            {
                Arriba();
            }
            else if (condicionReboteTecho)
            {
                Abajo();
            }
            if (condicionGameOver)
            {
                GameOver();
            }
        }
        private void MoverBola()
        {
            Canvas.SetBottom(Bola, Canvas.GetBottom(Bola) + subeBajaBola * velocidadBola);
            Canvas.SetLeft(Bola, Canvas.GetLeft(Bola) + izquierdaDerechaBola * velocidadBola);
        }
        #endregion
        /****************************************************************************************************/
        #endregion
        #region Pala
        #region Info
        /***************************************** MOVIMIENTO PALA *****************************************/
        /*  -Solo movimiento horizontal:
                +Valor mínimo: MIN_PALA = 0;
                +Valor máximo: MAX_PALA = 895;                                                              */
        /****************************************************************************************************/
        #endregion
        #region Propiedad
        private double PosicionPala
        {
            get { return posicionPala; }
            set
            {
                if (value <= MIN_PALA) { posicionPala = MIN_PALA; }    //Valor mínimo: MIN_PALA = 0;
                else if (value >= MAX_PALA) { posicionPala = MAX_PALA; }   //Valor máximo: MAX_PALA = 895;
                else { posicionPala = value; }
                Canvas.SetLeft(Pala, PosicionPala);
                //OnPropertyChanged();
            }
        }
        #endregion
        #endregion
        #region Partida
        private void PrepararJuego()
        {
            started = false;
            TextoGameOver.Visibility = Visibility.Hidden;
            btnReiniciarPartida.Visibility = Visibility.Hidden;
            Canvas.SetBottom(Bola, 390);
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
            Abajo();
            Izquierda();
            gameOver = false;
            contadorPuntosReloj = 0;
            ListaClasificacion.Visibility = Visibility.Hidden;
        }
        private void StartGame()
        {
            started = true;
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }
        private void StopGame()
        {
            started = false;
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }
        private void GameOver()
        {
            gameOver = true;
            Parar();

            Score sc = new Score(Nombre.Text, (long)contadorPuntosReloj);
            scores.AnadirScore(sc);
            RellenarClasificacion();
            scores.GuardarScores(rutaFichero);
            TextoGameOver.Visibility = Visibility.Visible;
            btnReiniciarPartida.Visibility = Visibility.Visible;
            ListaClasificacion.Visibility = Visibility.Visible;
        }
        private void ActivarTodosBotonesDificultad()
        {
            btn0.IsEnabled = true;
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            btn5.IsEnabled = true;
        }
        private void RellenarClasificacion()
        {
            TextBlock[] elementos = GetItems(ListaClasificacion);

            for (int i = 0; i < (scores.Count() * 2); i++)
            {
                if (i % 2 == 0)
                {
                    elementos[i].Text = scores[i / 2].Nombre;
                }
                else
                {
                    elementos[i].Text = scores[i / 2].score.ToString("#,##0");
                }
            }
        }
        private TextBlock[] GetItems(StackPanel vistaLista)
        {
            string[] nombresHijos = new string[] { "j1","s1", "j2", "s2", "j3", "s3","j4", "s4", "j5", "s5",
                "j6", "s6", "j7", "s7", "j8","s8", "j9","s9", "j10","s10" };
            List<StackPanel> stcpanel = new List<StackPanel>();
            TextBlock[] hijos = new TextBlock[40];
            int contador = 0;
            Grid grid = (Grid)vistaLista.Children[1];
            StackPanel panelPrinc1 = (StackPanel)grid.Children[0];
            StackPanel panelSec1 = (StackPanel)panelPrinc1.Children[0];
            StackPanel panelSec2 = (StackPanel)panelPrinc1.Children[1];
            StackPanel panelSec3 = (StackPanel)panelPrinc1.Children[2];
            StackPanel panelSec4 = (StackPanel)panelPrinc1.Children[3];
            StackPanel panelSec5 = (StackPanel)panelPrinc1.Children[4];

            StackPanel panelPrinc2 = (StackPanel)grid.Children[1];
            StackPanel panelSec6 = (StackPanel)panelPrinc2.Children[0];
            StackPanel panelSec7 = (StackPanel)panelPrinc2.Children[1];
            StackPanel panelSec8 = (StackPanel)panelPrinc2.Children[2];
            StackPanel panelSec9 = (StackPanel)panelPrinc2.Children[3];
            StackPanel panelSec10 = (StackPanel)panelPrinc2.Children[4];

            for (int i = 0; i < panelSec1.Children.Count; i++)
            {
                try
                {
                    TextBlock hijo = (TextBlock)panelSec1.Children[i];
                    for (int j = 0; j < nombresHijos.Length; j++)
                    {
                        if (hijo.Name.Equals(nombresHijos[j]))
                        {
                            hijos[contador++] = hijo;
                        }
                    }
                }
                catch { }
            }
            for (int i = 0; i < panelSec2.Children.Count; i++)
            {
                try
                {
                    TextBlock hijo = (TextBlock)panelSec2.Children[i];
                    for (int j = 0; j < nombresHijos.Length; j++)
                    {
                        if (hijo.Name.Equals(nombresHijos[j]))
                        {
                            hijos[contador++] = hijo;
                        }
                    }
                }
                catch { }
            }
            for (int i = 0; i < panelSec3.Children.Count; i++)
            {
                try
                {
                    TextBlock hijo = (TextBlock)panelSec3.Children[i];
                    for (int j = 0; j < nombresHijos.Length; j++)
                    {
                        if (hijo.Name.Equals(nombresHijos[j]))
                        {
                            hijos[contador++] = hijo;
                        }
                    }
                }
                catch { }
            }
            for (int i = 0; i < panelSec4.Children.Count; i++)
            {
                try
                {
                    TextBlock hijo = (TextBlock)panelSec4.Children[i];
                    for (int j = 0; j < nombresHijos.Length; j++)
                    {
                        if (hijo.Name.Equals(nombresHijos[j]))
                        {
                            hijos[contador++] = hijo;
                        }
                    }
                }
                catch { }
            }
            for (int i = 0; i < panelSec5.Children.Count; i++)
            {
                try
                {
                    TextBlock hijo = (TextBlock)panelSec5.Children[i];
                    for (int j = 0; j < nombresHijos.Length; j++)
                    {
                        if (hijo.Name.Equals(nombresHijos[j]))
                        {
                            hijos[contador++] = hijo;
                        }
                    }
                }
                catch { }
            }
            for (int i = 0; i < panelSec6.Children.Count; i++)
            {
                try
                {
                    TextBlock hijo = (TextBlock)panelSec6.Children[i];
                    for (int j = 0; j < nombresHijos.Length; j++)
                    {
                        if (hijo.Name.Equals(nombresHijos[j]))
                        {
                            hijos[contador++] = hijo;
                        }
                    }
                }
                catch { }
            }
            for (int i = 0; i < panelSec7.Children.Count; i++)
            {
                try
                {
                    TextBlock hijo = (TextBlock)panelSec7.Children[i];
                    for (int j = 0; j < nombresHijos.Length; j++)
                    {
                        if (hijo.Name.Equals(nombresHijos[j]))
                        {
                            hijos[contador++] = hijo;
                        }
                    }
                }
                catch { }
            }
            for (int i = 0; i < panelSec8.Children.Count; i++)
            {
                try
                {
                    TextBlock hijo = (TextBlock)panelSec8.Children[i];
                    for (int j = 0; j < nombresHijos.Length; j++)
                    {
                        if (hijo.Name.Equals(nombresHijos[j]))
                        {
                            hijos[contador++] = hijo;
                        }
                    }
                }
                catch { }
            }
            for (int i = 0; i < panelSec9.Children.Count; i++)
            {
                try
                {
                    TextBlock hijo = (TextBlock)panelSec9.Children[i];
                    for (int j = 0; j < nombresHijos.Length; j++)
                    {
                        if (hijo.Name.Equals(nombresHijos[j]))
                        {
                            hijos[contador++] = hijo;
                        }
                    }
                }
                catch { }
            }
            for (int i = 0; i < panelSec10.Children.Count; i++)
            {
                try
                {
                    TextBlock hijo = (TextBlock)panelSec10.Children[i];
                    for (int j = 0; j < nombresHijos.Length; j++)
                    {
                        if (hijo.Name.Equals(nombresHijos[j]))
                        {
                            hijos[contador++] = hijo;
                        }
                    }
                }
                catch { }
            }
            TextBlock[] resultado = new TextBlock[contador];
            Array.Copy(hijos, resultado, contador);
            return resultado;
        }
        #endregion
        #region Eventos    
        private void TiempoJuegoMovPelota(object sender, EventArgs e)
        {
            if (!gameOver && started)
            {
                EstablecerDireccion();
                MoverBola();
                try     //Contar puntos en función de la velocidad de la pelota
                {
                    if (!gameOver)
                    {
                        contadorPuntosReloj += (velocidadBola *velocidadBola)*0.25;
                        Marcador.Text = contadorPuntosReloj.ToString("#,##0").PadLeft(10);
                    }
                }
                catch { contadorPuntosReloj = 0; }
            }
        }
        private void Win_principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                PosicionPala -= desplazamientoPala;
            }
            else if (e.Key == Key.Right)
            {
                PosicionPala += desplazamientoPala;
            }
            else if (e.Key==Key.Enter||e.Key==Key.Space)
            {
                if (gameOver)
                {
                    PrepararJuego();
                }
                else
                {
                    started = !started;
                }
            }
        }
        private void BtnReiniciarPartida_Click(object sender, RoutedEventArgs e)
        {
            PrepararJuego();
        }
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }
        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            StopGame();
        }
        private void Btn_Dificultad(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            ActivarTodosBotonesDificultad();
            btn.IsEnabled = false;
            if (btn.Name.Equals("btn0"))
            {
                velocidadBola = 1;
            }
            else if (btn.Name.Equals("btn1"))
            {
                velocidadBola = 2;
            }
            else if (btn.Name.Equals("btn2"))
            {
                velocidadBola = 3;
            }
            else if (btn.Name.Equals("btn3"))
            {
                velocidadBola = 4;
            }
            else if (btn.Name.Equals("btn4"))
            {
                velocidadBola = 4.5;
            }
            else if (btn.Name.Equals("btn5"))
            {
                velocidadBola = 5;
            }
        }
        private void Btn_VelocidadBola(object sender, RoutedEventArgs e)
        {
            MenuItem btn = (MenuItem)sender;
            if (btn.Name.Equals("n0"))
            {
                velocidadBola = 1;
            }
            else if (btn.Name.Equals("n1"))
            {
                velocidadBola = 2;
            }
            else if (btn.Name.Equals("n2"))
            {
                velocidadBola = 3;
            }
            else if (btn.Name.Equals("n3"))
            {
                velocidadBola = 4;
            }
            else if (btn.Name.Equals("n4"))
            {
                velocidadBola = 4.5;
            }
            else if (btn.Name.Equals("n5"))
            {
                velocidadBola = 5;
            }
            else if (btn.Name.Equals("n6"))
            {
                velocidadBola = 5.5;
            }
            else if (btn.Name.Equals("n7"))
            {
                velocidadBola = 6;
            }
            else if (btn.Name.Equals("n8"))
            {
                velocidadBola = 7;
            }
            else if (btn.Name.Equals("n9"))
            {
                velocidadBola = 8;
            }
            else if (btn.Name.Equals("n10"))
            {
                velocidadBola = 9;
            }
            else if (btn.Name.Equals("n11"))
            {
                velocidadBola = 10;
            }
            else if (btn.Name.Equals("n12"))
            {
                velocidadBola = 12;
            }
            else if (btn.Name.Equals("n13"))
            {
                velocidadBola =14;
            }
            else if (btn.Name.Equals("n14"))
            {
                velocidadBola = 16;
            }
            else if (btn.Name.Equals("n15"))
            {
                velocidadBola = 20;
            }
        }
        private void Btn_Dificultad2(object sender, RoutedEventArgs e)
        {
            MenuItem mnItem = (MenuItem)sender;
            if (mnItem.Name.Equals("btn01"))
            {
                velocidadBola = 1;
            }
            else if (mnItem.Name.Equals("btn11"))
            {
                velocidadBola = 2;
            }
            else if (mnItem.Name.Equals("btn21"))
            {
                velocidadBola = 3;
            }
            else if (mnItem.Name.Equals("btn31"))
            {
                velocidadBola = 4;
            }
            else if (mnItem.Name.Equals("btn41"))
            {
                velocidadBola = 4.5;
            }
            else if (mnItem.Name.Equals("btn51"))
            {
                velocidadBola = 5;
            }
        }
        private void Btn_Pala(object sender, RoutedEventArgs e)
        {
            MenuItem mnItem = (MenuItem)sender;
            if (mnItem.Name.Equals("p1"))
            {
                desplazamientoPala = 15;
            }
            else if (mnItem.Name.Equals("p2"))
            {
                desplazamientoPala = 20;
            }
            else if (mnItem.Name.Equals("p3"))
            {
                desplazamientoPala = 25;
            }
            else if (mnItem.Name.Equals("p4"))
            {
                desplazamientoPala = 30;
            }
            else if (mnItem.Name.Equals("p5"))
            {
                desplazamientoPala = 35;
            }
            else if (mnItem.Name.Equals("p6"))
            {
                desplazamientoPala = 40;
            }
            else if (mnItem.Name.Equals("p7"))
            {
                desplazamientoPala = 45;
            }
            else if (mnItem.Name.Equals("p8"))
            {
                desplazamientoPala = 50;
            }
            else if (mnItem.Name.Equals("p9"))
            {
                desplazamientoPala = 55;
            }
            else if (mnItem.Name.Equals("p10"))
            {
                desplazamientoPala = 60;
            }
            else if (mnItem.Name.Equals("p11"))
            {
                desplazamientoPala = 65;
            }
            else if (mnItem.Name.Equals("p12"))
            {
                desplazamientoPala = 70;
            }
        }
        private void BtnAntesReiniciarMensaje(object sender, RoutedEventArgs e)
        {
            if (!gameOver)
            {
                MessageBoxButton botones = MessageBoxButton.YesNo;
                MessageBoxImage imagen = MessageBoxImage.Warning;

                MessageBoxResult resultado = MessageBox.Show("¿Estás seguro que deseas reiniciar la partida? Si para reiniciar, pero perderás todo el progreso realizado.", "¿REINICIAR PARTIDA?", botones, imagen);
                if (resultado == MessageBoxResult.Yes)
                {
                    PrepararJuego();
                }
            }
            else
            {
                PrepararJuego();
            }
        }
        private void Evt_NuevoRecord(Score sc)
        {
            if (Nombre.Text.TrimEnd(' ').Equals(""))
            {
                Win_IntroducirNombre ventana = new Win_IntroducirNombre();
                ventana.InitializeComponent();
                ventana.ShowDialog();
                bool? result = ventana.DialogResult;
                if (result == true)
                {
                    sc.Nombre = Nombre.Text;
                }
            }
        }
        #endregion
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        private void EspacioJuego_MouseMove(object sender, MouseEventArgs e)
        {
            if (controlMouse)
            {
                Point punto = e.MouseDevice.GetPosition(EspacioJuego);
                PosicionPala = punto.X;
            }
        }

        private void CheckMouse_Click(object sender, RoutedEventArgs e)
        {
            if (checkMouse.IsChecked==true)
            {
                controlMouse = true;
            }
            else
            {
                controlMouse = false;
            }
        }
    }
}