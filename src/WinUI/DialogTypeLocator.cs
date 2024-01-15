using MvvmDialogs.DialogTypeLocators;
using System.ComponentModel;
using WinUI.Models.Trips.ViewModels;
using WinUI.Views.Trips;

namespace WinUI;

internal sealed class DialogTypeLocator : IDialogTypeLocator
{
    public Type Locate(INotifyPropertyChanged viewModel) => viewModel switch
    {
        null => throw new ArgumentNullException(nameof(viewModel)),
        //register all your dialogs here (must implement IModalDialogViewModel interface
        UpdateTripItemsListViewModel => typeof(UpdateTripItemsListView),
        _ => throw new ArgumentException($"No dialog view type found for view model type {viewModel.GetType()}"),
    };
}
