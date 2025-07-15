using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class AnimalService
    {
        List<Animal> monkeyList = [];
        HttpClient httpClient;

        public AnimalService()
        {
            httpClient = new();
        }

        public async Task<List<Animal>> GetAnimals(string animalType)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName;
            switch (animalType)
            {
                case "Monkeys":
                    resourceName = "MauiApp1.Data.Monkeys.json";
                    break;
                case "Dogs":
                    resourceName = "MauiApp1.Data.Dogs.json";
                    break;
                case "Bears":
                    resourceName = "MauiApp1.Data.Bears.json";
                    break;
                default:
                    resourceName = "MauiApp1.Data.Monkeys.json";
                    break;
            }

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new(stream);
            string json = await reader.ReadToEndAsync();

            var animals = JsonSerializer.Deserialize<List<Animal>>(json);
            return animals;

            //string url = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/monkeydata.json";
            //var response = await httpClient.GetAsync(url);
            //if (response.IsSuccessStatusCode)
            //{
            //    monkeyList = await response.Content.ReadFromJsonAsync<List<Animal>>();
            //}
            //return monkeyList;
        }
    }
}
