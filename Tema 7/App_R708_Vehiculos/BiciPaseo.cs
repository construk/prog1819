using System;

namespace App_R708_Vehiculos
{
    /// <summary>
    /// Clase Bici de paseo que hereda de Bicicleta. Incluye: nº cestas, modelo y marca.
    /// </summary>
    class BiciPaseo:Bicicleta
    {
        protected int numeroCestas;
        protected string modelo;
        protected string marca;

        /// <summary>
        /// Número de cestas que tiene la bici.
        /// </summary>
        public int NumeroCestas { get { return numeroCestas; } }
        /// <summary>
        /// Modelo de la bicicleta.
        /// </summary>
        public string Modelo { get { return modelo; } }
        /// <summary>
        /// Marca de la bicicleta.
        /// </summary>
        public string Marca { get { return marca; } }

        /// <summary>
        /// Construye una bicicleta con cesta.
        /// </summary>
        /// <param name="nombre">Nombre de la bicicleta.</param>
        /// <param name="color">Color de la bicicleta.</param>
        /// <param name="numeroCestas">Número de cestas de la bicicleta.</param>
        /// <param name="modelo">Modelo de la bicicleta.</param>
        /// <param name="marca">Marca de la bicicleta.</param>
        /// <param name="fechaCompra">Fecha de compra de la bicicleta.</param>
        /// <param name="precio">Precio de compra de la bicicleta.</param>
        public BiciPaseo(string nombre, string color, int numeroCestas, string modelo, string marca,DateTime fechaCompra, double precio)
        {
            this.nombre = nombre;
            this.color = color;
            this.tipoTraccion = TipoTraccion.trasera;
            this.numeroRuedas = 2;
            this.numeroCestas = numeroCestas;
            this.modelo = modelo;
            this.marca = marca;
            this.fechaCompra = fechaCompra;
            this.precio = precio;
        }

        /// <summary>
        /// Método ToString().
        /// </summary>
        /// <returns>Devuelve cadena de texto que representa a una bicicleta con cesta.</returns>
        public override string ToString()
        {
            string texto = base.ToString();
            texto += string.Format("Número cestas: {0}\nMarca: {1}\nModelo: {2}", NumeroCestas, Marca,Modelo);
            return texto;
        }
    }
}
