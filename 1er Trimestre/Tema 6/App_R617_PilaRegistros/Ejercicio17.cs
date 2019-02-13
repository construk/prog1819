/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		PilaRegistros
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Programa con un menú capaz de gestionar una pila con los campos nombre, codigo y fecha.
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace App_R617_PilaRegistros
{
    class Ejercicio17
    {
        /// <summary>
        /// Objeto que almacena los campos nombre, código y fecha
        /// </summary>
        public class Registro
        {
            string nombre;
            string codigo;
            DateTime fecha;

            public string Nombre
            {
                get
                {
                    return nombre;
                }
                set
                {
                    nombre = value;
                }
            }
            public string Codigo
            {
                get
                {
                    return codigo;
                }
                set
                {
                    codigo = value;
                }
            }
            public DateTime Fecha
            {
                get
                {
                    return fecha;
                }
                set
                {
                    fecha = value;
                }
            }

            public Registro(string nombre, string codigo, DateTime fecha)
            {
                Nombre = nombre;
                Codigo = codigo;
                Fecha = fecha;
            }
            /// <summary>
            /// Método equals que compara dos registros para comprobar si son iguales
            /// </summary>
            /// <param name="obj">Objeto a comparar</param>
            /// <returns>Devueve true si los campos coinciden, false en caso de que alguno de ellos sea distinto</returns>
            public override bool Equals(object obj)     //Método necesario para que funcione el método Contains()
            {
                var registro = obj as Registro;
                return registro != null &&
                       nombre == registro.nombre &&
                       codigo == registro.codigo &&
                       fecha == registro.fecha;
            }

            public override string ToString()
            {
                return Nombre.PadRight(25) + Codigo.PadRight(12) + Fecha.ToShortDateString().PadRight(10);
            }
        }
        /// <summary>
        /// Objeto que gestiona mediante una pila (Stack) una colección de Registros
        /// </summary>
        public class PilaRegistro
        {
            Stack<Registro> historialRegistro;
            public Stack<Registro> HistorialRegistro
            {
                get { return historialRegistro; }
            }
            public PilaRegistro()
            {
                historialRegistro = new Stack<Registro>();
            }
            public void Add(Registro registro)
            {
                if (!historialRegistro.Contains(registro))
                {
                    historialRegistro.Push(registro);
                    Console.WriteLine("Elemento añadido a la pila con éxito");
                }
                else
                {
                    Console.WriteLine("El elemento ya se encontraba en la pila");
                }
            }
            public void List()
            {
                Console.WriteLine("Nº".PadRight(5) + "NOMBRE".PadRight(25) + "CÓDIGO".PadRight(12) + "FECHA".PadRight(10));
                Console.WriteLine("=".PadLeft(80, '='));
                int contador = 1;
                foreach (Registro registro in historialRegistro)
                {

                    Console.WriteLine(contador.ToString().PadRight(5) + registro.ToString());
                    contador++;
                }
            }
            public void Remove(int numero)
            {
                Stack<Registro> auxiliar = new Stack<Registro>();
                for (int i = 0; i < numero - 1; i++)
                {
                    auxiliar.Push(historialRegistro.Pop());
                }
                historialRegistro.Pop();
                for (int i = 0; i < numero - 1; i++)
                {
                    historialRegistro.Push(auxiliar.Pop());
                }
            }
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo teclaPulsada = new ConsoleKeyInfo();
            PilaRegistro pilaRegistro = new PilaRegistro();
            do
            {
                Console.Clear();
                PintaMenu();
                teclaPulsada = Console.ReadKey();
                Console.Clear();
                switch (teclaPulsada.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Anadir(pilaRegistro);
                        Console.WriteLine("\n Pulsa Enter para volver al menú...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("=".PadLeft(80, '='));
                        Console.WriteLine("   LISTA");
                        Console.WriteLine("=".PadLeft(80, '='));
                        pilaRegistro.List();
                        Console.WriteLine("=".PadLeft(80, '='));
                        Console.WriteLine("\n Pulsa Enter para volver al menú...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine("=".PadLeft(80, '='));
                        Console.WriteLine("   ELIMINAR\t\t(Esc) para salir");
                        Console.WriteLine("=".PadLeft(80, '='));

                        if (pilaRegistro.HistorialRegistro.Count != 0)
                        {
                            ConsoleKeyInfo tecla = new ConsoleKeyInfo();
                            StringBuilder texto = new StringBuilder();
                            pilaRegistro.List();
                            Console.WriteLine("=".PadLeft(80, '='));
                            Console.Write("\nIntroduce el Nº del registro que deseas eliminar: ");
                            EliminarRegistro(pilaRegistro);
                        }
                        else
                        {
                            Console.WriteLine("No se puede eliminar nada porque no existe ningún valor en el registro...");
                        }
                        Console.ReadLine();
                        break;
                }
            } while (teclaPulsada.Key != ConsoleKey.Escape);
        }
        /// <summary>
        /// Método que pinta el menú principal
        /// </summary>
        public static void PintaMenu()
        {
            Console.WriteLine("=".PadLeft(80, '='));
            Console.WriteLine("   MENU");
            Console.WriteLine("=".PadLeft(80, '='));
            Console.WriteLine(" 1 - Añadir");
            Console.WriteLine(" 2 - Listar");
            Console.WriteLine(" 3 - Eliminar");
            Console.WriteLine(" Esc - Salir");
            Console.WriteLine("=".PadLeft(80, '='));
        }
        /// <summary>
        /// Método que permite eliminar un registro concreto, y también permite salir sin eliminar ningún registro pulsando la tecla Escape
        /// </summary>
        /// <param name="pilaRegistro">PilaRegistro a editar</param>
        public static void EliminarRegistro(PilaRegistro pilaRegistro)
        {
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();
            int posicionCursor = Console.CursorLeft;
            StringBuilder texto = new StringBuilder();
            #region Introducción caracteres
            do                                  //Mientras no se pulse Enter o Escape leerá caracteres para formar una palabra. Escape no elimina. Enter comprueba que sea válido.
            {
                tecla = Console.ReadKey();      //Leer tecla
                if (tecla.Key == ConsoleKey.Backspace)  //Si tecla borra
                {
                    Console.Write(" ");
                    if (Console.CursorLeft <= posicionCursor)   //Si posición es menor o igual al comienzo, situar al comienzo
                    {
                        Console.CursorLeft = posicionCursor;
                    }
                    else                                        //Sino posición anterior
                    {
                        Console.CursorLeft--;
                    }

                    if (texto.Length > 0)                       //Si el texto tiene contenido: BORRAR
                    {
                        texto.Remove(texto.Length - 1, 1);
                    }
                }
                else                                            //Mientras no se pulse borrar lo añade al texto
                {
                    texto.Append(tecla.KeyChar);
                }

            } while (tecla.Key != ConsoleKey.Escape && tecla.Key != ConsoleKey.Enter);
            #endregion
            #region Pulsar Enter, comprobar que sea válido
            if (tecla.Key == ConsoleKey.Enter)
            {
                #region En caso de error
                string auxiliar = texto.ToString();
                int numero;
                while (!int.TryParse(auxiliar, out numero) || numero < 1 || numero > pilaRegistro.HistorialRegistro.Count)
                {
                    Console.WriteLine("".PadRight(Console.WindowWidth - 1, ' '));
                    Console.CursorTop--;
                    Console.CursorLeft = 0;
                    Console.Write("Error. Introduce el Nº del registro válido: ");
                    int posicionError=Console.CursorLeft;
                    texto.Clear();
                    do
                    {
                        #region Control caracteres
                        tecla = Console.ReadKey();      //Leer tecla
                        if (tecla.Key == ConsoleKey.Backspace)  //Si tecla borra
                        {
                            Console.Write(" ");
                            if (Console.CursorLeft <= posicionError)   //Si posición es menor o igual al comienzo, situar al comienzo
                            {
                                Console.CursorLeft = posicionError;
                            }
                            else                                        //Sino posición anterior
                            {
                                Console.CursorLeft--;
                            }

                            if (texto.Length > 0)                       //Si el texto tiene contenido: BORRAR
                            {
                                texto.Remove(texto.Length - 1, 1);
                            }
                        }
                        else if(tecla.Key == ConsoleKey.Enter)          //Si no se pulsa Backspace (tecla return o borrar) lo añade al texto
                        {
                            auxiliar = texto.ToString();
                        }
                        else
                        {
                            texto.Append(tecla.KeyChar);
                        }
                        #endregion
                    } while (tecla.Key != ConsoleKey.Escape && tecla.Key != ConsoleKey.Enter);
                }
                #endregion
                #region Eliminación realizada con éxito
                if (tecla.Key == ConsoleKey.Enter)      //Si se pulsa Enter y el dato introducido es un número válido se eliminará el registro
                {
                    pilaRegistro.Remove(numero);
                    Console.WriteLine("".PadRight(Console.WindowWidth - 1, ' '));
                    Console.CursorTop--;
                    Console.CursorLeft = 0;
                    Console.WriteLine("Eliminación realizada con éxito.\nPulse Enter para volver al menú principal...");
                }
                #endregion
            }

            #endregion
            #region Pulsar Escape, salida sin eliminar
            else if (tecla.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("\nPulse Enter para volver al menu principal...");
            }
            #endregion
        }
        /// <summary>
        /// Método que te permite añadir un registro al objeto PilaRegistro
        /// </summary>
        /// <param name="pilaRegistro">PilaRegistro a la que se añade el registro</param>
        public static void Anadir(PilaRegistro pilaRegistro)
        {
            string nombre, codigo, auxiliarFecha;
            DateTime fecha;
            Registro registro;

            Console.WriteLine("=".PadLeft(80, '='));
            Console.WriteLine("   AÑADIR");
            Console.WriteLine("=".PadLeft(80, '='));
            Console.Write("Introduce nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Introduce código: ");
            codigo = Console.ReadLine();
            Console.Write("Introduce fecha: ");
            auxiliarFecha = Console.ReadLine();
            while (!DateTime.TryParse(auxiliarFecha, out fecha))
            {
                Console.CursorTop--;
                Console.CursorLeft = 0;
                Console.Write("".PadRight(Console.WindowWidth - 1, ' '));
                Console.CursorLeft = 0;
                Console.Write("Error. Introduce una fecha válida: ");
                auxiliarFecha = Console.ReadLine();
            }
            registro = new Registro(nombre, codigo, fecha);
            pilaRegistro.Add(registro);
        }
    }
}