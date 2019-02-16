/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		MenuCesar
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Menú que puedes controlar el número de desplazamiento en la encriptación e introducir el texto que quieras
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Threading;

namespace App_R5E8_MenuCesar
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo teclaLeida = new ConsoleKeyInfo();   //TECLA INTRODUCIDA POR EL USUARIO QUE SE OBTENDRÁ EL CARACTER INTRODUCIDO
            int opcionInt;                                      //OPCIÓN INTRODUCIDA POR EL USUARIO DE TIPO INT QUE COMPRUEBA QUE SEA UN NÚMERO LO QUE INTRODUCE
            bool noSalir = true;
            string elegidaString = teclaLeida.KeyChar.ToString();       //SE TRANSFORMA A STRING PORQUE NO EXISTE SOBRECARGA PARA TIPO CHAR PARA MÉTODO TRYPARSE
            string texto;
            int desplazamiento = 0;
            string auxiliar;

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
                        Console.SetCursorPosition(Console.CursorLeft - 16, Console.CursorTop + 3);
                        Console.Write("Saliendo");
                        Thread.Sleep(400);
                        Console.Write(".");
                        Thread.Sleep(400);
                        Console.Write(".");
                        Thread.Sleep(400);
                        Console.Write(".");
                        break;
                    case '1':                                               //OPCIÓN ENCRIPTAR
                        Console.Clear();
                        //INTRODUCIR TEXTO
                        Console.WriteLine("Introduce un texto y encriptalo a Cesar con un desplazamiento determinado");
                        Console.Write("Introduce texto: ");
                        texto = Console.ReadLine();
                        
                        //INTRODUCIR CANTIDAD
                        Console.Write("Introduce cantidad de desplazamiento (máximo 25): ");
                        auxiliar = Console.ReadLine();
                        while (!int.TryParse(auxiliar,out desplazamiento)||desplazamiento>25)
                        {
                            Console.Write("Introduce un número válido: ");
                            auxiliar = Console.ReadLine();
                        }
                        
                        //ENCRIPTAR TEXTO Y MOSTRAR
                        Console.WriteLine(EncriptaCesar(texto,desplazamiento));
                        Console.WriteLine("Pulsa ENTER para volver al menú");
                        Console.ReadLine();
                        break;
                    case '2':                                               //OPCIÓN DESENCRIPTAR
                        Console.Clear();
                        //INTRODUCIR TEXTO
                        Console.WriteLine("Introduce un texto y desencriptalo de Cesar con un desplazamiento determinado");
                        Console.Write("Introduce texto: ");
                        texto = Console.ReadLine();

                        //INTRODUCIR CANTIDAD
                        Console.Write("Introduce cantidad de desplazamiento (máximo 25): ");
                        auxiliar = Console.ReadLine();
                        while (!int.TryParse(auxiliar, out desplazamiento) || desplazamiento > 25)
                        {
                            Console.Write("Introduce un número válido: ");
                            auxiliar = Console.ReadLine();
                        }

                        //DESENCRIPTAR TEXTO Y MOSTRAR
                        Console.WriteLine(DesencriptaCesar(texto, desplazamiento));
                        Console.WriteLine("Pulsa ENTER para volver al menú");
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            } while (noSalir);                                                      //MIENTRAS NO SE PULSE 0 EN EL MENÚ NO CAMBIA LA VARIABLE noSalir DE TRUE A FALSE
        }
        #region MÉTODOS
        #region PINTA MENU
        private static void LimpiaYPintaMenuPrincipal()
        {
            Console.Clear();
            PintaOpciones("ENCRIPTACIÓN CESAR", new string[] { "Realizar encriptación Cesar","Realizar desencriptación Cesar" }, ConsoleColor.Red, ConsoleColor.Yellow);
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
        #endregion
        #region CESAR
        /// <summary>
        /// Encripta con el algoritmo de Cesar
        /// </summary>
        /// <param name="texto">Texto a encriptar</param>
        /// <param name="desplazarCaracter">Número de caracteres a desplazar</param>
        /// <returns>Devuelve string encriptado</returns>
        public static string EncriptaCesar(string texto, int desplazarCaracter)
        {
            //CONSTANTES
            const int RANGO_CARACTERES = 'Z' - 'A';
            const int PRIMER_CARACTER_MAYUS = 'A';
            const int PRIMER_CARACTER_MINUS = 'a';

            string resultado = "";    //VARIABLE

            //RECORRE LA PALABRA CARACTER A CARACTER
            for (int i = 0; i < texto.Length; i++)
            {
                //SE ENCRIPTA DE LA 'A' A LA 'Z' MAYÚSCULA
                if (texto[i] >= 'A' && texto[i] <= 'Z')
                {
                    resultado += (char)(PRIMER_CARACTER_MAYUS + (texto[i] + desplazarCaracter - PRIMER_CARACTER_MAYUS) % (RANGO_CARACTERES + 1));
                }
                //SE ENCRIPTA DE LA 'A' A LA 'Z' MINÚSCULA
                else if (texto[i] >= 'a' && texto[i] <= 'z')
                {
                    resultado += (char)(PRIMER_CARACTER_MINUS + (texto[i] + desplazarCaracter - PRIMER_CARACTER_MINUS) % (RANGO_CARACTERES + 1));
                }
                //SI NO ES NINGUNA DE LAS ANTERIOR ESCRIBE EL CARACTER TAL CUAL
                else
                {
                    resultado += texto[i];
                }
            }
            return resultado;   //DEVUELVE EL STRING CON EL RESULTADO
        }
        /// <summary>
        /// Desencripta con el algoritmo de Cesar
        /// </summary>
        /// <param name="texto">Texto a desencriptar</param>
        /// <param name="desplazarCaracter">Número de caracteres desplazados en la codificación</param>
        /// <returns>Devuelve string desencriptado</returns>
        public static string DesencriptaCesar(string texto, int desplazarCaracter)
        {
            //CONSTANTES
            const int PRIMER_CARACTER_MAYUS = 'A';
            const int ULTIMO_CARACTER_MAYUS = 'Z';
            const int PRIMER_CARACTER_MINUS = 'a';
            const int ULTIMO_CARACTER_MINUS = 'z';

            string resultado = "";      //VARIABLE

            //RECORRE LA PALABRA CARACTER A CARACTER
            for (int i = 0; i < texto.Length; i++)
            {
                //SE CONTROLA DESDE LA LETRA CORRESPONDIENTE INCLUIDA A LA 'Z' EN MINÚSCULAS Y MAYÚSCULAS
                if (texto[i] >= ('A' + desplazarCaracter) && texto[i] <= 'Z')
                    resultado += (char)(texto[i] - desplazarCaracter);
                else if (texto[i] >= ('a' + desplazarCaracter) && texto[i] <= 'z')
                    resultado += (char)(texto[i] - desplazarCaracter);
                //SE CONTROLA LOS CASOS DESDE LA 'A' HASTA LA LETRA CORRESPONDIENTE EXCLUIDA EN MINÚSCULAS Y MAYÚSCULAS
                else if (texto[i] >= 'A' && texto[i] < (char)('A' + desplazarCaracter))
                    resultado += (char)(texto[i] - PRIMER_CARACTER_MAYUS + ULTIMO_CARACTER_MAYUS - desplazarCaracter + 1);
                else if (texto[i] >= 'a' && texto[i] < (char)('a' + desplazarCaracter))
                    resultado += (char)(texto[i] - PRIMER_CARACTER_MINUS + ULTIMO_CARACTER_MINUS - desplazarCaracter + 1);
                //SI NO ES NINGUNA DE LAS ANTERIOR ESCRIBE EL CARACTER TAL CUAL
                else
                    resultado += texto[i];
            }
            return resultado;   //DEVUELVE EL STRING CON EL RESULTADO
        }
        #endregion
        #endregion
    }
}
