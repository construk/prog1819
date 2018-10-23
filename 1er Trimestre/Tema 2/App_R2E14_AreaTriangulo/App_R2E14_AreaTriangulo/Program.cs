/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    AreaTriangulo
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Calcular el area de un triángulo de base 8 y de altura 5.5.
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R2E14_AreaTriangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            double _base = 8;
            double _altura = 5.5;
            Console.WriteLine("El área de un triángulo de base {0} y de altura {1} es {2}", _base, _altura, _base*_altura);
            Console.ReadLine();
        }
    }
}
