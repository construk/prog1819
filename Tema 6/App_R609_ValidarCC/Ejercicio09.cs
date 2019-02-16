/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ValidarCC
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Programa que tiene dos funciones que permiten comprobar si los dígitos de control de una cuenta corriente son válidos.
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;

namespace App_R609_ValidarCC
{
    public class IlegalCuentaCorrienteException : Exception
    {
        public override string Message
        {
            get
            {
                return "El formato de número de cuenta corriente es erroneo. Formato: 0000 0000 00 0000000000";
            }
        }
    }
    class Ejercicio09
    {
        static void Main(string[] args)
        {
            try
            {
                string digitoControl;
                string introducido = "1234 6456 53 1565565129";
                Console.WriteLine("PROGRAMA QUE COMRPRUEBA QUE UN NÚMERO DE CUENTA CORRIENTE ES VÁLIDO");
                Console.Write("Introduce un número de cuenta corriente: ");
                introducido = Console.ReadLine();
                if (ValidarCC(introducido, out digitoControl))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0} es válido", introducido);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} no es válido, Digito control: {1}", introducido, digitoControl);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Función que comprueba si un número de cuenta corriente es válido o no.
        /// </summary>
        /// <param name="numeroCuentaCorriente">string que representa el número de cuenta, todo lo que no sea un dígito se ignorará</param>
        /// <returns>Devuelve true si es válido y false en caso contrario</returns>
        public static bool ValidarCC(string numeroCuentaCorriente)
        {
            const int TAMANO_ENTIDAD = 4;
            const int TAMANO_SUCURSAL = 4;
            const int DIGITOS_CONTROL = 2;
            const int TAMANO_NUMERO_CUENTA = 10;
            const int TAMANO_CC = TAMANO_ENTIDAD + TAMANO_SUCURSAL + DIGITOS_CONTROL + TAMANO_NUMERO_CUENTA;
            int[] multiplos = new int[] { 4, 8, 5, 10, 9, 7, 3, 6, 1, 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            StringBuilder texto = new StringBuilder(TAMANO_CC + 4);
            try
            {
                #region Formateo texto
                //Dejar solo los dígitos de los que se introduzca
                for (int i = 0; i < numeroCuentaCorriente.Length; i++)
                {
                    if (char.IsDigit(numeroCuentaCorriente[i]))
                    {
                        texto.Append(numeroCuentaCorriente[i]);
                    }
                }
                #endregion

                #region Comprobar texto
                //Si el tamaño es distinto al que debería de tener la CC lanza excepción
                if (texto.Length != TAMANO_CC)
                {
                    throw new IlegalCuentaCorrienteException();
                }
                #endregion

                #region Calculo primer dígito de control
                int primerDigitoControlIntroducido = int.Parse(texto[TAMANO_ENTIDAD + TAMANO_SUCURSAL].ToString()); //Primer dígito de control que introduce el usuario
                int sumaDigitos = 0;
                int restoDivision;
                int primerDigitoControl;                                        //Variable donde se almacena el primer dígito de control
                for (int i = 0; i < (TAMANO_ENTIDAD + TAMANO_SUCURSAL); i++)      //Recorre los primeros 8 dígitos e ir sumando (su contenido por un multiplo específico de su posición)
                {
                    sumaDigitos += int.Parse(texto[i].ToString()) * multiplos[i];
                }
                restoDivision = sumaDigitos % 11;                               //Se obtiene el resto de dividir entre 11 la suma resultante anterior
                primerDigitoControl = 11 - restoDivision;                       //A 11 se le resta dicho resto (restoDivision)
                if (primerDigitoControl == 10)                                    //Si resultado 10-->1, si 11-->0, sino resultado
                {
                    primerDigitoControl = 1;
                }
                else if (primerDigitoControl == 11)
                {
                    primerDigitoControl = 0;
                }
                if (primerDigitoControl != primerDigitoControlIntroducido)        //Si no coincide el primer dígito de control devolver false
                {
                    return false;
                }
                #endregion

                #region Calculo segundo dígito de control
                int segundoDigitoControlIntroducido = int.Parse(texto[TAMANO_ENTIDAD + TAMANO_SUCURSAL + 1].ToString()); //Segundo dígito de control que introduce el usuario
                sumaDigitos = 0;                                                //Establezco valor 0 para reutilizar variable, restoDivisión no es necesario aunque se reutilice
                int segundoDigitoControl;                                       //Variable donde se almacena el segundo dígito de control
                for (int i = TAMANO_ENTIDAD + TAMANO_SUCURSAL + DIGITOS_CONTROL; i < TAMANO_CC; i++)  //Recorre los primeros 8 dígitos e ir sumando (su contenido por un multiplo específico de su posición)
                {
                    sumaDigitos += int.Parse(texto[i].ToString()) * multiplos[i - DIGITOS_CONTROL];
                }
                restoDivision = sumaDigitos % 11;                               //Se obtiene el resto de dividir entre 11 la suma resultante anterior
                segundoDigitoControl = 11 - restoDivision;                       //A 11 se le resta dicho resto (restoDivision)
                if (segundoDigitoControl == 10)                                  //Si resultado 10-->1, si 11-->0, sino resultado
                {
                    segundoDigitoControl = 1;
                }
                else if (segundoDigitoControl == 11)
                {
                    segundoDigitoControl = 0;
                }

                if (segundoDigitoControl != segundoDigitoControlIntroducido)      //Si no coincide el segundo dígito de control devolver false
                {
                    return false;
                }
                #endregion
            }
            catch (FormatException)
            {
                throw new IlegalCuentaCorrienteException();
            }
            return true;        //Devolver true en caso de que no se dé ninguna condición que devuelva false
        }
        /// <summary>
        /// Función que comprueba si un número de cuenta corriente es válido o no. Guarda también el dígito de control que le corresponde a dicha cuenta.
        /// </summary>
        /// <param name="numeroCuentaCorriente">string que representa el número de cuenta, todo lo que no sea un dígito se ignorará</param>
        /// <param name="digitoControlReal"></param>
        /// <returns>Devuelve true si es válido y false en caso contrario.</returns>
        public static bool ValidarCC(string numeroCuentaCorriente, out string digitoControlReal)
        {
            const int TAMANO_ENTIDAD = 4;
            const int TAMANO_SUCURSAL = 4;
            const int DIGITOS_CONTROL = 2;
            const int TAMANO_NUMERO_CUENTA = 10;
            const int TAMANO_CC = TAMANO_ENTIDAD + TAMANO_SUCURSAL + DIGITOS_CONTROL + TAMANO_NUMERO_CUENTA;
            int[] multiplos = new int[] { 4, 8, 5, 10, 9, 7, 3, 6, 1, 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            StringBuilder texto = new StringBuilder(TAMANO_CC + 4);
            try
            {
                #region Formateo texto
                //Dejar solo los dígitos de los que se introduzca
                for (int i = 0; i < numeroCuentaCorriente.Length; i++)
                {
                    if (char.IsDigit(numeroCuentaCorriente[i]))
                    {
                        texto.Append(numeroCuentaCorriente[i]);
                    }
                }
                #endregion

                #region Comprobar texto
                //Si el tamaño es distinto al que debería de tener la CC lanza excepción
                if (texto.Length != TAMANO_CC)
                {
                    throw new IlegalCuentaCorrienteException();
                }
                #endregion

                #region Calculo primer dígito de control
                int primerDigitoControlIntroducido = int.Parse(texto[TAMANO_ENTIDAD + TAMANO_SUCURSAL].ToString()); //Primer dígito de control que introduce el usuario
                int sumaDigitos = 0;
                int restoDivision;
                int primerDigitoControl;                                        //Variable donde se almacena el primer dígito de control
                for (int i = 0; i < (TAMANO_ENTIDAD + TAMANO_SUCURSAL); i++)      //Recorre los primeros 8 dígitos e ir sumando (su contenido por un multiplo específico de su posición)
                {
                    sumaDigitos += int.Parse(texto[i].ToString()) * multiplos[i];
                }
                restoDivision = sumaDigitos % 11;                               //Se obtiene el resto de dividir entre 11 la suma resultante anterior
                primerDigitoControl = 11 - restoDivision;                       //A 11 se le resta dicho resto (restoDivision)
                if (primerDigitoControl == 10)                                    //Si resultado 10-->1, si 11-->0, sino resultado
                {
                    primerDigitoControl = 1;
                }
                else if (primerDigitoControl == 11)
                {
                    primerDigitoControl = 0;
                }
                #endregion

                #region Calculo segundo dígito de control
                int segundoDigitoControlIntroducido = int.Parse(texto[TAMANO_ENTIDAD + TAMANO_SUCURSAL + 1].ToString()); //Segundo dígito de control que introduce el usuario
                sumaDigitos = 0;                                                //Establezco valor 0 para reutilizar variable, restoDivisión no es necesario aunque se reutilice
                int segundoDigitoControl;                                       //Variable donde se almacena el segundo dígito de control
                for (int i = TAMANO_ENTIDAD + TAMANO_SUCURSAL + DIGITOS_CONTROL; i < TAMANO_CC; i++)  //Recorre los primeros 8 dígitos e ir sumando (su contenido por un multiplo específico de su posición)
                {
                    sumaDigitos += int.Parse(texto[i].ToString()) * multiplos[i - DIGITOS_CONTROL];
                }
                restoDivision = sumaDigitos % 11;                               //Se obtiene el resto de dividir entre 11 la suma resultante anterior
                segundoDigitoControl = 11 - restoDivision;                       //A 11 se le resta dicho resto (restoDivision)
                if (segundoDigitoControl == 10)                                  //Si resultado 10-->1, si 11-->0, sino resultado
                {
                    segundoDigitoControl = 1;
                }
                else if (segundoDigitoControl == 11)
                {
                    segundoDigitoControl = 0;
                }
                #endregion


                #region Devolver resultado
                digitoControlReal = primerDigitoControl.ToString() + segundoDigitoControl.ToString();
                if (primerDigitoControl == primerDigitoControlIntroducido && segundoDigitoControl == segundoDigitoControlIntroducido)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion

            }
            catch (FormatException)
            {
                throw new IlegalCuentaCorrienteException();
            }
        }
    }
}