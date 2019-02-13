using System;
using App_R701_MenuPrincipal;
namespace App_R702_MenuPrincipalPruebaDLL
{
    class Ej2_PruebaMenuPrincipal
    {
        static void Main(string[] args)
        {
            string[] opciones = CrearOpciones(201);
            MenuPrincipal menu = new MenuPrincipal("El titulo más largo del mundo para comprobar que esto se ajusta a lo que haga falta y crece hacia abajo haciendo sus saltos de linea para que quede todo ajustado y sin que se solapen los borden, mae mia que lio!!", opciones, ConsoleColor.Red, TipoMarco.Doble, EstiloTexto.alineadoIzquierda);
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();
            Console.CursorVisible = false;
            do
            {
                Console.Clear();
                menu.Pintar();
                tecla = Console.ReadKey(true);
                switch (tecla.Key)
                {
                    case ConsoleKey.LeftArrow:
                        menu.PaginaMenu--;
                        break;
                    case ConsoleKey.RightArrow:
                        menu.PaginaMenu++;
                        break;
                }
            } while (tecla.Key!= ConsoleKey.Escape);
        }
        public static string[] CrearOpciones(int nOpciones)
        {
            string[] opciones = new string[nOpciones];
            for (int i = 0; i < nOpciones; i++)
            {
                opciones[i] = "Opción "+(i + 1).ToString();
            }
            return opciones;
        }
    }
}
