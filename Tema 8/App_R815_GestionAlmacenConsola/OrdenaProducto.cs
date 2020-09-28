using System.Collections.Generic;


namespace App_R815_GestionAlmacenConsola
{
    class OrdenaProductoNombre : IComparer<Producto>
    {
        public int Compare(Producto x, Producto y)
        {
            return x.Nombre.CompareTo(y.Nombre);
        }
    }
}
