using Lab5.UI.ViewModels;

namespace Lab5.UI.Pages;

public partial class Details : ContentPage
{
    private readonly SushiViewModel _viewModel;

    public Details(SushiViewModel detailsViewModel)
    {
        InitializeComponent();
        _viewModel = detailsViewModel;
        BindingContext = _viewModel;
    }

    private void RemoveSushi(object sender, EventArgs e)
    {
        (BindingContext as SushiViewModel).Delete();
    }

    private async void EditSushi(object sender, EventArgs e)
    {
        Dictionary<string, object> parameters = new() {
            { "Sushi", _viewModel.SelectedObject }
        };

        await Shell.Current.GoToAsync($"EditSushiPage", parameters);
    }
}