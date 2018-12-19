/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		AlReves
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Programa que utiliza la función AlReves, que recibe un texto y te lo devuelve del revés
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R601_AlReves
{
    class Ejercicio01
    {
        static void Main(string[] args)
        {
            string texto;
            try {
                Console.WriteLine("Escribe una palabra y se pintará por pantalla la palabrá del revés");
                Console.Write("Introduce palabra: ");
                Console.WriteLine(AlReves(Console.ReadLine()));
                Console.WriteLine("\nPulse ENTER para salir...");
                Console.ReadLine();

            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
        /// <summary>
        /// Devuelve el texto pasado del revés
        /// </summary>
        /// <param name="texto">Texto que se va a invertir</param>
        /// <returns>Devuelve el parámetro texto invertido</returns>
        public static string AlReves(string texto)
        {
            string resultado = "";                  //Inicializa la variable resultado con un string vacio
            for (int i = 0; i < texto.Length; i++)  //Recorre la palabra
            {
                resultado += texto[texto.Length - 1 - i];   //Añade a resultado el caracter de la posición contrária
            }
            return resultado;                       //Devuelve la variable resultado
        }
    }
}
