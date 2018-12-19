/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ValidarEAN
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Programa con dos funciones que validan el código EAN que le pases como parámetro. Y una de ellas te permite almacenar el valor del dígito de control que le corresponde a dicho código EAN.
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;

namespace App_R608_ValidarEAN
{
    class Ejercicio08
    {
        static void Main(string[] args)
        {
            int digitoControl;
            string ean;
            Console.WriteLine("Introduce nº EAN de 8 o 13 dígitos");
            Console.Write("Número EAN: ");
            ean = Console.ReadLine();
            
            if(ValidarEan(ean, out digitoControl))
                Console.WriteLine("¡El código EAN {0} es válido!", ean);
            else
                Console.WriteLine("¡El código EAN {0} NO es válido!, Dígito de control: {1}", ean,digitoControl);
            
            Console.ReadLine();
        }
        /// <summary>
        /// Función que valida si un número EAN es válido
        /// </summary>
        /// <param name="codigoEan">string que representa el código EAN a comprobar</param>
        /// <returns>Verdadero si el número EAN es válido y falso en caso contrario</returns>
        public static bool ValidarEan(string codigoEan)
        {
                #region Formateo texto
            StringBuilder textoFormateado = new StringBuilder();    //StringBuilder para no tener que crear y destruir constantemente la variable textoFormateado
            int digitoControl;
            try                                                     //Si falla alguna conversión se captura y devuelve un mensaje
            { 
                for(int i = 0; i < codigoEan.Length; i++)           //Recorrer el string recibido y quitar espacios en blanco y guiones si los tiene
                {
                    if(!codigoEan[i].Equals(" ") && !codigoEan[i].Equals("-"))
                    {
                        textoFormateado.Append(codigoEan[i]);
                    }
                }

                if(textoFormateado.Length != 8 && textoFormateado.Length != 13) //Como EAN es de longitud 8 o 13, si no la tiene devuelve falso
                {
                    Console.WriteLine("El código EAN debe de contener una longitud de 8 o 13 caracteres...");
                    return false;
                }
                #endregion
                #region Calculo digito de control
                int digitoFinal = int.Parse(textoFormateado[textoFormateado.Length - 1].ToString());    //Almacena en variable int último dígito para comparar
                int sumaPares = 0;      //Variable para sumar pares
                int sumaImpares = 0;    //Variable para sumar impares

                for(int i = 0; i < textoFormateado.Length - 1; i++) //Recorrer todo texto menos el último caracter (digito control)
                {
                    int numero = int.Parse(textoFormateado[i].ToString());
                    if((i + 1) % 2 == 0)        //Si es par se suma en sumaPares
                        sumaPares += numero;
                    else                        //Si es impar se suma en sumaImpares
                        sumaImpares += numero;
                }

                if(textoFormateado.Length == 8) //Si EAN de 8 dígitos sumaImpares se multiplica por 3
                    sumaImpares *= 3;
                else if(textoFormateado.Length == 13)   //Si EAN es de 13 dígitos sumaPares se multiplica por 3
                    sumaPares *= 3;

                int sumaTotal = sumaPares + sumaImpares;    //sumaTotal --> Se suma sumaPares+sumaImpares
                int resultado = 10 - (sumaTotal % 10);      //resultado --> A 10 se le resta sumaTotal

                if(resultado == 10)                         //Si resultado = 10 --> digitoControl = 0, sino es el resultado
                    digitoControl = 0;
                else
                    digitoControl = resultado;
                #endregion
                #region Devolver resultado
                if (digitoControl == digitoFinal)            //Si digitoControl==digitoFinal devuelve verdadero, sino falso
                    return true;
                else
                    return false;
                #endregion
            }
            catch (FormatException) { Console.WriteLine("Formato de EAN incorrecto"); return false; }       //Lo que hace en caso de que falle alguna conversión
        }

        /// <summary>
        /// Función que valida si un número EAN es válido
        /// </summary>
        /// <param name="codigoEan">string que representa el código EAN a comprobar</param>
        /// <param name="digitoControlReal">Valor del dígito de control que corresponde a dicho código EAN</param>
        /// <returns>Verdadero si el número EAN es válido y falso en caso contrario. Almacena el valor del dígito de control en digitoControlReal, en caso de error almacena -1.</returns>
        public static bool ValidarEan(string codigoEan, out int digitoControlReal)
        {
                #region Formateo texto
            StringBuilder textoFormateado = new StringBuilder();    //StringBuilder para no tener que crear y destruir constantemente la variable textoFormateado
            int digitoControl;
            try                                                     //Si falla alguna conversión se captura y devuelve un mensaje
            {
                for(int i = 0; i < codigoEan.Length; i++)           //Recorrer el string recibido y quitar espacios en blanco y guiones si los tiene
                {
                    if(!codigoEan[i].Equals(" ") && !codigoEan[i].Equals("-"))
                    {
                        textoFormateado.Append(codigoEan[i]);
                    }
                }
                if(textoFormateado.Length != 8 && textoFormateado.Length != 13) //Como EAN es de longitud 8 o 13, si no la tiene devuelve falso y asigna -1 como valor de error a la variable condigoControlReal
                {
                    digitoControlReal = -1;
                    Console.WriteLine("El código EAN debe de contener una longitud de 8 o 13 caracteres...");
                    return false;
                }
                #endregion
                #region Calculo dígito de control
                int digitoFinal = int.Parse(textoFormateado[textoFormateado.Length - 1].ToString()); //Almacena en variable int último dígito para comparar
                int sumaPares = 0;          //Variable para sumar pares
                int sumaImpares = 0;        //Variable para sumar impares

                for (int i = 0; i < textoFormateado.Length - 1; i++)        //Recorrer todo texto menos el último caracter (digito control)
                {
                    int numero = int.Parse(textoFormateado[i].ToString());
                    if((i + 1) % 2 == 0)            //Si es par se suma en sumaPares
                        sumaPares += numero;
                    else                            //Si es impar se suma en sumaImpares
                        sumaImpares += numero;
                }
                if(textoFormateado.Length == 8)         //Si EAN de 8 dígitos sumaImpares se multiplica por 3
                    sumaImpares *= 3;
                else if(textoFormateado.Length == 13)   //Si EAN es de 13 dígitos sumaPares se multiplica por 3
                    sumaPares *= 3;

                int sumaTotal = sumaPares + sumaImpares;    //sumaTotal --> Se suma sumaPares+sumaImpares
                int resultado = 10 - (sumaTotal % 10);      //resultado --> A 10 se le resta sumaTotal

                if (resultado == 10)                        //Si resultado == 10 --> digitoControl = 0, sino es el resultado
                    digitoControl = 0;
                else
                    digitoControl = resultado;
                #endregion
                #region Devolver resultado
                if (digitoControl == digitoFinal)           //Si digitoControl==digitoFinal devuelve verdadero y valor del dígito de control, sino falso y valor del dígito de control que debería ser
                {
                    digitoControlReal = digitoControl;
                    return true;
                }
                else
                {
                    digitoControlReal = digitoControl;
                    return false;
                }
                #endregion
            }
            catch (FormatException) { Console.WriteLine("Formato de EAN incorrecto"); digitoControlReal = -1; return false; }   //Lo que hace en caso de que falle alguna conversión
        }
    }
}
