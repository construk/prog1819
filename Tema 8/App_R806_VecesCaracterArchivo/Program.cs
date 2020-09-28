using System;
using System.IO;


namespace App_R806_VecesCaracterArchivo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Introduce una ruta y un caracter y obtendrás el número de apariciones de dicho caracter");
                Console.Write("Introduce una ruta de un archivo: ");
                var ruta = Console.ReadLine();
                if (ruta.Contains("\""))    //Si la ruta contiene comillas (cuando arrastras el fichero a la consola para evitar copiar la ruta o introduciendo ruta con espacios)
                {
                    ruta=ruta.Remove(0,1);
                    ruta = ruta.Remove(ruta.Length - 1,1);
                }
                if (!File.Exists(@ruta))    //Si no existe el fichero termina la ejecución del programa.
                {
                    Console.Write("El archivo especificado no existe.");
                    return;
                }

                Console.Write("Introduce el caracter que deseas contar: "); //Introducir un caracter válido
                string auxiliar = Console.ReadLine();
                char caracter;
                
                while (!char.TryParse(auxiliar, out caracter))              //Sino vuelve a preguntar
                {
                    Console.Write("Introduce un caracter válido: ");
                    auxiliar = Console.ReadLine();
                }

                int nApariciones = NVecesCaracter(caracter, @ruta);         //Número de apariciones del caracter a buscar y mostrar mensaje.
                if (nApariciones==0)
                {
                    Console.WriteLine("No aparece ninguna vez el caracter: "+caracter);
                }
                else
                {
                    Console.WriteLine("El caracter {0} aparece {1} veces",caracter,nApariciones);
                }
            }
            catch
            {
                Console.WriteLine("Error no contemplado.");
            }
            finally
            {
                Console.ReadLine();
            }
        }
        public static int NVecesCaracter(char caracter, string ruta)
        {
            try
            {
                if(File.Exists(@ruta))
                {
                    int contador = 0;
                    FileStream fichero = new FileStream(@ruta, FileMode.Open);
                    StreamReader lector = new StreamReader(fichero);
                    int caracterLeidoInt;
                    char caracterLeido;
                    while((caracterLeidoInt = lector.Read()) != -1)
                    {
                        caracterLeido = (char)caracterLeidoInt;

                        if(caracterLeido == caracter)
                        {
                            contador++;
                        }
                    }
                    return contador;
                }
                else
                {
                    return -1;
                }
            }
            catch { return -1; }
        }
    }
}
