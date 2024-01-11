namespace WinUI.Models.Trips.Models;

public sealed class TripItemList
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<TripItem> Items  { get; set; } = new();
}
