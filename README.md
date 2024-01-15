# branch: 2-display-and-organise-data-in-view

### Step 1 Create grid in main window (PackTheStuffView)

<Window
    x:Class="WinUI.Views.PackTheStuffView"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    Title="PackTheStuffView"
    Width="800"
    Height="450"
    DataContext="{d:DesignInstance viewmo}"
    mc:Ignorable="d">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto" /><!--  lists  -->
            <ColumnDefinition Width="*" /><!--  selected list  -->
            <ColumnDefinition Width="Auto" /><!--  items  -->
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
    - has full width (Grid.ColumnSpan="3")

now our window looks like this:
![Alt text](/assets/2-window-1.png)

- add toolbar in second row 

```xml
<ToolBar
    Grid.Row="1"
    Grid.Column="0"
    Grid.ColumnSpan="3">
    <Button Background="Gray">NewTripItem</Button>
    <Button Background="Gray">NewCategory</Button>
    <Button Background="Gray">NewList</Button>
</ToolBar>
```
effect looks like this:

![Alt text](/assets/2-window-2.png)

# Step 3 Displaty trip items lists

