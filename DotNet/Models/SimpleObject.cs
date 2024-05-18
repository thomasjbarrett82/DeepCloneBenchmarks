namespace DotNet.Models;

public class SimpleObject
{
    public long Id { get; set; }
    public Guid UniqueId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int IntValue { get; set; }
    public decimal DecimalValue { get; set; }
    public float FloatValue { get; set; }
}
