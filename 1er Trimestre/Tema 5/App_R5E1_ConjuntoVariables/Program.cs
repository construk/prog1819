/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		
 *  Autor:		
 *  Versión:		
 *  Descripción:	
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App_R5E1_ConjuntoVariables
{
    class Program
    {
        public struct Mano
        {
            public enum Dedo { Pulgar, Indice, Corazon, Anular, Menique}
            
            public static void PintaMano()
            {
                string dedoString;
                Mano.Dedo dedo = 0;
                dedoString = dedo.ToString();
                Console.Write("Enumeración Dedo de la estructura Mano con " + Enum.GetNames(typeof(Mano.Dedo)).Length + " valores: " + dedoString);
                for (int i = 1; i < Enum.GetNames(typeof(Mano.Dedo)).Length; i++)
                {
                    dedo = (Mano.Dedo)i;
                    dedoString = dedo.ToString();
                    Console.Write(", " + dedoString);
                }
                Console.WriteLine(".");
                return;
            }
        }
        static void Main(string[] args)
        {
            //CREA SEMILLA PARA ALEATORIOS
            Random rnd = new Random();

            //DÁNDOLE VALOR A LOS ARRAYS CON MÉTODOS QUE DEVUELVEN ARRAYS
            int[] arrayEnteros= nRandomInt(10,100);
            string[] arrayString = nRandomString(10, 5, rnd);     
       
            //ESTRUCTURA MANO Y ENUMERACIÓN DEDO
            Console.WriteLine("Estructura Mano es de tipo --> " +typeof(Mano));
            Console.WriteLine("Enumeración Dedo dentro de Mano es de tipo --> "+typeof(Mano.Dedo)+"\n");
            Mano.Dedo anular = Mano.Dedo.Anular;
            Console.WriteLine("Escribo un dedo de la enumeración --> " + anular);
            Mano.PintaMano();

            //ARRAY INT
            Console.WriteLine("\nTipo del array de int --> "+typeof(int[]));
            Console.WriteLine("Array relleno aleatoriamente de Int:\n"+arrayIntToString(arrayEnteros));

            //ARRAY STRING
            Console.WriteLine("\nTipo del array de string --> " + typeof(string[]));
            Console.WriteLine("Array relleno aleatoriamente de Strings rellenos por carácteres aleatorios: \n" + arrayStringToString(arrayString));

            //TIPOS BÁSICOS: TYPEOF, SIZEOF Y VALORES MÁXIMOS Y MÍNIMOS
            Console.WriteLine("\nBoleano "+typeof(bool)+" (bool) tamaño: "+sizeof (bool)+ " byte. Valores: "+true+" o "+false);
            Console.WriteLine("\nCaracter " + typeof(char) + " (char) tamaño: " + sizeof(char) + " bytes. Valores entre: " + char.MinValue + " y " + char.MaxValue);
            Console.WriteLine("\nEntero " + typeof(long) + " (long) tamaño: " + sizeof(long) + " bytes. Valores entre: " + long.MinValue + " y " + long.MaxValue);
            Console.WriteLine("\nEntero " + typeof(int) + " (int) tamaño: " + sizeof(int) + " bytes. Valores entre: " + int.MinValue + " y " + int.MaxValue);
            Console.WriteLine("\nEntero " + typeof(uint) + " (uint) tamaño: " + sizeof(uint) + " bytes. Valores entre: " + uint.MinValue + " y " + uint.MaxValue);
            Console.WriteLine("\nEntero " + typeof(short) + " (short) tamaño: " + sizeof(short) + " bytes. Valores entre: " + short.MinValue + " y " + short.MaxValue);
            Console.WriteLine("\nEntero " + typeof(ushort) + " (ushort) tamaño: " + sizeof(ushort) + " bytes. Valores entre: " + ushort.MinValue + " y " + ushort.MaxValue);
            Console.WriteLine("\nEntero " + typeof(byte) + " (byte) tamaño: " + sizeof(byte) + " bytes. Valores entre: " + byte.MinValue + " y " + byte.MaxValue);
            Console.WriteLine("\nEntero " + typeof(sbyte) + " (sbyte) tamaño: " + sizeof(sbyte) + " bytes. Valores entre: " + sbyte.MinValue + " y " + sbyte.MaxValue);
            Console.WriteLine("\nReal " + typeof(float) + " (float) tamaño: " + sizeof(float) + " bytes. Valores entre: " + float.MinValue + " y " + float.MaxValue);
            Console.WriteLine("\nReal " + typeof(double) + " (double) tamaño: " + sizeof(double) + " bytes. Valores entre: " + double.MinValue + " y " + double.MaxValue);
            Console.WriteLine("\nReal " + typeof(decimal) + " (decimal) tamaño: " + sizeof(decimal) + " bytes. Valores entre: " + decimal.MinValue + " y " + decimal.MaxValue);

            Console.ReadLine();
        }

        /// <summary>
        /// Método que convierte un array de int en string
        /// </summary>
        /// <param name="arrayInt">array de int a transformar a string</param>
        /// <returns>string con formato [ valor1, valor2, ... ]</returns>
        public static string arrayIntToString(int[] arrayInt)
        {
            string resultado = "[ "+arrayInt[0].ToString();
            for (int i = 1; i < arrayInt.Length; i++)
            {
                resultado += ", "+arrayInt[i].ToString();
            }
            resultado += " ]";
            return resultado;
        }
        /// <summary>
        /// Método que convierte un array de string en string
        /// </summary>
        /// <param name="arrayString">array de string a transformar a string</param>
        /// <returns>string con formato [ valor1, valor2, ... ]</returns>
        public static string arrayStringToString(string[] arrayString)
        {
            string resultado = "[ " + arrayString[0].ToString();
            for (int i = 1; i < arrayString.Length; i++)
            {
                resultado += ", " + arrayString[i];
            }
            resultado += " ]";
            return resultado;
        }
        /// <summary>
        /// Método que convierte un array de char en string
        /// </summary>
        /// <param name="arrayChar">array de char a transformar a string</param>
        /// <returns>string con formato [ valor1, valor2, ... ]</returns>
        public static string arrayCharToString(char[] arrayChar)
        {
            string resultado = "[ " + arrayChar[0].ToString();
            for (int i = 1; i < arrayChar.Length; i++)
            {
                resultado += ", " + arrayChar[i];
            }
            resultado += " ]";
            return resultado;
        }
        /// <summary>
        /// Método que convierte un array de char en string sin formato
        /// </summary>
        /// <param name="arrayChar">array de char a transformar a string sin formato</param>
        /// <returns>string sin formato valor1valor2Valor3...</returns>
        public static string arrayCharToStringClean(char[] arrayChar)
        {
            string resultado="";
            for (int i = 0; i < arrayChar.Length; i++)
            {
                resultado += arrayChar[i].ToString();
            }
            return resultado;
        }
        /// <summary>
        /// Método que obtiene un número aleatorio de bool
        /// </summary>
        /// <param name="numberOfRandoms">Número de aleatorios a obtener</param>
        /// <returns>array de bool aleatorio</returns>
        public static bool[] nRandomBool(int numberOfRandoms)
        {
            Random rnd = new Random();
            bool[] resultado = new bool[numberOfRandoms];
            for (int i = 0; i < numberOfRandoms; i++)
            {
                int contador = 0;
                int numero = rnd.Next(2);
                if (numero == 0)
                    resultado[contador] = false;
                else
                    resultado[contador] = true;

                contador++;
            }
            return resultado;
        }
        /// <summary>
        /// Método para obtener un número aleatorio de carácteres imprimibles [A-Z]
        /// </summary>
        /// <param name="numberOfRandoms">Número de aleatorios a obtener</param>
        /// <param name="random">semilla</param>
        /// <returns>array de char aleatorios</returns>
        public static char[] nRandomChar(int numberOfRandoms, Random random)
        {
            Random rnd = random;
            char[] resultado = new char[numberOfRandoms];
            for (int i = 0; i < numberOfRandoms; i++)
            {
                int numero = rnd.Next(65, 91);
                char caracter = (char)numero;
                resultado[i] = caracter;
            }
            return resultado;
        }
        /// <summary>
        /// Método para obtener un número aleatorio de strings generados aleatoriamente
        /// </summary>
        /// <param name="numberOfRandoms">números de string a generar aleatoriamente</param>
        /// <param name="lengthString">Longitud de los string a obtener</param>
        /// <param name="random">semilla</param>
        /// <returns>array con los strings aleatorios de tamaño determinado</returns>
        public static string[] nRandomString(int numberOfRandoms, int lengthString, Random random)
        {
            Random rnd = random;
            string[] resultado = new string[numberOfRandoms];
            for (int i = 0; i < numberOfRandoms; i++)
            {
                string texto;
                texto = arrayCharToStringClean(nRandomChar(lengthString,rnd));
                resultado[i] = texto;
            }
            return resultado;
        }
        /// <summary>
        /// Método para obtener un número aleatorio de int generados aleatoriamente
        /// </summary>
        /// <param name="numberOfRandoms">número de int a obtener</param>
        /// <param name="maxInt">valor máximo del entero a obtener</param>
        /// <returns>array relleno de int aleatorios</returns>
        public static int[] nRandomInt(int numberOfRandoms, int maxInt)
        {
            Random rnd = new Random();
            int[] resultado = new int[numberOfRandoms];
            for (int i = 0; i < numberOfRandoms; i++)
            {
                int number;
                number = rnd.Next(maxInt+1);
                resultado[i] = number;
            }
            return resultado;
        }


    }
}
