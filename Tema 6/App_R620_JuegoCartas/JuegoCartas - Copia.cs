/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_R620_JuegoCartas
{
    public enum TipoJuego { TexasHoldem0Joker }
    class JuegoCartas
    {
        Baraja baraja;
        int numeroJugadores;

        public JuegoCartas(TipoJuego tipo, int numeroJugadores)
        {
            this.numeroJugadores = numeroJugadores;
            switch (tipo)
            {
                case TipoJuego.TexasHoldem0Joker:
                    baraja = new Baraja(TipoBaraja.BarajaInglesa52, 0);
                    baraja.Barajar();
                    break;
                default:
                    break;
            }
        }

    }
    class TexasHoldem
    {
        Baraja baraja;
        int numeroJugadores;
        int ronda;
        Carta[,] cartasJugadores;
        Carta[] cartasMesa;
        int[] apustaJugadores;
        int[] dineroJugadores;
        int cartasMostradas;
        int hablaPrimero;
        int apuestaMinima;
        int dineroComienzo;
        bool[] sigueJugando;
        int turnoDe;


        public int TurnoDe
        {
            get { return turnoDe; }
            set { turnoDe = (value + HablaPrimero) % numeroJugadores; }
        }
        public int ApuestaGrande
        {
            get { return apuestaMinima * 2; }
        }
        public int ApuestaMinima
        {
            get { return apuestaMinima; }
            set { apuestaMinima = value; }
        }
        public int DineroComienzo
        {
            get { return dineroComienzo; }
            set
            {
                dineroComienzo = value;
                dineroJugadores = new int[numeroJugadores];
                for (int i = 0; i < numeroJugadores; i++)
                {
                    dineroJugadores[i] = value;
                }
            }
        }
        public int HablaPrimero
        {
            get { return hablaPrimero; }
            set
            {
                if (!sigueJugando[value])
                {
                    HablaPrimero++;
                }
                hablaPrimero = (value + numeroJugadores) % numeroJugadores;
            }
        }
        public TexasHoldem(Baraja baraja, int numeroJugadores)
        {
            Random rnd = new Random();
            this.baraja = baraja;
            this.numeroJugadores = numeroJugadores;
            cartasJugadores = new Carta[2, numeroJugadores];
            cartasMesa = new Carta[5];
            ronda = 1;
            cartasMostradas = 0;
            HablaPrimero = rnd.Next(numeroJugadores);
            ApuestaMinima = 10;
            DineroComienzo = 500;
            sigueJugando = new bool[numeroJugadores];
            for (int i = 0; i < sigueJugando.Length; i++)
            {
                sigueJugando[i] = true;
            }
        }
        public void RepartirCartas(int cartasPorJugador)
        {
            if (ronda != 1) //Si no es la 1ª ronda
            {
                baraja.SacarCarta();    //Se quema 1 carta

                for (int i = 0; i < cartasJugadores.GetLength(0); i++)  //Repartir cartas a cada jugador
                {
                    for (int j = 0; j < cartasJugadores.GetLength(1); j++)
                    {
                        if (sigueJugando[j])
                        {
                            cartasJugadores[i, j] = baraja.SacarCarta();
                        }
                    }
                }
            }
            else        //Si es la 1ª ronda
            {
                for (int i = 0; i < cartasJugadores.GetLength(0); i++)  //Dos cartas por jugador
                {
                    for (int j = 0; j < cartasJugadores.GetLength(1); j++) //Repartir carta a cada jugador
                    {
                        if (sigueJugando[j])
                        {
                            cartasJugadores[i, j] = baraja.SacarCarta();
                        }
                    }
                }
                baraja.SacarCarta();    //Se quema 1 carta
                for (int i = 0; i < 3; i++) //Se colocan 3 cartas en la mesa
                {
                    cartasMesa[i] = baraja.SacarCarta();
                }
            }
        }
        public void Hablar()
        {

            int contadorHablado = 0;
            int apuestaMaximaJugada = 0;
            int[] apuestasJugadores = new int[numeroJugadores];
            List<bool> subidoJugadores = new List<bool>(numeroJugadores);
            bool[] vaEnLaRonda = new bool[sigueJugando.Length];
            Array.Copy(sigueJugando, vaEnLaRonda, sigueJugando.Length);
            int ganadorRonda;
            do
            {
                TurnoDe = contadorHablado;              //Asignar el turno del jugador que le toca
                if (contarArrayBool(vaEnLaRonda) == 1)  //Si se va todo el mundo y solo queda un jugador en la ronda se lleva el dinero
                {
                    ganadorRonda = TurnoDe;
                }
                if (!sigueJugando[TurnoDe]||!vaEnLaRonda[TurnoDe])  //Si el jugador se ha retirado de la ronda o de la partida busca el siguiente que le toque
                {
                    do
                    {
                        TurnoDe++;
                        contadorHablado++;
                    } while (!sigueJugando[TurnoDe]);
                }
                int apuestaObligatoria = 0;
                Console.WriteLine("TURNO DEL JUGADOR {0}", turnoDe + 1);
                Console.WriteLine("INTRODUCIR ENTER CUANDO SOLO VEA LA PANTALLA EL JUGADOR {0}", turnoDe + 1);
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("TURNO DEL JUGADOR {0}", turnoDe + 1);
                Console.WriteLine("Tus cartas son:\n-{0}\n-{1}", cartasJugadores[0, turnoDe].ToString(), cartasJugadores[1, turnoDe].ToString());
                Console.WriteLine("Tu dinero: {0}", dineroJugadores[turnoDe]);
                if (turnoDe == HablaPrimero&&ronda==1)
                {
                    apuestaObligatoria = ApuestaMinima;
                }
                else if (turnoDe == HablaPrimero + 1 && ronda == 1)
                {
                    apuestaObligatoria = ApuestaGrande;
                }
                int apuesta = apuestaObligatoria;
                Console.WriteLine("Apuesta mínima: {0}", apuestaObligatoria);
                Console.WriteLine("¿Qué desea hacer?:");
                ConsoleKeyInfo tecla = new ConsoleKeyInfo();

                if (!subidoJugadores.Contains(true))    //Si nadie sube
                {
                    Console.WriteLine("\t1- Subir");
                    Console.WriteLine("\t2- Pasar");
                    Console.WriteLine("\t3- Retirarte de la jugada");
                    Console.WriteLine("\t4- Retirarte del juego");
                    tecla = Console.ReadKey();
                    switch (tecla.KeyChar)
                    {
                        case '1':
                            Console.WriteLine("Introduce el dinero que deseas subir. Disponible: {0}", dineroJugadores[TurnoDe]);
                            string aux = Console.ReadLine();
                            while (int.TryParse(aux, out apuestasJugadores[TurnoDe]) || apuestasJugadores[TurnoDe] > dineroJugadores[TurnoDe])
                            {
                                Console.WriteLine("Introduce un valor válido: ");
                                aux = Console.ReadLine();
                            }
                            apuesta += apuestasJugadores[TurnoDe];
                            subidoJugadores.Add(true);
                            apuestaMaximaJugada = apuestasJugadores[TurnoDe];
                            dineroJugadores[TurnoDe] -= apuesta;
                            break;
                        case '2':
                            dineroJugadores[turnoDe] -= apuesta;
                            subidoJugadores.Add(false);
                            break;
                        case '3':
                            dineroJugadores[turnoDe] -= apuesta;
                            
                            vaEnLaRonda[TurnoDe] = false;
                            
                            break;
                        case '4':
                            dineroJugadores[turnoDe] -= apuesta;
                            sigueJugando[TurnoDe] = false;
                            break;
                    }
                }
                Console.WriteLine("\t-Pasar (Apuestas: {0})", apuestaObligatoria);
                contadorHablado++;
            } while (contadorHablado != numeroJugadores);
            ronda++;
        }
        public int contarArrayBool(bool[]arrayBool)
        {
            int resultado = 0;
            for (int i = 0; i < arrayBool.Length; i++)
            {
                if (arrayBool[i])
                {
                    resultado++;
                }
            }
            return resultado;
        }
    }
}
*/