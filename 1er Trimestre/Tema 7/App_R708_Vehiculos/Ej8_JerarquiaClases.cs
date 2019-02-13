/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		Vehiculos
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 ene 2019
 *  Descripción:	Programa con una una jerarquia de clases que parten de Vehículo.
-------------------------------------------------------------------------------------------------------------*/
using System;

namespace App_R708_Vehiculos
{
    class Ej8_JerarquiaClases
    {
        static void Main(string[] args)
        {
            //Vehiculo vehiculo = new Vehiculo();       CLASE ABSTRACTA: NO SE PUEDE INSTANCIAR
            Coche alfa = new Coche("Alfa Romeo", "Azul plateado", TipoTraccion.todoTerreno, 260,EstadoCoche.parado);
            Coche audi = new Coche("Audi", "Negro", TipoTraccion.trasera, 280, EstadoCoche.marchando);
            Moto moto = new Moto("KTM", "Naranja", TipoCombustibleMoto.mezcla,2);
            Moto moto2 = new Moto("Yamaha", "Verde pistacho", TipoCombustibleMoto.normal,15);
            //Bicicleta bici = new Bicicleta();         CLASE ABSTRACTA: NO SE PUEDE INSTANCIAR
            BiciMontana biciMontana = new BiciMontana("Mountain Bike", "Plata", TipoAmortiguacionBici.Profesional, "Pro Racing", 58.4,new DateTime(2018,12,15),400.35);
            BiciMontana biciMontana2 = new BiciMontana("Mountain Bike Pro", "Plata", TipoAmortiguacionBici.Competicion, "Master Racing", 62.2, new DateTime(2018, 12, 17), 700.73);
            BiciMontana biciMontana3 = new BiciMontana("Mountain Bike Slide", "Roja", TipoAmortiguacionBici.Amateur, "Amateur", 55.9, new DateTime(2018, 12, 15), 1000.95);
            BiciPaseo biciPaseo = new BiciPaseo("Electric City", "Black", 2, "City", "Tesla motors", new DateTime(2018, 12, 15), 200.35);
            BiciPaseo biciPaseo2 = new BiciPaseo("Mi Bici", "Black", 1, "Junior Sport", "Xiaomi", new DateTime(2018, 12, 15), 170.35);

            Console.WriteLine(alfa.ToString());
            Console.WriteLine();
            Console.WriteLine(audi.ToString());
            Console.WriteLine();
            Console.WriteLine(moto.ToString());
            Console.WriteLine();
            Console.WriteLine(moto2.ToString());
            Console.WriteLine();
            Console.WriteLine(biciMontana.ToString());
            Console.WriteLine();
            Console.WriteLine(biciMontana2.ToString());
            Console.WriteLine();
            Console.WriteLine(biciMontana3.ToString());
            Console.WriteLine();
            Console.WriteLine(biciPaseo.ToString());
            Console.WriteLine();
            Console.WriteLine(biciPaseo2.ToString());
            Console.ReadLine();
        }
    }
}
