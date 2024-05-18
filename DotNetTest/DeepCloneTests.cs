using DotNet;

namespace DotNetTest; 

[TestClass]
public class DeepCloneTests {
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
}