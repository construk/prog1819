/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		Numeros
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 ene 2019
 *  Descripción:	Programa que funciona usando la clase Numeros que nos permite gestionar una serie de operaciones matemáticas.
-------------------------------------------------------------------------------------------------------------*/
using System;
using App_R701_MenuPrincipal;

namespace App_R704_MatematicasFran
{
    class Ej4_Matematicas
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();
            int numero;
            string aux;
            Console.Write("Introduce un número sobre el que operar: ");
            aux = Console.ReadLine();
            while (!int.TryParse(aux, out numero) || numero < 0)
            {
                Console.Write("Introduce número válido para operar (entero no negativo): ");
                aux = Console.ReadLine();
            }
            Numeros numeros = new Numeros(numero);
            
            do
            {
                try
                {
                    Console.Clear();
                    string[] opciones;
                    if (numeros.Numero>0)
                    {
                        opciones = new string[] { "Cambiar número", "Factorial recursivo", "Factorial iterativo", "Fibonacci recursivo", "Fibonacci iterativo", "Suma n números recursiva", "Suma n números iterativa", "Comprobar si es primo", string.Format("Obtener {0} primos", numeros.Numero) };
                    }
                    else
                    {
                        opciones = new string[] { "Cambiar número", "Factorial recursivo", "Factorial iterativo", "Fibonacci recursivo", "Fibonacci iterativo", "Suma n números recursiva", "Suma n números iterativa", "Comprobar si es primo" };
                    }

                    MenuPrincipal menu = new MenuPrincipal(string.Format("Menu             Tu número es: {0}", numeros.Numero), opciones, ConsoleColor.DarkBlue, TipoMarco.Doble, EstiloTexto.alineadoIzquierda);
                    menu.Pintar();
                    Console.WriteLine();
                    Console.WriteLine("           ESC- Salir");
                    tecla = Console.ReadKey(true);
                    switch (tecla.KeyChar)
                    {
                        case '1':       //CAMBIAR  NÚMERO
                            Console.Write("Elige el nuevo número a utilizar: ");
                            aux = Console.ReadLine();
                            while (!int.TryParse(aux, out numero) || numero < 0)
                            {
                                Console.Write("Introduce número válido para operar (entero no negativo): ");
                                aux = Console.ReadLine();
                            }
                            numeros.Numero = numero;
                            break;
                        case '2':       //FACTORIAL RECURSIVA
                            Console.WriteLine("Factorial recursivo de {0} es {1}", numero, numeros.FactorialRecursiva());
                            Console.ReadLine();
                            break;
                        case '3':       //FACTORIAL ITERATIVA
                            Console.WriteLine("Factorial iterativo de {0} es {1}", numero, numeros.FactorialIterativa());
                            Console.ReadLine();
                            break;
                        case '4':       //FIBONACCI RECURSIVO
                            Console.WriteLine("Fibonacci recursivo de {0} es {1}", numero, numeros.FibonacciRecursivo());
                            Console.ReadLine();
                            break;
                        case '5':       //FIBONACCI ITERATIVO
                            Console.WriteLine("Fibonacci iterativo de {0} es {1}", numero, numeros.FibonacciIterativo());
                            Console.ReadLine();
                            break;
                        case '6':       //SUMA N NÚMEROS RECURSIVO
                            Console.WriteLine("La suma de los números desde 0 hasta {0}(recursiva) es {1}", numero, numeros.SumaNNumerosRecursiva());
                            Console.ReadLine();
                            break;
                        case '7':       //SUMA N NÚMEROS ITERATIVO
                            Console.WriteLine("La suma de los números desde 0 hasta {0}(iterativa) es {1}", numero, numeros.SumaNNumerosIterativa());
                            Console.ReadLine();
                            break;
                        case '8':       //ES PRIMO
                            string texto;
                            if (numeros.EsPrimo())
                            {
                                texto = " es primo.";
                            }
                            else
                            {
                                texto = " no es primo.";
                            }
                            Console.Write("El número {0}" + texto, numeros.Numero);
                            Console.ReadLine();
                            break;
                        case '9':       //N PRIMOS
                            if (numero > 0)
                            {
                                int[] listaPrimos = numeros.Primos();
                                Console.Write(listaPrimos[0]);
                                for (int i = 1; i < listaPrimos.Length; i++)
                                {
                                    Console.Write(", " + listaPrimos[i]);
                                }
                                Console.WriteLine(".");
                                Console.ReadLine();
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No se puede realizar la operación.");
                    Console.ReadLine();
                }
            } while (tecla.Key != ConsoleKey.Escape);
        }
    }
}
