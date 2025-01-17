﻿/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    MenuFunciones
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		Esta aplicación pinta un menu con algoritmos realizadas durante el curso
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Threading;

namespace App_R4E22_MenuFunciones
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo teclaLeida = new ConsoleKeyInfo();   //TECLA INTRODUCIDA POR EL USUARIO QUE SE OBTENDRÁ EL CARACTER INTRODUCIDO
            char opcionChar;                                      //OPCIÓN INTRODUCIDA POR EL USUARIO DE TIPO INT QUE COMPRUEBA QUE SEA UN NÚMERO LO QUE INTRODUCE
            bool noSalir = true;
            string elegidaString = teclaLeida.KeyChar.ToString();       //SE TRANSFORMA A STRING PORQUE NO EXISTE SOBRECARGA PARA TIPO CHAR PARA MÉTODO TRYPARSE

            do                                                  //HACER MIENTRA EL BOOLEANO NO SALIR SEA TRUE (SE VUELVE FALSE SI SE PULSA 0)
            {
                LimpiaYPintaMenuPrincipal();                    //MÉTODO QUE LIMPIA LA CONSOLA Y PINTA EL MENÚ PRINCIPAL PARA DICHO PROGRAMA
                int posicionTop = Console.CursorTop;            //GUARDAMOS LA POSICIÓN TOP DE ESCRITURA;
                int posicionLeft = Console.CursorLeft;          //GUARDAMOS LA POSICIÓN LEFT DE ESCRITURA;
                //LEER OPCION
                teclaLeida = Console.ReadKey();                  //INTRODUCIDO POR EL USUARIO

                //MIENTRAS NO PUEDA TRANSFORMARLO A INT PIDE EL NÚMERO Y BORRA EL CAMPO ESCRITO
                while (!char.TryParse(elegidaString, out opcionChar))
                {
                    Console.SetCursorPosition(posicionLeft, posicionTop);   //POSICIONA PARA BORRAR EL CAMPO INTRODUCIDO PORQUE NO PUEDE TRANSFORMA A STRING
                    Console.Write(" ");                                     //BORRA EL CAMPO INTRODUCIDO
                    Console.SetCursorPosition(posicionLeft, posicionTop);   //POSICIONA PARA LEER
                    teclaLeida = Console.ReadKey();                         //LEE DATO DEL USUARIO
                    elegidaString = teclaLeida.KeyChar.ToString();          //GUARDA COMO STRING PARA COMPROBAR SI SE PUEDE TRANSFORMA A INT
                }
                //OPCIÓN ELEGIDA
                switch (teclaLeida.KeyChar)                                 //SEGÚN LA TECLA PULSADA
                {
                    #region Salir
                    case '0':                                               //OPCION PARA SALIR
                        noSalir = false;                                    //PONE A FALSE EL BOOLEANO QUE MANTIENE EL BUCLE DEL MENÚ
                        Console.SetCursorPosition(Console.CursorLeft - 16, Console.CursorTop + 3);
                        Console.Write("Saliendo");
                        Thread.Sleep(400);
                        Console.Write(".");
                        Thread.Sleep(400);
                        Console.Write(".");
                        Thread.Sleep(400);
                        Console.Write(".");
                        break;
                    #endregion
                    #region Imprimir N Caracteres
                    case '1':                                                       //OPCIÓN IMPRIMIR N CARACTERES
                        Console.Clear();
                        //VARIABLES
                        int numeroVeces;
                        char caracterLeido;
                        string auxiliar = null;        //Para comprobar tipo en el while

                        //INTRODUCCIÓN Y ENTRADA DE DATOS
                        Console.WriteLine("Este programa imprime un número determinado de veces un caracter");
                        Console.Write("Introduce caracter: ");
                        caracterLeido = Console.ReadKey().KeyChar;
                        Console.ReadLine();
                        Console.Write("Introduce el número de veces para que se repita: ");
                        auxiliar = Console.ReadLine();

                        //MIENTRAS NO PUEDA TRANSFORMAR A INT PEDIRÁ DE NUEVO EL NÚMERO
                        while (!int.TryParse(auxiliar, out numeroVeces))
                        {
                            Console.WriteLine("Introduce un número válido: ");
                            auxiliar = Console.ReadLine();
                        }

                        //FUNCIÓN QUE IMPRIME LOS CARACTERES CON LOS DATOS INTRODUCIDOS
                        ImprimirNVecesCaracter(caracterLeido, numeroVeces);

                        //SALIDA EL PROGRAMA    
                        Console.CursorVisible = false;
                        Console.WriteLine("\n\nPulse una tecla para salir...");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Es Primo
                    case '2':                                                       //OPCIÓN ES PRIMO
                        Console.Clear();
                        //VARIABLES
                        int numeroIntroducido;
                        string aux = null;

                        //INTRODUCCIÓN
                        Console.WriteLine("Programa que te dice si un número es primo o no (0 para salir)");
                        do
                        {
                            //ENTRADA DE DATOS
                            Console.Write("Introduce un número: ");
                            aux = Console.ReadLine();
                            //SI NO PUEDE TRANSFORMAR A UINT PIDE DE NUEVO EL DATO
                            while (!int.TryParse(aux, out numeroIntroducido))
                            {
                                Console.Write("Introduce un número válido: ");
                                aux = Console.ReadLine();
                            }

                            if (numeroIntroducido != 0)           //SI EL NÚMERO INTRODUCIDO NO ES 0
                            {
                                if (EsPrimo(numeroIntroducido)) //SI ES PRIMO
                                    Console.WriteLine("El número {0} es primo", numeroIntroducido);
                                else                            //SI NO ES PRIMO
                                    Console.WriteLine("El número {0} no es primo", numeroIntroducido);
                            }
                            else                                //SI EL NUMERO INTRODUCIDO ES 0
                            {
                                Console.CursorVisible = false;
                                Console.Write("Saliendo");
                                Thread.Sleep(800);
                                Console.Write(".");
                                Thread.Sleep(800);
                                Console.Write(".");
                                Thread.Sleep(800);
                                Console.Write(".");
                                Thread.Sleep(800);
                            }

                        } while (numeroIntroducido != 0);         //PEDIR NÚMEROS MIENTRAS NO INTRODUZCAS 0
                        break;
                    #endregion
                    #region Ecuación de segundo grado
                    case '3':                                                       //OPCIÓN ECUACIÓN SEGUNDO GRADO
                        Console.Clear();
                        //CAMPOS
                        double a, b, c;
                        string aux1;

                        //INTRODUCCIÓN
                        Console.WriteLine("Aplicación que calcula ecuación de segundo grado");
                        Console.WriteLine("ax²+bx+c\n");

                        //ENTRADA DE DATOS
                        Console.Write("Introduce primer elemento (ax²): ");
                        aux1 = Console.ReadLine();
                        while (!double.TryParse(aux1, out a) || aux1 == "0")
                        {
                            Console.Write("Introduce un número válido: ");
                            aux1 = Console.ReadLine();
                        }
                        Console.Write("Introduce segundo elemento (bx): ");
                        aux1 = Console.ReadLine();
                        while (!double.TryParse(aux1, out b))
                        {
                            Console.Write("Introduce un número válido: ");
                            aux1 = Console.ReadLine();
                        }
                        Console.Write("Introduce tercer elemento (c): ");
                        aux1 = Console.ReadLine();
                        while (!double.TryParse(aux1, out c))
                        {
                            Console.Write("Introduce un número válido: ");
                            aux1 = Console.ReadLine();
                        }

                        //RESULTADOS
                        if (b * b < 4 * a * c)         //SI NO EXISTE SOLUCIÓN REAL
                        {
                            Console.WriteLine("No existen soluciones reales");
                        }
                        else if (b * b == 4 * a * c)   //SI SOLO TIENE UNA SOLUCIÓN
                        {
                            double resultado = -b / (2 * a);
                            Console.WriteLine("Solo existe una solución");
                            Console.WriteLine("x = {0}", resultado);
                        }
                        else                            //SI TIENE MÁS DE UNA SOLUCIÓN
                        {
                            Console.WriteLine("Existen dos soluciones");
                            double resultado1 = (-b + Math.Sqrt(b * b - (4 * a * c))) / (2 * a);
                            double resultado2 = (-b - Math.Sqrt(b * b - (4 * a * c))) / (2 * a);

                            Console.WriteLine("x₁: {0}", resultado1);
                            Console.WriteLine("x₂: {0}", resultado2);
                        }
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Min y Max introducido
                    case '4':                                                       //OPCIÓN MIN Y MAX INTRODUCIDO
                        Console.Clear();
                        double max = 0;
                        double min = 0;
                        string aux2;
                        double numero;
                        double primerMaxMin = 0;
                        int contador2 = 0;

                        //INTRODUCCIÓN
                        Console.WriteLine("Introduce números y te mostraré el número más grande y más pequeño introducido");
                        do  //HACER MIENTRAS NÚMERO SEA DISTINTO DE 0
                        {
                            //INTRODUCIR DATOS
                            Console.Write("Introduce un número (0 para salir): ");
                            aux2 = Console.ReadLine();
                            while (!double.TryParse(aux2, out numero))
                            {
                                Console.Write("Introduce un número válido: ");
                                aux2 = Console.ReadLine();
                            }

                            if (numero != 0) //SI NÚMERO ES DISTINTO DE CERO, COMPARAR PARA ASIGNAR A MAX O MIN
                            {
                                if (contador2 == 0)                              //AL INTRODUCIR EL PRIMER NÚMERO
                                    primerMaxMin = numero;
                                
                                if ((min == 0 || max == 0) && contador2 != 0)    //SI NO ES EL PRIMER NÚMERO Y SI EL MAX Y MIN SIGUEN SIENDO 0
                                {
                                    if (numero < primerMaxMin)                  //SI NUMERO MENOR QUE EL PRIMER NÚMERO GUARDAR EN MÍNIMO
                                        min = numero;
                                    if (numero > primerMaxMin)                  //SI NUMERO MAYOR QUE EL PRIMER NÚMERO GUARDAR EN MÁXIMO
                                        max = numero;
                                }
                                else                                            //SI NÚMERO MIN Y MAX HA CAMBIADO Y NO ES EL PRIMER NÚMERO INTRODUCIDO
                                {
                                    if (numero < min)                           //SI NUMERO MENOR QUE EL MIN GUARDAR EN MÍNIMO
                                        min = numero;
                                    else if (numero > max)                      //SI NUMERO MAYOR QUE EL MAX GUARDAR EN MÁXIMO
                                        max = numero;
                                }
                                contador2++;                                     //AUMENTAR EL CONTADOR DE NÚMEROS INTRODUCIDOS
                            }
                        } while (numero != 0);                                  

                        //RESULTADOS
                        if (min == 0 && max == 0)
                            Console.WriteLine("No has introducido ningún número");
                        else if (min == 0)
                            Console.WriteLine("El valor máximo es {0}", max);
                        else if (max == 0)
                            Console.WriteLine("El valor mínimo es {0}", min);
                        else
                            Console.WriteLine("El valor máximo es {0}\nEl valor mínimo es {1}", max, min);
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Escribe Mayúsculas
                    case '5':                                                       //OPCIÓN ESCRIBE MAYUSCULAS
                        Console.Clear();
                        ConsoleKeyInfo tecla = new ConsoleKeyInfo();
                        Console.WriteLine("Programa que transforma todo lo que escribas a mayúsculas");
                        Console.WriteLine("* para salir");

                        do
                        {
                            tecla = Console.ReadKey(true);
                            Console.Write(Mayus(tecla));
                        } while (tecla.KeyChar != '*');
                        break;
                    #endregion
                    #region Media Notas
                    case '6':                                                       //OPCIÓN MEDIA NOTAS
                        Console.Clear();
                        double notaLeida;
                        double sumaNotas = 0;
                        int contador = 0;
                        string aux3;
                        double media;

                        Console.WriteLine("Esta aplicación calcula la media de las notas introducidas.");
                        do
                        {
                            Console.Write("Introduce una nota: ");
                            aux3 = Console.ReadLine();
                            while (!double.TryParse(aux3, out notaLeida) || notaLeida < 0)
                            {
                                Console.Write("Introduce una nota válida: ");
                                aux3 = Console.ReadLine();
                            }
                            if (notaLeida != 0)
                            {
                                sumaNotas += notaLeida;
                                contador++;
                            }
                        } while (notaLeida != 0);
                        try
                        {
                            media = sumaNotas / contador;
                            Console.WriteLine("\nLa media de las {0} notas es {1:F2}", contador, media);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Valor Absoluto
                    case '7':                                                       //OPCIÓN VALOR ABSOLUTO
                        Console.Clear();
                        double numero1;
                        string aux4;
                        Console.WriteLine("La función ValorAbsoluto te devuelve cualquier número en valor absoluto");
                        do
                        {
                            Console.Write("Introduce número (0 para salir): ");
                            aux4 = Console.ReadLine();
                            while (!double.TryParse(aux4, out numero1))
                            {
                                Console.Write("Introduce un número válido: ");
                                aux4 = Console.ReadLine();
                            }
                            if (numero1 != 0)
                            {
                                Console.WriteLine("El valor absoluto de " + numero1 + " es " + ValorAbsoluto(numero1));
                            }
                        } while (numero1 != 0);
                        break;
                    #endregion
                    #region Factorial Recursiva
                    case '8':                                                       //OPCION FACTORIAL RECURSIVA
                        Console.Clear();
                        double numero2 = -2;
                        Console.WriteLine("Este programa calcula el factorial de cualquier número");

                        do
                        {
                            try
                            {
                                Console.Write("Introduce número (-1 para salir): ");
                                numero2 = double.Parse(Console.ReadLine());
                                if (numero2 > -1)
                                {
                                    Console.WriteLine("{0:0,0}", FactorialRecursiva(numero2));
                                }
                            }
                            catch (Exception e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(e.Message);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                        } while (numero2 != -1);
                        break;
                    #endregion
                    #region Factorial Iterativa
                    case '9':                                                       //OPCIÓN FACTORIAL ITERATIVA
                        Console.Clear();
                        double numero3;
                        Console.WriteLine("Programa que calcula el factorial de un número de forma recursiva");
                        Console.Write("Introduce un número:");
                        try
                        {
                            numero3 = double.Parse(Console.ReadLine());
                            Console.WriteLine("{0:0,0}", FactorialIterativa(numero3));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadLine();
                        }
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Suma Gaussiana Recursiva
                    case 'A':
                    case 'a':                                                       //OPCION SUMA GAUSSIANA RECURSIVA
                        int numero5;
                        string aux5;
                        Console.Clear();
                        //INTRODUCCIÓN Y ENTRADA DE DATOS
                        Console.WriteLine("Este programa calcula la suma de gauss del número introducido");
                        Console.Write("Introduce un número: ");
                        aux5 = Console.ReadLine();
                        while (!int.TryParse(aux5, out numero5))
                        {
                            Console.Write("Introduce un número válido: ");
                            aux5 = Console.ReadLine();
                        }

                        //RESULTADO
                        try
                        {
                            Console.WriteLine(SumaNNumerosRecursiva(numero5));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Suma Gaussiana Iterativa
                    case 'B':
                    case 'b':
                        Console.Clear();
                        string aux6;
                        long numero7 = -1;
                        Console.WriteLine("Programa que hace la suma gaussiana");
                        do
                        {
                            try
                            {
                                Console.Write("Introduce un número (0 para salir): ");
                                aux6 = Console.ReadLine();
                                while (!long.TryParse(aux6, out numero7))
                                {
                                    Console.Write("Introduce un número válido: ");
                                    aux6 = Console.ReadLine();
                                }
                                Console.WriteLine(SumaNNumerosIterativa(numero7));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        } while (numero7 != 0);
                        break;
                    #endregion
                    #region Potencia Recursiva
                    case 'C':
                    case 'c':
                        Console.Clear();
                        int numero8;
                        int exponente;
                        string aux7;

                        //INTRODUCCIÓN
                        Console.WriteLine("Programa que calcula la potencia de un número");

                        //LEER DATOS
                        Console.Write("Introduce la base: ");
                        aux7 = Console.ReadLine();
                        while (!int.TryParse(aux7, out numero8))
                        {
                            Console.Write("Introduce un número válido: ");
                            aux7 = Console.ReadLine();
                        }
                        aux7 = null;
                        Console.Write("Introduce el exponente: ");
                        aux7 = Console.ReadLine();
                        while (!int.TryParse(aux7, out exponente))
                        {
                            Console.Write("Introduce un número válido: ");
                            aux7 = Console.ReadLine();
                        }

                        //APLICANDO LA FÚNCIÓN RECURSIVA
                        try
                        {
                            Console.WriteLine(PotenciaRecursiva(numero8, exponente));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Resto real 
                    case 'D':
                    case 'd':
                        Console.Clear();
                        double dividendo;
                        double divisor;
                        double resto;
                        string aux8;

                        //INTRODUCCIÓN
                        Console.WriteLine("Programa que recibe el dividendo y el divisor y muestra el resto como número real");

                        //ENTRADA DE DATOS
                        Console.Write("Introduce dividendo: ");             //DIVIDENDO
                        aux8 = Console.ReadLine();
                        while (!double.TryParse(aux8, out dividendo))
                        {
                            Console.Write("Introduce un dato válido: ");
                            aux8 = Console.ReadLine();
                        }
                        aux8 = null;

                        Console.Write("Introduce divisor: ");               //DIVISOR
                        aux8 = Console.ReadLine();
                        while (!double.TryParse(aux8, out divisor) || divisor < 1)
                        {
                            Console.Write("Introduce un dato válido: ");
                            aux8 = Console.ReadLine();
                        }

                        //SI EL RESULTADO DE LA DIVISIÓN DA DECIMALES (UN NÚMERO REAL) GUARDA EL DATO EN LA VARIABLE RESTO, SINO DEVUELVE 0 (Y EJECUTA ELSE)
                        try
                        {
                            if (ParteDecimal(dividendo / divisor, out resto))
                            {
                                Console.WriteLine("El dividendo {0} dividido entre el divisor {1} es igual a: {2}" +
                                "\nParte entera: {3}\tParte decimal: {4}", dividendo, divisor, dividendo / divisor, (int)(dividendo / divisor), resto);
                            }
                            else
                                Console.WriteLine("El dividendo {0} dividido entre el divisor {1} es igual a: {2}" +
                                "\nParte entera: {3}\tParte decimal: {4}", dividendo, divisor, dividendo / divisor, (int)(dividendo / divisor), resto);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Bisiesto
                    case 'E':
                    case 'e':
                        Console.Clear();
                        //VARIABLES
                        string aux9;
                        int anio;

                        //INTRODUCCIÓN
                        Console.WriteLine("Este programa te indica si un año es bisiesto o no (introduce 0 para salir)");
                        do
                        {   //ENTRADA DE DATOS
                            Console.Write("Introduce año: ");
                            aux9 = Console.ReadLine();
                            while (!int.TryParse(aux9, out anio))
                            {
                                Console.Write("Introduce un año válido: ");
                                aux9 = Console.ReadLine();
                            }

                            string esOFue = anio >= DateTime.Now.Year ? "es" : "fue";   //FORMATO PARA STRING

                            try
                            {
                                if (EsBisiesto(anio))   //SI ES BISIESTO
                                {
                                    Console.WriteLine("El año {0} " + esOFue + " bisiesto", anio);
                                }
                                else //SI NO ES BISIESTO
                                {
                                    Console.WriteLine("El año {0} no " + esOFue + " bisiesto", anio);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        } while (anio != 0);
                        break;
                    #endregion
                    #region Fibonacci Recursivo
                    case 'F':
                    case 'f':
                        Console.Clear();
                        //VARIABLES
                        string aux10;
                        int numero9;

                        //INTRODUCCIÓN
                        Console.WriteLine("Programa que calcula el número de la sucesión de Fibonacci que indiques (-1 para salir)");
                        do
                        {
                            //LEER DATOS
                            Console.Write("Introduce número : ");
                            aux10 = Console.ReadLine();
                            while (!int.TryParse(aux10, out numero9))
                            {
                                Console.Write("Introduce un número válido: ");
                                aux10 = Console.ReadLine();
                            }
                            //ESCRIBE EL NÚMERO DE LA SUCESIÓN DE FIBONACCI INDICADO
                            try
                            {
                                if (numero9 >= 0)
                                {
                                    Console.WriteLine(FibonacciRecursivo(numero9));
                                }
                                else
                                    Console.WriteLine("Número no válido");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        } while (numero9 != -1);
                        break;
                    #endregion
                    #region PintaArbol
                    case 'G':
                    case 'g':
                        Console.Clear();
                        //CONSTANTE Y VARIABLE
                        const int POSICION_ESCRIBIR = 57;
                        int altura = -1;

                        //PINTAR DE AZUL EL FONDO
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Clear();

                        //HACER MIENTRAS EL NÚMERO SEA DISTINTO DE 0
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Black;   //CAMBIAMOS PARA PINTAR LAS LETRAS EN NEGRO
                            Console.CursorLeft = POSICION_ESCRIBIR;         //POSICIÓN PARA NO PINTAR SOBRE EL ARBOL
                            Console.CursorVisible = true;                   //OCULTAMOS CURSOR

                            Console.WriteLine("Este programa pinta un arbol (altura max: 28, min: 5)");
                            try
                            {
                                Console.CursorLeft = POSICION_ESCRIBIR; //POSICIÓN PARA NO PINTAR SOBRE EL ARBOL
                                Console.Write("Introduce altura (0 para salir): ");
                                altura = int.Parse(Console.ReadLine()); //INTRODUCE ALTURA
                            }
                            catch (Exception e)
                            {
                                Console.CursorLeft = POSICION_ESCRIBIR; //POSICIÓN PARA NO PINTAR SOBRE EL ARBOL
                                Console.WriteLine(e.Message);           //MENSAJE DE EXCEPCIÓN
                                Console.CursorLeft = POSICION_ESCRIBIR;
                                Console.WriteLine("Pulse ENTER para continuar...");
                                Console.CursorLeft = POSICION_ESCRIBIR;
                                Console.ReadLine();
                            }
                            if (altura != 0)                            //SI NO SALE QUE PINTE EL ARBOL, SINO QUE NO LO PINTE
                                PintaArbol(altura, POSICION_ESCRIBIR);  //PINTA EL ARBOL
                            Console.CursorVisible = false;              //OCULTAR CURSOR
                            Console.BackgroundColor = ConsoleColor.Cyan;//DEJA EL COLOR DE FONDO COMO ESTABA
                        } while (altura != 0);
                        Console.CursorVisible = true;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    #endregion
                    #region Granos Arroz
                    case 'H':
                    case 'h':
                        Console.Clear();
                        const int CASILLAS_AJEDREZ = 8 * 8;     //TOTAL DE CASILLAS DE UN TABLERO DE AJEDREZ
                        const int granosPrimeraCasilla = 1;     //LAS SIGUIENTE CASILLAS SERÁN MÚLTIPLOS DE DOS DE LA CASILLA ANTERIOR
                        decimal totalGranos = 0;                //CONTADOR PARA EL TOTAL DE LOS GRANOS
                        decimal granosCasilla = 1;              //GRANOS POR CASILLA

                        Console.WriteLine("Habrás oído hablar de la historia de un poderoso sultán que deseaba " +
                            "recompensar a un estudiante que le había prestado un gran servicio. Cuando el sultán " +
                            "le preguntó la recompensa que deseaba, éste le señaló un tablero de ajedrez y solicitó " +
                            "simplemente 1 grano de trigo por la primera casilla, 2 por la segunda, 4 por la tercera, " +
                            "8 por la siguiente, y así sucesivamente. El sultán, que no debía andar muy fuerte en matemáticas," +
                            " quedó sorprendido por la modestia de la petición, porque estaba dispuesto a otorgarle riquezas" +
                            " mucho mayores: al menos, eso pensaba él...\n");

                        //SE CONTROLA LA PRIMERA CASILLA
                        totalGranos += granosPrimeraCasilla;    //SE LE SUMA EL PRIMER GRANO

                        for (int i = 2; i <= CASILLAS_AJEDREZ; i++) //POR CADA CASILLLA EMPEZANDO POR LA SEGUNDA
                        {
                            granosCasilla = granosCasilla * 2;      //EL NÚMERO DE GRANOS DE LA CASILLA ES IGUAL A LA ANTERIOR * 2
                            totalGranos += granosCasilla;           //SE SUMA LA CANTIDAD DE GRANOS DE LA CASILLA AL TOTAL DE GRANOS
                            if (i % 8 == 0)                         //SI ES MÚLTIPLO DE 8 MOSTRAR LOS GRANOS DE DICHA CASILLA
                            {
                                Console.WriteLine("En la casilla {0} hay {1:0,0} granos de arroz", i, granosCasilla);
                            }
                        }

                        //AL FINAL MOSTRAR EL TOTAL DE GRANOS QUE TIENE QUE PAGAR AL ESTUDIANTE
                        Console.WriteLine("\nHay un total de {0:0,0} granos de arroz", totalGranos);

                        Console.ReadLine();
                        break;
                    #endregion
                    #region Area Cuadrado
                    case 'I':
                    case 'i':                        //OPCIÓN CALCULAR AREA CUADRADO
                        double ladoCuadrado;
                        string ladoString;
                        Console.Clear();
                        MenuAreaCuadrado();
                        ladoString = Console.ReadLine();
                        while (!double.TryParse(ladoString, out ladoCuadrado))
                        {
                            MenuAreaCuadrado();
                            ladoString = Console.ReadLine();
                        }
                        Console.CursorLeft += 1;
                        try
                        {
                            Console.WriteLine("El área de un cuadrado es: " + ladoCuadrado * ladoCuadrado);
                            Console.CursorLeft += 2;
                            Console.CursorTop += 2;
                            Console.WriteLine("Pulse cualquier tecla para volver al menú principal");
                            Console.CursorVisible = false;
                            Console.ReadLine();
                        }catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    #endregion
                    #region Area Rectángulo
                    case 'J':                                                   //OPCIÓN CALCULAR AREA RECTÁNGULO
                    case 'j':
                        Console.Clear();
                        double ladoA;
                        double ladoB;
                        string ladoAString;
                        string ladoBString;
                        int posX;
                        int posY;
                        MenuAreaRectanguloA();
                        ladoAString = Console.ReadLine();
                        while (!double.TryParse(ladoAString, out ladoA))
                        {
                            MenuAreaRectanguloA();
                            ladoAString = Console.ReadLine();
                        }
                        MenuAreaRectanguloB();
                        posX = Console.CursorLeft;
                        posY = Console.CursorTop;
                        ladoBString = Console.ReadLine();
                        while (!double.TryParse(ladoBString, out ladoB))
                        {
                            Console.SetCursorPosition(posX, posY);
                            Console.Write(" ");
                            Console.SetCursorPosition(posX, posY);
                            ladoBString = Console.ReadLine();
                        }
                        Console.CursorLeft += 1;
                        try
                        {
                            Console.WriteLine("El área de un rectangulo es: " + ladoB * ladoA);
                            Console.CursorLeft += 2;
                            Console.CursorTop += 2;
                            Console.WriteLine("Pulse cualquier tecla para volver al menú principal");
                            Console.ReadLine();
                            Console.CursorVisible = false;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    #endregion
                    #region Area Triángulo
                    case 'K':                                                       //OPCIÓN CALCULAR AREA TRIÁNGULO
                    case 'k':
                        Console.Clear();
                        double _base;
                        double altura2;
                        string baseString;
                        string alturaString;
                        MenuAreaTrianguloA();
                        baseString = Console.ReadLine();
                        while (!double.TryParse(baseString, out _base))
                        {
                            MenuAreaRectanguloA();
                            baseString = Console.ReadLine();
                        }
                        MenuAreaTrianguloB();
                        posX = Console.CursorLeft;
                        posY = Console.CursorTop;
                        alturaString = Console.ReadLine();
                        while (!double.TryParse(alturaString, out altura2))
                        {
                            Console.SetCursorPosition(posX, posY);
                            Console.Write(" ");
                            Console.SetCursorPosition(posX, posY);
                            alturaString = Console.ReadLine();
                        }
                        Console.CursorLeft += 1;
                        Console.WriteLine("El área de un triangulo es: " + _base * altura2 / 2);
                        Console.CursorLeft += 2;
                        Console.CursorTop += 2;
                        Console.WriteLine("Pulse cualquier tecla para volver al menú principal");
                        Console.ReadLine();
                        Console.CursorVisible = false;
                        break;
                    #endregion
                    #region Acertar Número
                    case 'L':                   //CASO JUEGO ACERTAR NÚMERO
                    case 'l':
                        Console.Clear();
                        string auxiliar3;        //Utilizado para controlar excepciones de transformación
                        string auxiliarProbado; //Utilizado para controlar excepciones de transformación
                        int numero10;             //Registra el número secreto a acertar
                        int numeroProbado;      //numero10 que introduce el jugador  
                        int contadorProbados = 0; //Contador para registrar las veces que se ha probado a acertar el número

                        //INTRODUCCIÓN Y ENTRADA DEL NÚMERO SECRETO
                        Console.WriteLine("ACERTAR NÚMEROS\nEste programa es un juego en el que un jugador introducirá un número y otro sin saberlo intentará acertarlo");
                        Console.WriteLine("Introduce un número (que no lo vea el otro jugador) entre 0 y 100: ");
                        auxiliar3 = Console.ReadLine();

                        //COMPROBAR EL TIPO DEL DATO, Y MIENTRAS NO PUEDA TRANSFORMAR A INT (ENTERO) O EL NÚMERO SEA MENOR QUE 0 O MAYOR QUE 100 VOLVER A PEDIR
                        while (!int.TryParse(auxiliar3, out numero10) || numero10 < 0 || numero10 > 100)
                        {
                            Console.Write("No has introducido un número válido, introduce otro número: ");
                            auxiliar3 = Console.ReadLine();
                        }
                        do  //HACER  MIENTRAS EL NÚMERO SEA DISTINTO AL QUE HAY QUE ACERTAR
                        {
                            Console.Clear();                                            //LIMPIAR PANTALLA PARA NO VER EL numero10 INTRODUCIDO
                            Console.WriteLine("ACERTAR NÚMEROS");
                            Console.Write("Introduce el número a probar: ");
                            auxiliarProbado = Console.ReadLine();                       //INTRODUCE NÚMERO
                            while (!int.TryParse(auxiliarProbado, out numeroProbado))   //CONTROL SOBRE EL NÚMERO TRANSFORMADO EVITANDO ERRORES
                            {
                                Console.Write("No has introducido un número válido, introduce otro número: ");
                                auxiliarProbado = Console.ReadLine();
                            }
                            contadorProbados++;                                         //AUMENTA EL CONTADOR DE NÚMEROS PROBADOS     
                            if (numero10 > numeroProbado)                                 //SI EL NÚMERO ES MAYOR QUE EL PROBADO, MENSAJE
                            {
                                Console.WriteLine("El número a acertar es mayor, introduce un número más alto, pulsa ENTER para continuar.");
                                Console.ReadLine();
                            }
                            else if (numero10 < numeroProbado)                            //SI EL NÚMERO ES MENOR QUE EL PROBADO, MENSAJE
                            {
                                Console.WriteLine("El número a acertar es menor, introduce un número más bajo, pulsa ENTER para continuar.");
                                Console.ReadLine();
                            }
                            else                                                        //SI EL NÚMERO ES IGUAL QUE EL PROBADO, MENSAJE
                            {
                                Console.WriteLine("ACERTASTE!! En {0} intentos", contadorProbados);
                                Console.ReadLine();
                            }
                        } while (numero10 != numeroProbado);                                //MIENTRAS EL NÚMERO SEA DISTINTO DEL PROBADO, LIMPIA LA PANTALLA Y PIDE DE NUEVO NÚMERO
                        break;
                    default:                                                        //EN CASO DE PULSAR CUALQUIER OTRA TECLA
                        //TODO
                        Console.Clear();
                        break;
                }
            } while (noSalir);                                                      //MIENTRAS NO SE PULSE 0 EN EL MENÚ NO CAMBIA LA VARIABLE noSalir DE TRUE A FALSE
        }
        #endregion

        #region Pintar Menu
        private static void LimpiaYPintaMenuPrincipal()
        {
            Console.Clear();
            PintaOpciones("MENU PRINCIPAL FUNCIONES", new string[] { "Imprimir N Caracteres", "Es Primo", "Ecuación 2º grado", "Min/Max numeros",
                "Escribe mayúsculas","Media notas","Valor absoluto","Factorial recursiva","Factorial Iterativa","Suma Gaussiana Recursiva",
                "Suma Gaussiana Iterativa","Potencia Recursiva","Resto real", "Bisiesto","Fibonacci Recursivo","Pintar Arbol","Granos Arroz",
            "Área Cuadrado","Área rectángulo","Área Triángulo", "Acertar Número"}, ConsoleColor.Red, ConsoleColor.Yellow);
        }
        private static void PintaMarco(int posicionXIzqSup, int posicionYIzqSup, int posicionXDerInf, int posicionYDerInf)
        {
            int ancho = posicionXDerInf - posicionXIzqSup;
            int alto = posicionYDerInf - posicionYIzqSup;
            //PINTA ESQUINA SUPERIOR IZQUIERDA
            Console.Write("╔");
            //PINTA BORDE SUPERIOR
            for (int i = 0; i < ancho - 1; i++)
            {
                Console.Write("═");                         //X --> POSICIÓN LATERAL        Y --> POSICIÓN VERTICAL
            }                                               //Coordenada1 --> X      (0,0)╔════════════════════════╗
            //PINTA ESQUINA SUPERIOR DERECHA                //Coordenada1 --> Y           ║        TITULO          ║    <-- TITULO
            Console.WriteLine("╗");                         //Coordenada2 --> Y           ╠════════════════════════╣        string[] opciones
            //PINTA LATERAL IZQUIERDO 1                     //                            ║   1. Opcion1           ║    <-- opciones[0]
            Console.WriteLine("║");                         //                            ║   2. Opcion2           ║    <-- opciones[1]
            Console.WriteLine("╠");                         //                            ╠════════════════════════╣
            //PINTA LATERAL IZQUIERDO 2                     //                            ║        elegir:_        ║    <-- introducir opción
            for (int i = 0; i < alto - 5; i++)              //                            ╚════════════════════════╝(7,25)
            {                                               //                              ancho= 25;
                Console.WriteLine("║");                     //                              alto=  7;
            }                                               //                              altoNoUtil= 4; (4 bordes separadores)
            //PINTAL LATERAL IZQUIERDO 3
            Console.WriteLine("╠");
            Console.WriteLine("║");
            //PINTA ESQUINA INFERIOR IZQUIERDA                                              anchoNoUtil=3; (1x2 bordes laterales + 1 espacio antes de escribir)
            Console.Write("╚");
            //PINTA BORDE INFERIOR
            for (int i = 0; i < ancho - 1; i++)
            {
                Console.Write("═");
            }
            //PINTA ESQUINA INFERIOR DERECHA
            Console.Write("╝");
            //PINTA LATERAL DERECHO 1
            Console.SetCursorPosition(posicionXDerInf, posicionYIzqSup + 1);
            Console.WriteLine("║");
            Console.CursorLeft = posicionXDerInf;
            Console.WriteLine("╣");
            Console.CursorLeft = posicionXDerInf;
            //PINTA LATERAL DERECHO 2
            for (int i = 0; i < alto - 5; i++)
            {
                Console.WriteLine("║");
                Console.CursorLeft = posicionXDerInf;
            }
            //PINTA LATERAL DERECHO 3
            Console.WriteLine("╣");
            Console.CursorLeft = posicionXDerInf;
            Console.WriteLine("║");
            //PINTA SEPARADOR TITULO-OPCIONES
            Console.SetCursorPosition(1, 2);
            for (int i = 0; i < ancho - 1; i++)
            {
                Console.Write("═");
            }
            //PINTA SEPARADOR OPCIONES-ELEGIR
            Console.SetCursorPosition(1, 2 + alto - 4);
            for (int i = 0; i < ancho - 1; i++)
            {
                Console.Write("═");
            }

        }
        public static void PintaOpciones(string titulo, string[] opciones, ConsoleColor marco, ConsoleColor texto)
        {
            int nOpciones = opciones.Length;
            int opcionMasLarga = 13;
            foreach (string opcion in opciones)
            {
                if (opcion.Length > opcionMasLarga)
                {
                    opcionMasLarga = opcion.Length;
                }
            }
            int anchoMenu = opcionMasLarga + 5;
            int largoMenu = nOpciones + 5;
            Console.ForegroundColor = marco;
            PintaMarco(0, 0, anchoMenu, largoMenu);
            Console.ForegroundColor = texto;
            PintaLetras(titulo, opciones);

        }
        private static void PintaLetras(string titulo, string[] opciones)
        {

            Console.SetCursorPosition(2, 1);
            Console.Write(titulo);
            Console.SetCursorPosition(2, 3);
            for (int i = 0; i < opciones.Length; i++)
            {
                if (i >= 0 && i <= 8)
                {
                    Console.WriteLine(i + 1 + ". " + opciones[i]);
                }
                else
                {
                    Console.WriteLine((char)(i + (int)'a' - 9) + ". " + opciones[i]);
                }

                Console.CursorLeft = 2;
            }
            Console.SetCursorPosition(1, opciones.Length + 6);
            Console.WriteLine("Pulse 0 para salir");
            Console.SetCursorPosition(2, 2 + opciones.Length + 2);
            Console.Write("Elige opción: ");
        }
        #endregion
        private static void ImprimirNVecesCaracter(char caracter, int numeroVeces)
        {
            for (int i = 0; i < numeroVeces; i++)
                Console.Write(caracter);
        }
        public static char Mayus(ConsoleKeyInfo tecla)
        {
            int diferenciaMayusMinus = (int)'a' - (int)'A';

            if (tecla.KeyChar >= 'a' && tecla.KeyChar <= 'z')//RANGO a-z
            {
                return (char)(tecla.KeyChar - diferenciaMayusMinus);
            }
            else if (tecla.KeyChar == 'ñ')//ñ
            {
                return 'Ñ';
            }
            else if (tecla.KeyChar == 'á')//´
            {
                return 'Á';
            }
            else if (tecla.KeyChar == 'é')
            {
                return 'É';
            }
            else if (tecla.KeyChar == 'í')
            {
                return 'Í';
            }
            else if (tecla.KeyChar == 'ó')
            {
                return 'Ó';
            }
            else if (tecla.KeyChar == 'ú')
            {
                return 'Ú';
            }
            else if (tecla.KeyChar == 'à')//`
            {
                return 'À';
            }
            else if (tecla.KeyChar == 'è')
            {
                return 'È';
            }
            else if (tecla.KeyChar == 'ì')
            {
                return 'Ì';
            }
            else if (tecla.KeyChar == 'ò')
            {
                return 'Ò';
            }
            else if (tecla.KeyChar == 'ù')
            {
                return 'Ù';
            }
            else if (tecla.KeyChar == 'ä')//¨
            {
                return 'Ä';
            }
            else if (tecla.KeyChar == 'ë')
            {
                return 'Ë';
            }
            else if (tecla.KeyChar == 'ï')
            {
                return 'Ï';
            }
            else if (tecla.KeyChar == 'ö')
            {
                return 'Ö';
            }
            else if (tecla.KeyChar == 'ü')
            {
                return 'Ü';
            }
            else if (tecla.KeyChar == 'ç')
            {
                return 'Ç';
            }
            else
            {
                return tecla.KeyChar;
            }
        }
        #region Es Primo
        private static bool EsPrimo(uint numero) //Función que recibe un número de tipo uint que devuelve true si es primo y false si no lo es
        {
            int divisor = 2;      //Desde donde comenzamos a comprobar divisibles
            if (numero < 2)       //Controlamos el caso del número 0 y 1, que no son primos
            {
                return false;
            }
            else if (numero < 4) //Controlamos el caso del número 2 y 3, que son primos
            {
                return true;
            }
            else                //Controlamos el resto de casos (hasta el máximo aceptado por un uint)
            {
                while (numero % divisor != 0 && divisor <= numero / 2)   //Mientras el número no sea divisible y el divisor sea menor a la mitad del número comprobado, incrementa divisor
                {                                                   //Cuando termine de comprobar las condiciones se evaluará el último valor contemplado como divisor
                    divisor++;
                }
                return numero % divisor == 0 ? false : true;        //y si el numero entre el divisor es 0 será falso y si no será verdadero
            }
        }
        public static bool EsPrimo(int numero) //Función que recibe un número de tipo int que devuelve true si es primo y false si no lo es
        {
            int divisor = 2;      //Desde donde comenzamos a comprobar divisibles
            if (numero >= 0)
            {
                if (numero < 2)       //Controlamos el caso del número 0 y 1, que no son primos
                {
                    return false;
                }
                else if (numero < 4) //Controlamos el caso del número 2 y 3, que son primos
                {
                    return true;
                }
                else                //Controlamos el resto de casos (hasta el máximo aceptado por un uint)
                {
                    while (numero % divisor != 0 && divisor <= numero / 2)   //Mientras el número no sea divisible y el divisor sea menor a la mitad del número comprobado, incrementa divisor
                    {                                                   //Cuando termine de comprobar las condiciones se evaluará el último valor contemplado como divisor
                        divisor++;
                    }
                    return numero % divisor == 0 ? false : true;        //y si el numero entre el divisor es 0 será falso y si no será verdadero
                }
            }
            else
            {
                if (numero > -2)       //Controlamos el caso del número -1, que no es primo
                {
                    return false;
                }
                else if (numero > -4) //Controlamos el caso del número -2 y -3, que son primos
                {
                    return true;
                }
                else                //Controlamos el resto de casos (hasta el máximo aceptado por un int)
                {
                    while (numero % divisor != 0 && divisor <= -numero / 2)   //Mientras el número no sea divisible y el divisor sea menor a la mitad del número comprobado, incrementa divisor
                    {                                                   //Cuando termine de comprobar las condiciones se evaluará el último valor contemplado como divisor
                        divisor++;
                    }
                    return numero % divisor == 0 ? false : true;        //y si el numero entre el divisor es 0 será falso y si no será verdadero
                }
            }
        }
        #endregion
        #region EsBisiesto
        public static bool EsBisiesto(int anio) //Un año es bisiesto si es divisible entre 4, pero que no sea divisible entre 100, pero si entre 400.
        {
            if (anio % 4 == 0 && anio % 400 == 0)
                return true;
            else if (anio % 4 == 0 && anio % 100 == 0)
                return false;
            else if (anio % 4 == 0)
                return true;
            else
                return false;
        }
        #endregion
        #region Valor Absoluto
        public static double ValorAbsoluto(double numero1)
        {
            if (numero1 >= 0)
                return numero1;
            else
                return -numero1;
        }
        public static int ValorAbsoluto(int numero1)
        {
            if (numero1 >= 0)
                return numero1;
            else
                return -numero1;
        }
        public static decimal ValorAbsoluto(decimal numero1)
        {
            if (numero1 >= 0)
                return numero1;
            else
                return -numero1;
        }
        public static float ValorAbsoluto(float numero1)
        {
            if (numero1 >= 0)
                return numero1;
            else
                return -numero1;
        }
        public static long ValorAbsoluto(long numero1)
        {
            if (numero1 >= 0)
                return numero1;
            else
                return -numero1;
        }
        public static sbyte ValorAbsoluto(sbyte numero1)
        {
            if (numero1 >= 0)
                return numero1;
            else
                return (sbyte)-numero1;
        }
        #endregion
        #region Factorial
        #region Factorial Recursiva
        public static uint FactorialRecursiva(uint numero2)
        {
            if (numero2 <= 1)
                return 1;
            else if (numero2 > 170)
            {
                throw new StackOverflowException();
            }
            else
                return numero2 * FactorialRecursiva(numero2 - 1);
        }
        public static ulong FactorialRecursiva(ulong numero2)
        {
            if (numero2 <= 1)
                return 1;
            else if (numero2 > 170)
            {
                throw new StackOverflowException();
            }
            else
                return numero2 * FactorialRecursiva(numero2 - 1);
        }
        public static decimal FactorialRecursiva(decimal numero2)
        {
            if (numero2 <= 1)
                return 1;
            else if (numero2 > 170)
            {
                throw new StackOverflowException();
            }
            else
                return numero2 * FactorialRecursiva(numero2 - 1);
        }
        public static double FactorialRecursiva(double numero2)
        {
            try
            {
                if (numero2 <= 1)
                    return 1;
                else if(numero2>170)
                {
                    throw new StackOverflowException();
                }
                else
                    return numero2 * FactorialRecursiva(numero2 - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        public static float FactorialRecursiva(float numero2)
        {
            if (numero2 <= 1)
                return 1;
            else if (numero2 > 170)
            {
                throw new StackOverflowException();
            }
            else
                return numero2 * FactorialRecursiva(numero2 - 1);
        }
        #endregion
        #region Factorial Iterativa
        public static double FactorialIterativa(double numero3)
        {
            try
            {
                double factorial = 1;
                if (numero3 == 0)
                {
                    return 1;
                }
                else
                {
                    for (int i = 1; i <= numero3; i++)
                    {
                        factorial *= i;
                    }
                    return factorial;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        public static decimal FactorialIterativa(decimal numero3)
        {
            decimal factorial = 1;
            if (numero3 == 0)
            {
                return 1;
            }
            else
            {
                for (int i = 1; i <= numero3; i++)
                {
                    factorial *= i;
                }
                return factorial;
            }
        }
        public static long FactorialIterativa(long numero3)
        {
            try
            {
                long factorial = 1;
                if (numero3 == 0)
                {
                    return 1;
                }
                else
                {
                    for (int i = 1; i <= numero3; i++)
                    {
                        factorial *= i;
                    }
                    return factorial;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        public static float FactorialIterativa(float numero3)
        {
            try
            {
                float factorial = 1;
                if (numero3 == 0)
                {
                    return 1;
                }
                else
                {
                    for (int i = 1; i <= numero3; i++)
                    {
                        factorial *= i;
                    }
                    return factorial;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        #endregion
        #endregion
        #region SumaGaussiana
        /// <summary>
        /// Función que devuelve la suma de gauss de un número introducido
        /// </summary>
        /// <param name="nNumeros">El número de gauss a calcular</param>
        /// <returns>devuelve el número de gauus</returns>
        public static long SumaNNumerosRecursiva(long nNumeros)
        {
            try
            {
                if (nNumeros < 1)
                {
                    return 0;
                }
                else if (nNumeros < 2)
                {
                    return 1;
                }
                else if (nNumeros>7000)
                {
                    throw new StackOverflowException();
                }
                else
                    return nNumeros + SumaNNumerosRecursiva(nNumeros - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        public static long SumaNNumerosIterativa(long sumarHasta)
        {
            long resultado = 0;
            for (int i = 1; i <= sumarHasta; i++)
            {
                resultado += i;
            }
            return resultado;
        }
        #endregion
        #region Potencia Recursiva
        public static double PotenciaRecursiva(int numero8, int exponente)
        {
            try
            {
                if (exponente<0||exponente>500||numero8>9000)
                {
                    throw new StackOverflowException();
                }
                else if (exponente == 0) //Caso base: Cuando el exponente es 0 siempre devuelve 1
                {
                    return 1;
                }
                else
                {
                    return numero8 * PotenciaRecursiva(numero8, exponente - 1);
                }
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        #endregion
        #region Fibonacci Recursivo
        public static int FibonacciRecursivo(int numero9) //FUNCIÓN QUE TE DEVUELVE EL VALOR DE LA SUCESIÓN DE FIBONACCI QUE LE INDIQUES
        {
            if (numero9 == 0) //CASO BASE 1: 0
            {
                return 0;
            }
            else if (numero9 == 1) //CASO BASE 2: 1
            {
                return 1;
            }
            else if (numero9>10000)
            {
                throw new StackOverflowException();
                return -1;
            }
            else
            {
                return FibonacciRecursivo(numero9 - 1) + FibonacciRecursivo(numero9 - 2);
            }
        }
        #endregion
        #region ParteDecimal
        public static bool ParteDecimal(double numero, out double resultado)
        {
            string numeroString = numero.ToString();
            if (numeroString.IndexOf(',') != -1)
            {
                string parteDecimal = "0" + numeroString.Substring(numeroString.IndexOf(','));

                if (double.TryParse(parteDecimal, out resultado))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            resultado = 0;
            return false;
        }
        #endregion
        #region PintarArbol
        /// <summary>
        /// Función que te devuelve un arbol junto a más decoración
        /// </summary>
        /// <param name="altura">Indica la altura del arbol (min 5, max 28)</param>
        /// <param name="posicionMensaje">Indica la posición donde se situarán los mensajes para evitar cortar el arbol</param>
        public static void PintaArbol(int altura, int posicionMensaje)
        {
            //CONSTANTES
            const int ALTURA_MINIMA = 5;
            const int ALTURA_MAXIMA = 28;

            //VARIABLES
            int posicionaCursorAux = 2;
            int recorre = 1;
            int posicionTronco = altura - 2;
            int alturaRamas = altura - 1;
            Console.CursorVisible = false;                  //PROPIEDAD QUE OCULTA EL CURSOR

            //PINTAR ARBOL Y DECORADO
            if (altura < ALTURA_MINIMA || altura > ALTURA_MAXIMA) //SI ES MAYOR LA ALTURA INTRODUCIDA A LA MÁXIMA O MENOR A LA MÍNIMA
            {
                Console.CursorLeft = posicionMensaje;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Altura no válida");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else                                            //SI ES VÁLIDO EL NÚMERO PINTARÁ LO INDICADO
            {
                //PINTAR CIELO CIAN
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Clear();

                //PINTAR RAMAS VERDES
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Green;
                for (int i = 1; i <= alturaRamas; i++)        //ESCRIBIR EN CADA RAMA
                {
                    Console.CursorLeft = altura - posicionaCursorAux;
                    for (int j = 1; j <= recorre; j++)   //ESCRIBIR EN CADA POSICIÓN
                    {
                        Console.Write('*');             //ESCRIBIR EL CARACTER PEDIDO
                    }
                    Console.WriteLine("");              //SALTO DE LINEA PARA SIGUIENTE RAMA
                    recorre += 2;                       //AUMENTAMOS EN DOS LA CANTIDAD DE PUNTOS A PINTAR PARA LA PRÓXIMA VEZ
                    posicionaCursorAux++;               //AUMENTAMOS EL CONTADOR DE LAS LINEAS QUE SIRVE PARA POSICIONAR EL CURSOR
                }

                //PINTAR EL TRONCO MARRON (ROJO OSCURO)
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.CursorLeft = posicionTronco;                        //POSICIONO EL TRONCO EN LA PARTE CENTRAL DEL ARBOL
                Console.WriteLine('*');                                     //PINTA EL TRONCO

                //PINTAR SUELO MARRON (ROJO OSCURO)
                Console.ForegroundColor = ConsoleColor.Yellow;              //PARA PINTAR FLORES
                for (int i = 0; i < Console.WindowWidth; i++)               //PINTAR LINEA DE TIERRA     
                {
                    if (i % 2 == 0)                                             //ALTERNAR COLOR DE FLORES
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    else
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("*");                                     //PINTAR FLORES Y SUELO
                }
                //PINTAR FLORES Y SUELO VERDE
                Console.ForegroundColor = ConsoleColor.Yellow;              //PINTAR FLORES
                Console.BackgroundColor = ConsoleColor.DarkGreen;           //PINTAR PRADERA
                for (int i = 0; i < Console.WindowWidth * 30; i++)          //PINTAR 30 LINEAS DE PRADERA
                {
                    if (i % 2 == 0)                                         //ALTERNAR COLOR DE FLORES
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("*");                                     //PINTAR FLORES Y SUELO
                }
                Console.SetCursorPosition(0, 0);                            //POSICIONA AL PRINCIPIO PARA VER CORRECTAMENTE
                Console.CursorVisible = true;                               //RECUPERA LA VISIÓN DEL CURSOR
            }
        }

        /// <summary>
        /// Función que te devuelve un arbol junto a más decoración
        /// </summary>
        /// <param name="altura">Indica la altura del arbol (min 5, max 28)</param>
        public static void PintaArbol(int altura)
        {
            //CONSTANTES
            const int ALTURA_MINIMA = 5;
            const int ALTURA_MAXIMA = 28;

            //VARIABLES
            int posicionaCursorAux = 2;
            int recorre = 1;
            int posicionTronco = altura - 2;
            int alturaRamas = altura - 1;
            Console.CursorVisible = false;                      //PROPIEDAD QUE OCULTA EL CURSOR

            //PINTAR ARBOL Y DECORADO
            if (altura < ALTURA_MINIMA || altura > ALTURA_MAXIMA)   //SI ES MAYOR LA ALTURA INTRODUCIDA A LA MÁXIMA O MENOR A LA MÍNIMA
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Altura no válida");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else                                                    //SI ES VÁLIDO EL NÚMERO PINTARÁ LO INDICADO
            {
                //PINTAR CIELO CIÁN
                Console.BackgroundColor = ConsoleColor.Cyan;    //COLOR CIELO
                Console.Clear();

                //PINTAR RAMAS VERDES
                Console.ForegroundColor = ConsoleColor.Green;   //COLOR RAMAS ARBOL
                Console.BackgroundColor = ConsoleColor.Green;   //COLOR RAMAS ARBOL
                for (int i = 1; i <= alturaRamas; i++)  //ESCRIBIR EN CADA RAMA
                {
                    Console.CursorLeft = altura - posicionaCursorAux;
                    for (int j = 1; j <= recorre; j++)  //ESCRIBIR EN CADA POSICIÓN
                    {
                        Console.Write('*');             //ESCRIBIR EL CARACTER PEDIDO
                    }
                    Console.WriteLine("");              //SALTO DE LINEA PARA SIGUIENTE RAMA
                    recorre += 2;                       //AUMENTAMOS EN DOS LA CANTIDAD DE PUNTOS A PINTAR PARA LA PRÓXIMA VEZ
                    posicionaCursorAux++;               //AUMENTAMOS EL CONTADOR DE LAS LINEAS QUE SIRVE PARA POSICIONAR EL CURSOR
                }

                //PINTAR EL TRONCO MARRON (ROJO OSCURO)
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.CursorLeft = posicionTronco;                        //POSICIONO EL TRONCO EN LA PARTE CENTRAL DEL ARBOL
                Console.WriteLine('*');                                     //PINTA EL TRONCO

                //PINTAR SUELO MARRON (ROJO OSCURO)
                Console.ForegroundColor = ConsoleColor.Yellow;              //PARA PINTAR FLORES
                for (int i = 0; i < Console.WindowWidth; i++)               //PINTAR LINEA DE TIERRA     
                {
                    if (i % 2 == 0)                                         //ALTERNAR COLOR DE FLORES
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    else
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("*");                                     //PINTAR FLORES Y SUELO
                }

                //PINTAR FLORES Y SUELO VERDE
                Console.ForegroundColor = ConsoleColor.Yellow;              //PINTAR FLORES
                Console.BackgroundColor = ConsoleColor.DarkGreen;           //PINTAR PRADERA
                for (int i = 0; i < Console.WindowWidth * 30; i++)          //PINTAR 30 LINEAS DE PRADERA
                {
                    if (i % 2 == 0)                                         //ALTERNAR COLOR DE FLORES
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("*");                                     //PINTAR FLORES Y SUELO
                }
                Console.SetCursorPosition(0, 0);                            //POSICIONA AL PRINCIPIO PARA VER CORRECTAMENTE
                Console.CursorVisible = true;                               //RECUPERA LA VISIÓN DEL CURSOR
                Console.BackgroundColor = ConsoleColor.Black;               //DEVUELVE LOS COLORES ORIGINALES DE LA CONSOLA
                Console.ForegroundColor = ConsoleColor.White;               //DEVUELVE LOS COLORES ORIGINALES DE LA CONSOLA
            }
        }
        #endregion
        #region Menu Areas
        private static void MenuAreaCuadrado() //METODO QUE PINTA EL MENÚ QUE CALCULA EL ÁREA DEL CUADRADO      
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            PintaMarco(0, 0, 80, 20);
            Console.SetCursorPosition(2, 1);
            Console.WriteLine("CALCULAR EL ÁREA DE UN CUADRADO");
            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop + 1);
            Console.Write("Introduce el lado del cuadrado: ");
        }
        private static void MenuAreaRectanguloA()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            PintaMarco(0, 0, 80, 20);
            Console.SetCursorPosition(2, 1);
            Console.WriteLine("CALCULAR EL ÁREA DE UN RECTÁNGULO");
            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop + 1);
            Console.Write("Introduce el lado A del rectángulo: ");
        }
        private static void MenuAreaRectanguloB()
        {
            Console.CursorLeft = Console.CursorLeft + 1;
            Console.Write("Introduce el lado B del rectángulo: ");
        }
        private static void MenuAreaTrianguloA()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            PintaMarco(0, 0, 80, 20);
            Console.SetCursorPosition(2, 1);
            Console.WriteLine("CALCULAR EL ÁREA DE UN TRIÁNGULO");
            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop + 1);
            Console.Write("Introduce la base del triángulo: ");
        }
        private static void MenuAreaTrianguloB()
        {
            Console.CursorLeft = Console.CursorLeft + 1;
            Console.Write("Introduce la altura del triángulo: ");
        }
        #endregion
    }
}