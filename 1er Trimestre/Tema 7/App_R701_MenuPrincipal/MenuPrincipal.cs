using System;

namespace App_R701_MenuPrincipal
{
    public enum EstiloTexto { alineadoIzquierda }
    /// <summary>
    /// Clase que permite dibujar un menú de consola con distintos estilos de manera sencilla.
    /// </summary>
    public class MenuPrincipal
    {
        Marcos marco;
        string titulo;
        string[] opcionesMenu;
        ConsoleColor color;
        int paginaMenu;
        private readonly EstiloTexto estilo;
        int posicionMargen = 2;
        readonly TipoMarco tipoMarco;

        private int AltoUsado
        {
            get
            {
                if (opcionesMenu.Length > AltoEscribible)
                {
                    Coordenada.Maximize();
                    return AltoEscribible;
                }
                else if (opcionesMenu.Length > Console.WindowHeight)
                {
                    Coordenada.Maximize();
                    if (opcionesMenu.Length > AltoEscribible)
                    {
                        return AltoEscribible;
                    }
                    else
                    {
                        return opcionesMenu.Length;
                    }
                }
                else
                {
                    return opcionesMenu.Length;
                }
            }
        }
        private int NumeroOpciones { get { return opcionesMenu.Length; } }
        /// <summary>
        /// Número de páginas que contiene el menú dadas unas opciones y un límite según lo que permita la resolución de la pantalla.
        /// </summary>
        public int PaginasMenu
        {
            get
            {
                if (NumeroOpciones % AltoEscribible == 0)
                {
                    return (NumeroOpciones / AltoEscribible)-1;
                }
                else
                {
                    return (NumeroOpciones / AltoEscribible) ;
                }
            }
        }
        /// <summary>
        /// Página actual en la que se encuentra el menú cuando se pinte.
        /// </summary>
        public int PaginaMenu
        {
            get { return paginaMenu; }
            set
            {
                if (value < 0)
                {
                    paginaMenu = 0;
                }
                else if (value > PaginasMenu)
                {
                    paginaMenu = PaginasMenu;
                }
                else
                {
                    paginaMenu = value;
                }
            }
        }
        private int AnchoEscribible { get { return Console.LargestWindowWidth - 6; } }
        private int AltoEscribible { get { return Console.LargestWindowHeight - 7; } }
        private int ElementosPorPagina
        {
            get
            {
                if (opcionesMenu.Length > AltoEscribible)
                {
                    return AltoEscribible;
                }
                else
                {
                    return opcionesMenu.Length;
                }

            }
        }
        /// <summary>
        /// Constructor del MenuPrincipal que se construye dado su título y sus opciones. También permite cambiar el tipo de marco, su color, y el estilo de alineación del texto.
        /// </summary>
        /// <param name="titulo">string con el título del menú</param>
        /// <param name="opcionesMenu">string[] que contiene las opciones del menú.</param>
        /// <param name="color">color de los bordes del menú.</param>
        /// <param name="tipoMarco">Seleccionar si es simple o doble.</param>
        /// <param name="estilo">Seleccionar: alineacionIzquieda (próximamente más estilos)</param>
        public MenuPrincipal(string titulo, string[] opcionesMenu, ConsoleColor color, TipoMarco tipoMarco, EstiloTexto estilo)
        {
            this.titulo = titulo;
            this.opcionesMenu = opcionesMenu;
            this.color = color;
            this.tipoMarco = tipoMarco;
            this.paginaMenu = 0;
            this.estilo = estilo;
        }
        /// <summary>
        /// Pinta el menú dadas sus caracteristicas pasadas en el constructor.
        /// </summary>
        public void Pintar()
        {
            if (estilo == EstiloTexto.alineadoIzquierda)
            {
                int mayorAnchoTexto = ComprobarMayorAnchoTexto();
                if (mayorAnchoTexto > AnchoEscribible)
                {
                    Coordenada.Maximize();
                }
                else if (mayorAnchoTexto > Console.WindowWidth)
                {
                    Console.WindowWidth = mayorAnchoTexto;
                }
                int tamanoTitulo = 1;
                Console.SetCursorPosition(posicionMargen, 1);           //Posiciona escribir
                Console.Write(FormatoTitulo(titulo, out tamanoTitulo));  //Escribir el título
                Console.SetCursorPosition(1, Console.CursorTop + 2);    //Posicionar para escribir opciones
                PintarOpciones();                                       //Pintar las opciones

                marco = new Marcos(new Coordenada(), new Coordenada(ComprobarMayorAnchoTexto(), AltoUsado + tamanoTitulo + 2), tipoMarco, color);
                marco.Pinta(true, tamanoTitulo);
                Console.WriteLine();
                Console.Write(this.PaginasString().PadLeft(ComprobarMayorAnchoTexto()/2+1));
            }
        }
        /// <summary>
        /// Obtiene un string con la página y el total de páginas
        /// </summary>
        /// <returns>"NumeroPagina/NumeroPaginas"</returns>
        public string PaginasString()
        {
            return (PaginaMenu+1) + "/" + (PaginasMenu+1) + " Pág.";
        }
        private string Escribir(string opcion)
        {
            if (opcion.Length > (AnchoEscribible - 9))
            {
                return opcion.Substring(0, AnchoEscribible - 9) + "...";
            }
            else
            {
                return opcion;
            }
        }
        private string FormatoTitulo(string titulo, out int numeroFilas)
        {
            string resultado = "";
            string[] cadenas = titulo.Split(' ');
            int contador = 0;
            numeroFilas = 1;
            int sumaCaracteres = 0;
            while (contador < cadenas.Length)
            {
               
                sumaCaracteres += cadenas[contador].Length;
                
                if (sumaCaracteres > AnchoEscribible)
                {
                    resultado += "\n  " + cadenas[contador] + " ";
                    sumaCaracteres = cadenas[contador].Length + 1;
                    numeroFilas++;
                }
                else
                {
                    resultado += (cadenas[contador] + " ");
                    sumaCaracteres += cadenas[contador].Length + 1;
                }
                contador++;
            }
            return resultado;
        }
        private void PintarOpciones()
        {
            int numeroOpciones = opcionesMenu.Length;
            for (int i = PaginaMenu * ElementosPorPagina; i < (PaginaMenu * ElementosPorPagina) + ElementosPorPagina && i < opcionesMenu.Length; i++)
            {
                Console.CursorLeft = posicionMargen;
                Console.WriteLine((i + 1) + " - " + Escribir(opcionesMenu[i]));
            }
        }
        private int MasLargoTitulo()
        {
            int numero = 0;
            string texto = FormatoTitulo(titulo, out numero);
            string[] lineas = texto.Split('\n');
            int masLargo = 0;
            for (int i = 0; i < lineas.Length; i++)
            {
                if (lineas[i].Length > masLargo)
                {
                    masLargo = lineas[i].Length;
                }
            }
            return masLargo;
        }
        private int ComprobarMayorAnchoTexto()
        {
            int tamano = MasLargoTitulo();
            for (int i = 0; i < opcionesMenu.Length; i++)
            {
                if (opcionesMenu[i].Length > tamano)
                {
                    tamano = opcionesMenu[i].Length;
                }
            }
            return tamano + 5;
        }
    }
}