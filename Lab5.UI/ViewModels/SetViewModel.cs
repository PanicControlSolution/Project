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

        public SetViewModel(ISetService courceService, ISushiService traineeService)
        {
            _setService = courceService;
            _sushiService = traineeService;
        }

        public ObservableCollection<Set> Cources { get; set; } = new();
        public ObservableCollection<Sushi> Trainees { get; set; } = new();

        [ObservableProperty]
        Set selectedSet;
        [RelayCommand]
        async void UpdateGroupList() => await GetCources();
        [RelayCommand]
        async void UpdateMembersList() => await GetTrainees();

        public async Task GetCources()
        {
            var cources = await _setService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Cources.Clear();
                foreach (var cource in cources)
                    Cources.Add(cource);
            });
        }

        public async Task GetTrainees()
        {
            var trainees = await _setService.GetAllBySetIdAsync(SelectedSet.Id);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {

                Trainees.Clear();
                foreach (var trainee in trainees)
                    Trainees.Add(trainee);
            });
        }
    }
}
