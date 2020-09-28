using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace App_R801_Path
{
    class Ejercicio1
    {
        static void Main(string[] args)
        {
            string ruta = @"c:/basura/basura1/basura2/basura3/texto.txt";
            InfoAcceso(ruta);
            Console.ReadLine();
        }
        public static void InfoAcceso(string ruta)
        {
            Console.WriteLine("    Directorio: "+Path.GetDirectoryName(ruta));
            Console.WriteLine("Nombre fichero: "+Path.GetFileName(ruta));
            Console.WriteLine("     Extensión: "+Path.GetExtension(ruta));
            Console.WriteLine(" Ruta completa: "+Path.GetFullPath(ruta));
        }
    }
}
