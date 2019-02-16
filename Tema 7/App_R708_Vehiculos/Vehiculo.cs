namespace App_R708_Vehiculos { 
    /// <summary>
    /// Enumeración para definir el tipo de tracción de los vehículos.
    /// </summary>
    public enum TipoTraccion { todoTerreno, trasera, delantera}
    /// <summary>
    /// Clase base que sirve para definir los elementos comunes de todos los vehículos.
    /// </summary>
    public abstract class Vehiculo
    {
        protected string nombre;
        protected int numeroRuedas;
        protected string color;
        protected TipoTraccion tipoTraccion;

        /// <summary>
        /// Propiedad nombre
        /// </summary>
        public string Nombre { get { return nombre; } }
        /// <summary>
        /// Propiedades número de ruedas
        /// </summary>
        public int NumeroRuedas { get { return numeroRuedas; } }
        /// <summary>
        /// Propiedad color
        /// </summary>
        public string Color { get { return color; } }
        /// <summary>
        /// Propiedad tipo de tracción
        /// </summary>
        public TipoTraccion TipoTraccion { get { return tipoTraccion; } }
        /// <summary>
        /// Método ToString()
        /// </summary>
        /// <returns>Devuelve cadena de texto que representa a un vehículo.</returns>
        public override string ToString()
        {
            string datosComunes = "";
            datosComunes += string.Format("========================================\nDATOS COMUNES\n========================================\nNombre: {0}\nNumero ruedas: {1}\nColor: {2}\nTipo de tracción: {3}\n========================================\nDATOS ESPECÍFICOS\n========================================\n", Nombre,NumeroRuedas,Color,TipoTraccion);
            return datosComunes;
        }
    }
}
