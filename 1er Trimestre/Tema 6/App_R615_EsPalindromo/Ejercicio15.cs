/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		EsPalindromo
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Programa con la función EsPalindromo que comprueba si un texto es palindromo o no
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using System.Text;

namespace App_R615_EsPalindromo
{
    class Ejercicio15
    {
        static void Main(string[] args)
        {
            Console.WriteLine(EsPalindromo("abataba"));
            Console.WriteLine(EsPalindromo("sometemos"));
            Console.WriteLine(EsPalindromo("Ana"));
            Console.WriteLine(EsPalindromo("Ana Vana"));
            Console.WriteLine(EsPalindromo("La ruta natural"));
            Console.WriteLine(EsPalindromo("La rusta natural"));

            Console.ReadLine();
        }
        public static bool EsPalindromo(string texto)
        {
            while(texto.Contains(' '))
            {
                int posicion = texto.IndexOf(' ');
                if (posicion!=-1)
                {
                    texto = texto.Remove(posicion, 1);
                }
            }
            string auxiliar = texto.ToUpper();
            StringBuilder texto2 = new StringBuilder();
            for (int i = auxiliar.Length-1; i >= 0; i--)
            {
                texto2.Append(auxiliar[i]);
            }
            if (texto2.ToString().Equals(auxiliar))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
