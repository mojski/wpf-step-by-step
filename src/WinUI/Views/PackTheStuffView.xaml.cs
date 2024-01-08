using CommunityToolkit.Mvvm.DependencyInjection;
using System.Windows;
using WinUI.ViewModels;

namespace WinUI.Views
{
    /// <summary>
    /// Interaction logic for PackTheStuffView.xaml
    /// </summary>
    public partial class PackTheStuffView : Window
    {
        public PackTheStuffViewModel ViewModel => (PackTheStuffViewModel)this.DataContext;
        public PackTheStuffView()
        {
            InitializeComponent();
            this.DataContext = Ioc.Default.GetService<PackTheStuffViewModel>();
        }
    }
}
