using Lab5.Application.Abstractions;
using Lab5.Domain.Entities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab5.UI.ViewModels
{
    public partial class SushiViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        private readonly ISushiService _sushiService;

        public event PropertyChangedEventHandler PropertyChanged;

        Sushi selectedObject;

        public SushiViewModel(ISushiService service)
        {
            _sushiService = service;
        }

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

        public void Delete()
        {
            _sushiService.DeleteAsync(selectedObject);
            Shell.Current.GoToAsync("..");
        }

        public async Task Update()
        {
            await _sushiService.UpdateAsync(selectedObject);
            await Shell.Current.GoToAsync("..");
        }
    }
}
