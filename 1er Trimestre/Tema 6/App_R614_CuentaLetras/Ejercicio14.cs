/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ContarLetras
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Programa con funciones que sirven para calcular y mostrar el número de letras introducidas hasta pulsar [Ctrl + Z]
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;

namespace App_R614_CuentaLetras
{
    class Ejercicio14
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cuenta el número de letras introducidas por teclado\nde cada tipo y muestra el resultado por pantalla.\n");
            Console.WriteLine("\n\nIntroducir un texto (Para finalizar pulsar [Ctrl]+[Z])");
            int[] letrasContadas = ContarLetras();
            MostrarResultado(letrasContadas);
            Console.ReadLine();
        }
        /// <summary>
        /// Función que muestra el resultado de las letras contadas dado el int[] que devuelve ContarLetras()
        /// </summary>
        /// <param name="contador">int[] que devuelve ContarLetras</param>
        public static void MostrarResultado(int[] contador)
        {
            Console.WriteLine();
            for (int i = 'a'; i <= 'z'; i++)
            {
                Console.Write(((char)i).ToString().PadLeft(4));
            }
            Console.Write('ñ'.ToString().PadLeft(4));
            Console.Write('ç'.ToString().PadLeft(4));
            Console.WriteLine();
            for (int i = 0; i < contador.Length; i++)
            {
                Console.Write(contador[i].ToString().PadLeft(4));
            }
        }
        /// <summary>
        /// Función que cuenta todas las letras introducidas del abecedario español sin distinguir mayúsculas ni minúsculas ni caracteres acentuados.
        /// </summary>
        /// <returns>Array con las letras contadas [0-25][a-z] 26 --> ñ, 27 --> ç</returns>
        public static int[] ContarLetras()
        {
            ConsoleKeyInfo teclaPulsada = new ConsoleKeyInfo();
            StringBuilder textoAContar = new StringBuilder();
            int[] contador = new int['z' - 'a' + 3];
            do
            {
                teclaPulsada = Console.ReadKey();
                if (teclaPulsada.Key==ConsoleKey.Backspace&& textoAContar.Length>0)
                {
                    textoAContar.Remove(textoAContar.Length-1, 1);
                    Console.Write(' ');
                    Console.CursorLeft--;
                }
                else if (teclaPulsada.Key==ConsoleKey.Enter)
                {
                    Console.CursorTop++;
                }
                else
                {
                    textoAContar.Append(teclaPulsada.KeyChar);
                }
            } while (teclaPulsada.Modifiers != ConsoleModifiers.Control || teclaPulsada.Key != ConsoleKey.Z);

            for (int i = 0; i < textoAContar.Length; i++)
            {
                switch (textoAContar[i])
                {
                    case 'a':
                    case 'á':
                    case 'à':
                    case 'ä':
                    case 'â':
                    case 'A':
                    case 'Á':
                    case 'À':
                    case 'Ä':
                    case 'Â':
                        contador[0]++;
                        break;
                    case 'b':
                    case 'B':
                        contador[1]++;
                        break;
                    case 'c':
                    case 'C':
                        contador[2]++;
                        break;
                    case 'd':
                    case 'D':
                        contador[3]++;
                        break;
                    case 'e':
                    case 'é':
                    case 'è':
                    case 'ë':
                    case 'ê':
                    case 'E':
                    case 'É':
                    case 'È':
                    case 'Ë':
                    case 'Ê':
                        contador[4]++;
                        break;
                    case 'f':
                    case 'F':
                        contador[5]++;
                        break;
                    case 'g':
                    case 'G':
                        contador[6]++;
                        break;
                    case 'h':
                    case 'H':
                        contador[7]++;
                        break;
                    case 'i':
                    case 'í':
                    case 'ì':
                    case 'ï':
                    case 'î':
                    case 'I':
                    case 'Í':
                    case 'Ì':
                    case 'Ï':
                    case 'Î':
                        contador[8]++;
                        break;
                    case 'j':
                    case 'J':
                        contador[9]++;
                        break;
                    case 'k':
                    case 'K':
                        contador[10]++;
                        break;
                    case 'l':
                    case 'L':
                        contador[11]++;
                        break;
                    case 'm':
                    case 'M':
                        contador[12]++;
                        break;
                    case 'n':
                    case 'N':
                        contador[13]++;
                        break;
                    case 'o':
                    case 'ó':
                    case 'ò':
                    case 'ö':
                    case 'ô':
                    case 'O':
                    case 'Ó':
                    case 'Ò':
                    case 'Ö':
                    case 'Ô':
                        contador[14]++;
                        break;
                    case 'p':
                    case 'P':
                        contador[15]++;
                        break;
                    case 'q':
                    case 'Q':
                        contador[16]++;
                        break;
                    case 'r':
                    case 'R':
                        contador[17]++;
                        break;
                    case 's':
                    case 'S':
                        contador[18]++;
                        break;
                    case 't':
                    case 'T':
                        contador[19]++;
                        break;
                    case 'u':
                    case 'ú':
                    case 'ù':
                    case 'ü':
                    case 'û':
                    case 'U':
                    case 'Ú':
                    case 'Ù':
                    case 'Ü':
                    case 'Û':
                        contador[20]++;
                        break;
                    case 'v':
                    case 'V':
                        contador[21]++;
                        break;
                    case 'w':
                    case 'W':
                        contador[22]++;
                        break;
                    case 'x':
                    case 'X':
                        contador[23]++;
                        break;
                    case 'y':
                    case 'Y':
                        contador[24]++;
                        break;
                    case 'z':
                    case 'Z':
                        contador[25]++;
                        break;
                    case 'ñ':
                    case 'Ñ':
                        contador[26]++;
                        break;
                    case 'ç':
                    case 'Ç':
                        contador[27]++;
                        break;
                }
            }
            return contador;
        }
    }
}
