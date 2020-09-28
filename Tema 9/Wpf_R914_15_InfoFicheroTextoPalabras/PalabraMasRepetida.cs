using System.ComponentModel;

namespace Wpf_R914_15_InfoFicheroTextoPalabras
{
    class PalabrasMasRepetida: INotifyPropertyChanged
    {
        string palabra;
        int cantidad;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Palabra_Mas_Repetida
        {
            get { return palabra; }
            set
            {
                palabra = value;
                OnPropertyChanged("Palabra_Mas_Repetida");
            }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                OnPropertyChanged("Cantidad");
            }
        }
        public int Tamano { get { return Palabra_Mas_Repetida.Length; } }
        public PalabrasMasRepetida(){ Palabra_Mas_Repetida = ""; Cantidad = 0; }
        public PalabrasMasRepetida(string palabra, int cantidad)
        {
            Palabra_Mas_Repetida = palabra;
            Cantidad = cantidad;
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
