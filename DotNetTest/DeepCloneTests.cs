using DotNet;
using DotNet.Models;

namespace DotNetTest;

[TestClass]
public class DeepCloneTests {
    [TestMethod]
    public void CloneInjectionTest_SimpleObject() {
        var input = new SimpleObject();
        var result = input.InjectionClone();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void CloneInjectionTest_ComplexObject() {
        var input = new ComplexObject();
        var result = input.InjectionClone();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void CloneInjectionTest_VeryComplexObject() {
        var input = new VeryComplexObject();
        var result = input.InjectionClone();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void NewtonSoftSerializeTest_SimpleObject() {
        var input = new SimpleObject();
        var result = input.NewtonsoftJsonClone();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void NewtonSoftSerializeTest_ComplexObject() {
        var input = new ComplexObject();
        var result = input.NewtonsoftJsonClone();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void NewtonSoftSerializeTest_VeryComplexObject() {
        var input = new VeryComplexObject();
        var result = input.NewtonsoftJsonClone();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void SerializeTest_SimpleObject() {
        var input = new SimpleObject();
        var result = input.SystemTextJsonClone();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void SerializeTest_ComplexObject() {
        var input = new ComplexObject();
        var result = input.SystemTextJsonClone();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void SerializeTest_VeryComplexObject() {
        var input = new VeryComplexObject();
        var result = input.SystemTextJsonClone();
        Assert.IsNotNull(result);
    }

    // [TestMethod]
    // public void ExpressionTest_SimpleObject() {
    //     var input = new SimpleObject();
    //     var result = input.ExpressionClone();
    //     Assert.IsNotNull(result);
    // }

    // [TestMethod]
    // public void ExpressionTest_ComplexObject() {
    //     var input = new ComplexObject();
    //     var result = input.ExpressionClone();
    //     Assert.IsNotNull(result);
    // }

    // [TestMethod]
    // public void ExpressionTest_VeryComplexObject() {
    //     var input = new VeryComplexObject();
    //     var result = input.ExpressionClone();
    //     Assert.IsNotNull(result);
    // }
}