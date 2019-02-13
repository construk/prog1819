using System;

namespace App_R708_Vehiculos
{
    class BiciPaseo:Bicicleta
    {
        protected int numeroCestas;
        protected string modelo;
        protected string marca;

        public int NumeroCestas { get { return numeroCestas; } }
        public string Modelo { get { return modelo; } }
        public string Marca { get { return marca; } }

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

        public override string ToString()
        {
            string texto = base.ToString();
            texto += string.Format("Número cestas: {0}\nMarca: {1}\nModelo: {2}", NumeroCestas, Marca,Modelo);
            return texto;
        }
    }
}
