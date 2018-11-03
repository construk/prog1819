/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    FibonacciRecursivo
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación te devuelve el número de la sucesión de Fibonacci que le indiques
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E19_FibonacciRecursivo
{
    public class NoNegativeFibonacciException : Exception
    {
        private string mensajeError = "ERROR: No se puede obtener el número de la sucesión de Fibonacci negativo";

        public override string Message
        {
            get { return mensajeError; }
        }
        public NoNegativeFibonacciException()
        {
        }
        public NoNegativeFibonacciException(string message) : base(message)
        {
            mensajeError = message;
        }

    }
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
                try
                {
                    if (numero!=-1)
                    {
                        Console.WriteLine(FibonacciRecursivo(numero));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (numero != -1);
            Console.WriteLine("Pulse ENTER para salir...");
            Console.ReadLine();
        }

        public static int FibonacciRecursivo(int numero) //FUNCIÓN QUE TE DEVUELVE EL VALOR DE LA SUCESIÓN DE FIBONACCI QUE LE INDIQUES
        {
            if (numero < 0)
            {
                throw new NoNegativeFibonacciException();
            }
            else if (numero == 0) //CASO BASE 1: 0
            {
                return 0;
            }
            else if (numero == 1) //CASO BASE 2: 1
            {
                return 1;
            }
            else if (numero>5000)
            {
                throw new StackOverflowException();
            }
            else
            {
                return FibonacciRecursivo(numero - 1) + FibonacciRecursivo(numero - 2);
            }
        }
    }
}
