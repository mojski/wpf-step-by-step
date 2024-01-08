using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace WinUI.Models;

public partial class TripItemList : ObservableObject
{
    [ObservableProperty] private string name = string.Empty;
    [ObservableProperty] private string destination = string.Empty;
    [ObservableProperty] private string type = string.Empty;
    [ObservableProperty] private ObservableCollection<int> items = new();
    [ObservableProperty] private int? id = default;
}