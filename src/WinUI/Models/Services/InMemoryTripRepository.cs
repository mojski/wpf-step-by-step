using WinUI.Models.Interfaces;

namespace WinUI.Models.Services;

internal class InMemoryTripRepository : ITripRepository
{
    private List<TripItemCategory> categories = new();
    private List<TripItem> items = new();
    private List<TripItemList> trips = new();

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
        return trips;
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<TripItem>> GetTripItemsAsync()
    {
        return items;
        await Task.CompletedTask;
    }
}