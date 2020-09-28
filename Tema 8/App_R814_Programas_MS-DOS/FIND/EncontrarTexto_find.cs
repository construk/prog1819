using System;
using System.Collections.Generic;
using System.IO;

namespace FIND
{
    class EncontrarTexto_find
    {
        static void Main(string[] args)
        {
            if (args.Length!=2)
            {
                Console.WriteLine("Número de parametros incorrectos");
                return;
            }

            if (args[1].IndexOf('*')==args[1].Length-1)
            {
                string ruta = args[1].Replace("*", "");
                if (Directory.Exists(ruta))
                {
                    FileInfo[] ficheros = new DirectoryInfo(ruta).GetFiles();
                    foreach (var i in ficheros)
                    {
                        LeerFicheroTextoBuscando(i.FullName,args[0].Replace("\"",""));
                        Console.WriteLine("=".PadRight(Console.WindowWidth-1,'='));
                    }
                }
            }
            else
            {
                if (File.Exists(args[1]))
                {
                    LeerFicheroTextoBuscando(args[1], args[0]);
                }
                else
                {
                    Console.WriteLine("El segundo parámetro debe de ser un archivo o un directorio acabado en \\* para incluir a todos los ficheros");
                }
            }
        }
        public static void LeerFicheroTextoBuscando(string rutaFichero, string palabraBuscada)
        {
            try
            {
                if (File.Exists(rutaFichero))
                {
                    bool seMuestra = false;
                    List<string> lineasCoincidentes = new List<string>();
                    lineasCoincidentes.Add(new FileInfo(rutaFichero).Name);
                    lineasCoincidentes.Add("=".PadRight(Console.WindowWidth - 1, '='));
                    using (FileStream flujo = new FileStream(rutaFichero, FileMode.Open))
                    using (StreamReader lector = new StreamReader(flujo))
                    {
                        string linea;
                        while ((linea = lector.ReadLine()) != null)
                        {
                            if (linea.Contains(palabraBuscada))
                            {
                                lineasCoincidentes.Add(linea);
                                seMuestra = true;
                            }
                        }
                        if (seMuestra)
                        {
                            for (int i = 0; i < lineasCoincidentes.Count; i++)
                            {
                                Console.WriteLine(lineasCoincidentes[i]);
                            }
                        }
                    }
                }
            } catch
            {
                Console.WriteLine("ERROR: No tiene permisos para leer " +new FileInfo(rutaFichero).Name);
            }
        }
    }
}
