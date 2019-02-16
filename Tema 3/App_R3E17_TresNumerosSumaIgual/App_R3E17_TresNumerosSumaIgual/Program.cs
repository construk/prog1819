/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    TresNumerosSumaIgual
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		En esta aplicación se introducen tres números y si la suma de dos de ellos es igual al restante 
                        escribe "iguales",   y sino escribe distintos
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R3E17_TresNumerosSumaIgual
{
    class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            int numero1;
            int numero2;
            int numero3;
            //INTRODUCCIÓN DE DATOS
            Console.WriteLine("Introducir 3 números y determinará si la suma de alguno de ellos es igual al otro número restante");
            Console.Write("Introduce el primer número: " );
            numero1 = int.Parse(Console.ReadLine());
            Console.Write("Introduce el segundo número: ");
            numero2 = int.Parse(Console.ReadLine());
            Console.Write("Introduce tercer número: ");
            numero3 = int.Parse(Console.ReadLine());
            
            //SI LA SUMA DE DOS NÚMEROS ES IGUAL AL RESTANTE DE LOS TRES ESCRIBE "IGUALES", SINO "DISTINTOS"
            if (numero1+numero2==numero3|| numero1 + numero3 == numero2 || numero3 + numero2 == numero1)
                Console.WriteLine("Iguales");
            else
                Console.WriteLine("Distintos");

            Console.ReadLine();
        }
    }
}
