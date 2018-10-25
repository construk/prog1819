/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    AreaVolumenCilindro
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación sirve para calcular el area lateral y el volumen de un cilindro
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R3E18_AreaVolumenCilindro
{
    class Program
    {
        static void Main(string[] args)
        {
            //CAMPOS
            double altura;      
            double radio;       

            //INTRODUCCIÓN Y LECTURA DE DATOS
            Console.WriteLine("Algoritmo que calcula el área lateral y el volumen de un cilindro");
            Console.Write("Introduce altura: ");
            altura = double.Parse(Console.ReadLine());
            Console.Write("Introduce radio: ");
            radio = double.Parse(Console.ReadLine());
            
            //RESULTADO 
            Console.WriteLine("El area lateral del cilindro es {0}", Math.PI*2*radio*altura);
            Console.WriteLine("El volumen del cilindro es {0}", Math.PI * radio * radio * altura);
            Console.ReadLine();
        }
    }
}
