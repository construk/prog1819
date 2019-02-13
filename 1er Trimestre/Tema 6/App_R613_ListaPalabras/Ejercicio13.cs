/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ListaPalabras
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Programa con función ListaPalabras que te devuelve un string con un listado de palabras con la primera letra en mayúscula dados los separadores ' ', '-' y '|' 
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;

namespace App_R613_ListaPalabras
{
    class Ejercicio13
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe un texto y te devolvera un listado con las palabras y la primera letra en mayúscula dados los separadores ' ', '-' y '|'");
            Console.Write("Escribe texto: ");
            Console.WriteLine(ListaPalabras(Console.ReadLine())); 
            Console.ReadLine();
        }
        /// <summary>
        /// Función que te devuelve un string con saltos de linea dados los separadores ' ', '-' y '|' y la primera letra de cada palabra en mayúcula
        /// </summary>
        /// <param name="texto">string a transformar</param>
        /// <returns>string transformado</returns>
        public static string ListaPalabras(string texto)
        {
            bool comienzaPalabra = false;
            StringBuilder palabra = new StringBuilder();
            for (int i = 0; i < texto.Length; i++)
            {
                bool condicionSeparadores = texto[i] != ' ' && texto[i] != '|' && texto[i] != '-';
                if (condicionSeparadores && !comienzaPalabra)
                {
                    comienzaPalabra = true;
                    palabra.Append(char.ToUpper(texto[i]));
                }
                else if (comienzaPalabra && condicionSeparadores)
                {
                    palabra.Append(texto[i]);
                }
                else if (comienzaPalabra&&!condicionSeparadores)
                {
                    palabra.Append("\n");
                    comienzaPalabra = false;
                }
            }
            return palabra.ToString();
        }
    }
}
