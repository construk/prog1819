/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ImprimeNumeroLetras
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Programa con funciones que sirven para escribir números entre 0 y 999.999
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R611_ImprimeNumeroLetras
{
    class Ejercicio11
    {
        static void Main(string[] args)
        {
            string numero;
            Console.WriteLine("Escribe un número y obtendrás dicho número convertido en palabras ('s' para salir)");
            do
            {
                Console.Write("Introduce número: ");
                numero = Console.ReadLine();
                if (!numero.Equals("s"))
                {
                    Console.WriteLine(PintaNumerosLetras(numero));
                }
            } while (!numero.Equals("s"));
            /*
            for (int i = 0; i < 1000000; i++)
            {
                Console.WriteLine(PintaNumerosLetras(i.ToString()));
            }
            */
        }
        /// <summary>
        /// Función que escribe los números con palabras del 0 al 15
        /// </summary>
        /// <param name="numero">string que representa un número</param>
        /// <returns>Devuelve el número como string escrito con palabras, en caso de error devuelve ¡¡¡¡ERROR!!!!</returns>
        private static string Unidades(string numero)
        {
            #region Rango valores
            if (int.Parse(numero) == 0)
            {
                return "CERO";
            }
            else if (int.Parse(numero) == 1)
            {
                return "UNO";
            }
            else if (int.Parse(numero) == 2)
            {
                return "DOS";
            }
            else if (int.Parse(numero) == 3)
            {
                return "TRES";
            }
            else if (int.Parse(numero) == 4)
            {
                return "CUATRO";
            }
            else if (int.Parse(numero) == 5)
            {
                return "CINCO";
            }
            else if (int.Parse(numero) == 6)
            {
                return "SEIS";
            }
            else if (int.Parse(numero) == 7)
            {
                return "SIETE";
            }
            else if (int.Parse(numero) == 8)
            {
                return "OCHO";
            }
            else if (int.Parse(numero) == 9)
            {
                return "NUEVE";
            }
            else if (int.Parse(numero) == 10)
            {
                return "DIEZ";
            }
            else if (int.Parse(numero) == 11)
            {
                return "ONCE";
            }
            else if (int.Parse(numero) == 12)
            {
                return "DOCE";
            }
            else if (int.Parse(numero) == 13)
            {
                return "TRECE";
            }
            else if (int.Parse(numero) == 14)
            {
                return "CATORCE";
            }
            else if (int.Parse(numero) == 15)
            {
                return "QUINCE";
            }
            #endregion

            return "¡¡¡¡¡¡¡ERROR!!!!!!";
        }
        /// <summary>
        /// Función que escribe los números con palabras del 0 al 99
        /// </summary>
        /// <param name="numero">string que representa un número</param>
        /// <returns>Devuelve el número como string escrito con palabras, en caso de error devuelve ¡¡¡¡ERROR!!!!</returns>
        private static string Decenas(string numero)
        {
            #region Valores menores que decenas
            if (int.Parse(numero) < 16)
            {
                return Unidades(int.Parse(numero).ToString());
            }
            #endregion
            #region Valores sin unidades
            switch (int.Parse(numero))
            {
                case 20:
                    return "VEINTE";
                case 30:
                    return "TREINTA";
                case 40:
                    return "CUARENTA";
                case 50:
                    return "CINCUENTA";
                case 60:
                    return "SESENTA";
                case 70:
                    return "SETENTA";
                case 80:
                    return "OCHENTA";
                case 90:
                    return "NOVENTA";
            }
            #endregion
            #region Valores con unidades
            if (int.Parse(numero) < 20)
            {
                return "DIECI" + Unidades(numero.Substring(1));
            }
            else if (int.Parse(numero) < 30)
            {
                return "VEINTI" + Unidades(int.Parse(numero.Substring(1)).ToString());
            }
            else if (int.Parse(numero) < 40)
            {
                return "TREINTA Y " + Unidades((int.Parse(numero) % 10).ToString());
            }
            else if (int.Parse(numero) < 50)
            {
                return "CUARENTA Y " + Unidades((int.Parse(numero) % 10).ToString());
            }
            else if (int.Parse(numero) < 60)
            {
                return "CINCUENTA Y " + Unidades((int.Parse(numero) % 10).ToString());
            }
            else if (int.Parse(numero) < 70)
            {
                return "SESENTA Y " + Unidades((int.Parse(numero) % 10).ToString());
            }
            else if (int.Parse(numero) < 80)
            {
                return "SETENTA Y " + Unidades((int.Parse(numero) % 10).ToString());
            }
            else if (int.Parse(numero) < 90)
            {
                return "OCHENTA Y " + Unidades((int.Parse(numero) % 10).ToString());
            }
            else
            {
                return "NOVENTA Y " + Unidades((int.Parse(numero) % 10).ToString());
            }
            #endregion
        }
        /// <summary>
        /// Función que escribe los números con palabras del 1 al 999
        /// </summary>
        /// <param name="numero">string que representa un número</param>
        /// <returns>Devuelve el número como string escrito con palabras, en caso de error devuelve ¡¡¡¡ERROR!!!!</returns>
        private static string Centenas(string numero)
        {
            #region Sin decenas ni unidades
            if (int.Parse(numero) == 0)
            {
                return "";
            }
            #endregion
            #region Valores menores que decenas pero distinto de 0
            else if (int.Parse(numero) < 100)
            {
                return Decenas((int.Parse(numero) % 100).ToString());
            }
            #endregion
            #region Valores sin decenas ni unidades
            switch (int.Parse(numero))
            {
                case 100:
                    return "CIEN";
                case 200:
                    return "DOSCIENTOS";
                case 300:
                    return "TRESCIENTOS";
                case 400:
                    return "CUATROCIENTOS";
                case 500:
                    return "QUINIENTOS";
                case 600:
                    return "SEISCIENTOS";
                case 700:
                    return "SETENCIENTOS";
                case 800:
                    return "OCHOCIENTOS";
                case 900:
                    return "NOVECIENTOS";
            }
            #endregion
            #region Valores con decenas y unidades
            if (int.Parse(numero) < 200)
            {
                return "CIENTO " + Decenas(numero.Substring(1));
            }
            else if (int.Parse(numero) < 300)
            {
                return "DOSCIENTOS " + Decenas(numero.Substring(1));
            }
            else if (int.Parse(numero) < 400)
            {
                return "TRESCIENTOS " + Decenas(numero.Substring(1));
            }
            else if (int.Parse(numero) < 500)
            {
                return "CUATROCIENTOS " + Decenas(numero.Substring(1));
            }
            else if (int.Parse(numero) < 600)
            {
                return "QUINIENTOS " + Decenas(numero.Substring(1));
            }
            else if (int.Parse(numero) < 700)
            {
                return "SEISCIENTOS " + Decenas(numero.Substring(1));
            }
            else if (int.Parse(numero) < 800)
            {
                return "SETECIENTOS " + Decenas(numero.Substring(1));
            }
            else if (int.Parse(numero) < 900)
            {
                return "OCHOCIENTOS " + Decenas(numero.Substring(1));
            }
            else
            {
                return "NOVECIENTOS " + Decenas(numero.Substring(1));
            }
            #endregion
        }
        /// <summary>
        /// Función que escribe los números con palabras del 1 al 999.999
        /// </summary>
        /// <param name="numero">string que representa un número</param>
        /// <returns>Devuelve el número como string escrito con palabras, en caso de error devuelve ¡¡¡¡ERROR!!!!</returns>
        private static string Millares(string numero)
        {
            #region Valores menores que millares
            if (int.Parse(numero) < 1000)
            {
                return Centenas(int.Parse(numero).ToString());
            }
            #endregion
            #region Valores entre 1.000 y 9.999
            if (numero.Length == 4)
            {
                if (numero.Equals("0000"))
                {
                    return "";
                }
                else if (int.Parse(numero) < 2000)
                {
                    return "MIL " + Centenas(numero.Substring(1));
                }
                else if (int.Parse(numero) < 3000)
                {
                    return "DOS MIL " + Centenas(numero.Substring(1));
                }
                else if (int.Parse(numero) < 4000)
                {
                    return "TRES MIL " + Centenas(numero.Substring(1));
                }
                else if (int.Parse(numero) < 5000)
                {
                    return "CUATRO MIL " + Centenas(numero.Substring(1));
                }
                else if (int.Parse(numero) < 6000)
                {
                    return "CINCO MIL " + Centenas(numero.Substring(1));
                }
                else if (int.Parse(numero) < 7000)
                {
                    return "SEIS MIL " + Centenas(numero.Substring(1));
                }
                else if (int.Parse(numero) < 8000)
                {
                    return "SIETE MIL " + Centenas(numero.Substring(1));
                }
                else if (int.Parse(numero) < 9000)
                {
                    return "OCHO MIL " + Centenas(numero.Substring(1));
                }
                else
                {
                    return "NUEVE MIL " + Centenas(numero.Substring(1));
                }
            }
            #endregion
            #region Valores entre 10.000 y 99.999
            else if (numero.Length == 5)
            {
                if (numero.Equals("00000"))
                {
                    return "";
                }
                return Decenas(numero.Substring(0, 2)) + " MIL " + Millares(int.Parse(numero).ToString().Substring(2));
            }
            #endregion
            #region Valores entre 100.000 y 999.999
            else if (numero.Length == 6)
            {
                return Centenas(numero.Substring(0, 3)) + " MIL " + Centenas(numero.Substring(3));
            }
            #endregion
            #region Cualquier otro valor
            else
            {
                return "¡¡¡¡¡ERROR!!!!!";
            }
            #endregion
        }
        /// <summary>
        /// Función que escribe con palabras los números entre 0 y 999.999
        /// </summary>
        /// <param name="numero">string que representa un número</param>
        /// <returns>Devuelve el número como string escrito con palabras, en caso de error devuelve ¡¡¡¡ERROR!!!!</returns>
        public static string PintaNumerosLetras(string numero)
        {
            try
            {
                if (int.Parse(numero) == 0)
                {
                    return Unidades(numero);
                }
                else
                {
                    numero = numero.TrimStart('0');
                    return Millares(numero);
                }
            }
            catch (Exception)
            { return "Error: El número introducido no es válido"; }
        }
    }
}
