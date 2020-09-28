using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace App_R803_CopiaFicheroConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length!=2)
            {
                Console.WriteLine("El comando usado no es válido. Para usar correctamente dicho comando debe de usar:\n"+
                    "comando RUTA_ORIGEN RUTA_DESTINO");
            }
            else
            {
                File.Copy(args[0], args[1]);
            }
        }
    }
}
