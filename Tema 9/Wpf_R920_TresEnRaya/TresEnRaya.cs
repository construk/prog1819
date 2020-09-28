namespace Wpf_R920_TresEnRaya
{
    /// <summary>
    /// Posibles valores en el juego. El jugador que ha ganado o la pertenencia de las fichas en el tablero
    /// </summary>
    public enum ValoresJuego { Vacio = -1, Jugador = 0, Jugador2 = 1 }
    
    /// <summary>
    /// Clase que permite jugar al 3 en raya o tic tac toe, con otro jugador o contra una IA que funciona mediante el algoritmo Minimax.
    /// </summary>
    class TresEnRaya
    {
        #region PROPIEDADES

        /// <summary>
        /// Obtener tablero del 3 en raya, posibles valores: Vacio-> -1, Jugador->0, Jugador2->1
        /// </summary>
        public int[,] Tablero { get; }

        /// <summary>
        /// Devuelve las coordenadas X[0]: fila, Y[1]: columna, de la casilla seleccionada por la IA (para comunicación con interfaces).
        /// </summary>
        public int[] UltimaJugadaIA { get; }

        /// <summary>
        /// Propiedad que devuelve quién ha ganado la partida. Jugador1:0, Jugador2/IA = 1, Ninguno=-1
        /// </summary>
        public int GanadorPartida
        {
            get
            {
                //Diagonales
                if (Tablero[0, 0] != -1 && Tablero[0, 0] == Tablero[1, 1] && Tablero[0, 0] == Tablero[2, 2])
                {
                    return Tablero[0, 0];
                }
                if (Tablero[0, 2] != -1 && Tablero[0, 2] == Tablero[1, 1] && Tablero[0, 2] == Tablero[2, 0])
                {
                    return Tablero[0, 2];
                }
                //Horizontales y verticales
                int i = 0;
                bool horizontal = false;
                bool vertical = false;
                //Mientras no encuentre ninguna combinación ganadora y sea menor que 3 (el length de 1 dimensión)
                while (!horizontal && !vertical && i < Tablero.GetLength(0))
                {
                    horizontal = Tablero[i, 0] != -1 && Tablero[i, 0] == Tablero[i, 1] && Tablero[i, 0] == Tablero[i, 2];
                    vertical = Tablero[0, i] != -1 && Tablero[0, i] == Tablero[1, i] && Tablero[0, i] == Tablero[2, i];
                    //Si no encuentra combinación incrementa.
                    if (!horizontal && !vertical)
                    {
                        i++;
                    }
                }
                //Si la combinación es horizontal devuelve el valor (0 --> Jugador; 1 --> Maquina) del ganador
                if (horizontal)
                {
                    return Tablero[i, 0];
                }
                //Si la combinación es vertical devuelve el valor (0 --> Jugador; 1 --> Maquina) del ganador
                else if (vertical)
                {
                    return Tablero[0, i];
                }
                //Sino devuelve -1 (nadie ha ganado)
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Devuelve true si el tablero está completo, false en caso contrario.
        /// Comprueba si se ha completado el tablero, es decir si algún elemento es ValoresJuego.Vacio (-1) o no.
        /// </summary>
        public bool IsTableroCompleto
        {
            get
            {
                int i = 0;
                bool noElementoVacio = true;
                while (noElementoVacio && i < Tablero.GetLength(0))
                {
                    int j = 0;
                    while (noElementoVacio && j < Tablero.GetLength(1))
                    {
                        if (Tablero[i, j] == (int)ValoresJuego.Vacio)
                        {
                            noElementoVacio = false;
                        }
                        j++;
                    }
                    i++;
                }
                return noElementoVacio;
            }
        }

        /// <summary>
        /// Devuelve true si la partida ha acabado, false en caso contrario.
        /// Comprueba si ha acabado la partida, es decir si el tablero está completo o si hay algún ganador.
        /// </summary>
        public bool FinPartida => IsTableroCompleto || GanadorPartida != (int)ValoresJuego.Vacio;

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Construye una partida de 3 en raya
        /// </summary>        
        public TresEnRaya()
        {
            Tablero = new int[3, 3];
            UltimaJugadaIA = new int[2];
        }
        #endregion

        #region MÉTODOS

        #region PÚBLICOS
        /// <summary>
        /// Método que inicializa el tablero y establece que nadie ha ganado.
        /// </summary>
        public void EmpezarPartida()
        {
            for (int i = 0; i < Tablero.GetLength(0); i++)
            {
                for (int j = 0; j < Tablero.GetLength(1); j++)
                {
                    Tablero[i, j] = (int)ValoresJuego.Vacio;
                }
            }
        }

        /// <summary>
        /// Función que permite pulsar un botón para partidas con IA.
        /// </summary>
        /// <param name="n">Posición fila</param>
        /// <param name="m">Posición columna</param>
        public void PulsarBoton(int n, int m)
        {
            //Si está en el rango posible del juego, el valor está vacio y no hay ganador.
            if (n >= 0 && n < 3 && m >= 0 && m < 3 && Tablero[n, m] == (int)ValoresJuego.Vacio && GanadorPartida == (int)ValoresJuego.Vacio)
            {
                Tablero[n, m] = (int)ValoresJuego.Jugador;  //Asigna el valor indicado al tablero
                PonerFichaOrdenador();                      //La IA pone ficha
            }
        }

        /// <summary>
        /// Función que permite pulsar un botón para partidas sin IA.
        /// </summary>
        /// <param name="n">Posición fila</param>
        /// <param name="m">Posición columna</param>
        /// <param name="jugador">Si es true pulsa el botón el jugador 1, sino el jugador 2.</param>
        public void PulsarBoton(int n, int m, bool jugador)
        {
            //Si está en el rango posible del juego, el valor está vacio y no hay ganador.
            if (n >= 0 && n < 3 && m >= 0 && m < 3 && Tablero[n, m] == (int)ValoresJuego.Vacio && GanadorPartida == (int)ValoresJuego.Vacio)
            {
                ValoresJuego jugadorTmp;                    //Variable para recoger si establece ficha el jugador1 o jugador2
                if (jugador)                                
                    jugadorTmp = ValoresJuego.Jugador;      //Guarda valor Jugador
                else
                    jugadorTmp = ValoresJuego.Jugador2;     //Guarda valor jugador2

                Tablero[n, m] = (int)jugadorTmp;            //Establece el valor en el tablero
            }
        }

        //======================        COMIENZA LÓGICA DE MINIMAX          =====================================================================

        /// <summary>
        /// Si la partida no ha finalizado (finaliza si tablero está completo o hay un ganador) la IA pone ficha en el lugar más óptimo según el algoritmo MiniMax
        /// </summary>
        public void PonerFichaOrdenador()
        {
            //Si no ha acabado la partida realizar el cálculo de la posición más óptima y poner ficha
            if (!FinPartida)
            {
                int x = 0;
                int y = 0;
                int valorJugada = int.MinValue;
                int aux;

                //Este método es similar al Max, pero en él se recogen las llamadas finales recursivas y si la jugada es mejor a otra anterior guarda en 'x' e 'y' la posición más optima donde pulsar.
                //Recorrer tablero verticalmente
                for (int i = 0; i < Tablero.GetLength(0); i++)
                {
                    //Recorrer tablero horizontalmente
                    for (int j = 0; j < Tablero.GetLength(1); j++)
                    {
                        // Si hay un hueco libre comprobar con Min. Con cada recorrido de este bucle se coloca la ficha en una de las posiciones posibles (posiciones con valor vacio),
                        // y posteriormentese hace una llamada recursiva que comprueba alternando entre Min y Max para hayar lo que más le conviene a la máquina.
                        if (Tablero[i, j] == (int)ValoresJuego.Vacio)
                        {
                            //Simula seleccionar la casilla del tablero
                            Tablero[i, j] = (int)ValoresJuego.Jugador2;
                            //Realiza algoritmo Min que se ejecuta de forma recursiva.
                            aux = Min();
                            //Si el resultado de ejecutar el MiniMax es mayor que el valor de la jugada, asignar a valorJugada. 
                            //Y guardar posición la 'x' e 'y' (de la casilla seleccionada) para saber la opción más óptima.
                            if (aux > valorJugada)
                            {
                                valorJugada = aux;
                                x = i;
                                y = j;
                            }
                            //Deseleccionar la casilla seleccionada para la simulación.
                            Tablero[i, j] = (int)ValoresJuego.Vacio;
                        }
                    }
                }
                //Seleccionar la posición más óptima calculada.
                Tablero[x, y] = (int)ValoresJuego.Jugador2;
                //Establecer el valor de 'x' e 'y' para saber que botón ha pulsado la IA
                UltimaJugadaIA[0] = x;
                UltimaJugadaIA[1] = y;
            }
        }
        #endregion MÉTODOS PÚBLICOS

        #region PRIVADOS (MIN y MAX)
        /// <summary>
        /// Esta función se encarga de maximizar el beneficio de la maquina ante el jugador. Se queda con la partida que más beneficio le aporte a la máquina.
        /// Esta función en la recursividad representa el movimiento realizado por la IA.
        /// </summary>
        /// <returns>Devuelve el valor de la partida que más beneficia a la IA.</returns>
        private int Max()
        {
            //Si la partida ha terminado comprueba el resultado
            if (FinPartida)
            {
                //Si alguien ha ganado la partida
                if (GanadorPartida != (int)ValoresJuego.Vacio)
                {
                    return (int)ValoresJuego.Vacio;
                }
                //Si hay empate
                else
                {
                    return (int)ValoresJuego.Jugador;
                }
            }
            //Si la partida no ha terminado realiza el cálculo 
            int valorJugada = int.MinValue;
            int aux;
            //Recorrer verticalmente
            for (int i = 0; i < Tablero.GetLength(0); i++)
            {
                //Recorrer horizontalmente. Con cada recorrido de este bucle se coloca la ficha en una de las posiciones posibles (posiciones con valor vacio),
                // y posteriormentese hace una llamada recursiva que comprueba alternando entre Min y Max para hayar lo que más le conviene a la máquina.
                for (int j = 0; j < Tablero.GetLength(1); j++)
                {
                    // Si hay un hueco libre comprobar con Min. 
                    if (Tablero[i, j] == (int)ValoresJuego.Vacio)
                    {
                        //Simula colocar la ficha en dicha posición.
                        Tablero[i, j] = (int)ValoresJuego.Jugador2;
                        aux = Min();            //<-- La mágia.
                        //Si el valor obtenido es mayor (más beneficioso) que el valor anteior de la jugada, se sustituye la jugada.
                        if (aux > valorJugada)
                        {
                            valorJugada = aux;
                        }
                        //Se quita la ficha para probar en la siguiente ejecución del bucle en otro hueco posible.
                        Tablero[i, j] = (int)ValoresJuego.Vacio;
                    }
                }
            }
            //Finalmente devuelve la jugada con mayor valoración.
            return valorJugada;
        }
        /// <summary>
        /// Esta función se encarga de minimizar el beneficio del jugador ante la máquina. Se queda con la partida que menos beneficio le aporte al jugador.
        /// Esta función en la recursividad representa el movimiento realizado por el jugador.
        /// </summary>
        /// <returns>Devuelve el valor de la partida que menos beneficio le aporte al jugador.</returns>
        private int Min()
        {
            //Si ha acabado la partida devuelve el ganador.
            if (FinPartida)
            {

                if (GanadorPartida != (int)ValoresJuego.Vacio)
                {
                    return (int)ValoresJuego.Jugador2;
                }
                else
                {
                    return (int)ValoresJuego.Jugador;
                }
            }
            //Si no ha acabado la partida realiza el cálculo.
            int valorJugada = int.MaxValue;
            int aux;
            //Recorre verticalmente
            for (int i = 0; i < Tablero.GetLength(0); i++)
            {
                //Recorre horizontalmente
                for (int j = 0; j < Tablero.GetLength(1); j++)
                {
                    //Si hay hueco libre realiza simulación de colocar ficha y llamada recursiva
                    if (Tablero[i, j] == (int)ValoresJuego.Vacio)
                    {
                        //Establecer la ficha del jugador y hacer llamada recursiva a la función Max
                        Tablero[i, j] = (int)ValoresJuego.Jugador;
                        aux = Max();
                        //Si la jugada es menos beneficiosa para el jugador (más beneficiosa para la IA) se guarda el valor de la jugada.
                        if (aux < valorJugada)
                        {
                            valorJugada = aux;
                        }
                        //Se quita la ficha para probar en la siguiente ejecución del bucle en otro hueco posible.
                        Tablero[i, j] = (int)ValoresJuego.Vacio;
                    }
                }
            }
            return valorJugada;
        }

        //======================         FIN LÓGICA DE MINIMAX              =====================================================================

        #endregion MÉTODOS PRIVADOS

        #endregion MÉTODOS
    }
}