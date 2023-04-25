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
        public ObservableCollection<Sushi> Sushi { get; set; } = new();

        [ObservableProperty]
        Set selectedSet;

        [RelayCommand]
        async void UpdateGroupList() => await GetSets();
        [RelayCommand]
        async void UpdateMembersList() => await GetSushi();

        [RelayCommand]
        async void ShowDetails(Sushi sushi) => await GotoDetailsPage(sushi);

        [RelayCommand]
        async void AddSushi() => await GoToAddSushi();

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

        private async Task GotoDetailsPage(Sushi sushi)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"Sushi", sushi}
            };

            await Shell.Current.GoToAsync($"Details", parameters);
        }

        private async Task GoToAddSushi()
        {
            await Shell.Current.GoToAsync($"AddSushiPage");
        }
    }
}
