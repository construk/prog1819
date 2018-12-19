/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ISBN
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:    Programa con dos funciones que comprueban si un código de isbn es válido. Una de ellas también almacena el valor del caracter de control.
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R607_Isbn
{
    class Ejercicio07
    {
        static void Main(string[] args)
        {
            string texto="";
            Console.WriteLine("Introduce un número de ISBN de 10 dígitos y obtendrás si es válido o no ('S' para salir)");
            do
            {
                try { 
                    Console.Write("Introduce ISBN: ");
                    texto = Console.ReadLine();
                    if (!texto.Equals("s")&&!texto.Equals("S"))
                    {
                        if (ValidarIsbn(texto,out char caracterResultado))
                            Console.WriteLine("¡ISBN válido!");
                        else
                        { 
                            Console.WriteLine("ISBN incorrecto...");
                            Console.WriteLine("El dígito de control es "+caracterResultado);
                        }
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }

            } while (!texto.Equals("s")&&!texto.Equals("S"));
            
        }
        /// <summary>
        /// Función que comprueba si un isbn es válido
        /// </summary>
        /// <param name="isbn">string que representa el isbn a comprobar</param>
        /// <returns>Devuelve true si el isbn es válido, sino devuelve false.</returns>
        public static bool ValidarIsbn(string isbn)
        {
            string textoFormateado = FormatearTexto(isbn);        //Texto que solo incluye dígitos y X si hay

            if (textoFormateado.Length != 10)    //Comprobar que el texto formateado cumple las características del isbn de 10 dígitos
            {
                throw new FormatException("\nERROR: El formato del isbn introducido no corresponde con el formato de un isbn: \n9 números + 1 dígito de control --> Dígito control es número o 'X'\n");
            }

            char ultimoCaracter = textoFormateado[textoFormateado.Length - 1];
            int numeroControl = NumeroControl(textoFormateado);                               //Número a comprobar

            char numeroControlCorrespondiente=CaracterControl(numeroControl);


            //Si dígito control coincide --> true, sino false
            if (numeroControlCorrespondiente == ultimoCaracter || (numeroControl == 10 && (ultimoCaracter == 'x' || ultimoCaracter == 'X')))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Función que comprueba si un isbn es válido
        /// </summary>
        /// <param name="isbn">string que representa el isbn</param>
        /// <param name="caracterControlResultado">Caracter de control que corresponde a dicho isbn</param>
        /// <returns>Devuelve true si es válido y almacena el valor del caracter, sino devuelve false y el valor del caracter del dígito de control que le corresponde. Si falla devuelve falso y almacena -1.</returns>
        public static bool ValidarIsbn(string isbn, out char caracterControlResultado)
        {
            string textoFormateado = FormatearTexto(isbn);

            if (textoFormateado.Length != 10)
            {
                throw new FormatException("\nERROR: El formato del isbn introducido no corresponde con el formato de un isbn: \n9 números + 1 dígito de control --> Dígito control es número o 'X'\n");
            }

            char caracterControl = textoFormateado[textoFormateado.Length - 1];
            int numeroControl = NumeroControl(textoFormateado);

            char numeroControlChar=CaracterControl(numeroControl);
            caracterControlResultado = numeroControlChar;

            if (numeroControlChar == caracterControl||(numeroControl==10)&&caracterControl=='x')
                return true;
            else
                return false;
        }

        //Función que formatea el texto dejando solo dígitos y el caracter 'x' o 'X'
        private static string FormatearTexto(string isbn)
        {
            string textoFormateado="";
            for (int i = 0; i < isbn.Length; i++)
                if (char.IsDigit(isbn[i]) || isbn[i] == 'X' || isbn[i] == 'x')
                    textoFormateado += isbn[i];
            return textoFormateado;
        }
        
        //Función que te devuelve el número de control que le corresponde 
        private static int NumeroControl(string textoFormateado)
        {
            int multiplosSuma = 0;
            for (int i = 0; i < textoFormateado.Length - 1; i++)
            {
                int numero = 0;
                try
                {
                    numero = int.Parse(textoFormateado[i].ToString()) * (i + 1);
                }
                catch (FormatException) { Console.WriteLine("\nERROR: El formato del isbn introducido no corresponde con el formato de un isbn: \n9 números + 1 dígito de control --> Dígito control es número o 'X'\n"); }
                multiplosSuma += numero;
            }
            return multiplosSuma%11;
        }
        
        //Función que te devuelve el caracter de control correspondiente a un número de control
        private static char CaracterControl(int numeroControl)
        {
            if (numeroControl != 10)
                return char.Parse(numeroControl.ToString());
            else
                return 'X';
        }
    }
}
