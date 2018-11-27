/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Windows.Forms;

namespace App_R5E13_ElJuegoDeLaVida
{
    public class JuegoVida
    {
        #region CAMPOS
        private int ALTO_MAXIMO = Console.LargestWindowHeight;
        private int ANCHO_MAXIMO = Console.LargestWindowWidth;

        private int contadorGeneraciones;
        private int ancho;
        private int alto;
        private bool[,] entorno;
        private bool[,] entorno2;
        private string entornoString;
        private char caracterPintaViva;
        private char caracterPintaMuerta;
        private ConsoleColor colorPintaViva;
        private ConsoleColor colorPintaMuerta;
        #endregion
        #region CONSTRUCTORES
        public JuegoVida()
        {
            Alto = 30;
            Ancho = 120;
            Entorno = new bool[Alto, Ancho];
            caracterPintaViva = '*';
            caracterPintaMuerta = ' ';
            ColorPintaViva = ConsoleColor.White;
            ColorPintaMuerta = ConsoleColor.White;
            contadorGeneraciones = 0;
        }
        public JuegoVida(int alto, int ancho)
        {
            Alto = alto;
            Ancho = ancho;
            Entorno = new bool[Alto, Ancho];
            caracterPintaViva = '*';
            caracterPintaMuerta = ' ';
            ColorPintaViva = ConsoleColor.White;
            ColorPintaMuerta = ConsoleColor.White;
            contadorGeneraciones = 0;
        }
        public JuegoVida(int alto, int ancho, char pintaViva)
        {
            Alto = alto;
            Ancho = ancho;
            Entorno = new bool[Alto, Ancho];
            CaracterPintaViva = pintaViva;
            CaracterPintaMuerta = ' ';
            ColorPintaViva = ConsoleColor.White;
            ColorPintaMuerta = ConsoleColor.White;
            contadorGeneraciones = 0;
        }
        public JuegoVida(bool[,] entorno)
        {
            Entorno = entorno;
            caracterPintaViva = '*';
            caracterPintaMuerta = ' ';
            ColorPintaViva = ConsoleColor.White;
            ColorPintaMuerta = ConsoleColor.White;
            contadorGeneraciones = 0;
        }
        #endregion
        #region PROPIEDADES
        public int ContadorGeneraciones
        {
            get { return contadorGeneraciones; }
        }
        public int Ancho
        {
            get { return ancho; }
            set
            {
                if (value < 0)
                    ancho = 12;
                else if (value > ANCHO_MAXIMO)
                    ancho = ANCHO_MAXIMO;
                else
                    ancho = value;
            }
        }
        public int Alto
        {
            get { return alto; }
            set
            {
                if (value < 0)
                    alto = 12;
                else if (value > ALTO_MAXIMO)
                    alto = ALTO_MAXIMO;
                else
                    alto = value;
            }
        }
        public bool[,] Entorno
        {
            get { return entorno; }
            set
            {
                if (value.GetLength(0) <= ALTO_MAXIMO && value.GetLength(1) <= ANCHO_MAXIMO)          //SI VALORES MENOR O IGUAL QUE EL MÁXIMO
                {
                    Alto = value.GetLength(0);
                    Ancho = value.GetLength(1);
                    entorno = value;
                }
                else if (value.GetLength(0) <= ALTO_MAXIMO && value.GetLength(1) > ANCHO_MAXIMO)    //SI ALTO ES MENOR O IGUAL QUE EL MÁXIMO, PERO EL ANCHO ES MAYOR O IGUAL
                {
                    Alto = value.GetLength(0);
                    Ancho = ANCHO_MAXIMO;
                    entorno = new bool[Alto, Ancho];
                }
                else if (value.GetLength(0) > ALTO_MAXIMO && value.GetLength(1) <= ANCHO_MAXIMO)   //SI ALTO ES MAYOR QUE EL MÁXIMO, Y EL ANCHO ES MENOR O IGUAL
                {
                    Alto = ALTO_MAXIMO;
                    Ancho = value.GetLength(0);
                    entorno = new bool[Alto, Ancho];
                }
                else        //SI AMBOS SON MAYORES AL MÁXIMO
                {
                    Alto = ALTO_MAXIMO;
                    Ancho = ANCHO_MAXIMO;
                    entorno = new bool[Alto, Ancho];
                }
                entorno2 = new bool[Alto, Ancho];
            }
        }
        public string EntornoString
        {
            get { return entornoString; }
            set { entornoString = value; }
        }
        public char CaracterPintaViva
        {
            get { return caracterPintaViva; }
            set { caracterPintaViva = value; }
        }
        public char CaracterPintaMuerta
        {
            get { return caracterPintaMuerta; }
            set { caracterPintaMuerta = value; }
        }
        public ConsoleColor ColorPintaViva
        {
            get { return colorPintaViva; }
            set { colorPintaViva = value; }
        }
        public ConsoleColor ColorPintaMuerta
        {
            get { return colorPintaMuerta; }
            set { colorPintaMuerta = value; }
        }
        #endregion
        #region MÉTODOS
        #region MÉTODOS PRIVADOS   
        private void RellenaFalsoVida()
        {
            for (int i = 0; i < Ancho; i++)
            {
                for (int j = 0; j < Alto; j++)
                {
                    entorno2[i, j] = false;
                }
            }
        }
        private int ContarVecino(int posY, int posX)
        {
            int resultado = 0;                                              //RESULTADO COMIENZA EN 0
            int posRelX;                                                    //POSICION QUE TIENE EN CASO DE QUE AL REDEDOR NO HAYA CÉLULA
            int posRelY;                                                    //POSICION QUE TIENE EN CASO DE QUE AL REDEDOR NO HAYA CÉLULA
            for (int i = posY - 1; i <= (posY + 1); i++)          //ALTO      //RECORRE POSICIONES ALREDEDOR DE LA CELULA VIVA (O MUERTA) A CONTAR
            {
                for (int j = posX - 1; j <= (posX + 1); j++)      //ANCHO
                {
                    if (!(i == posY && j == posX))                             //SI NO ES LA POSICIÓN DESDE DONDE SE MIRA (CUENTA VECINOS MENOS ÉL MISMO)
                    {
                        //ALTO RELATIVO
                        if (i == -1)                                        //SI POSICIÓN NEGATIVA
                            posRelY = (posY + Alto - 1) % Alto;             //POSICIÓN RELATIVA SERÁ LA DEL EXTREMO
                        else if (i >= Alto)                                 //SI MAYOR O IGUAL AL ALTO
                            posRelY = (posY + Alto + 1) % Alto;             //POSICIÓN RELATIVA SERÁ LA DEL EXTREMO
                        else                                                //SINO POSICIÓN RELATIVA SERÁ EL VALOR DE I
                            posRelY = i;

                        //ANCHO RELATIVO
                        if (j == -1)                                        //SI POSICIÓN NEGATIVA
                            posRelX = (posX + Ancho - 1) % Ancho;           //POSICIÓN RELATIVA SERÁ LA DEL EXTREMO
                        else if (j >= Ancho)                                //SI MAYOR O IGUAL AL ANCHO
                            posRelX = (posX + Ancho + 1) % Ancho;           //POSICIÓN RELATIVA SERÁ LA DEL EXTREMO
                        else                                                //SINO POSICIÓN RELATIVA SERÁ EL VALOR DE J
                            posRelX = j;

                        if (entorno[posRelY, posRelX])                      //SI LA CÉLULA ESTÁ VIVA, LA SUMA
                            resultado++;
                    }
                }
            }
            return resultado;
        }
        private void CuentaVecinos()
        {
            for (int i = 0; i < Alto; i++)          //RECORRE ALTO
                for (int j = 0; j < Ancho; j++)     //RECORRE ANCHO
                {
                    int vecinosContados = ContarVecino(i, j); //CUENTA EL NÚMERO DE VECINOS Y LO ALMACENA

                    if (entorno[i, j] && vecinosContados < 2) //SI ESTÁ VIVA Y VECINOS MENOR A 2, MUERE DE SOLEDAD
                        entorno2[i, j] = false;
                    else if (entorno[i, j] && (vecinosContados == 2 || vecinosContados == 3)) //SI ESTÁ VIVA Y VECINOS SON ENTRE 2 Y 3, PERMANECE VIVA (ES REDUNDANTE)
                        entorno2[i, j] = true;
                    else if (entorno[i, j] && vecinosContados > 3)  //SI ESTÁ VIVA Y VECINOS ES MAYOR A 3 MUERE DE SUPERPOBLACIÓN
                        entorno2[i, j] = false;
                    else if (!entorno[i, j] && vecinosContados == 3) //SI ESTÁ MUERTA Y TIENE 3 VECINOS REVIVE
                        entorno2[i, j] = true;
                }
        }
        private void PasarDeEntorno2AEntorno1()
        {
            for (int i = 0; i < Alto; i++)
                for (int j = 0; j < Ancho; j++)
                    entorno[i, j] = entorno2[i, j];

        }
        #endregion
        #region MÉTODOS PÚBLICOS
        public void RellenaAleaVida(Random rnd, int porcientoVida)
        {
            contadorGeneraciones = 0;
            if (porcientoVida > 100)
            {
                porcientoVida = 100;
            }
            else if (porcientoVida < 0)
            {
                porcientoVida = 0;
            }
            for (int i = 0; i < Alto; i++)
            {
                for (int j = 0; j < Ancho; j++)
                {
                    int probabilidad = rnd.Next(101);
                    if (probabilidad <= porcientoVida)
                        entorno[i, j] = true;
                    else
                        entorno[i, j] = false;
                }
            }
        }
        public void PintaEntorno()
        {
            Console.SetCursorPosition(0, 0);
            entornoString = "";
            for (int i = 0; i < Alto; i++)
            {
                for (int j = 0; j < Ancho; j++)
                {
                    if (entorno[i, j])
                    {
                        Console.ForegroundColor = ColorPintaViva;
                        entornoString += CaracterPintaViva;
                    }
                    else
                    {
                        Console.ForegroundColor = ColorPintaMuerta;
                        entornoString += CaracterPintaMuerta;
                    }
                }
                entornoString += "\n";
            }
            Console.WriteLine(entornoString);
        }
        public void Evoluciona()
        {
            CuentaVecinos();
            PasarDeEntorno2AEntorno1();
            PintaEntorno();
            contadorGeneraciones++;
        }
        public void AbrirArchivo()
        {
            OpenFileDialog dialogoApertura = new OpenFileDialog();
            string leido = "";
            if (dialogoApertura.ShowDialog() == DialogResult.OK)
            {
                //LEER LINEAS DEL ARCHIVO Y CERRARLO (NO INCLUYE LOS SALTOS DE LÍNEA)
                string linea = "";
                StreamReader lector = new StreamReader(dialogoApertura.FileName);
                while ((linea = lector.ReadLine()) != null)
                    leido += linea;
                lector.Close();

                //RELLENAR ARRAY MULTIDIMENSIONAL DESDE STRING (ARRAY DE UNA DIMENSION DE CHAR)
                int vecesI = 0;
                int vecesJ = 0;
                bool[,] archivo = new bool[Alto, Ancho];
                for (int i = 0; i < leido.Length; i++)
                {
                    if (leido[i].Equals(CaracterPintaViva))
                        archivo[vecesI, vecesJ] = true;
                    else if (leido[i].Equals(CaracterPintaMuerta))
                        archivo[vecesI, vecesJ] = false;

                    //MODIFICAR VARIABLES PARA RECORRER LAS DOS DIMENSIONES DEL bool[,] archivo
                    if (vecesJ == Ancho - 1)
                    {
                        vecesI++;
                        vecesJ = 0;
                    }
                    else
                        vecesJ++;
                }
                Entorno = archivo;

                //Mensaje indicando que el archivo ha sido cargado
                Console.SetCursorPosition(20, 22);
                Console.WriteLine("Archivo cargado correctamente. Pulse cualquier tecla para continuar...");
                while (!Console.KeyAvailable)
                { }
                Console.SetCursorPosition(20, 22);
                Console.WriteLine("                                                                                ");
                PintaEntorno();
            }
        }
        public void GuardarArchivo()
        {
            SaveFileDialog dialogoGuardar = new SaveFileDialog();
            dialogoGuardar.DefaultExt = "txt";
            if (dialogoGuardar.ShowDialog() == DialogResult.OK)
            {
                StreamWriter guarda = new StreamWriter(dialogoGuardar.FileName);
                guarda.Write(EntornoString);
                guarda.Close();
            }
        }
        #endregion
        #endregion
    }
    class MainJuegoVida
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random rnd = new Random();
            ConsoleKeyInfo teclaPulsada = new ConsoleKeyInfo();

