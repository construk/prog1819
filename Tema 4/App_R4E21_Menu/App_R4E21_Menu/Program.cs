/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Menu
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación pinta un menu
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Threading;

namespace App_R4E21_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo teclaLeida = new ConsoleKeyInfo();   //TECLA INTRODUCIDA POR EL USUARIO QUE SE OBTENDRÁ EL CARACTER INTRODUCIDO
            int opcionInt;                                      //OPCIÓN INTRODUCIDA POR EL USUARIO DE TIPO INT QUE COMPRUEBA QUE SEA UN NÚMERO LO QUE INTRODUCE
            bool noSalir = true;
            string elegidaString = teclaLeida.KeyChar.ToString();       //SE TRANSFORMA A STRING PORQUE NO EXISTE SOBRECARGA PARA TIPO CHAR PARA MÉTODO TRYPARSE

            do                                                  //HACER MIENTRA EL BOOLEANO NO SALIR SEA TRUE (SE VUELVE FALSE SI SE PULSA 0)
            {
                LimpiaYPintaMenuPrincipal();                    //MÉTODO QUE LIMPIA LA CONSOLA Y PINTA EL MENÚ PRINCIPAL PARA DICHO PROGRAMA
                int posicionTop = Console.CursorTop;            //GUARDAMOS LA POSICIÓN TOP DE ESCRITURA;
                int posicionLeft = Console.CursorLeft;          //GUARDAMOS LA POSICIÓN LEFT DE ESCRITURA;
                //LEER OPCION
                teclaLeida = Console.ReadKey();                  //INTRODUCIDO POR EL USUARIO

                //MIENTRAS NO PUEDA TRANSFORMARLO A INT PIDE EL NÚMERO Y BORRA EL CAMPO ESCRITO
                while (!int.TryParse(elegidaString, out opcionInt))
                {
                    Console.SetCursorPosition(posicionLeft, posicionTop);   //POSICIONA PARA BORRAR EL CAMPO INTRODUCIDO PORQUE NO PUEDE TRANSFORMA A STRING
                    Console.Write(" ");                                     //BORRA EL CAMPO INTRODUCIDO
                    Console.SetCursorPosition(posicionLeft, posicionTop);   //POSICIONA PARA LEER
                    teclaLeida = Console.ReadKey();                         //LEE DATO DEL USUARIO
                    elegidaString = teclaLeida.KeyChar.ToString();          //GUARDA COMO STRING PARA COMPROBAR SI SE PUEDE TRANSFORMA A INT
                }
                //OPCIÓN ELEGIDA
                switch (teclaLeida.KeyChar)                                 //SEGÚN LA TECLA PULSADA
                {
                    case '0':                                               //OPCION PARA SALIR
                        noSalir = false;                                    //PONE A FALSE EL BOOLEANO QUE MANTIENE EL BUCLE DEL MENÚ
                        Console.SetCursorPosition(Console.CursorLeft - 16, Console.CursorTop + 3);
                        Console.Write("Saliendo");
                        Thread.Sleep(400);
                        Console.Write(".");
                        Thread.Sleep(400);
                        Console.Write(".");
                        Thread.Sleep(400);
                        Console.Write(".");
                        break;
                    case '1':                                                       //OPCIÓN ALTAS
                        Console.Clear();
                        Console.WriteLine("Has seleccionado ALTAS. ");
                        Console.ReadLine();
                        break;
                    case '2':                                                       //OPCIÓN BAJAS
                        Console.Clear();
                        Console.WriteLine("Has seleccionado BAJAS. ");
                        Console.ReadLine();
                        break;
                    case '3':                                                       //OPCIÓN MODIFICACIONES
                        Console.Clear();
                        Console.WriteLine("Has seleccionado MODIFICACIONES. ");
                        Console.ReadLine();
                        break;
                    case '4':                                                       //OPCIÓN CONSULTAS
                        Console.Clear();
                        Console.WriteLine("Has seleccionado CONSULTAS. ");          
                        Console.ReadLine();
                        break;
                    default:                                                        //EN CASO DE PULSAR CUALQUIER OTRA TECLA
                        int posIzq = Console.CursorLeft;
                        int posAlto = Console.CursorTop;
                        Console.CursorTop += 4;
                        Console.WriteLine("Por favor, opciones entre 1 y 4, 0 para salir. ");
                        Console.SetCursorPosition(posIzq, posAlto);
                        Console.ReadLine();
                        break;
                }
            } while (noSalir);                                                      //MIENTRAS NO SE PULSE 0 EN EL MENÚ NO CAMBIA LA VARIABLE noSalir DE TRUE A FALSE
        }

        private static void LimpiaYPintaMenuPrincipal()
        {
            Console.Clear();
            PintaOpciones("MENU PRINCIPAL", new string[] { "Altas","Bajas","Modificaciones","Consultas" }, ConsoleColor.Red, ConsoleColor.Yellow);
        }

        private static void PintaMarco(int posicionXIzqSup, int posicionYIzqSup, int posicionXDerInf, int posicionYDerInf)
        {
            int ancho = posicionXDerInf - posicionXIzqSup;
            int alto = posicionYDerInf - posicionYIzqSup;
            //PINTA ESQUINA SUPERIOR IZQUIERDA
            Console.Write("╔");
            //PINTA BORDE SUPERIOR
            for (int i = 0; i < ancho - 1; i++)
            {
                Console.Write("═");                         //X --> POSICIÓN LATERAL        Y --> POSICIÓN VERTICAL
            }                                               //Coordenada1 --> X      (0,0)╔════════════════════════╗
            //PINTA ESQUINA SUPERIOR DERECHA                //Coordenada1 --> Y           ║        TITULO          ║    <-- TITULO
            Console.WriteLine("╗");                         //Coordenada2 --> Y           ╠════════════════════════╣        string[] opciones
            //PINTA LATERAL IZQUIERDO 1                     //                            ║   1. Opcion1           ║    <-- opciones[0]
            Console.WriteLine("║");                         //                            ║   2. Opcion2           ║    <-- opciones[1]
            Console.WriteLine("╠");                         //                            ╠════════════════════════╣
            //PINTA LATERAL IZQUIERDO 2                     //                            ║        elegir:_        ║    <-- introducir opción
            for (int i = 0; i < alto - 5; i++)              //                            ╚════════════════════════╝(7,25)
            {                                               //                              ancho= 25;
                Console.WriteLine("║");                     //                              alto=  7;
            }                                               //                              altoNoUtil= 4; (4 bordes separadores)
            //PINTAL LATERAL IZQUIERDO 3
            Console.WriteLine("╠");
            Console.WriteLine("║");
            //PINTA ESQUINA INFERIOR IZQUIERDA                                              anchoNoUtil=3; (1x2 bordes laterales + 1 espacio antes de escribir)
            Console.Write("╚");
            //PINTA BORDE INFERIOR
            for (int i = 0; i < ancho - 1; i++)
            {
                Console.Write("═");
            }
            //PINTA ESQUINA INFERIOR DERECHA
            Console.Write("╝");
            //PINTA LATERAL DERECHO 1
            Console.SetCursorPosition(posicionXDerInf, posicionYIzqSup + 1);
            Console.WriteLine("║");
            Console.CursorLeft = posicionXDerInf;
            Console.WriteLine("╣");
            Console.CursorLeft = posicionXDerInf;
            //PINTA LATERAL DERECHO 2
            for (int i = 0; i < alto - 5; i++)
            {
                Console.WriteLine("║");
                Console.CursorLeft = posicionXDerInf;
            }
            //PINTA LATERAL DERECHO 3
            Console.WriteLine("╣");
            Console.CursorLeft = posicionXDerInf;
            Console.WriteLine("║");
            //PINTA SEPARADOR TITULO-OPCIONES
            Console.SetCursorPosition(1, 2);
            for (int i = 0; i < ancho - 1; i++)
            {
                Console.Write("═");
            }
            //PINTA SEPARADOR OPCIONES-ELEGIR
            Console.SetCursorPosition(1, 2 + alto - 4);
            for (int i = 0; i < ancho - 1; i++)
            {
                Console.Write("═");
            }

        }
        public static void PintaOpciones(string titulo, string[] opciones, ConsoleColor marco, ConsoleColor texto)
        {
            int nOpciones = opciones.Length;
            int opcionMasLarga = 13;
            foreach (string opcion in opciones)
            {
                if (opcion.Length > opcionMasLarga)
                {
                    opcionMasLarga = opcion.Length;
                }
            }
            int anchoMenu = opcionMasLarga + 5;
            int largoMenu = nOpciones + 5;
            Console.ForegroundColor = marco;
            PintaMarco(0, 0, anchoMenu, largoMenu);
            Console.ForegroundColor = texto;
            PintaLetras(titulo, opciones);

        }
        private static void PintaLetras(string titulo, string[] opciones)
        {

            Console.SetCursorPosition(2, 1);
            Console.Write(titulo);
            Console.SetCursorPosition(2, 3);
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + opciones[i]);
                Console.CursorLeft = 2;
            }
            Console.SetCursorPosition(1, opciones.Length + 6);
            Console.WriteLine("Pulse 0 para salir");
            Console.SetCursorPosition(2, 2 + opciones.Length + 2);
            Console.Write("Elige opción: ");
        }
    }
}
