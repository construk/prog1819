using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_R3E10_7A99EsPrimo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce número");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine(EsPrimo(numero)); 
            Console.ReadLine();
        }
        private static bool EsPrimo(int numero)
        { 
            bool esPrimo = true;
            int i=2;
            if (numero<2)
	        {
		        return false;
	        }else if (numero<4)
	        {
                return true;
            }
            else
            {
                while(numero % i != 0 && i<=numero/2)
                {
                    i++;
                }
                return numero % i == 0 ? false : true;
            }
        }
    }
}
