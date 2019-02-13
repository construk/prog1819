/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ListaDinamicaEnteros
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Programa con dos funciones que gestionan la introducción de un ArrayList que contiene números enteros, cuando 
 *                  se introduzca un valor mostrará un mensaje indicando si el valor es válido o no, y se introducirá solo el que sea
 *                  válido como entero. También permite listar los números introducidos y ordenarlos.
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;

namespace App_R616_ListaDinamicaEnteros
{
    class Ejercicio16
    {
        static void Main(string[] args)
        {
            GestionarEnteros();
        }
        public static void GestionarEnteros()
        {
            ArrayList listaEntero = new ArrayList();
            object texto;
            int valor = 0;
            Console.WriteLine("Introduce números para almacenarlos en una lista dinámica donde podrás almacenar hasta {0} números,\n" +
                "con valores entre {1} y {0}\n" +
                "OPCIONES:  (L) Listar valores   (O) Ordenarlos   (S) Salir", int.MaxValue, int.MinValue);
            do
            {
                bool valorEntero = true;
                Console.Write("Introduce un número: ");
                texto = Console.ReadLine();
                if (!texto.ToString().Equals("S") && !texto.ToString().Equals("s") && !texto.ToString().Equals("L") && !texto.ToString().Equals("l") && !texto.ToString().Equals("O") && !texto.ToString().Equals("o"))
                {
                    try
                    {
                        valor = int.Parse(texto.ToString());
                    }
                    catch (Exception)
                    {
                        valorEntero = false;
                    }
                    if (valorEntero)
                    {
                        listaEntero.Add(valor);
                        Console.WriteLine("Dato añadido con exito.");
                    }
                    else
                    {
                        Console.WriteLine("Error: El dato introducido no es válido.");
                    }
                }
                if (texto.ToString().Equals("L") || texto.ToString().Equals("l"))
                {
                    MostrarDatosLista(listaEntero);
                }
                else if (texto.ToString().Equals("O") || texto.ToString().Equals("o"))
                {
                    listaEntero.Sort();
                }
            } while (!texto.Equals("S") && !texto.Equals("s"));
        }
        private static void MostrarDatosLista(ArrayList listaEntero)
        {
            foreach (object obj in listaEntero)
            {
                Console.WriteLine(obj);
            }
        }
    }
}
