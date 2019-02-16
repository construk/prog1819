using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace App_R701_MenuPrincipal
{
    /// <summary>
    /// Coordenada de consola, compuesta por dos puntos X e Y determinan una posición dentro de la Consola de comandos.
    /// </summary>
    public class Coordenada
    {
        const int MARGEN_DERECHO = 1;
        const int MARGEN_INFERIOR = 1;
        int x;
        int y;
        /// <summary>
        /// X de la coordenada. Determina la posición horizontal de la coordenada. (min: 0, max: Console.LargestWindowWidth - 2)
        /// </summary>
        public int X
        {
            get { return x; }
            set
            {
                if (value < 0)
                {
                    x = 0;
                }
                else if (value > (Console.LargestWindowWidth - 1 - MARGEN_DERECHO))
                {
                    Maximize();
                    x = Console.WindowWidth - 1 - MARGEN_DERECHO;
                }
                else if (value > (Console.WindowWidth - 1 - MARGEN_DERECHO))
                {
                    x = Console.WindowWidth - 1 - MARGEN_DERECHO;
                }
                else
                {
                    x = value;
                }
            }
        }
        /// <summary>
        /// Y de la coordenada. Determina la posición vertical de la coordenada. (min: 0, max: Console.LargestWindowHeight - 2)
        /// </summary>
        public int Y
        {
            get { return y; }
            set
            {
                if (value < 0)
                {
                    y = 0;
                }
                else if (value > (Console.LargestWindowHeight - 1 - MARGEN_INFERIOR))
                {
                    Maximize();
                    y = Console.WindowHeight - 1 - MARGEN_INFERIOR;

                }
                else if (value > (Console.WindowHeight - 1 - MARGEN_INFERIOR))
                {
                    y = Console.WindowHeight - 1 - MARGEN_INFERIOR;
                }
                else
                {
                    y = value;
                }
            }
        }
        /// <summary>
        /// Constructor vacio. Crea la coordenada en la posición (0,0).
        /// </summary>
        public Coordenada()
        {
            x = 0;
            y = 0;
        }
        /// <summary>
        /// Crea la coordenada en la posición x e y que le indiques. X -> (min: 0, max: Console.LargestWindowWidth - 2), Y -> (min: 0, max: Console.LargestWindowHeight - 2).
        /// </summary>
        public Coordenada(int x, int y)
        {
            X = x;
            Y = y;
        }
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);
        /// <summary>
        /// Método que permite maximizar la ventana de la consola para poder definir coordenadas en posiciones mayores.
        /// </summary>
        public static void Maximize()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
        }
    }
}