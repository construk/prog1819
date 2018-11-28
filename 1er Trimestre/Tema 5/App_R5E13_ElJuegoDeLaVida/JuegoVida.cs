/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		ElJuegoDeLaVida
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	En este programa se encuentra la clase JuegoVida que permite crear un entorno con vida, poder guardarlo y abrirlo y un Main que prueba dichas funcionalidades.
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace App_R5E13_ElJuegoDeLaVida
{
    /// <summary>
    /// Clase que permite la creación de objetos JuegoVida. Te permite rellenar el entorno de celulas vivas y muertas aleatoriamente, pintar el entorno, hacer que evolucione, guardar y abrir archivos
    /// </summary>
    public class JuegoVida
    {
        #region CAMPOS
        private int ALTO_MAXIMO = Console.LargestWindowHeight - 2;  //ALTO MÁXIMO PERMITIDO ES IGUAL AL ALTO MÁXIMO DE PANTALLA PERMITIDO
        private int ANCHO_MAXIMO = Console.LargestWindowWidth - 1;  //ANCHO MÁXIMO PERMITIDO ES IGUAL AL ANCHO MÁXIMO DE PANTALLA PERMITIDO
        private const int ALTO_MINIMO = 6;                      //ALTO MÍNIMO PERMITIDO ES IGUAL 6
        private const int ANCHO_MINIMO = 12;                    //ANCHO MÍNIMO PERMITIDO ES IGUAL 12
        private decimal contadorGeneraciones;                   //CONTADOR DE GENERACIONES
        private int ancho;                                      //ANCHO DEL ENTORNO
        private int alto;                                       //ALTO DEL ENTORNO
        private bool[,] entorno;                                //PRIMER ENTORNO, EL QUE SE MUESTRA
        private bool[,] entorno2;                               //SEGUNDO ENTORNO, SIRVE DE APOYO PARA EVOLUCIONAR
        private string entornoString;                           //ES EL PRIMER ENTORNO COMO STRING PARA SER MOSTRADO POR PANTALLA
        private char caracterPintaViva;                         //ES EL CARACTER QUE PINTA LAS CÉLULAS VIVAS
        private char caracterPintaMuerta;                       //ES EL CARACTER QUE PINTA LAS CÉLULAS MUERTAS
        private ConsoleColor colorPinta;                        //ES EL COLOR CON EL QUE PINTA 
        private int stopMilisegundos;
        #endregion
        #region CONSTRUCTORES
        /// <summary>
        /// Establece el alto 30, ancho 120 y pinta las células vivas con '*' y muertas con ' '.
        /// </summary>
        public JuegoVida()
        {
            Alto = 30;
            Ancho = 120;
            Entorno = new bool[Alto, Ancho];
            caracterPintaViva = '*';
            caracterPintaMuerta = ' ';
            ColorPinta = ConsoleColor.White;
            contadorGeneraciones = 0;
            stopMilisegundos = 50;
        }
        /// <summary>
        /// Establece el alto y ancho indicado (min: 6 y 12, max: Console.LargestWindowHeight y Console.LargestWindowWidth) y pinta las células vivas con '*' y muertas con ' '.
        /// </summary>
        /// <param name="alto">Establece el alto del entorno donde se reproducen las células</param>
        /// <param name="ancho">Establece el ancho del entorno donde se reproducen las células</param>
        public JuegoVida(int alto, int ancho)
        {
            Alto = alto;
            Ancho = ancho;
            Entorno = new bool[Alto, Ancho];
            caracterPintaViva = '*';
            caracterPintaMuerta = ' ';
            ColorPinta = ConsoleColor.White;
            contadorGeneraciones = 0;
            stopMilisegundos = 50;
        }
        /// <summary>
        /// Establece el alto y ancho indicado (min: 6 y 12, max: Console.LargestWindowHeight y Console.LargestWindowWidth) y pinta las células vivas con el caracter que le indiques y muertas con ' '.
        /// </summary>
        /// <param name="alto">Establece el alto del entorno donde se reproducen las células</param>
        /// <param name="ancho">Establece el ancho del entorno donde se reproducen las células</param>
        /// <param name="pintaViva">Establece el caracter que se pinta cuando hay una célula viva</param>
        public JuegoVida(int alto, int ancho, char pintaViva)
        {
            Alto = alto;
            Ancho = ancho;
            Entorno = new bool[Alto, Ancho];
            CaracterPintaViva = pintaViva;
            CaracterPintaMuerta = ' ';
            ColorPinta = ConsoleColor.White;
            contadorGeneraciones = 0;
            stopMilisegundos = 50;
        }
        /// <summary>
        /// Establece un entorno con las proporciones del array pasado (min: 6 y 12, max: Console.LargestWindowHeight y Console.LargestWindowWidth) y pinta las células vivas con '*' y muertas con ' '.
        /// </summary>
        /// <param name="entorno">bool[] que recibe con tamaño máximo Console.LargestWindowHeight y Console.LargestWindowWidth</param>
        public JuegoVida(bool[,] entorno)
        {
            Entorno = entorno;
            caracterPintaViva = '*';
            caracterPintaMuerta = ' ';
            ColorPinta = ConsoleColor.White;
            contadorGeneraciones = 0;
            stopMilisegundos = 50;
        }
        #endregion
        #region PROPIEDADES
        /// <summary>
        /// Milisegundos que pausa la aplicación entre evoluciones.
        /// </summary>
        public int StopMilisegundos
        {
            get { return stopMilisegundos; }
            set
            {
                if (value < 0)
                    value = 0;
                else if (value > int.MaxValue)
                    value = int.MaxValue;
                else
                    stopMilisegundos = value;
            }
        }
        /// <summary>
        /// Devuelve el número de generaciones que han transcurrido
        /// </summary>
        public decimal ContadorGeneraciones
        {
            get { return contadorGeneraciones; }
        }
        /// <summary>
        /// Devuelve o establece el ancho del entorno. (mín: 12, máx: Console.LargestWindowWidth).
        /// </summary>
        public int Ancho
        {
            get { return ancho; }
            set
            {
                if (value < ANCHO_MINIMO)
                    ancho = ANCHO_MINIMO;
                else if (value > ANCHO_MAXIMO)
                    ancho = ANCHO_MAXIMO;
                else
                    ancho = value;
            }
        }
        /// <summary>
        /// Devuelve o establece el alto del entorno. (mín: 6, máx: Console.LargestWindowHeight).
        /// </summary>
        public int Alto
        {
            get { return alto; }
            set
            {
                if (value < ALTO_MINIMO)
                    alto = ALTO_MINIMO;
                else if (value > ALTO_MAXIMO)
                    alto = ALTO_MAXIMO;
                else
                    alto = value;
            }
        }
        /// <summary>
        /// Devuelve o establece el entorno donde estarán las células. (tamaño min: 6 y 12, max: Console.LargestWindowHeight y Console.LargestWindowWidth)
        /// </summary>
        public bool[,] Entorno
        {
            get { return entorno; }
            set
            {
                if (value.GetLength(0) <= ALTO_MAXIMO && value.GetLength(1) <= ANCHO_MAXIMO)    //SI VALORES MENORES O IGUALES QUE EL MÁXIMO
                {
                    Alto = value.GetLength(0);
                    Ancho = value.GetLength(1);
                    if (alto == ALTO_MINIMO || ancho == ANCHO_MINIMO)                                 //SI VALORES MENORES AL MÍNIMO, AJUSTAR EL ARRAY
                    {
                        bool[,] auxiliar = new bool[Alto, Ancho];
                        Array.Copy(value, auxiliar, Alto * Ancho);
                        entorno = auxiliar;
                    }
                    else                                                                       //SI ARRAY VÁLIDO ASIGNAR COMO ESTÁ
                        entorno = value;

                }
                else if (value.GetLength(0) <= ALTO_MAXIMO && value.GetLength(1) > ANCHO_MAXIMO)    //SI ALTO ES MENOR O IGUAL QUE EL MÁXIMO, Y EL ANCHO ES MAYOR
                {
                    Alto = value.GetLength(0);
                    Ancho = ANCHO_MAXIMO;
                    entorno = new bool[Alto, Ancho];
                }
                else if (value.GetLength(0) > ALTO_MAXIMO && value.GetLength(1) <= ANCHO_MAXIMO)    //SI ALTO ES MAYOR QUE EL MÁXIMO, Y EL ANCHO ES MENOR O IGUAL
                {
                    Alto = ALTO_MAXIMO;
                    Ancho = value.GetLength(0);
                    entorno = new bool[Alto, Ancho];
                }
                else                                                                                //SI AMBOS SON MAYORES AL MÁXIMO
                {
                    Alto = ALTO_MAXIMO;
                    Ancho = ANCHO_MAXIMO;
                    entorno = new bool[Alto, Ancho];
                }
                entorno2 = new bool[Alto, Ancho];                               //DARLE VALOR A ENTORNO2 CON LAS MISMAS PROPORCIONES QUE ENTORNO
            }
        }
        /// <summary>
        /// Devuelve el string que compone el entorno
        /// </summary>
        public string EntornoString
        {
            get { return entornoString; }
        }
        /// <summary>
        /// Devuelve o establece el caracter con el que se pinta las células vivas
        /// </summary>
        public char CaracterPintaViva
        {
            get { return caracterPintaViva; }
            set { caracterPintaViva = value; }
        }
        /// <summary>
        /// Devuelve o establece el caracter con el que se pinta las células muertas
        /// </summary>
        public char CaracterPintaMuerta
        {
            get { return caracterPintaMuerta; }
            set { caracterPintaMuerta = value; }
        }
        /// <summary>
        /// Devuelve o establece el color con el que se pinta el entorno.
        /// </summary>
        public ConsoleColor ColorPinta
        {
            get { return colorPinta; }
            set { colorPinta = value; }
        }
        #endregion
        #region MÉTODOS
        #region MÉTODOS PRIVADOS   
        /// <summary>
        /// Cuenta el número de vecinos en una posición determinada. Entorno con forma de toroide.
        /// </summary>
        /// <param name="posY">Posición respecto a la vertical</param>
        /// <param name="posX">Posición respecto a la horizontal</param>
        /// <returns>Devuelve el número de vecinos en una posición determinada</returns>
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
            return resultado;                                               //DEVUELVE EL NÚMERO DE VECINOS QUE TIENE
        }
        /// <summary>
        /// Recorre entorno y va almacenando las posibles celulas muertas y vivas de cada generación a entorno2.
        /// </summary>
        private void TransformaEnEntorno2()
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
        /// <summary>
        /// Recorre entorno2 y devuelve los valores transformados a entorno
        /// </summary>
        private void DevuelveAEntorno1()
        {
            for (int i = 0; i < Alto; i++)          //RECORRE ENTORNO2 Y LO COPIA A ENTORNO
                for (int j = 0; j < Ancho; j++)
                    entorno[i, j] = entorno2[i, j];

        }
        #endregion
        #region MÉTODOS PÚBLICOS
        /// <summary>
        /// Rellena el entorno con un porcentaje de células vivas colocadas aleatoriamente.
        /// </summary>
        /// <param name="rnd">Semilla para el aleatorio</param>
        /// <param name="porcientoVida">Porcentaje de vida que queremos establecer</param>
        public void RellenaAleaVida(Random rnd, int porcientoVida)
        {
            contadorGeneraciones = 0;
            if (porcientoVida > 100)    //AJUSTE DE MÁXIMO Y MÍNIMO DEL PORCENTAJE
            {
                porcientoVida = 100;
            }
            else if (porcientoVida < 0)
            {
                porcientoVida = 0;
            }
            for (int i = 0; i < Alto; i++)  //RECORRER EL ARRAY Y RELLENARLO CON TRUE SI EL NÚMERO ALEATORIO ESTÁ ENTRE EL PORCENTAJE INDICADO Y FALSE EN CASO CONTRARIO
            {
                for (int j = 0; j < Ancho; j++)
                {
                    int probabilidad = rnd.Next(101);       //OBTIENE NÚMERO ALEATORIO ENTRE 0-100
                    if (probabilidad <= porcientoVida)      //SI NÚMERO OBTENIDO ES MENOR O IGUAL AL PORCENTAJE INDICADO: VERDAD
                        entorno[i, j] = true;
                    else                                    //SINO: FALSO
                        entorno[i, j] = false;
                }
            }
        }
        /// <summary>
        /// Recorre el entorno y pinta por pantalla las células vivas y muertas encontradas en su interior desde la posición (0,0).
        /// </summary>
        public void PintaEntorno()
        {
            if (Ancho >= Console.WindowWidth)                 //SI LA VENTANA ES MENOR A LAS PROPORCIONES DEL ARRAY A MOSTRAR, AJUSTAR LA VENTANA
                Console.WindowWidth = Ancho + 1;
            if (Alto >= Console.WindowHeight)
                Console.WindowHeight = Alto;

            Console.SetCursorPosition(0, 0);                //POSICIONA AL PRINCIPIO
            entornoString = "";
            Console.ForegroundColor = ColorPinta;           //ESTABLECE EL COLOR CON EL QUE PINTA
            for (int i = 0; i < Alto; i++)                  //RECORRE ENTORNO PARA GUARDARLO EN UN STRING
            {
                for (int j = 0; j < Ancho; j++)
                {
                    if (entorno[i, j])                      //SI ESTÁ VIVA ALMACENA CARACTERPINTAVIVA, SINO ALMACENA CARACTERPINTAMUERTA
                        entornoString += CaracterPintaViva;
                    else
                        entornoString += CaracterPintaMuerta;
                }
                entornoString += "\n";                      //CADA FILA ALMACENA SALTO DE LINEA
            }
            Console.WriteLine(entornoString);               //ESCRIBE POR PANTALLA EL STRING ALMACENADO
        }
        /// <summary>
        /// Método que hace evolucionar al entorno y lo muestra por pantalla desde la posición (0,0).
        /// </summary>
        public void Evoluciona()
        {
            TransformaEnEntorno2();     //REALIZA CAMBIOS EN EL ENTORNO 2
            DevuelveAEntorno1();        //DEVUELVE LOS CAMBIOS AL ENTORNO
            PintaEntorno();             //LO MUESTRA POR PANTALLA
            if (contadorGeneraciones < decimal.MaxValue)    //SI NO ES EL MÁXIMO DE UN LONG
                contadorGeneraciones++;     //Y AUMENTA EL NÚMERO DE GENERACIONES
            Thread.Sleep(StopMilisegundos); //PAUSA EL THREAD PARA PODER OBSERVAR LA EVOLUCIÓN REALIZADA

        }
        /// <summary>
        /// Permite recuperar mediante un archivo .txt el estado de un entorno almacenado anteriormente.
        /// </summary>
        public void AbrirArchivo()
        {
            OpenFileDialog dialogoApertura = new OpenFileDialog();  //CREAR OPENFILEDIALOG PARA SELECCIONAR QUE ARCHIVO ABRIR
            dialogoApertura.DefaultExt = "cons";
            if (dialogoApertura.ShowDialog() == DialogResult.OK)    //SI SE SELECCIONA UN ARCHIVO
            {
                string entornoString = "";
                decimal numeroContador;
                contadorGeneraciones = 0;                           //ESTABLECER CONTADOR A 0
                StreamReader lectorVivas = new StreamReader(dialogoApertura.FileName);  //LEER LINEAS DEL ARCHIVO Y CERRARLO (NO INCLUYE LOS SALTOS DE LÍNEA)
                string archivo = "";                                                    //ALMACENAR ARCHIVO EN STRING
                string linea = "";                                                      //LINEA QUE SE LEE DEL ARCHIVO
                while ((linea = lectorVivas.ReadLine()) != null)                        //MIENTRAS NO SEA NULL LEE DEL ARCHIVO
                    archivo += linea;                                                   //GUARDA EN STRING ARCHIVO TODOS LOS CARACTERES DEL ARCHIVO
                lectorVivas.Close();                                                    //CIERRA EL LECTOR DEL ARCHIVO
                string contadorString = "";                                             //CONTADOR EN STRING PARA LUEGO TRANSFORMAR A DECIMAL
                for (int i = 0; i < archivo.Length; i++)                                //RECORRE EL STRING ARCHIVO
                    if (!archivo[i].Equals(CaracterPintaViva) && !archivo[i].Equals(CaracterPintaMuerta))   //SI NO ES NI CaracterPintaViva NI CaracterPintaMuerta LO AÑADE A contadorString
                        contadorString += archivo[i];
                    else                                                                //SI ES CaracterPintaViva O CaracterPintaMuerta LO GUARDA EN entornoString
                        entornoString += archivo[i];

                numeroContador = decimal.Parse(contadorString);                         //TRANSFORMA contadorString A DECIMAL
                contadorGeneraciones = numeroContador;                                  //ALMACENA EN contadorGeneraciones EL NÚMERO DEL CONTADOR OBTENIDO

                //RELLENAR ARRAY MULTIDIMENSIONAL DESDE STRING (ARRAY DE UNA DIMENSION DE CHAR)
                int vecesI = 0;
                int vecesJ = 0;
                bool[,] entornoArchivo = new bool[Alto, Ancho];
                for (int i = 0; i < entornoString.Length; i++)                          //RECORRE ENTORNO STRING Y 
                {
                    if (entornoString[i].Equals(CaracterPintaViva))                     //SI UN CARACTER ES IGUAL CaracterPintaViva LO PONE COMO TRUE, 
                        entornoArchivo[vecesI, vecesJ] = true;
                    else if (entornoString[i].Equals(CaracterPintaMuerta))              //SI ENCUENTRA CaracterPintaMuerta LO PONE COMO FALSE
                        entornoArchivo[vecesI, vecesJ] = false;

                    //MODIFICAR VARIABLES PARA RECORRER LAS DOS DIMENSIONES DEL bool[,] leidoArchivo
                    if (vecesJ == Ancho - 1)    //YA HA RECORRIDO POSICIÓN MÁXIMA DE J --> SE INCREMENTA vecesI Y SE PONE A 0 vecesJ 
                    {
                        vecesI++;
                        vecesJ = 0;
                    }
                    else                        //SI NO HA RECORRIDO vecesJ HASTA SU POSICIÓN MÁXIMA --> INCREMENTA vecesJ
                        vecesJ++;
                }
                Entorno = entornoArchivo;

                //MENSAJE INDICANDO QUE EL ARCHIVO HA SIDO CARGADO
                Console.SetCursorPosition(20, 22);
                Console.WriteLine("Archivo cargado correctamente. Pulse cualquier tecla para continuar...");
                while (!Console.KeyAvailable)           //MIENTRAS NO SE PULSE UNA TECLA BUCLE INFINITO
                { }
                Console.SetCursorPosition(20, 22);      //BORRA MENSAJE ANTES ESCRITO
                Console.WriteLine("                                                                                ");
                PintaEntorno();             //PINTA EL ARCHIVO CARGADO
            }
        }
        /// <summary>
        /// Permite almacenar mediante un cuadro de diálogo un archivo .txt con el estado actual del entorno y el contador de generaciones.
        /// </summary>
        public void GuardarArchivo()
        {
            SaveFileDialog dialogoGuardar = new SaveFileDialog();       //CREAR SAVEFILEDIALOG PARA SELECCIONAR DONDE GUARDAR EL ARCHIVO
            dialogoGuardar.DefaultExt = "cons";                          //FORMATO POR DEFECTO DEL ARCHIVO .txt
            if (dialogoGuardar.ShowDialog() == DialogResult.OK)         //SI LE DAS A GUARDAR
            {
                StreamWriter guarda = new StreamWriter(dialogoGuardar.FileName);    //CREA STREAM PARA ESCRIBIR EN UN ARCHIVO QUE SE VA A CREAR O SOBREESCRIBIR
                guarda.Write(ContadorGeneraciones + EntornoString);                 //ESCRIBE ContadorGeneracionesS Y EntornoString
                guarda.Close();                                                     //CIERRA EL FLUJO DEL STREAM ABIERTO
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
            try
            {
                Console.CursorVisible = false;                              //OCULTAR CURSOR
                Random rnd = new Random();                                  //CREAR SEMILLA PARA ALEATORIO
                ConsoleKeyInfo teclaPulsada = new ConsoleKeyInfo();         //TACLA A PULSAR
                Console.OutputEncoding = System.Text.Encoding.UTF8;         //CAMBIAR CODIFICACIÓN PARA ACEPTAR OTROS CARÁCTERES
                JuegoVida juegoVida = new JuegoVida(22, 120);               //CREO JUEGO DE LA VIDA DE 22 DE ALTO Y 120 DE ANCHO
                juegoVida.RellenaAleaVida(rnd, 20);                         //RELLENA ALEATORIAMENTE EL ENTORNO CON 20% DE VIDA
                juegoVida.StopMilisegundos = 200;                           //ESTABLECE COMO TIEMPO DE PARADA POR DEFECTO 200 MILISEGUNDOS
                juegoVida.PintaEntorno();                                   //PINTA EL ENTORNO
                EscribeOpciones();                                          //PINTA LAS OPCIONES
                
                do                                                          //HACER MIENTRAS NO SE PULSE LA TECLA ESCAPE
                {
                    EscribeContador(25, 28, juegoVida);                     //PINTA EL CONTADOR DE LAS GENERACIONES 
                    teclaPulsada = Console.ReadKey(true);                   //LEE CARACTER
                    switch (teclaPulsada.Key)                               //SEGÚN EL CARACTER PULSADO (AUTOMATICO, ITERA, REINICIA, GUARDA O CARGA (ESCAPE PARA SALIR) 
                    {
                        case ConsoleKey.A:                                  //SI LA TECLA PULSADA ES LA A, O LA FLECHA HACIA ARRIBA O LA FLECHA HACIA ABAJO
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.DownArrow:
                            while (!Console.KeyAvailable)                   //MIENTRAS NO SE PULSE UNA TECLA
                            {
                                juegoVida.Evoluciona();                     //VA A EVOLUCIONAR 
                                if (teclaPulsada.Key == ConsoleKey.UpArrow) //SI HAS PULSADO LA TECLA HACIA ARRIBA --> INCREMENTAS VELOCIDAD (QUITANDO STOP DE MILISEGUNDOS)
                                    juegoVida.StopMilisegundos -= 20;
                                else if (teclaPulsada.Key == ConsoleKey.DownArrow)  //SI HAS PULSADO LA TECLA HACIA ABAJO --> DISMINUYES VELOCIDAD (AUMENTANDO STOP DE MILISEGUNDOS)
                                    juegoVida.StopMilisegundos += 20;

                                EscribeContador(25, 28, juegoVida);         //ESCROBIR EL CONTADOR PARA QUE AUMENTE
                                teclaPulsada = new ConsoleKeyInfo();        //BORRA LA TECLA PULSADA (INICIALIZÁNDOLA DE NUEVO)
                            }
                            break;
                        case ConsoleKey.I:                                  //SI PULSAS I
                            juegoVida.Evoluciona();                         //EVOLUCIONA UNA VEZ
                            break;
                        case ConsoleKey.R:                                  //SI PULSAS R
                            Console.SetCursorPosition(20, 25);              //BORRAR EL CONTADOR
                            Console.WriteLine("                                                                                ");
                            juegoVida.RellenaAleaVida(rnd, 20);             //RELLENA ALEATORIAMENTE
                            juegoVida.PintaEntorno();                       //PINTA ENTORNO

                            break;
                        case ConsoleKey.S:                                  //SI PULSAS S
                            juegoVida.GuardarArchivo();                     //EJECUTA MÉTODO PARA GUARDAR EL ESTADO
                            break;
                        case ConsoleKey.L:                                  //SI PULSAS L
                            juegoVida.AbrirArchivo();                       //EJECUTA MÉTODO PARA ABRIR ARCHIVO DE ESTADO GUARDADO
                            Console.SetCursorPosition(20, 28);              //BORRA EL CONTADOR
                            Console.WriteLine("                                                                                ");
                            break;
                    }
                } while (teclaPulsada.Key != ConsoleKey.Escape);            //MIENTRAS NO SE PULSE ESCAPE....
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); Console.ReadLine(); }           //SI EXCEPCIÓN MENSAJE Y ESPERA PARA VERLO
        }

        /// <summary>
        /// Escribe el contador de número de generaciones del juego de la vida en una posición determinada
        /// </summary>
        /// <param name="posX">Posición horizontal</param>
        /// <param name="posY">Posición vertical</param>
        /// <param name="medio">Juego al que aplicar</param>
        public static void EscribeContador(int posX, int posY, JuegoVida medio)
        {
            Console.SetCursorPosition(posX, posY);
            if (medio.ContadorGeneraciones <= decimal.MaxValue)
                Console.WriteLine("\t\tContador de generaciones: {0}\t Stop en milisegundos: {1:D6}", medio.ContadorGeneraciones, medio.StopMilisegundos);
            else
                Console.WriteLine("\t\t\tContador de generaciones: VALOR MÁXIMO ALCANZADO");
            
        }
        /// <summary>
        /// Escribe las opciones del menú en una posición fija
        /// </summary>
        public static void EscribeOpciones()
        {
            Console.SetCursorPosition(0, 23);
            Console.WriteLine("  I --> Iterar");
            Console.WriteLine("  A --> Automático\t↑Aumenta velocidad\t↓Disminuye la velocidad");
            Console.WriteLine("  R --> Reiniciar");
            Console.WriteLine("  S --> Guardar");
            Console.WriteLine("  L --> Cargar");
            Console.WriteLine("  ESC --> Salir");
        }
    }
}