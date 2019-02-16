namespace App_R708_Vehiculos
{
    /// <summary>
    /// Enumeración para comprobar el estado del Coche
    /// </summary>
    public enum EstadoCoche { marchando, parado };
    /// <summary>
    /// Clase Coche que hereda de Vehículo. Incluye velocidadMaxima y estado, y CambiarEstadoCoche(). Además de sobreescribir el método ToString() para incluir demás información.
    /// </summary>
    class Coche : Vehiculo
    {
        protected int velocidadMaxima;
        protected EstadoCoche estado;

        /// <summary>
        /// Propiedad velocidad máxima
        /// </summary>
        public int VelocidadMaxima { get { return velocidadMaxima; } }
        /// <summary>
        /// Propiedad estado del coche (marchando o parado).
        /// </summary>
        public EstadoCoche Estado { get { return estado; } set { estado = value; } }
        
        /// <summary>
        /// Constructor de coche.
        /// </summary>
        /// <param name="nombre">Nombre del coche</param>
        /// <param name="color">Color del coche</param>
        /// <param name="tipoTraccion">Tipo de tracción</param>
        /// <param name="velocidadMaxima">Velocidad máxima del coche</param>
        /// <param name="estadoCoche">Estado actual del coche</param>
        public Coche(string nombre, string color, TipoTraccion tipoTraccion, int velocidadMaxima, EstadoCoche estadoCoche)
        {
            this.nombre = nombre;
            this.color = color;
            this.tipoTraccion = tipoTraccion;
            this.numeroRuedas = 4;
            this.velocidadMaxima = velocidadMaxima;
            this.estado = estadoCoche;
        }

        /// <summary>
        /// Cambia el estado del coche al que le indiques.
        /// </summary>
        /// <param name="estado">Estado al que deseas cambiar el estado del coche.</param>
        public void CambiarEstadoCoche(EstadoCoche estado)
        {
            this.estado = estado;
        }

        /// <summary>
        /// Método ToString() sobreescrito para incluir la información del coche.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string texto = base.ToString();
            texto += string.Format("Velocidad máxima: {0}\nEstado: {1}", VelocidadMaxima, Estado);
            return texto;
        }
    }
}
