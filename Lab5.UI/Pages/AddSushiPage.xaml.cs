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
}