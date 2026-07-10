using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;


namespace DailyRegisterBlazor
{
    public partial class App : Application
    {
        // Inside the App class, inject the localizer:
        [Inject]
        public IStringLocalizer<App> Localizer { get; set; } = default!;
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "DailyRegisterBlazor" };
        }
    }
}
