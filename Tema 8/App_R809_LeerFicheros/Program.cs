using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_R809_LeerFicheros
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length==0)
            {
                Console.WriteLine("Debes de introducir algún parámetro.");
            }
            EscribirLinea();
            for(int i = 0; i < args.Length; i++)
            {
                LeerFichero(args[i]);
                EscribirLinea();
            }
        }
        public static void LeerFichero(string rutaFichero)
        {
            if(File.Exists(rutaFichero))
            {
                using(FileStream flujo = new FileStream(rutaFichero, FileMode.Open))
                using(StreamReader lector = new StreamReader(flujo))
                {
                    string linea;
                    while((linea = lector.ReadLine()) != null)
                    {
                        Console.WriteLine(linea);
                    }
                }
            }
        }
        public static void EscribirLinea()
        {
            Console.WriteLine("-".PadRight(Console.WindowWidth-5,'-'));
        }
    }
}
