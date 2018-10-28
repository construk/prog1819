/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    EsPrimoONo
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación te dice si el número introducido es Primo o No  
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Threading;

namespace App_R4E3_EsPrimoONo
{
    class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            uint numeroIntroducido;
            string auxiliar;

            //INTRODUCCIÓN
            Console.WriteLine("Programa que te dice si un número es primo o no (0 para salir)");
            do
            {
                //ENTRADA DE DATOS
                Console.Write("Introduce un número: ");
                auxiliar = Console.ReadLine();
                //SI NO PUEDE TRANSFORMAR A UINT PIDE DE NUEVO EL DATO
                while (!uint.TryParse(auxiliar, out numeroIntroducido))
                {
                    Console.Write("Introduce un número válido: ");
                    auxiliar = Console.ReadLine();
                }
                
                if (numeroIntroducido!=0)           //SI EL NÚMERO INTRODUCIDO NO ES 0
                {
                    if (EsPrimo(numeroIntroducido)) //SI ES PRIMO
                        Console.WriteLine("El número {0} es primo",numeroIntroducido);
                    else                            //SI NO ES PRIMO
                        Console.WriteLine("El número {0} no es primo",numeroIntroducido);
                }
                else                                //SI EL NUMERO INTRODUCIDO ES 0
                {
                    Console.CursorVisible = false;
                    Console.Write("Saliendo");
                    Thread.Sleep(800);
                    Console.Write(".");
                    Thread.Sleep(800);
                    Console.Write(".");
                    Thread.Sleep(800);
                    Console.Write(".");
                    Thread.Sleep(800);
                }

            } while (numeroIntroducido!=0);         //PEDIR NÚMEROS MIENTRAS NO INTRODUZCAS 0
        }
        //FUNCIÓN QUE DEVUELVE TRUE SI ES PRIMO Y FALSE SI NO LO ES. SACADO DE LA RELACIÓN 3 EJERCICIO 10.
        private static bool EsPrimo(uint numero) //Función que recibe un número de tipo uint que devuelve true si es primo y false si no lo es
        {
            int divisor = 2;      //Desde donde comenzamos a comprobar divisibles
            if (numero < 2)       //Controlamos el caso del número 0 y 1, que no son primos
            {
                return false;
            }
            else if (numero < 4) //Controlamos el caso del número 2 y 3, que son primos
            {
                return true;
            }
            else                //Controlamos el resto de casos (hasta el máximo aceptado por un uint)
            {
                while (numero % divisor != 0 && divisor <= numero / 2)   //Mientras el número no sea divisible y el divisor sea menor a la mitad del número comprobado, incrementa divisor
                {                                                   //Cuando termine de comprobar las condiciones se evaluará el último valor contemplado como divisor
                    divisor++;
                }
                return numero % divisor == 0 ? false : true;        //y si el numero entre el divisor es 0 será falso y si no será verdadero
            }
        }

    }
}
