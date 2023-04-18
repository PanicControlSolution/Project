using CommunityToolkit.Mvvm.ComponentModel;
using Lab5.Domain.Entities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab5.UI.ViewModels
{
    public partial class DetailsViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Sushi selectedObject;
        public Sushi SelectedObject
        {
            get => selectedObject;
            set
            {
                selectedObject = value;
                OnPropertyChanged();
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            SelectedObject = query["Sushi"] as Sushi;
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
