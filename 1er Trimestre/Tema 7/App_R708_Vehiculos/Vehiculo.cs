namespace App_R708_Vehiculos { 

    public enum TipoTraccion { todoTerreno, trasera, delantera}
    public abstract class Vehiculo
    {
        protected string nombre;
        protected int numeroRuedas;
        protected string color;
        protected TipoTraccion tipoTraccion;

        public string Nombre { get { return nombre; } }
        public int NumeroRuedas { get { return numeroRuedas; } }
        public string Color { get { return color; } }
        public TipoTraccion TipoTraccion { get { return tipoTraccion; } }
        public override string ToString()
        {
            string datosComunes = "";
            datosComunes += string.Format("========================================\nDATOS COMUNES\n========================================\nNombre: {0}\nNumero ruedas: {1}\nColor: {2}\nTipo de tracción: {3}\n========================================\nDATOS ESPECÍFICOS\n========================================\n", Nombre,NumeroRuedas,Color,TipoTraccion);
            return datosComunes;
        }
    }
}
