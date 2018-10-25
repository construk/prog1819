/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Quiniela
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación genera resultados de quinielas
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R3E21_Quiniela
{
    class Program
    {
        static void Main(string[] args)
        {
            int contadorX = 0;
            int contador1 = 0;
            int contador2 = 0;
            Random random = new Random();
            string[] resultados = new string[] { "X", "1", "2" };
            string resultadoPartido;

            Console.WriteLine("Ejercicio Nº21\n");
            Console.WriteLine("Generador de resultados de quiniela de futbol");

            for (int i = 0; i < 15; i++)
            {
                resultadoPartido = resultados[random.Next(3)];
                Console.WriteLine(resultadoPartido.PadLeft(20));
                switch (resultadoPartido)
                {
                    case "X":
                        contadorX++;
                        break;
                    case "1":
                        contador1++;
                        break;
                    case "2":
                        contador2++;
                        break;
                }
            }
            Console.CursorTop++;

            Console.WriteLine("Hay {0} X".PadLeft(24),contadorX);
            Console.WriteLine("Hay {0} 1".PadLeft(24), contador1);
            Console.WriteLine("Hay {0} 2".PadLeft(24), contador2);
            Console.ReadLine();
        }
    }
}
