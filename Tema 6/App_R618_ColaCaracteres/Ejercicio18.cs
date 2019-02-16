/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ColaCaracteres
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Programa que gestiona una cola de caracteres...
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace App_R618_ColaCaracteres
{
    class Ejercicio18
    {
        static void Main(string[] args)
        {
            try
            {
                Queue<char> colaCaracteres = new Queue<char>();
                ConsoleKeyInfo teclaMenu = new ConsoleKeyInfo();
                string auxiliar;
                do
                {
                    Console.Clear();                    //LimpiaPantalla
                    PintarMenu();                       //Pinta el menú
                    teclaMenu = Console.ReadKey(true);  //Lee la tecla de la opción del menú (sin verse)
                    switch (teclaMenu.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            AnadirCola(colaCaracteres);
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            ListarCaracteres(colaCaracteres);
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            if (colaCaracteres.Count > 0)
                            {
                                int nCaracteres;
                                Console.WriteLine("=".PadLeft(80, '='));
                                Console.WriteLine("   EXTRAER N CARACTERES");
                                Console.WriteLine("=".PadLeft(80, '='));
                                Console.WriteLine("Introduce cuantos caracteres quieres extraer (MAX: {0}): ", colaCaracteres.Count);
                                auxiliar = Console.ReadLine();
                                while (!int.TryParse(auxiliar, out nCaracteres) || nCaracteres > colaCaracteres.Count)
                                {
                                    Console.CursorTop--;
                                    Console.CursorLeft = 0;
                                    Console.WriteLine(" ".PadLeft(80, ' '));
                                    Console.CursorTop--;
                                    Console.CursorLeft = 0;
                                    Console.WriteLine("Error. Introduce cuantos caracteres quieres extraer (MAX: {0}): ", colaCaracteres.Count);
                                    auxiliar = Console.ReadLine();
                                }
                                ExtraerCola(colaCaracteres, nCaracteres);
                            }
                            else
                            {
                                Console.WriteLine("No hay elementos a extraer...");
                            }

                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            if (colaCaracteres.Count > 0)
                            {
                                int numero;
                                ListarCaracteres(colaCaracteres);
                                Console.Write("Introduce el número del caracter a eliminar: ");
                                auxiliar = Console.ReadLine();
                                while (!int.TryParse(auxiliar, out numero) || numero > colaCaracteres.Count)
                                {
                                    Console.CursorTop--;
                                    Console.CursorLeft = 0;
                                    Console.WriteLine(" ".PadLeft(80, ' '));
                                    Console.CursorTop--;
                                    Console.CursorLeft = 0;
                                    Console.WriteLine("Error. Introduce un número válido: ");
                                    auxiliar = Console.ReadLine();
                                }
                                EliminarCaracterN(colaCaracteres, numero);
                            }
                            else
                            {
                                Console.WriteLine("No hay elementos a eliminar...");
                            }

                            break;
                    }
                    if (teclaMenu.Key != ConsoleKey.Escape)
                    {
                        Console.WriteLine("Pulsa Enter para volver al menú principal...");
                        Console.ReadLine();
                    }


                } while (teclaMenu.Key != ConsoleKey.Escape);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        /// <summary>
        /// Método que pinta el menú principal
        /// </summary>
        public static void PintarMenu()
        {
            Console.WriteLine("=".PadLeft(80, '='));
            Console.WriteLine("   MENU");
            Console.WriteLine("=".PadLeft(80, '='));
            Console.WriteLine(" 1 - Añadir");
            Console.WriteLine(" 2 - Listar");
            Console.WriteLine(" 3 - Extraer n caracteres");
            Console.WriteLine(" 4 - Eliminar");
            Console.WriteLine(" Esc - Salir");
            Console.WriteLine("=".PadLeft(80, '='));
        }
        /// <summary>
        /// Función que sirve para añadir caracteres imprimibles a una cola mientras no se pulse Escape
        /// </summary>
        /// <param name="colaCaracteres">Cola a la que se añaden los caracteres</param>
        public static void AnadirCola(Queue<char> colaCaracteres)
        {
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();

            Console.WriteLine("=".PadLeft(80, '='));
            Console.WriteLine("   AÑADIR CARACTERES");
            Console.WriteLine("=".PadLeft(80, '='));
            Console.Write("Introduce caracteres hasta pulsar Escape: ");
            int posicionCursor = Console.CursorLeft;
            do
            {
                tecla = Console.ReadKey(tecla.Key == ConsoleKey.Escape);
                if (char.IsSymbol(tecla.KeyChar) || char.IsLetterOrDigit(tecla.KeyChar))
                {
                    colaCaracteres.Enqueue(tecla.KeyChar);
                }
                else if (tecla.Key == ConsoleKey.Backspace)
                {
                    Queue<char> auxiliar = new Queue<char>();
                    Console.Write(" ");
                    if (Console.CursorLeft <= posicionCursor)   //Si posición es menor o igual al comienzo, situar al comienzo
                    {
                        Console.CursorLeft = posicionCursor;
                    }
                    else                                        //Sino posición anterior
                    {
                        Console.CursorLeft--;
                    }
                }
                else if (tecla.Key == ConsoleKey.Enter)
                {
                    Console.CursorTop++;
                }
                else if (tecla.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                }
            } while (tecla.Key != ConsoleKey.Escape);
        }
        /// <summary>
        /// Función que sirve para listar los elementos de la cola en una lista
        /// </summary>
        /// <param name="colaCaracteres">Cola a la que se añaden los caracteres</param>
        public static void ListarCaracteres(Queue<char> colaCaracteres)
        {
            int contador = 1;
            Console.WriteLine("=".PadLeft(80, '='));
            Console.WriteLine("   LISTA CARACTERES");
            Console.WriteLine("=".PadLeft(80, '='));
            foreach (char caracter in colaCaracteres)
            {
                Console.WriteLine(contador + " --> " + caracter);
                contador++;
            }
        }
        /// <summary>
        /// Función que sirve para extraer n caracteres de una cola
        /// </summary>
        /// <param name="colaCaracteres">Cola a la que se le van a extraer los caracteres</param>
        /// <param name="nCaracteres">Número de caracteres a extraer</param>
        public static void ExtraerCola(Queue<char> colaCaracteres, int nCaracteres)
        {
            for (int i = 0; i < nCaracteres; i++)
            {
                Console.Write(colaCaracteres.Dequeue());
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Función que extrae el elemento que le indiques de la cola
        /// </summary>
        /// <param name="colaCaracteres">Cola a la que se va a eliminar un caracter</param>
        /// <param name="caracterEliminar">Número del caracter que se va a eliminar</param>
        public static void EliminarCaracterN(Queue<char> colaCaracteres, int caracterEliminar)
        {
            Queue<char> colaAuxiliar = new Queue<char>();
            for (int i = 0; i < caracterEliminar - 1; i++)
            {
                colaAuxiliar.Enqueue(colaCaracteres.Dequeue());
            }
            colaCaracteres.Dequeue();
            for (int i = 0; i < caracterEliminar - 1; i++)
            {
                colaCaracteres.Enqueue(colaAuxiliar.Dequeue());
            }
        }
    }
}
