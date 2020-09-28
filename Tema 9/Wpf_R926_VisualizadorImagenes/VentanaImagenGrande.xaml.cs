using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Wpf_R926_VisualizadorImagenes
{
    /// <summary>
    /// Lógica de interacción para VentanaImagenGrande.xaml
    /// </summary>
    public partial class VentanaImagenGrande : Window
    {
        Button botonVisualizado;
        int posicion;
        List<string> rutaImagenes;

        private int Posicion
        {
            get { return posicion; }
            set
            {
                if (value<0)
                {
                    posicion = 0;
                }
                else if (value>=rutaImagenes.Count)
                {
                    posicion = rutaImagenes.Count - 1;
                }
                else
                {
                    posicion = value;
                }
            }
        }

        public VentanaImagenGrande()
        {
            InitializeComponent();
            App aplicacion = App.Current as App;
            ((VisualizadorImagenes)(aplicacion.Resources["VentanaPrincipal"])).EvtRellenarVentana += EvtRellenarVentana;
            InicializarVariables();
        }

        private void InicializarVariables()
        {
            rutaImagenes = new List<string>();
            posicion = 0;
        } 
        private void MoverIzquierda()
        {
            Posicion--;
            imagenMostrada.Source = new Uri(rutaImagenes[Posicion]);
            Title = Path.GetFileName(rutaImagenes[Posicion]);
            if (Posicion == 0)
            {
                btnHaciaAtras.Visibility = Visibility.Hidden;
            }
            else if (Posicion != (rutaImagenes.Count - 1))
            {
                btnHaciaDelante.Visibility = Visibility.Visible;
                btnHaciaAtras.Visibility = Visibility.Visible;
            }
        }
        private void MoverDerecha()
        {
            Posicion++;
            imagenMostrada.Source = new Uri(rutaImagenes[Posicion]);
            Title = Path.GetFileName(rutaImagenes[Posicion]);
            if (Posicion == (rutaImagenes.Count - 1))
            {
                btnHaciaDelante.Visibility = Visibility.Hidden;
            }
            else if (Posicion != 0)
            {
                btnHaciaDelante.Visibility = Visibility.Visible;
                btnHaciaAtras.Visibility = Visibility.Visible;
            }
        }

        private void EvtRellenarVentana(List<string> imagenesRuta, int posicionImagenAbrir)
        {
            rutaImagenes.AddRange(imagenesRuta);
            Posicion = posicionImagenAbrir;
            imagenMostrada.Source = new Uri(rutaImagenes[Posicion]);
            Title = Path.GetFileName(rutaImagenes[Posicion]);
            if (Posicion == (rutaImagenes.Count - 1))
            {
                btnHaciaDelante.Visibility = Visibility.Hidden;
            }
            else if (Posicion == 0)
            {
                btnHaciaAtras.Visibility = Visibility.Hidden;
            }
        }
        private void MouseMove_VisualizarCambiarImagen(object sender, MouseEventArgs e)
        {
            if (e.Source is Button) //Si es un botón donde está posado el ratón
            {
                botonVisualizado = e.Source as Button;
                botonVisualizado.Background = new SolidColorBrush(Color.FromArgb(90, 34, 34, 34));
                botonVisualizado.Foreground = new SolidColorBrush(Color.FromArgb(153, 34, 34, 34));
            }
            else    //Si no es un botón donde está posado el botón comprueba si ya se ha mostrado, y si es así lo oculta
            {
                if (!(botonVisualizado is null)) //Si se ha mostrado algun botón lo oculta
                {
                    botonVisualizado.Background = new SolidColorBrush(Color.FromArgb(00, 34, 34, 34));
                    botonVisualizado.Foreground = new SolidColorBrush(Color.FromArgb(00, 34, 34, 34));
                    botonVisualizado = null;
                }
            }
        }
        private void Click_DelanteAtras(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Name.Equals("btnHaciaAtras"))
            {
                MoverIzquierda();
            }
            else
            {
                MoverDerecha();   
            }
        }
        private void KeyDown_IzqDer(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Left)
            {
                MoverIzquierda();
            }
            else if(e.Key==Key.Right)
            {
                MoverDerecha();
            }
        }
    }
}
