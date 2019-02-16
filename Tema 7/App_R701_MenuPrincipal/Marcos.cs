using System;

namespace App_R701_MenuPrincipal
{
    /// <summary>
    /// Enumeración que sirve para determinar los tipos de marco que puede usar la clase <see cref="Marcos"/>.
    /// </summary>
    public enum TipoMarco { Simple, Doble }
    /// <summary>
    /// Clase que sirve para crear y pintar un marco, con o sin cabecera, en la consola de comandos.
    /// </summary>
    public class Marcos
    {
        const int MARGEN_DERECHO = 1;
        const int MARGEN_INFERIOR = 1;
        string[] caracteresMarco;
        Coordenada vertice1;
        Coordenada vertice3;
        ConsoleColor color;

        /// <summary>
        /// Vertice superior izquierdo del marco.
        /// </summary>
        public Coordenada Vertice1 { get { return vertice1; } }
        /// <summary>
        /// Vertice superior derecho del marco.
        /// </summary>
        public Coordenada Vertice2 { get { return new Coordenada(Vertice3.X, Vertice1.Y); } }
        /// <summary>
        /// Vertice inferior derecho del marco.
        /// </summary>
        public Coordenada Vertice3 { get { return vertice3; } }
        /// <summary>
        /// Vertice inferior izquierdo del marco.
        /// </summary>
        public Coordenada Vertice4 { get { return new Coordenada(Vertice1.X, Vertice3.Y); } }
        /// <summary>
        /// Alto del marco.
        /// </summary>
        public int Alto { get { return Vertice3.Y - Vertice1.Y+1; } }
        /// <summary>
        /// Ancho del marco.
        /// </summary>
        public int Ancho { get { return Vertice3.X - Vertice1.X+1; } }
        /// <summary>
        /// Construye un marco dado sus vertices superior izquierdo e inferior derecho, tipo de marco y un color determinado.
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
                throw new ArgumentException("Las coordendas 'x' e 'y' del vértice 1 deben de ser menores que las coordenadas 'x' e 'y' del vértice 3.");
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
            const int CARACTERES_NO_USADOS_VERTICAL = 2;                //Caracteres del borde superior e inferior.
            const int CARACTERES_MINIMOS_CUERPO_MARCO = 2;              //Hueco dejado para escribir debajo
            ConsoleColor colorDefecto = Console.ForegroundColor;        //Almacena el color por defecto de la consola
            Console.ForegroundColor = color;                            //Cambia el color de la consola al pasado a la clase
            int recorridoCuerpo = Alto - CARACTERES_NO_USADOS_VERTICAL; //Recorrido del cuerpo (vertical) que hará el bucle

            if ((cabecera && tamanoCabecera < 1)||(cabecera && (Alto-tamanoCabecera)< (CARACTERES_NO_USADOS_VERTICAL+CARACTERES_MINIMOS_CUERPO_MARCO))) //Si se pinta cabecera y el valor es menor que 1 --> excepción. 
            {
                throw new ArgumentException("El tamaño de la cabecera debe de ser mayor a 1 o el tamaño del marco es demasiado pequeño y no deja hueco para cabeceza y cuerpo.");
            }
            if (cabecera)                                               //Si se pinta cabecera se cambia el recorrido del cuerpo
            {
                recorridoCuerpo -= tamanoCabecera + 1;
            }
            Console.SetCursorPosition(Vertice1.X, Vertice1.Y);          //Posicionar para comenzar a pintar
            Console.Write(caracteresMarco[0]);                          //Esquina superior izquierda (Vertice 1)
            for (int i = 0; i < Ancho - 1 - MARGEN_DERECHO; i++)                         
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
                Console.Write(caracteresMarco[4]);          //Separador izquierdo cabecera ├
                for (int i = 0; i < Ancho - 2; i++)
                {
                    Console.Write(caracteresMarco[1]);      //Borde separador
                }
                Console.Write(caracteresMarco[5]);          //Separador derecho cabecera ┤
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