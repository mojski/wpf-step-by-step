using CommunityToolkit.Mvvm.ComponentModel;

namespace WinUI.Models.Trips
{
    public partial class TripItemCategoryViewModel : ObservableObject
    {
        [ObservableProperty] private string name = string.Empty;
        [ObservableProperty] private int priority;
        [ObservableProperty] private int? id = default;
    }
}
