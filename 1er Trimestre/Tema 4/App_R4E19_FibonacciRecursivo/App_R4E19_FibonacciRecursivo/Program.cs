/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    FibonacciRecursivo
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación te devuelve el número de la sucesión de Fibonacci que le indiques
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E19_FibonacciRecursivo
{
    class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            string aux;
            int numero;
            
            //INTRODUCCIÓN
            Console.WriteLine("Programa que calcula el número de la sucesión de Fibonacci que indiques (-1 para salir)");
            do
            {
                //LEER DATOS
                Console.Write("Introduce número : ");
                aux = Console.ReadLine();
                while (!int.TryParse(aux, out numero))
                {
                    Console.Write("Introduce un número válido: ");
                    aux = Console.ReadLine();
                }
                //ESCRIBE EL NÚMERO DE LA SUCESIÓN DE FIBONACCI INDICADO
                Console.WriteLine(FibonacciRecursivo(numero));
            } while (numero!=-1);
        }

        public static int FibonacciRecursivo(int numero) //FUNCIÓN QUE TE DEVUELVE EL VALOR DE LA SUCESIÓN DE FIBONACCI QUE LE INDIQUES
        {
            if (numero==0) //CASO BASE 1: 0
            {
                return 0;
            }
            else if (numero==1) //CASO BASE 2: 1
            {
                return 1;
            }
            else            
            {
                return FibonacciRecursivo(numero - 1) + FibonacciRecursivo(numero - 2);
            }
        }
    }
}
