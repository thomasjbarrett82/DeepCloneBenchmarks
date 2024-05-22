using DotNet;
using DotNet.Models;
using Force.DeepCloner;
using System.Text.Json;

namespace DotNetTest;

[TestClass]
public class DeepCloneTests {
    /* manual tests */
    [TestMethod]
    public void ManualTest_SimpleObject() {
        var input = new SimpleObject();
        var result = input.ManualClone();
        Assert.IsNotNull(result);
        Assert.IsFalse(input.Equals(result));
        Assert.AreEqual(JsonSerializer.Serialize(input), JsonSerializer.Serialize(result));
    }

    [TestMethod]
    public void ManualTest_ComplexObject() {
        var input = new ComplexObject();
        var result = input.ManualClone();
        Assert.IsNotNull(result);
        Assert.AreEqual(JsonSerializer.Serialize(input), JsonSerializer.Serialize(result));
    }

    [TestMethod]
    public void ManualTest_VeryComplexObject() {
        var input = new VeryComplexObject();
        var result = input.ManualClone();
        Assert.IsNotNull(result);
        Assert.AreEqual(JsonSerializer.Serialize(input), JsonSerializer.Serialize(result));
    }

    /* Value Injector tests */
    [TestMethod]
    public void CloneInjectionTest_SimpleObject() {
        var input = new SimpleObject();
        var result = input.InjectionClone();
        Assert.IsNotNull(result);
        Assert.AreEqual(JsonSerializer.Serialize(input), JsonSerializer.Serialize(result));
    }

    [TestMethod]
    public void CloneInjectionTest_ComplexObject() {
        var input = new ComplexObject();
        var result = input.InjectionClone();
        Assert.IsNotNull(result);
        Assert.AreEqual(JsonSerializer.Serialize(input), JsonSerializer.Serialize(result));
    }

    [TestMethod]
    public void CloneInjectionTest_VeryComplexObject() {
        var input = new VeryComplexObject();
        var result = input.InjectionClone();
        Assert.IsNotNull(result);
        Assert.AreEqual(JsonSerializer.Serialize(input), JsonSerializer.Serialize(result));
    }

    /* Newtonsoft tests */
    [TestMethod]
    public void NewtonSoftSerializeTest_SimpleObject() {
        var input = new SimpleObject();
        var result = input.NewtonsoftJsonClone();
        Assert.IsNotNull(result);
        // not comparing Newtonsoft because it adds a trailing zero to decimals
    }

    [TestMethod]
    public void NewtonSoftSerializeTest_ComplexObject() {
        var input = new ComplexObject();
        var result = input.NewtonsoftJsonClone();
        Assert.IsNotNull(result);
        // not comparing Newtonsoft because it adds a trailing zero to decimals
    }

    [TestMethod]
    public void NewtonSoftSerializeTest_VeryComplexObject() {
        var input = new VeryComplexObject();
        var result = input.NewtonsoftJsonClone();
        Assert.IsNotNull(result);
        // not comparing Newtonsoft because it adds a trailing zero to decimals
    }

    /* System.Text.Json tests */
    [TestMethod]
    public void SerializeTest_SimpleObject() {
        var input = new SimpleObject();
        var result = input.SystemTextJsonClone();
        Assert.IsNotNull(result);
        Assert.AreEqual(JsonSerializer.Serialize(input), JsonSerializer.Serialize(result));
    }

    [TestMethod]
    public void SerializeTest_ComplexObject() {
        var input = new ComplexObject();
        var result = input.SystemTextJsonClone();
        Assert.IsNotNull(result);
        Assert.AreEqual(JsonSerializer.Serialize(input), JsonSerializer.Serialize(result));
    }

    [TestMethod]
    public void SerializeTest_VeryComplexObject() {
        var input = new VeryComplexObject();
        var result = input.SystemTextJsonClone();
        Assert.IsNotNull(result);
        Assert.AreEqual(JsonSerializer.Serialize(input), JsonSerializer.Serialize(result));
    }

    /* DeepCloner tests */
    [TestMethod]
    public void DeepClonerTest_SimpleObject() {
        var input = new SimpleObject();
        var result = input.DeepClone();
        Assert.IsNotNull(result);
        Assert.AreEqual(JsonSerializer.Serialize(input), JsonSerializer.Serialize(result));
    }

    [TestMethod]
    public void DeepClonerTest_ComplexObject() {
        var input = new ComplexObject();
        var result = input.DeepClone();
        Assert.IsNotNull(result);
        Assert.AreEqual(JsonSerializer.Serialize(input), JsonSerializer.Serialize(result));
    }

    [TestMethod]
    public void DeepClonerTest_VeryComplexObject() {
        var input = new VeryComplexObject();
        var result = input.DeepClone();
        Assert.IsNotNull(result);
        Assert.AreEqual(JsonSerializer.Serialize(input), JsonSerializer.Serialize(result));
    }
}