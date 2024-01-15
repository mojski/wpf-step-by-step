using WinUI.Models.Trips.Models;

namespace WinUI.Models.Trips.Interfaces;

public interface ITripRepository
{
    // categories
    Task CreateItemCategoryAsync(TripItemCategory category, CancellationToken cancellation);
    Task<IEnumerable<TripItemCategory>> GetCategoriesAsync(CancellationToken cancellation);

    // items
    Task CreateTripItemAsync(TripItem tripItem, CancellationToken cancellation);
    Task<IEnumerable<TripItem>> GetTripItemsAsync(CancellationToken cancellation);

    // trips
    Task CreateTripItemList(TripItemList tripItemList, CancellationToken cancellation);
    Task<IEnumerable<TripItemList>> GetTripItemListsAsync(CancellationToken cancellation);
    Task UpdateTripItemListAsync(TripItemList tripItemList, CancellationToken cancellation);
}
