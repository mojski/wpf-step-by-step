using CommunityToolkit.Mvvm.ComponentModel;

namespace WinUI.Models
{
    public partial class TripItemCategory : ObservableObject
    {
        [ObservableProperty] private string name = string.Empty;
        [ObservableProperty] private string priority = string.Empty;
        [ObservableProperty] private int? id = default;
    }
}
