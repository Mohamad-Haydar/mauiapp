using MauiApp1.Services;
using MauiApp1.ViewModel;
using System.Threading.Tasks;

namespace MauiApp1.View;

public partial class CatsPage : ContentPage
{
    public readonly AnimalsViewModel _viewModel;
    public CatsPage(AnimalsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel  = viewModel;
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await _viewModel.LoadAnimalsAsync("Cats");
    }
}