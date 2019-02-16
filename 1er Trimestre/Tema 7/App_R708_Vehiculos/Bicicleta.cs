using System;

namespace App_R708_Vehiculos
{
    /// <summary>
    /// Clase base para bicicletas. Incluye fecha de compra y precio. No se puede instanciar.
    /// </summary>
    public abstract class Bicicleta : Vehiculo
    {
        protected DateTime fechaCompra;
        protected double precio;

        /// <summary>
        /// Fecha de compra de la bicicleta.
        /// </summary>
        public DateTime FechaCompra { get { return fechaCompra; } }
        
        /// <summary>
        /// Precio de compra de la bicicleta.
        /// </summary>
        public double Precio { get { return precio; } }

        /// <summary>
        /// Método ToString().
        /// </summary>
        /// <returns>Devuelve cadena de texto que representa a una bicicleta.</returns>
        public override string ToString()
        {
            string texto = base.ToString();
            texto += string.Format("Fecha compra: {0}\nPrecio: {1}\n", FechaCompra.ToShortDateString(),Precio);
            return texto;
        }
    }
}
