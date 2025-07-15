using CommunityToolkit.Mvvm.Input;
using MauiApp1.Model;
using MauiApp1.Services;
using MauiApp1.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModel
{
    public partial class AnimalsViewModel : BaseViewModel
    {
        public AnimalService _animalService;
        public IConnectivity Connectivity { get; }
        public IGeolocation Geolocation { get; }
        private static int count = 0;

        public ObservableCollection<Animal> Animals { get; }

        public AnimalsViewModel(AnimalService monkeyService, IConnectivity connectivity, IGeolocation geolocation)
        {
            Shell.Current.DisplayAlert("New AnimalsVewModel", "Adding new Animalsviewmodel object nb: " + ++count, "OK");
            _animalService = monkeyService;
            Animals = [];
            Connectivity = connectivity;
            Geolocation = geolocation;
        }
        public async Task LoadAnimalsAsync(string animalType)
        {
            if (IsBusy  || Animals.Count > 0)
                return;

            try
            {
                IsBusy = true;
                if (!Connectivity.NetworkAccess.Equals(NetworkAccess.Internet))
                {
                    await Shell.Current.DisplayAlert("No Internet", "Please check your internet connection.", "OK");
                    await Shell.Current.GoToAsync(".."); 
                    return;
                }
                var monkeys = await _animalService.GetAnimals(animalType);
                foreach (var monkey in monkeys)
                {
                    Animals.Add(monkey);
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine("Failed to load Animals.");
                await Shell.Current.DisplayAlert("Error", "Failed to load cats.", "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }

        [RelayCommand]
        async Task GoToDetailsAsync(Animal animal)
        {
            if(animal is null)
                return;
            await Shell.Current.GoToAsync(nameof(AnimalDetails), true, new Dictionary<string, object>
            {
                { nameof(Animal), animal   }
            });
        }

        [RelayCommand]
        async Task FindClosestAsync()
        {
            if (!Connectivity.NetworkAccess.Equals(NetworkAccess.Internet))
            {
                await Shell.Current.DisplayAlert("No Internet", "Please check your internet connection.", "OK");
                return;
            }

            try
            {
                IsBusy = true;
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location is null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }
                if (location is null)
                {
                    await Shell.Current.DisplayAlert("Location Error", "Unable to determine your location.", "OK");
                    IsBusy = false;
                    return;
                }

                var closest = Animals.OrderBy(m => location.CalculateDistance(m.Latitude, m.Longitude, DistanceUnits.Kilometers)).FirstOrDefault();
                if (closest is null)
                {
                    await Shell.Current.DisplayAlert("No Cats Nearby", "There are no cats nearby.", "OK");
                    return;
                }

                await Shell.Current.DisplayAlert("Closest Monkey", $"The closest monkey is {closest.Name} located at {closest.Location}", "OK");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "something whent wrong","OK");
            }
            finally
            {
                IsBusy = false;
            }

            
        }
    }
}
