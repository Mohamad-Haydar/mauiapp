using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Model;
using MauiApp1.View;
using System.Diagnostics;

namespace MauiApp1.ViewModel
{
    [QueryProperty(nameof(Animal), nameof(Animal))]
    public partial class AnimalDetailsViewModel : ObservableObject
    {
        public IMap Map { get; }


        [ObservableProperty]
        Animal animal;

        public AnimalDetailsViewModel(IMap map)
        {
            Map = map;
        }

        [RelayCommand]
        async Task EditDetailsAsync()
        {
            if (Animal is null)
                return;

            var result = await Shell.Current.DisplayPromptAsync("Admin access Required", "Enter Admin Code to Continue", 
                accept: "OK",
                cancel: "Cancel",
                maxLength: 20,
                keyboard: Keyboard.Text);

            if (string.IsNullOrEmpty(result))
            {
                await Shell.Current.DisplayAlert("Access Restriction", "You should provide an admin password to enter this page", "Ok");
                return;
            }

            if (result != "123")
            {
                await Shell.Current.DisplayAlert("Access Restriction", "Your code is wrong", "Ok");
                return;
            }

            await Shell.Current.GoToAsync(nameof(EditAnimal), true, new Dictionary<string, object>
            {
                { nameof(Animal), Animal }
            });
        }

        [RelayCommand]
        async Task OpenInMapAsync()
        {
            if(Animal is null)
                return;

            try
            {
                await Map.OpenAsync(Animal.Latitude, Animal.Longitude, new MapLaunchOptions
                {
                    Name = Animal.Name,
                    NavigationMode = NavigationMode.None
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error opening map: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Unable to open map.", "OK");
            }
        }
    }    
}
