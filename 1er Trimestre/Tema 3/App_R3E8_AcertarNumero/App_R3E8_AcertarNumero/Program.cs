/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Acertar número
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación es un juego donde un jugador debe de introducir un número y el otro intentará acertarlo.
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R3E8_AcertarNumero
{
    class Program
    {
        static void Main(string[] args)
        {
            string auxiliar;        //Utilizado para controlar excepciones de transformación
            string auxiliarProbado; //Utilizado para controlar excepciones de transformación
            int numero;             //Registra el número secreto a acertar
            int numeroProbado;      //Numero que introduce el jugador  
            int contadorProbados=0; //Contador para registrar las veces que se ha probado a acertar el número

            //INTRODUCCIÓN Y ENTRADA DEL NÚMERO SECRETO
            Console.WriteLine("ACERTAR NÚMEROS\nEste programa es un juego en el que un jugador introducirá un número y otro sin saberlo intentará acertarlo");
            Console.WriteLine("Introduce un número (que no lo vea el otro jugador) entre 0 y 100: ");
            auxiliar = Console.ReadLine();

            //COMPROBAR EL TIPO DEL DATO, Y MIENTRAS NO PUEDA TRANSFORMAR A INT (ENTERO) O EL NÚMERO SEA MENOR QUE 0 O MAYOR QUE 100 VOLVER A PEDIR
            while (!int.TryParse(auxiliar, out numero)||numero<0||numero>100)
            {
                Console.Write("No has introducido un número válido, introduce otro número: ");
                auxiliar = Console.ReadLine();
            }
            do  //HACER  MIENTRAS EL NÚMERO SEA DISTINTO AL QUE HAY QUE ACERTAR
            {
                Console.Clear();                                            //LIMPIAR PANTALLA PARA NO VER EL NUMERO INTRODUCIDO
                Console.WriteLine("ACERTAR NÚMEROS");
                Console.Write("Introduce el número a probar: ");
                auxiliarProbado = Console.ReadLine();                       //INTRODUCE NÚMERO
                while (!int.TryParse(auxiliarProbado, out numeroProbado))   //CONTROL SOBRE EL NÚMERO TRANSFORMADO EVITANDO ERRORES
                {
                    Console.Write("No has introducido un número válido, introduce otro número: ");
                    auxiliarProbado = Console.ReadLine();
                }
                contadorProbados++;                                         //AUMENTA EL CONTADOR DE NÚMEROS PROBADOS     
                if (numero > numeroProbado)                                 //SI EL NÚMERO ES MAYOR QUE EL PROBADO, MENSAJE
                {
                    Console.WriteLine("El número a acertar es mayor, introduce un número más alto, pulsa ENTER para continuar.");
                    Console.ReadLine();
                }
                else if (numero < numeroProbado)                            //SI EL NÚMERO ES MENOR QUE EL PROBADO, MENSAJE
                {
                    Console.WriteLine("El número a acertar es menor, introduce un número más bajo, pulsa ENTER para continuar.");
                    Console.ReadLine();
                }
                else                                                        //SI EL NÚMERO ES IGUAL QUE EL PROBADO, MENSAJE
                {
                    Console.WriteLine("ACERTASTE!! En {0} intentos", contadorProbados);
                    Console.ReadLine();
                }
            } while (numero!=numeroProbado);                                //MIENTRAS EL NÚMERO SEA DISTINTO DEL PROBADO, LIMPIA LA PANTALLA Y PIDE DE NUEVO NÚMERO
        }
    }
}
