/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		MatrizMultidimensional
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Programa que muestra matrices: Una inicializada con ceros, otra aleatoriamente y una copia.
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R5E6_MatrizMultidimensional
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[,] matrizBidimensional = new int[20, 20];
            int[,] matrizCopia = new int[20, 20];

            Console.WriteLine("INICIALIZA MATRÍZ CON CEROS");
            InicializaCeroMatrizBidimensional(matrizBidimensional);
            MuestraMatrizBidimensional(matrizBidimensional);

            Console.WriteLine("\nINICIALIZA MATRÍZ ALEATORIAMENTE");
            InicializaAleaMatrizBidimensional(matrizBidimensional,rnd,1000);
            MuestraMatrizBidimensional(matrizBidimensional);

            Console.WriteLine("\nCOPIA MATRÍZ EN OTRA Y MODIFICA MATRIZ CON OTROS NÚMEROS ALEATORIOS");
            CopiaMatrizBidimensional(matrizBidimensional, matrizCopia);
            InicializaAleaMatrizBidimensional(matrizBidimensional, rnd, 1000);
            MuestraMatrizBidimensional(matrizBidimensional);

            Console.WriteLine("\nMUESTRA LA MATRÍZ COPIADA ANTES DE SER EDITADA");
            MuestraMatrizBidimensional(matrizCopia);
            Console.ReadLine();
        }
        public static void InicializaCeroMatrizBidimensional(int[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1); j++)
                    matriz[i, j] = 0;
        }
        public static void InicializaAleaMatrizBidimensional(int[,] matriz, Random random, int aleaMax)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1); j++)
                    matriz[i, j] = random.Next(aleaMax);
        }
        public static void InicializaAleaMatrizBidimensional(int[,] matriz, Random random, int aleaMin, int aleaMax)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1); j++)
                    matriz[i, j] = random.Next(aleaMin, aleaMax);
        }
        public static void MuestraMatrizBidimensional(int[,] matriz)
        {
            //MARCO PARA MOSTRAR LA MATRIZ
            string[] marco = new string[] { "│", "┌", "└", "┐", "┘" };

            //RECORRER CADA FILA DE LA MATRIZ
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                //PINTA EL MARCO IZQUIERDO DE LA MATRIZ
                if (i == 0)
                    Console.Write(marco[1]+" ");
                else if (i != matriz.GetLength(0) - 1)
                    Console.Write(marco[0] + " ");
                else
                    Console.Write(marco[2] + " ");

                //PINTA LOS VALORES DE LA MATRÍZ SEPARADOS POR COMAS MENOS EL ÚLTIMO DE CADA FILA
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j].ToString().PadLeft(3).PadRight(3));
                    if (j!=matriz.GetLength(1)-1)
                        Console.Write(", ");
                    else
                        Console.Write("  ");
                }
                //PINTA EL MARCO DERECHO DE LA MATRIZ
                if (i==0)
                    Console.WriteLine(marco[3]);
                else if (i!=matriz.GetLength(0)-1)
                    Console.WriteLine(marco[0]);
                else
                    Console.WriteLine(marco[4]);
            }
        }
        public static void CopiaMatrizBidimensional(int[,] matrizACopiar, int[,] matrizCopia)
        {
            for (int i = 0; i < matrizACopiar.GetLength(0); i++)
                for (int j = 0; j < matrizACopiar.GetLength(1); j++)
                    matrizCopia[i, j] = matrizACopiar[i, j];
        }
    }
}
