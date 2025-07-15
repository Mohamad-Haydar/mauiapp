using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class BearsPage : ContentPage
{
	public readonly AnimalsViewModel _viewModel;

    public BearsPage(AnimalsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await _viewModel.LoadAnimalsAsync("Bears");
    }
}