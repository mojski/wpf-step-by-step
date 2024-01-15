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

- add menu just inside <Grid> component just after row definituions:
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
Most important things here are two data grid attributes: ItemsSource (list of items to display in window) and selectedItem. Both of them are binded by "binding key word" whit pointer to observable property of view model (PackTheStuffViewModel). 
Now our window looks like this:

![Alt text](/assets/2-window-3.png)

it has no daata yet. 


