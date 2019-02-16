/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    CuentaVocales
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación cuenta las vocales introducidas por teclado hasta pulsar un 0 y luego muestra el resultado
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R3E16_CuentaVocales
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo caracterLeido;   //tecla que se va a leer
            int caracterA = 0;              //contador de la tecla pulsada a
            int caracterE = 0;              //contador de la tecla pulsada e
            int caracterI = 0;              //contador de la tecla pulsada i
            int caracterO = 0;              //contador de la tecla pulsada o
            int caracterU = 0;              //contador de la tecla pulsada u

            Console.WriteLine("Programa que cuenta el número de vocales introducidas");
            Console.WriteLine("Introduce caracteres (0 para salir):");
            do
            {
                caracterLeido = Console.ReadKey();  //Leer caracter
                switch (caracterLeido.Key)  //Según el caracter leido
                {
                    case ConsoleKey.A:      //Si es A aumenta el contador
                        caracterA++;
                        break;
                    case ConsoleKey.E:      //Si es E aumenta el contador
                        caracterE++;
                        break;
                    case ConsoleKey.I:      //Si es I aumenta el contador
                        caracterI++;
                        break;
                    case ConsoleKey.O:      //Si es O aumenta el contador
                        caracterO++;
                        break;
                    case ConsoleKey.U:      //Si es U aumenta el contador
                        caracterU++;
                        break;
                    default:                //En caso de pulsar cualquier otra tecla no hacer nada.
                        break;
                }
            } while (caracterLeido.KeyChar!='0');   //MIENTRA LA TECLA PULSADA NO SEA 0 NO PODRÁ SALIR DEL PROGRAMA
            Console.WriteLine("El número de vocales son:"); //Escribe los resultados de las vocales contadas
            Console.WriteLine("A --> {0}",caracterA );
            Console.WriteLine("E --> {0}", caracterE);
            Console.WriteLine("I --> {0}", caracterI);
            Console.WriteLine("O --> {0}", caracterO);
            Console.WriteLine("U --> {0}", caracterU);
            Console.ReadLine();
        }
    }
}
