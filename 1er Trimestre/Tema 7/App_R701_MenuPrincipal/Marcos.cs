using System;

namespace App_R701_MenuPrincipal
{
    public enum TipoMarco { Simple, Doble }
    public class Marcos
    {
        string[] caracteresMarco;
        Coordenada vertice1;
        Coordenada vertice3;
        ConsoleColor color;

        /// <summary>
        /// Vertice superior izquierdo del marco
        /// </summary>
        public Coordenada Vertice1 { get { return vertice1; } }
        /// <summary>
        /// Vertice superior derecho del marco
        /// </summary>
        public Coordenada Vertice2 { get { return new Coordenada(Vertice3.X, Vertice1.Y); } }
        /// <summary>
        /// Vertice inferior derecho del marco
        /// </summary>
        public Coordenada Vertice3 { get { return vertice3; } }
        /// <summary>
        /// Vertice inferior izquierdo del marco
        /// </summary>
        public Coordenada Vertice4 { get { return new Coordenada(Vertice1.X, Vertice3.Y); } }
        /// <summary>
        /// Alto del marco
        /// </summary>
        public int Alto { get { return Vertice3.Y - Vertice1.Y+1; } }
        /// <summary>
        /// Ancho del marco
        /// </summary>
        public int Ancho { get { return Vertice3.X - Vertice1.X+1; } }
        /// <summary>
        /// Construye un marco dado sus vertices superior izquierdo e inferior derecho, tipo de marco y un color determinado
        /// </summary>
        /// <param name="vertice1">Coordenada de la posición superior izquierda</param>
        /// <param name="vertice3">Coordenada de la posición superior izquierda</param>
        /// <param name="tipo">Tipo de marco: Simple o Doble</param>
        /// <param name="color">Color de consola que indica el color del marco</param>
        /// <exception cref="ArgumentException">Se da cuando el Vertice3 no está posicionado debajo y a la derecha del Vertice1 o la cabecera no cumple con el formato adecuado.</exception>
        public Marcos(Coordenada vertice1, Coordenada vertice3, TipoMarco tipo, ConsoleColor color)
        {
            if (vertice3.X <= vertice1.X || vertice3.Y <= vertice1.Y)
            {
                throw new ArgumentException();
            }
            this.vertice1 = vertice1;
            this.vertice3 = vertice3;
            this.caracteresMarco = RellenarCaracteresMarco(tipo);
            this.color = color;
        }
        /// <summary>
        /// Sirve para pintar el marco con o sin cabecera.
        /// </summary>
        /// <param name="cabecera">True para pintar con cabecera. Si está activada la cabecera la Altura mínima del marco es 4.</param>
        /// <param name="tamanoCabecera">Determina el tamaño del hueco de la cabecera. Valor mínimo 1. Solo sirve si cabecera está activada.</param>
        /// <remarks>Si Alto-tamanoCabecera es menor que 4 provoca excepción</remarks>
        public void Pinta(bool cabecera, int tamanoCabecera)
        {
            ConsoleColor colorDefecto = Console.ForegroundColor;        //Almacena el color por defecto de la consoa
            Console.ForegroundColor = color;                            //Cambia el color de la consola al pasado a la clase
            int recorridoCuerpo = Alto - 2;                             //Recorrido del cuerpo (vertical) que hará el bucle

            if ((cabecera && tamanoCabecera < 1)||(cabecera && (Alto-tamanoCabecera)< 4)) //Si se pinta cabecera y el valor es menor que 1 --> excepción. 
            {
                throw new ArgumentException();
            }
            if (cabecera)                                               //Si se pinta cabecera se cambia el recorrido del cuerpo
            {
                recorridoCuerpo -= tamanoCabecera + 1;
            }

            Console.SetCursorPosition(Vertice1.X, Vertice1.Y);          //Posicionar para comenzar a pintar
            Console.Write(caracteresMarco[0]);                          //Esquina superior izquierda (Vertice 1)
            for (int i = 0; i < Ancho - 2; i++)                         
            {
                Console.Write(caracteresMarco[1]);                      //Borde superior
            }
            Console.Write(caracteresMarco[2]);                          //Esquina superior derecha  (Vertice 2)

            if (cabecera)                                               //Si se pinta la cabecera se pinta el separador entre la cabecera y el
            {
                for (int i = 0; i < tamanoCabecera; i++)
                {
                    Console.SetCursorPosition(vertice1.X, ++Console.CursorTop);
                    Console.Write(caracteresMarco[3]);      //Lateral izquierdo cabecera
                    Console.CursorLeft = Vertice3.X;
                    Console.Write(caracteresMarco[3]);      //Lateral derecho cabecera
                }
                Console.SetCursorPosition(vertice1.X, ++Console.CursorTop);
                Console.Write(caracteresMarco[4]);          //Separador izquierdo cabecera
                for (int i = 0; i < Ancho - 2; i++)
                {
                    Console.Write(caracteresMarco[1]);      //Borde separador
                }
                Console.Write(caracteresMarco[5]);          //Separador derecho cabecera
            }

            for (int i = 0; i < recorridoCuerpo; i++)
            {
                Console.SetCursorPosition(vertice1.X, ++Console.CursorTop);
                Console.Write(caracteresMarco[3]);      //Lateral izquierdo
                Console.CursorLeft = Vertice3.X;
                Console.Write(caracteresMarco[3]);      //Lateral derecho
            }
            Console.SetCursorPosition(vertice1.X, ++Console.CursorTop);
            Console.Write(caracteresMarco[6]);          //Esquina inferior izquierda (Vertice 4)
            for (int i = 0; i < Ancho - 2; i++)
            {
                Console.Write(caracteresMarco[1]);      //Borde inferior
            }
            Console.Write(caracteresMarco[7]);          //Esquina inferior derecha (Vertice 3)

            Console.ForegroundColor = colorDefecto;
        }
        /// <summary>
        /// Sirve para rellenar caracteresMarco según el tipo de marco utilizado.
        /// </summary>
        /// <param name="tipoMarco">Enumeración: simple o doble.</param>
        /// <returns>El array de string con el formato elegido.</returns>
        private static string[] RellenarCaracteresMarco(TipoMarco tipoMarco)
        {
            if (tipoMarco == TipoMarco.Simple)
            {
                return new string[] { "┌", "─", "┐", "│", "├", "┤", "└", "┘" };
            }
            else
            {
                return new string[] { "╔", "═", "╗", "║", "╠", "╣", "╚", "╝" };
            }
        }
    }
}