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
            //INTRODUCCIÓN
            Console.WriteLine("Esta aplicación calcula la media de las notas introducidas.");
            do //Hacer mientras el número introducido sea distinto de 0
            {
                //LEER DATOS
                Console.Write("Introduce una nota: ");
                auxiliar = Console.ReadLine();
                while (!double.TryParse(auxiliar, out notaLeida)||notaLeida<0)
                {
                    Console.Write("Introduce una nota válida: ");
                    auxiliar = Console.ReadLine();
                }
                //COMPROBACIONES
                if (notaLeida!=0) //SI NOTA LEIDA ES DISTINTA DE 0, SUMARLA Y AUMENTAR EL CONTADOR
                {
                    sumaNotas += notaLeida;
                    contador++;
                }
                else if (contador!=0) //SI EL CONTADOR ES DISTINTO DE 0 (SI SALE METIENDO DATOS) TE DICE LA MEDIA
                {
                    media = sumaNotas / contador;
                    Console.WriteLine("\nLa media de las {0} notas es {1:F2}", contador, media);
                }
            } while (notaLeida != 0);
            //MENSAJE FIN DE PROGRAMA
            Console.WriteLine("Pulsa ENTER para salir...");
            Console.ReadLine();
        }
    }
}
