# Deep Clone Benchmarks

Benchmarking different ways of deep cloning objects.

## DotNet

Benchmarking done with [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet).

- Manual cloning the object.
- Serialize and deserialize the object using System.Text.Json.
- Serialize and deserialize the object using Newtonsoft.Json.
- CloneInjection using [Omu/ValueInjecter](https://github.com/omuleanu/ValueInjecter).
- Expression Trees using [DeepCloner](https://www.nuget.org/packages/DeepCloner).

### Results

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i3-7100U CPU 2.40GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK DotNet 1.0.0+c79b82b954b8eaddc955861090c4c6b259c27d89
Host : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2

Job=Dry  Toolchain=InProcessEmitToolchain  IterationCount=100  
LaunchCount=1  RunStrategy=ColdStart  UnrollFactor=1  
WarmupCount=1  

| Method                          | input             | Mean        | Median    | Min        | Max          |
|-------------------------------- |------------------ |------------:|----------:|-----------:|-------------:|
| ManualSimpleObject              | SimpleObject      |    79.12 us |  74.65 us |  53.200 us |     323.8 us |
| SystemTextJsonSimpleObject      | SimpleObject      |   161.44 us | 144.30 us | 111.400 us |     745.3 us |
| NewtonsoftSimpleObject          | SimpleObject      |   212.48 us | 190.80 us | 157.300 us |     963.3 us |
| ValueInjecterSimpleObject       | SimpleObject      |   111.43 us | 105.55 us |  77.200 us |     520.9 us |
| ExpressionSimpleObject          | SimpleObject      |    17.59 us |  13.15 us |   7.500 us |     422.3 us |
| ManualComplexObject             | ComplexObject     |   194.61 us | 154.35 us | 118.000 us |   3,554.5 us |
| SystemTextJsonComplexObject     | ComplexObject     | 1,262.17 us | 229.90 us | 183.900 us | 101,813.3 us |
| NewtonsoftComplexObject         | ComplexObject     | 2,047.94 us | 311.55 us | 230.200 us | 172,179.0 us |
| ValueInjecterComplexObject      | ComplexObject     |   325.62 us | 210.30 us | 176.700 us |   4,591.7 us |
| ExpressionComplexObject         | ComplexObject     |   241.91 us |  17.70 us |   9.600 us |  22,395.2 us |
| ManualVeryComplexObject         | VeryComplexObject |   263.57 us | 225.20 us | 157.500 us |   2,687.9 us |
| SystemTextJsonVeryComplexObject | VeryComplexObject |   792.01 us | 534.90 us | 367.200 us |  17,084.9 us |
| NewtonsoftVeryComplexObject     | VeryComplexObject |   699.00 us | 490.75 us | 406.700 us |  14,405.9 us |
| ValueInjecterVeryComplexObject  | VeryComplexObject |   467.76 us | 367.50 us | 269.100 us |   2,985.4 us |
| ExpressionVeryComplexObject     | VeryComplexObject |    89.58 us |  35.70 us |  21.700 us |   5,575.0 us |

#### Legends
  input  : Value of the 'input' parameter
  Mean   : Arithmetic mean of all measurements
  Median : Value separating the higher half of all measurements (50th percentile)
  Min    : Minimum
  Max    : Maximum
  1 us   : 1 Microsecond (0.000001 sec)