using System;

namespace App_R706_CFechas
{
    /// <summary>
    /// Excepción producida cuando el día no es válido.
    /// </summary>
    public class InvalidDiaException : Exception
    {
        public override string Message
        {
            get { return "El día introducido no es válido."; }
        }
    }
    /// <summary>
    /// Excepción producida cuando el mes no es válido.
    /// </summary>
    public class InvalidMesException : Exception
    {
        public override string Message
        {
            get { return "El mes introducido no es válido."; }
        }
    }
    /// <summary>
    /// Excepción producida cuando el año no es válido.
    /// </summary>
    public class InvalidAnioException : Exception
    {
        public override string Message
        {
            get { return "El año introducido no es válido."; }
        }
    }
    /// <summary>
    /// Clase CFechas que permite gestionar fechas de forma correcta y realizar ciertas comprobaciones con estás.
    /// </summary>
    public class CFechas : IComparable<CFechas>
    {
        #region CAMPOS
        int dia;
        int mes;
        int anio;
        string[] meses = new string[] { "Enero", "Febrero", "Marzo", "Abríl", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        #endregion
        #region PROPIEDADES
        /// <summary>
        /// Dia de la fecha correspondiente.
        /// </summary>
        /// <exception cref="InvalidDiaException">Cuando el día está fuera del rango que le corresponde respecto al mes y el año.</exception>
        public int Dia
        {
            get { return dia; }
            set
            {
                if (value < 1)
                {
                    throw new InvalidDiaException();
                }
                else if (mes == 2 && EsBisiesto(anio))
                {
                    if (value > 29)
                    {
                        throw new InvalidDiaException();
                    }
                    else
                    {
                        dia = value;
                    }
                }
                else if (mes == 2 && !EsBisiesto(anio))
                {
                    if (value > 28)
                    {
                        throw new InvalidDiaException();
                    }
                    else
                    {
                        dia = value;
                    }
                }
                else if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                {
                    if (value > 31)
                    {
                        throw new InvalidDiaException();
                    }
                    else
                    {
                        dia = value;
                    }
                }
                else if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
                {
                    if (value > 30)
                    {
                        throw new InvalidDiaException();
                    }
                    else
                    {
                        dia = value;
                    }
                }
                else
                {
                    dia = value;
                }
            }
        }
        /// <summary>
        /// Mes de la fecha correspondiente.
        /// </summary>
        /// <exception cref="InvalidMesException">Cuando el mes está fuera del rango que le corresponde (1-12).</exception>
        public int Mes
        {
            get { return mes; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new InvalidMesException();
                }
                else
                {
                    mes = value;
                }
            }
        }
        /// <summary>
        /// Año de la fecha correspondiente.
        /// </summary>
        /// <exception cref="InvalidAnioException">Cuando el año está fuera del rango permitido (0-4000 incluidos).</exception>
        public int Anio
        {
            get { return anio; }
            set
            {
                if (value < 0 || value > 4000)
                {
                    throw new InvalidAnioException();
                }
                else
                {
                    anio = value;
                }
            }
        }
        /// <summary>
        /// Propiedad que es true cuando el año de la fecha correspondiente es bisiesto, y false en caso contrario.
        /// </summary>
        public bool EsBisiestoAnio
        {
            get { return EsBisiesto(Anio); }
        }
        #endregion
        #region CONSTRUCTORES
        /// <summary>
        /// Constructor CFechas vacio. Por defecto 1/1/2000.
        /// </summary>
        public CFechas()
        {
            Dia = 1;
            Mes = 1;
            Anio = 2000;
        }
        /// <summary>
        /// Constructor CFechas.
        /// </summary>
        /// <param name="dia">Día de la fecha.</param>
        /// <param name="mes">Més de la fecha.</param>
        /// <param name="anio">Año de la fecha.</param>
        public CFechas(int dia, int mes, int anio)
        {
            Anio = anio;
            Mes = mes;
            Dia = dia;            
        }
        #endregion
        #region MÉTODOS
        #region ESTÁTICOS
        public static bool EsBisiesto(int anio) //Un año es bisiesto si es divisible entre 4, pero que no sea divisible entre 100, pero si entre 400.
        {
            if (anio % 4 == 0 && (anio % 400 == 0||anio%100!=0))
                return true;
            else if (anio % 4 == 0 && anio % 100 == 0)
                return false;
            else if (anio % 4 == 0)
                return true;
            else
                return false;
        }
        public static void SumarFecha(CFechas a, int numeroDias)
        {
            for (int i = 0; i < numeroDias; i++)
            {
                try
                {
                    a.Dia++;
                }
                catch (InvalidDiaException)
                {
                    try
                    {
                        a.Dia = 1;
                        a.Mes++;
                    }
                    catch (InvalidMesException)
                    {
                        try
                        {
                            a.Anio++;
                            a.Mes = 1;
                        }
                        catch (InvalidAnioException)
                        {
                            a.Dia = 31;
                            a.Mes = 12;
                            Console.WriteLine("Se ha alcanzado la fecha máxima posible.");
                        }
                    }
                }
            }
        }
        public static void RestarFecha(CFechas a, int numeroDias)
        {
            for (int i = 0; i < numeroDias; i++)
            {
                try
                {
                    a.Dia--;
                }
                catch (InvalidDiaException)
                {
                    try
                    {
                        a.Mes--;

                        if (a.Mes == 2 && EsBisiesto(a.Anio))
                        {
                            a.Dia = 29;
                        }
                        else if (a.Mes == 2 && !EsBisiesto(a.Anio))
                        {
                            a.Dia = 28;
                        }
                        else if (a.Mes == 1 || a.Mes == 3 || a.Mes == 5 || a.Mes == 7 || a.Mes == 8 || a.Mes == 10 || a.Mes == 12)
                        {
                            a.Dia = 31;
                        }
                        else if (a.Mes == 4 || a.Mes == 6 || a.Mes == 9 || a.Mes == 11)
                        {
                            a.Dia = 30;
                        }
                    }
                    catch (InvalidMesException)
                    {
                        try
                        {
                            a.Anio--;
                            a.Mes = 12;
                            a.Dia = 31;
                        }
                        catch (InvalidAnioException)
                        {
                            a.Dia = 1;
                            a.Mes = 1;
                            a.Anio = 0;
                            Console.WriteLine("Se ha alcanzado la fecha mínima posible.");
                        }
                    }
                }
            }
        }
        #endregion
        #region DE INSTANCIA
        /// <summary>
        /// Sumar fecha dado una cantidad de días.
        /// </summary>
        /// <param name="numeroDias">Número de días a sumar.</param>
        public void SumarFecha(int numeroDias)
        {
            for (int i = 0; i < numeroDias; i++)
            {
                try
                {
                    Dia++;
                }
                catch (InvalidDiaException)
                {
                    try
                    {
                        Mes++;
                        Dia = 1;
                    }
                    catch (InvalidMesException)
                    {
                        try
                        {
                            Anio++;
                            Mes = 1;
                        }
                        catch (InvalidAnioException)
                        {
                            Dia = 31;
                            Mes = 12;
                            Console.WriteLine("Se ha alcanzado la fecha máxima posible.");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Sumar fecha dado una cantidad de días y meses.
        /// </summary>
        /// <param name="numeroDias">Número de días a sumar.</param>
        /// <param name="numeroMeses">Número de meses a sumar.</param>
        public void SumarFecha(int numeroDias, int numeroMeses)
        {
            SumarFecha(numeroDias);
            for (int i = 0; i < numeroMeses; i++)
            {
                try
                {
                    Mes++;
                }
                catch (InvalidMesException)
                {
                    try
                    {
                        Anio++;
                        Mes = 1;
                    }
                    catch (InvalidAnioException)
                    {
                        Dia = 31;
                        Mes = 12;
                        Console.WriteLine("Se ha alcanzado la fecha máxima posible.");
                    }
                }
            }
        }
        /// <summary>
        /// Sumar fecha dado una cantidad de días, meses y años.
        /// </summary>
        /// <param name="numeroDias">Número de días a sumar.</param>
        /// <param name="numeroMeses">Número de meses a sumar.</param>
        /// <param name="numeroAnios">Número de años a sumar.</param>
        public void SumarFecha(int numeroDias, int numeroMeses, int numeroAnios)
        {
            SumarFecha(numeroDias, numeroMeses);
            for (int i = 0; i < numeroAnios; i++)
            {
                try
                {
                    Anio++;
                }
                catch (InvalidAnioException)
                {
                    Dia = 31;
                    Mes = 12;
                    Console.WriteLine("Se ha alcanzado la fecha máxima posible.");
                }
            }
        }
        /// <summary>
        /// Restar fecha dado una cantidad de días.
        /// </summary>
        /// <param name="numeroDias">Número de días a restar.</param>
        public void RestarFecha(int numeroDias)
        {
            for (int i = 0; i < numeroDias; i++)
            {
                try
                {
                    Dia--;
                }
                catch (InvalidDiaException)
                {
                    try
                    {
                        Mes--;

                        if (Mes == 2 && EsBisiesto(Anio))
                        {
                            Dia = 29;
                        }
                        else if (Mes == 2 && !EsBisiesto(Anio))
                        {
                            Dia = 28;
                        }
                        else if (Mes == 1 || Mes == 3 || Mes == 5 || Mes == 7 || Mes == 8 || Mes == 10 || Mes == 12)
                        {
                            Dia = 31;
                        }
                        else if (Mes == 4 || Mes == 6 || Mes == 9 || Mes == 11)
                        {
                            Dia = 30;
                        }
                    }
                    catch (InvalidMesException)
                    {
                        try
                        {
                            Anio--;
                            Mes = 12;
                            Dia = 31;
                        }
                        catch (InvalidAnioException)
                        {
                            Dia = 1;
                            Mes = 1;
                            Anio = 0;
                            Console.WriteLine("Se ha alcanzado la fecha mínima posible.");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Cadena de texto con formato de fecha corta. DD/MM/AA.
        /// </summary>
        /// <returns>Devuelve cadena de texto con formato fecha corta.</returns>
        public string ToShortDateString()
        {
            return Dia.ToString() + "/" + Mes.ToString() + "/" + Anio.ToString();
        }
        /// <summary>
        /// Compara dos fechas.
        /// </summary>
        /// <param name="other">Otra fecha sobre la que comparar</param>
        /// <returns>0 si son iguales, positivo o negativo en caso contrario.</returns>
        public int CompareTo(CFechas other)
        {
            int compare;
            compare = Anio - other.Anio;
            if (compare == 0)
            {
                compare = Mes - other.Mes;
                if (compare == 0)
                {
                    compare = Dia - other.Dia;
                }
            }
            return compare;
        }
        #region SOBREESCRITOS
        /// <summary>
        /// Devuelve cadena de texto con fecha en formato largo DD de nombreMes de AAAA.
        /// </summary>
        /// <returns>Devuelve cadena de texto con fecha en formato largo DD de nombreMes de AAAA.</returns>
        public override string ToString()
        {
            return Dia.ToString() + " de " + meses[Mes - 1] + " de " + Anio.ToString();
        }
        /// <summary>
        /// Sirve para comparar dos fechas.
        /// </summary>
        /// <param name="obj">Fecha a comparar.</param>
        /// <returns>Devuelve true en caso de que sean iguales, y false en caso contrario.</returns>
        public override bool Equals(object obj)
        {
            var fechas = obj as CFechas;
            return fechas != null &&
                   dia == fechas.dia &&
                   mes == fechas.mes &&
                   anio == fechas.anio;
        }
        /// <summary>
        /// Devuelve valor HashCode para tabla hash.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return int.Parse(dia.ToString() + mes.ToString() + anio.ToString()).GetHashCode();
        }
        #endregion
        #endregion
        #endregion
        #region SOBRECARGA OPERADORES
        /// <summary>
        /// Permite comparar dos fechas con el operador ==
        /// </summary>
        /// <param name="a">Fecha a</param>
        /// <param name="b">Fecha b</param>
        /// <returns>Devuelve true si son iguales y false en caso contrario.</returns>
        public static bool operator ==(CFechas a, CFechas b)
        {
            return a!=null&&b!=null&&a.Anio == b.Anio && a.Mes == b.Mes && a.Dia == b.Dia;
        }
        /// <summary>
        /// Permite comparar dos fechas con el operador !=
        /// </summary>
        /// <param name="a">fecha a</param>
        /// <param name="b">fecha b</param>
        /// <returns>Devuelve true si son distintas y false en caso contrario</returns>
        public static bool operator !=(CFechas a, CFechas b)
        {
            return a is null||b is null||a.Anio != b.Anio || a.Mes != b.Mes || a.Dia != b.Dia;
        }
        /// <summary>
        /// Permite comparar dos fechas con el operador <
        /// </summary>
        /// <param name="a">fecha a</param>
        /// <param name="b">fecha b</param>
        /// <returns>Devuelve true si la fecha a es menor que la fecha b, en caso contrario false.</returns>
        public static bool operator <(CFechas a, CFechas b)
        {
            if (a.Anio < b.Anio)
            {
                return true;
            }
            else if (a.Anio > b.Anio)
            {
                return false;
            }

            if (a.Mes < b.Mes)
            {
                return true;
            }
            else if (a.Mes > b.Mes)
            {
                return false;
            }

            if (a.Dia < b.Dia)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Permite comparar dos fechas con el operador >
        /// </summary>
        /// <param name="a">fecha a</param>
        /// <param name="b">fecha b</param>
        /// <returns>Devuelve true en caso de la fecha a sea mayor que la fecha b, en caso contrario false.</returns>
        public static bool operator >(CFechas a, CFechas b)
        {
            if (a.Anio > b.Anio)
            {
                return true;
            }
            else if (a.Anio < b.Anio)
            {
                return false;
            }

            if (a.Mes > b.Mes)
            {
                return true;
            }
            else if (a.Mes < b.Mes)
            {
                return false;
            }

            if (a.Dia > b.Dia)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Permite comparar dos fechas con el operador <=
        /// </summary>
        /// <param name="a">fecha a</param>
        /// <param name="b">fecha b</param>
        /// <returns>Devuelve true en caso de la fecha a sea menor o igual que la fecha b, en caso contrario false.</returns>
        public static bool operator <=(CFechas a, CFechas b)
        {
            return a == b || a < b;
        }
        /// <summary>
        /// Permite comparar dos fechas con el operador >=
        /// </summary>
        /// <param name="a">fecha a</param>
        /// <param name="b">fecha b</param>
        /// <returns>Devuelve true en caso de la fecha a sea mayor o igual que la fecha b, en caso contrario false.</returns>
        public static bool operator >=(CFechas a, CFechas b)
        {
            return a == b || a > b;
        }
        /// <summary>
        /// Permite aumentar las fechas mediante el operador ++
        /// </summary>
        /// <param name="a">fecha sobre la que va a realizar el incremento</param>
        /// <returns>Devuelve el objeto CFechas con un día más.</returns>
        public static CFechas operator ++(CFechas a)
        {
            SumarFecha(a, 1);
            return a;
        }
        /// <summary>
        /// Permite disminuir las fechas mediante el operador --
        /// </summary>
        /// <param name="a">fecha sobre la que va a realizar el decremento</param>
        /// <returns>Devuelve el objeto CFechas con un día menos.</returns>
        public static CFechas operator --(CFechas a)
        {
            RestarFecha(a, 1);
            return a;
        }
        #endregion
    }
}
