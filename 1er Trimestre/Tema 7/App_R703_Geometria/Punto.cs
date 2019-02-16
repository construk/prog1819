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
}
