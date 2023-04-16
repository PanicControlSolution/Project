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

        public ObservableCollection<int> SushiCountVariants { get; set; } = new(new int[] { 4, 8, 12, 16 });
        [ObservableProperty]
        int selectedCount = 8;


        [RelayCommand]
        async void UpdateGroupList() => await GetSets();
        [RelayCommand]
        async void UpdateMembersList() => await GetSushi();

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
    }
}
