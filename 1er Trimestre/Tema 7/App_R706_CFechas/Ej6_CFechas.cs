/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		CFechas
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 ene 2019
 *  Descripción:	CFechas es una clase que permite gestionar fechas desde el 1/1/0 hasta el 31/12/4000
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R706_CFechas
{
    class Ej6_CFechas
    {
        static void Main(string[] args)
        {
            try
            {
                CFechas fecha = new CFechas(1, 1, 1999);                               
                for (int i = 0; i < 731; i++)
                {
                    Console.WriteLine(fecha);
                    fecha++;
                }               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
