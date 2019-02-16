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
            Coche coche = new Coche();              //Instancia de coche
            Corredor corredor = new Corredor();     //Instancia de corredor
            
            coche.Correr();                         //Ejecutar correr de coche
            corredor.Correr();                      //Ejecutar correr de corredor
            Console.ReadLine();
        }
    }
    /// <summary>
    /// Clase coche que implementa la interfaz ICarrera que obliga a codificar el método Correr()
    /// </summary>
    class Coche : ICarrera
    {
        public void Correr()
        {
            Console.WriteLine("El coche está en marcha.");
        }
    }
    /// <summary>
    /// Clase corredor que implementa la interfaz ICarrera que obliga a codificar el método Correr()
    /// </summary>
    class Corredor : ICarrera
    {
        public void Correr()
        {
            Console.WriteLine("El corredor de fondo está en ello...");
        }
    }
}
