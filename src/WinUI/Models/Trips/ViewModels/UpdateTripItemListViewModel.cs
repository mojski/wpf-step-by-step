using CommunityToolkit.Mvvm.ComponentModel;
using MvvmDialogs;

namespace WinUI.Models.Trips.ViewModels
{
    public partial class UpdateTripItemsListViewModel : ObservableObject, IModalDialogViewModel
    {
        [ObservableProperty] private TripItemListViewModel item = default;

        public bool? DialogResult { get; private set; } = default;
    }
}
