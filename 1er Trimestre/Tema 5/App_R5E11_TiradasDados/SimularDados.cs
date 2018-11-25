/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		TiradasDados
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Programa que permite simular la tirada de dados y mostrar los resultados con sus respectivos porcentajes
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R5E11_TiradasDados
{
    class SimularDados
    {
        #region VARIABLES ESTÁTICAS
        public static int nVecesTotal;
        public static int nVeces1;
        public static int nVeces2;
        public static int nVeces3;
        public static int nVeces4;
        public static int nVeces5;
        public static int nVeces6;
        #endregion
        static void Main(string[] args)
        {
            Random random = new Random();                   //SEMILLA PARA ALEATORIOS
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();    //TECLA PULSADA
            Console.CursorVisible = false;                  //PONER INVISIBLE EL CURSOR
            do
            {
                Console.Clear();                            //LIMPIAR CONSOLA
                PintaResultado();                           //PINTAR LOS RESULTADOS
                PintaOpciones();                            //PINTAR OPCIONES DEL MENU
                tecla = Console.ReadKey(true);              //LEER LA TECLA (Y SIN QUE SE VEA)
                switch (tecla.KeyChar)
                {
                    case '1':                               //SI PULSAS 1 --> TIRAR EL DADO 1 VEZ
                        TirarDado(random);
                        break;
                    case '2':                               //SI PULSAS 2 --> TE PREGUNTA CUANTAS VECES LO QUIERES TIRAR Y LO TIRAS
                        TirarNVecesDado(IntroduceDato(), random);
                        break;
                    default:                                //SINO NO HACE NADA
                        break;
                }
            } while (tecla.KeyChar!='0');                   //MIENTRAS LA TECLA PULSADA NO SEA 0 NO SALES DEL PROGRAMA
        }
        /// <summary>
        /// Método que sirve para preguntar el número de tiradas
        /// </summary>
        /// <returns>Devuelve el número de tiradas introducidas por el usuario</returns>
        public static int IntroduceDato()
        {
            string auxiliar;
            int numero;
            Console.Write("\nIntroduce nº de tiradas: ");
            auxiliar = Console.ReadLine();
            while (!int.TryParse(auxiliar,out numero))
            {
                Console.Write("Introduce un número de tiradas válidos: ");
                auxiliar = Console.ReadLine();
            }
            return numero;
        }
        /// <summary>
        /// Pinta en pantalla el resultado de las variables estáticas
        /// </summary>
        public static void PintaResultado()
        {
            Console.WriteLine("                RESULTADO");
            Console.WriteLine("=======================================");
            Console.WriteLine("TOTAL TIRADAS: {0}", nVecesTotal);
            if (nVecesTotal == 0)
            {
                Console.WriteLine("Veces el número 1: {0} --> 0%", nVeces1);
                Console.WriteLine("Veces el número 2: {0} --> 0%", nVeces2);
                Console.WriteLine("Veces el número 3: {0} --> 0%", nVeces3);
                Console.WriteLine("Veces el número 4: {0} --> 0%", nVeces4);
                Console.WriteLine("Veces el número 5: {0} --> 0%", nVeces5);
                Console.WriteLine("Veces el número 6: {0} --> 0%", nVeces6);
                Console.WriteLine("=======================================");
            }
            else
            {
                Console.WriteLine("Veces el número 1: {0} --> {1:F2}%", nVeces1, (double)nVeces1 / nVecesTotal*100);
                Console.WriteLine("Veces el número 2: {0} --> {1:F2}%", nVeces2, (double)nVeces2 / nVecesTotal*100);
                Console.WriteLine("Veces el número 3: {0} --> {1:F2}%", nVeces3, (double)nVeces3 / nVecesTotal*100);
                Console.WriteLine("Veces el número 4: {0} --> {1:F2}%", nVeces4, (double)nVeces4 / nVecesTotal*100);
                Console.WriteLine("Veces el número 5: {0} --> {1:F2}%", nVeces5, (double)nVeces5 / nVecesTotal*100);
                Console.WriteLine("Veces el número 6: {0} --> {1:F2}%", nVeces6, (double)nVeces6 / nVecesTotal*100);
                Console.WriteLine("=======================================");
            }
        }
        /// <summary>
        /// Pinta las opciones del menú
        /// </summary>
        public static void PintaOpciones()
        {
            Console.WriteLine("Pulse 1 - Para realizar una tirada");
            Console.WriteLine("Pulse 2 - Para introducir el número de tiradas a realizar");
            Console.WriteLine("Pulse 0 - Para salir");
        }
        /// <summary>
        /// Simular la tirada de un dado un número determinado de veces
        /// </summary>
        /// <param name="nVeces">Número de tiradas a realizar</param>
        /// <param name="rnd">Semilla del aleatorio</param>
        public static void TirarNVecesDado(int nVeces, Random rnd)
        {
            for (int i = 0; i < nVeces; i++)
                TirarDado(rnd);
        }
        /// <summary>
        /// Simular la tirada de un dado
        /// </summary>
        /// <param name="rnd">Semilla del aleatorio</param>
        public static void TirarDado(Random rnd)
        {
            int resultadoDado = rnd.Next(6);
            resultadoDado++;
            nVecesTotal++;
            switch (resultadoDado)
            {
                case 1:
                    nVeces1++;
                    break;
                case 2:
                    nVeces2++;
                    break;
                case 3:
                    nVeces3++;
                    break;
                case 4:
                    nVeces4++;
                    break;
                case 5:
                    nVeces5++;
                    break;
                case 6:
                    nVeces6++;
                    break;
                default:
                    break;
            }
        }
    }
}
