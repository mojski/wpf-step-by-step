This project is a simple application that allows you to generate a list of things you need before traveling.
The main goal of the project is to present the MVVM pattern for beginners. The project will be developed and each stage will be visible on consecutive numbered branches.
the main branch will contain the final appearance of the project identical to the last branch number.
To see what changes have occurred in the project, do not forget to look at the README.md file, all changes will be described there along with the code and comments.

### Step 1 Add ViewModel classes

create three classes inheriting from the ObservableObject 

```csharp
namespace WinUI.Models.Trips.ViewModels;

public partial class TripItemViewModel : ObservableObject
{
    [ObservableProperty] private string name = string.Empty;
    [ObservableProperty] private string storagePlace = string.Empty;
    [ObservableProperty] private string weight = string.Empty;
    [ObservableProperty] private string content = string.Empty;
    [ObservableProperty] private ObservableCollection<TripItemCategoryViewModel> categories = new();
    [ObservableProperty] private int? id = default;
}

public partial class TripItemCategoryViewModel : ObservableObject
{
    [ObservableProperty] private string name = string.Empty;
    [ObservableProperty] private int priority;
    [ObservableProperty] private int? id = default;
}

public partial class TripItemListViewModel : ObservableObject
{
    [ObservableProperty] private string name = string.Empty;
    [ObservableProperty] private string destination = string.Empty;
    [ObservableProperty] private string type = string.Empty;
    [ObservableProperty] private ObservableCollection<TripItemViewModel> items = new();
    [ObservableProperty] private int? id = default;
}
```
notice that:
- view models are public partial classes
- due to convention properties are named with snake case convention
- class inherit from ObservableObject and properties have ObservableProperty attribute and collection are ObservableCollection
that preparation help us to obtain two way comunication and change values from UI to viewModel and back

### Step 2 Create Model classes

```csharp

namespace WinUI.Models.Trips.Models;

public sealed class TripItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string StoragePlace { get; set; } = string.Empty;
    public int Weight { get; set; }
    public string Content { get; set; } = string.Empty;
    public List<TripItemCategory> Categories { get; set; } = new();
}

public sealed class TripItemCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Priority { get; set; }
}

public sealed class TripItemList
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<TripItem> Items  { get; set; } = new();
}
```

### Step 3 prepare main ViewModel to display item

- first create abstraction to hide data persistence layer

```csharp
namespace WinUI.Models.Trips.Interfaces;

public interface ITripRepository
{
    // categories
    Task CreateItemCategoryAsync(TripItemCategory category);
    Task<IEnumerable<TripItemCategory>> GetCategoriesAsync(int categoryId);

    // items
    Task CreateTripItemAsync(TripItem tripItem);
    Task<IEnumerable<TripItem>> GetTripItemsAsync();

    // trips
    Task CreateTripItemList(TripItemList tripItemList);
    Task<IEnumerable<TripItemList>> GetTripItemListsAsync(int tripItemListId);
    Task UpdateTripItemListAsync(TripItemList tripItemList);
}
```

- and its temporary implementation as in memeory repository

### Step 4 prepare in memory fake repository

```csharp
namespace WinUI.Models.Services;

internal class InMemoryTripRepository : ITripRepository
{
    private List<TripItemCategory> categories = new();
    private List<TripItem> items = new();
    private List<TripItemList> trips = new();

    /// <summary>
/// it is temporary test data to develop purposes
/// </summary>
public InMemoryTripRepository()
{
    categories.Add(new TripItemCategory
    {
        Id = 1,
        Name = "Papers",
        Priority = 0,
    });

    categories.Add(new TripItemCategory
    {
        Id = 2,
        Name = "Electronic devices",
        Priority = 0,
    });
}

    public async Task CreateItemCategoryAsync(TripItemCategory category)
    {
        categories.Add(category);
        await Task.CompletedTask;
    }

    public async Task CreateTripItemAsync(TripItem tripItem)
    {
        items.Add(tripItem);
        await Task.CompletedTask;
    }

    public async Task CreateTripItemList(TripItemList tripItemList)
    {
        trips.Add(tripItemList);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<TripItemCategory>> GetCategoriesAsync(int categoryId)
    {
        return categories;
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<TripItemList>> GetTripItemListsAsync(int tripItemListId)
    {
        await Task.CompletedTask;
        return trips;
    }

    public async Task<IEnumerable<TripItem>> GetTripItemsAsync()
    {
        await Task.CompletedTask;
        return items;
    }

    public Task UpdateTripItemListAsync(TripItemList tripItemList)
    {
        var list = trips.FirstOrDefault(trip => trip.Id == tripItemList.Id);

        if (list is null)
        {
            throw new Exception("trip list not found");
        }

        list.Items = tripItemList.Items;
        list.Description = tripItemList.Description;
        list.Name = tripItemList.Name;

        return Task.CompletedTask;
    }
}
```

At the end solution should looks like this
![Alt text](aasets/sln.png)