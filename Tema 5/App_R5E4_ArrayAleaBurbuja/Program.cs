/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ArrayAleBurbuja
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Programa que genera un array relleno aleatoriamente y lo ordena con el método de la burbuja. 
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R5E4_ArrayAleaBurbuja
{
    class Program
    {
        static void Main(string[] args)
        {
            //CREAR SEMILLA DEL ALEATORIO
            Random rnd = new Random();

            //CREAR ARRAY Y RELLENAR ALEATORIAMENTE
            int[] array = new int[20];
            RandomArray(ref array, array.Length, -99, 99, rnd);

            //MOSTRAR ARRAY
            Console.WriteLine("DESORDENADO\n"+arrayIntToString(array));

            //COPIAR ARRAY ANTES DE ORDENAR
            int[] array2 = new int[array.Length];
            Array.Copy(array, array2, array.Length);

            //ORDENAR Y MOSTRAR ARRAY
            OrdenarBurbuja(array);
            Console.WriteLine("\nORDENADO\n"+arrayIntToString(array));

            //MOSTRAR ARRAY COPIADO Y COMPROBAR QUE NO HA SIDO MODIFICADO
            Console.WriteLine("\nARRAY COPIADO ANTES DE ORDENARLO\n"+arrayIntToString(array2));
            Console.ReadLine();
        }
        #region MÉTODOS
        /// <summary>
        /// Método de la burbuja para ordenar int[]
        /// </summary>
        /// <param name="array">array a ordenar</param>
        public static void OrdenarBurbuja(int[] array)
        {
            bool noSalir;
            do
            {
                noSalir = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    int auxiliar = 0;
                    if (array[i] > array[i + 1])
                    {
                        auxiliar = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = auxiliar;
                        noSalir = true;
                    }
                }
            } while (noSalir);
        }

        /// <summary>
        /// Método que te rellena un array de números aleatorios, indicándole el tamaño y el rango de valores del número aleatorio.
        /// </summary>
        /// <param name="array">int[] a rellenar</param>
        /// <param name="tamano">Tamaño del array a rellenar</param>
        /// <param name="rangoInf">Rango inferior de valores del aleatorio</param>
        /// <param name="rangoSup">Rango superior de valores del aleatorio</param>
        /// <param name="random">Semilla</param>
        public static void RandomArray(ref int[] array, int tamano, int rangoInf, int rangoSup, Random random) //SE REFERENCIA
        {
            array = new int[tamano];
            for (int i = 0; i < tamano; i++)
            {
                array[i] = random.Next(rangoInf, rangoSup + 1);
            }
        }

        /// <summary>
        /// Método que convierte un array de int en string
        /// </summary>
        /// <param name="arrayInt">array de int a transformar a string</param>
        /// <returns>string con formato [ valor1, valor2, ... ]</returns>
        public static string arrayIntToString(int[] arrayInt)
        {
            string resultado = "[ " + arrayInt[0].ToString();
            for (int i = 1; i < arrayInt.Length; i++)
            {
                resultado += ", " + arrayInt[i].ToString();
            }
            resultado += " ]";
            return resultado;
        }
        #endregion
    }
}
