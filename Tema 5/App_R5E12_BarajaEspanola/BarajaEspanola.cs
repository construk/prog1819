/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		BarajaEspanola
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Este programa genera una baraja de cartas española y extrae carta a carta aleatoriamente hasta que se quede vacia, luego pregunta si ejecuta de nuevo o no.
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace App_R5E12_BarajaEspanola
{   
    /// <summary>
    /// Clase que contiene las estructuras Carta, Baraja y el método Main que las prueba
    /// </summary>
    class BarajaEspanola
    {
        /// <summary>
        /// Estructura Carta que almacena peso, nombre del peso, y el palo que contiene dicha carta.
        /// </summary>
        public struct Carta
        {
            #region CAMPOS
            int peso;
            string nombrePeso;
            string palo;
            #endregion
            #region Propiedades
            public int Peso
            {
                get { return peso; }
                set { peso = value; }
            }
            public string NombrePeso
            {
                get { return nombrePeso; }
                set { nombrePeso = value; }
            }
            public string Palo
            {
                get { return palo; }
                set { palo = value; }
            }
            #endregion
            public override string ToString() //MÉTODO ToString() DE CARTA
            {
                return NombrePeso + " de " + Palo;
            }
        }
        /// <summary>
        /// Estructura Baraja que almacena una lista con las cartas que contiene la baraja.
        /// </summary>
        public struct Baraja
        {
            #region VALORES BARAJA ESPAÑOLA ORIGINAL
            public static int[] peso = new int[] { 1, 2, 3, 4, 5, 6, 7, 10, 11, 12 };
            public static string[] nombrePeso = new string[] { "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Sota", "Caballo", "Rey" };
            public static string[] palo = new string[] { "Oro", "Basto", "Espada", "Copa" };
            #endregion
            List<Carta> barajaEspanola; //CAMPOS LISTA DE BARAJAS           
            public List<Carta> BarajaEspanola //PROPIEDAD BarajaEspanola
            {
                get { return barajaEspanola; }
                set { barajaEspanola = value; }
            }
            public Baraja(List<Carta> cartas) //CONSTRUCTOR CON PARÁMETROS
            {
                barajaEspanola = cartas;
            }
            #region MÉTODOS
            /// <summary>
            /// Obtiene una carta de la lista.
            /// </summary>
            /// <param name="nCarta">Numero de la carta a obtener (Máximo BarajaEspanola.Count).</param>
            /// <returns>Devuelve la carta solicitada.</returns>
            public Carta GetCarta(int nCarta)
            {
                return barajaEspanola[nCarta];
            }
            /// <summary>
            /// Obtiene aleatoriamente una carta de la baraja y la elimina de la baraja.
            /// </summary>
            /// <param name="rnd">Semilla del aleatorio</param>
            public void SacarCarta(Random rnd)
            {
                int nCartas = barajaEspanola.Count;
                int elementoASacar = rnd.Next(nCartas);
                Console.WriteLine("Cartas "+nCartas+" --> "+GetCarta(elementoASacar).ToString());
                barajaEspanola.Remove(GetCarta(elementoASacar));
            }
            /// <summary>
            /// Rellena una baraja con los valores originales de la Baraja Española.
            /// </summary>
            public void RellenarBaraja()
            {
                Carta carta = new Carta();

                for (int i = 0; i < palo.Length; i++)
                    for (int j = 0; j < peso.Length; j++)
                    {
                        carta.Palo = palo[i];
                        carta.NombrePeso = nombrePeso[j];
                        carta.Peso = peso[j];
                        barajaEspanola.Add(carta);
                    }
            }
            #endregion
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();              //DECLARAR SEMILLA DEL ALEATORIO
            Console.WriteLine("Extrae cartas aleatoriamente de la baraja española");
            string respuesta;
            do                                                          //HACER... (MIENTRAS LA RESPUESTA SEA SI) 
            {
                Baraja barajaEspanola = new Baraja(new List<Carta>());  //DECLARAR BARAJA
                barajaEspanola.RellenarBaraja();                        //RELLENAR BARAJA DE CARTAS 
                Console.WriteLine("Pulse una tecla para extraer una carta");
                do                                                      //HACER...(MIENTRAS LA BARAJA NO ESTÉ VACIA)
                {
                    Console.ReadKey(true);                              //PULSAR TECLA
                    barajaEspanola.SacarCarta(rnd);                     //SACA CARTA ALEATORIAMENTE
                } while (barajaEspanola.BarajaEspanola.Count > 0);      //MIENTRAS LA BARAJA NO ESTÉ VACIA

                Console.WriteLine("¡¡YA HAS EXTRAIDO TODAS LAS CARTAS!!\n");
                Console.Write("¿Deseas empezar de nuevo? (si/no): ");   //PREGUNTAR SI REPITE EL PROCESO DE NUEVO
                respuesta = Console.ReadLine();
                while (!respuesta.ToLower().Equals("si") && !respuesta.ToLower().Equals("no"))  //MIENTRAS LA RESPUESTA NO SEA NI SI, NI NO, PREGUNTAR DENUEVO
                {
                    Console.Write("Introduce si o no: ");
                    respuesta = Console.ReadLine();
                }
            } while (respuesta.ToLower().Equals("si"));                 //MIENTRAS LA RESPUESTA SEA SI
        }
    }
}
