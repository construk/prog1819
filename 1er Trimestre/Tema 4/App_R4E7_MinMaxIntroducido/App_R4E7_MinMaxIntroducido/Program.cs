/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    MinMaxIntroducido
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Aplicación que te dice el número más grande introducido y el más pequeño
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E7_MinMaxIntroducido
{
    class Program
    {
        static void Main(string[] args)
        {
            //CAMPOS
            double max=0;
            double min=0;
            string auxiliar;
            double numero;
            
            //INTRODUCCIÓN
            Console.WriteLine("Introduce números y te mostraré el número más grande y más pequeño introducido");
            do  //HACER MIENTRAS NÚMERO SEA DISTINTO DE 0
            {
                //INTRODUCIR DATOS
                Console.Write("Introduce un número (0 para salir): ");
                auxiliar = Console.ReadLine();
                while (!double.TryParse(auxiliar, out numero))
                {
                    Console.Write("Introduce un número válido: ");
                    auxiliar = Console.ReadLine();
                }

                if (numero!=0) //SI NÚMERO ES DISTINTO DE CERO, COMPARAR PARA ASIGNAR A MAX O MIN
                {
                    if (numero<min)
                        min = numero;
                    if (numero>max)
                        max = numero;
                }
            } while (numero!=0);
            
            //RESULTADOS
            if (min==0&&max==0)
                Console.WriteLine("No has introducido ningún número");
            else if (min==0)
                Console.WriteLine("El valor máximo es {0}",max);
            else if (max==0)
                Console.WriteLine("El valor mínimo es {0}",min);
            else
                Console.WriteLine("El valor máximo es {0}\nEl valor mínimo es {1}",max,min);
            Console.ReadLine();
        }
    }
}
