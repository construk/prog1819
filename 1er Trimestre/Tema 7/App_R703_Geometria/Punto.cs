using System;

namespace Geometria
{
    /// <summary>
    /// Clase punto compuesto por dos cordenadas x e y.
    /// </summary>
    public class Punto
    {
        #region Campos
        int x;
        int y;
        #endregion
        #region Propiedades
        /// <summary>
        /// Propiedad de solo lectura de la coordenada 'x' del punto.
        /// </summary>
        public int X
        {
            get { return x; }
        }
        /// <summary>
        ///Propiiedad de solo lectura de la coordenada 'y' del punto.
        /// </summary>
        public int Y
        {
            get { return y; }
        }
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor vacio de un punto que lo inicializa con los valores x=0 e y=0.
        /// </summary>
        public Punto()
        { this.x = 0; this.y = 0; }
        /// <summary>
        /// Constructor de un punto que lo inicializa a partir de los valores pasados como parámetros.
        /// </summary>
        /// <param name="x">Valor de la coordenada x (posición horizontal).</param>
        /// <param name="y">Valor de la coordenada y (posición vertical).</param>
        /// <exception cref="ArgumentOutOfRangeException">Excepción que se produce si el Punto está en una posición fuera de la Consola. Es decir, si x>(Console.WindowWidth - 1) o y > (Console.WindowHeight - 1) o si x e y son menores que 0."/></exception>
        public Punto(int x, int y)
        {
            if (x < 0 || y < 0 || x > (Console.WindowWidth - 1) || y > (Console.WindowHeight - 1))
            {
                throw new ArgumentOutOfRangeException("Punto fuera del rango permitido.");
            }
            else
            {
                this.x = x;
                this.y = y;
            }
        }
        #endregion
    }
    /// <summary>
    /// Excepción resultante si no cumple las condiciones de un cuadrado (lado = lado).
    /// </summary>
    public class NoCuadradoException : Exception
    {
        public override string Message
        {
            get { return "Los parámetros pasados no corresponden con los de un cuadrado."; }
        }
    }
    /// <summary>
    /// Clase Cuadrado que nos permite crearlos, obtener sus propiedades, pintarlo y obtener un string que lo representa.
    /// </summary>
    public class Cuadrado
    {
        #region Campos
        Punto vertice1;
        Punto vertice3;
        #endregion
        #region Propiedades
        /// <summary>
        /// Obtener o modificar el lado de un cuadrado.
        /// <exception cref="ArgumentOutOfRangeException">Excepción que se produce si al establecer el lado el Punto del vértice 3 está en una posición fuera de la Consola. Es decir, si x>(Console.WindowWidth - 1) o y > (Console.WindowHeight - 1) o si x e y son menores que 0."/></exception>
        /// </summary>
        public int Lado
        {
            get { return vertice3.X - vertice1.X; }
            set
            {
                vertice3 = new Punto(Vertice1.X + value, Vertice1.Y + value);
            }
        }
        /// <summary>
        /// Obtiene el área del cuadrado.
        /// </summary>
        public int Area
        {
            get { return Lado * Lado; }
        }
        /// <summary>
        /// Obtener el perímetro del cuadrado
        /// </summary>
        public int Perimetro
        {
            get { return Lado * 4; }
        }

        /// <summary>
        /// Obtener el Punto del vertice 1 (arriba izquierda).
        /// </summary>
        public Punto Vertice1 { get { return vertice1; } }
        /// <summary>
        /// Obtener el Punto del vertice 2 (arriba derecha).
        /// </summary>
        public Punto Vertice2
        {
            get { return new Punto(vertice3.X, vertice1.Y); }
        }
        /// <summary>
        /// Obtener el Punto del vertice 3 (abajo derecha).
        /// </summary>
        public Punto Vertice3 { get { return vertice3; } }
        /// <summary>
        /// Obtener el Punto del vertice 4 (abajo izquierda).
        /// </summary>
        public Punto Vertice4
        {
            get { return new Punto(vertice1.X, vertice3.Y); }
        }
        #endregion
        #region Constructores
        /// <summary>
        /// Construir un cuadrado a partir de los parámetros pasados.
        /// </summary>
        /// <param name="vertice1">Vertice superior izquierdo del cuadrado.</param>
        /// <param name="vertice3">Vertice inferior derecho del cuadrado.</param>
        /// <exception cref="ArgumentOutOfRangeException">Excepción que se produce al establecer el Punto del vértice 1 o 3 en una posición fuera de la Consola. Es decir, si x>(Console.WindowWidth - 1) o y > (Console.WindowHeight - 1) o si x e y son menores que 0."/></exception>
        public Cuadrado(Punto vertice1, Punto vertice3)
        {
            if (vertice3.X - vertice1.X != vertice3.Y - vertice1.Y || vertice3.X <= vertice1.X || vertice3.Y <= vertice1.Y)
            {
                throw new NoCuadradoException();
            }
            this.vertice1 = vertice1;
            this.vertice3 = vertice3;
        }
        /// <summary>
        /// Construir un cuadrado a partir del punto del vértice 1 y el lado del cuadrado.
        /// </summary>
        /// <param name="vertice1">Vertice superior izquierdo del cuadrado.e</param>
        /// <param name="lado">Lado del cuadrado</param>
        /// <exception cref="ArgumentOutOfRangeException">Excepción que se produce si al establecer el lado el Punto del vértice 3 está en una posición fuera de la Consola. Es decir, si x>(Console.WindowWidth - 1) o y > (Console.WindowHeight - 1) o si x e y son menores que 0."/></exception>
        public Cuadrado(Punto vertice1, int lado)
        {
            this.vertice1 = vertice1;
            this.vertice3 = new Punto(vertice1.X + lado, vertice1.Y + lado);
        }
        #endregion
        #region Métodos
        /// <summary>
        /// Método que pinta en consola el cuadrado creado.
        /// </summary>
        public void Pinta()
        {
            Console.SetCursorPosition(Vertice1.X, Vertice1.Y);
            Console.Write("┌");
            for (int i = 0; i < (Lado - 1) * 2; i++)
            {
                Console.Write("─");
            }
            Console.Write("┐");
            for (int i = 0; i < Lado - 1; i++)
            {
                Console.SetCursorPosition(Vertice1.X, ++Console.CursorTop);
                Console.Write("│");
                Console.CursorLeft = vertice1.X + (Lado - 1) * 2 + 1;
                Console.Write("│");
            }
            Console.SetCursorPosition(Vertice4.X, Vertice4.Y);
            Console.Write("└");
            for (int i = 0; i < (Lado - 1) * 2; i++)
            {
                Console.Write("─");
            }
            Console.Write("┘");
        }
        /// <summary>
        /// Método que devuelve una cadena de texto con toda la información del cuadrado creado.
        /// </summary>
        /// <returns>Devuelve una cadena de texto con toda la información del cuadrado creado.</returns>
        public override string ToString()
        {
            return String.Format("=================================================\n" +
                "\t\tCUADRADO\n" +
                "=================================================\n" +
                "Vertice 1: ({0},{1})       Vertice 2: ({2},{3})\n" +
                "Vertice 4: ({4},{5})      Vertice 3: ({6},{7})\n" +
                "=================================================\n" +
                "Lado: {8}\tArea: {9}\tPerímetro: {10}\n" +
                "=================================================", Vertice1.X, Vertice1.Y, Vertice2.X, Vertice2.Y, Vertice4.X, Vertice4.Y, Vertice3.X, Vertice3.Y, Lado, Area, Perimetro);
        }
        #endregion
    }
}
