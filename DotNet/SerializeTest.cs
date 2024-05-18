using BenchmarkDotNet.Attributes;
using System.Text.Json;

namespace DotNet;

public class SerializeTest {
    private SimpleObject _simple = ObjectHelper.CreateSimpleObject();
    private ComplexObject _complex = ObjectHelper.CreateComplexObject();
    private VeryComplexObject _veryComplex = ObjectHelper.CreateVeryComplexObject();

    [Benchmark]
    public SimpleObject SerializeSimpleObject() {
        var str = JsonSerializer.Serialize(_simple);
        return JsonSerializer.Deserialize<SimpleObject>(str);
    }

    [Benchmark]
    public ComplexObject SerializeComplexObject() {
        var str = JsonSerializer.Serialize(_complex);
        return JsonSerializer.Deserialize<ComplexObject>(str);
    }

    [Benchmark]
    public VeryComplexObject SerializeVeryComplexObject() {
        var str = JsonSerializer.Serialize(_veryComplex);
        return JsonSerializer.Deserialize<VeryComplexObject>(str);
    }
}
