using System;

namespace HELP
{
    class Ayuda_help
    {
        static void Main(string[] args)
        {
            if (args.Length==0)
                MensajeHelp();
            else if (args.Length==1)
                MensajeComando(args[0]);
            else
                Console.WriteLine("Número de argumentos incorrecto.");
        }
        public static void MensajeHelp()
        {
            Console.WriteLine("Para obtener más información acerca de un comando específico, escriba HELP seguido del nombre de comando");
            Console.WriteLine(
                "DIR ".PadRight(10) + "Muestra una lista de archivos en un directorio.\n" +
                "COPY ".PadRight(10) + "Copia un archivo en otra ubicación.\n" +
                "DELETE ".PadRight(10) + "Elimina un archivo.\n" +
                "HELP ".PadRight(10) + "Proporciona información de Ayuda para los comandos de Francisco J. Gómez Florido.\n" +
                "TYPE ".PadRight(10) + "Muestra el contenido de un archivo de texto.\n" +
                "FIND".PadRight(10) + "Busca una cadena de texto en uno o más archivos.\n");
        }
        public static void MensajeComando(string comando)
        {
            comando = comando.ToUpper().Replace(" ","");
            switch (comando)
            {
                case "DIR":
                    Console.WriteLine("DIR.exe [ruta]\n" +
                        "Lista todos los ficheros y carpetas del directorio actual o del directorio especificado.");
                    break;
                case "COPY":
                    Console.WriteLine("COPY.exe [ruta\\]nombreArchivoOrigen [ruta\\][nombreArchivoDestino]\n" +
                        "Copia un fichero a una ruta específica (absoluta o relativa).\n" +
                        "Si no se especifica el nombre del fichero se copia con el mismo nombre.");
                    break;
                case "DELETE":
                    Console.WriteLine("DELETE.exe [ruta\\]nombreArchivo\n" +
                        "Borra un archivo de una ruta concreta o de la ruta actual.");
                    break;
                case "HELP":
                    Console.WriteLine("HELP.exe [nombreComando]\n" +
                        "Obtiene información sobre los comandos disponibles o del comando especificado como argumento.");
                    break;
                case "TYPE":
                    Console.WriteLine("TYPE.exe [ruta\\]nombreFichero\n" +
                        "Muestra el contenido como texto de un fichero.");
                    break;
                case "FIND":
                    Console.WriteLine("FIND.exe \"Texto a buscar\" [ruta\\](nombreFichero | * )\n" +
                        "Busca en un fichero o ficheros una cadena de texto concreta y muestra la linea por pantalla.");
                    break;
                default:
                    Console.WriteLine("El comando introducido no coincide con ninguno de los disponibles.");
                    break;
            }
        }
    }
}
