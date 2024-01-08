This project is a simple application that allows you to generate a list of things you need before traveling.
The main goal of the project is to present the MVVM pattern for beginners. The project will be developed and each stage will be visible on consecutive numbered branches.
the main branch will contain the final appearance of the project identical to the last branch number.
To see what changes have occurred in the project, do not forget to look at the README.md file, all changes will be described there along with the code and comments.

### Step 1 Add Model classes

create three classes inheriting from the ObservableObject class that constitute our business model

```csharp
namespace WinUI.Models;

public partial class TripItem : ObservableObject
{
    [ObservableProperty] private string name = string.Empty;
    [ObservableProperty] private string storagePlace = string.Empty;
    [ObservableProperty] private string weight = string.Empty;
    [ObservableProperty] private string content = string.Empty;
    [ObservableProperty] private ObservableCollection<int> categories = new();
    [ObservableProperty] private int? id = default;
}

public partial class TripItemCategory : ObservableObject
{
    [ObservableProperty] private string name = string.Empty;
    [ObservableProperty] private string priority = string.Empty;
    [ObservableProperty] private int? id = default;
}

public partial class TripItemList : ObservableObject
{
    [ObservableProperty] private string name = string.Empty;
    [ObservableProperty] private string destination = string.Empty;
    [ObservableProperty] private string type = string.Empty;
    [ObservableProperty] private ObservableCollection<int> items = new();
    [ObservableProperty] private int? id = default;
}
```

### Step prepare ViewModel to display item

- first create abstraction to hide data persistence layer

```csharp
namespace WinUI.Models.Interfaces;

internal interface ITripRepository
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
}
```

- and its temporary implementation as in memeory repository





