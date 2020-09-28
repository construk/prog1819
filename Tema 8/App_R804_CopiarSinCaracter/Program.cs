using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_R804_CopiarSinCaracter
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 3)
            {
                MostrarMensajeErrorArgumentos();
                return;
            }
            try
            {
                if(args[2].Length != 1)
                {
                    MostrarMensajeErrorCaracter();
                    return;
                }
                string rutaDestino = args[0];
                string rutaOrigen = args[1];
                char caracterAIgnorar = args[2][0];
                using(FileStream archivoOrigen = new FileStream(rutaOrigen, FileMode.Open, FileAccess.Read))
                {
                    CopiarSinCaracter(archivoOrigen, caracterAIgnorar, rutaDestino);
                }
            }
            catch(Exception)
            {
                MostrarMensajeErrorArgumentos();
            }

        }
        public static void MostrarMensajeErrorArgumentos()
        {
            Console.WriteLine("El número de argumentos del programa no es válido.\nIntroduce: App_R804_CopiarSinCaracter FicheroDestino FicheroFuente Caracter");
        }
        public static void MostrarMensajeErrorCaracter()
        {
            Console.WriteLine("El tercer parámetro debe de ser un caracter.");
        }

        public static void CopiarSinCaracter(FileStream archivo, char caracterIgnorado, string rutaDestino)
        {
            int caracterLeido;
            using(StreamReader leer = new StreamReader(archivo))
            using(StreamWriter escribir = new StreamWriter(rutaDestino))
            {
                while((caracterLeido = leer.Read()) != -1)
                {
                    if((char)caracterLeido != caracterIgnorado)
                    {
                        escribir.Write((char)caracterLeido);
                    }
                }
            }
        }
    }
}