            JuegoVida juegoVida = new JuegoVida(20, 80);
            juegoVida.RellenaAleaVida(rnd, 20);
            
            EscribeOpciones();
            juegoVida.PintaEntorno();
            do
            {
                EscribeContador(22, 22, juegoVida);
                teclaPulsada = Console.ReadKey(true);
                switch (teclaPulsada.Key)
                {
                    case ConsoleKey.A:
                        while (!Console.KeyAvailable)
                        {
                            juegoVida.Evoluciona();
                            EscribeContador(22, 22, juegoVida);
                        }
                        break;
                    case ConsoleKey.I:
                        juegoVida.Evoluciona();
                        break;
                    case ConsoleKey.R:
                        juegoVida.RellenaAleaVida(rnd, 20);
                        juegoVida.PintaEntorno();
                        break;
                    case ConsoleKey.S:
                        juegoVida.GuardarArchivo();

                        break;
                    case ConsoleKey.L:
                        juegoVida.AbrirArchivo();
                        break;
                }
            } while (teclaPulsada.Key != ConsoleKey.Escape);
        }
        public static void EscribeContador(int posX, int posY, JuegoVida medio)
        {
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine("\t\t\tContador de generaciones: {0}", medio.ContadorGeneraciones);
        }
        public static void EscribeOpciones()
        {
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("  I --> Iterar");
            Console.WriteLine("  A --> Automático");
            Console.WriteLine("  R --> Reiniciar");
            Console.WriteLine("  S --> Guardar");
            Console.WriteLine("  L --> Cargar");
            Console.WriteLine("  ESC --> Salir");
        }
    }
}
