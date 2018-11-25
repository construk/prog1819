/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		MenuEstructura
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Menú que te permite gestionar un array de Empleados (Añadir, Buscar, Editar y Listar)
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Threading;

namespace App_R5E9_MenuEstructura
{
    public struct Empleado
    {
        //CAMPOS
        private string nombre;
        private string apellidos;
        private int edad;
        private double sueldo;
        private DateTime fechaContrato;
        //CONSTRUCTOR CON PARÁMETROS
        public Empleado(string nombre, string apellidos, int edad, double sueldo, DateTime fechaContrato)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
            this.sueldo = sueldo;
            this.fechaContrato = fechaContrato;
        }
        #region PROPIEDADES
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
        public string Apellidos
        {
            get
            {
                return apellidos;
            }
            set
            {
                apellidos = value;
            }
        }
        public int Edad
        {
            get
            {
                return edad;
            }
            set
            {
                edad = value;
            }
        }
        public double Sueldo
        {
            get
            {
                return sueldo;
            }
            set
            {
                sueldo = value;
            }
        }
        public DateTime FechaContrato
        {
            get
            {
                return fechaContrato;
            }
            set
            {
                fechaContrato = value;
            }
        }
        #endregion

        override
        public string ToString()    //MÉTODO ToString() SOBREESCRITO
        {
            string resultado = "";
            resultado = Nombre.PadRight(20).ToUpper() + Apellidos.PadRight(20).ToUpper() +
                Edad.ToString().PadRight(10) + (Sueldo.ToString() + " euros").PadRight(14) +
                FechaContrato.ToShortDateString();
            return resultado;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //GENERAMOS SEMILLA
            Random rnd = new Random();            
            Empleado[] empleados = new Empleado[10];            //CREAMOS ARRAY
            ConsoleKeyInfo teclaLeida = new ConsoleKeyInfo();   //TECLA INTRODUCIDA POR EL USUARIO QUE SE OBTENDRÁ EL CARACTER INTRODUCIDO
            int opcionInt;                                      //OPCIÓN INTRODUCIDA POR EL USUARIO DE TIPO INT QUE COMPRUEBA QUE SEA UN NÚMERO LO QUE INTRODUCE
            bool noSalir = true;                                //BOLEANO QUE EVITA QUE SALGA DEL MENÚ
            string elegidaString = teclaLeida.KeyChar.ToString();       //SE TRANSFORMA A STRING PORQUE NO EXISTE SOBRECARGA PARA TIPO CHAR PARA MÉTODO TRYPARSE            
            string auxiliar;
            
            //MENU
            do                                                  //HACER MIENTRA EL BOOLEANO NO SALIR SEA TRUE (SE VUELVE FALSE SI SE PULSA 0)
            {
                LimpiaYPintaMenuPrincipal();                    //MÉTODO QUE LIMPIA LA CONSOLA Y PINTA EL MENÚ PRINCIPAL PARA DICHO PROGRAMA
                int posicionTop = Console.CursorTop;            //GUARDAMOS LA POSICIÓN TOP DE ESCRITURA;
                int posicionLeft = Console.CursorLeft;          //GUARDAMOS LA POSICIÓN LEFT DE ESCRITURA;
                //LEER OPCION
                teclaLeida = Console.ReadKey();                  //INTRODUCIDO POR EL USUARIO

                //MIENTRAS NO PUEDA TRANSFORMARLO A INT PIDE EL NÚMERO Y BORRA EL CAMPO ESCRITO
                while (!int.TryParse(elegidaString, out opcionInt))
                {
                    Console.SetCursorPosition(posicionLeft, posicionTop);   //POSICIONA PARA BORRAR EL CAMPO INTRODUCIDO PORQUE NO PUEDE TRANSFORMA A STRING
                    Console.Write(" ");                                     //BORRA EL CAMPO INTRODUCIDO
                    Console.SetCursorPosition(posicionLeft, posicionTop);   //POSICIONA PARA LEER
                    teclaLeida = Console.ReadKey();                         //LEE DATO DEL USUARIO
                    elegidaString = teclaLeida.KeyChar.ToString();          //GUARDA COMO STRING PARA COMPROBAR SI SE PUEDE TRANSFORMA A INT
                }
                //OPCIÓN ELEGIDA
                switch (teclaLeida.KeyChar)     //SEGÚN LA TECLA PULSADA
                {
                    #region OPCION 0 - SALIR
                    case '0':                                               //OPCION PARA SALIR
                        noSalir = false;                                    //PONE A FALSE EL BOOLEANO QUE MANTIENE EL BUCLE DEL MENÚ
                        Console.SetCursorPosition(Console.CursorLeft - 16, Console.CursorTop + 3);
                        Console.Write("Saliendo");
                        Thread.Sleep(400);
                        Console.Write(".");
                        Thread.Sleep(400);
                        Console.Write(".");
                        Thread.Sleep(400);
                        Console.Write(".");
                        break;
                    #endregion
                    #region OPCIÓN 1 - AÑADIR 
                    case '1':
                        empleados = AddEmpleado(empleados, true);
                        Console.WriteLine("EMPLEADO AÑADIDO CON ÉXISTO, PULSE ENTER PARA VOLVER AL MENÚ PRINCIPAL...");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region OPCION 2 - BUSCAR
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Introduce el nombre, apellidos, edad, sueldo o fecha de contrato del empleado a buscar");
                        Console.Write("Parámetro: ");
                        string parametroBusqueda = Console.ReadLine();
                        int rellenoHasta = EmpleadosLength(empleados);
                        Empleado[] busqueda = new Empleado[rellenoHasta];
                        busqueda = BuscarEmpleado(empleados, parametroBusqueda);
                        Console.WriteLine(ListaString(busqueda));
                        Console.WriteLine("PULSE ENTER PARA VOLVER AL MENÚ PRINCIPAL...");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region SUBMENÚ OPCION 3 - EDITAR
                    case '3': //MISMA ESTRUCTURA QUE EL MENÚ PARA SUBMENÚ QUE PERMITA ELEGIR QUE PARTE DEL EMPLEADO EDITAR
                        Console.WriteLine(ListaString(empleados, true));
                        Console.Write("Introduce el nº del empleado a editar (0 para salir): ");
                        int numeroEmpleado;
                        string auxiliar2 = Console.ReadLine();
                        while (!int.TryParse(auxiliar2, out numeroEmpleado))
                        {
                            Console.Write("Introduce un número de empleado válido: ");
                            auxiliar = Console.ReadLine();
                        }
                        if (numeroEmpleado != 0)
                        {
                            numeroEmpleado--;
                            bool noSalir2 = true;
                            string elegidaString2 = "";
                            ConsoleKeyInfo teclaLeida2 = new ConsoleKeyInfo();
                            int opionInt2;
                            do                                                  //HACER MIENTRA EL BOOLEANO NO SALIR SEA TRUE (SE VUELVE FALSE SI SE PULSA 0)
                            {
                                LimpiaYPintaMenuPrincipal2();                    //MÉTODO QUE LIMPIA LA CONSOLA Y PINTA EL MENÚ PRINCIPAL PARA DICHO PROGRAMA
                                int posicionTop2 = Console.CursorTop;           //GUARDAMOS LA POSICIÓN TOP DE ESCRITURA;
                                int posicionLeft2 = Console.CursorLeft;         //GUARDAMOS LA POSICIÓN LEFT DE ESCRITURA;
                                                                                //LEER OPCION
                                teclaLeida2 = Console.ReadKey();                //INTRODUCIDO POR EL USUARIO

                                //MIENTRAS NO PUEDA TRANSFORMARLO A INT PIDE EL NÚMERO Y BORRA EL CAMPO ESCRITO
                                while (!int.TryParse(elegidaString2, out opionInt2))
                                {
                                    Console.SetCursorPosition(posicionLeft, posicionTop2);  //POSICIONA PARA BORRAR EL CAMPO INTRODUCIDO PORQUE NO PUEDE TRANSFORMA A STRING
                                    Console.Write(" ");                                     //BORRA EL CAMPO INTRODUCIDO
                                    Console.SetCursorPosition(posicionLeft, posicionTop2);  //POSICIONA PARA LEER
                                    teclaLeida2 = Console.ReadKey();                        //LEE DATO DEL USUARIO
                                    elegidaString2 = teclaLeida2.KeyChar.ToString();        //GUARDA COMO STRING PARA COMPROBAR SI SE PUEDE TRANSFORMA A INT
                                }
                                //OPCIÓN ELEGIDA
                                switch (teclaLeida2.KeyChar)     //SEGÚN LA TECLA PULSADA
                                {
                                    case '0':                                               //OPCION PARA SALIR
                                        noSalir2 = false;                                    //PONE A FALSE EL BOOLEANO QUE MANTIENE EL BUCLE DEL MENÚ
                                        Console.SetCursorPosition(Console.CursorLeft - 16, Console.CursorTop + 3);
                                        Console.Write("Saliendo");
                                        Thread.Sleep(400);
                                        Console.Write(".");
                                        Thread.Sleep(400);
                                        Console.Write(".");
                                        Thread.Sleep(400);
                                        Console.Write(".");
                                        break;

                                    case '1':
                                        Console.Clear();
                                        Console.Write("Introduce el nombre nuevo del empleado: ");
                                        string nombre = Console.ReadLine();
                                        empleados[numeroEmpleado].Nombre = nombre;
                                        break;
                                    case '2':
                                        Console.Clear();
                                        Console.Write("Introduce los apellidos nuevos del empleado: ");
                                        string apellidos = Console.ReadLine();
                                        empleados[numeroEmpleado].Apellidos = apellidos;
                                        break;
                                    case '3':
                                        Console.Clear();
                                        Console.Write("Introduce la nueva edad del empleado: ");
                                        string auxiliar3 = Console.ReadLine();
                                        int edadEmpleado;
                                        while (!int.TryParse(auxiliar3, out edadEmpleado))
                                        {
                                            Console.WriteLine("Introduce una edad válida: ");
                                            auxiliar3 = Console.ReadLine();
                                        }
                                        empleados[numeroEmpleado].Edad = edadEmpleado;
                                        break;
                                    case '4':
                                        Console.Clear();
                                        Console.Write("Introduce el nuevo sueldo del empleado: ");
                                        string auxiliar4 = Console.ReadLine();
                                        double sueldoEmpleado;
                                        while (!double.TryParse(auxiliar4, out sueldoEmpleado))
                                        {
                                            Console.WriteLine("Introduce una edad válida: ");
                                            auxiliar4 = Console.ReadLine();
                                        }
                                        empleados[numeroEmpleado].Sueldo = sueldoEmpleado;
                                        break;
                                    case '5':
                                        Console.Clear();
                                        Console.Write("Introduce la nueva fecha de contratación del empleado: ");
                                        string auxiliar5 = Console.ReadLine();
                                        DateTime fechaContratacion;
                                        while (!DateTime.TryParse(auxiliar5, out fechaContratacion))
                                        {
                                            Console.WriteLine("Introduce una edad válida: ");
                                            auxiliar5 = Console.ReadLine();
                                        }
                                        empleados[numeroEmpleado].FechaContrato = fechaContratacion;
                                        break;
                                    default:
                                        break;
                                }
                            } while (noSalir2);                                                      //MIENTRAS NO SE PULSE 0 EN EL MENÚ NO CAMBIA LA VARIABLE noSalir DE TRUE A FALSE
                        }
                        break;
                    #endregion
                    #region OPCION 4 - LISTAR
                    case '4':
                        Console.WriteLine(ListaString(empleados, true));
                        Console.WriteLine("PULSE ENTER PARA VOLVER AL MENÚ PRINCIPAL...");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region OPCION 5 (EXTRA) - AÑADIR EMPLEADOS ALEATORIAMENTE
                    case '5':
                        Console.Clear();
                        empleados = AddEmpleado(empleados, 30, rnd);
                        Console.WriteLine("AÑADIDOS 30 EMPLEADOS ALEATORIAMENTE ENTER PARA VOLVER AL MENÚ PRINCIPAL");
                        Console.ReadLine();
                        break;
                    #endregion
                    default:
                        break;
                }
            } while (noSalir);                                                      //MIENTRAS NO SE PULSE 0 EN EL MENÚ NO CAMBIA LA VARIABLE noSalir DE TRUE A FALSE
        }
        #region MÉTODOS
        #region PINTA MENU
        private static void LimpiaYPintaMenuPrincipal2()
        {
            Console.Clear();
            PintaOpciones("EDITAR EMPLEADOS", new string[] { "Editar nombre", "Editar apellidos", "Editar edad", "Editar sueldo", "Editar fecha contrato" }, ConsoleColor.Red, ConsoleColor.Yellow);
        }
        private static void LimpiaYPintaMenuPrincipal()
        {
            Console.Clear();
            PintaOpciones("EMPLEADOS", new string[] { "Añadir empleado", "Buscar", "Editar", "Listar", "Añadir aleatoriamente" }, ConsoleColor.Red, ConsoleColor.Yellow);
        }
        private static void PintaMarco(int posicionXIzqSup, int posicionYIzqSup, int posicionXDerInf, int posicionYDerInf)
        {
            int ancho = posicionXDerInf - posicionXIzqSup;
            int alto = posicionYDerInf - posicionYIzqSup;
            //PINTA ESQUINA SUPERIOR IZQUIERDA
            Console.Write("╔");
            //PINTA BORDE SUPERIOR
            for (int i = 0; i < ancho - 1; i++)
            {
                Console.Write("═");                         //X --> POSICIÓN LATERAL        Y --> POSICIÓN VERTICAL
            }                                               //Coordenada1 --> X      (0,0)╔════════════════════════╗
            //PINTA ESQUINA SUPERIOR DERECHA                //Coordenada1 --> Y           ║        TITULO          ║    <-- TITULO
            Console.WriteLine("╗");                         //Coordenada2 --> Y           ╠════════════════════════╣        string[] opciones
            //PINTA LATERAL IZQUIERDO 1                     //                            ║   1. Opcion1           ║    <-- opciones[0]
            Console.WriteLine("║");                         //                            ║   2. Opcion2           ║    <-- opciones[1]
            Console.WriteLine("╠");                         //                            ╠════════════════════════╣
            //PINTA LATERAL IZQUIERDO 2                     //                            ║        elegir:_        ║    <-- introducir opción
            for (int i = 0; i < alto - 5; i++)              //                            ╚════════════════════════╝(7,25)
            {                                               //                              ancho= 25;
                Console.WriteLine("║");                     //                              alto=  7;
            }                                               //                              altoNoUtil= 4; (4 bordes separadores)
            //PINTAL LATERAL IZQUIERDO 3
            Console.WriteLine("╠");
            Console.WriteLine("║");
            //PINTA ESQUINA INFERIOR IZQUIERDA                                              anchoNoUtil=3; (1x2 bordes laterales + 1 espacio antes de escribir)
            Console.Write("╚");
            //PINTA BORDE INFERIOR
            for (int i = 0; i < ancho - 1; i++)
            {
                Console.Write("═");
            }
            //PINTA ESQUINA INFERIOR DERECHA
            Console.Write("╝");
            //PINTA LATERAL DERECHO 1
            Console.SetCursorPosition(posicionXDerInf, posicionYIzqSup + 1);
            Console.WriteLine("║");
            Console.CursorLeft = posicionXDerInf;
            Console.WriteLine("╣");
            Console.CursorLeft = posicionXDerInf;
            //PINTA LATERAL DERECHO 2
            for (int i = 0; i < alto - 5; i++)
            {
                Console.WriteLine("║");
                Console.CursorLeft = posicionXDerInf;
            }
            //PINTA LATERAL DERECHO 3
            Console.WriteLine("╣");
            Console.CursorLeft = posicionXDerInf;
            Console.WriteLine("║");
            //PINTA SEPARADOR TITULO-OPCIONES
            Console.SetCursorPosition(1, 2);
            for (int i = 0; i < ancho - 1; i++)
            {
                Console.Write("═");
            }
            //PINTA SEPARADOR OPCIONES-ELEGIR
            Console.SetCursorPosition(1, 2 + alto - 4);
            for (int i = 0; i < ancho - 1; i++)
            {
                Console.Write("═");
            }

        }
        public static void PintaOpciones(string titulo, string[] opciones, ConsoleColor marco, ConsoleColor texto)
        {
            int nOpciones = opciones.Length;
            int opcionMasLarga = 13;
            foreach (string opcion in opciones)
            {
                if (opcion.Length > opcionMasLarga)
                {
                    opcionMasLarga = opcion.Length;
                }
            }
            int anchoMenu = opcionMasLarga + 5;
            int largoMenu = nOpciones + 5;
            Console.ForegroundColor = marco;
            PintaMarco(0, 0, anchoMenu, largoMenu);
            Console.ForegroundColor = texto;
            PintaLetras(titulo, opciones);

        }
        private static void PintaLetras(string titulo, string[] opciones)
        {

            Console.SetCursorPosition(2, 1);
            Console.Write(titulo);
            Console.SetCursorPosition(2, 3);
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + opciones[i]);
                Console.CursorLeft = 2;
            }
            Console.SetCursorPosition(1, opciones.Length + 6);
            Console.WriteLine("Pulse 0 para salir");
            Console.SetCursorPosition(2, 2 + opciones.Length + 2);
            Console.Write("Elige opción: ");
        }
        #endregion
        #region AÑADIR
        /// <summary>
        /// Devuelve un array con el empleado introducido por el usuario
        /// </summary>
        /// <param name="empleados">Array de estructura Empleado</param>
        /// <returns>Array de estructuraa Empleado</returns>
        public static Empleado[] AddEmpleado(Empleado[] empleados)
        {
            string nombre;
            string apellidos;
            int edad;
            double sueldo;
            DateTime fechaContrato;
            string auxiliar = "";

            //COMPROBAR QUE EL ARRAY NO ESTÁ LLENO Y SI LO ESTÁ AMPLIARLO
            int rellenoHasta = EmpleadosLength(empleados);
            if (rellenoHasta == empleados.Length)   //SI EL NÚMERO DE DATOS INTRODUCIDOS ES IGUAL AL TAMAÑO DEL ARRAY AMPLIARLO
                empleados = CopiarArray(empleados, empleados.Length + 10);

            #region INTRODUCIR DATOS
            try
            {
                Console.Write("Introduce nombre: ");
                nombre = Console.ReadLine();
                empleados[rellenoHasta].Nombre = nombre;

                Console.Write("Introduce apellidos: ");
                apellidos = Console.ReadLine();
                empleados[rellenoHasta].Apellidos = apellidos;

                Console.Write("Introduce edad: ");
                auxiliar = Console.ReadLine();
                while (!int.TryParse(auxiliar, out edad) || edad > 120)
                {
                    Console.Write("Introduzca una edad válida: ");
                    auxiliar = Console.ReadLine();
                }
                empleados[rellenoHasta].Edad = edad;

                Console.Write("Introduce fecha del contrato: ");
                auxiliar = Console.ReadLine();
                while (!DateTime.TryParse(auxiliar, out fechaContrato))
                {
                    Console.Write("Introduzca una fecha válida: ");
                    auxiliar = Console.ReadLine();
                }
                empleados[rellenoHasta].FechaContrato = fechaContrato;

                Console.Write("Introduce sueldo: ");
                auxiliar = Console.ReadLine();
                while (!double.TryParse(auxiliar, out sueldo) || sueldo < 0)
                {
                    Console.Write("Introduzca un sueldo válido: ");
                    auxiliar = Console.ReadLine();
                }
                empleados[rellenoHasta].Sueldo = sueldo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion
            //Empleado empleado = new Empleado(nombre, apellidos, edad, sueldo, fechaContrato);
            //empleados[rellenoHasta] = empleado;
            return empleados;
        }
        /// <summary>
        /// Devuelve un array con el empleado introducido por el usuario
        /// </summary>
        /// <param name="empleados">Array de estructura Empleado</param>
        /// <returns>Array de estructuraa Empleado</returns>
        public static Empleado[] AddEmpleado(Empleado[] empleados, bool limpiaPantalla)
        {
            string nombre;
            string apellidos;
            int edad;
            double sueldo;
            DateTime fechaContrato;
            string auxiliar = "";

            if (limpiaPantalla)
                Console.Clear();

            //COMPROBAR QUE EL ARRAY NO ESTÁ LLENO Y SI LO ESTÁ AMPLIARLO
            int rellenoHasta = EmpleadosLength(empleados);
            if (rellenoHasta == empleados.Length)   //SI EL NÚMERO DE DATOS INTRODUCIDOS ES IGUAL AL TAMAÑO DEL ARRAY AMPLIARLO
                empleados = CopiarArray(empleados, empleados.Length + 10);

            #region INTRODUCIR DATOS
            try
            {
                Console.Write("Introduce nombre: ");
                nombre = Console.ReadLine();
                empleados[rellenoHasta].Nombre = nombre;

                Console.Write("Introduce apellidos: ");
                apellidos = Console.ReadLine();
                empleados[rellenoHasta].Apellidos = apellidos;

                Console.Write("Introduce edad: ");
                auxiliar = Console.ReadLine();
                while (!int.TryParse(auxiliar, out edad) || edad > 120)
                {
                    Console.Write("Introduzca una edad válida: ");
                    auxiliar = Console.ReadLine();
                }
                empleados[rellenoHasta].Edad = edad;

                Console.Write("Introduce fecha del contrato: ");
                auxiliar = Console.ReadLine();
                while (!DateTime.TryParse(auxiliar, out fechaContrato))
                {
                    Console.Write("Introduzca una fecha válida: ");
                    auxiliar = Console.ReadLine();
                }
                empleados[rellenoHasta].FechaContrato = fechaContrato;

                Console.Write("Introduce sueldo: ");
                auxiliar = Console.ReadLine();
                while (!double.TryParse(auxiliar, out sueldo) || sueldo < 0)
                {
                    Console.Write("Introduzca un sueldo válido: ");
                    auxiliar = Console.ReadLine();
                }
                empleados[rellenoHasta].Sueldo = sueldo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion
            //Empleado empleado = new Empleado(nombre, apellidos, edad, sueldo, fechaContrato);
            //empleados[rellenoHasta] = empleado;
            return empleados;
        }
        /// <summary>
        /// Devuelve un array relleno de nRandoms personas aleatorias
        /// </summary>
        /// <param name="empleados">Array a rellenar</param>
        /// <param name="nRandoms">Número de personas aleatorias a generar</param>
        /// <param name="rnd">Semilla para generar aleatorio</param>
        /// <returns>Array relleno con las personas generadas aleatoriamente</returns>
        public static Empleado[] AddEmpleado(Empleado[] empleados, int nRandoms, Random rnd)
        {
            //ARRAY NOMBRES HOMBRE
            string[] nombresH = new string[] { "Pepe","José","Carlos", "Jesús", "Bartolo","Mario",
                "Juan","Pedro", "Antonio", "Francisco","Paco","Javier","Bilal","Marek", "Manuel",
                "Manolo"};
            //ARRAY NOMBRES MUJER
            string[] nombresM = new string[] {"Pepa","Josefa","Carla", "Lola", "Rosa", "Maria",
                "Juana","Antonia", "Ana", "Francisca", "Paqui","Manuela","Cristina","Marina","Belen"};
            //APELLIDOS
            string[] apellidos = new string[] { "Martin", "Lopez", "Salas", "Mateo", "Abas", "Del Rio","Gómez","Gamez","Florido","Flores","Quintana",
                "Vera", "Ramirez", "Ponce", "Díaz", "Vicario","Berlanga", "Gamboa", "Campos" };

            //CAMPOS
            int edad;
            double sueldo;
            DateTime fechaContrato;

            //RELLENAR HASTA nRandoms 
            for (int i = 0; i < nRandoms; i++)
            {
                //COMPROBAR QUE EL ARRAY NO ESTÁ LLENO Y SI LO ESTÁ AMPLIARLO
                int rellenoHasta = EmpleadosLength(empleados);
                if (rellenoHasta == empleados.Length - 1) //SI EL NÚMERO DE DATOS INTRODUCIDOS ES IGUAL AL TAMAÑO DEL ARRAY AMPLIARLO
                    empleados = CopiarArray(empleados, empleados.Length + 10);

                #region INTRODUCIR DATOS
                string segundoNombre = "";  //VARIABLE PARA GENERAR O NO SEGUNDO NOMBRE 
                int genero = rnd.Next(2); //0 --> HOMBRE, 1 --> MUJER
                if (genero == 0) //SI GENERO HOMBRE
                {
                    segundoNombre = rnd.Next(2) == 1 ? nombresH[rnd.Next(nombresH.Length)] : "";    //SI ALEATORIO = 1 --> GENERA SEGUNDO NOMBRE;
                    empleados[rellenoHasta].Nombre = nombresH[rnd.Next(nombresH.Length)] + " " + segundoNombre; //NOMBRE = NOMBRE ALEA + SEGUNDO NOMBRE
                }
                else            //SI GENERO MUJER
                {
                    segundoNombre = rnd.Next(2) == 1 ? nombresM[rnd.Next(nombresM.Length)] : "";
                    empleados[rellenoHasta].Nombre = nombresM[rnd.Next(nombresM.Length)] + " " + segundoNombre;
                }

                //APELLIDOS ALEATORIOS
                empleados[rellenoHasta].Apellidos = apellidos[rnd.Next(apellidos.Length)] + " " + apellidos[rnd.Next(apellidos.Length)];

                //EDAD MÁXIMA GENERADA 67
                edad = rnd.Next(68);
                empleados[rellenoHasta].Edad = edad;

                //FECHA CONTRATO --> (1990-2019/1-12/1-28) FECHA VÁLIDA PERO FALTAN EN MUCHOS MESES DIAS 29, 30 Y 31
                fechaContrato = new DateTime(rnd.Next(1990, 2020), rnd.Next(1, 13), rnd.Next(1, 29));
                empleados[rellenoHasta].FechaContrato = fechaContrato;

                //SUELDO ENTRE 1000 Y 1800
                sueldo = rnd.Next(1000, 1801);
                empleados[rellenoHasta].Sueldo = sueldo;
                #endregion
            }

            return empleados;   //DEVUELVE ARRAY
        }
        #endregion
        #region EMPLEADOS RELLENOS Y COPIAR 
        /// <summary>
        /// Devuelve el número de empleados introducidos en el array Empleado[]
        /// </summary>
        /// <param name="empleados">Array Empleado[] que se cuentan los Empleado introducido</param>
        /// <returns>Posición donde se encuentra el último dato introducido</returns>
        public static int EmpleadosLength(Empleado[] empleados)
        {
            for (int i = 0; i < empleados.Length; i++)  //RECORRE ARRAY HASTA EL FINAL
            {
                if (empleados[i].Apellidos == null && empleados[i].Nombre == null) //SI EL NOMBRE O EL APELLIDO ES NULL DEVUELVE LA POSICIÓN
                {
                    return i;
                }
            }
            return empleados.Length;  //SI NO ENCUENTRA NINGUNO COMO NULL ESTÁ RELLENO Y SU POSICIÓN FINAL ES LENGTH - 1
        }
        /// <summary>
        /// Devuelve una copia del array pasado como parámetro con el tamaño indicado. Si tamaño nuevo es menor que la copia, copia hasta dichos datos
        /// </summary>
        /// <param name="arrayACopiar">Array de Empleado (Empleado[]) que es copiado</param>
        /// <param name="tamanoNuevoArray">Tamaño de la copia</param>
        /// <returns></returns>
        public static Empleado[] CopiarArray(Empleado[] arrayACopiar, int tamanoNuevoArray)
        {
            Empleado[] matrizCopiada = new Empleado[tamanoNuevoArray]; //METRIZ A DEVOLVER
            int tamanoArray;    //VARIABLE AUXILIAR PARA ASIGNAR EL TAMAÑO DEL ARRAY EN EL MÉTODO

            if (tamanoNuevoArray >= arrayACopiar.Length) //SI EL TAMAÑO DEL NUEVO ARRAY ES MAYOR O IGUAL AL TAMAÑO DEL ARRAY A COPIAR
                tamanoArray = arrayACopiar.Length;      //RECORRERÁ HASTA LA LONGITUD DEL ARRAY A COPIAR
            else                                        //SINO
                tamanoArray = tamanoNuevoArray;         //RECORRERÁ HASTA EL TAMAÑO ASIGNADO AL NUEVO ARRAY

            //RECORRE HASTA EL TAMAÑO ASIGNADO RELLENANDO EL NUEVO ARRAY
            for (int i = 0; i < tamanoArray; i++)
            {
                matrizCopiada[i].Nombre = arrayACopiar[i].Nombre;
                matrizCopiada[i].Apellidos = arrayACopiar[i].Apellidos;
                matrizCopiada[i].Edad = arrayACopiar[i].Edad;
                matrizCopiada[i].FechaContrato = arrayACopiar[i].FechaContrato;
                matrizCopiada[i].Sueldo = arrayACopiar[i].Sueldo;
            }

            return matrizCopiada;                   //DEVUELVE EL ARRAY COPIADO
        }
        #endregion
        #region LISTAR
        /// <summary>
        /// Pinta por consola todos los elementos del array Empleado[] con un formato determinado.
        /// </summary>
        /// <param name="empleados">Array que contiene la estructura Empleado</param>
        /// <param name="limpiaPantalla">True para limpiar pantalla antes de devolver el dato, False para lo contrario</param>
        /// <returns>Devuelve el string con los Empleados con un formato determinado</returns>
        public static string ListaString(Empleado[] empleados, bool limpiaPantalla)
        {
            if (limpiaPantalla)  //SI BOOL = TRUE --> LIMPIA LA PANTALLA, SINO NO.
                Console.Clear();

            //VARIABLE QUE RECOGE EL NOMBRE DE LOS CAMPOS Y LUEGO ESCRIBE LOS DISTINTOS ELEMENTOS CON SALTOS DE LINEA.
            string resultado = "LISTADO DE EMPLEADOS\n" + "".PadLeft(86, '▀') + "\n" + " Nº".PadRight(6) + "Nombre".PadRight(20).ToUpper() +
                "Apellidos".PadRight(20).ToUpper() + "Edad".ToString().PadRight(10) + "Sueldo".ToString().PadRight(14) +
                "Fecha Contrato\n" + "".PadLeft(86, '▀') + "\n";
            int recorre = EmpleadosLength(empleados);   //RECORRE HASTA DONDE ESTÁ RELLENO EL ARRAY 
            for (int i = 0; i < recorre; i++)
            {
                resultado += " " + (i + 1).ToString().PadRight(5) + empleados[i].ToString() + "\n";  //CONVIERTE A STRING EL EMPLEADO
            }
            Console.WriteLine("".PadLeft(86, '▀'));
            return resultado;
        }
        /// <summary>
        /// Pinta por consola todos los elementos del array Empleado[] con un formato determinado.
        /// </summary>
        /// <param name="empleados">Array que contiene la estructura Empleado</param>
        /// <returns>Devuelve el string con los Empleados con un formato determinado</returns>
        public static string ListaString(Empleado[] empleados)
        {
            //VARIABLE QUE RECOGE EL NOMBRE DE LOS CAMPOS Y LUEGO ESCRIBE LOS DISTINTOS ELEMENTOS CON SALTOS DE LINEA.
            string resultado = "LISTADO DE EMPLEADOS\n" + "".PadLeft(79, '▀') + "\n" + "Nombre".PadRight(20).ToUpper() +
                "Apellidos".PadRight(20).ToUpper() + "Edad".ToString().PadRight(10) + "Sueldo".ToString().PadRight(14) +
                "Fecha Contrato\n" + "".PadLeft(79, '▀') + "\n";
            int recorre = EmpleadosLength(empleados);   //RECORRE HASTA DONDE ESTÁ RELLENO EL ARRAY 
            for (int i = 0; i < recorre; i++)
            {
                resultado += empleados[i].ToString() + "\n";  //CONVIERTE A STRING EL EMPLEADO
            }
            Console.WriteLine("".PadLeft(79, '▀'));
            return resultado;
        }
        #endregion
        #region BUSCAR
        /// <summary>
        /// Devuelve un array de empleados con los empleados que coincidan con el parámetro de búsqueda pasado.
        /// </summary>
        /// <param name="array">Array de personas sobre el que se vá a buscar.</param>
        /// <param name="parametroBusqueda">Párametro que busca en el listado de personas (nombre, apellido, edad, sueldo y fecha contrato).</param>
        /// <returns>Devuelve array con el resultado buscado.</returns>
        public static Empleado[] BuscarEmpleado(Empleado[] array, string parametroBusqueda)
        {
            int cantidadEmpleados = EmpleadosLength(array);             //CANTIDAD DE EMPLEADOS INTRODUCIDOS EN EL ORIGINAL
            Empleado[] auxiliar = new Empleado[cantidadEmpleados];     //ARRAY RESULTADO CON EL MISMO TAMAÑO QUE EL ORIGINAL
            int contadorEncontrados = 0;                                //CONTADOR CON LOS EMPLEADOS ENCONTRADOS
            for (int i = 0; i < cantidadEmpleados; i++)                //RECORRER ARRAY ORIGINAL
            {
                if (array[i].ToString().ToUpper().Contains(parametroBusqueda.ToUpper()))    //SI ENCUENTRAS ALGUNO QUE CONTENGA EL PARÁMETRO DE BÚSQUEDA INTRODUCIDO
                {
                    auxiliar[contadorEncontrados] = array[i];          //AÑADIR AL RESULTADO
                    contadorEncontrados++;                              //Y AUMENTAR CONTADOR DE RESULTADOS
                }
            }
            Empleado[] resultado = new Empleado[contadorEncontrados];
            Array.Copy(auxiliar, resultado, contadorEncontrados);      //CREAR ARRAY DE TAMAÑO AL NÚMERO DE RESULTADOS
            return resultado;                                           //DEVOLVER EL RESULTADO
        }
        #endregion
        #region EDITAR
        /// <summary>
        /// Modifica el nombre de un empleado en una posición determinada.
        /// </summary>
        /// <param name="array">Array a modificar</param>
        /// <param name="posicion">Posición del empleado a modificar (empienza en 1). Si menor que 1 o mayor al máximo dentro del array Excepción.</param>
        /// <param name="nombre">Nombre nuevo del empleado</param>
        public static void EditaNombre(Empleado[] array, int posicion, string nombre)
        {
            posicion--;     //DISMINUYE POSICIÓN PARA ADECUAR A POSICIÓN DEL ARRAY RESPECTO A LA MOSTRADA
            int posMaxima = EmpleadosLength(array); //POSICIÓN MÁXIMA CON DATOS

            if (posicion < 0 || posicion > posMaxima) //SI POSICIÓN ESTÁ FUERA DE LOS LÍMITES EXCEPCIÓN
                throw new IndexOutOfRangeException();
            else                                    //SINO MODIFICA NOMBRE DEL ARRAY EN LA POSICIÓN INDICADA
                array[posicion].Nombre = nombre;
        }
        /// <summary>
        /// Modifica el apellido de un empleado en una posición determinada.
        /// </summary>
        /// <param name="array">Array a modificar</param>
        /// <param name="posicion">Posición del empleado a modificar (empienza en 1). Si menor que 1 o mayor al máximo dentro del array Excepción.</param>
        /// <param name="apellidos">Apellido nuevo del empleado</param>
        public static void EditaApellido(Empleado[] array, int posicion, string apellidos)
        {
            posicion--;     //DISMINUYE POSICIÓN PARA ADECUAR A POSICIÓN DEL ARRAY RESPECTO A LA MOSTRADA
            int posMaxima = EmpleadosLength(array); //POSICIÓN MÁXIMA CON DATOS

            if (posicion < 0 || posicion > posMaxima) //SI POSICIÓN ESTÁ FUERA DE LOS LÍMITES EXCEPCIÓN
                throw new IndexOutOfRangeException();
            else                                    //SINO MODIFICA APELLIDOS DEL ARRAY EN LA POSICIÓN INDICADA
                array[posicion].Apellidos = apellidos;
        }
        /// <summary>
        /// Modifica la edad de un empleado en una posición determinada.
        /// </summary>
        /// <param name="array">Array a modificar</param>
        /// <param name="posicion">Posición del empleado a modificar (empienza en 1). Si menor que 1 o mayor al máximo dentro del array Excepción.</param>
        /// <param name="edad">Edad nueva del empleado</param>
        public static void EditaEdad(Empleado[] array, int posicion, int edad)
        {
            posicion--;     //DISMINUYE POSICIÓN PARA ADECUAR A POSICIÓN DEL ARRAY RESPECTO A LA MOSTRADA
            int posMaxima = EmpleadosLength(array); //POSICIÓN MÁXIMA CON DATOS

            if (posicion < 0 || posicion > posMaxima) //SI POSICIÓN ESTÁ FUERA DE LOS LÍMITES EXCEPCIÓN
                throw new IndexOutOfRangeException();
            else                                    //SINO MODIFICA EDAD DEL ARRAY EN LA POSICIÓN INDICADA
                array[posicion].Edad = edad;
        }
        /// <summary>
        /// Modifica el sueldo de un empleado en una posición determinada.
        /// </summary>
        /// <param name="array">Array a modificar</param>
        /// <param name="posicion">Posición del empleado a modificar (empienza en 1). Si menor que 1 o mayor al máximo dentro del array Excepción.</param>
        /// <param name="sueldo">Sueldo nuevo del empleado</param>
        public static void EditaSueldo(Empleado[] array, int posicion, double sueldo)
        {
            posicion--;     //DISMINUYE POSICIÓN PARA ADECUAR A POSICIÓN DEL ARRAY RESPECTO A LA MOSTRADA
            int posMaxima = EmpleadosLength(array); //POSICIÓN MÁXIMA CON DATOS

            if (posicion < 0 || posicion > posMaxima) //SI POSICIÓN ESTÁ FUERA DE LOS LÍMITES EXCEPCIÓN
                throw new IndexOutOfRangeException();
            else                                    //SINO MODIFICA SUELDO DEL ARRAY EN LA POSICIÓN INDICADA
                array[posicion].Sueldo = sueldo;
        }
        /// <summary>
        /// Modifica la fecha de contrato de un empleado en una posición determinada.
        /// </summary>
        /// <param name="array">Array a modificar</param>
        /// <param name="posicion">Posición del empleado a modificar (empienza en 1). Si menor que 1 o mayor al máximo dentro del array Excepción.</param>
        /// <param name="fechaContrato">Nueva fecha de contrato del empleado</param>
        public static void EditaFechaContrato(Empleado[] array, int posicion, DateTime fechaContrato)
        {
            posicion--;     //DISMINUYE POSICIÓN PARA ADECUAR A POSICIÓN DEL ARRAY RESPECTO A LA MOSTRADA
            int posMaxima = EmpleadosLength(array); //POSICIÓN MÁXIMA CON DATOS

            if (posicion < 0 || posicion > posMaxima) //SI POSICIÓN ESTÁ FUERA DE LOS LÍMITES EXCEPCIÓN
                throw new IndexOutOfRangeException();
            else                                    //SINO MODIFICA FECHACONTRATO DEL ARRAY EN LA POSICIÓN INDICADA
                array[posicion].FechaContrato = fechaContrato;
        }
        #endregion
        #endregion
    }
}
