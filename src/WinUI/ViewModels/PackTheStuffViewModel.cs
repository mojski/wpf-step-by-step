using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using MvvmDialogs;
using System.Collections.ObjectModel;
using WinUI.Models.Trips;
using WinUI.Models.Trips.ViewModels;

namespace WinUI.ViewModels;

public partial class PackTheStuffViewModel : ObservableObject
{
    private readonly IMediator mediator;
    private readonly IDialogService dialogService;

    [ObservableProperty] private TripItemListViewModel? selectedItem = default;
    [ObservableProperty] private ObservableCollection<TripItemListViewModel> items = new ();

    public IAsyncRelayCommand AddTripItemsListCommand{ get; }
    
    public PackTheStuffViewModel(IMediator mediator, IDialogService dialogService)
    {
        this.mediator = mediator;
        this.dialogService = dialogService;

        this.AddTripItemsListCommand = new AsyncRelayCommand(this.AddTripItemsListAsync);
    }

    private async Task AddTripItemsListAsync(CancellationToken cancellationToken = default)
    {
        var emptyModel = new TripItemListViewModel();

        var viewModel = new UpdateTripItemsListViewModel() { Item = emptyModel };

        var result = this.dialogService.ShowDialog(this, viewModel);
    }
}