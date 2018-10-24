using System;

namespace App_R3E10_7A99EsPrimo
{
    class Program
    {
        static void Main(string[] args)
        {
            uint numero;        //Entero que solo admite positivos
            string auxiliar;    //string auxiliar utilizado para comprobar que el tipo del dato introducido sea correcto
            Console.Write("Introduce un número entero positivo para comprobar si es primo o no: ");
            auxiliar = Console.ReadLine();  //Leer el dato como string
            while (!uint.TryParse(auxiliar, out numero))    //Mientras no se pueda transformar a uint pedirá el dato de nuevo.
            {
                Console.WriteLine("Introduce un número válido: ");
                auxiliar = Console.ReadLine();
            }
            string textoEsPrimo = EsPrimo(numero) ? string.Format("El número {0} es Primo", numero) : string.Format("El número {0} no es Primo", numero);   //Texto si primo y no primo
            Console.WriteLine(textoEsPrimo);        //Escribe el texto
            
            /*
            if (EsPrimo(numero))                    //FORMA NO SIMPLIFICADA (SIN TERNARIA)
                Console.WriteLine("Es primo");
            else
                Console.WriteLine("No es primo");
            */

            Console.WriteLine("Pulse ENTER para salir");    //Mensaje antes de salir
            Console.ReadLine();                             //Mantener el programa
        }
        private static bool EsPrimo(uint numero) //Función que recibe un número de tipo uint que devuelve true si es primo y false si no lo es
        { 
            int divisor=2;      //Desde donde comenzamos a comprobar divisibles
            if (numero<2)       //Controlamos el caso del número 0 y 1, que no son primos
	        {
		        return false;
	        }else if (numero<4) //Controlamos el caso del número 2 y 3, que son primos
	        {
                return true;
            }
            else                //Controlamos el resto de casos (hasta el máximo aceptado por un uint)
            {
                while(numero % divisor != 0 && divisor<=numero/2)   //Mientras el número no sea divisible y el divisor sea menor a la mitad del número comprobado, incrementa divisor
                {                                                   //Cuando termine de comprobar las condiciones se evaluará el último valor contemplado como divisor
                    divisor++;                                      
                }
                return numero % divisor == 0 ? false : true;        //y si el numero entre el divisor es 0 será falso y si no será verdadero
            }
        }
    }
}
