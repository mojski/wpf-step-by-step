using CommunityToolkit.Mvvm.ComponentModel;
using MediatR;
using System.Collections.ObjectModel;
using WinUI.Models.Trips;

namespace WinUI.ViewModels;

public partial class PackTheStuffViewModel : ObservableObject
{
    private readonly IMediator mediator;

    [ObservableProperty] private TripItemListViewModel? selectedItem = default;
    [ObservableProperty] private ObservableCollection<TripItemListViewModel> items = new ();

    public PackTheStuffViewModel(IMediator mediator)
    {
        this.mediator = mediator;
    }
}