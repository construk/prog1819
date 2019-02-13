using System;

namespace App_R708_Vehiculos
{
    public abstract class Bicicleta : Vehiculo
    {
        protected DateTime fechaCompra;
        protected double precio;

        public DateTime FechaCompra { get { return fechaCompra; } }
        public double Precio { get { return precio; } }

        public override string ToString()
        {
            string texto = base.ToString();
            texto += string.Format("Fecha compra: {0}\nPrecio: {1}\n", FechaCompra.ToShortDateString(),Precio);
            return texto;
        }
    }
}
