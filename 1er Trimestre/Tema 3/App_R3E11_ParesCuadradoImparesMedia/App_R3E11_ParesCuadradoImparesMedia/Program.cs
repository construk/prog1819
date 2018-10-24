/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Pares Cuadrado Impares Media
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación sumará pares e impares y hayará el cuadrado de los pares y media de los impares.
-------------------------------------------------------------------------------------------------------------*/
using System;


namespace App_R3E11_ParesCuadradoImparesMedia
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero;             //numero introducido
            string auxiliar;        //para comprobar el tipo del dato introducido
            int sumaPares=0;        //Aquí se suman los números pares
            int sumaImpares = 0;    //Aquí se suman los números impares
            int contadorImpares = 0;//Contador del número de impares para realizar la media
            do
            {
                //LIMPIAR LA PANTALLA PARA MEJOR EXPERIENCIA
                Console.Clear();
                Console.WriteLine("Introduce números hasta introducir un cero, se mostrará por pantalla el cuadrado de la suma de los pares y la media de la suma de los impares");
                Console.Write("Introduce un número: ");
                
                //LEER DATO Y COMPROBAR EL TIPO PARA EVITAR ERRORES
                auxiliar = Console.ReadLine();
                while (!int.TryParse(auxiliar, out numero))
                {
                    Console.Clear();
                    Console.WriteLine("Introduce números hasta introducir un cero, se mostrará por pantalla el cuadrado de la suma de los pares y la media de la suma de los impares");
                    Console.Write("Dato introducido inválido, introduce un número válido: ");
                    auxiliar = Console.ReadLine();
                }
                //SUMAR DATOS INTRODUCIDOS Y REGISTRO DE CONTADOR IMPARES
                if (numero % 2 == 0)    //PARES
                {
                    sumaPares += numero;
                }
                else {                  //IMPARES
                    sumaImpares += numero;
                    contadorImpares++;
                }

            } while (numero!=0);        //SALIDA DEL PROGRAMA: CUANDO SE INTRODUCE 0


            Console.WriteLine("La suma de los pares es {0} y su cuadrado {1}",sumaPares,sumaPares*sumaPares);   //ESCRIBIR RESULTADO PARES
            if (contadorImpares==0)                                                                             //ESCRIBIR RESULTADO IMPARES (COMPROBAR QUE NO HAYA DIVISOR 0)
            {
                Console.WriteLine("NO EXISTEN NÚMEROS IMPARES");
            }else
                Console.WriteLine("La suma de los impares es {0} y su media {1:F2}",sumaImpares, (sumaImpares / (double)contadorImpares));

            Console.ReadLine();                                                                                 //MANTENER PROGRAMA HASTA QUE SE PULSE ENTER
        }
    }
}
