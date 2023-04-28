using System.Globalization;

namespace Lab5.UI.ValueConverters
{
    public class CountToColorValueConverter : IValueConverter
    {

        static public Color Accept { get; set; } = Colors.LightCyan;

        static public Color Denied { get; set; } = Colors.LightPink;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var count = (int)value;
            if (count > 8)
            {
                return Denied;
            }
            return Accept;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
