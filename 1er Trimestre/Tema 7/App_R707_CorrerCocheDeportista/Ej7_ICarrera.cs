/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ICarrera, Corredor y Coche
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 ene 2019
 *  Descripción:	Proyecto con dos clases que implementan la inferfaz ICarrera con el método Correr
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R707_CorrerCocheDeportista
{
    class Ej7_ICarrera
    {
        static void Main(string[] args)
        {
            Coche coche = new Coche();
            Corredor corredor = new Corredor();
            
            coche.Correr();
            corredor.Correr();
            Console.ReadLine();
        }
    }
    class Coche : ICarrera
    {
        public void Correr()
        {
            Console.WriteLine("El coche está en marcha.");
        }
    }
    class Corredor : ICarrera
    {
        public void Correr()
        {
            Console.WriteLine("El corredor de fondo está en ello...");
        }
    }
}
