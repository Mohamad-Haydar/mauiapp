using MauiApp1.View;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CatsPage), typeof(CatsPage));
            Routing.RegisterRoute(nameof(AnimalDetails), typeof(AnimalDetails));
            Routing.RegisterRoute(nameof(EditAnimal), typeof(EditAnimal));
        }
    }
}
