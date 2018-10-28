/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Factorial Recursiva
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación haya el factorial de un número de manera recursiva.
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E12_FactorialRecursiva
{
    class Program
    {
        static void Main(string[] args)
        {
            double numero;
            Console.WriteLine("Este programa calcula el factorial de cualquier número");
            numero = uint.Parse(Console.ReadLine());
            Console.WriteLine("{0:0,0}", FactorialRecursiva(numero));
            Console.ReadLine();
        }

        //EL FACTORIAL MAYOR ACEPTADO CON DECIMAL ES 27, CON DOUBLE 170
        public static uint FactorialRecursiva(uint numero)
        {
            if (numero <= 1)
                return 1;
            else
                return numero * FactorialRecursiva(numero - 1);
        }
        public static ulong FactorialRecursiva(ulong numero)
        {
            if (numero <= 1)
                return 1;
            else
                return numero * FactorialRecursiva(numero - 1);
        }
        public static decimal FactorialRecursiva(decimal numero)
        {
            if (numero <= 1)
                return 1;
            else
                return numero * FactorialRecursiva(numero - 1);
        }
        public static double FactorialRecursiva(double numero)
        {
            if (numero <= 1)
                return 1;
            else
                return numero * FactorialRecursiva(numero - 1);
        }
        public static float FactorialRecursiva(float numero)
        {
            if (numero <= 1)
                return 1;
            else
                return numero * FactorialRecursiva(numero - 1);
        }
    }
}
