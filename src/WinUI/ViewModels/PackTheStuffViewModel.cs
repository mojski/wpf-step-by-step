using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WinUI.Models.Trips;
using WinUI.Models.Trips.Interfaces;

namespace WinUI.ViewModels;

public partial class PackTheStuffViewModel : ObservableObject
{
    private readonly ITripRepository tripRepository;

    [ObservableProperty] private TripItemViewModel selectedItem = default;
    [ObservableProperty] private ObservableCollection<TripItemViewModel> items = new ();

    public PackTheStuffViewModel(ITripRepository tripRepository)
    {
        this.tripRepository = tripRepository;
    }
}