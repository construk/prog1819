using System;

namespace App_R705_ColeccionOrdenadaSinRepeticion
{
    /// <summary>
    /// Clase trabajador que contiene código, apellidos, nombre, fecha de nacimiento y sueldo.
    /// </summary>
    public class Trabajador:IComparable<Trabajador>
    {
        #region Campos
        int codigo;
        string apellidos;
        string nombre;
        DateTime fechaNacimiento;
        double sueldo;
        #endregion
        #region Propiedades
        /// <summary>
        /// Código del trabajador.
        /// </summary>
        public int Codigo { get { return codigo; } set { codigo = value; } }
        /// <summary>
        /// Apellido del trabajador
        /// </summary>
        public string Apellidos { get { return apellidos; } set { apellidos = value; } }
        /// <summary>
        /// Nombre del trabajador.
        /// </summary>
        public string Nombre { get { return nombre; } set { nombre = value; } }
        /// <summary>
        /// Fecha de nacimiento del trabajador.
        /// </summary>
        public DateTime FechaNacimiento { get { return fechaNacimiento; } set { fechaNacimiento = value; } }
        /// <summary>
        /// Sueldo del trabajador.
        /// </summary>
        public double Sueldo
        {
            get { return sueldo; }
            set
            {
                if (value < 0)
                {
                    sueldo = 0;
                }
                else
                {
                    sueldo = value;
                }
            }
        }
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor de un trabajador si datos y con código 0.
        /// </summary>
        public Trabajador()
        {
            codigo = 0;
            apellidos = "";
            nombre = "";
            fechaNacimiento = new DateTime();
            sueldo = 0;
        }
        /// <summary>
        /// Construir trabajador con código, apellidos, nombre, fecha de nacimiento y sueldo.
        /// </summary>
        /// <param name="codigo">Código del trabajador, debe de ser único.</param>
        /// <param name="apellidos">Apellidos del trabajador.</param>
        /// <param name="nombre">Nombre del trabajador.</param>
        /// <param name="fechaNacimiento">Fecha de nacimiento del trabajador.</param>
        /// <param name="sueldo">Sueldo del trabajador.</param>
        public Trabajador(int codigo, string apellidos, string nombre, DateTime fechaNacimiento, double sueldo)
        {
            this.codigo = codigo;
            this.apellidos = apellidos;
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
            Sueldo = sueldo;
        }
        #endregion
        #region Métodos
        /// <summary>
        /// ToString preparado con PadRight para listar.(10,30,30,20).
        /// </summary>
        /// <returns>Cadena de texto formateada con espacios entre los datos para mostrarlos alineadamente.</returns>
        public override string ToString()
        {
            return codigo.ToString().PadRight(10) + apellidos.PadRight(30) + nombre.PadRight(30) + fechaNacimiento.ToShortDateString().PadRight(20) + sueldo.ToString();
        }
        /// <summary>
        /// Sirve para comparar trabajadores.
        /// </summary>
        /// <param name="other">Trabajador sobre el que se compara la instancia actual.</param>
        /// <returns>Devuelve 0 si son iguales y un número positivo o negativo en caso contrario.</returns>
        public int CompareTo(Trabajador other)
        {
            int compare;
            compare = this.codigo-other.codigo;
            if (compare==0)
            {
                compare = this.apellidos.CompareTo(other.apellidos);
                if (compare==0)
                {
                    compare = this.nombre.CompareTo(other.nombre);
                    if (compare==0)
                    {
                        compare = this.fechaNacimiento.CompareTo(other.fechaNacimiento);
                        if (compare==0)
                        {
                            compare = sueldo.CompareTo(other.sueldo);
                        }
                    }
                }
            }
            return compare;
        }
        #endregion
    }
}