namespace DotNet.Models;

public class BaseObject {
    public BaseObject(string benchmarkName) {
        var _random = new Random();

        Id = _random.NextInt64();
        UniqueId = Guid.NewGuid();
        Name = ObjectHelper.RandomString();
        Description = ObjectHelper.RandomString();
        Comment = ObjectHelper.RandomString();
        BenchmarkName = benchmarkName;
    }

    public long Id { get; set; }
    public Guid UniqueId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
    public string BenchmarkName { get; set; }
}