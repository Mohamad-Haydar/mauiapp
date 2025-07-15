using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Model;
using System.Threading.Tasks;

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
        void UpdateAnimalDetailsAsync()
        {
            if (Animal == null || Data == null)
                return;
            IsBusy = true;
            Animal.Name = Data.Name;
            Animal.Location = Data.Location;
            Animal.Details = Data.Details;
            Animal.Image = Data.Image;
            Animal.Population = Data.Population;
            Animal.Latitude = Data.Latitude;
            Animal.Longitude = Data.Longitude;
            IsBusy = false;
        }
    }
}
