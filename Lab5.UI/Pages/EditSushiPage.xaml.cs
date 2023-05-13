using CommunityToolkit.Mvvm.Input;
using Lab5.UI.ViewModels;

namespace Lab5.UI.Pages;

public partial class EditSushiPage : ContentPage
{
    public SushiViewModel ViewModel { get; set; }
    public SetViewModel Sets { get; set; }

    public List<string> selectedSets = new();

    [RelayCommand]
    public async void AddSushiElement()
    {

    }

    void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }

    public EditSushiPage(SushiViewModel sushiViewModel, IServiceProvider provider)
    {
        InitializeComponent();
        ViewModel = sushiViewModel;
        Sets = provider.GetRequiredService<SetViewModel>();
        BindingContext = this;
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