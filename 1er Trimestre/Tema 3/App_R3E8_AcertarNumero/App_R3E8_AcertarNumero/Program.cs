using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.Clear();                                    //LIMPIAR PANTALLA PARA NO VER EL NUMERO INTRODUCIDO
                Console.WriteLine("ACERTAR NÚMEROS");
                Console.Write("Introduce el número a probar: ");
                auxiliarProbado = Console.ReadLine();
                while (!int.TryParse(auxiliarProbado, out numeroProbado))
                {
                    Console.Write("No has introducido un número válido, introduce otro número: ");
                    auxiliarProbado = Console.ReadLine();
                }
                contadorProbados++;
                if (numero > numeroProbado)
                {
                    Console.WriteLine("El número a acertar es mayor, introduce un número más alto, pulsa ENTER para continuar.");
                    Console.ReadLine();
                }
                else if (numero < numeroProbado)
                {
                    Console.WriteLine("El número a acertar es menor, introduce un número más bajo, pulsa ENTER para continuar.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("ACERTASTE!! En {0} intentos", contadorProbados);
                    Console.ReadLine();
                }
            } while (numero!=numeroProbado);
            

        }
    }
}
