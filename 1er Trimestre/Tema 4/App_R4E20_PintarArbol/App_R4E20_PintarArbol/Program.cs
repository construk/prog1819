/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    PintarArbol
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación pinta un arbol, el cielo y una pradera con flores
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E20_PintarArbol
{
    class Program
    {
        static void Main(string[] args)
        {
            //CONSTANTE Y VARIABLE
            const int POSICION_ESCRIBIR = 57;
            int altura=-1;

            //PINTAR DE AZUL EL FONDO
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Clear();

            //HACER MIENTRAS EL NÚMERO SEA DISTINTO DE 0
            do
            {
                Console.ForegroundColor = ConsoleColor.Black;   //CAMBIAMOS PARA PINTAR LAS LETRAS EN NEGRO
                Console.CursorLeft = POSICION_ESCRIBIR;         //POSICIÓN PARA NO PINTAR SOBRE EL ARBOL
                Console.CursorVisible = true;                   //OCULTAMOS CURSOR

                Console.WriteLine("Este programa pinta un arbol (altura max: 28, min: 5)");
                try
                {
                    Console.CursorLeft = POSICION_ESCRIBIR; //POSICIÓN PARA NO PINTAR SOBRE EL ARBOL
                    Console.Write("Introduce altura (0 para salir): ");
                    altura = int.Parse(Console.ReadLine()); //INTRODUCE ALTURA
                }
                catch (Exception e)
                {
                    Console.CursorLeft = POSICION_ESCRIBIR; //POSICIÓN PARA NO PINTAR SOBRE EL ARBOL
                    Console.WriteLine(e.Message);           //MENSAJE DE EXCEPCIÓN
                    Console.CursorLeft = POSICION_ESCRIBIR;
                    Console.WriteLine("Pulse ENTER para continuar...");
                    Console.CursorLeft = POSICION_ESCRIBIR;
                    Console.ReadLine();
                }
                if (altura != 0)                            //SI NO SALE QUE PINTE EL ARBOL, SINO QUE NO LO PINTE
                    PintaArbol(altura, POSICION_ESCRIBIR);  //PINTA EL ARBOL
                Console.CursorVisible = false;              //OCULTAR CURSOR
                Console.BackgroundColor = ConsoleColor.Cyan;//DEJA EL COLOR DE FONDO COMO ESTABA
            } while (altura != 0);
        }

        /// <summary>
        /// Función que te devuelve un arbol junto a más decoración
        /// </summary>
        /// <param name="altura">Indica la altura del arbol (min 5, max 28)</param>
        /// <param name="posicionMensaje">Indica la posición donde se situarán los mensajes para evitar cortar el arbol</param>
        public static void PintaArbol(int altura, int posicionMensaje)
        {
            //CONSTANTES
            const int ALTURA_MINIMA = 5;
            const int ALTURA_MAXIMA = 28;
        
            //VARIABLES
            int posicionaCursorAux = 2;
            int recorre = 1;
            int posicionTronco = altura - 2;
            int alturaRamas = altura - 1;
            Console.CursorVisible = false;                  //PROPIEDAD QUE OCULTA EL CURSOR

            //PINTAR ARBOL Y DECORADO
            if (altura<ALTURA_MINIMA||altura>ALTURA_MAXIMA) //SI ES MAYOR LA ALTURA INTRODUCIDA A LA MÁXIMA O MENOR A LA MÍNIMA
            {
                Console.CursorLeft = posicionMensaje;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Altura no válida");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else                                            //SI ES VÁLIDO EL NÚMERO PINTARÁ LO INDICADO
            {
                //PINTAR CIELO CIAN
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Clear();

                //PINTAR RAMAS VERDES
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Green;
                for (int i=1;i<=alturaRamas;i++)        //ESCRIBIR EN CADA RAMA
                {
                    Console.CursorLeft=altura - posicionaCursorAux;
                    for (int j = 1; j <=recorre; j++)   //ESCRIBIR EN CADA POSICIÓN
                    {
                        Console.Write('*');             //ESCRIBIR EL CARACTER PEDIDO
                    }
                    Console.WriteLine("");              //SALTO DE LINEA PARA SIGUIENTE RAMA
                    recorre += 2;                       //AUMENTAMOS EN DOS LA CANTIDAD DE PUNTOS A PINTAR PARA LA PRÓXIMA VEZ
                    posicionaCursorAux++;               //AUMENTAMOS EL CONTADOR DE LAS LINEAS QUE SIRVE PARA POSICIONAR EL CURSOR
                }

                //PINTAR EL TRONCO MARRON (ROJO OSCURO)
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.CursorLeft = posicionTronco;                        //POSICIONO EL TRONCO EN LA PARTE CENTRAL DEL ARBOL
                Console.WriteLine('*');                                     //PINTA EL TRONCO

                //PINTAR SUELO MARRON (ROJO OSCURO)
                Console.ForegroundColor = ConsoleColor.Yellow;              //PARA PINTAR FLORES
                for (int i = 0; i < Console.WindowWidth; i++)               //PINTAR LINEA DE TIERRA     
                {
                    if (i%2==0)                                             //ALTERNAR COLOR DE FLORES
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    else
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("*");                                     //PINTAR FLORES Y SUELO
                }
                //PINTAR FLORES Y SUELO VERDE
                Console.ForegroundColor = ConsoleColor.Yellow;              //PINTAR FLORES
                Console.BackgroundColor = ConsoleColor.DarkGreen;           //PINTAR PRADERA
                for (int i = 0; i < Console.WindowWidth * 30; i++)          //PINTAR 30 LINEAS DE PRADERA
                {
                    if (i % 2 == 0)                                         //ALTERNAR COLOR DE FLORES
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("*");                                     //PINTAR FLORES Y SUELO
                }
                Console.SetCursorPosition(0, 0);                            //POSICIONA AL PRINCIPIO PARA VER CORRECTAMENTE
                Console.CursorVisible = true;                               //RECUPERA LA VISIÓN DEL CURSOR
            }
        }

        /// <summary>
        /// Función que te devuelve un arbol junto a más decoración
        /// </summary>
        /// <param name="altura">Indica la altura del arbol (min 5, max 28)</param>
        public static void PintaArbol(int altura)
        {
            //CONSTANTES
            const int ALTURA_MINIMA = 5;
            const int ALTURA_MAXIMA = 28;

            //VARIABLES
            int posicionaCursorAux = 2;
            int recorre = 1;
            int posicionTronco = altura - 2;
            int alturaRamas = altura - 1;
            Console.CursorVisible = false;                      //PROPIEDAD QUE OCULTA EL CURSOR

            //PINTAR ARBOL Y DECORADO
            if (altura < ALTURA_MINIMA || altura > ALTURA_MAXIMA)   //SI ES MAYOR LA ALTURA INTRODUCIDA A LA MÁXIMA O MENOR A LA MÍNIMA
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Altura no válida");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else                                                    //SI ES VÁLIDO EL NÚMERO PINTARÁ LO INDICADO
            {
                //PINTAR CIELO CIÁN
                Console.BackgroundColor = ConsoleColor.Cyan;    //COLOR CIELO
                Console.Clear();

                //PINTAR RAMAS VERDES
                Console.ForegroundColor = ConsoleColor.Green;   //COLOR RAMAS ARBOL
                Console.BackgroundColor = ConsoleColor.Green;   //COLOR RAMAS ARBOL
                for (int i = 1; i <= alturaRamas; i++)  //ESCRIBIR EN CADA RAMA
                {
                    Console.CursorLeft = altura - posicionaCursorAux;
                    for (int j = 1; j <= recorre; j++)  //ESCRIBIR EN CADA POSICIÓN
                    {
                        Console.Write('*');             //ESCRIBIR EL CARACTER PEDIDO
                    }
                    Console.WriteLine("");              //SALTO DE LINEA PARA SIGUIENTE RAMA
                    recorre += 2;                       //AUMENTAMOS EN DOS LA CANTIDAD DE PUNTOS A PINTAR PARA LA PRÓXIMA VEZ
                    posicionaCursorAux++;               //AUMENTAMOS EL CONTADOR DE LAS LINEAS QUE SIRVE PARA POSICIONAR EL CURSOR
                }

                //PINTAR EL TRONCO MARRON (ROJO OSCURO)
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.CursorLeft = posicionTronco;                        //POSICIONO EL TRONCO EN LA PARTE CENTRAL DEL ARBOL
                Console.WriteLine('*');                                     //PINTA EL TRONCO

                //PINTAR SUELO MARRON (ROJO OSCURO)
                Console.ForegroundColor = ConsoleColor.Yellow;              //PARA PINTAR FLORES
                for (int i = 0; i < Console.WindowWidth; i++)               //PINTAR LINEA DE TIERRA     
                {
                    if (i % 2 == 0)                                         //ALTERNAR COLOR DE FLORES
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    else
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("*");                                     //PINTAR FLORES Y SUELO
                }

                //PINTAR FLORES Y SUELO VERDE
                Console.ForegroundColor = ConsoleColor.Yellow;              //PINTAR FLORES
                Console.BackgroundColor = ConsoleColor.DarkGreen;           //PINTAR PRADERA
                for (int i = 0; i < Console.WindowWidth * 30; i++)          //PINTAR 30 LINEAS DE PRADERA
                {
                    if (i % 2 == 0)                                         //ALTERNAR COLOR DE FLORES
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("*");                                     //PINTAR FLORES Y SUELO
                }
                Console.SetCursorPosition(0, 0);                            //POSICIONA AL PRINCIPIO PARA VER CORRECTAMENTE
                Console.CursorVisible = true;                               //RECUPERA LA VISIÓN DEL CURSOR
                Console.BackgroundColor = ConsoleColor.Black;               //DEVUELVE LOS COLORES ORIGINALES DE LA CONSOLA
                Console.ForegroundColor = ConsoleColor.White;               //DEVUELVE LOS COLORES ORIGINALES DE LA CONSOLA
            }
        }
    }
}
