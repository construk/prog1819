/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		TrimD
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Ejercicio que tiene una función que quita los espacios finales de un string
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R602_TrimD
{
    class Ejercicio02
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe un texto y te devolverá el texto sin los espacios finales");
            Console.Write("Escribe texto: ");
            Console.Write(TrimD(Console.ReadLine()));
            Console.WriteLine("Texto pegado para comprobar que quita los espacios");
            Console.WriteLine("\nPulsa ENTER para salir");
            Console.ReadLine();
        }
        /// <summary>
        /// Devuelve el texto pasado como parámetro sin espacios finales
        /// </summary>
        /// <param name="texto">Texto que se le van a quitar los espacios finales</param>
        /// <returns>string pasado como parámetro sin espacios finales</returns>
        public static string TrimD(string texto)
        {
            string resultado = "";                                  //Inicializa el string resultado como string vacio
            int finalTexto = texto.Length - 1;                      //Posición final del string pasado
            while (finalTexto != 0 && texto[finalTexto] == ' ')     //Mientras no sea el final del texto y el caracter a leer sea un espacio en blanco resta la posición final
            {
                finalTexto--;
            }
            for (int i = 0; i <= finalTexto; i++)                   //Añade hasta la posición final del texto sin espacios el caracter del string pasado como parámetro al resultado 
            {
                resultado += texto[i];
            }
            return resultado;                                       //Devuelve el resultado
        }
    }
}
