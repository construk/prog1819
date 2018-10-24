/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Escribir frases
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación escribe frases con caracteres especiales
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R3E13_ImprimirFrases
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Este programa escribe frases con caracteres especiales");
            Console.WriteLine("Las comillas dobles( \" ) son especiales dentro del método Write. ");
            Console.WriteLine("Esto es una barra invertida \\. ");
            Console.WriteLine("El carácter \"\\t\" es tabulación horizontal ");
            Console.WriteLine("El carácter \"\\n\" es salto de línea");
            Console.WriteLine("Los caracteres {} son especiales");
            int i = 5;
            Console.WriteLine(" El primer valor se sustituye por {0} y vale: "+i);
            Console.ReadLine();
        }
    }
}
