/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		AMayuscula
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Programa con función AMayúscula que transforma un string pasado como parámetro en mayúsculas
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;

namespace App_R612_AMayuscula
{
    class Ejercicio12
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe un texto y lo obtendrás en mayúsculas");
            Console.Write("Escribir texto: ");
            Console.WriteLine(AMayuscula(Console.ReadLine()));
            Console.ReadLine();
        }
        /// <summary>
        /// Función que te devuelve un string en mayúsculas
        /// </summary>
        /// <param name="texto">string a transformar</param>
        /// <returns>string en mayúsculas</returns>
        public static string AMayuscula(string texto)
        {
            int diferencia = 'a' - 'A';
            StringBuilder textoMayuscula = new StringBuilder(texto);
            for (int i = 0; i < textoMayuscula.Length; i++)
            {
                if (textoMayuscula[i] >= 'a' && texto[i] <= 'z')                //Controlando entre rangos de valores (Problema con caracteres acentuados)
                {
                    textoMayuscula[i] = (char)(textoMayuscula[i] - diferencia);
                }
                else if (char.IsLower(textoMayuscula[i]))                       //Control con el uso de métodos estáticos de la clase char (Controla mejor todos los caracteres)
                {
                    textoMayuscula[i] = char.ToUpper(textoMayuscula[i]);
                }
            }
            return textoMayuscula.ToString();
        }
    }
}
