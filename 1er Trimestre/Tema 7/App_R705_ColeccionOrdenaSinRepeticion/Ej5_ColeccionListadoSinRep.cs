/*-------------------------------------------------------------------------------------------------------------
 *  Programa:                ColeccionOrdenadaSinRepeticion
 *  Autor:                Francisco J. Gómez Florido
 *  Versión:                v 1.0 ene 2019
 *  Descripción:        Programa que gestiona una lista con código único de trabajadores
-------------------------------------------------------------------------------------------------------------*/
using System;
using App_R701_MenuPrincipal;

namespace App_R705_ColeccionOrdenadaSinRepeticion
{
    class Ej5_ColeccionSinRepeticion
    {
        static void Main(string[] args)
        {
            Trabajadores trabajadores = new Trabajadores();
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();
            RellenarAleaLista(trabajadores, 1000);
            MenuPrincipal menu = new MenuPrincipal("MENÚ", new string[] { "AÑADIR  ", "BUSCAR  ", "LISTAR  " }, ConsoleColor.Red, TipoMarco.Doble, EstiloTexto.alineadoIzquierda);
            do
            {
                Console.Clear();
                menu.Pintar();
                Console.CursorLeft = 0;
                Console.WriteLine("  ESC- SALIR  ");
                tecla = Console.ReadKey(true);
                switch (tecla.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        trabajadores.AnadirConsola();
                        Console.WriteLine("Pulse ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        trabajadores.BuscarMenuConsola();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        trabajadores.ListarMenuConsola();
                        break;
                }
            } while (tecla.Key != ConsoleKey.Escape);
        }
        public static void RellenarAleaLista(Trabajadores trabajadores, int cantidad)
        {
            string[] nombre = { "Raul", "Bilal", "Fran", "Manuel", "Ignacio", "Eustaquio", "Eliseo", "Aitor", "Vyacheslav", "Ismael", "Sebas", "Ana", "Muzska", "Rubén", "Alejandro", "Chemita", "Marek" };
            string[] apellido = { "Prieto", "Perez", "González", "Toro", "Roldán", "Moya", "Rivas", "Tilla", "Menta", "García", "Shylyayev", "Bueno", "Turbado", "Sánchez", "Zúñiga" };
            Random rnd = new Random();
            for (int i = 1; i <= cantidad; i++)
            {
                trabajadores.Anadir(i, apellido[rnd.Next(apellido.Length)] + " " + apellido[rnd.Next(apellido.Length)], nombre[rnd.Next(nombre.Length)], new DateTime(rnd.Next(80) + 1920, rnd.Next(12) + 1, rnd.Next(28) + 1), rnd.Next(1000) + 1000);
            }
        }
    }
}