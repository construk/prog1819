using System;

namespace App_R708_Vehiculos
{
    public enum TipoAmortiguacionBici { Competicion, Profesional, Amateur }
    class BiciMontana : Bicicleta
    {
        protected TipoAmortiguacionBici tipoAmortiguacion;
        protected string kitReparacion;
        protected double diametroRueda;

        public TipoAmortiguacionBici TipoAmortiguacion { get { return tipoAmortiguacion; } }
        public string KitReparacion { get { return kitReparacion; } }
        public double DiametroRueda { get { return diametroRueda; } }


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

        public override string ToString()
        {
            string texto = base.ToString();
            texto += string.Format("Kit reparación: {0}\nDiametro rueda: {1}", KitReparacion, DiametroRueda);
            return texto;
        }
    }
}
