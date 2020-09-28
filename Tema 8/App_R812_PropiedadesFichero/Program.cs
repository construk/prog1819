using System;
using System.IO;
using System.Windows.Forms;

namespace App_R812_PropiedadesFichero
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string ruta = RutaFicheroGraficamente();
            FileAttributes atributos = File.GetAttributes(ruta);
          
            Console.WriteLine("Atributos: ".PadLeft(20) + atributos);
            FileStream flujo = new FileStream(ruta, FileMode.Open);
            ImprimeTamano(flujo.Length);
            flujo.Close();
            ImprimeLineasYPalabras(ruta);

            Console.ReadLine();
        }
        public static void ImprimeLineasYPalabras(string ruta)
        {
            int contadorLineas = 0;
            int contadorPalabras = 0;
            using (FileStream flujo = new FileStream(ruta, FileMode.Open, FileAccess.Read))
            using (StreamReader lector = new StreamReader(flujo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    contadorPalabras += linea.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Length;
                    contadorLineas++;
                }
            }
            Console.WriteLine("Número de palabras: ".PadLeft(20) + contadorPalabras);
            Console.WriteLine("Número de lineas: ".PadLeft(20) + contadorLineas);
        }
        public static void ImprimeTamano(long bytesFlujo)
        {
            double megasFichero = MegaBytes(bytesFlujo);
            if (megasFichero < 1)
            {
                if (KyloBytes(bytesFlujo) < 1)
                {
                    Console.WriteLine("Tamaño: ".PadLeft(20) + Math.Round((double)bytesFlujo, 2) + " bytes.");
                }
                else
                {
                    Console.WriteLine("Tamaño: ".PadLeft(20) + Math.Round(KyloBytes(bytesFlujo), 2) + " kylobytes.");
                }
            }
            else if (megasFichero > 1024)
            {
                Console.WriteLine("Tamaño: ".PadLeft(20) + Math.Round(megasFichero / 1024, 2) + " gygabytes.");
            }
            else
            {
                Console.WriteLine("Tamaño: ".PadLeft(20) + Math.Round(megasFichero, 2) + " megabytes.");
            }
        }
        public static string RutaFicheroGraficamente()
        {
            OpenFileDialog abrirFichero = new OpenFileDialog();
            abrirFichero.Filter = "Archivos de texto (*.txt)|*.txt";
            DialogResult resultado;
            do
            {
                resultado = abrirFichero.ShowDialog();
            } while (resultado != DialogResult.OK);

            return abrirFichero.FileName;
        }
        private static double KyloBytes(long bytes)
        {
            const double KYLOBYTES = 1024;
            return bytes / KYLOBYTES;
        }
        private static double MegaBytes(long bytes)
        {
            const double KYLOBYTES = 1024;
            const double MEGABYTES = 1024;
            return ((double)(bytes / KYLOBYTES)) / MEGABYTES;
        }
    }
}
