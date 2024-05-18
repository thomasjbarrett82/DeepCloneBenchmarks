using DotNet.Models;

namespace DotNet.Benchmarks;

public interface IDeepCopy
{
    SimpleObject DeepCopySimpleObject();
    ComplexObject DeepCopyComplexObject();
    VeryComplexObject DeepCopyVeryComplexObject();
}