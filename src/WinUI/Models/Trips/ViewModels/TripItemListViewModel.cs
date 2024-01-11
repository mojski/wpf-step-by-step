using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace WinUI.Models.Trips;

public partial class TripItemListViewModel : ObservableObject
{
    [ObservableProperty] private string name = string.Empty;
    [ObservableProperty] private string destination = string.Empty;
    [ObservableProperty] private string type = string.Empty;
    [ObservableProperty] private ObservableCollection<TripItemViewModel> items = new();
    [ObservableProperty] private int? id = default;
}