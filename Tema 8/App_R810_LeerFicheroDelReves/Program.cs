using System;
using System.IO;

namespace App_R810_LeerFicheroDelReves
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Debes de introducir un parámetro");
                    return;
                }
                LeerDelReves(args[0]);
            }
            finally
            {
                Console.ReadLine();
            }
        }
        public static void LeerDelReves(string ruta)
        {
            if (File.Exists(ruta))
            {
                using (FileStream flujo = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                using (BinaryReader lectorBinario = new BinaryReader(flujo))
                {
                    flujo.Position = flujo.Length - 1;
                    try
                    {
                        while (flujo.Position >= 0)
                        {
                            char caracterLeido = (char)lectorBinario.PeekChar();
                            Console.Write(caracterLeido.ToString());
                            flujo.Position = flujo.Seek(-1, SeekOrigin.Current);
                        }
                    }
                    catch
                    {
                        //Cuando flujo.Position==-1 termina el bucle.
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.Write("El fichero no existe...");
            }
        }
    }
}
