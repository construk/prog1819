using System;
using System.Globalization;
using System.Windows.Data;

namespace Wpf_R905_EncriptacionCesar
{
    class AjustarVistaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double panel = (double)value;
            return panel - 120;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
