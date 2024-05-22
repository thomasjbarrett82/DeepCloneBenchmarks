using BenchmarkDotNet.Attributes;
using DotNet.Models;

namespace DotNet;

[MinColumn, MaxColumn, MeanColumn, MedianColumn]
[MemoryDiagnoser]
public class DeepCopyBenchmarks {
    public IEnumerable<object[]> SimpleObjects() {
        yield return new object[] { new SimpleObject() };
    }

    public IEnumerable<object[]> ComplexObjects() {
        yield return new object[] { new ComplexObject() };
    }

    public IEnumerable<object[]> VeryComplexObjects() {
        yield return new object[] { new VeryComplexObject() };
    }

    /* Benchmarks for manual clone */ // TODO ICloneable instead of extension methods?
    [Benchmark]
    [ArgumentsSource(nameof(SimpleObjects))]
    public void ManualSimpleObject(SimpleObject input) {
        input.ManualClone();
    }

    [Benchmark]
    [ArgumentsSource(nameof(ComplexObjects))]
    public void ManualComplexObject(ComplexObject input) {
        input.ManualClone();
    }

    [Benchmark]
    [ArgumentsSource(nameof(VeryComplexObjects))]
    public void ManualVeryComplexObject(VeryComplexObject input) {
        input.ManualClone();
    }

    /* Benchmarks for System.Text.Json */
    [Benchmark]
    [ArgumentsSource(nameof(SimpleObjects))]
    public void SystemTextJsonSimpleObject(SimpleObject input) {
        input.SystemTextJsonClone();
    }

    [Benchmark]
    [ArgumentsSource(nameof(ComplexObjects))]
    public void SystemTextJsonComplexObject(ComplexObject input) {
        input.SystemTextJsonClone();
    }

    [Benchmark]
    [ArgumentsSource(nameof(VeryComplexObjects))]
    public void SystemTextJsonVeryComplexObject(VeryComplexObject input) {
        input.SystemTextJsonClone();
    }

    /* Benchmarks for Newtonsoft.Json */
    [Benchmark]
    [ArgumentsSource(nameof(SimpleObjects))]
    public void NewtonsoftSimpleObject(SimpleObject input) {
        input.NewtonsoftJsonClone();
    }

    [Benchmark]
    [ArgumentsSource(nameof(ComplexObjects))]
    public void NewtonsoftComplexObject(ComplexObject input) {
        input.NewtonsoftJsonClone();
    }

    [Benchmark]
    [ArgumentsSource(nameof(VeryComplexObjects))]
    public void NewtonsoftVeryComplexObject(VeryComplexObject input) {
        input.NewtonsoftJsonClone();
    }

    /* Benchmarks for ValueInjecter */
    [Benchmark]
    [ArgumentsSource(nameof(SimpleObjects))]
    public void ValueInjecterSimpleObject(SimpleObject input) {
        input.InjectionClone();
    }

    [Benchmark]
    [ArgumentsSource(nameof(ComplexObjects))]
    public void ValueInjecterComplexObject(ComplexObject input) {
        input.InjectionClone();
    }

    [Benchmark]
    [ArgumentsSource(nameof(VeryComplexObjects))]
    public void ValueInjecterVeryComplexObject(VeryComplexObject input) {
        input.InjectionClone();
    }

    /* Benchmarks for Expression */
    [Benchmark]
    [ArgumentsSource(nameof(SimpleObjects))]
    public void ExpressionSimpleObject(SimpleObject input) {
        input.ExpressionClone();
    }

    [Benchmark]
    [ArgumentsSource(nameof(ComplexObjects))]
    public void ExpressionComplexObject(ComplexObject input) {
        input.ExpressionClone();
    }

    [Benchmark]
    [ArgumentsSource(nameof(VeryComplexObjects))]
    public void ExpressionVeryComplexObject(VeryComplexObject input) {
        input.ExpressionClone();
    }
}
