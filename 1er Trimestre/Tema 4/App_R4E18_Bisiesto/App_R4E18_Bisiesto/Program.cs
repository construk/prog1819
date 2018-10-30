/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Bisiesto
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación te dice si un año es bisiesto o no
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E18_Bisiesto
{
    class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            string aux;
            int anio;

            //INTRODUCCIÓN
            Console.WriteLine("Este programa te indica si un año es bisiesto o no (introduce 0 para salir)");
            do
            {   //ENTRADA DE DATOS
                Console.Write("Introduce año: ");
                aux = Console.ReadLine();
                while (!int.TryParse(aux,out anio))
                {
                    Console.Write("Introduce un año válido: ");
                    aux = Console.ReadLine();
                }

                string esOFue = anio >= DateTime.Now.Year ? "es" : "fue";   //FORMATO PARA STRING

                if (EsBisiesto(anio))   //SI ES BISIESTO
                {
                    Console.WriteLine("El año {0} " + esOFue + " bisiesto", anio);
                }
                else //SI NO ES BISIESTO
                {
                    Console.WriteLine("El año {0} no "+esOFue+" bisiesto",anio);
                }
            } while (anio!=0);

        }
        public static bool EsBisiesto(int anio) //Un año es bisiesto si es divisible entre 4, pero que no sea divisible entre 100, pero si entre 400.
        {
            if (anio % 4 == 0 && anio % 400 == 0)
                return true;
            else if (anio % 4 == 0 && anio % 100 == 0)
                return false;
            else if (anio%4==0)
                return true;
            else
                return false;
        }
    }
}
