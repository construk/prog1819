using System;
using System.Threading;

namespace App_R3E5_MenuAreas
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
                switch (teclaLeida.KeyChar)     //SEGÚN LA TECLA PULSADA
                {
                    case '0':                                               //OPCION PARA SALIR
                        noSalir = false;                                    //PONE A FALSE EL BOOLEANO QUE MANTIENE EL BUCLE DEL MENÚ
                        Console.SetCursorPosition(Console.CursorLeft-16, Console.CursorTop+3); //POSICIONA PARA INDICACIÓN DE QUE EL PROGRAMA ESTÁ ACABANDO
                        Console.Write("Saliendo");                          //ESCRIBE
                        Thread.Sleep(400);                                  //PAUSA
                        Console.Write(".");                                 //ESCRIBE
                        Thread.Sleep(400);                                  //PAUSA
                        Console.Write(".");                                 //ESCRIBE
                        Thread.Sleep(400);                                  //PAUSA
                        Console.Write(".");                                 //ESCRIBE
                        break;
                    case '1':                                               //OPCIÓN CALCULAR AREA CUADRADO
                        double ladoCuadrado;
                        string ladoString;
                        MenuAreaCuadrado();
                        ladoString = Console.ReadLine();
                        while (!double.TryParse(ladoString,out ladoCuadrado))
                        {
                            MenuAreaCuadrado();
                            ladoString = Console.ReadLine();
                        }
                        Console.CursorLeft += 1;
                        Console.WriteLine("El área de un cuadrado es: "+ladoCuadrado*ladoCuadrado);
                        Console.CursorLeft += 2;
                        Console.CursorTop += 2;
                        Console.WriteLine("Pulse cualquier tecla para volver al menú principal");
                        Console.CursorVisible = false;
                        while (!Console.KeyAvailable) { }
                        break;
                    case '2':                                                   //OPCIÓN CALCULAR AREA RECTÁNGULO
                        double ladoA;
                        double ladoB;
                        string ladoAString;
                        string ladoBString;
                        int posX;
                        int posY;
                        MenuAreaRectanguloA();
                        ladoAString = Console.ReadLine();
                        while (!double.TryParse(ladoAString, out ladoA))
                        {
                            MenuAreaRectanguloA();
                            ladoAString = Console.ReadLine();
                        }
                        MenuAreaRectanguloB();
                        posX = Console.CursorLeft;
                        posY = Console.CursorTop;
                        ladoBString = Console.ReadLine();
                        while (!double.TryParse(ladoBString, out ladoB))
                        {
                            Console.SetCursorPosition(posX, posY);
                            Console.Write(" ");
                            Console.SetCursorPosition(posX, posY);
                            ladoBString = Console.ReadLine();
                        }
                        Console.CursorLeft += 1;
                        Console.WriteLine("El área de un rectangulo es: " + ladoB * ladoA);
                        Console.CursorLeft += 2;
                        Console.CursorTop += 2;
                        Console.WriteLine("Pulse cualquier tecla para volver al menú principal");
                        Console.CursorVisible = false;
                        while (!Console.KeyAvailable) { }
                        break;
                    case '3':                                                       //OPCIÓN CALCULAR AREA TRIÁNGULO
                        double _base;
                        double altura;
                        string baseString;
                        string alturaString;
                        MenuAreaTrianguloA();
                        baseString = Console.ReadLine();
                        while (!double.TryParse(baseString, out _base))
                        {
                            MenuAreaRectanguloA();
                            baseString = Console.ReadLine();
                        }
                        MenuAreaTrianguloB();
                        posX = Console.CursorLeft;
                        posY = Console.CursorTop;
                        alturaString = Console.ReadLine();
                        while (!double.TryParse(alturaString, out altura))
                        {
                            Console.SetCursorPosition(posX, posY);
                            Console.Write(" ");
                            Console.SetCursorPosition(posX, posY);
                            alturaString = Console.ReadLine();
                        }
                        Console.CursorLeft += 1;
                        Console.WriteLine("El área de un triangulo es: " + _base*altura/2);
                        Console.CursorLeft += 2;
                        Console.CursorTop += 2;
                        Console.WriteLine("Pulse cualquier tecla para volver al menú principal");
                        Console.CursorVisible = false;
                        while (!Console.KeyAvailable) { }
                        break;
                    default:
                        break;
                }
            } while (noSalir);                                                      //MIENTRAS NO SE PULSE 0 EN EL MENÚ NO CAMBIA LA VARIABLE noSalir DE TRUE A FALSE
        }
        private static void MenuAreaCuadrado() //METODO QUE PINTA EL MENÚ QUE CALCULA EL ÁREA DEL CUADRADO      
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            PintaMarco(0, 0, 80, 20);
            Console.SetCursorPosition(2, 1);
            Console.WriteLine("CALCULAR EL ÁREA DE UN CUADRADO");
            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop + 1);
            Console.Write("Introduce el lado del cuadrado: "); 
        }
        private static void MenuAreaRectanguloA() 
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            PintaMarco(0, 0, 80, 20);
            Console.SetCursorPosition(2, 1);
            Console.WriteLine("CALCULAR EL ÁREA DE UN RECTÁNGULO");
            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop + 1);
            Console.Write("Introduce el lado A del rectángulo: ");
        }
        private static void MenuAreaRectanguloB()
        {
            Console.CursorLeft=Console.CursorLeft + 1;
            Console.Write("Introduce el lado B del rectángulo: ");
        }
        private static void MenuAreaTrianguloA()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            PintaMarco(0, 0, 80, 20);
            Console.SetCursorPosition(2, 1);
            Console.WriteLine("CALCULAR EL ÁREA DE UN TRIÁNGULO");
            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop + 1);
            Console.Write("Introduce la base del triángulo: ");
        }
        private static void MenuAreaTrianguloB()
        {
            Console.CursorLeft = Console.CursorLeft + 1;
            Console.Write("Introduce la altura del triángulo: ");
        }
        private static void LimpiaYPintaMenuPrincipal()
        {
            Console.Clear();
            PintaOpciones("CALCULAR ÁREAS", new string[] { "Calcular area cuadrado", "Calcular area rectangulo", "Calcular area triangulo" }, ConsoleColor.Red, ConsoleColor.Yellow);
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
            for (int i = 0; i < ancho-1; i++)
            {
                Console.Write("═");
            }
            //PINTA SEPARADOR OPCIONES-ELEGIR
            Console.SetCursorPosition(1, 2 + alto - 4);
            for (int i = 0; i < ancho-1; i++)
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
                if (opcion.Length>opcionMasLarga)
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
                Console.WriteLine(i+1+". "+opciones[i]);
                Console.CursorLeft = 2;
            }
            Console.SetCursorPosition(1, opciones.Length + 6);
            Console.WriteLine("Pulse 0 para salir");
            Console.SetCursorPosition(2, 2 + opciones.Length + 2);
            Console.Write("Elige opción: ");
        }
    }
}
