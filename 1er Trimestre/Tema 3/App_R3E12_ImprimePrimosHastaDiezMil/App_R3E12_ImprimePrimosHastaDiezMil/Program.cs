/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    ImprimePrimosHastaDiezMil
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación te muestra todos los números que son primos hasta diez mil
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R3E12_ImprimePrimosHastaDiezMil
{
    class Program
    {
        static void Main(string[] args)
        {
            int limite = 10000;                 //LIMITE DEL ENUNCIADO
            Console.Write("2");                 //ESCRIBIMOS PRIMER RESULTADO PARA MEJORAR FORMATO
            for (uint i = 3; i <= limite; i++)  //DESDE EL NÚMERO 3 HASTA EL LIMITE PROBARÁ SI SON PRIMOS
            {
                if (EsPrimo(i))                 //SI ES PRIMO
                {
                    Console.Write(", "+i);      //ESCRIBE EL NÚMERO
                }
            }
            Console.WriteLine();
            Console.WriteLine("Pulsar ENTER para salir");
            Console.ReadLine();                 //ESPERA QUE PULSE ENTER EL USUARIO
        }

        //FUNCION REUTILIZADA DEL EJERCICIO 10 DE LA RELACIÓN 3
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
