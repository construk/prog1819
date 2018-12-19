/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		TrimAll
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Ejercicio que tiene una función que quita los espacios del principio y del final de un string
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R604_TrimAll
{
    class Ejercicio04
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe un texto y te devolverá el texto sin los espacios del principio y finales");
            Console.Write("Escribe texto: ");
            Console.Write(TrimAll(Console.ReadLine()));
            Console.WriteLine("Texto pegado para comprobar que quita los espacios");
            Console.WriteLine("\nPulsa ENTER para salir");
            Console.ReadLine();
        }
        /// <summary>
        /// Devuelve el texto pasado como parámetro sin espacios al principio ni final
        /// </summary>
        /// <param name="texto">Texto que se le van a quitar los espacios al principio y final</param>
        /// <returns>string pasado como parámetro sin espacios al principio ni final</returns>
        public static string TrimAll(string texto)
        {
            return TrimD(TrimI(texto));
        }
        /// <summary>
        /// Devuelve el texto pasado como parámetro sin espacios al principio
        /// </summary>
        /// <param name="texto">Texto que se le van a quitar los espacios al principio</param>
        /// <returns>string pasado como parámetro sin espacios al principio</returns>
        public static string TrimI(string texto)
        {
            string resultado = "";                                  //Inicializa el string resultado como string vacio
            int principioTexto = 0;                                 //Posición inicial del string pasado
            while (principioTexto != texto.Length && texto[principioTexto] == ' ')     //Mientras no sea el final del texto y el caracter a leer sea un espacio en blanco suma la posición inicial
            {
                principioTexto++;
            }
            for (int i = principioTexto; i < texto.Length; i++)                   //Añade hasta la posición final del texto sin espacios el caracter del string pasado como parámetro al resultado 
            {
                resultado += texto[i];
            }
            return resultado;                                       //Devuelve el resultado
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
