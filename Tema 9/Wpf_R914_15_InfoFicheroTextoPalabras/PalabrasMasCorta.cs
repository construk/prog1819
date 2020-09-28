using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_R914_15_InfoFicheroTextoPalabras
{
    class PalabrasMasCorta : INotifyPropertyChanged
    {
        string palabra;
        int linea;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Palabra_Mas_Corta
        {
            get { return palabra; }
            set
            {
                palabra = value;
                OnPropertyChanged("Palabra_Mas_Corta");
            }
        }
        public int Linea
        {
            get { return linea; }
            set
            {
                linea = value;
                OnPropertyChanged("Linea");
            }
        }
        public PalabrasMasCorta(){ Palabra_Mas_Corta = ""; Linea = 0; }
        public PalabrasMasCorta(string palabra, int cantidad)
        {
            this.palabra = palabra;
            this.linea = cantidad;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
