using CommunityToolkit.Mvvm.DependencyInjection;
using System.Windows;
using WinUI.Models.Trips.ViewModels;

namespace WinUI.Views.Trips
{
    /// <summary>
    /// Interaction logic for UpdateTripItemsListView.xaml
    /// </summary>
    public partial class UpdateTripItemsListView : Window
    {
        public UpdateTripItemsListView()
        {
            this.DataContext = Ioc.Default.GetService<UpdateTripItemsListViewModel>();
            InitializeComponent();
        }

        public UpdateTripItemsListViewModel ViewModel => (UpdateTripItemsListViewModel)this.DataContext;
    }
}
