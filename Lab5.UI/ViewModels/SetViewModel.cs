using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab5.Application.Abstractions;
using Lab5.Domain.Entities;
using Lab5.UI.Pages;
using System.Collections.ObjectModel;

namespace Lab5.UI.ViewModels
{
    public partial class SetViewModel : ObservableObject
    {
        private readonly ISetService _setService;
        private readonly ISushiService _sushiService;

        public SetViewModel(ISetService setService, ISushiService sushiService)
        {
            _setService = setService;
            _sushiService = sushiService;
        }

        public ObservableCollection<Set> Sets { get; set; } = new();
        public ObservableCollection<Sushi> Sushi { get; set; } = new();

        [ObservableProperty]
        Set selectedSet;

        [RelayCommand]
        async void UpdateGroupList() => await GetSets();
        [RelayCommand]
        async void UpdateMembersList() => await GetSushi();

        [RelayCommand]
        async void ShowDetails() => await GotoDetailsPage();

        public async Task GetSets()
        {
            var sets = await _setService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Sets.Clear();
                foreach (var set in sets)
                {
                    Sets.Add(set);
                }
            });
        }

        public async Task GetSushi()
        {
            var sushi = await _setService.GetAllBySetIdAsync(SelectedSet.Id);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Sushi.Clear();
                foreach (var sushi in sushi)
                {
                    Sushi.Add(sushi);
                }
            });
        }

        private async Task GotoDetailsPage()
        {
            await Shell.Current.GoToAsync(nameof(Details));
        }
    }
}
