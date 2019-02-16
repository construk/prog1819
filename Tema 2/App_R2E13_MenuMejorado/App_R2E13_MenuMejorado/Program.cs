/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Menu mejorado (usando dll del año pasado)
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación pinta un menú usando una dll de cosecha propia.
-------------------------------------------------------------------------------------------------------------*/
using System;
using App_R7E1_MenuPrincipal;

namespace App_R2E13_MenuMejorado
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal menu = new MenuPrincipal(1, ConsoleColor.Red, new string[] { "1. Alta", "2. Baja", "3. Consulta", "4. Modifica", "", "0. Salir", "" }, "MENU PRINCIPAL", new Coordenada(10, 5), new Coordenada(21,26));
            menu.MostrarMenu(ConsoleColor.Yellow);
            Console.ReadLine();
        }
    }
}
