/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    RelojDigital
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación muestra un reloj digital
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Threading;

namespace App_R4E01_RelojDigital
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  //FORMA SENCILLA
            while (true)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine(DateTime.Now.ToLocalTime().ToString().Substring(11));
            }*/

            //DE FORMA MÁS COMPLEJA
            const int MAX_HOURS = 24;
            const int MAX_MINUTES = 60;
            const int MAX_SECONDS = 60;
            const int MILLISECONDS_SECOND = 1000;
            Console.CursorVisible = false;
            PintaOpciones(" RELOJ DIGITAL", new string[]{""}, ConsoleColor.Red, ConsoleColor.Yellow);
            while (true)
                for (int i = DateTime.Now.Hour; i < MAX_HOURS; i++)
                    for (int j = DateTime.Now.Minute ; j < MAX_MINUTES; j++)
                        for (int k = DateTime.Now.Second; k < MAX_SECONDS; k++)
                        {
                            Console.SetCursorPosition(5,3);
                            Console.WriteLine("{0:D2}:{1:D2}:{2:D2}", i, j, k);
                            Thread.Sleep(MILLISECONDS_SECOND);
                        }
        }

        /*MÉTODOS QUE OBTIENEN LA HORA, LOS MINUTOS Y LOS SEGUNDOS PARA INICIAR EL RELOJ
          EXISTE UN PROPIEDAD QUE OBTIENE HORA, MINUTOS, SEGUNDOS,...(DESECHADO)
        
        private static int getHour()
        {
            int hour;
            string dateTime = DateTime.Now.ToLocalTime().ToString().Substring(11,2);
            hour = int.Parse(dateTime);
            return hour;
        }
        private static int getMinute()
        {
            int minute;
            string fechaHora = DateTime.Now.ToLocalTime().ToString().Substring(14, 2);
            minute = int.Parse(fechaHora);
            return minute;
        }
        private static int getSecond()
        {
            int second;
            string fechaHora = DateTime.Now.ToLocalTime().ToString().Substring(17, 2);
            second = int.Parse(fechaHora);
            return second;
        }
        */

        //MÉTODO DE LA RELACIÓN 3 EJERCICIO 5 PARA PINTAR EL MARCO (RETOCADO)
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

            //PINTA SEPARADOR TITULO-OPCIONES
            Console.SetCursorPosition(1, 2);
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
                Console.WriteLine(opciones[i]);
                Console.CursorLeft = 2;
            }
            
        }
    }
}
