namespace DotNet.Models;

public class VeryComplexObject
{
    public long Id { get; set; }
    public Guid UniqueId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
    public List<ComplexObject> ComplexObjects { get; set; }
    public List<Guid> Guids { get; set; }
    public List<string> OtherNames { get; set; }
}