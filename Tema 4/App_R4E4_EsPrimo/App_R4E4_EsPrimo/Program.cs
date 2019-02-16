/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    EsPrimoONo
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.1 oct de 2018
 *  Descripción:		Esta aplicación incluye una sobrecargar para EsPrimo donde recibe un dato tipo int y controla los número negativos  
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace Cons
{
    class Math
    {
        static void Main(string[] args)
        {
            Console.WriteLine(EsPrimo(-7));
            Console.WriteLine(EsPrimo(-8));
            Console.WriteLine(EsPrimo(-11));
            Console.WriteLine(EsPrimo(-12));
            Console.WriteLine(EsPrimo(-13));
            Console.WriteLine(EsPrimo(-773));
            Console.WriteLine(EsPrimo(-733));
            Console.ReadLine();
        }
        //FUNCIÓN QUE DEVUELVE TRUE SI ES PRIMO Y FALSE SI NO LO ES.
        public static bool EsPrimo(uint numero) //Función que recibe un número de tipo uint que devuelve true si es primo y false si no lo es
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
        public static bool EsPrimo(int numero) //Función que recibe un número de tipo int que devuelve true si es primo y false si no lo es
        {
            int divisor = 2;      //Desde donde comenzamos a comprobar divisibles
            if (numero >= 0)
            {
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
            else {
                if (numero > -2)       //Controlamos el caso del número -1, que no es primo
                {
                    return false;
                }
                else if (numero > -4) //Controlamos el caso del número -2 y -3, que son primos
                {
                    return true;
                }
                else                //Controlamos el resto de casos (hasta el máximo aceptado por un int)
                {
                    while (numero % divisor != 0 && divisor <= -numero / 2)   //Mientras el número no sea divisible y el divisor sea menor a la mitad del número comprobado, incrementa divisor
                    {                                                   //Cuando termine de comprobar las condiciones se evaluará el último valor contemplado como divisor
                        divisor++;
                    }
                    return numero % divisor == 0 ? false : true;        //y si el numero entre el divisor es 0 será falso y si no será verdadero
                }
            }
        }
    }
}
