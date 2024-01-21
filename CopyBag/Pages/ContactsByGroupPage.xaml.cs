using CopyBag.ViewModels;

namespace CopyBag.Pages;

public partial class ContactsByGroupPage : ContentPage
{
    private ContactsByGroupViewModel _viewModel;
    public ContactsByGroupPage(ContactsByGroupViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        VisualStateManager.GoToState(SortAtoZBtn, "Selected");
        VisualStateManager.GoToState(SortTimeBtn, "UnSelected");
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (_viewModel is null) _viewModel = (ContactsByGroupViewModel)BindingContext;

        _viewModel.Search();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadContacts();
    }

    private void SortButton_Click(object sender, EventArgs e)
    {
        // Reset the visual state of all buttons to "Normal"
        VisualStateManager.GoToState(SortAtoZBtn, "UnSelected");
        VisualStateManager.GoToState(SortTimeBtn, "UnSelected");

        // Get the clicked button
        Button clickedButton = (Button)sender;

        // Change the visual state of the clicked button to "Selected"
        VisualStateManager.GoToState(clickedButton, "Selected");
    }
}