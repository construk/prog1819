using App_R701_MenuPrincipal;
using System;
using System.Collections.Generic;
using System.IO;

namespace App_R815_GestionAlmacenConsola
{
    #region Delegados
    delegate void dlgBorrarProducto(out bool respuesta, Producto producto);
    delegate void dlgBorrarFichero(out bool respuesta, string ruta);
    #endregion
    class Productos
    {
        #region Campos
        const int MAX_POR_PAGINA = 20;
        List<Producto> productos;
        int generadorCodProducto;
        int punteroListado;
        public event dlgBorrarProducto evtBorrarProducto;
        public event dlgBorrarFichero evtBorrarFichero;
        string ruta = @"./informacion.fran";
        #endregion
        #region Propiedades
        public Producto this[string nombreProducto]
        {
            get
            {
                try
                {
                    return productos[Buscar(nombreProducto)];
                }
                catch
                {
                    return new Producto();
                }
            }
            set
            {
                try
                {
                    productos[Buscar(nombreProducto)] = value;
                }
                catch
                {

                }
            }
        }
        public Producto this[int indiceColeccion]
        {
            get { return productos[indiceColeccion]; }
            set { productos[indiceColeccion] = value; }
        }
        /// <summary>
        /// Posición de la página mostrada del listado. Valor mínimo: 0, valor máximo: NumeroPáginas - 1.
        /// </summary>
        public int PunteroListado
        {
            get { return punteroListado; }
            set
            {
                if (productos.Count > 0)
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
        /// Número de páginas del listado.
        /// </summary>
        public int NumeroPaginas
        {
            get
            {
                if (productos.Count % MostrarPorPagina == 0)
                {
                    return productos.Count / MostrarPorPagina;
                }
                else
                {
                    return (productos.Count / MostrarPorPagina) + 1;
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
                if (productos.Count > MAX_POR_PAGINA)
                {
                    return MAX_POR_PAGINA;
                }
                else
                {
                    return productos.Count;
                }
            }
        }
        #endregion
        #region Constructor
        public Productos()
        {
            productos = new List<Producto>();
            generadorCodProducto = 1;
        }
        #endregion
        #region Métodos
        #region Métodos públicos
        #region Añadir
        public bool Anadir(string nombre, int cantidad, double precio, string comentario)
        {
            try
            {
                if (NombreDisponible(nombre))
                {
                    productos.Add(new Producto(generadorCodProducto++, nombre, cantidad, precio, comentario));
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
        public bool Anadir(Producto producto)
        {
            try
            {
                if (NombreDisponible(producto.Nombre))
                {
                    productos.Add(new Producto(producto.CodArticulo, producto.Nombre, producto.Existencias, producto.Precio, producto.Comentario));
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
        public bool Anadir(Producto producto, bool mantenerCodigo)
        {
            try
            {
                int codProd;
                if (mantenerCodigo)
                    codProd = producto.CodArticulo;
                else
                    codProd = generadorCodProducto++;

                if (NombreDisponible(producto.Nombre))
                {
                    productos.Add(new Producto(codProd, producto.Nombre, producto.Existencias, producto.Precio, producto.Comentario));
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
        #endregion
        #region Eliminar
        public bool Eliminar(int codProducto)
        {
            int posicion = Buscar(codProducto);

            if (posicion != -1)
            {
                bool borrar = false;
                if (evtBorrarProducto != null)
                {
                    evtBorrarProducto(out borrar, this[posicion]);
                }
                if (borrar)
                {
                    productos[posicion].Borrado = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentException("El código del producto no corresponde con ninguno existente.");
            }

        }
        #endregion
        #region Buscar
        public int Buscar(int codProducto)
        {
            bool encontrado = false;
            int contador = 0;
            int posProducto = -1;
            while (!encontrado && contador < productos.Count)
            {
                if (productos[contador].CodArticulo == codProducto && !productos[contador].Borrado)
                {
                    encontrado = true;
                    posProducto = contador;
                }
                contador++;
            }
            return posProducto;
        }
        public int Buscar(string nombre)
        {
            int posProducto = -1;
            int contador = 0;
            bool encontrado = false;
            while (!encontrado && contador < productos.Count)
            {
                if (productos[contador].Nombre.Equals(nombre) && !productos[contador].Borrado)
                {
                    posProducto = contador;
                    encontrado = true;
                }
                contador++;
            }
            return posProducto;
        }
        #endregion
        #region Editar
        public bool EditarNombre(int codProducto, string nuevoNombre)
        {
            int posProducto;
            if (NombreDisponible(nuevoNombre) && (posProducto = Buscar(codProducto)) != -1)
            {
                productos[posProducto].Nombre = nuevoNombre;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EditarPrecio(int codProducto, double nuevoPrecio)
        {
            int posProducto;
            if ((posProducto = Buscar(codProducto)) != -1)
            {
                productos[posProducto].Precio = nuevoPrecio;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EditarCantidad(int codProducto, int nuevaCantidad)
        {
            int posProducto;
            if ((posProducto = Buscar(codProducto)) != -1)
            {
                productos[posProducto].Existencias = nuevaCantidad;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EditarComentario(int codProducto, string nuevoComentario)
        {
            int posProducto;
            if ((posProducto = Buscar(codProducto)) != -1)
            {
                productos[posProducto].Comentario = nuevoComentario;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Ordenar
        public void OrdenarPorCodigo()
        {
            productos.Sort();
        }
        public void OrdenarPorNombre()
        {
            productos.Sort(new OrdenaProductoNombre());
        }
        #endregion
        #region Consola
        public void EditarNombreConsola(int codProducto, int posX, int posY)
        {
            int posProd = Buscar(codProducto);
            if (posProd != -1)
            {
                string aCambiar;
                Marcos marcoMenu = new Marcos(new Coordenada(posX, posY), new Coordenada(posX + 80, posY + 20), TipoMarco.Simple, ConsoleColor.Green);
                marcoMenu.Pinta(true, 1);
                Console.SetCursorPosition(posX + 2, posY + 1);
                Console.Write("Cod: {0} producto: {1}\n\n Introduce nuevo nombre del articulo: ", productos[posProd].CodArticulo.ToString("000"), productos[posProd].Nombre.TrimEnd(new char[] { ' ' }));
                aCambiar = Console.ReadLine();
                
                if (EditarNombre(codProducto, aCambiar))
                {
                    Console.WriteLine("Nombre cambiado correctamente.");
                    Console.WriteLine(productos[posProd].CodArticulo.ToString() + " " + productos[posProd].Nombre.TrimEnd(new char[] { ' ' }));
                }
                else
                {
                    Console.WriteLine("El nombre introducido ya existe.");
                }
            }
            else
            {
                Console.WriteLine("No se ha encontrado el producto con dicho código. ");
            }
        }
        public void EditarPrecioConsola(int codProducto, int posX, int posY)
        {
            int posProd = Buscar(codProducto);
            if (posProd != -1)
            {
                string aCambiar;
                Marcos marcoMenu = new Marcos(new Coordenada(posX, posY), new Coordenada(posX + 80, posY + 20), TipoMarco.Simple, ConsoleColor.Green);
                marcoMenu.Pinta(true, 1);
                Console.SetCursorPosition(posX + 2, posY + 1);
                Console.Write("Cod: {0} producto: {1} precio: {2}\n\n Introduce nuevo precio del articulo: ", productos[posProd].CodArticulo.ToString("000"),
                                productos[posProd].Nombre.TrimEnd(new char[] { ' ' }), productos[posProd].Precio);
                aCambiar = Console.ReadLine();
                Console.CursorTop++;
                Console.CursorLeft += 2;
                double aCambiar2;
                while (!double.TryParse(aCambiar, out aCambiar2)||aCambiar2<0)
                {
                    Console.CursorLeft = posX + 2;
                    Console.Write("Introduce un precio válido: ");
                    aCambiar = Console.ReadLine();
                }

                productos[posProd].Precio = aCambiar2;
                Console.WriteLine("Precio cambiado correctamente.");
                Console.WriteLine(productos[posProd].CodArticulo.ToString() + " " + productos[posProd].Nombre.TrimEnd(new char[] { ' ' }) + " " + productos[posProd].Precio);
            }
            else
            {
                Console.WriteLine("No se ha encontrado el producto con dicho código. ");
            }
        }
        public void EditarExistenciasConsola(int codProducto, int posX, int posY)
        {
            int posProd = Buscar(codProducto);
            if (posProd != -1)
            {
                string aCambiar;
                Marcos marcoMenu = new Marcos(new Coordenada(posX, posY), new Coordenada(posX + 80, posY + 20), TipoMarco.Simple, ConsoleColor.Green);
                marcoMenu.Pinta(true, 1);
                Console.SetCursorPosition(posX + 2, posY + 1);
                Console.Write("Cod: {0} producto: {1} existencias: {2}\n\n Introduce nueva cantidad para existencias del articulo: ", productos[posProd].CodArticulo.ToString("000"),
                                productos[posProd].Nombre.TrimEnd(new char[] { ' ' }), productos[posProd].Existencias);
                aCambiar = Console.ReadLine();
                int aCambiar2;
                Console.CursorTop++;
                Console.CursorLeft += 2;
                while (!int.TryParse(aCambiar, out aCambiar2)||aCambiar2<0)
                {
                    Console.CursorLeft = posX + 2;
                    Console.Write("Introduce una cantidad válida: ");
                    aCambiar = Console.ReadLine();
                }

                productos[posProd].Existencias = aCambiar2;
                Console.WriteLine("Existencias cambiadas correctamente.");
                Console.WriteLine(productos[posProd].CodArticulo.ToString() + " " + productos[posProd].Nombre.TrimEnd(new char[] { ' ' }) + " " +
                    productos[posProd].Existencias);
            }
            else
            {
                Console.WriteLine("No se ha encontrado el producto con dicho código. ");
            }
        }
        public void EditarComentarioConsola(int codProducto, int posX, int posY)
        {
            int posProd = Buscar(codProducto);
            if (posProd != -1)
            {
                string aCambiar;
                Marcos marcoMenu = new Marcos(new Coordenada(posX, posY), new Coordenada(posX + 80, posY + 20), TipoMarco.Simple, ConsoleColor.Green);
                marcoMenu.Pinta(true, 1);
                Console.SetCursorPosition(posX + 2, posY + 1);
                Console.Write("Cod: {0} producto: {1}\n\n  comentario: {2}\n\n  Introduce nuevo comentario: ",
                    productos[posProd].CodArticulo.ToString("000"), productos[posProd].Nombre.TrimEnd(new char[] { ' ' }), productos[posProd].Comentario);
                aCambiar = Console.ReadLine();
                Console.CursorTop++;
                Console.CursorLeft += 2;
                productos[posProd].Comentario = aCambiar;
                Console.WriteLine("Comentario cambiado correctamente.");
                Console.WriteLine(productos[posProd].CodArticulo.ToString() + " " + productos[posProd].Nombre.TrimEnd(new char[] { ' ' }) + "\n " + productos[posProd].Comentario);
            }
            else
            {
                Console.WriteLine("No se ha encontrado el producto con dicho código. ");
            }
        }
        public void MenuEditar()
        {
            if (productos.Count > 0)
            {
                ConsoleKeyInfo tecla = new ConsoleKeyInfo();
                do
                {
                    Console.Clear();
                    Console.CursorLeft = 4;
                    Console.WriteLine("    EDITAR PRODUCTO");
                    Console.WriteLine("=".PadRight(60), '=');
                    Console.CursorLeft = 4;
                    Console.WriteLine("1. Nombre");
                    Console.CursorLeft = 4;
                    Console.WriteLine("2. Existencias");
                    Console.CursorLeft = 4;
                    Console.WriteLine("3. Precio");
                    Console.CursorLeft = 4;
                    Console.WriteLine("4. Comentario");
                    Console.CursorTop += 3;
                    Console.CursorLeft = 10;
                    Console.WriteLine("0. Salir");
                    tecla = Console.ReadKey(true);

                    Console.Write("Introduce el número del producto a editar: ");
                    string aux = Console.ReadLine();
                    int numProd;
                    while (!int.TryParse(aux, out numProd)||numProd<1)
                    {
                        Console.Write("Introduce un número válido de código: ");
                        aux = Console.ReadLine();
                    }
                    Console.Clear();

                    switch (tecla.KeyChar)
                    {   //0 - SALIR
                        case '1':   //NOMBRE
                            EditarNombreConsola(numProd, 0, 0);
                            break;
                        case '2':   //CANTIDAD
                            EditarExistenciasConsola(numProd, 0, 0);
                            break;
                        case '3':   //PRECIO
                            EditarPrecioConsola(numProd, 0, 0);
                            break;
                        case '4':   //COMENTARIO
                            EditarComentarioConsola(numProd, 0, 0);
                            break;
                    }
                    Console.ReadLine();
                } while (tecla.KeyChar != '0');
            }
            else
            {
                Console.WriteLine("No hay elementos a editar...");
            }
            
        }
        public void Listar()
        {
            Console.Clear();
            Marcos marco = new Marcos(new Coordenada(), new Coordenada(70, 23), TipoMarco.Simple, ConsoleColor.Red);
            marco.Pinta(true, 1);

            Console.SetCursorPosition(2, 1);
            Console.WriteLine(
                "CÓDIGO".PadRight(8) +
                "NOMBRE".PadRight(16) +
                "PRECIO".PadLeft(14) +
                "PVP".PadLeft(14) +
                "EXISTENCIAS".PadLeft(15));
            Console.CursorTop++;
            int cantidadBorrados = 0;
            if (productos.Count > 0)
            {


                for (int i = punteroListado * MostrarPorPagina + cantidadBorrados; i < (punteroListado * MostrarPorPagina) + MostrarPorPagina + cantidadBorrados && i < productos.Count; i++)
                {
                    if (!productos[i].Borrado)
                    {
                        Console.CursorLeft = 2;
                        Console.WriteLine(productos[i].ToString());
                        Console.CursorLeft = 2;
                    }
                    else
                    {
                        cantidadBorrados++;
                    }
                }
            }
        }
        public void ListarMenuConsola()
        {
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();
            do
            {
                Listar();
                Console.WriteLine();
                Console.CursorLeft = 4;
                Console.SetCursorPosition(2, 24);
                if (productos.Count > 0)
                {
                    MostrarNumPaginas();
                }
                Console.WriteLine("<- (Atrás)  -> (Delante)  Esc (Salir)  A (Añadir)  B (Borrar) O (Ordenar por código) N (Ordenar por nombre)");
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
                        Console.Clear();
                        AnadirConsola(0, 0);
                        Console.WriteLine(" Pulsa ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.B:          //Borrar
                        Console.Clear();
                        EliminarConsola();
                        Console.WriteLine(" Pulsa ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.O:          //Ordenar por código
                        OrdenarPorCodigo();
                        break;
                    case ConsoleKey.N:          //Ordenar por nombre
                        OrdenarPorNombre();
                        break;
                }
            } while (tecla.Key != ConsoleKey.Escape);
        }
        public void AnadirConsola(int posX, int posY)
        {
            Marcos marcoMenu = new Marcos(new Coordenada(posX, posY), new Coordenada(posX + 80, posY + 20), TipoMarco.Simple, ConsoleColor.Green);
            marcoMenu.Pinta(true, 1);
            Console.SetCursorPosition(posX + 5, posY + 1);
            Console.WriteLine("AÑADIR UN PRODUCTO");
            Console.CursorTop++;
            Console.CursorLeft = posX + 2;

            string auxiliar;
            string nombre, comentario;
            int cantidad;
            double precio;

            Console.Write("Nombre del producto: ");
            nombre = Console.ReadLine();

            Console.CursorLeft = posX + 2;
            Console.Write("Cantidad: ");
            auxiliar = Console.ReadLine();

            while (!int.TryParse(auxiliar, out cantidad) || cantidad < 0)
            {
                Console.CursorLeft = posX + 2;
                Console.Write("Introduce cantidad válida: ");
                auxiliar = Console.ReadLine();
            }

            Console.CursorLeft = posX + 2;
            Console.Write("Precio: ");
            auxiliar = Console.ReadLine();

            while (!double.TryParse(auxiliar, out precio) || precio < 0)
            {
                Console.CursorLeft = posX + 2;
                Console.Write("Introduce precio válido: ");
                auxiliar = Console.ReadLine();
            }
            Console.CursorLeft = posX + 2;
            Console.Write("Comentario: ");
            comentario = Console.ReadLine();
            if (Anadir(nombre, cantidad, precio, comentario))
            {

                Console.SetCursorPosition(2, Console.WindowHeight - 4);
                Console.WriteLine("Producto añadido con éxito.");
            }
            else
            {
                Console.SetCursorPosition(2, Console.WindowHeight - 4);
                Console.WriteLine("El producto ya existe.");
            }

        }
        public void EliminarConsola()
        {
            Console.WriteLine("Introduce el número del artículo que deseas eliminar:");
            int numeroArticulo;
            string aux = Console.ReadLine();
            while (!int.TryParse(aux, out numeroArticulo))
            {
                Console.WriteLine("Introduce un número de artículo válido: ");
                aux = Console.ReadLine();
            }
            try
            {
                if (Eliminar(numeroArticulo))
                {
                    Console.SetCursorPosition(1, Console.WindowHeight - 4);
                    Console.Write("El artículo ha sido eliminado satistactoriamente.");
                }
                else
                {
                    Console.SetCursorPosition(1, Console.WindowHeight - 4);
                    Console.Write("No se ha borrado el artículo.");
                }
            }
            catch
            {
                Console.SetCursorPosition(1, Console.WindowHeight - 4);
                Console.Write("El número del artículo elegido no corresponde con ninguno registrado.");
            }
        }
        public void MostrarProductoConsola()
        {
            int codProducto;
            Console.WriteLine("Introduce el código del producto a buscar: ");
            string aux2 = Console.ReadLine();
            while (!int.TryParse(aux2, out codProducto))
            {
                Console.Write("Introduce un número de producto válido: ");
                aux2 = Console.ReadLine();
            }
            int posicionProducto;
            if ((posicionProducto = Buscar(codProducto)) != -1)
            {
                Console.WriteLine(productos[posicionProducto].ToLargeString());
            }
            else
            {
                Console.Write("Artículo no encontrado...");
            }
        }
        #endregion
        #region Ficheros
        public void CrearFichero()
        {
            bool borrar = false;
            if (File.Exists(ruta))
            {
                if (evtBorrarFichero != null)
                {
                    evtBorrarFichero(out borrar, ruta);
                }
                if (borrar)
                {
                    File.Delete(ruta);
                }
            }
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (Stream flujo = File.Open(ruta, FileMode.Create))
            {
                // var : BinaryFormatter [ IFormatter ]
                foreach (Producto p in productos)
                {
                    binaryFormatter.Serialize(flujo, p);
                }
            }
        }
        public void LeerFichero(bool borrarActualYRecuperarDelFichero)
        {
            if (borrarActualYRecuperarDelFichero)
            {
                if (File.Exists(ruta))
                {
                    File.Delete(ruta);
                }
            }
            using (Stream flujo = File.Open(ruta, borrarActualYRecuperarDelFichero ? FileMode.Create : FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                try
                {
                    while (true)
                    {
                        Anadir((Producto)binaryFormatter.Deserialize(flujo), borrarActualYRecuperarDelFichero);
                    }
                }
                catch
                {
                    Console.WriteLine("Archivo leido completamente.");
                }
            }
        }
        public string GenerarHtml()
        {
            using (Stream flujo = File.Open(Path.ChangeExtension(ruta, "html"), FileMode.Create))
            using (StreamWriter escritor = new StreamWriter(flujo))
            {
                string linea = "";
                linea = "<html><head><title>Datos productos</title></head><body><table border='1'>" +
                    "<tr><th>CÓDIGO</th><th>NOMBRE</th><th>PRECIO</th><th>PVP</th><th>CANTIDAD</th></tr>";
                foreach (Producto p in productos)
                {
                    linea += "<tr><td>" + p.CodArticulo + "</td><td>" + p.Nombre + "</td><td>" + p.Precio + "</td><td>" +
                        p.Pvp + "</td><td>" + p.Existencias + "</td></tr>";
                }
                linea += "</table></body></html>";
                escritor.WriteLine(linea);
                return Path.ChangeExtension(Path.GetFullPath(ruta), "html");
            }
        }
        #endregion
        #region Métodos informativos
        public bool NombreDisponible(string nombre)
        {
            nombre = nombre.PadRight(15);
            bool disponible = true;
            for(int i =0; i<productos.Count;i++)
            {
                if (productos[i].Nombre.Equals(nombre) && !productos[i].Borrado)
                {
                    disponible= false;
                }
            }
            return disponible;
        }
        #endregion
        #endregion
        #region Métodos privados
        //TODO: Hay que tener en cuenta los eliminados totales
        private void MostrarNumPaginas()
        {
            if (productos.Count % MostrarPorPagina == 0)
            {
                Console.WriteLine(punteroListado + 1 + "/" + NumeroPaginas + " Pág.");
            }
            else
            {
                Console.WriteLine(punteroListado + 1 + "/" + NumeroPaginas + " Pág.");
            }
        }
        #endregion
        #endregion
    }
}