/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		EncriptacionCesar
 *  Autor:		Francisco J. Gómez Florido
 *  Versión:		v 1.0 nov 2018
 *  Descripción:	Programa que encripta y desencripta mediante el algoritmo de Cesar
-------------------------------------------------------------------------------------------------------------*/
using System;


namespace App_R5E7_EncriptacionCesar
{
    class Program
    {
        static void Main(string[] args)
        {
            //VARIABLES
            string textoIntroducido;
            string textoCodificado;
            int desplazamiento = 3;

            //INTRODUCE DATO
            Console.WriteLine("Introduce un texto para ser encriptado por cesar: ");
            textoIntroducido = Console.ReadLine();

            //CODIFICAR TEXTO Y MOSTRAR
            textoCodificado = EncriptaCesar(textoIntroducido, desplazamiento);
            Console.WriteLine("\nTEXTO ENCRIPTADO POR CESAR\n"+textoCodificado);

            //DESCODIFICAR TEXTO Y MOSTRAR
            Console.WriteLine("\nTEXTO DESENCRIPTADO POR CESAR\n" + DesencriptaCesar(textoCodificado, desplazamiento));

            Console.ReadLine();
        }
        /// <summary>
        /// Encripta con el algoritmo de Cesar
        /// </summary>
        /// <param name="texto">Texto a encriptar</param>
        /// <param name="desplazarCaracter">Número de caracteres a desplazar</param>
        /// <returns>Devuelve string encriptado</returns>
        public static string EncriptaCesar(string texto,int desplazarCaracter)
        {
            //CONSTANTES
            const int RANGO_CARACTERES = 'Z' - 'A';
            const int PRIMER_CARACTER_MAYUS = 'A';
            const int PRIMER_CARACTER_MINUS = 'a';

            string resultado="";    //VARIABLE

            //RECORRE LA PALABRA CARACTER A CARACTER
            for (int i = 0; i < texto.Length; i++)
            {
                //SE ENCRIPTA DE LA 'A' A LA 'Z' MAYÚSCULA
                if (texto[i]>='A'&&texto[i]<='Z')
                {
                    resultado += (char)(PRIMER_CARACTER_MAYUS + (texto[i] + desplazarCaracter - PRIMER_CARACTER_MAYUS) % (RANGO_CARACTERES + 1));
                }
                //SE ENCRIPTA DE LA 'A' A LA 'Z' MINÚSCULA
                else if (texto[i] >= 'a' && texto[i] <= 'z')
                {
                    resultado += (char)(PRIMER_CARACTER_MINUS + (texto[i] + desplazarCaracter-PRIMER_CARACTER_MINUS) % (RANGO_CARACTERES + 1));
                }
                //SI NO ES NINGUNA DE LAS ANTERIOR ESCRIBE EL CARACTER TAL CUAL
                else
                {
                    resultado += texto[i];
                }
            }
            return resultado;   //DEVUELVE EL STRING CON EL RESULTADO
        }
        /// <summary>
        /// Desencripta con el algoritmo de Cesar
        /// </summary>
        /// <param name="texto">Texto a desencriptar</param>
        /// <param name="desplazarCaracter">Número de caracteres desplazados en la codificación</param>
        /// <returns>Devuelve string desencriptado</returns>
        public static string DesencriptaCesar(string texto, int desplazarCaracter)
        {
            //CONSTANTES
            const int PRIMER_CARACTER_MAYUS = 'A';
            const int ULTIMO_CARACTER_MAYUS = 'Z';
            const int PRIMER_CARACTER_MINUS = 'a';
            const int ULTIMO_CARACTER_MINUS = 'z';

            string resultado = "";      //VARIABLE

            //RECORRE LA PALABRA CARACTER A CARACTER
            for (int i = 0; i < texto.Length; i++)
            {
                //SE CONTROLA DESDE LA LETRA CORRESPONDIENTE INCLUIDA A LA 'Z' EN MINÚSCULAS Y MAYÚSCULAS
                if (texto[i] >= ('A' + desplazarCaracter) && texto[i] <= 'Z')
                    resultado += (char)(texto[i] - desplazarCaracter);
                else if (texto[i] >= ('a' + desplazarCaracter) && texto[i] <= 'z')
                    resultado += (char)(texto[i] - desplazarCaracter);
                //SE CONTROLA LOS CASOS DESDE LA 'A' HASTA LA LETRA CORRESPONDIENTE EXCLUIDA EN MINÚSCULAS Y MAYÚSCULAS
                else if (texto[i] >= 'A' && texto[i] < (char)('A'+desplazarCaracter))
                    resultado += (char)(texto[i] - PRIMER_CARACTER_MAYUS + ULTIMO_CARACTER_MAYUS-desplazarCaracter+1);
                else if (texto[i] >= 'a' && texto[i] < (char)('a' + desplazarCaracter))
                    resultado += (char)(texto[i] - PRIMER_CARACTER_MINUS + ULTIMO_CARACTER_MINUS - desplazarCaracter + 1);
                //SI NO ES NINGUNA DE LAS ANTERIOR ESCRIBE EL CARACTER TAL CUAL
                else
                    resultado += texto[i];
            }
            return resultado;   //DEVUELVE EL STRING CON EL RESULTADO
        }
    }
}
