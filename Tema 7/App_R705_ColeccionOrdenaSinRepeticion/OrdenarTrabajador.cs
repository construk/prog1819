using System.Collections.Generic;

namespace App_R705_ColeccionOrdenadaSinRepeticion
{
    /// <summary>
    /// Clase que encapsula a otras que permiten la ordenación de una colección de Trabajador.
    /// </summary>
    public class OrdenarTrabajador
    {
        /// <summary>
        /// Clase que permite ordenar por nombre del trabajador. Crear instancia en método Sort de la colección.
        /// </summary>
        public class OrdenarPorNombre : IComparer<Trabajador>
        {
            public int Compare(Trabajador x, Trabajador y)
            {
                int comparer;
                comparer = x.Nombre.CompareTo(y.Nombre);
                if (comparer == 0)
                {
                    comparer = x.Apellidos.CompareTo(y.Apellidos);
                    if (comparer == 0)
                    {
                        comparer = x.FechaNacimiento.CompareTo(y.FechaNacimiento);
                        if (comparer == 0)
                        {
                            comparer = x.Sueldo.CompareTo(y.Sueldo);
                            if (comparer == 0)
                            {
                                comparer = x.Codigo.CompareTo(y.Codigo);
                            }
                        }
                    }
                }
                return comparer;
            }
        }
        /// <summary>
        /// Clase que permite ordenar por apellido del trabajador. Crear instancia en método Sort de la colección.
        /// </summary>
        public class OrdenarPorApellido : IComparer<Trabajador>
        {
            public int Compare(Trabajador x, Trabajador y)
            {
                int comparer;
                comparer = x.Apellidos.CompareTo(y.Apellidos);
                if (comparer == 0)
                {
                    comparer = x.Nombre.CompareTo(y.Nombre);
                    if (comparer == 0)
                    {
                        comparer = x.FechaNacimiento.CompareTo(y.FechaNacimiento);
                        if (comparer == 0)
                        {
                            comparer = x.Sueldo.CompareTo(y.Sueldo);
                            if (comparer == 0)
                            {
                                comparer = x.Codigo.CompareTo(y.Codigo);
                            }
                        }
                    }
                }
                return comparer;
            }
        }
        /// <summary>
        /// Clase que permite ordenar por fecha de nacimiento del trabajador. Crear instancia en método Sort de la colección.
        /// </summary>
        public class OrdenarPorFechaNacimiento : IComparer<Trabajador>
        {
            public int Compare(Trabajador x, Trabajador y)
            {
                int comparer;
                comparer = x.FechaNacimiento.CompareTo(y.FechaNacimiento);
                if (comparer == 0)
                {
                    comparer = x.Nombre.CompareTo(y.Nombre);
                    if (comparer == 0)
                    {
                        comparer = x.Apellidos.CompareTo(y.Apellidos);
                        if (comparer == 0)
                        {
                            comparer = x.Sueldo.CompareTo(y.Sueldo);
                            if (comparer == 0)
                            {
                                comparer = x.Codigo.CompareTo(y.Codigo);
                            }
                        }
                    }
                }
                return comparer;
            }
        }
        /// <summary>
        /// Clase que permite ordenar por sueldo un trabajador. Crear instancia en método Sort de la colección.
        /// </summary>
        public class OrdenarPorSueldo : IComparer<Trabajador>
        {
            public int Compare(Trabajador x, Trabajador y)
            {
                int comparer;
                comparer = x.Sueldo.CompareTo(y.Sueldo);
                if (comparer == 0)
                {
                    comparer = x.Nombre.CompareTo(y.Nombre);
                    if (comparer == 0)
                    {
                        comparer = x.Apellidos.CompareTo(y.Apellidos);
                        if (comparer == 0)
                        {
                            comparer = x.FechaNacimiento.CompareTo(y.FechaNacimiento);
                            if (comparer == 0)
                            {
                                comparer = x.Codigo.CompareTo(y.Codigo);
                            }
                        }
                    }
                }
                return comparer;
            }
        }
    }
}
