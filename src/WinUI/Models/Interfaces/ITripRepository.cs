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
