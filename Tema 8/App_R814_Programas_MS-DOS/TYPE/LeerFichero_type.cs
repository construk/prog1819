
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYPE
{
    class LeerFichero_type
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Número de argumentos inválido...");
                return;
            }
            LeerFichero(args[0]);
        }
        public static void LeerFichero(string rutaFichero)
        {
            if (File.Exists(rutaFichero))
            {
                using (FileStream flujo = new FileStream(rutaFichero, FileMode.Open))
                using (StreamReader lector = new StreamReader(flujo))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        Console.WriteLine(linea);
                    }
                }
            }
            else
            {
                Console.WriteLine("El fichero no existe...");
            }
        }
    }
}
