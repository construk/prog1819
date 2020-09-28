using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;

namespace Wpf_R914_15_InfoFicheroTextoPalabras
{
    class FileInfoWordsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        const string MENSAJE_ARCHIVO_CARGADO_OK = "Fichero cargado correctamente.";
        const string MENSAJE_ARCHIVO_CARGADO_MAL = "Error al cargar el fichero.";
        FileInfoWords gestorFichero;
        string estado;

        public List<PalabrasMasCorta> PalabrasMasCortas { get { return gestorFichero.PalabrasMasCortas; } }
        public List<PalabrasMasLarga> PalabrasMasLargas { get { return gestorFichero.PalabrasMasLargas; } }
        public List<PalabrasMasRepetida> PalabrasMasRepetidas { get { return gestorFichero.PalabrasMasRepetidas; } }
        public List<string> PalabrasMenosRepetidas { get { return gestorFichero.PalabrasMenosRepetidas; } }
        public List<string> Palindromas { get { return gestorFichero.Palindromas; } }
        public string Ruta { get { return gestorFichero.Ruta; } set { gestorFichero.Ruta = value; } }
        public int TotalPalabras { get { return gestorFichero.TotalPalabras; } }
        public int TotalLineas { get { return gestorFichero.TotalLineas; } }
        public string TamanoArchivo { get { return gestorFichero.TamanoArchivo; } }
        public string Atributos { get { return gestorFichero.Atributos; } }
        public string Estado { get { return estado; } set { estado = value; } }
        public FileInfoWordsVM()
        {
            gestorFichero = new FileInfoWords();
            Ruta = SeleccionarRuta();
            try
            {
                gestorFichero.LeerDocumento();
                Estado = MENSAJE_ARCHIVO_CARGADO_OK;
                ActualizarVistas();
            }
            catch
            {
                Estado = MENSAJE_ARCHIVO_CARGADO_MAL;
                ActualizarVistas();
            }
        }
        private string SeleccionarRuta()
        {
            OpenFileDialog elegirRuta = new OpenFileDialog();
            bool? resultadoVentana = false;

            while (resultadoVentana != true)
            {
                resultadoVentana = elegirRuta.ShowDialog();
            }
            return elegirRuta.FileName;
        }
        protected void OnPropertyChanged(string propiedad)
        {
            PropertyChangedEventHandler dlgEvento = this.PropertyChanged;
            if (dlgEvento != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propiedad);
                dlgEvento(this, e);
            }
        }
        private void ActualizarVistas()
        {
            OnPropertyChanged("PalabrasMasCortas");
            OnPropertyChanged("PalabrasMasLargas");
            OnPropertyChanged("PalabrasMasRepetidas");
            OnPropertyChanged("PalabrasMenosRepetidas");
            OnPropertyChanged("Palindromas");
            OnPropertyChanged("Ruta");
            OnPropertyChanged("TotalPalabras");
            OnPropertyChanged("Estado");
        }
    }
}