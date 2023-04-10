using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab5.Application.Abstractions;
using Lab5.Domain.Entities;
using System.Collections.ObjectModel;

namespace Lab5.UI.ViewModels
{
    public partial class SetViewModel : ObservableObject
    {
        private readonly ISetService _setService;

        public SetViewModel(ISetService setService)
        {
            _setService = setService;
        }

        public ObservableCollection<Set> Sets { get; set; } = new();

        [ObservableProperty]
        Set selectedSet;

        [RelayCommand]
        async void UpdateGroupList() => await GetSets();

        public async Task GetSets()
        {
            var sets = await _setService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Sets.Clear();
                foreach (var cource in sets)
                    Sets.Add(cource);
            });
        }
    }
}
