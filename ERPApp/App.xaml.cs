using System.Windows;
using ERPApp.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERPApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider? Services {get; private set;}

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Services = AppInitializer.Build();
            var mainWindow = Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
