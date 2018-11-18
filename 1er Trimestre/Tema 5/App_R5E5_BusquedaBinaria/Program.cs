/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		BusquedaBinaria
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Programa que muestra array y puedes buscar en que posición se encuentra un dato
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R5E5_BusquedaBinaria
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

            //ORDENAR Y MOSTRAR ARRAY
            OrdenarBurbuja(array);
            Console.WriteLine("\nORDENADO\n" + arrayIntToString(array));

            //PREGUNTAR POR NÚMERO A BUSCAR
            string auxiliar;
            int numero;
            Console.Write("Introduce número a buscar: ");
            auxiliar = Console.ReadLine();
            while(!int.TryParse(auxiliar,out numero))
            {
                Console.Write("Introduce un número válido: ");
                auxiliar = Console.ReadLine();
            }
            //BUSCAR NÚMERO, SI ENCUENTRA ESCRIBE POSICIÓN, SINO AVISA DE NO ENCONTRADO
            string linea = BusquedaBinaria(array, numero) == -1 ? "NÚMERO NO ENCONTRADO" : "El número "+numero+" ha sido encontrado en la posición " + BusquedaBinaria(array, numero);
            Console.WriteLine(linea);

            Console.ReadLine();
        }
        #region MÉTODOS
        /// <summary>
        /// Método de búsqueda binaria, devuelve la posición del elemento buscado, si no lo encuentra devuelve -1.
        /// </summary>
        /// <param name="array">array donde se encuentran los números</param>
        /// <param name="valorBuscado">valor a buscar</param>
        /// <returns>Devuelve la posición del número a buscar, si no lo encuentra devuelve -1.</returns>
        public static int BusquedaBinaria(int[] array, int valorBuscado)
        {
            //FIJAR RANGOS DE DATOS DE LA MATRIZ
            int rangoSuperior = array.Length-1;
            int mitad = rangoSuperior / 2;
            int rangoInferior = 0;

            //SIEMPRE SE REPITE BUCLE HASTA QUE ENCUENTRE UN RETURN
            while (true)
            {
                if (rangoSuperior - rangoInferior == 1)         //SI LA DIFERENCIA ENTRE RANGO SUPERIOR E INFERIOR ES 1
                {
                    if (array[mitad] == valorBuscado)           //SI EL PRIMER DATO ES EL BUSCADO DEVUELVE SU POSICIÓN
                    {
                        return mitad;
                    }
                    else if (array[mitad+1] == valorBuscado)    //SI EL SEGUNDO DATO ES EL BUSCADO DEVUELVE SU POSICIÓN
                    {
                        return mitad+1;
                    }
                    else                                        //SI NO SE ENCUENTRA EL DATO DEVUELVE -1
                        return -1;
                }
                else if (array[mitad] == valorBuscado)               //SI SE ENCUENTRA DEVOLVERLO
                {
                    return mitad;
                }
                else if (valorBuscado < array[mitad])           //SINO Y ES MENOR QUE EL VALOR SITUADO EN LA MITAD DISMINUYE RANGO SUPERIOR Y MITAD
                {
                    rangoSuperior = mitad;
                    mitad = rangoSuperior / 2;
                }
                else                                            //SINO Y ES MAYOR QUE EL VALOR SITUADO EN LA MITAD AUMENTA RANGO SUPERIOR Y MITAD
                {
                    rangoInferior = mitad;
                    int anadido = rangoSuperior - rangoInferior;
                    mitad = rangoInferior+(anadido/2);
                }
            }
        }
        
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
