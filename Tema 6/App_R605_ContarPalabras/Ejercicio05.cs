/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ContarPalabras
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Ejercicio que tiene una función que cuenta las palabras de un string dado un caracter separador
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R605_ContarPalabras
{
    class Ejercicio05
    {
        static void Main(string[] args)
        {
            char separador;
            string texto;
            string auxiliar;

            Console.WriteLine("Introduce palabras separadas por un caracter separador y obtén el número de palabras introducidas");
            Console.Write("Introduce caracter separador: ");
            auxiliar = Console.ReadLine();
            while(!char.TryParse(auxiliar,out separador))
            {
                Console.Write("Introduce caracter válido: ");
                auxiliar = Console.ReadLine();
            }
            Console.Write("Introduce texto para contar las palabras: ");
            texto = Console.ReadLine();
            Console.WriteLine("Palabras contadas: "+ContarPalabras(texto,separador));
            Console.WriteLine("\nPulsa ENTER para salir...");
            Console.ReadLine();
        }
        /// <summary>
        /// Devuelve la cantidad de palabras dado un string y un char separador pasados como parámetros
        /// </summary>
        /// <param name="texto">Texto string que sobre el que se contarán las palabras dado el otro parámetro separador</param>
        /// <param name="separador">Caracter que sirve de separador entre palabras, si hay separadores consecutivos no contará ninguna palabra</param>
        /// <returns>Número de palabras dado el texto y el separador, si hay separadores consecutivos no contará ninguna palabra </returns>
        public static int ContarPalabras(string texto, char separador)
        {
            int resultado = 0;                              //Variable sobre la que se cuentan las palabras

            bool comienza = false;                          //Si no es al comienzo de una palabra no es true, y cuando cambie contará una palabra
            for (int i = 0; i < texto.Length; i++)
            {
                if (!comienza&&texto[i] != separador)//Si no está comenzada la palabra y el caracter es distinto de separador cambiar valor de comienza a true y cuenta palabra
                {
                    comienza = true;
                    resultado++;
                }
                else if (comienza && texto[i] == separador)     //Si ha comenzado una palabra y el caracter es el separador --> comienza = false
                {
                    comienza = false;
                }
            }
            return resultado;                               //Devuelve el número de las palabras contadas
        }
    }
}
