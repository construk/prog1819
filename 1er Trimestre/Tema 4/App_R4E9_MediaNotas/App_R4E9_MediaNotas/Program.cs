/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Media Notas
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación calcula la media de las notas introducidas.
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E9_MediaNotas
{
    class Program
    {
        static void Main(string[] args)
        {
            double notaLeida;
            double sumaNotas = 0;
            int contador = 0;
            string auxiliar;
            double media;

            Console.WriteLine("Esta aplicación calcula la media de las notas introducidas.");
            do
            {
                Console.Write("Introduce una nota: ");
                auxiliar = Console.ReadLine();
                while (!double.TryParse(auxiliar, out notaLeida))
                {
                    Console.Write("Introduce una nota válida: ");
                    auxiliar = Console.ReadLine();
                }
                if (notaLeida!=0)
                {
                    sumaNotas += notaLeida;
                    contador++;
                }
            } while (notaLeida != 0);

            media = sumaNotas / contador;
            Console.WriteLine("\nLa media de las {0} notas es {1:F2}",contador,media);
            Console.ReadLine();
        }
    }
}
