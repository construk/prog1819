using System;
using System.Collections.Generic;
using System.Text;

namespace App_R619_DiccionarioRegistro
{
    class Registro
    {
        string apellido;
        string nombre;
        string telefono;
        public Registro()
        {
            this.apellido = null;
            this.nombre = null;
            this.telefono = null;
        }
        public Registro(string apellido, string nombre, string telefono)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.telefono = telefono;
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public override string ToString()
        {
            return nombre.PadRight(20, ' ')+apellido.PadRight(20,' ')+telefono.PadRight(15, ' ');
        }
    }
    class DiccionarioRegistro
    {
        int contadorRegistros;
        Dictionary<int, Registro> diccionarioRegistro;

        public DiccionarioRegistro()
        {
            diccionarioRegistro = new Dictionary<int, Registro>();
            contadorRegistros = 0;
        }
        private string AnadirCampo()
        {
            StringBuilder texto = new StringBuilder();
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();
            do
            {
                tecla = Console.ReadKey();
                if (char.IsLetterOrDigit(tecla.KeyChar)||char.IsSymbol(tecla.KeyChar))
                {
                    texto.Append(tecla.KeyChar);
                }
                else if (tecla.Key==ConsoleKey.Backspace)
                {
                    Console.Write(" ");
                    Console.CursorLeft--;
                    texto.Remove(texto.Length - 1, 1);
                }else if (tecla.Key == ConsoleKey.Enter)
                {
                    Console.CursorTop++;
                }
            } while (tecla.Key != ConsoleKey.Escape && tecla.Key != ConsoleKey.Enter);
            Console.WriteLine();
            if (tecla.Key==ConsoleKey.Enter)
            {
                return texto.ToString();
            }
            else
            {
                return null;
            }
        }
        public void AnadirRegistro()
        {
            Registro registro=new Registro();
            string textoIntroducido;
            
            Console.Write("Introduce apellido: ");
            if ((textoIntroducido = AnadirCampo())!=null)
            {
                registro.Apellido = textoIntroducido;
                Console.Write("Introduce nombre: ");
                if ((textoIntroducido = AnadirCampo()) != null)
                {
                    registro.Nombre = textoIntroducido;
                    Console.Write("Introduce nº de telefono: ");
                    if ((textoIntroducido = AnadirCampo()) != null)
                    {
                        registro.Telefono = textoIntroducido;
                        contadorRegistros++;
                        diccionarioRegistro.Add(contadorRegistros, registro);
                        Console.WriteLine("Registro añadido con éxito.");
                    }
                }
            }
            if (textoIntroducido==null)
            {
                Console.WriteLine("Registro cancelado.");
            }
        }
        public bool Delete()
        {
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();    
            int numeroElementoAEliminar;
            Console.WriteLine(this.ToString());
            Console.Write("Introduce el número del registro a eliminar: ");
            string texto;
            texto = AnadirCampo();
            if (texto!=null)
            {
                while (!int.TryParse(texto, out numeroElementoAEliminar))
                {
                    Console.Write("Introduce un dato válido: ");
                    texto = AnadirCampo();
                }

                if (diccionarioRegistro.ContainsKey(numeroElementoAEliminar))
                {
                    Console.WriteLine("¿Estás seguro que quiere eliminar el registro? [S/N] \n{0}\n", diccionarioRegistro[numeroElementoAEliminar].ToString());
                    tecla = Console.ReadKey(true);
                    if (tecla.Key==ConsoleKey.S)
                    {
                        diccionarioRegistro.Remove(numeroElementoAEliminar);
                        Console.WriteLine("Elemento eliminado con éxito.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Elemento no eliminado.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("El elemento indicado no existe.");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            string resultado="CLAVE".PadRight(7)+"NOMBRRE".PadRight(20,' ')+"APELLIDO".PadRight(20,' ')+"TELEFONO".PadRight(20,' ')+"\n";
            foreach (KeyValuePair<int, Registro> registro in diccionarioRegistro)
            {
                resultado+=registro.Key.ToString().PadRight(7) + registro.Value.ToString()+"\n";
            }
            return resultado;
        }
    }
    class Ejercicio19
    {
        static void Main(string[] args)
        {
            try
            {
                DiccionarioRegistro diccionario = new DiccionarioRegistro();
                ConsoleKeyInfo teclaMenu = new ConsoleKeyInfo();
                string auxiliar;
                
                do
                {
                    Console.Clear();                    //LimpiaPantalla
                    PintarMenu();                       //Pinta el menú
                    teclaMenu = Console.ReadKey(true);  //Lee la tecla de la opción del menú (sin verse)
                    switch (teclaMenu.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            diccionario.AnadirRegistro();
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            Console.WriteLine(diccionario.ToString());
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            diccionario.Delete();
                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:

                            break;
                    }
                    if (teclaMenu.Key != ConsoleKey.Escape)
                    {
                        Console.WriteLine("Pulsa Enter para volver al menú principal...");
                        Console.ReadLine();
                    }
                } while (teclaMenu.Key != ConsoleKey.Escape);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public static void PintarMenu()
        {
            Console.WriteLine("=".PadLeft(80, '='));
            Console.WriteLine("   MENU");
            Console.WriteLine("=".PadLeft(80, '='));
            Console.WriteLine(" 1 - Añadir");
            Console.WriteLine(" 2 - Listar");
            Console.WriteLine(" 3 - Eliminar");
            Console.WriteLine(" Esc - Salir");
            Console.WriteLine("=".PadLeft(80, '='));
        }
    }
}
