using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace App_R701_MenuPrincipal
{
    public class Coordenada
    {
        int x;
        int y;
        public int X
        { 
            get { return x; }
            set
            {
                if (value<0)
                {
                    x = 0;
                }
                else if (value>(Console.LargestWindowWidth-1))
                {
                    Maximize();
                    x = Console.WindowWidth - 2;
                }
                else if (value>(Console.WindowWidth-1))
                { 
                    x = Console.WindowWidth - 3;
                }
                else
                {
                    x = value;
                }
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                if (value < 0)
                {
                    y = 0;
                }
                else if (value > (Console.LargestWindowHeight - 3))
                {
                    Maximize();
                    y = Console.WindowHeight - 2;
                    
                }
                else if (value > (Console.WindowHeight - 1))
                {
                    y = Console.WindowHeight - 2;
                }
                else
                {
                    y = value;
                }
            }
        }

        public Coordenada()
        {
            x = 0;
            y = 0;
        }
        public Coordenada(int x, int y)
        {
            X = x;
            Y = y;
        }

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);
        public static void Maximize()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
        }
    }
}