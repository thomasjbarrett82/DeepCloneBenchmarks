# Deep Clone Benchmarks

Benchmarking different ways of deep cloning objects.

## DotNet

Benchmarking done with [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet).

- Serialize and deserialize the object using System.Text.Json.
- Serialize and deserialize the object using Newtonsoft.Json.
- CloneInjection using [Omu/ValueInjecter](https://github.com/omuleanu/ValueInjecter).
- TODO: IL using https://whizzodev.blogspot.com/2008/03/object-cloning-using-il-in-c.html
- TODO: ICloneable using https://www.codeproject.com/Articles/3441/Base-class-for-cloning-an-object-in-C
- TODO: Expression Trees using https://www.codeproject.com/Articles/1111658/Fast-Deep-Copy-by-Expression-Trees-C-Sharp
- TODO: DeepCloner package https://www.nuget.org/packages/DeepCloner 

### Results

- Windows 10 x64, .NET Core 8.0, i3-7100U CPU, 8 GB RAM, 500 GB SSD
- TODO 