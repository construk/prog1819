using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_R620_JuegoCartas
{
    class JugadorPokerHoldem
    {
        #region CAMPOS
        string nombre;
        List<Carta> manoCartas;
        int dinero;
        IJugador accionJugador;

        int apuestaActual;
        bool sigueEnMesa;
        bool sigueEnRonda;
        int vaConXDineroRonda;
        List<int> valoresJugadaCartas;
        #endregion

        #region PROPIEDADES       
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Dinero
        {
            get { return dinero; }
            set
            {
                if (value<0)
                {
                    dinero = 0;
                }
                else
                {
                    dinero = value;
                }
            }
        }
        public List<Carta> Cartas
        {
            get { return manoCartas; }
        }
        public int DineroApuesta
        {
            get { return apuestaActual; }
            set
            {
                if (value<0)
                {
                    Console.WriteLine("La apuesta no puede ser negativa.\n Apuesta ajustada a 0.");
                    apuestaActual = 0;
                }
                else if (value>dinero)
                {
                    Console.WriteLine("Dinero apostado es mayor al dinero que contienes. Apuesta reajustada: {0}",dinero);
                    apuestaActual = dinero;
                }
                else
                {
                    apuestaActual = value;
                }
            }
        }
        public bool SigueEnMesa
        {
            get { return sigueEnMesa; }
            set { sigueEnMesa = value; }
        }
        public bool SigueEnRonda
        {
            get { return sigueEnRonda; }
            set { sigueEnRonda = value; }
        }
        public int ValorMano
        {
            get { return valoresJugadaCartas[0]; }
            set { valoresJugadaCartas[0] = value; }
        }
        public int ValorCarta1
        {
            get { return valoresJugadaCartas[1]; }
            set { valoresJugadaCartas[1] = value; }
        }
        public int ValorCarta2
        {
            get { return valoresJugadaCartas[2]; }
            set { valoresJugadaCartas[2] = value; }
        }
        public int ValorCarta3
        {
            get { return valoresJugadaCartas[3]; }
            set { valoresJugadaCartas[3] = value; }
        }
        public int ValorCarta4
        {
            get { return valoresJugadaCartas[4]; }
            set { valoresJugadaCartas[4] = value; }
        }
        public int ValorCarta5
        {
            get { return valoresJugadaCartas[5]; }
            set { valoresJugadaCartas[5] = value; }
        }
        public int VaCon
        { get { return vaConXDineroRonda; }
            set
            {
                if (value<0)
                {
                    value = 0;
                }
                else
                {
                    vaConXDineroRonda = value;
                }
            }
        }
        #endregion

        #region CONSTRUCTORES
        public JugadorPokerHoldem(string nombre, int dinero, IJugador accionJugador)
        {
            Nombre = nombre;
            Dinero = dinero;
            this.accionJugador = accionJugador;
            apuestaActual = 0;
            manoCartas = new List<Carta>();
            valoresJugadaCartas = new List<int>();
            vaConXDineroRonda = 0;
            for (int i = 0; i < 10; i++)
            {
                valoresJugadaCartas.Add(0);
            }
        }
        #endregion

        #region MÉTODOS
        public void PedirCarta()
        {
            accionJugador.RecibirCarta();
        }
        public void RetirarseJugada()
        {
            accionJugador.NoIrJugada();
        }
        public void Apostar(int cantidadASubir)
        {
            accionJugador.IgualarYSubir(cantidadASubir); 
        }
        public void SalirMesa()
        {
            accionJugador.SalirDeLaMesa();
        }
        public void AllIn()
        {
            accionJugador.AllIn();
        }
        public void PasarSiNoSubido()
        {
            accionJugador.IgualarYPasar();
        }
        #endregion

        #region INTERFAZ
        public interface IJugador
        {
            void RecibirCarta();
            void NoIrJugada();
            void SalirDeLaMesa();
            void IgualarYSubir(int cantidadASubir);
            void AllIn();
            void IgualarYPasar();
        }
        #endregion
    }
}
