using DotNet.Models;

namespace DotNetTest;

[TestClass]
public class DeepCloneTests {
    private readonly DeepCopyBenchmarks _benchmarks = new();

    // [TestMethod]
    // public void CloneInjectionTest_SimpleObject() {
    //     var input = new SimpleObject();
    //     var result = _clone.DeepCopySimpleObject(input);
    //     Assert.IsNotNull(result);
    // }

    // [TestMethod]
    // public void CloneInjectionTest_ComplexObject() {
    //     var input = new ComplexObject();
    //     var result = _clone.DeepCopyComplexObject(input);
    //     Assert.IsNotNull(result);
    // }

    // [TestMethod]
    // public void CloneInjectionTest_VeryComplexObject() {
    //     var input = new VeryComplexObject();
    //     var result = _clone.DeepCopyVeryComplexObject(input);
    //     Assert.IsNotNull(result);
    // }

    // [TestMethod]
    // public void NewtonSoftSerializeTest_SimpleObject() {
    //     var input = new SimpleObject();
    //     var result = _newton.DeepCopySimpleObject(input);
    //     Assert.IsNotNull(result);
    // }

    // [TestMethod]
    // public void NewtonSoftSerializeTest_ComplexObject() {
    //     var input = new ComplexObject();
    //     var result = _newton.DeepCopyComplexObject(input);
    //     Assert.IsNotNull(result);
    // }

    // [TestMethod]
    // public void NewtonSoftSerializeTest_VeryComplexObject() {
    //     var input = new VeryComplexObject();
    //     var result = _newton.DeepCopyVeryComplexObject(input);
    //     Assert.IsNotNull(result);
    // }

    [TestMethod]
    public void SerializeTest_SimpleObject() {
        var input = new SimpleObject();
        _benchmarks.SystemTextJsonSimpleObject(input);
    }

    // [TestMethod]
    // public void SerializeTest_ComplexObject() {
    //     var input = new ComplexObject("System.Text.Json");
    //     _benchmarks.SystemTextJsonComplexObject(input);
    // }

    // [TestMethod]
    // public void SerializeTest_VeryComplexObject() {
    //     var input = new VeryComplexObject("System.Text.Json");
    //     _benchmarks.SystemTextJsonVeryComplexObject(input);
    // }
}