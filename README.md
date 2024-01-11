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
            <!--  lists  -->
            <ColumnDefinition Width="Auto" />
            <!--  selected list  -->
            <ColumnDefinition Width="*" />
            <!--  items  -->
            <ColumnDefinition Width="Auto" />
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <!--  top menu bar  -->
            <RowDefinition Height="Auto" />
            <!--  top tool bar  -->
            <RowDefinition Height="Auto" />
            <!--  data grid  -->
            <RowDefinition Height="*" />
            <!--  bottom status bar  -->
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
    </Grid>
</Window>

now our empty grid should look like this:
![Alt text](/assets/grid_01.png)
