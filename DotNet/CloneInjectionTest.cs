using BenchmarkDotNet.Attributes;
using Omu.ValueInjecter;

namespace DotNet;

public class CloneInjectionTest {
    private SimpleObject _simple = ObjectHelper.CreateSimpleObject();
    private ComplexObject _complex = ObjectHelper.CreateComplexObject();
    private VeryComplexObject _veryComplex = ObjectHelper.CreateVeryComplexObject();

    [Benchmark]
    public SimpleObject CloneInjectSimpleObject() {
        var result = new SimpleObject();
        result.InjectFrom<CloneInjection>(_simple);
        return result;
    }

    [Benchmark]
    public ComplexObject CloneInjectComplexObject() {
        var result = new ComplexObject();
        result.InjectFrom<CloneInjection>(_complex);
        return result;
    }

    [Benchmark]
    public VeryComplexObject CloneInjectVeryComplexObject() {
        var result = new VeryComplexObject();
        result.InjectFrom<CloneInjection>(_veryComplex);
        return result;
    }
}