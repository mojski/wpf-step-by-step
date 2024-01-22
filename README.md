# branch: 3-create-trip-items-list-ok-or-cancel-commands

# Step 1 Cancel button - add close window behavior 

- in main directory add Behaviors directory and class inside:

```csharp
public static class WindowBehavior
{
    private static readonly Type ownerType = typeof(WindowBehavior);

    public static readonly DependencyProperty CloseProperty =
    DependencyProperty.RegisterAttached(
        "Close",
        typeof(bool),
        ownerType,
        new UIPropertyMetadata(defaultValue: false, (sender, e) =>
        {
            if (!(e.NewValue is bool) || !(bool)e.NewValue)
            {
                return;
            }

            Window? window = sender as Window ?? Window.GetWindow(sender);

            window?.Close();
        }));

    [AttachedPropertyBrowsableForType(typeof(Window))] // add SetCloseAction to any window class 
    public static void SetClose(DependencyObject target, bool value)
    {
        target.SetValue(CloseProperty, value);
    }
}
```
You will need to implement it once. 

- add is close property to dialog window view model (UpdateTripItemsListViewModel):

```csharp
[ObservableProperty] private bool isClosed = default;
// ...
public IAsyncRelayCommand CancelCommand { get; }
```
- in same file add CancelAsync method 

```csharp
private async Task CancelAsync(CancellationToken cancellationToken = default)
{
    this.DialogResult = false;
    this.IsClosed = true;
    await Task.CompletedTask;
}
```
- in constructor create command:

```csharp
public UpdateTripItemsListViewModel()
{
    this.CancelCommand = new AsyncRelayCommand(this.CancelAsync);
}
```

- bind window behavior to UpdateTripItemsListView:

```xml

<!-- ... window tag... -->
<Window.Style>
    <Style>
        <Style.Triggers>
            <DataTrigger Binding="{Binding Path=IsClosed}" Value="true">
                <Setter Property="behaviors:WindowBehavior.Close" Value="true" />
            </DataTrigger>
        </Style.Triggers>
    </Style>
</Window.Style>
<!-- ... Grid ... -->
```
Don't forget to add behavior namespace in window tag: 
```
xmlns:behaviors="clr-namespace:WinUI.Behaviors"
```
- add cancel OK and Cancel button in UpdateTripItemsListView with binding

```xml
<!-- ... grid items... -->
<StackPanel Grid.Row="7">
    <Button Content="OK" />
    <Button Command="{Binding Path=CancelCommand}" Content="Cancel" />
</StackPanel>
```
for now it will close window after clicking "Cancel". Then we need to implement Ok command. 




