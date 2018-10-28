/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    ValorAbsoluto
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación contiene distintas sobrecargas para obtener el valor absoluto de cualquier número.
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace Cons
{
    class Math
    {
        static void Main(string[] args)
        {
            double numero;
            string auxiliar;
            Console.WriteLine("La función ValorAbsoluto te devuelve cualquier número en valor absoluto");
            do
            {
                Console.Write("Introduce número (0 para salir): ");
                auxiliar = Console.ReadLine();
                while (!double.TryParse(auxiliar, out numero))
                {
                    Console.Write("Introduce un número válido: ");
                    auxiliar = Console.ReadLine();
                }
                if (numero!=0)
                {
                    Console.WriteLine("El valor absoluto de "+numero+" es "+ValorAbsoluto(numero));
                }
            } while (numero!=0);
        }

        //Distintas sobrecargas para el método ValorAbsoluto
        public static double ValorAbsoluto(double numero)
        {
            if (numero >= 0)
                return numero;
            else
                return -numero;
        }
        public static int ValorAbsoluto(int numero)
        {
            if (numero >= 0)
                return numero;
            else
                return -numero;
        }
        public static decimal ValorAbsoluto(decimal numero)
        {
            if (numero >= 0)
                return numero;
            else
                return -numero;
        }
        public static float ValorAbsoluto(float numero)
        {
            if (numero >= 0)
                return numero;
            else
                return -numero;
        }
        public static long ValorAbsoluto(long numero)
        {
            if (numero >= 0)
                return numero;
            else
                return -numero;
        }
        public static sbyte ValorAbsoluto(sbyte numero)
        {
            if (numero >= 0)
                return numero;
            else
                return (sbyte)-numero;
        }
        
    }
}
