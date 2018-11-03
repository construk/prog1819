/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Factorial Recursiva
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación haya el factorial de un número de manera recursiva.
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E12_FactorialRecursiva
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
            Console.WriteLine("Este programa calcula el factorial de cualquier número");
            try
            {
                Console.Write("Introduce un número entero no negativo: ");
                numero = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:0,0}", FactorialRecursiva(numero));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
        /// <summary>
        /// Función que calcula el factorial de un número. 
        /// </summary>
        /// <param name="numero">Numero sobre el que calcular el factorial. Si se introduce un número negativo produce FactorialNoNegativeException</param>
        /// <returns>Devuelve el factorial como double</returns>
        public static double FactorialRecursiva(double numero)
        {
            if (numero < 0)
            {
                throw new FactorialNoNegativeException();
            }
            else if (numero>170)
            {
                throw new StackOverflowException();
            }
            else if (numero <= 1)
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
