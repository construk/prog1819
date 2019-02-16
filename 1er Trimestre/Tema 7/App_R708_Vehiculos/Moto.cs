namespace App_R708_Vehiculos
{
    /// <summary>
    /// Enumeración que sirve para indicar el tipo de combustible de una moto.
    /// </summary>
    public enum TipoCombustibleMoto { mezcla, normal };
    /// <summary>
    /// Clase moto que hereda de la clase vehículo. Incluye tipo de combustible y la potencia en Caballos de vapor (CV).
    /// </summary>
    class Moto : Vehiculo
    {
        protected TipoCombustibleMoto tipoCombustible;
        protected int potenciaCV;

        /// <summary>
        /// Potencia en CV de la moto.
        /// </summary>
        public int PotenciaCV { get { return potenciaCV; } set { potenciaCV = value; } }
        /// <summary>
        /// Tipo de combustible usado por la moto (mezcla, normal).
        /// </summary>
        public TipoCombustibleMoto TipoCombustible { get { return tipoCombustible; } }

        /// <summary>
        /// Construye una moto.
        /// </summary>
        /// <param name="nombre">Nombre de la moto.</param>
        /// <param name="color">Color de la moto.</param>
        /// <param name="tipoCombustible">Tipo de combustible de la moto (mezcla o normal).</param>
        /// <param name="potenciaCV">Potencia en CV de la moto.</param>
        public Moto(string nombre, string color, TipoCombustibleMoto tipoCombustible, int potenciaCV)
        {
            this.nombre = nombre;
            this.color = color;
            this.tipoCombustible = tipoCombustible;
            this.tipoTraccion = TipoTraccion.trasera;
            this.numeroRuedas = 2;
            this.PotenciaCV = potenciaCV;
        }

        /// <summary>
        /// Método ToString()
        /// </summary>
        /// <returns>Devuelve cadena de texto con las caracteristicas de una moto.</returns>
        public override string ToString()
        {
            string texto = base.ToString();
            texto += string.Format("Potencia (CV): {0}\nTipo combustible: {1}", PotenciaCV, TipoCombustible);
            return texto;
        }
    }
}
