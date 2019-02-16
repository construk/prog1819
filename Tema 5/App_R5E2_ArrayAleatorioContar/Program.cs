/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ArrayAleatorioContar
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Programa que genera un array relleno aleatoriamente y cuenta ceros, 
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R5E2_ArrayAleatorioContar
{
    class Program
    {
        /// <summary>
        /// Estructura Contador para contar ceros, negativos, positivos, pares e impares.
        /// </summary>
        public struct Contador
        {
            int ceros;
            int negativos;
            int positivos;
            int pares;
            int impares;

            #region Propiedades
            public void CountCero()
            {
                ceros++;
            }
            public int GetCeros()
            {
                return ceros;
            }
            public void countNegativo()
            {
                negativos++;
            }
            public int getNegativos()
            {
                return negativos;
            }
            public void countPositivo()
            {
                positivos++;
            }
            public int getPositivos()
            {
                return positivos;
            }
            public void countPar()
            {
                pares++;
            }
            public int getPares()
            {
                return pares;
            }
            public void countImpar()
            {
                impares++;
            }
            public int getImpares()
            {
                return impares;
            }
            #endregion
            
            //MÉTODO QUE PINTA LOS RESULTADOS
            public void PintaResultado(Contador contador)
            {
                Console.WriteLine("   RESULTADO");
                Console.WriteLine("==============================");
                Console.WriteLine("Ceros \t\t--> {0}\nPositivos \t--> {1}\nNegativos \t--> {2}\nPares \t\t--> {3}\nImpares \t--> {4}"
                    , GetCeros(), getPositivos(), getNegativos(), getPares(), getImpares());
            }
        }
        static void Main(string[] args)
        {
            //CREAR SEMILLA PARA ALEATORIO
            Random random = new Random();
            
            //CREAR ARRAY Y ESTRUCTURA CONTADOR
            int[] array = new int[0];
            Contador contador = new Contador();

            //EJECUTAR MÉTODO QUE RELLENA EL ARRAY CON UN TAMAÑO ESPECIFICADO Y UN RANGO DE VALORES DE LOS ALEATORIOS
            RandomArray(ref array, 100, -99, 99, random);
            
            //PINTAR ARRAY
            Console.WriteLine(arrayIntToString(array)+"\n");
            
            //CONTAR VALORES
            contador = CuentaNumerosArray(array);

            //PINTAR RESULTADO
            contador.PintaResultado(CuentaNumerosArray(array));

            Console.ReadLine();
        }
        /// <summary>
        /// Método que te devuelve una estructura Contador con la cuenta de los ceros, positivos, negativos, pares e impares.
        /// </summary>
        /// <param name="array">Array de int que recibe</param>
        /// <returns>Devuelve estructura Contador</returns>
        public static Contador CuentaNumerosArray(int[] array)
        {
            Contador contador = new Contador();
            foreach (int entero in array)
            {
                if (entero == 0)
                    contador.CountCero();
                else if (entero < 0)
                    contador.countNegativo();
                else if (entero > 0)
                    contador.countPositivo();

                if (entero%2==0)
                    contador.countPar();
                else
                    contador.countImpar();
            }
            return contador;
        }
        
        #region Método que rellena un array aleatoriamente
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
        /// Método que te rellena un array de números aleatorios, indicándole el tamaño y el rango de valores del número aleatorio.
        /// </summary>
        /// <param name="array">int[] a rellenar</param>
        /// <param name="tamano">Tamaño del array a rellenar</param>
        /// <param name="rangoInf">Rango inferior de valores del aleatorio</param>
        /// <param name="rangoSup">Rango superior de valores del aleatorio</param>
        /// <param name="random">Semilla</param>
        public static void RandomArray(int[] array, int tamano, int rangoInf, int rangoSup, Random random)  //NO SE MODIFICA REFERENCIAS
        {
            for (int i = 0; i < tamano; i++)
            {
                array[i] = random.Next(rangoInf, rangoSup + 1);
            }
        }

        /* //FALLAN LAS REFERENCIAS
        public static void RandomArray(int[] array, int tamano, int rangoInf, int rangoSup, Random random) 
        {
            array = new int[tamano];
            for (int i = 0; i < tamano; i++)
            {
                array[i] = random.Next(rangoInf, rangoSup + 1);
            }
        }
        */
        #endregion
        
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
