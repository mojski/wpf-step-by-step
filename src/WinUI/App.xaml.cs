using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MvvmDialogs;
using MvvmDialogs.DialogTypeLocators;
using System.Reflection;
using System.Windows;
using WinUI.Models.Services;
using WinUI.Models.Trips.Interfaces;
using WinUI.Models.Trips.ViewModels;
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
        services.AddSingleton<UpdateTripItemsListViewModel>();
        services.AddSingleton<ITripRepository, InMemoryTripRepository>();
        services.AddSingleton<IDialogService, DialogService>();
        services.AddSingleton<IDialogTypeLocator, DialogTypeLocator>();

        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        IServiceProvider provider = services.BuildServiceProvider();

        Ioc.Default.ConfigureServices(provider);
    }
}
