using BenchmarkDotNet.Attributes;
using DotNet.Models;

namespace DotNet.Benchmarks;

public class SerializeTest : IDeepCopy {
    private SimpleObject _simple = ObjectHelper.CreateSimpleObject();
    private ComplexObject _complex = ObjectHelper.CreateComplexObject();
    private VeryComplexObject _veryComplex = ObjectHelper.CreateVeryComplexObject();

    [Benchmark]
    public SimpleObject DeepCopySimpleObject() {
        return _simple.SystemTextJsonClone();
    }

    [Benchmark]
    public ComplexObject DeepCopyComplexObject() {
        return _complex.SystemTextJsonClone();
    }

    [Benchmark]
    public VeryComplexObject DeepCopyVeryComplexObject() {
        return _veryComplex.SystemTextJsonClone();
    }
}
