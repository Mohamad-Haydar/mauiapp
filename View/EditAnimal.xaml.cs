using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class EditAnimal : ContentPage
{
	public EditAnimal(EditAnimalViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}