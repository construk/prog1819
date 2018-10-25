/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    FormatoNumeros
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación escribe números en distintos formatos numéricos
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R3E14_FormatoNumeros
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1, num2, num3, num4, num5, num6;
            int num7;
            Console.WriteLine("Escribir cantidades a formatear (5 números):");
            Console.Write("1º: ");
            num1 = double.Parse(Console.ReadLine());
            Console.Write("2º: ");
            num2 = double.Parse(Console.ReadLine());
            Console.Write("3º: ");
            num3 = double.Parse(Console.ReadLine());
            Console.Write("4º: ");
            num4 = double.Parse(Console.ReadLine());
            Console.Write("5º: ");
            num5 = double.Parse(Console.ReadLine());
            Console.Write("6º: ");
            num6 = double.Parse(Console.ReadLine());
            Console.Write("7º: ");
            num7 = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Formateo de Salida");
            Console.WriteLine("---------------------");
            Console.WriteLine("El número {0} es {0:00000}",num1);
            Console.WriteLine("El número {0} es {0:E6}", num2);
            Console.WriteLine("El número {0} es {0:00.00}", num3);
            Console.WriteLine("El número {0} es {0:F0}", num4);
            Console.WriteLine("El número {0} es {0:#.0}", num5);
            Console.WriteLine("El número {0} es {0:0,000,000.00}", num6);
            Console.WriteLine("El número {0} es {0:X}", num7);
            Console.ReadLine();
        }
    }
}
