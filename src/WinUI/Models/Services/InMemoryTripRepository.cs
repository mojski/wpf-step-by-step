using WinUI.Models.Trips.Interfaces;
using WinUI.Models.Trips.Models;

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

    public async Task CreateItemCategoryAsync(TripItemCategory category, CancellationToken cancellation)
    {
        categories.Add(category);
        await Task.CompletedTask;
    }

    public async Task CreateTripItemAsync(TripItem tripItem, CancellationToken cancellation)
    {
        items.Add(tripItem);
        await Task.CompletedTask;
    }

    public async Task CreateTripItemList(TripItemList tripItemList, CancellationToken cancellation)
    {
        trips.Add(tripItemList);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<TripItemCategory>> GetCategoriesAsync(CancellationToken cancellation)
    {
        return categories;
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<TripItemList>> GetTripItemListsAsync(CancellationToken cancellation)
    {
        await Task.CompletedTask;
        return trips;
    }

    public async Task<IEnumerable<TripItem>> GetTripItemsAsync(CancellationToken cancellation)
    {
        await Task.CompletedTask;
        return items;
    }

    public Task UpdateTripItemListAsync(TripItemList tripItemList, CancellationToken cancellation)
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