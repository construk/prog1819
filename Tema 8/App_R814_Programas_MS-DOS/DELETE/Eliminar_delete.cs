using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DELETE
{
    class Eliminar_delete
    {
        static void Main(string[] args)
        {
            if (args.Length!=1)
            {
                Console.WriteLine("El número de argumentos no es válido...");
                return;
            }

            if (File.Exists(args[0]))
            {
                File.Delete(args[0]);
            }
            else
            {
                Console.WriteLine("El fichero especificado no existe...");
            }

        }
    }
}
