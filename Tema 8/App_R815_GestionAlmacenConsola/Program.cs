using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_R815_GestionAlmacenConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();

            Productos productos = new Productos();
            productos.evtBorrarProducto += BorrarRegistro;
            productos.evtBorrarFichero += BorrarFicheroDatos;
            //RellenarPruebas(productos);                 //PARA PRUEBAS

            do
            {
                PintarMenu();
                tecla = Console.ReadKey();
                Console.Clear();
                switch (tecla.KeyChar)
                {
                    case '0':
                        // Sale del bucle                 TODO: poner animación...
                        break;
                    case '1':   // Alta artículos
                        productos.AnadirConsola(0, 0);
                        break;
                    case '2':   // Baja artículos
                        productos.EliminarConsola();
                        break;
                    case '3':   //Consultar un artículo
                        productos.MostrarProductoConsola();
                        break;
                    case '4':   //Modificar un artículo
                        productos.MenuEditar();
                        break;
                    case '5':   //Listar ordenado por código
                        productos.OrdenarPorCodigo();
                        productos.ListarMenuConsola();
                        break;
                    case '6':   //Listar ordenado por nombre
                        productos.OrdenarPorNombre();
                        productos.ListarMenuConsola();
                        break;
                    case '7':   //Generar HTML
                        string rutaFicheroHtml = productos.GenerarHtml();
                        System.Diagnostics.Process.Start(rutaFicheroHtml);
                        break;
                    case '8':   //Generar fichero
                        productos.CrearFichero();
                        break;
                    case '9':   //Cargar fichero
                        productos.LeerFichero(false);
                        break;
                }

                if(tecla.KeyChar == '1' || tecla.KeyChar == '2' || tecla.KeyChar == '3' || tecla.KeyChar == '4' || tecla.KeyChar == '5')
                {
                    Console.ReadLine();
                }
            } while (tecla.KeyChar!='0');
        }
        private static void BorrarFicheroDatos(out bool respuesta, string ruta)
        {
            Console.WriteLine("¿Deseas eliminar el fichero {0}? (S: Sí, N: No): ",ruta);
            string texto;
            if ((texto = Console.ReadLine().ToUpper()).Equals("S"))
            {
                respuesta = true;
            }
            else
            {
                respuesta = false;
            }
        }  
        private static void BorrarRegistro(out bool respuesta,Producto producto)
        {       
            Console.WriteLine(producto.ToLargeString());
            string linea;
            Console.Write("\n¿Deseas eliminarlo?(S: Si, N: No): ");
            if ((linea=Console.ReadLine()).Equals("S")|| linea.Equals("s"))
            {
                respuesta = true;
            }
            else
            {
                respuesta = false;
            }
        }
        public static void PintarMenu()
        {
            Console.Clear();
            App_R701_MenuPrincipal.MenuPrincipal menu = new App_R701_MenuPrincipal.MenuPrincipal("  MENÚ PRINCIPAL",
                new string[] { "1. Alta de artículos","2. Baja de artículos","3. Consultar un artículo","4. Modificar un artículo",
                "5. Listar artículos ordenados por código","6. Listar artículos ordenados por nombre","7. Generar documento HTML",
                "8. Crear fichero","9. Cargar fichero","","      0 - Para salir" }, ConsoleColor.Red, App_R701_MenuPrincipal.TipoMarco.Doble,
                App_R701_MenuPrincipal.EstiloTexto.alineadoIzquierda);
            menu.Pintar(false);
        }
        public static void RellenarPruebas(Productos productos)
        {
            for (int i = 0; i < 100; i++)
            {
                productos.Anadir("nombre" + (i + 1).ToString(), i, i * 100," asdf");
            }
        }
        public static void BorrarPruebas(Productos productos)
        {
            for (int i = 20; i < 80; i++)
            {
                productos.Eliminar(i);
            }
        }
    }
}
