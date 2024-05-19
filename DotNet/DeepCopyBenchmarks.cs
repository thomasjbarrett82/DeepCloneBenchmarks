using BenchmarkDotNet.Attributes;
using DotNet;
using DotNet.Models;

using Newton = Newtonsoft.Json;
using Omu.ValueInjecter;
using Json = System.Text.Json;

[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class DeepCopyBenchmarks {
    private readonly SimpleObject _simple;

    public DeepCopyBenchmarks() {
        _simple = new SimpleObject();
    }

    public IEnumerable<object[]> SystemTextJsonSimpleObjects() {
        yield return new object[] { _simple };
    }

    public IEnumerable<object[]> SystemTextJsonComplexObjects() {
        yield return new object[] { new ComplexObject() };
    }

    public IEnumerable<object[]> SystemTextJsonVeryComplexObjects() {
        yield return new object[] { new VeryComplexObject() };
    }

    /* Benchmarks for System.Text.Json */
    [Benchmark]
    [ArgumentsSource(nameof(SystemTextJsonSimpleObjects))]
    public SimpleObject SystemTextJsonSimpleObject(SimpleObject input) {
        var str = Json.JsonSerializer.Serialize(input);
        return Json.JsonSerializer.Deserialize<SimpleObject>(str);
    }

    [Benchmark]
    [ArgumentsSource(nameof(SystemTextJsonComplexObjects))]
    public void SystemTextJsonComplexObject(ComplexObject input) {
        var str = Json.JsonSerializer.Serialize(input);
        Json.JsonSerializer.Deserialize<ComplexObject>(str);
    }

    [Benchmark]
    [ArgumentsSource(nameof(SystemTextJsonVeryComplexObjects))]
    public void SystemTextJsonVeryComplexObject(VeryComplexObject input) {
        var str = Json.JsonSerializer.Serialize(input);
        Json.JsonSerializer.Deserialize<VeryComplexObject>(str);
    }

    /* Benchmarks for Newtonsoft.Json */
    // [Benchmark]
    // [ArgumentsSource(nameof(SimpleObjects))]
    // public void NewtonsoftSimpleObject(SimpleObject input) {
    //     input.NewtonsoftJsonClone();
    // }

    // [Benchmark]
    // [ArgumentsSource(nameof(ComplexObjects))]
    // public void NewtonsoftComplexObject(ComplexObject input) {
    //     input.NewtonsoftJsonClone();
    // }

    // [Benchmark]
    // [ArgumentsSource(nameof(VeryComplexObjects))]
    // public void NewtonsoftVeryComplexObject(VeryComplexObject input) {
    //     input.NewtonsoftJsonClone();
    // }

    /* Benchmarks for ValueInjecter */
//     [Benchmark]
//     [ArgumentsSource(nameof(SimpleObjects))]
//     public override void DeepCopySimpleObject(SimpleObject input) {
//         input.InjectionClone();
//     }

//     [Benchmark]
//     [ArgumentsSource(nameof(ComplexObjects))]
//     public override void DeepCopyComplexObject(ComplexObject input) {
//         input.InjectionClone();
//     }

//     [Benchmark]
//     [ArgumentsSource(nameof(VeryComplexObjects))]
//     public override void DeepCopyVeryComplexObject(VeryComplexObject input) {
//         input.InjectionClone();
//     }
}
