using System;

namespace App_R4E8_Mayus
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla = new ConsoleKeyInfo();
            Console.WriteLine("Programa que transforma todo lo que escribas a mayúsculas");
            Console.WriteLine("* para salir");
            
            do
            {
                Console.Write(Mayus(Console.ReadKey(true)));
            } while (tecla.KeyChar!='*');

        }
        public static char Mayus(ConsoleKeyInfo tecla)
        {
            int diferenciaMayusMinus = (int)'a' - (int)'A';
            
            if (tecla.KeyChar>='a'&&tecla.KeyChar<='z')//RANGO a-z
            {
                return (char)(tecla.KeyChar - diferenciaMayusMinus);
            }
            else if (tecla.KeyChar == 'ñ')//ñ
            {
                return 'Ñ';
            }
            else if (tecla.KeyChar=='á')//´
            {
                return 'Á';
            }
            else if (tecla.KeyChar == 'é')
            {
                return 'É';
            }
            else if (tecla.KeyChar == 'í')
            {
                return 'Í';
            }
            else if (tecla.KeyChar == 'ó')
            {
                return 'Ó';
            }
            else if (tecla.KeyChar == 'ú')
            {
                return 'Ú';
            }
            else if (tecla.KeyChar == 'à')//`
            {
                return 'À';
            }
            else if (tecla.KeyChar == 'è')
            {
                return 'È';
            }
            else if (tecla.KeyChar == 'ì')
            {
                return 'Ì';
            }
            else if (tecla.KeyChar == 'ò')
            {
                return 'Ò';
            }
            else if (tecla.KeyChar == 'ù')
            {
                return 'Ù';
            }
            else if (tecla.KeyChar == 'ä')//¨
            {
                return 'Ä';
            }
            else if (tecla.KeyChar == 'ë')
            {
                return 'Ë';
            }
            else if (tecla.KeyChar == 'ï')
            {
                return 'Ï';
            }
            else if (tecla.KeyChar == 'ö')
            {
                return 'Ö';
            }
            else if (tecla.KeyChar == 'ü')
            {
                return 'Ü';
            }
            else if (tecla.KeyChar == 'ç')
            {
                return 'Ç';
            }
            else
            {
                return tecla.KeyChar;
            }
        }
    }
}
