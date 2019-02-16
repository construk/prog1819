/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    MillaMarinaMetros
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación sirve para calcular en metros las millas marinas
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R3E19_MillaMarinaMetros
{
    class Program
    {
        static void Main(string[] args)
        {
            const double millaMarMetros = 1.852;
            double millaMarina = 0;

            Console.WriteLine("Este algoritmo transforma las millas marinas en metros");
            Console.Write("Introduce millas marinas: ");
            millaMarina = double.Parse(Console.ReadLine());
            Console.WriteLine(millaMarina+" millas marinas son "+millaMarina*millaMarMetros+" metros.");
            Console.ReadLine();
        }
    }
}
