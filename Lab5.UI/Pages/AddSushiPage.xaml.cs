using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab5.UI.ViewModels;

namespace Lab5.UI.Pages;

public partial class AddSushiPage : ContentPage
{
    private SetViewModel _viewModel;


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