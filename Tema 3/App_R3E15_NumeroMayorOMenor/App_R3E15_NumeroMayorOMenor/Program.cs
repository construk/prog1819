/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    NumeroMayorOMenor
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación compara dos números, si el primero es mayor que el segundo muestra verdadero en caso contrario escribe falso
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R3E15_NumeroMayorOMenor
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            double y;
            Console.WriteLine("Programa que compara dos número y devuelve verdadero si el primero es mayor que el segundo");
            Console.Write("Introduce el primer valor: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("Introduce el segundo valor: ");
            y = double.Parse(Console.ReadLine());
            if (x>y)
                Console.WriteLine("Verdadero");
            else
                Console.WriteLine("Falso");
            Console.ReadLine();
        }
    }
}
