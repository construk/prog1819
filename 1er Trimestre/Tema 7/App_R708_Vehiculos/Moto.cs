namespace App_R708_Vehiculos
{
    public enum TipoCombustibleMoto { mezcla, normal };
    class Moto : Vehiculo
    {
        protected TipoCombustibleMoto tipoCombustible;
        protected int potenciaCV;

        public int PotenciaCV { get { return potenciaCV; } set { potenciaCV = value; } }
        public TipoCombustibleMoto TipoCombustible { get { return tipoCombustible; } }

        public Moto(string nombre, string color, TipoCombustibleMoto tipoCombustible, int potenciaCV)
        {
            this.nombre = nombre;
            this.color = color;
            this.tipoCombustible = tipoCombustible;
            this.tipoTraccion = TipoTraccion.trasera;
            this.numeroRuedas = 2;
            this.PotenciaCV = potenciaCV;
        }

        public override string ToString()
        {
            string texto = base.ToString();
            texto += string.Format("Potencia (CV): {0}\nTipo combustible: {1}", PotenciaCV, TipoCombustible);
            return texto;
        }
    }
}
