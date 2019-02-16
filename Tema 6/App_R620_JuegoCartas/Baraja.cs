using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_R620_JuegoCartas
{
    public enum TipoBaraja { BarajaEspanola40, BarajaEspanola48, BarajaInglesa52 };

    #region EXCEPCIONES
    public class NoCartaEnBarajaException : Exception
    {
        public override string Message
        {
            get { return "No se puede sacar ninguna carta dado que la baraja está vacía"; }
        }
    }
    #endregion
    /// <summary>
    /// Clase Carta que almacena peso, nombre del peso, y el palo que contiene dicha carta.
    /// </summary>
    public class Carta
    {
        public class OrdenarAscesdente : IComparer<Carta>
        {
            public int Compare(Carta x, Carta y)
            {
                return x.peso - y.peso;
            }
        }
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
    /// Clase Baraja que almacena una lista con las cartas que contiene la baraja.
    /// </summary>
    public class Baraja
    {
        #region CAMPOS
        public static int[] peso;
        public static string[] nombrePeso;
        public static string[] palo;
        int numeroJokers;
        List<Carta> baraja; //CAMPOS LISTA DE BARAJAS
        List<Carta> cartasSacadas;
        #endregion

        #region PROPIEDADES
        public List<Carta> BarajaEspanola //PROPIEDAD BarajaEspanola
        {
            get { return baraja; }
            set { baraja = value; }
        }
        public int NumeroJokers
        {
            get { return numeroJokers; }
            set
            {
                if (value < 0 || value > 2)
                {
                    throw new ArgumentException();
                }
                else
                {
                    numeroJokers = value;
                }
            }
        }
        #endregion

        #region CONSTRUCTORES
        public Baraja(List<Carta> cartas)
        {
            baraja = cartas;
            cartasSacadas = new List<Carta>();
        }
        public Baraja(TipoBaraja tipoBaraja)
        {
            RellenarBaraja(tipoBaraja);
            numeroJokers = 0;
            cartasSacadas = new List<Carta>();
        }
        public Baraja(TipoBaraja tipoBaraja, int numeroJokers)
        {
            cartasSacadas = new List<Carta>();
            NumeroJokers = numeroJokers;
            RellenarBaraja(tipoBaraja);
        }
        #endregion

        #region MÉTODOS
        /// <summary>
        /// Obtiene una carta de la lista.
        /// </summary>
        /// <param name="nCarta">Numero de la carta a obtener (Máximo BarajaEspanola.Count).</param>
        /// <returns>Devuelve la carta solicitada.</returns>
        public Carta GetCarta(int nCarta)
        {
            return baraja[nCarta];
        }

        /// <summary>
        /// Obtiene aleatoriamente una carta de la baraja y la añade a la lista cartasSacadas.
        /// </summary>
        /// <param name="rnd">Semilla del aleatorio</param>
        public void SacarCartaYMostrarConsola(Random rnd)
        {
            int nCartas = baraja.Count;
            int elementoASacar = rnd.Next(nCartas);
            Carta cartaSacada = GetCarta(elementoASacar);
            Console.WriteLine("Cartas " + nCartas + " --> " + cartaSacada.ToString());
            baraja.Remove(cartaSacada);
            cartasSacadas.Add(cartaSacada);
        }

        /// <summary>
        /// Obtiene aleatoriamente una carta de la baraja y la añade a la lista cartasSacadas.
        /// </summary>
        /// <param name="rnd">Semilla del aleatorio</param>
        /// <returns>Devuelve la Carta sacada</returns>
        public Carta SacarCarta(Random rnd)
        {
            int nCartas = baraja.Count;
            int elementoASacar = rnd.Next(nCartas);
            Carta carta = GetCarta(elementoASacar);
            baraja.Remove(carta);
            cartasSacadas.Add(carta);
            return carta;
        }

        /// <summary>
        /// Obtiene una carta concreta de la baraja y la añade a las cartasSacadas, debe de ser menor que baraja.Count
        /// </summary>
        /// <param name="numeroCarta">Índice de la coleccion baraja de la cual se va a extraer la carta.</param>
        /// <returns>Devuelve la carta extraida.</returns>
        public Carta SacarCarta(int numeroCarta)
        {
            int nCartas = baraja.Count;
            if (numeroCarta >= nCartas)
            {
                throw new ArgumentException("El número de la carta a extraer debe de ser menor a baraja.Count");
            }
            Carta carta = GetCarta(numeroCarta);
            baraja.Remove(carta);
            cartasSacadas.Add(carta);
            return carta;
        }

        /// <summary>
        /// Obtiene la carta que le toca salir de la baraja. Si no hay cartas salta excepción.
        /// </summary>
        /// <returns></returns>
        public Carta SacarCarta()
        {
            int nCartas = baraja.Count;
            if (nCartas == 0)
            {
                throw new NoCartaEnBarajaException();
            }
            Carta carta = GetCarta(nCartas - 1);
            baraja.Remove(carta);
            cartasSacadas.Add(carta);
            return carta;
        }

        /// <summary>
        /// Baraja las cartas aleatoriamente
        /// </summary>
        public void Barajar()
        {
            Random rnd = new Random();
            List<Carta> auxiliar = new List<Carta>();
            int numeroCartas = baraja.Count;
            for (int i = 0; i < numeroCartas; i++)
            {
                int cartaASacar = rnd.Next(baraja.Count);
                Carta cartaBarajada = baraja[cartaASacar];
                auxiliar.Add(cartaBarajada);
                baraja.Remove(cartaBarajada);
            }
            baraja = auxiliar;
        }

        /// <summary>
        /// Junta las cartas sacadas con las cartas que quedan en la baraja y barajar.
        /// </summary>
        public void JuntarCartasSacadasConBarajaYBarajar()
        {
            baraja.AddRange(cartasSacadas);
            cartasSacadas.Clear();
            Barajar();
        }

        /// <summary>
        /// Rellena una baraja con los valores del tipo de baraja asignada.
        /// </summary>
        public void RellenarBaraja(TipoBaraja tipoBaraja)
        {
            Carta carta = new Carta();
            baraja = new List<Carta>();
            AsignarTipoBaraja(tipoBaraja);

            for (int i = 0; i < palo.Length; i++)
                for (int j = 0; j < peso.Length; j++)
                {
                    carta.Palo = palo[i];
                    carta.NombrePeso = nombrePeso[j];
                    carta.Peso = peso[j];
                    baraja.Add(carta);
                }
            for (int i = 0; i < numeroJokers; i++)
            {
                carta.Palo = "Joker";
                carta.NombrePeso = "Joker";
                carta.Peso = -1;
                baraja.Add(carta);
            }
        }

        /// <summary>
        /// Asigna a los arrays que contienen el peso, el palo y el nombre del peso.
        /// </summary>
        /// <param name="tipoBaraja">Tipo de baraja que se va a asignar de la enumeración TipoBaraja</param>
        private void AsignarTipoBaraja(TipoBaraja tipoBaraja)
        {
            switch (tipoBaraja)
            {
                case TipoBaraja.BarajaEspanola40:
                    peso = new int[] { 1, 2, 3, 4, 5, 6, 7, 10, 11, 12 };
                    nombrePeso = new string[] { "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Sota", "Caballo", "Rey" };
                    palo = new string[] { "Oro", "Basto", "Espada", "Copa" };
                    break;
                case TipoBaraja.BarajaEspanola48:
                    peso = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                    nombrePeso = new string[] { "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve", "Sota", "Caballo", "Rey" };
                    palo = new string[] { "Oro", "Basto", "Espada", "Copa" };
                    break;
                case TipoBaraja.BarajaInglesa52:
                    peso = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
                    nombrePeso = new string[] { "As", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve", "Diez", "J", "Q", "K" };
                    palo = new string[] { "Corazón", "Pica", "Rombo", "Trebol" };
                    break;
            }
        }
        #endregion
    }
}
