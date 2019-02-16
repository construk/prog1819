/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    EscribeNCaracter
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación escribe tantas veces un caracter como indiques
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E2_EscribeNCaracter
{
    class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            int numeroVeces;
            char caracterLeido;
            string auxiliar;        //Para comprobar tipo en el while

            //INTRODUCCIÓN Y ENTRADA DE DATOS
            Console.WriteLine("Este programa imprime un número determinado de veces un caracter");
            Console.Write("Introduce caracter: ");
            caracterLeido = Console.ReadKey().KeyChar;
            Console.ReadLine();
            Console.Write("Introduce el número de veces para que se repita: ");
            auxiliar = Console.ReadLine();

            //MIENTRAS NO PUEDA TRANSFORMAR A INT PEDIRÁ DE NUEVO EL NÚMERO
            while (!int.TryParse(auxiliar,out numeroVeces))
            {
                Console.WriteLine("Introduce un número válido: ");
                auxiliar = Console.ReadLine();
            }

            //FUNCIÓN QUE IMPRIME LOS CARACTERES CON LOS DATOS INTRODUCIDOS
            ImprimirNVecesCaracter(caracterLeido, numeroVeces);

            //SALIDA EL PROGRAMA    
            Console.CursorVisible = false;
            Console.WriteLine("\n\nPulse una tecla para salir...");
            Console.ReadLine();

        }
        private static void ImprimirNVecesCaracter(char caracter, int numeroVeces)
        {
            for (int i = 0; i < numeroVeces; i++)
                Console.Write(caracter);
        }
    }
}
