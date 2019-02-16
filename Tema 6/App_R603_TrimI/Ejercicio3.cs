/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		TrimI
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Ejercicio que tiene una función que quita los espacios del principio de un string
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R603_TrimI
{
    class Ejercicio3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe un texto y te devolverá el texto sin los espacios finales");
            Console.Write("Escribe texto: ");
            Console.WriteLine(TrimI(Console.ReadLine()));
            Console.WriteLine("\nPulsa ENTER para salir");
            Console.ReadLine();
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
    }
}
