/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Factorial Iterativa
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación haya el factorial de un número de manera iterativa.
-------------------------------------------------------------------------------------------------------------*/
using System;


namespace App_R4E13_FactorialIterativa
{
    class Program
    {
        static void Main(string[] args)
        {
            double numero;

            Console.Write("Introduce un número:");
            numero = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:0,0}", FactorialIterativa(numero));
            Console.ReadLine();
        }
        public static double FactorialIterativa(double numero)
        {
            double factorial = 1;
            if (numero == 0)
            {
                return 1;
            }
            else
            {
                for (int i = 1; i <= numero; i++)
                {
                    factorial *= i;
                }
                return factorial;
            }
        }
        public static decimal FactorialIterativa(decimal numero)
        {
            decimal factorial = 1;
            if (numero == 0)
            {
                return 1;
            }
            else
            {
                for (int i = 1; i <= numero; i++)
                {
                    factorial *= i;
                }
                return factorial;
            }
        }
        public static long FactorialIterativa(long numero)
        {
            long factorial = 1;
            if (numero == 0)
            {
                return 1;
            }
            else
            {
                for (int i = 1; i <= numero; i++)
                {
                    factorial *= i;
                }
                return factorial;
            }
        }
        public static float FactorialIterativa(float numero)
        {
            float factorial = 1;
            if (numero == 0)
            {
                return 1;
            }
            else
            {
                for (int i = 1; i <= numero; i++)
                {
                    factorial *= i;
                }
                return factorial;
            }
        }
    }
}
