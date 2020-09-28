using System;

namespace App_R808_CreaListaFicheroAlumno
{
    [Serializable]
    internal class Alumno
    {
        string nombre;
        string apellido;

        public Alumno(string apellido, string nombre)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public override string ToString()
        {
            return apellido.PadRight(30) + nombre.PadRight(30);
        }
    }
}