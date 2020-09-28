using System;

namespace App_R701_MenuPrincipal
{
    /// <summary>
    /// Enumeración que sirve para definír la alineación del texto en el menú.
    /// </summary>
    public enum EstiloTexto { alineadoIzquierda }
    /// <summary>
    /// Clase que permite dibujar un menú de consola con distintos estilos de manera sencilla.
    /// </summary>
    public class MenuPrincipal
    {
        #region Campos
        const int ALTO_INUTIL = 3;
        const int ANCHO_INUTIL = 5;
        Marcos marco;
        string titulo;
        string[] opcionesMenu;
        ConsoleColor color;
        int paginaMenu;
        private readonly EstiloTexto estilo;
        int posicionMargen = 1;
        readonly TipoMarco tipoMarco;
        int tamanoTitulo = 0;
        #endregion
        #region Propiedades
        /// <summary>
        /// Alto que ocupa el cuerpo de las opciones.
        /// </summary>
        private int AltoUsadoCuerpoOpciones
        {
            get
            {
                if (NumeroOpciones > AltoEscribible)
                {
                    Coordenada.Maximize();
                    return AltoEscribible;
                }
                else if (NumeroOpciones > Console.WindowHeight)
                {
                    Coordenada.Maximize();
                    if (NumeroOpciones > AltoEscribible)
                    {
                        return AltoEscribible;
                    }
                    else
                    {
                        return NumeroOpciones;
                    }
                }
                else
                {
                    return NumeroOpciones;
                }
            }
        }
        /// <summary>
        /// Número de opciones del menú.
        /// </summary>
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
                    return (NumeroOpciones / AltoEscribible) - 1;
                }
                else
                {
                    return (NumeroOpciones / AltoEscribible);
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
        /// <summary>
        /// Ancho máximo que se puede escribir en consola.
        /// </summary>
        private int AnchoEscribible { get { return Console.LargestWindowWidth - ANCHO_INUTIL - 1; } }
        /// <summary>
        /// Alto máximo que se puede escribir en consola.
        /// </summary>
        private int AltoEscribible { get { return Console.LargestWindowHeight - tamanoTitulo - 4; } }
        private int OpcionesPorPaginaMenu
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
        #endregion
        #region Constructor
        /// <summary>
        /// Construye un MenuPrincipal dado su título y sus opciones. También permite cambiar el tipo de marco, su color, y el estilo de alineación del texto.
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
        #endregion
        #region Métodos
        #region Métodos públicos
        /// <summary>
        /// Pinta el menú dadas sus caracteristicas pasadas en el constructor. Incluye la pagina actual y las páginas del MenuPrincipal.
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
                Console.SetCursorPosition(posicionMargen, 1);           //Posiciona escribir
                Console.Write(FormatoTitulo(titulo, out tamanoTitulo));  //Escribir el título
                Console.SetCursorPosition(1, Console.CursorTop + 2);    //Posicionar para escribir opciones
                PintarOpciones();                                       //Pintar las opciones

                marco = new Marcos(new Coordenada(), new Coordenada(ComprobarMayorAnchoTexto(), AltoUsadoCuerpoOpciones + tamanoTitulo + 2), tipoMarco, color);
                marco.Pinta(true, tamanoTitulo);
                Console.WriteLine();
                Console.Write(this.PaginasString().PadLeft(ComprobarMayorAnchoTexto() / 2 + 1));
            }
        }
        /// <summary>
        /// Pinta el menú dadas sus caracteristicas pasadas en el constructor. Puedes o no incluir las páginas del MenuPrincipal.
        /// </summary>
        /// <param name="pintarPaginasYEnumerado">True para pintar la página actual y el número de páginas que tiene el menú y enumerar las opciones. False para no mostrarlas.</param>
        public void Pintar(bool pintarPaginasYEnumerado)
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
                PintarOpciones(pintarPaginasYEnumerado);                                       //Pintar las opciones

                marco = new Marcos(new Coordenada(), new Coordenada(ComprobarMayorAnchoTexto(), AltoUsadoCuerpoOpciones + tamanoTitulo + 2), tipoMarco, color);
                marco.Pinta(true, tamanoTitulo);
                Console.WriteLine();
                if (pintarPaginasYEnumerado)
                {
                    Console.Write(this.PaginasString().PadLeft(ComprobarMayorAnchoTexto() / 2 + 1));
                }
            }
        }
        /// <summary>
        /// Obtiene un string con la página actual y el total de páginas
        /// </summary>
        /// <returns>"NumeroPagina/NumeroPaginas"</returns>
        public string PaginasString()
        {
            return (PaginaMenu + 1) + "/" + (PaginasMenu + 1) + " Pág.";
        }
        #endregion
        #region Métodos privados
        /// <summary>
        /// Escribe un string para las opciones que lo limita al AnchoEscribible.
        /// </summary>
        /// <param name="opcion">Opción a formatear.</param>
        /// <returns>String limitado al ancho escribible o el string tal cual si no supera el ancho.</returns>
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
        /// <summary>
        /// Devuelve el título para escribirlo antes de pintar el marco
        /// </summary>
        /// <param name="titulo">string del título a formatear.</param>
        /// <param name="numeroFilas">Número de filas que serán el resultado del formateo del texto</param>
        /// <returns>Título formateado.</returns>
        private static string FormatoTitulo(string titulo, out int numeroFilas)
        {
            string resultado = "";
            string[] cadenas = titulo.Split(' ');
            int contador = 0;
            numeroFilas = 1;
            int sumaCaracteres = 0;
            /*while (contador < cadenas.Length)
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
            }*/
            string cadenaATratar = "-1";
            int contadorCaracteresFila = 0;
            while (contador < cadenas.Length)
            {
                if (cadenaATratar.Equals("-1"))
                {
                    cadenaATratar = cadenas[contador];
                }
                int tamanoCadenaATratar = cadenaATratar.Length;
                int maxAnchoPermitido = Console.LargestWindowWidth - 5;

                if (tamanoCadenaATratar > maxAnchoPermitido)
                {
                    while (tamanoCadenaATratar > maxAnchoPermitido)
                    {
                        numeroFilas++;
                        resultado += cadenaATratar.Substring(0, maxAnchoPermitido) + "\n ";
                        contadorCaracteresFila = 0;
                        tamanoCadenaATratar = cadenaATratar.Substring(maxAnchoPermitido).Length;
                        if (tamanoCadenaATratar < maxAnchoPermitido)
                        {
                            resultado += cadenaATratar.Substring(maxAnchoPermitido);
                            contadorCaracteresFila += cadenaATratar.Substring(maxAnchoPermitido).Length;
                            cadenaATratar = "-1";
                            contador++;
                        }
                        else
                        {
                            cadenaATratar = cadenaATratar.Substring(maxAnchoPermitido);
                            tamanoCadenaATratar = cadenaATratar.Length;
                        }
                    }
                }
                else
                {
                    if ((contadorCaracteresFila + tamanoCadenaATratar) > maxAnchoPermitido)
                    {
                        resultado += "\n ";
                        contadorCaracteresFila = 0;
                        numeroFilas++;
                    }
                    else
                    {
                        resultado += " " + cadenaATratar;
                        contadorCaracteresFila += cadenaATratar.Length + 1;
                        cadenaATratar = "-1";
                        contador++;
                    }
                }
            }

            return resultado;
        }
        /// <summary>
        /// Pinta las opciones del menú según en la página que te encuentres.
        /// </summary>
        private void PintarOpciones()
        {
            int numeroOpciones = opcionesMenu.Length;
            for (int i = PaginaMenu * OpcionesPorPaginaMenu; i < (PaginaMenu * OpcionesPorPaginaMenu) + OpcionesPorPaginaMenu && i < opcionesMenu.Length; i++)
            {
                Console.CursorLeft = posicionMargen + 1;
                Console.WriteLine((i + 1) + " - " + Escribir(opcionesMenu[i]));
            }
        }
        private void PintarOpciones(bool conEnumeracion)
        {
            if (conEnumeracion)
            {
                int numeroOpciones = opcionesMenu.Length;
                for (int i = PaginaMenu * OpcionesPorPaginaMenu; i < (PaginaMenu * OpcionesPorPaginaMenu) + OpcionesPorPaginaMenu && i < opcionesMenu.Length; i++)
                {
                    Console.CursorLeft = posicionMargen + 1;
                    Console.WriteLine((i + 1) + " - " + Escribir(opcionesMenu[i]));
                }
            }
            else
            {
                int numeroOpciones = opcionesMenu.Length;
                for (int i = PaginaMenu * OpcionesPorPaginaMenu; i < (PaginaMenu * OpcionesPorPaginaMenu) + OpcionesPorPaginaMenu && i < opcionesMenu.Length; i++)
                {
                    Console.CursorLeft = posicionMargen + 1;
                    Console.WriteLine(Escribir(opcionesMenu[i]));
                }
            }
            
        }
        /// <summary>
        /// Determina el mayor ancho del título en caso de que supere una línea.
        /// </summary>
        /// <returns>Devuelve un entero que representa el string más largo.</returns>
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
        /// <summary>
        /// Comprueba el mayor ancho tanto de título como de las opciones del menú.
        /// </summary>
        /// <returns>Devuelve un entero que representa el string más largo.</returns>
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
        #endregion
        #endregion
    }
}