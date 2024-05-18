using DotNet;
using DotNet.Benchmarks;

namespace DotNetTest;

[TestClass]
public class DeepCloneTests {
    private readonly CloneInjectionTest _clone = new();
    private readonly NewtonSoftSerializeTest _newton = new();
    private readonly SerializeTest _json = new();

    [TestMethod]
    public void ObjectHelper_SimpleObject() {
        var result = ObjectHelper.CreateSimpleObject();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void ObjectHelper_ComplexObject() {
        var result = ObjectHelper.CreateComplexObject();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void ObjectHelper_VeryComplexObject() {
        var result = ObjectHelper.CreateVeryComplexObject();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void CloneInjectionTest_SimpleObject() {
        var result = _clone.DeepCopySimpleObject();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void CloneInjectionTest_ComplexObject() {
        var result = _clone.DeepCopyComplexObject();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void CloneInjectionTest_VeryComplexObject() {
        var result = _clone.DeepCopyVeryComplexObject();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void NewtonSoftSerializeTest_SimpleObject() {
        var result = _newton.DeepCopySimpleObject();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void NewtonSoftSerializeTest_ComplexObject() {
        var result = _newton.DeepCopyComplexObject();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void NewtonSoftSerializeTest_VeryComplexObject() {
        var result = _newton.DeepCopyVeryComplexObject();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void SerializeTest_SimpleObject() {
        var result = _json.DeepCopySimpleObject();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void SerializeTest_ComplexObject() {
        var result = _json.DeepCopyComplexObject();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void SerializeTest_VeryComplexObject() {
        var result = _json.DeepCopyVeryComplexObject();
        Assert.IsNotNull(result);
    }
}