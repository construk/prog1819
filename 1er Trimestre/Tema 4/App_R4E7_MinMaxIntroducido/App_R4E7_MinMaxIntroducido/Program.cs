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
            double primerMaxMin=0;
            int contador = 0;
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

                if (numero != 0) //SI NÚMERO ES DISTINTO DE CERO, COMPARAR PARA ASIGNAR A MAX O MIN
                {
                    if (contador == 0)                              //AL INTRODUCIR EL PRIMER NÚMERO
                        primerMaxMin = numero;

                    if ((min == 0 || max == 0) && contador != 0)    //SI NO ES EL PRIMER NÚMERO Y SI EL MAX Y MIN SIGUEN SIENDO 0
                    {
                        if (numero < primerMaxMin)                  //SI NUMERO MENOR QUE EL PRIMER NÚMERO GUARDAR EN MÍNIMO
                            min = numero;
                        if (numero > primerMaxMin)                  //SI NUMERO MAYOR QUE EL PRIMER NÚMERO GUARDAR EN MÁXIMO
                            max = numero;
                    }
                    else                                            //SI NÚMERO MIN Y MAX HA CAMBIADO Y NO ES EL PRIMER NÚMERO INTRODUCIDO
                    {
                        if (numero < min)                           //SI NUMERO MENOR QUE EL MIN GUARDAR EN MÍNIMO
                            min = numero;
                        else if (numero > max)                      //SI NUMERO MAYOR QUE EL MAX GUARDAR EN MÁXIMO
                            max = numero;
                    }
                    contador++;                                     //AUMENTAR EL CONTADOR DE NÚMEROS INTRODUCIDOS
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
