using Lab5.UI.ViewModels;

namespace Lab5.UI.Pages;

public partial class Sets : ContentPage
{
    private SetViewModel _viewModel;

    public Sets(SetViewModel setViewModel)
    {
        InitializeComponent();
        _viewModel = setViewModel;
        BindingContext = setViewModel;
    }

}