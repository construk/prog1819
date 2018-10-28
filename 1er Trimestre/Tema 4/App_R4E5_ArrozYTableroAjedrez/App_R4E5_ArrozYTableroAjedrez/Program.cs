/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		    ArrozYTableroAjedrez
 *  Autor:		        Francisco J. Gómez Florido
 *  Versión:		    1.0 oct de 2018
 *  Descripción:		El problema del arroz y el tablero de ajedrez 
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R4E5_ArrozYTableroAjedrez
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine("\nHay un total de {0:0,0} granos de arroz",totalGranos);

            Console.ReadLine();
        }
    }
}
