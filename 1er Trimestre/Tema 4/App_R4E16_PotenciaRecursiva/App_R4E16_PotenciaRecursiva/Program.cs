/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    PotenciaRecursiva
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación calcula la potencia de un número de forma recursiva
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E16_PotenciaRecursiva
{
    class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            int numero;
            int exponente;
            string aux;
            
            //INTRODUCCIÓN
            Console.WriteLine("Programa que calcula la potencia de un número");
            
            //LEER DATOS
            Console.Write("Introduce la base: ");
            aux = Console.ReadLine();
            while (!int.TryParse(aux, out numero))
            {
                Console.Write("Introduce un número válido: ");
                aux = Console.ReadLine();
            }
            aux = null;
            Console.Write("Introduce el exponente: ");
            aux = Console.ReadLine();
            while (!int.TryParse(aux, out exponente))
            {
                Console.Write("Introduce un número válido: ");
                aux = Console.ReadLine();
            }
            
            //APLICANDO LA FÚNCIÓN RECURSIVA
            Console.WriteLine(PotenciaRecursiva(numero, exponente));
            Console.ReadLine();

        }
        public static double PotenciaRecursiva(int numero, int exponente)
        {
            try
            {
                if (exponente < 0 || exponente > 500 || numero > 9000)
                {
                    throw new StackOverflowException();
                }
                else if (exponente == 0) //Caso base: Cuando el exponente es 0 siempre devuelve 1
                {
                    return 1;
                }
                else
                {
                    return numero * PotenciaRecursiva(numero, exponente - 1);
                }
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }
}
