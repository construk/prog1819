using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace App_R805_LeeFichero
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if(args.Length != 1)
                {
                    MensajeErrorArgumentos();
                    return;
                }
                if(File.Exists(args[0]))
                {
                    FileStream fichero = new FileStream(args[0], FileMode.Open);
                    StreamReader lector = new StreamReader(fichero);
                    string linea;
                    while((linea = lector.ReadLine()) != null)
                    {
                        Console.WriteLine(linea);
                    }
                }
                else
                {
                    ConsoleColor colorDefecto = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El fichero introducido no existe...");
                    Console.ForegroundColor = colorDefecto;
                    return;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void MensajeErrorArgumentos()
        {
            ConsoleColor colorDefecto = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("El número de argumentos no es válido, pruebe con: \n" + System.AppDomain.CurrentDomain.FriendlyName + @" [Unidad:\Ruta\]Fichero_de_Texto");
            Console.ForegroundColor = colorDefecto;
        }
    }
}
