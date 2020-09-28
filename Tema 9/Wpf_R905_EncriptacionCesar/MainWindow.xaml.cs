using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_R905_EncriptacionCesar
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Encriptar_Click(object sender, RoutedEventArgs e)
        {
            txbl_original.Text = txb_texto.Text;
            txbl_encriptado.Text = EncriptaCesar(txbl_original.Text, int.Parse(tbx_deplazamiento.Text));
            txbl_desencriptado.Text = DesencriptaCesar(txbl_encriptado.Text, int.Parse(tbx_deplazamiento.Text));
        }

        /// <summary>
        /// Encripta con el algoritmo de Cesar
        /// </summary>
        /// <param name="texto">Texto a encriptar</param>
        /// <param name="desplazarCaracter">Número de caracteres a desplazar</param>
        /// <returns>Devuelve string encriptado</returns>
        public static string EncriptaCesar(string texto, int desplazarCaracter)
        {
            //CONSTANTES
            const int RANGO_CARACTERES = 'Z' - 'A';
            const int PRIMER_CARACTER_MAYUS = 'A';
            const int PRIMER_CARACTER_MINUS = 'a';

            string resultado = "";    //VARIABLE

            //RECORRE LA PALABRA CARACTER A CARACTER
            for (int i = 0; i < texto.Length; i++)
            {
                //SE ENCRIPTA DE LA 'A' A LA 'Z' MAYÚSCULA
                if (texto[i] >= 'A' && texto[i] <= 'Z')
                {
                    resultado += (char)(PRIMER_CARACTER_MAYUS + (texto[i] + desplazarCaracter - PRIMER_CARACTER_MAYUS) % (RANGO_CARACTERES + 1));
                }
                //SE ENCRIPTA DE LA 'A' A LA 'Z' MINÚSCULA
                else if (texto[i] >= 'a' && texto[i] <= 'z')
                {
                    resultado += (char)(PRIMER_CARACTER_MINUS + (texto[i] + desplazarCaracter - PRIMER_CARACTER_MINUS) % (RANGO_CARACTERES + 1));
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
                else if (texto[i] >= 'A' && texto[i] < (char)('A' + desplazarCaracter))
                    resultado += (char)(texto[i] - PRIMER_CARACTER_MAYUS + ULTIMO_CARACTER_MAYUS - desplazarCaracter + 1);
                else if (texto[i] >= 'a' && texto[i] < (char)('a' + desplazarCaracter))
                    resultado += (char)(texto[i] - PRIMER_CARACTER_MINUS + ULTIMO_CARACTER_MINUS - desplazarCaracter + 1);
                //SI NO ES NINGUNA DE LAS ANTERIOR ESCRIBE EL CARACTER TAL CUAL
                else
                    resultado += texto[i];
            }
            return resultado;   //DEVUELVE EL STRING CON EL RESULTADO
        }

        private void Btn_sumar_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(tbx_deplazamiento.Text) < 20)
            {
                tbx_deplazamiento.Text = (int.Parse(tbx_deplazamiento.Text) + 1).ToString();
            }
        }

        private void Btn_restar_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(tbx_deplazamiento.Text) > 0)
            {
                tbx_deplazamiento.Text = (int.Parse(tbx_deplazamiento.Text) - 1).ToString();
            }
        }

        private void Btn_leerFichero_Click(object sender, RoutedEventArgs e)
        {
            string ruta;
            OpenFileDialog abrirFichero = new OpenFileDialog();
            abrirFichero.Filter = "Documentos de texto|*.txt";
            if (abrirFichero.ShowDialog()==true)
            {
                ruta=abrirFichero.FileName;

                StringBuilder texto = new StringBuilder();
                using (FileStream flujoFichero = new FileStream(ruta, FileMode.Open))
                using (StreamReader fichero = new StreamReader(flujoFichero))
                {
                    string linea;
                    while ((linea=fichero.ReadLine())!=null)
                    {
                        texto.Append(linea+"\n");
                    }
                    string textoString = texto.ToString();

                    txbl_original.Text = textoString;
                    txbl_encriptado.Text = EncriptaCesar(textoString, int.Parse(tbx_deplazamiento.Text));
                    txbl_desencriptado.Text = DesencriptaCesar(txbl_encriptado.Text, int.Parse(tbx_deplazamiento.Text));
                }
            }
        }
    }
}
