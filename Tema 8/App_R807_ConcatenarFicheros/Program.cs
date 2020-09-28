using System;
using System.IO;


namespace App_R807_ConcatenarFicheros
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length!=2)
            {
                Console.WriteLine(" Necesitas dos parámetros:\n ficheroAAñadirAlFinal ficheroLeidoQueSeAñade");
                return;
            }
            
                ConcatenaFichero(args[0], args[1]);
            }
            catch(Exception e)
            { Console.WriteLine(e.Message); }
            finally { Console.ReadLine(); }
        }
        public static void ConcatenaFichero(string rutaFichero1, string rutaFichero2)
        {
            if (!File.Exists(rutaFichero1) || !File.Exists(rutaFichero2))
            {
                Console.WriteLine("El fichero 1 o 2 no existe.");
                return;
            }
            using (FileStream archivoLeido = new FileStream(rutaFichero2, FileMode.Open))
            using (FileStream archivoEscrito = new FileStream(rutaFichero1, FileMode.Append))
            using (StreamReader lector = new StreamReader(archivoLeido))
            using (StreamWriter escritor = new StreamWriter(archivoEscrito))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    escritor.WriteLine(linea);
                }
            }
        }
    }
}
