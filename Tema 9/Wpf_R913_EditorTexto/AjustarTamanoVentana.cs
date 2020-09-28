using System;
using System.Globalization;
using System.Windows.Data;

namespace Wpf_R913_EditorTexto
{
    class AjustarTamanoVentana : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value)/2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
