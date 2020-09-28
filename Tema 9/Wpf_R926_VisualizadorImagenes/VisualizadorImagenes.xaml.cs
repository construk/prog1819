using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DialogResult = System.Windows.Forms.DialogResult;
using FolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;

namespace Wpf_R926_VisualizadorImagenes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class VisualizadorImagenes : Window
    {
        public delegate void DlgRellenarVentana(List<string> imagenesRuta, int posicionImagenAbrir);
        public event DlgRellenarVentana EvtRellenarVentana;
        string[] extensionesImagenes = { ".jpg", ".jpeg", ".png", ".gif",".mp4" };
        string ruta;
        List<string> archivos;
        public VisualizadorImagenes()
        {
            InitializeComponent();
            InicializarAplicacion();
        }
        private void InicializarAplicacion()
        {
            InicializarVariables();
            RegistrarEnDiccionarioApp();
            EstablecerRutaInicial();
            this.Topmost = true;
            Focus();
            this.Activate();
            RecogerRutasImagenes();
            RellenarPanelVisualizador();
        }
        private void InicializarVariables()
        {
            ruta = "";
            archivos = new List<string>();
        }
        private void RegistrarEnDiccionarioApp()
        {
            App aplicacion = (App.Current) as App;
            aplicacion.Resources["VentanaPrincipal"] = this;
        }
        private void EstablecerRutaInicial()
        {
            FolderBrowserDialog dialogoCarpeta = new FolderBrowserDialog();
            DialogResult resultadoDialogo = dialogoCarpeta.ShowDialog();
            if (resultadoDialogo == System.Windows.Forms.DialogResult.OK)
            {
                ruta = dialogoCarpeta.SelectedPath;
                Title= "Visualizador de imagenes - "+dialogoCarpeta.SelectedPath;
            }
            else
            {
                MessageBox.Show("Debes de seleccionar una carpeta.");
                EstablecerRuta();
            }
        }
        private bool EstablecerRuta()
        {
            FolderBrowserDialog dialogoCarpeta = new FolderBrowserDialog();
            DialogResult resultadoDialogo = dialogoCarpeta.ShowDialog();
            if (resultadoDialogo == System.Windows.Forms.DialogResult.OK)
            {
                ruta = dialogoCarpeta.SelectedPath;
                Title = "Visualizador de imagenes - " + dialogoCarpeta.SelectedPath;
                return true;
            }
            return false;
        }
        private void RecogerRutasImagenes()
        {
            if (Directory.Exists(ruta))
            {
                archivos.Clear();
                DirectoryInfo directorioElegido = new DirectoryInfo(ruta);
                FileInfo[] ficheros = directorioElegido.GetFiles();
                foreach (FileInfo fichero in ficheros)
                {
                    foreach (string extension in extensionesImagenes)
                    {
                        if (fichero.Extension.Equals(extension))
                        {
                            //archivos.Add(new Uri(@fichero.FullName).AbsoluteUri);
                            archivos.Add(new Uri(@fichero.FullName).OriginalString);
                        }
                    }
                }
            }
        }
        private void RellenarPanelVisualizador()
        {
            panelVisualizacion.Children.Clear();
            MediaElement mediaImagen;
            foreach (string archivo in archivos)
            {
                mediaImagen = new MediaElement()
                {
                    Stretch = Stretch.Uniform,
                    Margin = new Thickness(5),
                    MaxHeight = 100,
                    Source = new Uri(archivo),
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
                    IsMuted = true,
                };
               
                if (archivo.Contains(".mp4"))
                {
                    mediaImagen.LoadedBehavior = MediaState.Manual;
                    mediaImagen.Pause();
                }
                else if (archivo.Contains(".gif"))
                {
                    mediaImagen.LoadedBehavior = MediaState.Manual;
                    mediaImagen.Play();
                }
                panelVisualizacion.Children.Add(mediaImagen);
            }
        }
        private void Evt_MouseDown_Imagen(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is MediaElement)
            {
                MediaElement imagen = e.Source as MediaElement;
                int posicion = archivos.IndexOf(imagen.Source.OriginalString);
                VentanaImagenGrande ventana = new VentanaImagenGrande();
                if (EvtRellenarVentana != null)
                {
                    EvtRellenarVentana(archivos, posicion);
                }
                ventana.ShowDialog();
            }
        }
        private void CambiarCarpetaOpc_Click(object sender, RoutedEventArgs e)
        {
            if (EstablecerRuta())
            {
                RecogerRutasImagenes();
                RellenarPanelVisualizador();
            }
        }
        private void Evt_PrevMouseDown_Imagen(object sender, MouseButtonEventArgs e)
        {
            this.Topmost = false;
        }
    }
}
