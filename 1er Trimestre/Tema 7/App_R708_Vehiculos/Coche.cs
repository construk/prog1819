namespace App_R708_Vehiculos
{
    public enum EstadoCoche { marchando, parado };
    class Coche : Vehiculo
    {
        protected int velocidadMaxima;
        protected EstadoCoche estado;

        public int VelocidadMaxima { get { return velocidadMaxima; } }
        public EstadoCoche Estado { get { return estado; } set { estado = value; } }

        public Coche(string nombre, string color, TipoTraccion tipoTraccion, int velocidadMaxima, EstadoCoche estadoCoche)
        {
            this.nombre = nombre;
            this.color = color;
            this.tipoTraccion = tipoTraccion;
            this.numeroRuedas = 4;
            this.velocidadMaxima = velocidadMaxima;
            this.estado = estadoCoche;
        }

        public void CambiarEstadoCoche(EstadoCoche estado)
        {
            this.estado = estado;
        }
        public override string ToString()
        {
            string texto = base.ToString();
            texto += string.Format("Velocidad máxima: {0}\nEstado: {1}", VelocidadMaxima, Estado);
            return texto;
        }
    }
}
