/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ValidarIBAN
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 dic 2018
 *  Descripción:	Programa con varias funciones que sirven para validar un número IBAN. También incluye otras que validan la CC.
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;

namespace App_R610_ValidarIBAN
{
    class Ejercicio10
    {
        static void Main(string[] args)
        {
            string digitoControlIBAN;
            string digitoControlCC;
            string iban;
            try
            {
                Console.WriteLine("Introduce un número de IBAN para comprobar si es válido");
                iban = Console.ReadLine();

                Console.WriteLine("Resultado: " + ValidarIBAN(iban, out digitoControlIBAN, out digitoControlCC) + ". Digito control IBAN: " + digitoControlIBAN + ". Dígito control CC: " + digitoControlCC);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        #region Funciones IBAN
        /// <summary>
        /// Función que comprueba si un número de IBAN es válido
        /// </summary>
        /// <param name="iban">string que representa el número de IBAN</param>
        /// <returns>Devuelve true si es válido el número de IBAN, false en caso contrario</returns>
        public static bool ValidarIBAN(string iban)
        {
            const int TAMANO_IBAN = 24;             //Constante que define el tamaño de un número IBAN
            StringBuilder textoFormateo=new StringBuilder();
            for (int i = 0; i < iban.Length; i++)   //Recorrer string pasado como parámetro y coger solo caracteres y números y almacenarlos en string texto
            {
                if (char.IsDigit(iban[i]) || char.IsLetter(iban[i]))
                {
                    textoFormateo.Append(iban[i]);
                }
            }
            string texto = textoFormateo.ToString();
            if (texto.Length != TAMANO_IBAN)        //Si el tamaño del string resultante fuese distinto al tamaño de un número IBAN saltar excepción
            {
                throw new IlegalIBANException();
            }

            //El número por el que se sustituyen las letras comienza la 'a' como valor 10 y continua aumentando hasta la 'z' (no tiene en cuenta la 'ñ'), controlado minúsculas y mayúsculas
            int valorPrimerCaracter = 0;            
            if (texto[0] >= 'a' && texto[0] <= 'z') 
            {
                valorPrimerCaracter = texto[0] - 'a' + 10;
            }
            else if (texto[0] >= 'A' && texto[0] <= 'Z')
            {
                valorPrimerCaracter = texto[0] - 'A' + 10;
            }
            int valorSegundoCaracter = 0;
            if (texto[1] >= 'a' && texto[1] <= 'z')
            {
                valorSegundoCaracter = texto[1] - 'a' + 10;
            }
            else if (texto[1] >= 'A' && texto[1] <= 'Z')
            {
                valorSegundoCaracter = texto[1] - 'A' + 10;
            }
            //Formato IBAN: AA00 0000 0000 00 0000000000
            //El número sobre el que se va a calcular es: 0000 0000 00 0000000000 AA00, se desplazan los 4 primeros caracteres al final
            //Se sustituyen los caracteres por su valor numérico obtenido anteriormente  y los dígitos de control se sustituyen por 00
            decimal numeroCalculo = decimal.Parse(texto.Substring(4) + valorPrimerCaracter.ToString() + valorSegundoCaracter.ToString() + "00");   //Mover 4 primeros caracteres al final y convertirlo a número entero y sustituir dígitos de control del IBAN por "00"
            int resto = (int)(numeroCalculo % 97);      //Se realiza el módulo 97 a dicho número
            int digitoControlIban = 98 - resto;         //Se le resta a 98 dicho resto obtenido
            string stringDigitoControlIban = string.Format("{0:00}", digitoControlIban);    //Se pone el número obtenido como string con formato de dos números
            string resultado = texto.Substring(0, 2) + stringDigitoControlIban + texto.Substring(4);    //El resultado debe de ser: caracteresPais + digitosControlIBAN+ númeroCC (con sus dígitos de control)
            string controlCC = texto.Substring(4);      //Para controlar los dígitos de control de la cuenta corriente se obtiene Substring del número del IBAN obteniendo solo la parte correspondiente a la CC
                        
            if (resultado.Equals(texto)&& ValidarCC(controlCC))     //Si el resultado es igual al texto formateado en un principio y es válido su número de cuenta corriente devuelve true, sino false
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Función que comprueba si un número de IBAN es válido
        /// </summary>
        /// <param name="iban">string que representa el número de IBAN</param>
        /// <param name="digitoControlIBAN">variable string pasada por referencia que almacena el dígito de control que le corresponde al iban</param>
        /// <returns>Devuelve true si es válido el número de IBAN, false en caso contrario</returns>
        public static bool ValidarIBAN(string iban, out string digitoControlIBAN)
        {
            const int TAMANO_IBAN = 24;             //Constante que define el tamaño de un número IBAN
            StringBuilder textoFormateo = new StringBuilder();
            for (int i = 0; i < iban.Length; i++)   //Recorrer string pasado como parámetro y coger solo caracteres y números y almacenarlos en string texto
            {
                if (char.IsDigit(iban[i]) || char.IsLetter(iban[i]))
                {
                    textoFormateo.Append(iban[i]);
                }
            }
            string texto = textoFormateo.ToString();
            if (texto.Length != TAMANO_IBAN)        //Si el tamaño del string resultante fuese distinto al tamaño de un número IBAN saltar excepción
            {
                throw new IlegalIBANException();
            }

            //El número por el que se sustituyen las letras comienza la 'a' como valor 10 y continua aumentando hasta la 'z' (no tiene en cuenta la 'ñ'), controlado minúsculas y mayúsculas
            int valorPrimerCaracter = 0;
            if (texto[0] >= 'a' && texto[0] <= 'z')
            {
                valorPrimerCaracter = texto[0] - 'a' + 10;
            }
            else if (texto[0] >= 'A' && texto[0] <= 'Z')
            {
                valorPrimerCaracter = texto[0] - 'A' + 10;
            }
            int valorSegundoCaracter = 0;
            if (texto[1] >= 'a' && texto[1] <= 'z')
            {
                valorSegundoCaracter = texto[1] - 'a' + 10;
            }
            else if (texto[1] >= 'A' && texto[1] <= 'Z')
            {
                valorSegundoCaracter = texto[1] - 'A' + 10;
            }
            //Formato IBAN: AA00 0000 0000 00 0000000000
            //El número sobre el que se va a calcular es: 0000 0000 00 0000000000 AA00, se desplazan los 4 primeros caracteres al final
            //Se sustituyen los caracteres por su valor numérico obtenido anteriormente  y los dígitos de control se sustituyen por 00
            decimal numeroCalculo = decimal.Parse(texto.Substring(4) + valorPrimerCaracter.ToString() + valorSegundoCaracter.ToString() + "00");   //Mover 4 primeros caracteres al final y convertirlo a número entero y sustituir dígitos de control del IBAN por "00"
            int resto = (int)(numeroCalculo % 97);      //Se realiza el módulo 97 a dicho número
            int digitoControlIban = 98 - resto;         //Se le resta a 98 dicho resto obtenido
            string stringDigitoControlIban = string.Format("{0:00}", digitoControlIban);    //Se pone el número obtenido como string con formato de dos números
            digitoControlIBAN = stringDigitoControlIban;        //Almacena en la variable pasada por referencia el string que representa el dígito de control que le corresponde
            string resultado = texto.Substring(0, 2) + stringDigitoControlIban + texto.Substring(4);    //El resultado debe de ser: caracteresPais + digitosControlIBAN+ númeroCC (con sus dígitos de control)
            string controlCC = texto.Substring(4);      //Para controlar los dígitos de control de la cuenta corriente se obtiene Substring del número del IBAN obteniendo solo la parte correspondiente a la CC

            if (resultado.Equals(texto) && ValidarCC(controlCC))     //Si el resultado es igual al texto formateado en un principio y es válido su número de cuenta corriente devuelve true, sino false
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Función que comprueba si un número de IBAN es válido
        /// </summary>
        /// <param name="iban">string que representa el número de IBAN</param>
        /// <param name="digitoControlIBAN">>variable string pasada por referencia que almacena el dígito de control que le corresponde al iban</param>
        /// <param name="digitoControlCC">>variable string pasada por referencia que almacena el dígito de control que le corresponde a la cuenta corriente</param>
        /// <returns>Devuelve true si es válido el número de IBAN, false en caso contrario</returns>
        public static bool ValidarIBAN(string iban, out string digitoControlIBAN, out string digitoControlCC)
        {
            const int TAMANO_IBAN = 24;             //Constante que define el tamaño de un número IBAN
            StringBuilder textoFormateo = new StringBuilder();
            for (int i = 0; i < iban.Length; i++)   //Recorrer string pasado como parámetro y coger solo caracteres y números y almacenarlos en string texto
            {
                if (char.IsDigit(iban[i]) || char.IsLetter(iban[i]))
                {
                    textoFormateo.Append(iban[i]);
                }
            }
            string texto = textoFormateo.ToString();
            if (texto.Length != TAMANO_IBAN)        //Si el tamaño del string resultante fuese distinto al tamaño de un número IBAN saltar excepción
            {
                throw new IlegalIBANException();
            }

            //El número por el que se sustituyen las letras comienza la 'a' como valor 10 y continua aumentando hasta la 'z' (no tiene en cuenta la 'ñ'), controlado minúsculas y mayúsculas
            int valorPrimerCaracter = 0;
            if (texto[0] >= 'a' && texto[0] <= 'z')
            {
                valorPrimerCaracter = texto[0] - 'a' + 10;
            }
            else if (texto[0] >= 'A' && texto[0] <= 'Z')
            {
                valorPrimerCaracter = texto[0] - 'A' + 10;
            }
            int valorSegundoCaracter = 0;
            if (texto[1] >= 'a' && texto[1] <= 'z')
            {
                valorSegundoCaracter = texto[1] - 'a' + 10;
            }
            else if (texto[1] >= 'A' && texto[1] <= 'Z')
            {
                valorSegundoCaracter = texto[1] - 'A' + 10;
            }
            //Formato IBAN: AA00 0000 0000 00 0000000000
            //El número sobre el que se va a calcular es: 0000 0000 00 0000000000 AA00, se desplazan los 4 primeros caracteres al final
            //Se sustituyen los caracteres por su valor numérico obtenido anteriormente  y los dígitos de control se sustituyen por 00
            decimal numeroCalculo = decimal.Parse(texto.Substring(4) + valorPrimerCaracter.ToString() + valorSegundoCaracter.ToString() + "00");   //Mover 4 primeros caracteres al final y convertirlo a número entero y sustituir dígitos de control del IBAN por "00"
            int resto = (int)(numeroCalculo % 97);      //Se realiza el módulo 97 a dicho número
            int digitoControlIban = 98 - resto;         //Se le resta a 98 dicho resto obtenido
            string stringDigitoControlIban = string.Format("{0:00}", digitoControlIban);    //Se pone el número obtenido como string con formato de dos números
            digitoControlIBAN = stringDigitoControlIban;        //Almacena en la variable pasada por referencia el string que representa el dígito de control que le corresponde
            string resultado = texto.Substring(0, 2) + stringDigitoControlIban + texto.Substring(4);    //El resultado debe de ser: caracteresPais + digitosControlIBAN+ númeroCC (con sus dígitos de control)
            string controlCC = texto.Substring(4);      //Para controlar los dígitos de control de la cuenta corriente se obtiene Substring del número del IBAN obteniendo solo la parte correspondiente a la CC
            ValidarCC(controlCC, out digitoControlCC);  //Para almacenar los dígitos de control
            if (resultado.Equals(texto) && ValidarCC(controlCC))     //Si el resultado es igual al texto formateado en un principio y es válido su número de cuenta corriente devuelve true, sino false
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Funciones CC
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
        /// <param name="digitoControlCCReal"></param>
        /// <returns>Devuelve true si es válido y false en caso contrario.</returns>
        public static bool ValidarCC(string numeroCuentaCorriente, out string digitoControlCCReal)
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
                digitoControlCCReal = primerDigitoControl.ToString() + segundoDigitoControl.ToString();
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
        #endregion
    }
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
    public class IlegalIBANException : Exception
    {
        public override string Message
        {
            get
            {
                return "El formato de número del IBAN es erroneo. Formato: AA00 0000 0000 00 0000000000";
            }
        }
    }
}