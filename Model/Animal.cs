using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace MauiApp1.Model
{
    public partial class Animal : ObservableObject
    {
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public string location;
        [ObservableProperty]
        public string details;
        [ObservableProperty]
        public string image;
        [ObservableProperty]
        public int population;
        [ObservableProperty]
        public double latitude;
        [ObservableProperty]
        public double longitude;
       

    }
    //public partial class Monkey : INotifyPropertyChanged
    //{
    //    private string name;
    //    public string Name
    //    {
    //        get => name;
    //        set
    //        {
    //            if (name == value) return;
    //            name = value;
    //            OnPropertyChanged(nameof(Name));
    //        }
    //    }

    //    private string location;

    //    public string Location
    //    {
    //        get { return location; }
    //        set 
    //        {
    //            if(location == value) return;
    //            location = value;
    //            OnPropertyChanged(nameof(Location));
    //        }
    //    }

    //    private string details;

    //    public string Details
    //    {
    //        get { return details; }
    //        set 
    //        {
    //            if(details == value) return;
    //            details = value;
    //            OnPropertyChanged(nameof(Details));
    //        }
    //    }

    //    private string image;

    //    public string Image
    //    {
    //        get { return image; }
    //        set 
    //        { 
    //            if(image == value) return;
    //            image = value;
    //            OnPropertyChanged(nameof(Image));
    //        }
    //    }

    //    private int population;

    //    public int Population
    //    {
    //        get { return population; }
    //        set
    //        {
    //            if (population == value) return;
    //            population = value;
    //            OnPropertyChanged(nameof(Population));
    //        }
    //    }

    //    private double latitute;

    //    public double Latitude
    //    {
    //        get { return latitute; }
    //        set
    //        {
    //            if (latitute == value) return;
    //            latitute = value;
    //            OnPropertyChanged(nameof(Latitude));
    //        }
    //    }

    //    public double Longitude
    //    {
    //        get { return Longitude; }
    //        set
    //        {
    //            if (latitute == value) return;
    //            latitute = value;
    //            OnPropertyChanged(nameof(Longitude));
    //        }
    //    }



    //    public event PropertyChangedEventHandler? PropertyChanged;
    //    protected void OnPropertyChanged(string name)
    //        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    //}
}
