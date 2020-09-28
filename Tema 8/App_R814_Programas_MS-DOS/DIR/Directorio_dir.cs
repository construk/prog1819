using System;
using System.IO;

namespace DIR
{
    class Directorio_dir
    {
        static void Main(string[] args)
        {
            if (args.Length==0)
            {
                InfoDisco();
                ListarDirectorio();
            }
            else if (args.Length==1)
            {
                if (Directory.Exists(args[0]))
                {
                    InfoDisco(args[0]);
                    ListarDirectorio(args[0]);
                }
                else
                    Console.WriteLine("El directorio introducido no existe...");
            }
            else
                Console.WriteLine("Número de argumentos incorrecto.");
        }
        public static void InfoDisco()
        {
            DriveInfo disco = new DriveInfo(Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()));
            string etiquetaDisco = disco.VolumeLabel;
            string textoEtiquetaMostrado;
            if (etiquetaDisco.Equals(""))
            {
                textoEtiquetaMostrado = string.Format(" El volumen de la unidad {0} no tiene etiqueta.",disco.Name);

            }
            else
            {
                textoEtiquetaMostrado = string.Format(" El volumen de la unidad {0} es {1}", disco.RootDirectory, etiquetaDisco);
            }

            Console.WriteLine(textoEtiquetaMostrado);
        }
        public static void InfoDisco(string ruta)
        {
            DriveInfo disco = new DriveInfo(Directory.GetDirectoryRoot(ruta));
            string etiquetaDisco = disco.VolumeLabel;
            string textoEtiquetaMostrado;
            if (etiquetaDisco.Equals(""))
            {
                textoEtiquetaMostrado = string.Format(" El volumen de la unidad {0} no tiene etiqueta.", disco.Name);

            }
            else
            {
                textoEtiquetaMostrado = string.Format(" El volumen de la unidad {0} es {1}", disco.RootDirectory, etiquetaDisco);
            }

            Console.WriteLine(textoEtiquetaMostrado);
        }
        public static void ListarDirectorio()
        {
            string ruta = Directory.GetCurrentDirectory();
            DirectoryInfo directorio = new DirectoryInfo(ruta);
            DirectoryInfo[] directorios = directorio.GetDirectories();
            int totalDirectorios = 1;
            Console.WriteLine("\n Directorio de {0}\n",ruta);
            
            Console.WriteLine(directorio.LastWriteTime.ToShortDateString() +
                    directorio.LastWriteTime.ToShortTimeString().PadLeft(7) +
                    "<DIR>".PadLeft(9) +
                    ".".PadLeft(11));

            if (directorio.Parent!=null)
            {
                Console.WriteLine(directorio.Parent.LastWriteTime.ToShortDateString() +
                    directorio.Parent.LastWriteTime.ToShortTimeString().PadLeft(7) +
                    "<DIR>".PadLeft(9) +
                    "..".PadLeft(12));
                totalDirectorios++;
            }

            foreach (var i in directorios)
            {
                Console.WriteLine(i.LastWriteTime.ToShortDateString() +
                    i.LastWriteTime.ToShortTimeString().PadLeft(7) +
                    "<DIR>".PadLeft(9) +" ".PadRight(10)+
                    i.Name);
            }
            FileInfo[] ficheros = directorio.GetFiles();
            long totalTamanoArchivos = 0;
            foreach (var i in ficheros)
            {
                Console.WriteLine(i.LastWriteTime.ToShortDateString() +
                    i.LastWriteTime.ToShortTimeString().PadLeft(7) +
                    i.Length.ToString("#,###").PadLeft(18) +
                    i.Name.PadLeft(i.Name.Length + 1));

                totalTamanoArchivos += i.Length;
            }
            DriveInfo disco = new DriveInfo(Directory.GetDirectoryRoot(ruta));
            Console.WriteLine(ficheros.Length.ToString().PadLeft(15)+" archivos"+totalTamanoArchivos.ToString("#,###").PadLeft(16)+" bytes");
            Console.WriteLine((directorios.Length+totalDirectorios).ToString().PadLeft(15) + " dirs" + disco.AvailableFreeSpace.ToString("#,###").PadLeft(20)+" bytes libres");
        }
        public static void ListarDirectorio(string ruta)
        {
            DirectoryInfo directorio = new DirectoryInfo(ruta);
            DirectoryInfo[] directorios = directorio.GetDirectories();
            int totalDirectorios = 1;
            Console.WriteLine("\n Directorio de {0}\n", ruta);

            Console.WriteLine(directorio.LastWriteTime.ToShortDateString() +
                    directorio.LastWriteTime.ToShortTimeString().PadLeft(7) +
                    "<DIR>".PadLeft(9) +
                    ".".PadLeft(11));

            if (directorio.Parent != null)
            {
                Console.WriteLine(directorio.Parent.LastWriteTime.ToShortDateString() +
                    directorio.Parent.LastWriteTime.ToShortTimeString().PadLeft(7) +
                    "<DIR>".PadLeft(9) +
                    "..".PadLeft(12));
                totalDirectorios++;
            }

            foreach (var i in directorios)
            {
                Console.WriteLine(i.LastWriteTime.ToShortDateString() +
                    i.LastWriteTime.ToShortTimeString().PadLeft(7) +
                    "<DIR>".PadLeft(9) + " ".PadRight(10) +
                    i.Name);
            }
            FileInfo[] ficheros = directorio.GetFiles();
            long totalTamanoArchivos = 0;
            foreach (var i in ficheros)
            {
                Console.WriteLine(i.LastWriteTime.ToShortDateString() +
                    i.LastWriteTime.ToShortTimeString().PadLeft(7) +
                    i.Length.ToString("#,###").PadLeft(18) +
                    i.Name.PadLeft(i.Name.Length + 1));

                totalTamanoArchivos += i.Length;
            }
            DriveInfo disco = new DriveInfo(Directory.GetDirectoryRoot(ruta));
            Console.WriteLine(ficheros.Length.ToString().PadLeft(15) + " archivos" + totalTamanoArchivos.ToString("#,###").PadLeft(16) + " bytes");
            Console.WriteLine((directorios.Length + totalDirectorios).ToString().PadLeft(15) + " dirs" + disco.AvailableFreeSpace.ToString("#,###").PadLeft(20) + " bytes libres");
        }
    }
}