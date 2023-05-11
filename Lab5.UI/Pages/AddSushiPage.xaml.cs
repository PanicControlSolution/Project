using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab5.Domain.Entities;
using Lab5.UI.ViewModels;
using System.Linq;

namespace Lab5.UI.Pages;

public partial class AddSushiPage : ContentPage
{
    private SetViewModel _viewModel;

    public List<string> selectedSets = new();

    [RelayCommand]
    public async void AddSushiElement()
    {

    }

    void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _viewModel._setService.AddSushi(_viewModel.Sets[0], new Sushi($"Суши 69", new Random().Next(4, 12)));
        /*CheckBox check = (CheckBox)sender;
        if (check.IsChecked)
        {
            selectedSets.Add(check.StyleId);
        }
        else
        {
            selectedSets.Remove(check.StyleId);
        }*/
    }

    public AddSushiPage(SetViewModel setViewModel)
    {
        InitializeComponent();
        _viewModel = setViewModel;
        BindingContext = _viewModel;
    }

    public async void pick_image(object sender, EventArgs e)
    {
        var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            {DevicePlatform.WinUI, new[]{".png", ".svg"} }
        });

        var results = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = customFileType
        });
    }
}