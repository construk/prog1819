using System;
using System.IO;
using System.Linq;

namespace COPY
{
    class Copiar_copy
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                try
                {
                    if (args[1].Contains('"')) ;
                    {
                        args[1] = args[1].Replace("\"", "");
                    }
                    if (File.Exists(args[0]))
                    {
                        File.Copy(args[0], args[1]);
                    }
                    else if (!File.Exists(args[0]))
                    {
                        Console.WriteLine("El fichero a copiar no existe...");
                    }

                }
                catch
                {
                    try
                    {
                        if (File.Exists(args[0]))
                        {
                            File.Copy(args[0], args[1] + @"\" + new FileInfo(args[0]).Name);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("La ruta de destino no es válida...");
                    }
                }
            }
            else
            {
                Console.WriteLine("El número de argumentos no es válido...");
            }
        }
    }
}