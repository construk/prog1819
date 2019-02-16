/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    EcuacionSegundoGrado
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Aplicación capaz de resolver una ecuación de segundo grado
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_R4E6_EcuacionSegundoGrado
{
    class Program
    {
        static void Main(string[] args)
        {
            //X = (-b +-Math.sqrt(b*b -4*a*c))/2a
            //Si a = 0          --> No es una ecuación de segundo grado
            //Si b*b < -4*a*c   --> No existen soluciones reales
            //Si b*b == -4*a*c  --> Existe una solución
            //Si b*b > -4*a*c   --> Existen dos soluciones

            //CAMPOS
            double a,b,c;
            string auxiliar;

            //INTRODUCCIÓN
            Console.WriteLine("Aplicación que calcula ecuación de segundo grado");
            Console.WriteLine("ax²+bx+c\n");

            //ENTRADA DE DATOS
            Console.Write("Introduce primer elemento (ax²): ");
            auxiliar = Console.ReadLine();
            while (!double.TryParse(auxiliar, out a)||auxiliar=="0")
            {
                Console.Write("Introduce un número válido: ");
                auxiliar = Console.ReadLine();
            }
            Console.Write("Introduce segundo elemento (bx): ");
            auxiliar = Console.ReadLine();
            while (!double.TryParse(auxiliar, out b))
            {
                Console.Write("Introduce un número válido: ");
                auxiliar = Console.ReadLine();
            }
            Console.Write("Introduce tercer elemento (c): ");
            auxiliar = Console.ReadLine();
            while (!double.TryParse(auxiliar, out c))
            {
                Console.Write("Introduce un número válido: ");
                auxiliar = Console.ReadLine();
            }

            //RESULTADOS
            if (b * b < 4 * a * c)         //SI NO EXISTE SOLUCIÓN REAL
            {
                Console.WriteLine("No existen soluciones reales");
            }
            else if (b * b == 4 * a * c)   //SI SOLO TIENE UNA SOLUCIÓN
            {
                double resultado = -b / (2 * a);
                Console.WriteLine("Solo existe una solución");
                Console.WriteLine("x = {0}", resultado);
            }
            else                            //SI TIENE MÁS DE UNA SOLUCIÓN
            {
                Console.WriteLine("Existen dos soluciones");
                double resultado1 = (-b + Math.Sqrt(b * b - (4 * a * c))) / (2 * a);
                double resultado2 = (-b - Math.Sqrt(b * b - (4 * a * c))) / (2 * a);

                Console.WriteLine("x₁: {0}", resultado1);
                Console.WriteLine("x₂: {0}", resultado2);
            }

            Console.ReadLine();
        }
    }
}
