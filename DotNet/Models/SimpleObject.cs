namespace DotNet.Models;

public class SimpleObject : BaseObject {
    public SimpleObject(string benchmarkName) : base(benchmarkName) {
        var _random = new Random();
        StartDate = ObjectHelper.RandomDay();
        EndDate = ObjectHelper.RandomDay();
        IntValue = _random.Next();
        DecimalValue = ObjectHelper.RandomDecimal();
        FloatValue = _random.NextSingle();
    }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int IntValue { get; set; }
    public decimal DecimalValue { get; set; }
    public float FloatValue { get; set; }

    public override string ToString() {
        return $"{nameof(SimpleObject)} - {BenchmarkName}";
    }
}
