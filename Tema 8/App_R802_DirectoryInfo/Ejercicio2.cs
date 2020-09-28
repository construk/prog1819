using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace App_R802_DirectoryInfo
{
    class Ejercicio2
    {
        [STAThread]
        static void Main(string[] args)
        {
            FolderBrowserDialog abrirCarpeta = new FolderBrowserDialog();
            DialogResult resultado = abrirCarpeta.ShowDialog();
            if(resultado==DialogResult.OK)
            {
                string carpetaSeleccionada = abrirCarpeta.SelectedPath;
                InfoDirectorio(carpetaSeleccionada);
            }
            Console.ReadLine();
        }
        public static void InfoDirectorio(string ruta)
        {
            DirectoryInfo directorio = new DirectoryInfo(ruta);
            Console.WriteLine("   Ruta completa: "+directorio.FullName);
            Console.WriteLine("  Nombre carpeta: " + directorio.Name);
            Console.WriteLine("Directorio padre: " + directorio.Parent);
            Console.WriteLine(" Directorio raíz: " + directorio.Root);
            Console.WriteLine("        Creación: " + directorio.CreationTime);
            Console.WriteLine("  Ultima edición: " + directorio.LastWriteTime);
            Console.WriteLine("   Ultimo acceso: " + directorio.LastAccessTime);       
        }
    }
}
