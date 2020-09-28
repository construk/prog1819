using System;
using System.Collections.Generic;
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

namespace Wpf_R913_EditorTexto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AjustarTamanoVentana a = new AjustarTamanoVentana();
        double altoVentana;
        double altoScrollViewer;
        const int MARGEN_CUADRO_TEXTO = 100;
        public MainWindow()
        {
            InitializeComponent();
            altoVentana = window.Height;
            altoScrollViewer = scroll_texto.Height;
            cmbFuentes.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFuentes.SelectedIndex=0;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height >= MARGEN_CUADRO_TEXTO)
            {
                scroll_texto.Height = e.NewSize.Height - MARGEN_CUADRO_TEXTO;
            }
            else
            {
                scroll_texto.Height = 0;
            }
        }

        private void Btn_negrita_Click(object sender, RoutedEventArgs e)
        {
            if (txtEnriquecido.IsSelectionActive)
            {
                if (txtEnriquecido.Selection.GetPropertyValue(Inline.FontWeightProperty).Equals(FontWeights.Bold))
                {
                    txtEnriquecido.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
                    btn_negrita.IsChecked = false;
                }
                else
                {
                    txtEnriquecido.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
                    btn_negrita.IsChecked = true;
                }
            }
        }

        private void Btn_cursiva_Click(object sender, RoutedEventArgs e)
        {
            if (txtEnriquecido.IsSelectionActive)
            {
                if (txtEnriquecido.Selection.GetPropertyValue(Inline.FontStyleProperty).Equals(FontStyles.Italic))
                {
                    txtEnriquecido.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
                    btn_cursiva.IsChecked = false;
                }
                else
                {
                    txtEnriquecido.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
                    btn_negrita.IsChecked = true;
                }
            }
        }

        private void BtnRehacer_Click(object sender, RoutedEventArgs e)
        {
            txtEnriquecido.Redo();
        }

        private void BtnDeshacer_Click(object sender, RoutedEventArgs e)
        {
            txtEnriquecido.Undo();
        }

        private void BtnCortar_Click(object sender, RoutedEventArgs e)
        {
            txtEnriquecido.Cut();
        }

        private void BtnCopiar_Click(object sender, RoutedEventArgs e)
        {
            txtEnriquecido.Copy();
        }

        private void BtnPegar_Click(object sender, RoutedEventArgs e)
        {
            txtEnriquecido.Paste();
        }

        private void TxtEnriquecido_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!txtEnriquecido.Selection.IsEmpty)
            {
                object temp = txtEnriquecido.Selection.GetPropertyValue(Inline.FontWeightProperty);
                btn_negrita.IsChecked = (bool)((temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold)));

                temp = txtEnriquecido.Selection.GetPropertyValue(Inline.FontStyleProperty);
                btn_cursiva.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

                temp = txtEnriquecido.Selection.GetPropertyValue(Inline.FontFamilyProperty);
                cmbFuentes.SelectedItem = temp;
                /*
                temp = txtEnriquecido.Selection.GetPropertyValue(Inline.FontSizeProperty);
                cmbTamanos.Text = temp.ToString();

                temp = txtEnriquecido.Selection.GetPropertyValue(Inline.ForegroundProperty);
                cmbColores.Text = temp.ToString();
                */
            }
        }

        private void CmbFuentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFuentes.SelectedItem != null)
                txtEnriquecido.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFuentes.SelectedItem);
        }
    }
}

