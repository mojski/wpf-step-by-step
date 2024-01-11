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
