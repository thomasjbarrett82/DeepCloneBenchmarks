namespace DotNet;

public class ComplexObject {
    public long Id { get; set; }
    public Guid UniqueId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
    public SimpleObject Object { get; set; }
    public List<DateTime> DateTimes { get; set; }
}
