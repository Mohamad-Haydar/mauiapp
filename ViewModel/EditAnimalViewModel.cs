using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Model;

namespace MauiApp1.ViewModel
{
    [QueryProperty(nameof(Animal), nameof(Animal))]
    public partial class EditAnimalViewModel : BaseViewModel
    {
        [ObservableProperty]
        Animal animal;
        [ObservableProperty]
        Animal data;
        [ObservableProperty]
        string pageTitle;

        partial void OnAnimalChanged(Animal value)
        {
            Data = new()
            {
                name = value.Name,
                location = value.Location,
                details = value.Details,
                image = value.Image,
                population = value.Population,
                latitude = value.latitude,
                longitude = value.longitude
            };
            pageTitle = "Edit " + value.Name;
        }

        [RelayCommand]
        async Task UpdateAnimalDetailsAsync()
        {
            if (Animal == null || Data == null)
                return;
            IsBusy = true;
            Animal.Name = Data.name;
            Animal.Location = Data.location;
            Animal.Details = Data.details;
            Animal.Image = Data.image;
            Animal.Population = Data.population;
            Animal.latitude = Data.latitude;
            Animal.longitude = Data.longitude;
            IsBusy = false;
        }
    }
}
