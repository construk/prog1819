/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    MediaNotas
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación sirve para calcular la media de las notas introducidas
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R3E20_MediaNotas
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero=0;
            int contador=0;
            int numeroLeido;
            do
            {
                Console.Write("Introduce número (0 para salir): ");
                numeroLeido = int.Parse(Console.ReadLine());
                if (numeroLeido!=0)
                {
                    numero += numeroLeido;
                    contador++;
                }
            } while (numeroLeido!=0);

            Console.WriteLine("La media de las "+contador+" notas es {0:F2}",(double)numero/contador);
            Console.ReadLine();
        }
    }
}
