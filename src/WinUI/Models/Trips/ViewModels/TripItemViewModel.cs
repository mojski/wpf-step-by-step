using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace WinUI.Models.Trips;

public partial class TripItemViewModel : ObservableObject
{
    [ObservableProperty] private string name = string.Empty;
    [ObservableProperty] private string storagePlace = string.Empty;
    [ObservableProperty] private string weight = string.Empty;
    [ObservableProperty] private string content = string.Empty;
    [ObservableProperty] private ObservableCollection<TripItemCategoryViewModel> categories = new();
    [ObservableProperty] private int? id = default;
}