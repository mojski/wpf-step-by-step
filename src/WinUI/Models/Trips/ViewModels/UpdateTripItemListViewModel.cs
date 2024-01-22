using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;

namespace WinUI.Models.Trips.ViewModels;

public partial class UpdateTripItemsListViewModel : ObservableObject, IModalDialogViewModel
{
    [ObservableProperty] private bool isClosed = default;
    [ObservableProperty] private TripItemListViewModel? item = default;
    public bool? DialogResult { get; private set; } = default;

    public IAsyncRelayCommand CancelCommand { get; }

    public UpdateTripItemsListViewModel()
    {
        this.CancelCommand = new AsyncRelayCommand(this.CancelAsync);
    }

    private async Task CancelAsync(CancellationToken cancellationToken = default)
    {
        this.DialogResult = false;
        this.IsClosed = true;
        await Task.CompletedTask;
    }
}
