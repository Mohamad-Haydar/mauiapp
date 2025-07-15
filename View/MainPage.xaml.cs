using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}