using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WinUI.Models.Trips;
using WinUI.Models.Trips.Interfaces;

namespace WinUI.ViewModels;

public partial class PackTheStuffViewModel : ObservableObject
{

    [ObservableProperty] private TripItemListViewModel? selectedItem = default;
    [ObservableProperty] private ObservableCollection<TripItemListViewModel> items = new ();

    public PackTheStuffViewModel()
    {
        
    }
}