using System;
using System.Diagnostics;
using System.IO;

namespace App_R813_DatosConexion
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            DateTime fechaInicio = DateTime.Now;
            string ruta = "./log.txt";
            string nombreUsuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name;          

            using (FileStream flujoFichero = new FileStream(ruta, FileMode.Append))
            using (StreamWriter escritor = new StreamWriter(flujoFichero))
            {
                escritor.Write(" Nombre de usuario: ".PadRight(20)+nombreUsuario);
                escritor.Write(" Fecha de conexión: ".PadRight(20) + fechaInicio.ToShortDateString());
                escritor.Write(" Hora de conexión: ".PadRight(20) + fechaInicio.ToShortTimeString());
                sw.Stop();
                escritor.Write(" Conexión en milisegundos: ".PadRight(20) + sw.Elapsed.TotalMilliseconds + "\r\n");
            }
        }
    }
}
