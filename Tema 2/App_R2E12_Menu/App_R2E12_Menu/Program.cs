/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Menu
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación pinta un menú.
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R2E12_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            PintaMarco(50, 17);
            PintaElementos();
        }
        private static void PintaElementos()
        {
            int margenIzquierdo = 10;
            int posicionLeerIzquierda = 20;
            Console.SetCursorPosition(margenIzquierdo, 5);
            Console.WriteLine("MENU PRINCIPAL");
            Console.CursorLeft = margenIzquierdo;
            Console.WriteLine("---------------");
            Console.CursorLeft = margenIzquierdo;
            Console.WriteLine("1. Alta");
            Console.CursorLeft = margenIzquierdo;
            Console.WriteLine("2. Baja");
            Console.CursorLeft = margenIzquierdo;
            Console.WriteLine("3. Consulta");
            Console.CursorLeft = margenIzquierdo;
            Console.WriteLine("4. Modifica\n");
            Console.CursorLeft = margenIzquierdo;
            Console.WriteLine("0. Salir");
            Console.CursorLeft = posicionLeerIzquierda;
            Console.Write("Elige una opción:");
            Console.ReadLine();
        }
        private static void PintaMarco(int ancho, int largo)
        {                                       //PINTA:
            Console.Write("┌");                 //Esquina superior izquierda
            for (int i = 0; i < ancho-1; i++)   //Linea superior 
            {
                Console.Write("─");
            }
            Console.WriteLine("┐");                 //Esquina superior derecha
            for (int i = 0; i < largo-1; i++)   //Lateral izquierdo
            {
                Console.WriteLine("│");
            }
            Console.CursorTop = 1;              //Se posiciona en la segunda linea
            for (int i = 0; i < largo-1; i++)
            {
                Console.CursorLeft = ancho;
                Console.WriteLine("│");
            }
            Console.Write("└");
            for (int i = 0; i < ancho-1; i++)
            {
                Console.Write("─");
            }
            Console.Write("┘");
        }
    }
}
