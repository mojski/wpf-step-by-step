using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WinUI.Models.Services;
using WinUI.Models.Trips.Interfaces;
using WinUI.ViewModels;

namespace WinUI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        IServiceCollection services = new ServiceCollection();

        // register all services here

        services.AddSingleton<PackTheStuffViewModel>();
        services.AddSingleton<ITripRepository, InMemoryTripRepository>();
        IServiceProvider provider = services.BuildServiceProvider();

        Ioc.Default.ConfigureServices(provider);
    }
}

