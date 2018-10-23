/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    AreaVolumenCilindro
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Calcular el area lateral y volumen de un cilindro (separador de decimales ',').
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R2E16_AreaVolumenCilindro
{
    class Program
    {
        static void Main(string[] args)
        {
            //CAMPOS
            double _altura = 0;
            double _radio = 0;
            double _areaLateral = 0;
            double _volumen = 0;

            //INSTRUCCIONES E INTRODUCCIÓN DE DATOS
            Console.WriteLine("Programa que calcula el área lateral y el volumen de un cilindro");
            Console.Write("Introduce la altura: ");
            _altura=double.Parse(Console.ReadLine());
            Console.Write("Introduce el radio: ");
            _radio = double.Parse(Console.ReadLine());
            
            //CÁLCULO DE VOLUMEN Y ÁREA
            _volumen = Math.PI * _radio * _radio * _altura;
            _areaLateral = 2 * Math.PI * _radio * _altura;

            //MOSTRAR RESULTADOS
            Console.WriteLine("El cilindro de radio {0} y altura {1} tiene:", _radio,_altura);
            Console.WriteLine("   -Area:    {0}\n   -Volumen: {1}",_areaLateral,_volumen);
            Console.ReadLine();
        }
    }
}
