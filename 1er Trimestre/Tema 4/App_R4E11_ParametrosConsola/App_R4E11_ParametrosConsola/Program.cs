/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    ParametrosConsola
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación escribe en pantalla todos los parametros introducidos por consola.
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E11_ParametrosConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)       //BUCLE QUE RECORRE TODOS LOS ARGUMENTOS INTRODUCIDOS POR CONSOLA
            {
                Console.WriteLine(args[i]);
            }
            Console.ReadLine();
        }
    }
}
