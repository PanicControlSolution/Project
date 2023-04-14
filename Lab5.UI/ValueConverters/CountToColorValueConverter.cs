

using Lab5.Domain.Entities;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Lab5.UI.ValueConverters
{
    public class CountToColorValueConverter : IValueConverter
    {
        public Color Accept { get; set; } = Colors.Green;
        public Color Denied { get; set; } = Colors.Red;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sushi = (string)value;
            int count = Int32.Parse(Regex.Match(sushi, @"\d+").Value);
            if (count < 1) 
                return Denied;
            return Accept;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
