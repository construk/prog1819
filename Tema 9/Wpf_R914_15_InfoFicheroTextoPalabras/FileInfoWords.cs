using System;
using System.Collections.Generic;
using System.IO;

namespace Wpf_R914_15_InfoFicheroTextoPalabras
{
    class FileInfoWords
    {
        readonly char[] separadores = new char[] { ' ', ',', '.', ';', ':' };
        Dictionary<string, int> palabras;
        List<PalabrasMasLarga> palabrasMasLargas;
        List<PalabrasMasCorta> palabrasMasCortas;
        List<string> palabrasPalindromas;
        int totalPalabras;
        string ruta;
        string atributos;
        int totalLineas;
        string tamanoArchivo;
        public FileInfoWords()
        {
            palabrasMasLargas = new List<PalabrasMasLarga>();
            palabrasMasCortas = new List<PalabrasMasCorta>();
            palabras = new Dictionary<string, int>();
            palabrasPalindromas = new List<string>();
            totalPalabras = 0;
            totalLineas = 0;
            ruta = "";
        }

        public string Ruta { get { return ruta; } set { ruta = value; } }
        public List<PalabrasMasRepetida> PalabrasMasRepetidas {
            get
            {
                List<PalabrasMasRepetida> masRepetidas = new List<PalabrasMasRepetida>(); //Lista de string que va a devolver.
                int nRepeticiones = 0;                          //Cantidad de repeticiones de cada palabra
                foreach (var palabra in palabras)               //Por cada palabra
                {
                    if (masRepetidas.Count==0)                  //Si la lista está vacia mete un elemento
                    {
                        masRepetidas.Add(new PalabrasMasRepetida(palabra.Key,palabra.Value));
                        nRepeticiones = palabra.Value;
                    }
                    else if (palabra.Value>nRepeticiones)       //Si el número de repeticiones es mayor que el ya asignado 
                    {                                           //limpia la lista y añade la nueva palabra más repetida
                        masRepetidas.Clear();
                        nRepeticiones = palabra.Value;
                        masRepetidas.Add(new PalabrasMasRepetida(palabra.Key, palabra.Value));
                    }
                    else if (palabra.Value==nRepeticiones)      //Si el número de repeticiones es igual, la añade
                    {
                        masRepetidas.Add(new PalabrasMasRepetida(palabra.Key, palabra.Value));
                    }
                }
                return masRepetidas;                            //Devuelve la lista de palabras más repetidas
            }
        }
        public List<string> PalabrasMenosRepetidas
        {
            get
            {
                List<string> menosRepetidas = new List<string>(); //Lista de string que va a devolver.
                int nRepeticiones = 0;                          //Cantidad de repeticiones de cada palabra
                foreach (var palabra in palabras)               //Por cada palabra
                {
                    if (menosRepetidas.Count == 0)              //Si la lista está vacia mete un elemento
                    {
                        menosRepetidas.Add(palabra.Key);
                        nRepeticiones = palabra.Value;
                    }
                    else if (palabra.Value < nRepeticiones)     //Si el número de repeticiones es menor que el ya asignado 
                    {                                           //limpia la lista y añade la nueva palabra menos repetida
                        menosRepetidas.Clear();
                        nRepeticiones = palabra.Value;
                        menosRepetidas.Add(palabra.Key);
                    }
                    else if (palabra.Value == nRepeticiones)      //Si el número de repeticiones es igual, la añade
                    {
                        menosRepetidas.Add(palabra.Key);
                    }
                }
                return menosRepetidas;                            //Devuelve la lista de palabras más repetidas
            }
        }
        public List<PalabrasMasLarga> PalabrasMasLargas { get { return palabrasMasLargas; } }
        public List<PalabrasMasCorta> PalabrasMasCortas { get { return palabrasMasCortas; } }
        public List<string> Palindromas { get { return palabrasPalindromas; } }
        public int TotalPalabras { get { return totalPalabras; } }
        public int TotalLineas { get { return totalLineas; } }
        public string Atributos { get { return atributos; } }
        public string TamanoArchivo
        {
            get
            {
                if (File.Exists(ruta))
                {
                    long tamanoFichero = new FileInfo(ruta).Length;
                    if (tamanoFichero<1024)
                    {
                        return tamanoFichero.ToString("###0") + " bytes";
                    }
                    else if(tamanoFichero<(1024*1024))
                    {
                        return ((double)tamanoFichero/1024).ToString("#,##0.##") + " kilobytes";
                    }
                    else
                    {
                        return ((double)tamanoFichero / (1024*1024)).ToString("#,##0.##") + " megabytes";
                    }
                }
                else
                {
                    return "Error: El fichero no existe";
                }
            }
        }
        private void ComprobarSiMasLarga(string palabra, int lineaActual)
        {
            if (palabrasMasLargas.Count==0) //Si no hay palabrás la añade.
            {
                palabrasMasLargas.Add(new PalabrasMasLarga(palabra, lineaActual));
            }
            else if (palabrasMasLargas[0].Palabra_Mas_Larga.Length<palabra.Length)    //Si la palabra nueva es mayor borra el diccionario y la añade
            {
                palabrasMasLargas.Clear();
                palabrasMasLargas.Add(new PalabrasMasLarga(palabra, lineaActual));
            }
            else if (palabrasMasLargas[0].Palabra_Mas_Larga.Length == palabra.Length) //Si la palabra es igual de larga la añade.
            {
                palabrasMasLargas.Add(new PalabrasMasLarga(palabra, lineaActual));
            }
        }
        private void ComprobarSiMasCorta(string palabra, int lineaActual)
        {
            if (palabrasMasCortas.Count == 0) //Si no hay palabrás la añade.
            {
                palabrasMasCortas.Add(new PalabrasMasCorta(palabra, lineaActual));
            }
            else if (palabrasMasCortas[0].Palabra_Mas_Corta.Length > palabra.Length)    //Si la palabra nueva es menor borra el diccionario y la añade
            {
                palabrasMasCortas.Clear();
                palabrasMasCortas.Add(new PalabrasMasCorta(palabra, lineaActual));
            }
            else if (palabrasMasCortas[0].Palabra_Mas_Corta.Length == palabra.Length) //Si la palabra es igual de corta la añade.
            {
                palabrasMasCortas.Add(new PalabrasMasCorta(palabra, lineaActual));
            }
        }
        private void AnadirOSumarPalabra(string palabra)
        {

            if (palabras.ContainsKey(palabra))
            {
                palabras[palabra] = (palabras[palabra] + 1);
            }
            else
            {
                palabras.Add(palabra, 1);
            }
        }

        public void LeerDocumento()
        {
            if (File.Exists(ruta))
            {
                atributos = File.GetAttributes(ruta).ToString();
                using (FileStream flujoFichero = new FileStream(ruta, FileMode.Open))
                using (StreamReader lector = new StreamReader(flujoFichero))
                {
                    string linea;
                    int contadorLinea = 1;
                    while ((linea=lector.ReadLine())!=null)
                    {
                        string[] palabrasLinea = linea.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < palabrasLinea.Length; i++)
                        {
                            AnadirOSumarPalabra(palabrasLinea[i]);
                            ComprobarSiMasLarga(palabrasLinea[i], contadorLinea);
                            ComprobarSiMasCorta(palabrasLinea[i], contadorLinea);
                        }
                        totalPalabras += palabrasLinea.Length;
                        contadorLinea++;
                    }
                    totalLineas = contadorLinea;
                }
            }
        }
    }
}
