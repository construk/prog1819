/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    SumaNNumerosIterativa
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación calcula la suma de gauss de un número
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E15_SumaNNumerosIterativa
{
    class Program
    {
        static void Main(string[] args)
        {
            string aux;
            long numero;
            Console.WriteLine("Programa que hace la suma gaussiana");
            try { 
                do
                {
                    Console.Write("Introduce un número (0 para salir): ");
                    aux = Console.ReadLine();
                    while(!long.TryParse(aux,out numero))
                    {
                        Console.Write("Introduce un número válido: ");
                        aux=Console.ReadLine();
                    }
                    Console.WriteLine(SumaNNumerosIterativa(numero));
                } while(numero!=0);
            }catch(Exception e)
            { Console.WriteLine(e.Message); }
        }
        public static long SumaNNumerosIterativa(long sumarHasta)
        {
            long resultado = 0;
            for(int i = 1; i <= sumarHasta; i++)
            {
                resultado += i;
            }
            return resultado;
        }
    }
}
