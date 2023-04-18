using Lab5.UI.ViewModels;

namespace Lab5.UI.Pages;

public partial class Details : ContentPage
{
    private DetailsViewModel _viewModel;
    public Details(DetailsViewModel detailsViewModel)
    {
        InitializeComponent();
        _viewModel = detailsViewModel;
        BindingContext = _viewModel;
    }
}