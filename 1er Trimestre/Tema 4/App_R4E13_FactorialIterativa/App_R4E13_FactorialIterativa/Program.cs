/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Factorial Iterativa
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación haya el factorial de un número de manera iterativa.
-------------------------------------------------------------------------------------------------------------*/
using System;


namespace App_R4E13_FactorialIterativa
{
    /// <summary>
    /// Excepción producida cuando intentas realizar el factorial de un número negativo
    /// </summary>
    public class FactorialNoNegativeException : Exception
    {
        private string mensajeExcepcion = "ERROR: No se puede calcular el factorial de un número negativo";

        public override string Message
        { get { return mensajeExcepcion; } }

        public FactorialNoNegativeException()
        {
            ConsoleColor colorTexto = new ConsoleColor();
            Console.ForegroundColor = colorTexto;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Message);
            Console.ForegroundColor = colorTexto;
        }

        public FactorialNoNegativeException(string message) : base(message)
        {
            ConsoleColor colorTexto = new ConsoleColor();
            Console.ForegroundColor = colorTexto;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = colorTexto;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double numero;
            Console.WriteLine("Programa que calcula el factorial de forma iterativa");
            Console.Write("Introduce un número: ");
            try
            {
                numero = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:0,0}", FactorialIterativa(numero));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); ;
            }
            Console.ReadLine();
        }
        public static double FactorialIterativa(double numero)
        {
            double factorial = 1;
            if (numero<0)
            {
                throw new FactorialNoNegativeException();
            }
            else if (numero == 0)
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
            if (numero < 0)
            {
                throw new FactorialNoNegativeException();
            }
            else if (numero == 0)
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
            if (numero < 0)
            {
                throw new FactorialNoNegativeException();
            }
            else if (numero == 0)
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
