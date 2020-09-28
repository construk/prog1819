using System;

namespace App_R815_GestionAlmacenConsola
{
    [Serializable]
    class Producto : IComparable<Producto>
    {
        #region Campos y constante
        const int LONGITUD_MAXIMA_NOMBRE_ART = 15;
        const int LONGITUD_MAXIMA_COMENTARIO = 50;
        int codArticulo;
        string nombre;
        double precio;
        int existencias;
        string comentario;
        bool borrado;
        #endregion
        #region Propiedades
        public int CodArticulo { get { return codArticulo; } }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Length > LONGITUD_MAXIMA_NOMBRE_ART)
                {
                    nombre = value.Substring(0, LONGITUD_MAXIMA_NOMBRE_ART);
                }
                else
                {
                    nombre = value.PadRight(LONGITUD_MAXIMA_NOMBRE_ART);
                }
            }
        }
        public double Precio
        {
            get { return precio; }
            set
            {
                if (value < 0)
                {
                    precio = 0;
                }
                else
                {
                    precio = value;
                }
            }
        }
        public double Pvp { get { return precio * 1.25; } }
        public int Existencias
        {
            get { return existencias; }
            set
            {
                if (value < 0)
                {
                    existencias = 0;
                }
                else
                {
                    existencias = value;
                }
            }
        }
        public string Comentario
        {
            get { return comentario; }
            set
            {
                if (value.Length > LONGITUD_MAXIMA_COMENTARIO)
                {
                    comentario = value.Substring(0, LONGITUD_MAXIMA_COMENTARIO);
                }
                else
                {
                    comentario = value.PadRight(LONGITUD_MAXIMA_COMENTARIO);
                }
            }
        }
        public bool Borrado { get { return borrado; } set { borrado = value; } }
        #endregion
        #region Constructor
        public Producto(int codArt, string nombre, int cantidad, double precio, string comentario)
        {
            codArticulo = codArt;
            Nombre = nombre;
            Existencias = cantidad;
            Precio = precio;
            Comentario = comentario;
            borrado = false;
        }
        public Producto()
        {
            codArticulo = -1;
            Nombre = null;
            Existencias = -1;
            Precio = -1;
            Comentario = null;
            borrado = false;
        }
        #endregion
        #region Métodos
        public int CompareTo(Producto other)
        {
            return this.codArticulo - other.codArticulo;
        }
        public override string ToString()
        {
            return codArticulo.ToString("000").PadRight(8) +
                nombre.PadRight(LONGITUD_MAXIMA_NOMBRE_ART + 1) +
                precio.ToString("#,###").PadLeft(14) +
                Pvp.ToString("#,###").PadLeft(14) +
                existencias.ToString().PadLeft(15);
        }
        public string ToLargeString()
        {
            return string.Format(
                "           PRODUCTO" + "\n" +
                "=".PadRight(79, '=') +"\n"+
                "     Nombre: " + Nombre + "\n" +
                "     Precio: " + Precio + "\n" +
                "        PVP: " + Pvp + "\n" +
                "Existencias: " + Existencias + "\n" +
                " Comentario: " + Comentario);
        }
        #endregion
    }
}
