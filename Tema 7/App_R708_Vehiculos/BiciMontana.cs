using System;

namespace App_R708_Vehiculos
{
    /// <summary>
    /// Enumeración que define los tipos de amortiguadores de Bicicletas de montaña.
    /// </summary>
    public enum TipoAmortiguacionBici { Competicion, Profesional, Amateur }
    /// <summary>
    /// Clase BiciMontana que hereda de la clase Bicicleta. Incluye tipo de amortiguador, kit de reparación y el diámetro de la rueda.
    /// </summary>
    class BiciMontana : Bicicleta
    {
        protected TipoAmortiguacionBici tipoAmortiguacion;
        protected string kitReparacion;
        protected double diametroRueda;

        /// <summary>
        /// Propiedad tipo de amortiguación bici.
        /// </summary>
        public TipoAmortiguacionBici TipoAmortiguacion { get { return tipoAmortiguacion; } }
        /// <summary>
        /// Propiedad kit de reparación bici.
        /// </summary>
        public string KitReparacion { get { return kitReparacion; } }
        /// <summary>
        /// Propiedad diametro rueda bici.
        /// </summary>
        public double DiametroRueda { get { return diametroRueda; } }

        /// <summary>
        /// Construye una bicicleta de montaña.
        /// </summary>
        /// <param name="nombre">Nombre de la bicicleta.</param>
        /// <param name="color">Color de la bicicleta.</param>
        /// <param name="tipoAmortiguacion">Tipo de amortiguador de la bicicleta.</param>
        /// <param name="kitReparacion">Kit de reparación de la bicicleta.</param>
        /// <param name="diametroRueda">Diámetro de la rueda de la bicicleta.</param>
        /// <param name="fechaCompra">Fecha de compra de la bicicleta.</param>
        /// <param name="precio">Precio de compra de la bicicleta.</param>
        public BiciMontana(string nombre, string color, TipoAmortiguacionBici tipoAmortiguacion, string kitReparacion, double diametroRueda, DateTime fechaCompra, double precio)
        {
            this.nombre = nombre;
            this.color = color;
            this.tipoTraccion = TipoTraccion.trasera;
            this.numeroRuedas = 2;
            this.tipoAmortiguacion = tipoAmortiguacion;
            this.kitReparacion = kitReparacion;
            this.diametroRueda = diametroRueda;
            this.fechaCompra = fechaCompra;
            this.precio = precio;
        }

        /// <summary>
        /// Método ToString() sobreescrito que incluya las caracteristicas de una bicicleta de montaña.
        /// </summary>
        /// <returns>Devuelve cadena de texto que representa a una bicicleta de montaña.</returns>
        public override string ToString()
        {
            string texto = base.ToString();
            texto += string.Format("Kit reparación: {0}\nDiametro rueda: {1}", KitReparacion, DiametroRueda);
            return texto;
        }
    }
}
