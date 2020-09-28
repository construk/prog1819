using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_R914_15_InfoFicheroTextoPalabras
{
    class PalabrasMasLarga: INotifyPropertyChanged
    {
        string palabra;
        int linea;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Palabra_Mas_Larga
        {
            get { return palabra; }
            set
            {
                palabra = value;
                OnPropertyChanged("Palabra_Mas_Larga");
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
        public PalabrasMasLarga(){ Palabra_Mas_Larga = ""; Linea = 0; }
        public PalabrasMasLarga(string palabra, int cantidad)
        {
            Palabra_Mas_Larga = palabra;
            Linea = cantidad;
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
