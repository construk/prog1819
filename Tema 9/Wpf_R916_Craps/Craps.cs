using System;
using System.ComponentModel;

namespace Wpf_R916_Craps
{
    class Craps : INotifyPropertyChanged
    {
        public delegate void DlgEvtVictoriaODerrota(bool victoria);
        public event DlgEvtVictoriaODerrota Evt_ResultadoPartida;
        public event PropertyChangedEventHandler PropertyChanged;

        Random rnd;
        readonly int[] valorPrimeraRondaVictoria = { 7, 11 };
        readonly int[] valorCrapsPrimeraRonda = { 2, 3, 12 };
        readonly int[] valorPunto = { 4, 5, 6, 8, 9, 10 };
        const int valorCrapRondasSiguientes = 7;
        const int PUNTOS_PARA_GANAR = 2;

        bool primeraRonda;
        int valorDado1;
        int valorDado2;
        int puntosJugador;

        public int ValorDado1 { get { return valorDado1; } set { valorDado1 = value; OnPropertyChanged("ValorDado1"); OnPropertyChanged("SumaValorDados"); } }
        public int ValorDado2 { get { return valorDado2; } set { valorDado2 = value; OnPropertyChanged("ValorDado2"); OnPropertyChanged("SumaValorDados"); } }
        public int PuntosJugador { get { return puntosJugador; } set { puntosJugador = value; OnPropertyChanged("PuntosJugador"); } }
        public void ReiniciarPartida()
        {
            this.ValorDado1 = 0;
            this.ValorDado2 = 0;
            this.PuntosJugador = 0;
            this.primeraRonda = true;
        }
        public int SumaValorDados
        {
            get { return ValorDado1 + ValorDado2; }
        }
        public bool Victoria
        {
            get
            {
                if (ComprobarVictoriaPrimeraRonda())
                {
                    return true;
                }
                if (ComprobarVictoriaDemasRondas())
                {
                    return true;
                }
                return false;
            }
        }
        public bool Derrota
        {
            get
            {
                if (ComprobarDerrotaPrimeraRonda())
                {
                    return true;
                }
                if (ComprobarDerrotaDemasRondas())
                {
                    return true;
                }
                return false;
            }
        }
        #region Métodos para propiedades
        private bool ComprobarVictoriaPrimeraRonda()
        {
            bool victoria = false;
            int contadorProbarValoresVictoria = 0;
            if (primeraRonda)
            {
                while (!victoria && contadorProbarValoresVictoria < valorPrimeraRondaVictoria.Length)
                {
                    if (SumaValorDados == valorPrimeraRondaVictoria[contadorProbarValoresVictoria])
                    {
                        victoria = true;
                    }
                    contadorProbarValoresVictoria++;
                }
                return victoria;
            }
            return victoria;
        }
        private bool ComprobarVictoriaDemasRondas()
        {
            if (!primeraRonda)
            {
                if (PuntosJugador == PUNTOS_PARA_GANAR)
                {
                    return true;
                }
            }
            return false;
        }
        private bool ComprobarDerrotaPrimeraRonda()
        {
            bool derrota = false;
            int contadorProbarValoresDerrota = 0;
            if (primeraRonda)
            {
                while (!derrota && contadorProbarValoresDerrota < valorCrapsPrimeraRonda.Length)
                {
                    if (SumaValorDados == valorCrapsPrimeraRonda[contadorProbarValoresDerrota])
                    {
                        derrota = true;
                    }
                    contadorProbarValoresDerrota++;
                }
                return derrota;
            }
            return derrota;
        }
        private bool ComprobarDerrotaDemasRondas()
        {
            if (!primeraRonda)
            {
                if (SumaValorDados == valorCrapRondasSiguientes)
                {
                    return true;
                }
            }
            return false;
        }
        private bool ComprobarSiPunto()
        {
            bool punto = false;
            int contadorProbarValoresPunto = 0;

            while (!punto && contadorProbarValoresPunto < valorPunto.Length)
            {
                if (SumaValorDados == valorPunto[contadorProbarValoresPunto])
                {
                    punto = true;
                }
                contadorProbarValoresPunto++;
            }
            return punto;
        }
        #endregion
        public Craps()
        {
            rnd = new Random();
            PuntosJugador = 0;
            ValorDado1 = 0;
            ValorDado2 = 0;
            primeraRonda = true;
        }
        public void TirarDados()
        {
            if (!Victoria && !Derrota)
            {
                ValorDado1 = rnd.Next(1, 7);
                ValorDado2 = rnd.Next(1, 7);
                if (ComprobarSiPunto())
                {
                    PuntosJugador++;
                    if (Victoria)
                    {
                        if (Evt_ResultadoPartida != null)
                        {
                            Evt_ResultadoPartida(true);
                        }
                    }
                }
                else if (Victoria)
                {
                    if (Evt_ResultadoPartida != null)
                    {
                        Evt_ResultadoPartida(true);
                    }
                }
                else if(Derrota)
                {
                    if (Evt_ResultadoPartida != null)
                    {
                        Evt_ResultadoPartida(false);
                    }
                }
            }
            primeraRonda = false;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        public RelayCommand TirarDado_Click
        {
            get { return new RelayCommand(o => TirarDados(), o => true); }
        }
    }
}

