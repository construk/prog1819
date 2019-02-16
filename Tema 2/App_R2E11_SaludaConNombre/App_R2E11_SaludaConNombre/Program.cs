/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Saluda con nombre
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación escribe por pantalla un saludo.
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R2E11_SaludaConNombre
{
    class Program
    {
        static void Main(string[] args)
        {
            string _nombre;
            Console.Write("Escribe tu nombre: ");
            _nombre = Console.ReadLine();
            Console.WriteLine("¡"+_nombre+ ", bienvenido al mundo del .NET!");
            Console.ReadLine();
        }
    }
}
