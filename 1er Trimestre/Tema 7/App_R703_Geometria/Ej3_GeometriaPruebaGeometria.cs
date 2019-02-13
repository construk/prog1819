/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		Geometria y PruebaGeometria
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 ene 2019
 *  Descripción:	Proyecto con las clases Punto y Cuadrado
-------------------------------------------------------------------------------------------------------------*/
using System;
using Geometria;

namespace PruebaGeometria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Cuadrado cuadrado = new Cuadrado(new Punto(0, 0), new Punto(Console.WindowHeight - 1, Console.WindowHeight-1));
            cuadrado.Pinta();
            Console.WriteLine();
            Console.WriteLine(cuadrado.ToString());
            Console.ReadLine();
        }
    }
}
