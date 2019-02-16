/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ArrayAleatorioMediaMayorMenor
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Programa que genera un array relleno aleatoriamente y cuenta ceros, 
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R5E3_ArrayAleatorioMediaMayorMenor
{
    class Program
    {
        static void Main(string[] args)
        {
            //CONSTANTES
            const int VALOR_MAX_ALEA = 10000;       //VALOR MÁXIMO POSIBLE DEL ALEATORIO
            const int NUM_ALEATORIOS = 100;         //NÚMERO DE ALEATORIOS A OBTENER

            //CREAR SEMILLA RANDOM
            Random rnd = new Random();

            //RELLENAR ARRAY CON NÚMEROS ALEATORIOS POSITIVOS
            int[] array = new int[10];
            RandomArrayPositivo(ref array, NUM_ALEATORIOS, VALOR_MAX_ALEA, rnd);

            //PINTAR EL ARRAY
            Console.WriteLine(arrayIntToString(array));

            //PINTAR LOS RESULTADOS
            Console.WriteLine("\nLa media es\t --> {0}\nEl mayor es\t --> {1}\nEl menor es\t --> {2}"
                , MediaArrayInt(array), MayorArrayInt(array), MenorArrayInt(array));
            
            Console.ReadLine();
        }
        /// <summary>
        /// Método que te rellena un array de números aleatorios positivos, indicándole el tamaño y el valor máximo del número aleatorio.
        /// </summary>
        /// <param name="array">int[] a rellenar</param>
        /// <param name="tamano">Tamaño del array a rellenar</param>
        /// <param name="aleaMax">Valor máximo del número generado aleatoriamente inclusivo</param>
        /// <param name="random">Semilla</param>
        public static void RandomArrayPositivo(ref int[] array, int tamano, int aleaMax, Random random) //SE REFERENCIA
        {
            array = new int[tamano];
            for (int i = 0; i < tamano; i++)
                array[i] = random.Next(aleaMax+ 1);
        }
        /// <summary>
        /// Obtiene el valor más grande de un array
        /// </summary>
        /// <param name="array">array a recorrer</param>
        /// <returns></returns>
        public static int MayorArrayInt(int[]array)
        {
            int resultado = array[0];
            foreach (int numero in array)
                if (numero>resultado)
                    resultado = numero;
            return resultado;
        }
        /// <summary>
        /// Obtiene el valor más pequeño de un array
        /// </summary>
        /// <param name="array">array a recorrer</param>
        /// <returns></returns>
        public static int MenorArrayInt(int[] array)
        {
            int resultado = array[0];
            foreach (int numero in array)
                if (numero < resultado)
                    resultado = numero;
            return resultado;
        }
        /// <summary>
        /// Obtiene la media de un array
        /// </summary>
        /// <param name="array">array a recorrer</param>
        /// <returns></returns>
        public static int MediaArrayInt(int[] array)
        {
            int suma = 0;
            foreach (int numero in array)
                suma += numero;
            return suma/array.Length;
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
    }
}
