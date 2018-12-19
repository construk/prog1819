/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		LetraDni
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Ejercicio que tiene un método que te devuelve la letra del DNI y te lo muestra por pantalla
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R606_LetraDNI
{
    class Ejercicio06
    {
        static void Main(string[] args)
        {
            string aux;
            int numero;
            Console.WriteLine("Introduce el número de tu dni, sin letra");
            Console.Write("Número DNI: ");
            aux = Console.ReadLine();
            while(aux.Length != 8||!int.TryParse(aux,out numero))  //Controla que el número introducido cumple que es de longitud 8 y que se pueda transformar a int
            {
                Console.Write("Introduce número de dni válido: ");
                aux = Console.ReadLine();
            }
            Console.WriteLine("DNI: "+numero+LetraDni(numero));
            Console.Write("\nIntroduce de nuevo tu número de dni: ");
            string numero2 = Console.ReadLine();
            try
            {
                Console.WriteLine("DNI: " + numero2 + LetraDni(numero2));
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("\nPulsa ENTER para salir...");
            Console.ReadLine();
        }
        /// <summary>
        /// Método que devuelve la letra del DNI
        /// </summary>
        /// <param name="numero">Número del DNI</param>
        /// <returns>Letra del DNI</returns>
        public static char LetraDni(int numero)
        {
            string letrasDni = "TRWAGMYFPDXBNJZSQVHLCKE";
            if (numero < 0 || numero > 99999999)
                throw new FormatException("El número introducido no es válido");
            
            return letrasDni[numero % 23];          //Devuelve el caracter de letrasDni posición: numero%módulo 23 
        }
        /// <summary>
        /// Método que devuelve la letra del DNI
        /// </summary>
        /// <param name="numero">Número del DNI</param>
        /// <returns>Letra del DNI</returns>
        public static char LetraDni(string numero)
        {
            string letrasDni = "TRWAGMYFPDXBNJZSQVHLCKE";
            int numeroInt;
            if (!int.TryParse(numero, out numeroInt))
                throw new FormatException("La cadena pasada debe de ser un número");
            if (numero.Length!=8)
                throw new FormatException("La longitud del número del dni debe de ser de 8 caracteres");

            return letrasDni[numeroInt % 23];          //Devuelve el caracter de letrasDni posición: numero%módulo 23 

        }
    }
}
