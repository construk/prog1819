/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Imprime Mayusculas
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación escribe en mayúsculas.
-------------------------------------------------------------------------------------------------------------*/

using System;

namespace App_R3E7_ImprimeMayuscula
{
    class Program
    {
        static void Main(string[] args)
        {
            char teclaEscape = '*';
            char teclaLeida;
            Console.WriteLine("Este programa escribe en mayusculas todo lo que escribas");
            do
            {
                teclaLeida = Console.ReadKey(true).KeyChar;
                if(teclaLeida != teclaEscape)
                {
                    Console.Write(AMayuscula(teclaLeida).ToString());
                }
            } while(teclaLeida != teclaEscape);
        }
        private static char AMayuscula(char caracter)
        {
            int a = 97;
            int A = 65;
            int z = 122;
            int diferenciaMayusMinus = a-A;
            if((int)caracter >= a && (int)caracter <= z)
            {
                int caracterMayus = (int)caracter - diferenciaMayusMinus;
                return (char)caracterMayus;
            }
            else if((int)caracter == 241) //CONTROL DE Ñ
            {
                return (char)209;
            }
            else if((int)caracter == 160) //CONTROL DE á
            {
                return (char)181;
            }
            else if((int)caracter == 130) //CONTROL DE é
            {
                return (char)144;
            }
            else if((int)caracter == 161)//CONTROL DE í
            {
                return (char)214;
            }
            else if((int)caracter == 161) //CONTROL DE ú
            {
                return (char)214;
            }
            else
            {                      //PARA TODO LO DEMÁS MASTERCARD
                return caracter;
            }
        }
    }
}

