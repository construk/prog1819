/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    SumaNNumerosRecursiva
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación haya la suma de los N números introducidos.
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E14_SumaNNumerosRecursiva
{
    class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            int numero;
            string aux;
            
            //INTRODUCCIÓN Y ENTRADA DE DATOS
            Console.WriteLine("Este programa calcula la suma de gauss del número introducido");
            Console.Write("Introduce un número: ");
            aux = Console.ReadLine();
            while (!int.TryParse(aux, out numero))
            {
                Console.Write("Introduce un número válido: ");
                aux = Console.ReadLine();
            }

            //RESULTADO
            Console.WriteLine(SumaNNumeros(numero));
            Console.ReadLine();
        }
        /// <summary>
        /// Función que devuelve la suma de gauss de un número introducido
        /// </summary>
        /// <param name="nNumeros">El número de gauss a calcular</param>
        /// <returns>devuelve el número de gauus</returns>
        public static long SumaNNumeros(long nNumeros)
        {
            if (nNumeros < 1)
            {
                return 0;
            }
            else if (nNumeros < 2)
            {
                return 1;
            }
            else
                return nNumeros + SumaNNumeros(nNumeros - 1);
        }
    }
}
