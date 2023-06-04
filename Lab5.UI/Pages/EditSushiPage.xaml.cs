using Lab5.Domain.Entities;
using Lab5.UI.ViewModels;
using System.Collections.ObjectModel;

namespace Lab5.UI.Pages;

public class SetSelection
{
    public Set CurrentSet { get; set; }
    public bool Contains { get; set; }

    public SetSelection(Set set, bool contains)
    {
        CurrentSet = set;
        Contains = contains;
    }
}

public partial class EditSushiPage : ContentPage
{
    public SushiViewModel ViewModel { get; set; }

    public ObservableCollection<SetSelection> Selection { get; set; } = new();

    public async void EditSushiElement(object sender, EventArgs e)
    {
        var sets = Selection.Where(x => x.Contains).Select(x => x.CurrentSet);
        ViewModel.SelectedObject.Sets.Clear();
        ViewModel.SelectedObject.Sets.AddRange(sets);
        await ViewModel.Update();
    }

    public EditSushiPage(SushiViewModel sushiViewModel, SetViewModel sets)
    {
        InitializeComponent();
        ViewModel = sushiViewModel;
        foreach (var set in sets.Sets)
        {
            Selection.Add(new SetSelection(set, ViewModel.SelectedObject.Sets.Where(x => x.Id == set.Id).Count() == 1));
        }
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