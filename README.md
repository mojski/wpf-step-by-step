# branch: 2-display-and-organise-data-in-view

### Step 1 Create grid in main window (PackTheStuffView)

<Window
    x:Class="WinUI.Views.PackTheStuffView"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:viewmodels="clr-namespace:WinUI.ViewModels"
    Title="PackTheStuffView"
    Width="800"
    Height="450"
    d:DataContext="{d:DesignInstance viewmodels:PackTheStuffViewModel,
                                     IsDesignTimeCreatable=True}"
    mc:Ignorable="d">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto" /><!--  lists  -->
            <ColumnDefinition Width="*" /><!--  selected list  -->
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" /><!--  top menu bar  -->
            <RowDefinition Height="Auto" /><!--  top tool bar  -->
            <RowDefinition Height="*" /><!--  data grid  -->
            <RowDefinition Height="Auto" /><!--  bottom status bar  -->
        </Grid.RowDefinitions>
    </Grid>
</Window>

now our empty grid should look like this:
![Alt text](/assets/grid_01.png)

# Step 2 Add grid content

- add menu just inside <Grid> component just after row definitions:
```xml
<Menu
    Grid.Row="0" 
    Grid.Column="0"
    Grid.ColumnSpan="3">
    <MenuItem Header="File">
        <MenuItem>
            <MenuItem.Header>
                <ContentPresenter Content="Load" />
            </MenuItem.Header>
        </MenuItem>
        <MenuItem>
            <MenuItem.Header>
                <ContentPresenter Content="Save" />
            </MenuItem.Header>
        </MenuItem>
        <MenuItem>
            <MenuItem.Header>
                <ContentPresenter Content="Save" />
            </MenuItem.Header>
        </MenuItem>
    </MenuItem>
</Menu>
```
notice that menu has its position in grid:
    - is located in first row (Grid.Row="0")
    - is located in first column (Grid.Column="0")
    - has full width (Grid.ColumnSpan="2")

now our window looks like this:
![Alt text](/assets/2-window-1.png)

- add toolbar in second row 

```xml
<!-- ... xml file content ... -->
<ToolBar
    Grid.Row="1"
    Grid.Column="0"
    Grid.ColumnSpan="3">
    <Button Background="Gray">NewTripItem</Button>
    <Button Background="Gray">NewCategory</Button>
    <Button Background="Gray">NewList</Button>
</ToolBar>
<!-- ... xml file content ... -->
```
effect looks like this:

![Alt text](/assets/2-window-2.png)

# Step 3 Displaty available trips (trip items list)

- add MediatR package to project
- inject mediator to PackTheStuffViewModel:

```csharp
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
```

- notice that our main view model contains two observable properties: list of trips (items) and current displaying trip (selected item)
- then register mediator in App.xaml.cs OnStartup method

```csharp
var assembly = Assembly.GetExecutingAssembly();
services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
```

- just below Toolbar tag add new <Datagrid> element with position Grid.Row = 2 and Grid.Column = 0

```xml
<DataGrid
    Grid.Row="2"
    Grid.Column="0"
    ItemsSource="{Binding Path=Items, Mode=OneWay}"
    SelectedItem="{Binding Path=SelectedItem, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
```
Most important things here are two data grid attributes: ItemsSource (list of items to display in window) and selectedItem. Both of them are bound by "binding key word" with pointer to observable property of view model (PackTheStuffViewModel). 
Now our window looks like this:

![Alt text](/assets/2-window-3.png)

it has no data yet. We need to add some.

# Step 4 Add trip command 

- add command property to PackTheStuffViewModel

```csharp
public IAsyncRelayCommand AddTripItemsListCommand{ get; }
```

- add method run on command

```csharp
private async Task AddTripItemsListAsync(CancellationToken cancellationToken = default)
{
    throw new NotImplementedException();
}
```

- instantiate AddTripItemsList in view model constructor:

```csharp
public PackTheStuffViewModel(IMediator mediator)
{
    this.mediator = mediator;

    this.AddTripItemsListCommand = new AsyncRelayCommand(this.AddTripItemsListAsync);
}
```
- bind command to button in view xaml file

