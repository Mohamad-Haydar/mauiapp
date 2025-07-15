using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class AnimalDetails : ContentPage
{
	public AnimalDetails(AnimalDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}