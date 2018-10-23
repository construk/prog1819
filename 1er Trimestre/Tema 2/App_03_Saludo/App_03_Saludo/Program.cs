/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    Saludo
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación escribe por pantalla un saludo.
-------------------------------------------------------------------------------------------------------------*/
using System;               //Librería necesaria para poder escribir por pantalla en la consola

namespace App_03_Saludo     //Espacio de nombre de la clase
{
    class Program           //Clase Program, clase que se crea por defecto en los proyectos de consola
    {
        static void Main(string[] args)                     //Método especial, Main, es el método por donde se comienzan a ejecutar los programas de consola
        {
            Console.WriteLine("Hola Sebastian! :D");        //Metodo de la clase consola para escribir por pantalla con un salto de linea
            Console.ReadLine();                             //Método para leer caracteres como String hasta pulsar la tecla Enter
        }
    }
}