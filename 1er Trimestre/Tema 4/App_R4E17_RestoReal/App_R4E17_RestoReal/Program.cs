/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    RestoReal
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Programa que recibe el dividendo y el divisor y muestra el resto como número real
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E17_RestoReal
{
    class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            double dividendo;
            double divisor;
            double resto;
            string aux;

            //INTRODUCCIÓN
            Console.WriteLine("Programa que recibe el dividendo y el divisor y muestra el resto como número real");
            
            //ENTRADA DE DATOS
            Console.Write("Introduce dividendo: ");             //DIVIDENDO
            aux = Console.ReadLine();
            while (!double.TryParse(aux, out dividendo))
            {
                Console.Write("Introduce un dato válido: ");
                aux = Console.ReadLine();
            }
            aux = null;

            Console.Write("Introduce divisor: ");               //DIVISOR
            aux = Console.ReadLine();
            while (!double.TryParse(aux, out divisor))
            {
                Console.Write("Introduce un dato válido: ");
                aux = Console.ReadLine();
            }

            //SI EL RESULTADO DE LA DIVISIÓN DA DECIMALES (UN NÚMERO REAL) GUARDA EL DATO EN LA VARIABLE RESTO, SINO DEVUELVE 0 (Y EJECUTA ELSE)
            if (ParteDecimal(dividendo / divisor, out resto))
            {
                Console.WriteLine("El dividendo {0} dividido entre el divisor {1} es igual a: {2}" +
                "\nParte entera: {3}\tParte decimal: {4}",dividendo,divisor,dividendo/divisor,(int)(dividendo / divisor),resto);
            }else
                Console.WriteLine("El dividendo {0} dividido entre el divisor {1} es igual a: {2}" +
                "\nParte entera: {3}\tParte decimal: {4}",dividendo,divisor,dividendo/divisor,(int)(dividendo / divisor),resto);

            Console.ReadLine();
        }


        //Función que intenta obtener la parte decimal de un número, si lo consigue devuelve el true y asigna el valor, sino devuelve false y asigna 0.
        public static bool ParteDecimal(double numero,out double resultado)
        {
            string numeroString = numero.ToString();
            if (numeroString.IndexOf(',')!=-1)
            {
                string parteDecimal = "0" + numeroString.Substring(numeroString.IndexOf(','));

                if (double.TryParse(parteDecimal, out resultado))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            resultado = 0;
            return false;
        }
    }
}
