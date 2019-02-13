using App_R701_MenuPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App_R705_ColeccionOrdenadaSinRepeticion
{
    public class Trabajadores
    {
        #region CAMPOS
        List<Trabajador> trabajadores;  //Colección usada internamente.
        int punteroListado;             //Puntero para saber la posición en el listado.
        const int maxMostrarPag = 20;     //Constante usada para definir el máximo de elementos a mostrar en la lista.
        #endregion
        #region CONSTRUCTOR
        /// <summary>
        /// Construir colección de trabajadores que permite administrar un listado de trabajadores con su código único, nombre, apellidos, fecha de nacimiento y sueldo. 
        /// </summary>
        public Trabajadores()
        {
            trabajadores = new List<Trabajador>();
            punteroListado = 0;
        }
        #endregion
        #region PROPIEDADES
        /// <summary>
        /// Posición de la página mostrada del listado. Valor mínimo: 0, valor máximo: NumeroPáginas - 1.
        /// </summary>
        public int PunteroListado
        {
            get { return punteroListado; }
            set
            {
                if (trabajadores.Count > 0)
                {

                    /*punteroListado=(value+ trabajadores.Count)% trabajadores.Count*/      //Para hacerlo circular
                    if (value > NumeroPaginas - 1)                                          //Limitarlo superiormente
                    {
                        punteroListado = NumeroPaginas - 1;
                    }
                    else if (value < 0)                                                     //Limitarlo inforiormente
                    {
                        punteroListado = 0;
                    }
                    else
                    {
                        punteroListado = value;
                    }

                }
            }
        }
        /// <summary>
        /// Número de elementos que se muestran por página en el listado.
        /// </summary>
        public int MostrarPorPagina
        {
            get
            {
                if (trabajadores.Count > maxMostrarPag)
                {
                    return maxMostrarPag;
                }
                else
                {
                    return trabajadores.Count;
                }
            }
        }
        /// <summary>
        /// Número de páginas del listado.
        /// </summary>
        public int NumeroPaginas
        {
            get
            {
                if (trabajadores.Count % MostrarPorPagina == 0)
                {
                    return trabajadores.Count / MostrarPorPagina;
                }
                else
                {
                    return (trabajadores.Count / MostrarPorPagina) + 1;
                }
            }
        }
        /// <summary>
        /// Indexador que nos permite recorrer la colección.
        /// </summary>
        /// <param name="numero">Número de la posición del elemento a obtener (Desde 0 hasta NumeroTrabajadores).</param>
        /// <returns>Devuelve un trabajador de la colección</returns>
        public Trabajador this[int numero]
        {
            get { return trabajadores[numero]; }
        }
        /// <summary>
        /// Obtiene el número de trabajadores en la colección.
        /// </summary>
        public int NumeroTrabajadores
        {
            get { return trabajadores.Count(); }
        }
        #endregion
        #region MÉTODOS
        #region Básicos
        /// <summary>
        /// Añade un nuevo trabajador a la colección.
        /// </summary>
        /// <param name="trabajador">Trabajador a introducir.</param>
        /// <returns>True si el trabajador se añadió correctamente. False si el trabajador no se añadió porque ya existe alguien con el mismo código u otro error.</returns>
        public bool Anadir(Trabajador trabajador)
        {
            try { 
            if (EstaCodigo(trabajador.Codigo))
            {
                return false;
            }
            trabajadores.Add(trabajador);
            return true;
            }catch(Exception)
            { return false; }
        }
        /// <summary>
        /// Añade un nuevo trabajador a la colección.
        /// </summary>
        /// <param name="codigo">Código del trabajador</param>
        /// <param name="apellidos">Apellidos del trabajador</param>
        /// <param name="nombre">Nombre del trabajador</param>
        /// <param name="fechaNacimiento">Fecha de nacimiento del trabajador</param>
        /// <param name="sueldo">Sueldo del trabajador</param>
        /// <returns>True si el trabajador se añadió correctamente. False si el trabajador no se añadió porque ya existe alguien con el mismo código u otro error.</returns>
        public bool Anadir(int codigo, string apellidos, string nombre, DateTime fechaNacimiento, double sueldo)
        {
            try
            {
                Trabajador trabajador = new Trabajador(codigo, apellidos, nombre, fechaNacimiento, sueldo);
                if (EstaCodigo(codigo))
                {
                    return false;
                }
                else
                {
                    trabajadores.Add(trabajador);
                    return true;
                }
            }
            catch (Exception)
            { return false; }
        }
        /// <summary>
        /// Ordena la colección de trabajadores por los códigos del trabajador.
        /// </summary>
        public void Ordenar()
        {
            trabajadores.Sort();
        }
        /// <summary>
        /// Buscar trabajador por número de código.
        /// </summary>
        /// <param name="codigo">Código a buscar.</param>
        /// <returns>Devuelve el trabajador buscado o un empleado vacio en caso de no encontrarlo.</returns>
        public Trabajador Buscar(int codigo)
        {
            bool estaTrabajador = false;
            int indiceTrabajadores = 0;
            Trabajador resultado = new Trabajador();
            while (indiceTrabajadores < trabajadores.Count && !estaTrabajador)
            {
                if (trabajadores[indiceTrabajadores].Codigo == codigo)
                {
                    resultado = trabajadores[indiceTrabajadores];
                    estaTrabajador = true;
                }
                indiceTrabajadores++;
            }
            return resultado;
        }
        /// <summary>
        /// Listar los trabajadores de forma paginada.
        /// </summary>
        public void Listar()
        {
            Console.Clear();
            Marcos marco = new Marcos(new Coordenada(), new Coordenada(98, 23), TipoMarco.Simple, ConsoleColor.Red);
            marco.Pinta(true, 1);

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("CÓDIGO".PadRight(10) + "APELLIDOS".PadRight(30) + "NOMBRE".PadRight(30) + "FECHA NACIMIENTO".PadRight(20) + "SUELDO");
            Console.CursorTop++;

            for (int i = punteroListado * MostrarPorPagina; i < (punteroListado * MostrarPorPagina) + MostrarPorPagina && i < trabajadores.Count; i++)
            {
                Console.CursorLeft = 1;
                Console.WriteLine(trabajadores[i].ToString());
                Console.CursorLeft = 1;
            }
        }
        /// <summary>
        /// Mostrar todos los trabajadores.
        /// </summary>
        public void ListarTodos()
        {
            Marcos marco = new Marcos(new Coordenada(), new Coordenada(97, 22), TipoMarco.Simple, ConsoleColor.Red);
            marco.Pinta(true, 1);
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("CÓDIGO".PadRight(10) + "APELLIDOS".PadRight(30) + "NOMBRE".PadRight(30) + "FECHA NACIMIENTO".PadRight(20) + "SUELDO");
            foreach (Trabajador trabajador in trabajadores)
            {
                Console.CursorLeft = 1;
                Console.WriteLine(trabajador.ToString());
                Console.CursorLeft = 1;
            }
        }
        /// <summary>
        /// Borrar trabajador según el código.
        /// </summary>
        /// <param name="codigoTrabajador">Código del trabajador a eliminar.</param>
        /// <returns>True, si se ha encontrado y eliminado el trabador que corresponde a dicho código, false en caso contrario.</returns>
        public bool Borrar(int codigoTrabajador)
        {
            int posicionTrabajador;
            if ((posicionTrabajador = EstaCodigoEn(codigoTrabajador)) != -1)
            {
                trabajadores.Remove(trabajadores[posicionTrabajador]);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Por Consola
        /// <summary>
        /// Añadir mediante consola los datos del trabajador.
        /// </summary>
        public void AnadirConsola()
        {
            int codigo;
            string apellidos;
            string nombre;
            DateTime fechaNacimiento;
            double sueldo;
            string auxiliar;
            Console.Clear();
            Console.WriteLine("===========================================");
            Console.WriteLine("             AÑADIR EMPLEADO");
            Console.WriteLine("===========================================");
            Console.Write(" Escribe el código de empleado: ");
            auxiliar = Console.ReadLine();
            while (!int.TryParse(auxiliar, out codigo))
            {
                Console.Write(" Introduce un código válido (número entero): ");
                auxiliar = Console.ReadLine();
            }
            Console.Write(" Introduce los apellidos: ");
            apellidos = Console.ReadLine();
            Console.Write(" Introduce el nombre: ");
            nombre = Console.ReadLine();
            Console.Write(" Escribe la fecha de nacimiento: ");
            auxiliar = Console.ReadLine();
            while (!DateTime.TryParse(auxiliar, out fechaNacimiento))
            {
                Console.Write(" Introduce una fecha de nacimiento válida (DD/MM/AAAA): ");
                auxiliar = Console.ReadLine();
            }
            Console.Write(" Escribe el sueldo: ");
            auxiliar = Console.ReadLine();
            while (!double.TryParse(auxiliar, out sueldo))
            {
                Console.Write(" Introduce un sueldo válido (valores reales): ");
                auxiliar = Console.ReadLine();
            }
            Trabajador trabajador = new Trabajador(codigo, apellidos, nombre, fechaNacimiento, sueldo);
            if (Anadir(trabajador))
            {
                Console.WriteLine(" Empleado añadido con éxito.");
            }
            else
            {
                Console.WriteLine(" El código del empleado utilizaado ya está en uso.");
            }


        }
        /// <summary>
        /// Buscar trabajador por código por consola.
        /// </summary>
        public void BuscarCodigoConsola()
        {
            string auxiliar;
            int codigo;
            Console.WriteLine("===========================================");
            Console.WriteLine("             BUSCAR EMPLEADO");
            Console.WriteLine("===========================================");

            Console.Write(" Introduce el código del empleado: ");
            auxiliar = Console.ReadLine();
            while (!int.TryParse(auxiliar, out codigo))
            {
                Console.Write(" Introduce un código válido (número entero): ");
                auxiliar = Console.ReadLine();
            }
            int indice;
            if ((indice = EstaCodigoEn(codigo)) != -1)
            {
                Console.WriteLine(this[indice]);
            }
            else
            {
                Console.WriteLine(" El código del empleado a buscar no coincide con ninguno en la lista.");
            }
        }
        /// <summary>
        /// Menú con las distintas opciones para buscar trabajadores.
        /// </summary>
        public void BuscarMenuConsola()
        {
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();
            string[] opcionesBuscar = new string[] { "Código", "Apellido", "Nombre", "Fecha de nacimiento" };
            MenuPrincipal menuBusqueda = new MenuPrincipal("BUSCAR TRABAJADOR", opcionesBuscar, ConsoleColor.Red, TipoMarco.Simple, EstiloTexto.alineadoIzquierda);
            do
            {
                Console.Clear();
                menuBusqueda.Pintar();
                Console.WriteLine();
                Console.WriteLine("  Esc (Salir)");
                tecla = Console.ReadKey(true);

                switch (tecla.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        BuscarCodigoConsola();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Write(" Introduce el apellido: ");
                        MostrarTrabajadoresApellidos(Console.ReadLine());
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Write(" Introduce el nombre: ");
                        MostrarTrabajadoresNombre(Console.ReadLine());
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Write(" Introduce el nombre: ");
                        MostrarTrabajadoresFechaNacimiento(Console.ReadLine());
                        break;
                }
                Console.WriteLine(" Pulse ENTER para continuar...");
                Console.ReadLine();
            } while (tecla.Key != ConsoleKey.Escape);
        }
        /// <summary>
        /// Borrar empleado por consola con confirmación antes de borrar.
        /// </summary>
        public void BorrarEmpleadoConsola()
        {
            Console.Write(" Introduce el código del empleado a borrar: ");
            int codEm;
            string aux = Console.ReadLine();
            while (!int.TryParse(aux, out codEm))
            {
                Console.Write(" Introduce un código válido (número entero): ");
                aux = Console.ReadLine();
            }
            int indiceTrabajador;
            if ((indiceTrabajador = EstaCodigoEn(codEm)) != -1)
            {
                Console.WriteLine(" ¿Estás seguro que deseas borrar a: \n {0}[S/N]?", trabajadores[indiceTrabajador].ToString());
                aux = Console.ReadLine();
                if (aux.Equals("S") || aux.Equals("s"))
                {
                    if (Borrar(codEm))
                    {
                        Console.WriteLine(" Empleado borrado con éxito.");
                    }
                }
            }
            else
            {
                Console.WriteLine(" El código de empleado introducido no coincide con ninguno en la lista.");
            }
        }
        /// <summary>
        /// Menú que permite listar de forma paginada con distintas opciones incluidas (Moverte entre páginas, añadir, borrar y ordenar).
        /// </summary>
        public void ListarMenuConsola()
        {
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();
            do
            {
                Listar();
                Console.WriteLine();
                Console.CursorLeft = 4;
                Console.SetCursorPosition(2, 24);
                MostrarNumPaginas();
                Console.WriteLine("<- (Atrás)  -> (Delante)  Esc (Salir)  A (Añadir)  B (Borrar)\nO/N/P/F/S (Ordenar por código/nombre/apellidos/f. nacimiento/sueldo)");
                tecla = Console.ReadKey(true);
                switch (tecla.Key)
                {
                    case ConsoleKey.LeftArrow:  //Flecha izquierda muestra la página previa del listado
                        PunteroListado--;
                        break;
                    case ConsoleKey.RightArrow: //Flecha derecha muestra la página siguiente del listado
                        PunteroListado++;
                        break;
                    case ConsoleKey.A:          //Añadir trabajador
                        AnadirConsola();
                        Console.WriteLine(" Pulsa ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.B:          //Borrar
                        BorrarEmpleadoConsola();
                        Console.WriteLine(" Pulsa ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.O:          //Ordenar por código
                        Ordenar();
                        break;
                    case ConsoleKey.N:          //Ordenar por nombre
                        OrdenarPorNombre();
                        break;
                    case ConsoleKey.P:          //Ordenar por apellido
                        OrdenarPorApellido();
                        break;
                    case ConsoleKey.F:          //Ordenar por fecha de nacimiento
                        OrdenarPorFechaNacimmiento();
                        break;
                    case ConsoleKey.S:          //Ordenar por sueldo
                        OrdenarPorSueldo();
                        break;
                }
            } while (tecla.Key != ConsoleKey.Escape);
        }
        #endregion
        #region Extras
        /// <summary>
        /// Comprueba si un código está incluido en la colección.
        /// </summary>
        /// <param name="codigoTrabajador">Código a comprobar.</param>
        /// <returns>Devuelve true si está contenido y false si no está contenido.</returns>
        public bool EstaCodigo(int codigoTrabajador)
        {
            bool estaCodigo = false;
            int indiceTrabajadores = 0;
            while (indiceTrabajadores < trabajadores.Count && !estaCodigo)
            {
                if (trabajadores[indiceTrabajadores].Codigo == codigoTrabajador)
                {
                    estaCodigo = true;
                }
                indiceTrabajadores++;
            }
            return estaCodigo;
        }
        /// <summary>
        /// Comprueba si un código está en la colección, si está devuelve su posición, si no está devuelve -1.
        /// </summary>
        /// <param name="codigoTrabajador">Código a comprobar.</param>
        /// <returns>Devuelve la posición del trabajador en la colección con dicho código, si no está devuelve -1.</returns>
        public int EstaCodigoEn(int codigoTrabajador)
        {
            bool estaCodigo = false;
            int indiceTrabajadores = 0;
            int resultado = -1;
            while (indiceTrabajadores < trabajadores.Count && !estaCodigo)
            {
                if (trabajadores[indiceTrabajadores].Codigo == codigoTrabajador)
                {
                    estaCodigo = true;
                    resultado = indiceTrabajadores;
                }
                indiceTrabajadores++;
            }
            return resultado;
        }
        /// <summary>
        /// Muestra un listado de Trabajadores con un nombre determinado.
        /// </summary>
        /// <param name="nombre">Nombre a buscar</param>
        public void MostrarTrabajadoresNombre(string nombre)
        {
            int[] resultadoBusqueda = BuscarIndicesNombre(nombre);
            if (resultadoBusqueda[0] != -1)
            {
                for (int i = 0; i < resultadoBusqueda.Length; i++)
                {
                    Console.WriteLine(trabajadores[resultadoBusqueda[i]].ToString());
                }
            }
        }
        /// <summary>
        /// Muestra un listado de Trabajadores con un apellido determinado.
        /// </summary>
        /// <param name="apellidos">Apellido a buscar</param>
        public void MostrarTrabajadoresApellidos(string apellidos)
        {
            int[] resultadoBusqueda = BuscarIndicesApellido(apellidos);
            if (resultadoBusqueda[0] != -1)
            {
                for (int i = 0; i < resultadoBusqueda.Length; i++)
                {
                    Console.WriteLine(trabajadores[resultadoBusqueda[i]].ToString());
                }
            }
        }
        /// <summary>
        /// Muestra un listado de Trabajadores con una fecha de nacimiento determinada.
        /// </summary>
        /// <param name="fecha">Fecha de nacimiento a buscar</param>
        public void MostrarTrabajadoresFechaNacimiento(string fecha)
        {
            try
            {
                DateTime fecha2 = DateTime.Parse(fecha);
                int[] resultadoBusqueda = BuscarIndicesFechaNacimiento(fecha2);
                if (resultadoBusqueda[0] != -1)
                {
                    for (int i = 0; i < resultadoBusqueda.Length; i++)
                    {
                        Console.WriteLine(trabajadores[resultadoBusqueda[i]].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("La fecha introducida no es válida");
            }
        }
        /// <summary>
        /// Ordena la colección de trabajadores por el nombre del trabajador.
        /// </summary>
        public void OrdenarPorNombre()
        {
            trabajadores.Sort(new OrdenarTrabajador.OrdenarPorNombre());
        }
        /// <summary>
        /// Ordena la colección de trabajadores por el apellido del trabajador.
        /// </summary>
        public void OrdenarPorApellido()
        {
            trabajadores.Sort(new OrdenarTrabajador.OrdenarPorApellido());
        }
        /// <summary>
        /// Ordena la colección de trabajadores por el sueldo del trabajador.
        /// </summary>
        public void OrdenarPorSueldo()
        {
            trabajadores.Sort(new OrdenarTrabajador.OrdenarPorSueldo());
        }
        /// <summary>
        /// Ordena la colección de trabajadores por la fecha de nacimiento del trabajador.
        /// </summary>
        public void OrdenarPorFechaNacimmiento()
        {
            trabajadores.Sort(new OrdenarTrabajador.OrdenarPorFechaNacimiento());
        }
        #region Privados
        private void MostrarNumPaginas()
        {
            if (trabajadores.Count % MostrarPorPagina == 0)
            {
                Console.WriteLine(punteroListado + 1 + "/" + NumeroPaginas + " Pág.");
            }
            else
            {
                Console.WriteLine(punteroListado + 1 + "/" + NumeroPaginas + " Pág.");
            }
        }
        private int[] BuscarIndicesNombre(string nombre)
        {
            int indiceTrabajadores = 0;
            int[] resultado = new int[trabajadores.Count];
            int contadorResultados = 0;
            while (indiceTrabajadores < trabajadores.Count)
            {
                if (trabajadores[indiceTrabajadores].Nombre.Contains(nombre))
                {
                    resultado[contadorResultados] = indiceTrabajadores;
                    contadorResultados++;
                }
                indiceTrabajadores++;
            }
            if (contadorResultados > 0)
            {
                int[] resultadoFinal = new int[contadorResultados];
                Array.Copy(resultado, resultadoFinal, contadorResultados);
                return resultadoFinal;
            }
            else
            {
                return new int[] { -1 };
            }
        }
        private int[] BuscarIndicesApellido(string apellidos)
        {
            int indiceTrabajadores = 0;
            int[] resultado = new int[trabajadores.Count];
            int contadorResultados = 0;
            while (indiceTrabajadores < trabajadores.Count)
            {
                if (trabajadores[indiceTrabajadores].Apellidos.Contains(apellidos))
                {
                    resultado[contadorResultados] = indiceTrabajadores;
                    contadorResultados++;
                }
                indiceTrabajadores++;
            }
            if (contadorResultados > 0)
            {
                int[] resultadoFinal = new int[contadorResultados];
                Array.Copy(resultado, resultadoFinal, contadorResultados);
                return resultadoFinal;
            }
            else
            {
                return new int[] { -1 };
            }
        }
        private int[] BuscarIndicesFechaNacimiento(DateTime fechaNacimiento)
        {
            int indiceTrabajadores = 0;
            int[] resultado = new int[trabajadores.Count];
            int contadorResultados = 0;
            while (indiceTrabajadores < trabajadores.Count)
            {
                if (trabajadores[indiceTrabajadores].FechaNacimiento.Equals(fechaNacimiento))
                {
                    resultado[contadorResultados] = indiceTrabajadores;
                    contadorResultados++;
                }
                indiceTrabajadores++;
            }
            if (contadorResultados > 0)
            {
                int[] resultadoFinal = new int[contadorResultados];
                Array.Copy(resultado, resultadoFinal, contadorResultados);
                return resultadoFinal;
            }
            else
            {
                return new int[] { -1 };
            }
        }
        #endregion
        #endregion
        #endregion
    }
}