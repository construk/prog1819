using System;
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
                    TexasHoldem partida = new TexasHoldem(baraja, numeroJugadores);
                    partida.Jugar();
                    break;
                default:
                    break;
            }
        }
    }
    class TexasHoldem : JugadorPokerHoldem.IJugador
    {
        #region CAMPOS
        Random rnd;
        Baraja baraja;
        int ronda;              //1     2       3       4
        int cartasMostradas;    //0     3       4       5
        List<JugadorPokerHoldem> jugadoresPoker;
        List<Carta> cartasMesa;
        int dealer;         //random.Next(numeroJugadores)
        int turnoDe;        //(random+numeroJugadores)%numeroJugadores    
        int ciegaChica;
        int dineroComienzo;
        int ganadorRonda;
        int ganadorPartida;
        int boteMesa;
        //int[] dineroJugadores;
        //bool[] sigueJugando;
        #endregion
        #region PROPIEDADES
        public int NumeroJugadores { get { return jugadoresPoker.Count; } }
        public int TurnoDe
        {
            get { return turnoDe; }
            set
            {
                turnoDe = (value + Dealer) % NumeroJugadores;
            }
        }
        public int Dealer
        {
            get { return dealer; }
            set
            {
                dealer = (value + NumeroJugadores) % NumeroJugadores;
                TurnoDe = turnoDe;
            }
        }
        public int CiegaGrande
        {
            get { return ciegaChica * 2; }
        }
        public int CiegaChica
        {
            get { return ciegaChica; }
            set
            {
                if (value < 0)
                {
                    ciegaChica = 0;
                }
                else if (value > dineroComienzo)
                {
                    ciegaChica = dineroComienzo;
                }
                else
                {
                    ciegaChica = value;
                }
            }
        }
        public int DineroComienzo
        {
            get { return dineroComienzo; }
            set
            {
                dineroComienzo = value;
            }
        }

        #endregion
        #region CONSTRUCTORES
        public TexasHoldem(Baraja baraja, int numeroJugadores)
        {
            rnd = new Random();
            this.baraja = baraja;
            baraja.RellenarBaraja(TipoBaraja.BarajaInglesa52);
            jugadoresPoker = new List<JugadorPokerHoldem>();
            CrearNJugadores(numeroJugadores);
            DineroComienzo = 500;
            for (int i = 0; i < jugadoresPoker.Count; i++)
            {
                jugadoresPoker[i].Dinero = DineroComienzo;
            }
            cartasMesa = new List<Carta>();
            ronda = 1;
            cartasMostradas = 0;
            Dealer = rnd.Next(numeroJugadores);
            CiegaChica = 10;

            boteMesa = 0;
            ganadorRonda = -1;
            ganadorPartida = -1;
            Dealer = rnd.Next(NumeroJugadores);
        }
        #endregion
        #region MÉTODOS
        #region MÉTODOS GRÁFICOS USARIO CONSOLA
        public void CrearJugadorMesa()
        {

            Console.WriteLine("============================");
            Console.WriteLine("        JUGADOR");
            Console.WriteLine("============================");
            Console.WriteLine(" Introduce nombre: ");
            string nombre = Console.ReadLine();
            JugadorPokerHoldem jugador = new JugadorPokerHoldem(nombre, DineroComienzo, this);
            jugadoresPoker.Add(jugador);
        }
        public void CrearNJugadores(int nJugadores)
        {
            for (int i = 0; i < nJugadores; i++)
            {
                CrearJugadorMesa();
            }
        }
        #endregion
        #region MÉTODOS JUEGO
        public void RepartirCartas()
        {
            if (ronda != 1) //Si no es la 1ª ronda
            {
                baraja.SacarCarta();    //Se quema 1 carta
                cartasMesa.Add(baraja.SacarCarta());
            }
            else        //Si es la 1ª ronda
            {
                for (int i = 0; i < NumeroJugadores * 2; i++)         //Repartir cartas a cada jugador (2 por jugador)
                {
                    jugadoresPoker[(i + NumeroJugadores + 1) % NumeroJugadores].Cartas.Add(baraja.SacarCarta());
                }
                baraja.SacarCarta();    //Se quema 1 carta
                for (int i = 0; i < 3; i++) //Se colocan 3 cartas en la mesa
                {
                    cartasMesa.Add(baraja.SacarCarta());
                }
            }
        }
        public void Hablar(int turno)
        {
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();
            TurnoDe = Dealer + turno;               //Asignar el turno del jugador que le toca
            if (NumeroJugadores == 1)          //Si se va todo el mundo y solo queda un jugador en la ronda se lleva el dinero y gana la partida
            {
                ganadorRonda = 0;
                ganadorPartida = 0;
                jugadoresPoker[ganadorPartida].Dinero += boteMesa;
            }
            else if (ContarJugadoresNoRetirados(out ganadorRonda) > 1) //Si se retiran los jugadores y queda uno gana el que quede. Si no queda 1 --> ganadorRonda = -1
            {
                if (turno == 0 && ronda == 1)  //Si es el primer turno de la primera ronda el dealer coloca la ciega chica obligatoria.
                {
                    Console.WriteLine("Dealer, jugador {0} pone la ciega chica {1}", jugadoresPoker[TurnoDe].Nombre, CiegaChica);
                    jugadoresPoker[TurnoDe].Dinero -= CiegaChica;
                    jugadoresPoker[TurnoDe].DineroApuesta = CiegaChica;
                    boteMesa += CiegaChica;
                }
                else if (jugadoresPoker[TurnoDe].SigueEnRonda && jugadoresPoker[TurnoDe].SigueEnMesa && !HaIgualadoOAllIn(TurnoDe))  //Si el jugador sigue en la ronda (no se ha retirado ni se ha ido de la mesa) y si no ha igualado la apuesta.
                {
                    Console.Clear();
                    int apuestaObligatoria = 0;
                    Console.WriteLine("TURNO DEL JUGADOR {0}", TurnoDe.ToString() + " - " + jugadoresPoker[TurnoDe].Nombre);
                    Console.WriteLine("INTRODUCIR ENTER CUANDO SOLO VEA LA PANTALLA EL JUGADOR {0}", TurnoDe.ToString() + " - " + jugadoresPoker[TurnoDe].Nombre);
                    Console.ReadLine();
                    Console.WriteLine("TURNO DEL JUGADOR {0}", TurnoDe.ToString() + " - " + jugadoresPoker[TurnoDe].Nombre);
                    Console.WriteLine("Tus cartas son:\n-{0}\n-{1}", jugadoresPoker[TurnoDe].Cartas[0].ToString(), jugadoresPoker[TurnoDe].Cartas[1].ToString());
                    Console.WriteLine("Tu dinero: {0}", jugadoresPoker[TurnoDe].Dinero);
                    Console.WriteLine("Ronda: {0}", ronda);
                    Console.WriteLine("Cartas mostradas: {0}", cartasMostradas);
                    Console.WriteLine("Cartas mesa: ");
                    int asteriscos = 0;
                    asteriscos = 5 - cartasMostradas;
                    for (int i = 0; i < cartasMostradas; i++)
                    {
                        Console.Write(cartasMesa[i].ToString().PadRight(15));
                    }
                    for (int i = 0; i < asteriscos; i++)
                    {
                        Console.Write("X".PadRight(15));
                    }

                    if (turnoDe == Dealer && ronda == 1)
                    {
                        apuestaObligatoria = CiegaChica;
                    }
                    else if (turnoDe == (Dealer + 1) && ronda == 1)
                    {
                        apuestaObligatoria = CiegaGrande;
                    }
                    else if (ronda == 1)
                    {
                        apuestaObligatoria = CiegaGrande;
                    }
                    else
                    {
                        apuestaObligatoria = ComprobarApuestaMinimaContinuarJugando(TurnoDe);
                    }

                    int apuesta = apuestaObligatoria;
                    Console.WriteLine("Apuesta mínima: {0}", apuestaObligatoria);
                    Console.WriteLine("Apuesta mínima para continuar jugando {0}", ComprobarApuestaMinimaContinuarJugando(TurnoDe));
                    Console.WriteLine("¿Qué desea hacer?");
                    if (jugadoresPoker[TurnoDe].Dinero > ComprobarApuestaMinimaContinuarJugando(TurnoDe))    //Si tiene suficiente dinero para subir //000000000000000000000000000000000000000000000000000000000000000000000000
                    {
                        Console.WriteLine("\t1- Subir");
                        Console.WriteLine("\t2- Pasar o igualar");
                        Console.WriteLine("\t3- All-In");
                        Console.WriteLine("\t4- Retirarte de la jugada");
                        Console.WriteLine("\t5- Retirarte del juego");
                        jugadoresPoker[TurnoDe].DineroApuesta = apuesta;
                        tecla = Console.ReadKey();

                        switch (tecla.KeyChar)
                        {
                            case '1':
                                Console.WriteLine("Introduce el dinero que deseas subir. Disponible: {0}", jugadoresPoker[TurnoDe].Dinero);
                                Console.Write("Introduce dinero a apostar: ");
                                string aux = Console.ReadLine();
                                int dineroApostado;
                                while (int.TryParse(aux, out dineroApostado) || dineroApostado > jugadoresPoker[TurnoDe].Dinero)
                                {
                                    Console.Write("Introduce un valor válido: ");
                                    aux = Console.ReadLine();
                                }
                                Console.WriteLine("El jugador {0} ha apostado {1}", jugadoresPoker[TurnoDe].Nombre, dineroApostado + ComprobarApuestaMinimaContinuarJugando(TurnoDe));
                                IgualarYSubir(dineroApostado);
                                break;
                            case '2':
                                IgualarYPasar();
                                Console.WriteLine("El jugador {0} pasa. Ha pagado {1}", jugadoresPoker[TurnoDe].Nombre, jugadoresPoker[TurnoDe].DineroApuesta);
                                break;
                            case '3':
                                AllIn();
                                Console.WriteLine("El jugador {0} ha hecho All-In con {1}", jugadoresPoker[TurnoDe].Nombre, jugadoresPoker[TurnoDe].DineroApuesta);
                                break;
                            case '4':
                                NoIrJugada();
                                Console.WriteLine("El jugador {0} no va y espera a la siguiente mano. Ha pagado {1}", jugadoresPoker[TurnoDe].Nombre, jugadoresPoker[TurnoDe].DineroApuesta);
                                break;
                            case '5':
                                Console.WriteLine("El jugador {0} se va de la mesa. Ha pagado {1}", jugadoresPoker[TurnoDe].Nombre, jugadoresPoker[TurnoDe].DineroApuesta);
                                SalirDeLaMesa();
                                break;
                        }

                        Console.WriteLine("Pulse una tecla para continuar...");
                        Console.ReadLine();
                    }
                    else if (jugadoresPoker[TurnoDe].Dinero < ComprobarApuestaMinimaContinuarJugando(TurnoDe))    //Si no tiene suficiente dinero para pagar para continuar jugando //00000000000000000000000000000000000000000000000000000000000
                    {
                        Console.WriteLine("\t1- All-In");
                        Console.WriteLine("\t2- Retirarte de la jugada");
                        Console.WriteLine("\t3- Retirarte del juego");
                        jugadoresPoker[TurnoDe].DineroApuesta = apuesta;
                        tecla = Console.ReadKey();

                        switch (tecla.KeyChar)
                        {
                            case '1':
                                AllIn();
                                Console.WriteLine("El jugador {0} ha hecho All-In con {1}", jugadoresPoker[TurnoDe].Nombre, jugadoresPoker[TurnoDe].DineroApuesta);
                                break;
                            case '2':
                                NoIrJugada();
                                Console.WriteLine("El jugador {0} no va y espera a la siguiente mano. Ha pagado {1}", jugadoresPoker[TurnoDe].Nombre, jugadoresPoker[TurnoDe].DineroApuesta);
                                break;
                            case '3':
                                Console.WriteLine("El jugador {0} se va de la mesa. Ha pagado {1}", jugadoresPoker[TurnoDe].Nombre, jugadoresPoker[TurnoDe].DineroApuesta);
                                SalirDeLaMesa();
                                break;
                        }
                    }
                }
            }
        }
        public void IgualarApuestasRonda()
        {
            int contadorTurnos = 0;
            do
            {
                Hablar(contadorTurnos++);
            } while (NumeroJugadores > 1 && ContarJugadoresNoRetirados(out ganadorRonda) > 1 && !JugadoresHanIgualadoOAllIn());
            ReiniciarApuestasTurno();
            ronda++;
        }
        public void Jugar()
        {
            do
            {
                ganadorRonda = -1;          //Nadie ha ganado la Ronda

                ronda = 1;                  //Ronda 1
                cartasMostradas = 0;        //No se muestra ninguna carta
                RepartirCartas();           //Repartir las cartas a los jugadores --> Ronda 1: reparte 2 cartas por jugador, quema una y coloca 3 sin mostrar en la mesa.
                IgualarApuestasRonda();     //Hasta que todos los jugadores no hayan igualado todas las apuestas no aumenta la ronda.

                ronda++;                    //Aumenta la ronda. Ronda 2.
                cartasMostradas = 3;        //Se muestran las 3 cartas
                IgualarApuestasRonda();     //Hasta que todos los jugadores no hayan igualado todas las apuestas no aumenta la ronda.

                ronda++;                    //Aumenta la ronda. Ronda 3.
                RepartirCartas();           //Sacar carta a la mesa --> Ronda 4: quema una y saca a la mesa.
                cartasMostradas = 4;        //Se muestran las 4 cartas
                IgualarApuestasRonda();     //Hasta que todos los jugadores no hayan igualado todas las apuestas no aumenta la ronda.

                ronda++;                    //Aumenta la ronda. Ronda 4.
                RepartirCartas();           //Sacar carta a la mesa --> Ronda 4: quema una y saca la última carta a la mesa.
                cartasMostradas = 5;        //Se muestran todas las cartas en la mesa.
                IgualarApuestasRonda();     //Hasta que todos los jugadores no hayan igualado todas las apuestas no aumenta la ronda.

                if (ronda==5)
                {
                    CompararManos();
                }
                DeterminarGanadorYRepartirBote();
                RecogerCartasBarajarYReiniciarApuestas();
            } while (jugadoresPoker.Count > 1);
            Dealer--;
        }
        public void ComprobarMano(int turnoDe)
        {
            int valorJugada = -1;

            int valor1Carta = -1;
            int valor2Carta = -1;
            int valor3Carta = -1;
            int valor4Carta = -1;
            int valor5Carta = -1;
            if (jugadoresPoker[turnoDe].SigueEnMesa && jugadoresPoker[turnoDe].SigueEnRonda)
            {
                if (ComprobarEscaleraReal(turnoDe))
                {
                    valorJugada = 11;
                }
                else if (ComprobarEscaleraColor(turnoDe, out valor1Carta))
                {
                    valorJugada = 10;
                }
                else if (ComprobarPoker(turnoDe, out valor1Carta))
                {
                    valorJugada = 9;
                }
                else if (ComprobarFull(turnoDe, out valor1Carta, out valor2Carta))  //TODO FALTA AÑADIR valorCarta3 que compruebe la carta alta en caso de empate FULL
                {
                    valorJugada = 8;
                }
                else if (ComprobarColor(turnoDe, out valor1Carta, out valor2Carta, out valor3Carta, out valor4Carta, out valor5Carta))
                {
                    valorJugada = 7;
                }
                else if (ComprobarEscaleraAlta(turnoDe))
                {
                    valorJugada = 6;
                }
                else if (ComprobarEscalera(turnoDe, out valor1Carta))
                {
                    valorJugada = 5;
                }
                else if (ComprobarTrio(turnoDe, out valor1Carta))   //TODO Falta añadir valorCarta2, valorCarta3, valorCarta4 que compruebe las cartas altas
                {
                    valorJugada = 4;
                }
                else if (ComprobarDoblePareja(turnoDe, out valor1Carta, out valor2Carta))   //TODO Falta añadir valor3Carta que compruebe la carta alta
                {
                    valorJugada = 3;
                }
                else if (ComprobarPareja(turnoDe, out valor1Carta, out valor2Carta, out valor3Carta, out valor4Carta))
                {
                    valorJugada = 2;
                }
                else if (ComprobarCartaAlta(turnoDe, out valor1Carta, out valor2Carta, out valor3Carta, out valor4Carta, out valor5Carta))
                {
                    valorJugada = 1;
                }
                jugadoresPoker[turnoDe].ValorMano = valorJugada;
                jugadoresPoker[turnoDe].ValorCarta1 = valor1Carta;
                jugadoresPoker[turnoDe].ValorCarta2 = valor2Carta;
                jugadoresPoker[turnoDe].ValorCarta3 = valor3Carta;
                jugadoresPoker[turnoDe].ValorCarta4 = valor4Carta;
                jugadoresPoker[turnoDe].ValorCarta5 = valor5Carta;
            }
        }
        public void DeterminarGanadorYRepartirBote()
        {
            bool repetidaJugada = false;
            int valorManoGanadora = 0;
            int jugadorGanador = -1;
            for (int i = 0; i < jugadoresPoker.Count; i++)
            {
                if (jugadoresPoker[i].ValorMano > valorManoGanadora)
                {
                    valorManoGanadora = jugadoresPoker[i].ValorMano;
                    repetidaJugada = false;
                    jugadorGanador = i;
                }
                else if (jugadoresPoker[i].ValorMano == valorManoGanadora)
                {
                    repetidaJugada = true;
                    jugadorGanador = -1;
                }
            }
            if (!repetidaJugada)
            {
                jugadoresPoker[jugadorGanador].Dinero += boteMesa;
                boteMesa = 0;
                Console.WriteLine("El ganador de la ronda es: {0}", jugadoresPoker[jugadorGanador].Nombre);
            }
            else
            {
                //TODO CUANDO GANAN LA JUGADA VARIOS JUGADORES, HAY QUE TENER EN CUENTA VaCon para separar la distintas apuestas según All-ins
            }
        }
        public void CompararManos()
        {
            for (int i = 0; i < jugadoresPoker.Count; i++)
            {
                if (jugadoresPoker[i].SigueEnMesa && jugadoresPoker[i].SigueEnRonda)
                {
                    ComprobarMano(i);
                }
            }
        }
        #endregion
        #region MÉTODOS PRIVADOS
        private void ReiniciarApuestasTurno()
        {
            for (int i = 0; i < jugadoresPoker.Count; i++)
            {
                jugadoresPoker[i].DineroApuesta = 0;
            }
        }
        private void RecogerCartasBarajarYReiniciarApuestas()
        {
            for (int i = 0; i < jugadoresPoker.Count; i++)
            {
                jugadoresPoker[i].DineroApuesta = 0;
                jugadoresPoker[i].Cartas.Clear();
                if (jugadoresPoker[i].Dinero > 0)
                {
                    jugadoresPoker[i].SigueEnRonda = true;
                }
                else
                {
                    jugadoresPoker[i].SigueEnRonda = false;
                    jugadoresPoker[i].SigueEnMesa = false;
                }
                jugadoresPoker[i].ValorMano = 0;
                jugadoresPoker[i].ValorCarta1 = 0;
                jugadoresPoker[i].ValorCarta2 = 0;
                jugadoresPoker[i].ValorCarta3 = 0;
                jugadoresPoker[i].ValorCarta4 = 0;
                jugadoresPoker[i].ValorCarta5 = 0;
                jugadoresPoker[i].VaCon = 0;
            }
            baraja.JuntarCartasSacadasConBarajaYBarajar();
            boteMesa = 0;
        }
        private void CombinarMesaConManos()
        {
            foreach (JugadorPokerHoldem jugador in jugadoresPoker)
            {
                jugador.Cartas.AddRange(cartasMesa);
            }
        }
        private void OrdenarManos()
        {
            foreach (JugadorPokerHoldem jugador in jugadoresPoker)
            {
                jugador.Cartas.Sort(new Carta.OrdenarAscesdente());
            }
        }
        private int ContarJugadoresNoRetirados(out int ganadorRonda)
        {
            int contador = 0;
            ganadorRonda = -1;
            foreach (JugadorPokerHoldem jugador in jugadoresPoker)
            {
                if (jugador.SigueEnRonda)
                {
                    contador++;
                }
            }
            if (contador == 1)
            {
                for (int i = 0; i < jugadoresPoker.Count; i++)
                {
                    if (jugadoresPoker[i].SigueEnRonda)
                    {
                        ganadorRonda = i;
                    }
                }
            }
            return contador;
        }
        private int ComprobarApuestaMinimaContinuarJugando(int numeroJugador)
        {
            int resultado = 0;
            if (ronda == 1)
            {
                resultado = CiegaGrande;
            }
            foreach (JugadorPokerHoldem jugador in jugadoresPoker)
            {
                if (resultado < jugador.DineroApuesta)
                {
                    resultado = jugador.DineroApuesta;
                }
            }
            if (resultado > jugadoresPoker[numeroJugador].Dinero)
            {
                resultado = jugadoresPoker[numeroJugador].Dinero;
            }
            return resultado;
        }
        private bool JugadoresHanIgualadoOAllIn()
        {
            bool todosHanIgualadoOAllIn = true;
            int contador = 0;
            int dineroApostado = jugadoresPoker[0].DineroApuesta;
            while (todosHanIgualadoOAllIn && contador < jugadoresPoker.Count)
            {
                todosHanIgualadoOAllIn = jugadoresPoker[contador].DineroApuesta == dineroApostado || jugadoresPoker[contador].Dinero == 0;
                contador++;
            }
            return todosHanIgualadoOAllIn;
        }
        private bool HaIgualadoOAllIn(int indiceJugador)
        {
            int maximoApostado = 0;
            foreach (JugadorPokerHoldem jugador in jugadoresPoker)
            {
                if (jugador.VaCon > maximoApostado)
                {
                    maximoApostado = jugador.DineroApuesta;
                }
            }
            return jugadoresPoker[indiceJugador].DineroApuesta == maximoApostado || jugadoresPoker[indiceJugador].Dinero == 0;
        }
        private List<int> ListaPesosJugador(int indiceJugador)
        {
            List<int> valoresSalidos = new List<int>();

            for (int i = 0; i < jugadoresPoker[indiceJugador].Cartas.Count; i++)
            {
                valoresSalidos.Add(jugadoresPoker[indiceJugador].Cartas[i].Peso);
            }
            return valoresSalidos;
        }
        private List<string> ListaPalosJugador(int indiceJugador)
        {
            List<string> valoresSalidos = new List<string>();

            for (int i = 0; i < jugadoresPoker[indiceJugador].Cartas.Count; i++)
            {
                valoresSalidos.Add(jugadoresPoker[indiceJugador].Cartas[i].Palo);
            }
            return valoresSalidos;
        }
        private List<int> ListaCartasRepetidas(List<Carta> cartasJugador)
        {
            List<int> valoresSalidos = new List<int>();
            for (int i = 0; i < 13; i++)
            {
                valoresSalidos.Add(0);
            }

            for (int i = 0; i < cartasJugador.Count; i++)
            {
                switch (cartasJugador[i].Peso)
                {
                    case 1:
                        valoresSalidos[0]++;
                        break;
                    case 2:
                        valoresSalidos[1]++;
                        break;
                    case 3:
                        valoresSalidos[2]++;
                        break;
                    case 4:
                        valoresSalidos[3]++;
                        break;
                    case 5:
                        valoresSalidos[4]++;
                        break;
                    case 6:
                        valoresSalidos[5]++;
                        break;
                    case 7:
                        valoresSalidos[6]++;
                        break;
                    case 8:
                        valoresSalidos[7]++;
                        break;
                    case 9:
                        valoresSalidos[8]++;
                        break;
                    case 10:
                        valoresSalidos[9]++;
                        break;
                    case 11:
                        valoresSalidos[10]++;
                        break;
                    case 12:
                        valoresSalidos[11]++;
                        break;
                    case 13:
                        valoresSalidos[12]++;
                        break;
                }
            }
            return valoresSalidos;
        }
        private List<int> ListaPalosRepetidos(List<Carta> cartasJugador)
        {
            List<int> valoresSalidos = new List<int>();
            for (int i = 0; i < 7; i++)
            {
                valoresSalidos.Add(0);
            }

            for (int i = 0; i < cartasJugador.Count; i++)
            {
                switch (cartasJugador[i].Palo)
                {
                    case "Corazón":
                        valoresSalidos[0]++;
                        break;
                    case "Pica":
                        valoresSalidos[1]++;
                        break;
                    case "Rombo":
                        valoresSalidos[2]++;
                        break;
                    case "Trebol":
                        valoresSalidos[3]++;
                        break;
                }
            }
            return valoresSalidos;
        }
        #endregion
        #region MÉTODOS INTERFAZ
        public void RecibirCarta()
        {
            jugadoresPoker[TurnoDe].Cartas.Add(baraja.GetCarta(1));
        }
        public void NoIrJugada()
        {
            IgualarYPasar();
            jugadoresPoker[TurnoDe].SigueEnRonda = false;
        }
        public void SalirDeLaMesa()
        {
            IgualarYPasar();
            jugadoresPoker[TurnoDe].SigueEnRonda = false;
            jugadoresPoker[TurnoDe].SigueEnMesa = false;
            jugadoresPoker.Remove(jugadoresPoker[TurnoDe]);
            Dealer = dealer;

        }
        public void IgualarYSubir(int dineroSubido)
        {
            int dineroQueSeApuesta = ComprobarApuestaMinimaContinuarJugando(TurnoDe) + dineroSubido;
            if (dineroQueSeApuesta > jugadoresPoker[TurnoDe].Dinero)
            {
                dineroQueSeApuesta = jugadoresPoker[TurnoDe].Dinero;
            }
            jugadoresPoker[TurnoDe].DineroApuesta = dineroQueSeApuesta;
            jugadoresPoker[TurnoDe].VaCon += dineroQueSeApuesta;
            boteMesa += jugadoresPoker[TurnoDe].DineroApuesta;
            jugadoresPoker[TurnoDe].Dinero -= jugadoresPoker[TurnoDe].DineroApuesta;
        }
        public void AllIn()
        {
            jugadoresPoker[TurnoDe].DineroApuesta = jugadoresPoker[TurnoDe].Dinero;
            boteMesa += jugadoresPoker[TurnoDe].DineroApuesta;
            jugadoresPoker[TurnoDe].Dinero -= jugadoresPoker[TurnoDe].DineroApuesta;
            jugadoresPoker[TurnoDe].VaCon += jugadoresPoker[TurnoDe].DineroApuesta;
        }
        public void IgualarYPasar()
        {
            int dineroParaIgualar = ComprobarApuestaMinimaContinuarJugando(TurnoDe);
            if (dineroParaIgualar > jugadoresPoker[TurnoDe].Dinero)
            {
                dineroParaIgualar = jugadoresPoker[TurnoDe].Dinero;
            }

            jugadoresPoker[TurnoDe].DineroApuesta = dineroParaIgualar;
            jugadoresPoker[TurnoDe].VaCon += dineroParaIgualar;
            boteMesa += jugadoresPoker[TurnoDe].DineroApuesta;
            jugadoresPoker[TurnoDe].Dinero -= jugadoresPoker[TurnoDe].DineroApuesta;
        }
        #endregion
        #endregion
        #region COMPROBAR VALORES COMBINACIÓN MANO
        private bool ComprobarCartaAlta(int indiceJugador, out int pesoCartaAlta1, out int pesoCartaAlta2, out int pesoCartaAlta3, out int pesoCartaAlta4, out int pesoCartaAlta5)
        {
            if (jugadoresPoker[indiceJugador].Cartas[0].Peso == 1)
            {
                pesoCartaAlta1 = 14;
                pesoCartaAlta2 = jugadoresPoker[indiceJugador].Cartas[jugadoresPoker[indiceJugador].Cartas.Count - 1].Peso;
                pesoCartaAlta3 = jugadoresPoker[indiceJugador].Cartas[jugadoresPoker[indiceJugador].Cartas.Count - 2].Peso;
                pesoCartaAlta4 = jugadoresPoker[indiceJugador].Cartas[jugadoresPoker[indiceJugador].Cartas.Count - 3].Peso;
                pesoCartaAlta5 = jugadoresPoker[indiceJugador].Cartas[jugadoresPoker[indiceJugador].Cartas.Count - 4].Peso;
            }
            else
            {
                pesoCartaAlta1 = jugadoresPoker[indiceJugador].Cartas[jugadoresPoker[indiceJugador].Cartas.Count - 1].Peso;
                pesoCartaAlta2 = jugadoresPoker[indiceJugador].Cartas[jugadoresPoker[indiceJugador].Cartas.Count - 2].Peso;
                pesoCartaAlta3 = jugadoresPoker[indiceJugador].Cartas[jugadoresPoker[indiceJugador].Cartas.Count - 3].Peso;
                pesoCartaAlta4 = jugadoresPoker[indiceJugador].Cartas[jugadoresPoker[indiceJugador].Cartas.Count - 4].Peso;
                pesoCartaAlta5 = jugadoresPoker[indiceJugador].Cartas[jugadoresPoker[indiceJugador].Cartas.Count - 5].Peso;
            }

            return true;
        }
        private bool ComprobarPareja(int indiceJugador, out int pesoPareja, out int pesoCartaAlta1, out int pesoCartaAlta2, out int pesoCartaAlta3)
        {
            int pesoCartaRepetida = jugadoresPoker[indiceJugador].Cartas[jugadoresPoker[indiceJugador].Cartas.Count - 1].Peso;
            pesoCartaAlta1 = -1;
            pesoCartaAlta2 = -1;
            pesoCartaAlta3 = -1;
            int vecesRepetida = 0;
            pesoPareja = -1;

            if (jugadoresPoker[indiceJugador].SigueEnRonda)
            {
                bool esPareja = false;
                for (int i = jugadoresPoker[indiceJugador].Cartas.Count - 2; i >= 0; i--)
                {
                    if (jugadoresPoker[indiceJugador].Cartas[i].Peso == pesoCartaRepetida)
                    {
                        vecesRepetida++;
                    }
                    else
                    {
                        pesoCartaRepetida = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                        if (vecesRepetida < 2)
                        {
                            vecesRepetida = 0;
                        }
                    }
                    if (vecesRepetida == 2)
                    {
                        esPareja = true;
                        pesoPareja = jugadoresPoker[indiceJugador].Cartas[i].Peso;

                    }
                }
                if (esPareja)
                {
                    if (jugadoresPoker[indiceJugador].Cartas[0].Peso == 1 && pesoPareja != 1)
                    {
                        pesoCartaAlta1 = 14;
                        for (int i = jugadoresPoker[indiceJugador].Cartas.Count - 1; i >= 0; i--)
                        {
                            if (jugadoresPoker[indiceJugador].Cartas[i].Peso != pesoPareja)
                            {
                                int contadorCartaAlta = 0;
                                switch (contadorCartaAlta)
                                {
                                    case 0:
                                        pesoCartaAlta2 = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                                        break;
                                    case 1:
                                        pesoCartaAlta3 = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                                        break;
                                }
                                contadorCartaAlta++;
                            }
                        }
                    }
                    else
                    {
                        for (int i = jugadoresPoker[indiceJugador].Cartas.Count - 1; i >= 0; i--)
                        {
                            if (jugadoresPoker[indiceJugador].Cartas[i].Peso != pesoPareja)
                            {
                                int contadorCartaAlta = 0;
                                switch (contadorCartaAlta)
                                {
                                    case 0:
                                        pesoCartaAlta1 = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                                        break;
                                    case 1:
                                        pesoCartaAlta2 = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                                        break;
                                    case 2:
                                        pesoCartaAlta3 = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                                        break;
                                }
                                contadorCartaAlta++;
                            }
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        private bool ComprobarDoblePareja(int indiceJugador, out int pesoPareja1, out int pesoPareja2)
        {
            int pesoCartaRepetida = jugadoresPoker[indiceJugador].Cartas[jugadoresPoker[indiceJugador].Cartas.Count - 1].Peso;
            int vecesRepetida = 0;
            pesoPareja1 = -1;
            pesoPareja2 = -1;
            if (jugadoresPoker[indiceJugador].SigueEnRonda)
            {
                for (int i = jugadoresPoker[indiceJugador].Cartas.Count - 2; i >= 0; i--)
                {
                    if (jugadoresPoker[indiceJugador].Cartas[i].Peso == pesoCartaRepetida)
                    {
                        vecesRepetida++;
                    }
                    else
                    {
                        pesoCartaRepetida = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                        if (vecesRepetida < 2)
                        {
                            vecesRepetida = 0;
                        }
                    }

                    if (vecesRepetida == 2 && pesoPareja1 == -1)
                    {
                        pesoPareja1 = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                    }
                    else if (vecesRepetida == 2)
                    {
                        pesoPareja2 = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                    }

                    if (pesoPareja2 != pesoPareja1 && pesoPareja2 != -1 && pesoPareja1 != -1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool ComprobarTrio(int indiceJugador, out int pesoTrio)
        {
            int pesoCartaRepetida = jugadoresPoker[indiceJugador].Cartas[0].Peso;
            int vecesRepetida = 0;
            pesoTrio = -1;
            if (jugadoresPoker[indiceJugador].SigueEnRonda)
            {
                for (int i = 1; i < jugadoresPoker[indiceJugador].Cartas.Count; i++)
                {
                    if (jugadoresPoker[indiceJugador].Cartas[i].Peso == pesoCartaRepetida)
                    {
                        vecesRepetida++;
                    }
                    else
                    {
                        pesoCartaRepetida = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                        if (vecesRepetida < 3)
                        {
                            vecesRepetida = 0;
                        }
                    }

                    if (vecesRepetida == 3)
                    {
                        pesoTrio = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                        return true;
                    }
                }
            }
            return false;
        }
        private bool ComprobarEscalera(int indiceJugador, out int pesoMasAlto)
        {
            int contadorFinalCartasConsecutivas = 0;

            int pesoAnterior = jugadoresPoker[indiceJugador].Cartas[0].Peso;
            int comienzoRango = -1;
            int finRango = -1;

            int contador = 1;
            int contadorCartasConsecutivas = 1;

            //Establecer los pesos y palos iniciales sobre los que comparar
            int peso = jugadoresPoker[indiceJugador].Cartas[contador].Peso;
            string palo = jugadoresPoker[indiceJugador].Cartas[contador].Palo;

            while (contador < jugadoresPoker[indiceJugador].Cartas.Count)
            {
                if (jugadoresPoker[indiceJugador].SigueEnRonda)
                {
                    peso = jugadoresPoker[indiceJugador].Cartas[contador].Peso;
                    palo = jugadoresPoker[indiceJugador].Cartas[contador].Palo;
                    //Comprobar comienzo de las consecutivas y el final
                    if (peso == (pesoAnterior + 1)) //Si es correlativo el peso y el palo
                    {
                        contadorCartasConsecutivas++;   //Cuenta cartas correlativas

                        if (comienzoRango == -1)    //Si no ha sido modificado el comienzo del rango se establece en la posición anterior que es igual a la actual
                        {
                            comienzoRango = contador - 1;
                        }
                        pesoAnterior = peso;        //Establecer el peso a
                        finRango = contador;
                    }
                    else        //Si el peso no es correlativo y/o es de distinto palo
                    {
                        if (contadorCartasConsecutivas >= 5)    //Si el contador de cartas correlativas es igual o superior a 5 guardar como dato final válido
                        {
                            contadorFinalCartasConsecutivas = contadorCartasConsecutivas;
                            pesoMasAlto = finRango;
                            return true;
                        }
                        contadorCartasConsecutivas = 1;     //Reiniciar contador de cartas consecutivas
                        comienzoRango = -1;                 //Reiniciar rango comienzo
                        finRango = -1;                      //Reiniciar rango final
                    }
                }
                contador++;
                pesoAnterior = peso;
            }
            pesoMasAlto = finRango;
            if (contadorFinalCartasConsecutivas < 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }//Escalera
        private bool ComprobarEscaleraAlta(int indiceJugador)
        {
            bool valorAs = false, j = false, q = false, k = false, valor10 = false;

            for (int i = 0; i < jugadoresPoker[indiceJugador].Cartas.Count; i++)
            {
                if (jugadoresPoker[indiceJugador].Cartas[i].Peso == 1)
                {
                    valorAs = true;
                }
                else if (jugadoresPoker[indiceJugador].Cartas[i].Peso == 13)
                {
                    k = true;
                }
                else if (jugadoresPoker[indiceJugador].Cartas[i].Peso == 12)
                {
                    q = true;
                }
                else if (jugadoresPoker[indiceJugador].Cartas[i].Peso == 11)
                {
                    j = true;
                }
                else if (jugadoresPoker[indiceJugador].Cartas[i].Peso == 10)
                {
                    valor10 = true;
                }
            }
            return valorAs && valor10 && j && q && k;
        }//EscaleraAlta
        private bool ComprobarColor(int indiceJugador, out int pesoCarta1, out int pesoCarta2, out int pesoCarta3, out int pesoCarta4, out int pesoCarta5)
        {
            pesoCarta1 = -1;
            pesoCarta2 = -1;
            pesoCarta3 = -1;
            pesoCarta4 = -1;
            pesoCarta5 = -1;
            List<int> numeroCartasPaloX = ListaPalosRepetidos(jugadoresPoker[indiceJugador].Cartas); //Corazon, Pica, Rombo y Trebol
            bool color = false;
            int palo = -1;
            for (int i = 0; i < numeroCartasPaloX.Count; i++)
            {
                if (numeroCartasPaloX[i] >= 5)
                {
                    color = true;
                    palo = i;
                }
            }
            string[] valoresPalos = { "Corazón", "Pica", "Rombo", "Trebol" };
            if (color)
            {
                int contadorCarta = 0;
                for (int i = 0; i < jugadoresPoker[indiceJugador].Cartas.Count; i++)
                {
                    if (jugadoresPoker[indiceJugador].Cartas[i].Palo == valoresPalos[palo])
                    {
                        switch (contadorCarta)
                        {
                            case 0:
                                pesoCarta1 = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                                break;
                            case 1:
                                pesoCarta2 = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                                break;
                            case 2:
                                pesoCarta3 = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                                break;
                            case 3:
                                pesoCarta4 = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                                break;
                            case 4:
                                pesoCarta5 = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                                break;
                        }
                        contadorCarta++;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool ComprobarFull(int indiceJugador, out int pesoFullTrio, out int pesoFullPareja)
        {
            int pesoCartaRepetida = jugadoresPoker[indiceJugador].Cartas[0].Peso;
            int vecesRepetida = 0;
            pesoFullTrio = -1;
            pesoFullPareja = -1;
            if (jugadoresPoker[indiceJugador].SigueEnRonda)
            {
                for (int i = 1; i < jugadoresPoker[indiceJugador].Cartas.Count; i++)
                {
                    if (jugadoresPoker[indiceJugador].Cartas[i].Peso == pesoCartaRepetida)
                    {
                        vecesRepetida++;
                    }
                    else
                    {
                        pesoCartaRepetida = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                        if (vecesRepetida < 2)
                        {
                            vecesRepetida = 0;
                        }
                    }

                    if (vecesRepetida == 2 && jugadoresPoker[indiceJugador].Cartas[i + 1].Peso != pesoCartaRepetida)
                    {
                        pesoFullPareja = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                    }
                    if (vecesRepetida == 3)
                    {
                        pesoFullTrio = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                    }

                    if (pesoFullPareja != pesoFullTrio && pesoFullPareja != -1 && pesoFullTrio != -1)
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        private bool ComprobarPoker(int indiceJugador, out int pesoPoker)
        {
            int pesoCartaRepetida = jugadoresPoker[indiceJugador].Cartas[0].Peso;
            int vecesRepetida = 0;
            pesoPoker = -1;

            if (jugadoresPoker[indiceJugador].SigueEnRonda)
            {
                for (int i = 1; i < jugadoresPoker[indiceJugador].Cartas.Count; i++)
                {
                    if (jugadoresPoker[indiceJugador].Cartas[i].Peso == pesoCartaRepetida)
                    {
                        vecesRepetida++;
                    }
                    else
                    {
                        pesoCartaRepetida = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                        if (vecesRepetida < 4)
                        {
                            vecesRepetida = 0;
                        }
                    }

                    if (vecesRepetida >= 4)
                    {
                        pesoPoker = jugadoresPoker[indiceJugador].Cartas[i].Peso;
                        return true;
                    }
                }
            }
            return false;
        }
        private bool ComprobarEscaleraColor(int indiceJugador, out int pesoMasAlto)
        {
            int contadorFinalCartasConsecutivas = 0;

            int pesoAnterior = jugadoresPoker[indiceJugador].Cartas[0].Peso;
            string paloConsecutivas = jugadoresPoker[indiceJugador].Cartas[0].Palo;
            int comienzoRango = -1;
            int finRango = -1;

            int contador = 1;
            int contadorCartasConsecutivas = 1;

            //Establecer los pesos y palos iniciales sobre los que comparar
            int peso = jugadoresPoker[indiceJugador].Cartas[contador].Peso;
            string palo = jugadoresPoker[indiceJugador].Cartas[contador].Palo;

            while (contador < jugadoresPoker[indiceJugador].Cartas.Count)
            {
                if (jugadoresPoker[indiceJugador].SigueEnRonda)
                {
                    peso = jugadoresPoker[indiceJugador].Cartas[contador].Peso;
                    palo = jugadoresPoker[indiceJugador].Cartas[contador].Palo;
                    //Comprobar comienzo de las consecutivas y el final
                    if (peso == (pesoAnterior + 1) && palo == paloConsecutivas) //Si es correlativo el peso y el palo
                    {
                        contadorCartasConsecutivas++;   //Cuenta cartas correlativas

                        if (comienzoRango == -1)    //Si no ha sido modificado el comienzo del rango se establece en la posición anterior que es igual a la actual
                        {
                            comienzoRango = contador - 1;
                        }
                        pesoAnterior = peso;        //Establecer el peso a
                        finRango = contador;
                    }
                    else        //Si el peso no es correlativo y/o es de distinto palo
                    {
                        if (contadorCartasConsecutivas >= 5)    //Si el contador de cartas correlativas es igual o superior a 5 guardar como dato final válido
                        {
                            contadorFinalCartasConsecutivas = contadorCartasConsecutivas;
                            pesoMasAlto = finRango;
                            return true;
                        }
                        contadorCartasConsecutivas = 1;     //Reiniciar contador de cartas consecutivas
                        paloConsecutivas = palo;            //Ajutar el nuevo palo para la proxima comparación
                        comienzoRango = -1;                 //Reiniciar rango comienzo
                        finRango = -1;                      //Reiniciar rango final
                    }
                }
                contador++;
                pesoAnterior = peso;
            }
            pesoMasAlto = finRango;
            if (contadorFinalCartasConsecutivas < 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }//Escalera color
        private bool ComprobarEscaleraReal(int indiceJugador)
        {
            bool valorAs = false, j = false, q = false, k = false, valor10 = false;
            string paloAs = "";
            for (int i = 0; i < jugadoresPoker[indiceJugador].Cartas.Count; i++)
            {
                if (jugadoresPoker[indiceJugador].Cartas[i].Peso == 1)
                {
                    valorAs = true;
                    paloAs = jugadoresPoker[indiceJugador].Cartas[i].Palo;
                }
                else if (jugadoresPoker[indiceJugador].Cartas[i].Peso == 13 && jugadoresPoker[indiceJugador].Cartas[i].Palo.Equals(paloAs))
                {
                    k = true;
                }
                else if (jugadoresPoker[indiceJugador].Cartas[i].Peso == 12 && jugadoresPoker[indiceJugador].Cartas[i].Palo.Equals(paloAs))
                {
                    q = true;
                }
                else if (jugadoresPoker[indiceJugador].Cartas[i].Peso == 11 && jugadoresPoker[indiceJugador].Cartas[i].Palo.Equals(paloAs))
                {
                    j = true;
                }
                else if (jugadoresPoker[indiceJugador].Cartas[i].Peso == 10 && jugadoresPoker[indiceJugador].Cartas[i].Palo.Equals(paloAs))
                {
                    valor10 = true;
                }
            }
            return valorAs && valor10 && j && q && k;
        }//Escalera Real
        #endregion
    }
}