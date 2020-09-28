using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Wpf_R909_TiradaDados
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int RETARDO_ANIMACION = 800;
        const int TIEMPO_ANIMACION = 2400;
        #region CAMPOS
        DispatcherTimer reloj = new DispatcherTimer();
        bool? animando = false;
        int contadorIteracionesReloj = 0;
        Random rnd = new Random();
        int contadorTiradas = 0;
        int resultadoActual = 0;
        int resultado1 = 0;
        int resultado2 = 0;
        int resultado3 = 0;
        int resultado4 = 0;
        int resultado5 = 0;
        int resultado6 = 0;
        string dado1;
        string dado2;
        string dado3;
        string dado4;
        string dado5;
        string dado6;
        int nTiradas;
        int contador = 0;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            reloj.Start();
            reloj.Tick += Reloj_Tick;
        }
        #region Metodos auxiliares
        private void CambiarImagenAlea()
        {
            string stringUri = "./Imagenes/" + rnd.Next(1, 7) + ".png";
            BitmapImage imagen = new BitmapImage();
            imagen.BeginInit();
            imagen.UriSource = new Uri(stringUri, UriKind.Relative);
            imagen.EndInit();
            img_dado.Source = imagen;
        }
        private void DesactivarBotones()
        {
            //DESACTIVAR BOTÓN PARA CALCULAR
            btn_Tirar.IsEnabled = false;
            btn_auto.IsEnabled = false;
        }
        private void ActivarBotones()
        {
            //DESACTIVAR BOTÓN PARA CALCULAR
            btn_Tirar.IsEnabled = true;
            int tmp;
            if (int.TryParse(txb_nTiradas.Text, out tmp))
            {
                btn_auto.IsEnabled = true;
            }
            else
            {
                btn_auto.IsEnabled = false;
            }
        }
        private void TirarDado()
        {
            resultadoActual = rnd.Next(1, 7);   //OBTENER NÚMERO ALEATORIO ENTRE EL 1 Y EL 6
            contadorTiradas++;                  //Aumentar el número de tiradas realizadas
        }
        private void AnadirResultadoGrafico()
        {
            //AÑADIR A RESULTADO
            ListViewItem item = new ListViewItem();
            item.Content = contadorTiradas.ToString() + " -> " + resultadoActual.ToString();
            list_Resultados.Items.Add(item);
        }
        private void SumarDadoObtenido()
        {
            switch (resultadoActual)
            {
                case 1:
                    resultado1++;
                    break;
                case 2:
                    resultado2++;
                    break;
                case 3:
                    resultado3++;
                    break;
                case 4:
                    resultado4++;
                    break;
                case 5:
                    resultado5++;
                    break;
                case 6:
                    resultado6++;
                    break;
            }
        }
        private void ObtenerStringEstadistica()
        {
            dado1 = "1 ->" + resultado1 + " -> " + ((resultado1 / (double)contadorTiradas) * 100).ToString("#0.##") + "%";
            dado2 = "2 ->" + resultado2 + " -> " + ((resultado2 / (double)contadorTiradas) * 100).ToString("#0.##") + "%"; ;
            dado3 = "3 ->" + resultado3 + " -> " + ((resultado3 / (double)contadorTiradas) * 100).ToString("#0.##") + "%";
            dado4 = "4 ->" + resultado4 + " -> " + ((resultado4 / (double)contadorTiradas) * 100).ToString("#0.##") + "%";
            dado5 = "5 ->" + resultado5 + " -> " + ((resultado5 / (double)contadorTiradas) * 100).ToString("#0.##") + "%";
            dado6 = "6 ->" + resultado6 + " -> " + ((resultado6 / (double)contadorTiradas) * 100).ToString("#0.##") + "%";
        }
        private void AnadirEstadisticaYTotalTiradasGrafico()
        {
            item1.Content = dado1;
            item2.Content = dado2;
            item3.Content = dado3;
            item4.Content = dado4;
            item5.Content = dado5;
            item6.Content = dado6;
            gr_TotalTiradas.Content = contadorTiradas;
        }
        private void AnadirDadoResultadoGrafico()
        {
            string stringUri = "./Imagenes/" +resultadoActual + ".png";
            BitmapImage imagen = new BitmapImage();
            imagen.BeginInit();
            imagen.UriSource = new Uri(stringUri, UriKind.Relative);
            imagen.EndInit();
            img_dado.Source = imagen;
        }
        #endregion
        #region Eventos
        private async void Reloj_Tick(object sender, EventArgs e)
        {
            if (animando == true && contadorIteracionesReloj % RETARDO_ANIMACION == 0)      //CONDICIÓN PARA QUE HAYA ANIMACIÓN TANTO DE DADO COMO BARRA CARGANDO
            {
                if (nTiradas != 0 && contador == nTiradas)                                //FIN DE LA ANIMACIÓN
                {
                    barraProgreso.Value = (barraProgreso.Maximum / nTiradas) * contador;
                    animando = false;
                    await Task.Delay(1);
                    contador = 0;
                    barraProgreso.Value = 0;
                }
                else                                                                    //SI NO ES EL FIN CAMBIA IMAGEN Y ACTUALIZA BARRA
                {
                    //CAMBIAR LA IMAGEN PARA LA ANIMACIÓN
                    CambiarImagenAlea();

                    //ANIMAR LA BARRA DE PROGRESO
                    if (nTiradas != 0)
                    {
                        barraProgreso.Value = (barraProgreso.Maximum / nTiradas) * contador;
                        await Task.Delay(1);
                    }
                }
            }

            //Si el contador del reloj se llena, se reinicia su valor
            try { contadorIteracionesReloj++; } catch (Exception) { contadorIteracionesReloj = 0; }
        }
        private async void Btn_Tirar_Click(object sender, RoutedEventArgs e)
        {
            DesactivarBotones();
            animando = check_Simular.IsChecked;     //Anima si está activado el CHECKBOX

            //SI ANIMA LO HACE ASINCRONAMENTE PARA QUE SE MUESTRE EN LA INTERFAZ
            if (animando==true)
            {
                await Task.Delay(TIEMPO_ANIMACION);
            }
            TirarDado();
            SumarDadoObtenido();
            ObtenerStringEstadistica();
            AnadirDadoResultadoGrafico();
            AnadirResultadoGrafico();        
            AnadirEstadisticaYTotalTiradasGrafico();
            await Task.Delay(1);
            ActivarBotones();
            /*
             //Si se tira una vez que nTiradas = 1
             Button btn = null;
             try { btn = (Button)sender; } catch { }
             if (!(btn is null) && btn.Name.Equals("btn_Tirar"))
             {
                 nTiradas = 1;
                 animando = false;
             }        */
            animando = false;
        }
        private void Txb_nTiradas_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(txb_nTiradas.Text, out nTiradas))
            {
                btn_auto.IsEnabled = true;
            }
            else
            {
                btn_auto.IsEnabled = false;
            }
        }
        private async void Btn_auto_Click(object sender, RoutedEventArgs e)
        {
            nTiradas = int.Parse(txb_nTiradas.Text);
            for (contador = 0; contador < nTiradas; contador++)
            {
                DesactivarBotones();
                animando = check_Simular.IsChecked;     //Anima si está activado el CHECKBOX

                //SI ANIMA LO HACE ASINCRONAMENTE PARA QUE SE MUESTRE EN LA INTERFAZ
                if (animando == true)
                {
                    await Task.Delay(TIEMPO_ANIMACION);
                }
                TirarDado();                
                SumarDadoObtenido();
                ObtenerStringEstadistica();
                AnadirDadoResultadoGrafico();
                AnadirResultadoGrafico();
                AnadirEstadisticaYTotalTiradasGrafico();
                await Task.Delay(1);
            }
            ActivarBotones();
            animando = false;
            barraProgreso.Value = (barraProgreso.Maximum / nTiradas) * contador;
            await Task.Delay(1000);
            contador = 0;
            barraProgreso.Value = 0;
        }
        #endregion
    }
}