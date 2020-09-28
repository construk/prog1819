using System;
using System.IO;

//NOTA: No he usado las funciones de los ejercicios anteriores para hacerlo de otra forma e innovar algo
namespace App_R811_LeerTecladoGuardarMostrar
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Encabezado
                Console.Write("Guarda en un fichero todo lo que escribas por pantalla y luego lo muestra. ");
                Console.WriteLine("Para salir introduce una linea vacia: ");
                Console.WriteLine("=".PadRight(Console.WindowWidth - 1, '='));

                //Escribiendo desde teclado en fichero.txt desde el final, si no existe lo crea
                using (FileStream flujo = new FileStream("./fichero.txt", FileMode.Append))
                using (StreamWriter lectorTeclado = new StreamWriter(flujo))
                {
                    TextWriter consola = Console.Out;       //Guardando el flujo de la consola.
                    Console.SetOut(lectorTeclado);          //Cambiando el flujo de la consola hacia el fichero.
                    string lineaLeida;
                    do
                    {
                        lineaLeida = Console.ReadLine();    //Lee por teclado
                        Console.WriteLine(lineaLeida);      //Escribe en fichero
                    } while (!lineaLeida.Equals(""));

                    Console.SetOut(consola);                //Reestableciendo el flujo de la consola
                }

                //Leyendo fichero.txt y mostrándolo por pantalla
                Console.WriteLine("Ahora se mostrará todo lo escrito en el fichero: \n");

                using (FileStream flujo = new FileStream("./fichero.txt", FileMode.OpenOrCreate))
                using (StreamReader lectorFichero = new StreamReader(flujo))
                {
                    string linea;
                    TextReader consola = Console.In;
                    Console.SetIn(lectorFichero);

                    while ((linea = Console.ReadLine()) != null)  //Mostrar todas la líneas del fichero
                    {
                        Console.WriteLine(linea);
                    }
                    Console.SetIn(consola);
                }
            }
            catch
            {
                Console.WriteLine("Excepción no controlada.");
            }
        }
    }
}
