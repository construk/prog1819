/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		TrianguloPascal
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Programa que te permite calcular el triángulo de pascal del nivel que indiques
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R5E10_TrianguloPascal
{
    class Program
    {
        static void Main(string[] args)
        {
            string auxiliar = "";
            int nivel;
            try
            {
                Console.WriteLine("Pinta el triángulo de pascal indicando cuantos niveles quieres hallar");
                Console.Write("nivel (mínimo 1 y máximo 34):");
                auxiliar = Console.ReadLine();
                while (!int.TryParse(auxiliar, out nivel)||nivel<1||nivel>34)
                {
                    Console.Write("Introduce un nivel válido: ");
                    auxiliar = Console.ReadLine();
                }
                PintaTriangulo(nivel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Rellena un array bidimensional con el triángulo de pascal, deja con ceros la parte que no forma parte del triángulo
        /// </summary>
        /// <param name="nivel">Indica de cuentos niveles quieres obtener el triángulo, si es menor que cero provocará FormatException</param>
        /// <returns>Devuelve int[,] de tamaño nivel*nivel relleno con el triángulo de pascal, los valores 0 hay que ignorarlos</returns>
        public static int[,] CalcularPascal(int nivel)
        {
            int[,] resultado = new int[nivel, nivel];
            if (nivel<1)
            {
                throw new FormatException();
            }
            for (int i = 0; i < nivel; i++)
                for (int j = 0; j < nivel; j++)
                {
                    if (j==0||i==j)
                    {
                        resultado[i, j] = 1;
                    }
                    else if (i>j)
                    {
                        resultado[i, j] = resultado[i - 1, j - 1] + resultado[i - 1, j];
                    }
                }
            return resultado;
        }
        /// <summary>
        /// Pinta el triángulo de pascal
        /// </summary>
        /// <param name="nivel">Niveles que quieres obtener del triángulo, mínimo 1, sino provocará FormatException</param>
        public static void PintaTriangulo(int nivel)
        {
            int[,] triangulo = CalcularPascal(nivel);
            for (int i = 0; i < triangulo.GetLength(0); i++)
            {
                for (int j = 0; j < triangulo.GetLength(1); j++)
                {
                    if (triangulo[i, j] != 0)
                    {
                        if (j==0)
                        {
                            int desplazamiento = 0;
                            desplazamiento = nivel - i;
                            Console.Write(triangulo[i, j].ToString().PadLeft(desplazamiento) + " ");
                        }else
                            Console.Write(triangulo[i, j]+" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
