using System;

namespace App_R704_MatematicasFran
{
    /// <summary>
    /// Clase que nos permite calcular una serie de operaciones respecto a los números primos, factoriales, fibonacci y suma de Gauss. Solo acepta números positivos o 0.
    /// </summary>
    class Numeros
    {
        #region CAMPO, PROPIEDAD Y CONSTRUCTOR
        int numero;
        /// <summary>
        /// Propiedad de lectura y escritura del número sobre el que calcular. No se aceptan números negativos.
        /// </summary>
        ///<exception cref="NoNegativeException">Excepción que se produce cuando se intenta introducir u operar con un número negativo. No se permiten números negativos en esta clase.</exception>
        public int Numero
        {
            get { return numero; }
            set
            {
                if (value < 0)
                {
                    throw new NoNegativeException();
                }
                else
                {
                    numero = value;
                }
            }
        }
        /// <summary>
        /// Construir el objeto Numeros sobre el que operar.
        /// </summary>
        /// <param name="numero">Número sobre el que operar.</param>
        public Numeros(int numero)
        {
            Numero = numero;
        }
        #endregion
        #region PRIMOS
        /// <summary>
        /// Comprueba si un número es primo.
        /// </summary>
        /// <param name="numero">Número a comprobar</param>
        /// <returns>Devuelve true si es primo y false si no lo es.</returns>
        /// <exception cref="NoNegativeException">Se produce cuando se intenta calcular si es primo un número no positivo.</exception>
        public static bool EsPrimo(int numero) //Función que recibe un número de tipo uint que devuelve true si es primo y false si no lo es
        {
            int divisor = 2;      //Desde donde comenzamos a comprobar divisibles
            if (numero < 0)
            {
                throw new NoNegativeException();
            }
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
                checked
                {
                    while (numero % divisor != 0 && divisor <= numero / 2)   //Mientras el número no sea divisible y el divisor sea menor a la mitad del número comprobado, incrementa divisor
                    {                                                   //Cuando termine de comprobar las condiciones se evaluará el último valor contemplado como divisor
                        divisor++;
                    }
                }
                return numero % divisor == 0 ? false : true;        //y si el numero entre el divisor es 0 será falso y si no será verdadero
            }
        }
        /// <summary>
        /// Comprueba si un número es primo.
        /// </summary>
        /// <returns>Devuelve true si es primo y false si no lo es.</returns>
        /// <exception cref="NoNegativeException">Se produce cuando se intenta calcular si es primo un número no positivo.</exception>
        public bool EsPrimo() //Función que recibe un número de tipo int que devuelve true si es primo y false si no lo es
        {
            return EsPrimo(numero);
        }
        /// <summary>
        /// Devuelve un array de int con lo n números primos que le indiques
        /// </summary>
        /// <returns>Devuelve array de int con los números que son primos</returns>
        /// <exception cref="NoNegativeException">Se produce cuando se intenta calcular n número de números no positivo.</exception>
        public int[] Primos()    //FUNCIÓN QUE TE DEVUELVE UN ARRAY UINT RELLENO DE TANTOS PRIMOS COMO INDIQUES
        {
            return Primos(this.numero);
        }
        /// <summary>
        /// Devuelve un array de int con lo n números primos que le indiques
        /// </summary>
        /// <param name="numero">Números a obtener de primos</param>
        /// <returns>Devuelve array de int con los números que son primos</returns>
        /// <exception cref="NoNegativeException">Se produce cuando se intenta calcular n número de números no positivo.</exception>
        public static int[] Primos(int numero)    //FUNCIÓN QUE TE DEVUELVE UN ARRAY UINT RELLENO DE TANTOS PRIMOS COMO INDIQUES
        {
            int[] resultado = new int[numero];   //ARRAY QUE VA A GUARDAR LOS RESULTADOS
            int pruebaSiPrimo = 2;                 //VA PROBANDO LOS NÚMEROS SI SON PRIMOS O NO, EMPIEZA DESDE EL 2
            int contadorPrimos = 0;                   //CUENTA LOS PRIMOS INTRODUCIDOS
            if (numero < 0)
            {
                throw new NoNegativeException("No puedes obtener n números primos negativos.");
            }
            while (contadorPrimos < numero)         //MIENTRAS EL CONTADOR DE PRIMOS SEA MENOR O IGUAL AL NÚMERO DE PRIMOS REQUERIDOS
            {
                if (EsPrimo(pruebaSiPrimo))                             //SI ES PRIMO EL NÚMERO PROBADO
                {
                    resultado[contadorPrimos] = pruebaSiPrimo;          //GUARDA EL NÚMERO
                    contadorPrimos++;                                   //AUMENTA EL CONTADOR DE LOS PRIMOS GUARDADOS 
                }
                pruebaSiPrimo++;                                        //PRUEBA OTRO NÚMERO
            }
            return resultado;
        }
        #endregion
        #region FACTORIAL
        /// <summary>
        /// Calcular factorial de forma recursiva
        /// </summary>
        /// <returns>Devuelve el factorial de un número</returns>
        public int FactorialRecursiva()
        {
            return FactorialRecursiva(this.numero);
        }
        /// <summary>
        /// Calcular factorial de forma recursiva
        /// </summary>
        /// <param name="numero">Número sobre el que calcular.</param>
        /// <returns>Devuelve el factorial de un número</returns>
        public static int FactorialRecursiva(int numero)
        {
            checked
            {
                if (numero < 0)
                {
                    throw new NoNegativeException();
                }
                else if (numero <= 1)
                {
                    return 1;
                }
                else if (numero > 5000)
                {
                    throw new StackOverflowException();
                }
                else
                {
                    return numero * FactorialRecursiva(numero - 1);
                }
            }
        }
        /// <summary>
        /// Calcular factorial de forma iterativa.
        /// </summary>
        /// <returns>Devuelve el factorial de un número</returns>
        public int FactorialIterativa()
        {
            int factorial = 1;
            if (numero == 0)
            {
                return 1;
            }
            else
            {
                checked
                {
                    for (int i = 1; i <= numero; i++)
                    {
                        factorial *= i;
                    }
                }
                return factorial;
            }
        }
        /// <summary>
        /// Calcular factorial de forma iterativa.
        /// </summary>
        /// <param name="numero">Número sobre el que calcular.</param>
        /// <returns>Devuelve el factorial de un número</returns>
        public static int FactorialIterativa(int numero)
        {
            int factorial = 1;
            if (numero < 0)
            {
                throw new NoNegativeException();
            }
            if (numero == 0)
            {
                return 1;
            }
            else
            {
                checked
                {
                    for (int i = 1; i <= numero; i++)
                    {
                        factorial *= i;
                    }
                }
                return factorial;
            }
        }
        #endregion
        #region FIBONACCI
        /// <summary>
        /// Calcular Fibonacci de forma recursiva.
        /// </summary>
        /// <returns>Devuelve el número correspondiente a la posición de Fibonacci.</returns>
        public int FibonacciRecursivo()
        {
            return FibonacciRecursivo(numero);
        }
        /// <summary>
        /// Calcular Fibonacci de forma recursiva.
        /// </summary>
        /// <param name="numero">Número sobre el que calcular.</param>
        /// <returns>Devuelve el número correspondiente a la posición de Fibonacci.</returns>
        public static int FibonacciRecursivo(int numero) //FUNCIÓN QUE TE DEVUELVE EL VALOR DE LA SUCESIÓN DE FIBONACCI QUE LE INDIQUES
        {
            if (numero < 0)
            {
                throw new NoNegativeException();
            }
            else if (numero == 0) //CASO BASE 1: 0
            {
                return 0;
            }
            else if (numero == 1) //CASO BASE 2: 1
            {
                return 1;
            }
            else if (numero > 5000)
            {
                throw new StackOverflowException();
            }
            else
            {
                return FibonacciRecursivo(numero - 1) + FibonacciRecursivo(numero - 2);
            }
        }
        /// <summary>
        /// Calcular Fibonacci de forma iterativa.
        /// </summary>
        /// <returns>Devuelve el número correspondiente a la posición de Fibonacci.</returns>
        public int FibonacciIterativo()
        {
            return FibonacciIterativo(this.numero);
        }
        /// <summary>
        /// Calcular Fibonacci de forma iterativa.
        /// </summary>
        /// <param name="numero">Número sobre el que calcular.</param>
        /// <returns>Devuelve el número correspondiente a la posición de Fibonacci.</returns>
        public static int FibonacciIterativo(int numero)
        {
            if (numero < 0)
            {
                throw new NoNegativeException();
            }
            else if (numero == 0)
            {
                return 0;
            }
            else if (numero == 1)
            {
                return 1;
            }
            else
            {
                int primero = 0;
                int segundo = 1;
                int resultado = 0;
                for (int i = 1; i < numero; i++)
                {
                    checked
                    {
                        resultado = 0;
                        resultado += primero;
                        resultado += segundo;
                        primero = segundo;
                        segundo = resultado;
                    }
                }
                return resultado;
            }
        }
        #endregion
        #region SUMA N NÚMEROS
        /// <summary>
        /// Función que devuelve la suma de gauss.
        /// </summary>
        /// <returns>devuelve la suma de gauss.</returns>
        public int SumaNNumerosRecursiva()
        {
            return SumaNNumerosRecursiva(numero);
        }
        /// <summary>
        /// Función que devuelve la suma de gauss de un número introducido
        /// </summary>
        /// <param name="nNumeros">El número de gauss a calcular</param>
        /// <returns>devuelve la suma de gauus</returns>
        public static int SumaNNumerosRecursiva(int nNumeros)
        {
            if (nNumeros < 0)
            {
                throw new NoNegativeException();
            }
            if (nNumeros < 1)
            {
                return 0;
            }
            else if (nNumeros < 2)
            {
                return 1;
            }
            else if (nNumeros > 5000)
            {
                throw new StackOverflowException();
            }
            else
                return nNumeros + SumaNNumerosRecursiva(nNumeros - 1);
        }
        /// <summary>
        /// Función que devuelve la suma de gauss.
        /// </summary>
        /// <returns>devuelve la suma de gauss.</returns>
        public int SumaNNumerosIterativa()
        {
            return SumaNNumerosIterativa(this.numero);
        }
        /// <summary>
        /// Función que devuelve la suma de gauss de un número introducido
        /// </summary>
        /// <param name="nNumeros">El número de gauss a calcular</param>
        /// <returns>devuelve la suma de gauus</returns>
        public static int SumaNNumerosIterativa(int nNumeros)
        {
            int resultado = 0;
            if (nNumeros < 0)
            {
                throw new NoNegativeException();
            }
            for (int i = 1; i <= nNumeros; i++)
            {
                resultado += i;
            }
            return resultado;
        }
        #endregion
        #region EXCEPCIÓN
        /// <summary>
        /// Excepción que se produce cuando se intenta operar o introducir un número negativo donde no es posible.
        /// </summary>
        public class NoNegativeException : Exception
        {
            private string mensajeExcepcion = "ERROR: Las operaciones permitidas no admiten números negativos";

            public override string Message
            { get { return mensajeExcepcion; } }

            public NoNegativeException():base()
            { }

            public NoNegativeException(string message) : base(message)
            { }
        }
        #endregion
    }
}
