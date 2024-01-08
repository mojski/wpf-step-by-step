using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace WinUI.Models;

public partial class TripItem : ObservableObject
{
    [ObservableProperty] private string name = string.Empty;
    [ObservableProperty] private string storagePlace = string.Empty;
    [ObservableProperty] private string weight = string.Empty;
    [ObservableProperty] private string content = string.Empty;
    [ObservableProperty] private ObservableCollection<int> categories = new();
    [ObservableProperty] private int? id = default;
}