```xml
<Button Background="Salmon" Command="{Binding Path=AddTripItemsListCommand}">NewList</Button>
```
for now clicking "NewList" button will throw NotImplementedException. We need an implementation. Clicking button should display new window with inputs to populate data needed to create new trip items list. 

# Step 5 Use Mvvm Dialogs package and display trip items list editor

- create class UpdateTripItemsListViewModel in Models/Trips/ViewModels directory
view model should be observable object and implement IModalDialogViewModel interface. This interface has only one boolean property DialogResult (success or not) 

```csharp
namespace WinUI.Models.Trips.ViewModels
{
    public partial class UpdateTripItemsListViewModel : ObservableObject, IModalDialogViewModel
    {
        [ObservableProperty] private TripItemListViewModel? item = default;
        public bool? DialogResult { get; private set; } = default;
    }
}
```
- register viewModel in App.xaml.cs:
```csharp
services.AddSingleton<UpdateTripItemsListViewModel>();
```
- create folder Trips inside Views directory
- create view UpdateTripItemsListView by clicking on Trips directory (add -> "Window (WPF)")
- go to added window and in generated window xaml tag add namespaces:

```
xmlns:viewmodels="clr-namespace:WinUI.Models.Trips.ViewModels"
d:DataContext="{d:DesignInstance viewmodels:UpdateTripItemsListViewModel,
                                 IsDesignTimeCreatable=True}"

xmlns:md="https://github.com/fantasticfiasco/mvvm-dialogs"
md:DialogServiceViews.IsRegistered="True"
```

- in main window (PackTheStuffView) register service view by add attributes:
```
xmlns:md="https://github.com/fantasticfiasco/mvvm-dialogs"
md:DialogServiceViews.IsRegistered="True"
```

- add DialogTypeLocator class (main catalog)
DialogTypeLocator class will configure which window will be displayed by which view model

```csharp
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
```
- register it in App.xaml.cs:
```csharp
services.AddSingleton<IDialogTypeLocator, DialogTypeLocator>();
```
- add text input to UpdateTripItemsListView window 

```xml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto" />
        <RowDefinition Height="Auto" />
        <RowDefinition Height="Auto" />
        <RowDefinition Height="Auto" />
    </Grid.RowDefinitions>
    <Label Grid.Row="0" Content="Trip items list" />
    <Label
        Grid.Row="1"
        VerticalAlignment="Center"
        Content="Name :" />
    <TextBox
        Grid.Row="1"
        VerticalContentAlignment="Center"
        Text="{Binding Path=Name, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
    <Label
        Grid.Row="2"
        VerticalAlignment="Center"
        Content="Name :" />
    <TextBox
        Grid.Row="2"
        VerticalContentAlignment="Center"
        Text="{Binding Path=Destination, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
    <Label
        Grid.Row="3"
        VerticalAlignment="Center"
        Content="Name :" />
    <TextBox
        Grid.Row="3"
        VerticalContentAlignment="Center"
        Text="{Binding Path=Type, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
</Grid>
```

with following code behind:

```csharp
public partial class UpdateTripItemsListView : Window
{
    public UpdateTripItemsListView()
    {
        this.DataContext = Ioc.Default.GetService<UpdateTripItemsListViewModel>();
        InitializeComponent();
    }

    public UpdateTripItemsListViewModel ViewModel => (UpdateTripItemsListViewModel)this.DataContext;
}
```

- add trigger to show trip items list editor to AddTripItemsListCommand 

first we need register and inject 

```csharp
// App.xaml:
services.AddSingleton<IDialogService, DialogService>();

// in  PackTheStuffViewModel
//...
private readonly IDialogService dialogService;

public PackTheStuffViewModel(IMediator mediator, IDialogService dialogService)
{
    //...
    this.dialogService = dialogService;
   //...
}
```

change throw new NotImplementedException(); to code:

```csharp
private async Task AddTripItemsListAsync(CancellationToken cancellationToken = default)
{
    var emptyModel = new TripItemListViewModel();

    var viewModel = new UpdateTripItemsListViewModel() { Item = emptyModel };

    var result = this.dialogService.ShowDialog(this, viewModel);
}
```
After run the application and clicking NewList button result should looks like this:

![Alt text](/assets/2-window-3.png)

There is no further action in next branch we will add OK and Cancel button with respective actions. 

