using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class DogsPage : ContentPage
{
    public readonly AnimalsViewModel _viewModel;
    public DogsPage(AnimalsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await _viewModel.LoadAnimalsAsync("Dogs");
    }
}