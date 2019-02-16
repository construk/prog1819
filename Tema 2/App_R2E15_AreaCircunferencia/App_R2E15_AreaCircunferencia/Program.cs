/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    AreaCircunferencia
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Calcular el area de una circunferencia (introduciendo el número con separador decimal '.' y se muestran dos decimales de precisión).
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Globalization;

namespace App_R2E15_AreaCircunferencia
{
    class Program
    {
        static void Main(string[] args)
        {
            double radio=0.0;
            NumberFormatInfo formatoNumeroPunto = new CultureInfo("en-US", false).NumberFormat; //Para cambiar el separador de decimales de ',' a '.'
            Console.WriteLine("Programa que calcula el área de una circunferencia");            //Texto explicativo
            Console.Write("Introduce radio de la circunferencia: ");                    
            radio = double.Parse(Console.ReadLine(),formatoNumeroPunto);                        //Lee un número (el separador de decimales es el punto).
            Console.WriteLine("El área de una circunferencia de radio {0:0.00} es {1:0.00}",radio,Math.PI*radio*radio); //Muestra el radio y el area con 2 decimales.
            Console.ReadLine();
        }
    }
}
