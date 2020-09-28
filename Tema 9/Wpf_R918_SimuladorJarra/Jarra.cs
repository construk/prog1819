using System.ComponentModel;

namespace Wpf_R918_SimuladorJarra
{
    class Jarra : INotifyPropertyChanged
    {
        int capacidad;
        int cantidad;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Texto { get { return ToString(); } }
        public int Capacidad
        {
            get { return capacidad; }
            set
            {
                if (value < 0)
                {
                    capacidad = 0;
                }
                else
                {
                    capacidad = value;
                }
                OnPropertyChanged("Capacidad");
                OnPropertyChanged("Texto");
            }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value;
                OnPropertyChanged("Texto");
                OnPropertyChanged("Cantidad");
            }
            
    }
        public Jarra()
        { Capacidad = 0;Cantidad = 0; }
        public void Llenar() { cantidad = Capacidad; OnPropertyChanged("Cantidad"); OnPropertyChanged("Texto"); }
        public void Vaciar() { cantidad = 0; OnPropertyChanged("Cantidad"); OnPropertyChanged("Texto"); }
        public void LlenarDesdeJarra(Jarra jarra)
        {
            int capacidadDisponible = Capacidad - Cantidad;
            int contenidodOtraJarra = jarra.Cantidad;
            if (capacidadDisponible >= contenidodOtraJarra)
            {
                Cantidad += contenidodOtraJarra;
                jarra.Cantidad -= contenidodOtraJarra;
            }
            else
            {
                Cantidad += capacidadDisponible;
                jarra.Cantidad -= capacidadDisponible;
            }
            /*OnPropertyChanged("Cantidad");
            OnPropertyChanged("Texto");
            OnPropertyChanged("jarra.Cantidad");
        */}
        public override string ToString()
        {
            return string.Format("{0}/{1}", Cantidad, Capacidad);
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
