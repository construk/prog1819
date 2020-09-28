using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace App_R808_CreaListaFicheroAlumno
{
    class Program
    {
        static void Main(string[] args)
        {
            CrearFichero(@".\texto.txt");
            ListarFichero(@".\texto.txt");
            Console.ReadLine();
        }
        public static void CrearFichero(string fi)
        {
            int cantidad = 50;
            string[] nombre = { "Raul", "Bilal", "Fran", "Manuel", "Ignacio", "Eustaquio", "Eliseo", "Aitor", "Vyacheslav", "Ismael", "Sebas", "Ana", "Muzska", "Rubén", "Alejandro", "Chemita", "Marek" };
            string[] apellido = { "Prieto", "Perez", "González", "Toro", "Roldán", "Moya", "Rivas", "Tilla", "Menta", "García", "Shylyayev", "Bueno", "Turbado", "Sánchez", "Zúñiga" };
            Random rnd = new Random();
            using (FileStream aEscribir = new FileStream(fi, FileMode.Create))
            {
                IFormatter serializador = new BinaryFormatter();
                for (int i = 0; i < cantidad; i++)
                {
                    serializador.Serialize(aEscribir, new Alumno(apellido[rnd.Next(apellido.Length)], nombre[rnd.Next(nombre.Length)]));
                }
            }
        }
        public static void ListarFichero(string fi)
        {
            if (File.Exists(fi))
            {
                try
                {
                    using (FileStream aLeer = new FileStream(fi, FileMode.Open))
                    {
                        BinaryFormatter lectorSerializado = new BinaryFormatter();
                        aLeer.Position = 0;
                        Console.WriteLine();
                        Console.WriteLine(" Nº".PadRight(9) + "Apellido".PadRight(30) + "Nombre".PadRight(30));
                        Console.WriteLine(" =".PadRight(50, '='));
                        int contador = 0;
                        do
                        {
                            Alumno alumno = (Alumno)lectorSerializado.Deserialize(aLeer);
                            Console.WriteLine(" " + (contador + 1).ToString("00000").PadRight(8) + alumno.ToString());
                            contador++;
                        } while (aLeer.Position < aLeer.Length);

                        Console.Write("\n ================ Fin del fichero ================");
                    }
                }
                catch
                {
                    Console.Write("Error inesperado");
                }
            }
        }
    }
}
