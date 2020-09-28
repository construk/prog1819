using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf_R919_CrearMatrizBotones
{
    class CBotones : INotifyPropertyChanged
    {
        StackPanel panelPrincipal;
        int ancho, alto;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public StackPanel Botones { get { return panelPrincipal; } set { panelPrincipal = value;  OnPropertyChanged(); } }
        /*private void ActualizaVista()
        {
            if (Alto > 0 && Ancho > 0)
            {
                InsertarBotones();
            }
        }*/
        public int Ancho
        {
            get { return ancho; }
            set
            {
                if (value < 0)
                {
                    ancho = 0;
                }
                else
                {
                    ancho = value;
                }
                //ActualizaVista();
                OnPropertyChanged();
            }
        }
        public int Alto
        {
            get { return alto; }
            set
            {
                if (value < 0)
                {
                    alto = 0;
                }
                else
                {
                    alto = value;
                }
                //ActualizaVista();
                OnPropertyChanged();
            }
        }
        public CBotones()
        {
            panelPrincipal = new StackPanel();
            ancho = 0;
            alto = 0;
        }
        public void InsertarBotones()
        {
            panelPrincipal.Children.Clear();
            for (int i = 0; i < Alto; i++)
            {
                StackPanel panelBotones = new StackPanel();
                panelBotones.HorizontalAlignment = HorizontalAlignment.Center;
                panelBotones.Orientation = Orientation.Horizontal;
                for (int j  = 0; j < Ancho; j++)
                {
                    Button botonInsertado = new Button
                    {
                        Margin = new Thickness(5),
                        Width = 50,
                        Content = "[" + i + "," + j + "]"
                    };

                    botonInsertado.Click += Clic_Boton;
                    botonInsertado.MouseEnter += BotonInsertado_MouseEnter;
                    botonInsertado.MouseLeave += BotonInsertado_MouseLeave;
                    
                    panelBotones.Children.Add(botonInsertado);
                }
                Botones.Children.Add(panelBotones);
            }
        }

        private void BotonInsertado_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Background = Brushes.Red;
        }

        private void BotonInsertado_MouseLeave(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Background = SystemColors.ControlLightBrush;
        }

        private void Clic_Boton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Botón pulsado: "+((Button)sender).Content.ToString());
        }
        protected void OnPropertyChanged2(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
