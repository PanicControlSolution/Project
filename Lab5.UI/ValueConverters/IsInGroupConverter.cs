using Lab5.UI.Pages;
using Lab5.UI.ViewModels;
using System.Globalization;

namespace Lab5.UI.ValueConverters
{
    public class IsInGroupConverter : IValueConverter
    {
        public int Id { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sets = ((parameter as Binding).Source as EditSushiPage).ViewModel.SelectedObject.Sets;
            return sets.Count(x => x.Id == (int)value) == 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 1;
        }
    }
}
