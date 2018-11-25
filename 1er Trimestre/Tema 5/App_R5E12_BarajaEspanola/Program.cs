using System;
using System.Collections.Generic;

namespace App_R5E12_BarajaEspanola
{
    class Program
    {
        public struct Carta
        {
            int peso;
            string nombrePeso;
            string palo;
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
            public override string ToString()
            {
                return NombrePeso + " de " + Palo;
            }
        }
        public class Baraja
        {
            public static int[] peso = new int[] { 1, 2, 3, 4, 5, 6, 7, 10, 11, 12 };
            public static string[] nombrePeso = new string[] { "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Sota", "Caballo", "Rey" };
            public static string[] palo = new string[] { "Oro", "Basto", "Espada", "Copa" };
            List<Carta> barajaEspanola = new List<Carta>();
            public List<Carta> BarajaEspanola
            {
                get { return barajaEspanola; }
                set { barajaEspanola = value; }
            }
            public Carta GetCarta(int nCarta)
            {
                return barajaEspanola[nCarta];
            }
            public void SacarCarta(Random rnd)
            {
                int nCartas = barajaEspanola.Count;
                int elementoASacar = rnd.Next(nCartas);
                Console.WriteLine("Cartas "+nCartas+" --> "+GetCarta(elementoASacar).ToString());
                barajaEspanola.Remove(GetCarta(elementoASacar));
            }
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
        }
        static void Main(string[] args)
        {
            Baraja barajaEspanola = new Baraja();
            Random rnd = new Random();
            Console.WriteLine("Extrae cartas aleatoriamente de la baraja española");
            string respuesta;
            do
            {
                barajaEspanola.RellenarBaraja();
                Console.WriteLine("Pulse una tecla para extraer una carta");
                do
                {
                    Console.ReadKey();
                    barajaEspanola.SacarCarta(rnd);
                } while (barajaEspanola.BarajaEspanola.Count > 0);

                Console.WriteLine("¡¡YA HAS EXTRAIDO TODAS LAS CARTAS!!\n");
                Console.Write("¿Deseas empezar de nuevo? (si/no): ");
                respuesta = Console.ReadLine();
                while (!respuesta.ToLower().Equals("si") && !respuesta.ToLower().Equals("no"))
                {
                    Console.Write("Introduce si o no: ");
                    respuesta = Console.ReadLine();
                }
            } while (respuesta.Equals("si"));
        }
    }
}
