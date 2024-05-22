# Deep Clone Benchmarks

Benchmarking different ways of deep cloning objects.

## DotNet

Benchmarking done with [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet).

- Manual cloning the object.
- Serialize and deserialize the object using System.Text.Json.
- Serialize and deserialize the object using Newtonsoft.Json.
- Reflection using CloneInjection in [Omu/ValueInjecter](https://github.com/omuleanu/ValueInjecter).
- Expression Trees using [DeepCloner](https://www.nuget.org/packages/DeepCloner).

### Analysis

- Expression Trees have an initial setup cost, but for repeated cloning it is definitely fastest.
- Manual cloning is generally the fastest clone method for most use cases.
- Reflection is the next fastest clone method.
- Serialization using System.Text.Json is the second slowest clone method.
- Serialization using Newtonsoft.Json is the slowest clone method.

### Results

```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i3-7100U CPU 2.40GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK DotNet 1.0.0+4767dfd92db4492fd2ffef2cc65698f26e0f0680
  [Host] : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2

Job=Dry  Toolchain=InProcessEmitToolchain  IterationCount=100  
LaunchCount=1  RunStrategy=ColdStart  UnrollFactor=1  
WarmupCount=1  

```
| Method                          | input             | Mean        | Error       | StdDev       | Median      | Min        | Max          | Allocated |
|-------------------------------- |------------------ |------------:|------------:|-------------:|------------:|-----------:|-------------:|----------:|
| **ManualComplexObject**             | **ComplexObject**     |   **214.74 μs** |   **116.69 μs** |    **344.06 μs** |   **165.80 μs** | **137.900 μs** |   **3,586.5 μs** |    **6312 B** |
| SystemTextJsonComplexObject     | ComplexObject     | 1,676.89 μs | 4,616.87 μs | 13,612.95 μs |   297.85 μs | 266.200 μs | 136,443.6 μs |   11672 B |
| NewtonsoftComplexObject         | ComplexObject     | 2,764.98 μs | 8,124.96 μs | 23,956.64 μs |   364.45 μs | 248.600 μs | 239,934.7 μs |   18456 B |
| ValueInjecterComplexObject      | ComplexObject     |   373.88 μs |   281.28 μs |    829.35 μs |   209.20 μs | 157.200 μs |   5,768.8 μs |    8480 B |
| ExpressionComplexObject         | ComplexObject     |   911.82 μs | 3,031.01 μs |  8,936.99 μs |    17.90 μs |  10.900 μs |  89,388.0 μs |    1432 B |
| **ManualSimpleObject**              | **SimpleObject**      |    **70.35 μs** |    **10.24 μs** |     **30.21 μs** |    **68.45 μs** |  **46.800 μs** |     **329.3 μs** |    **2904 B** |
| SystemTextJsonSimpleObject      | SimpleObject      |   134.62 μs |    15.49 μs |     45.66 μs |   121.15 μs | 100.700 μs |     505.7 μs |    4688 B |
| NewtonsoftSimpleObject          | SimpleObject      |   258.03 μs |    47.39 μs |    139.73 μs |   242.25 μs | 161.700 μs |   1,487.2 μs |   10976 B |
| ValueInjecterSimpleObject       | SimpleObject      |   109.15 μs |    15.31 μs |     45.13 μs |   104.85 μs |  75.800 μs |     513.5 μs |    3424 B |
| ExpressionSimpleObject          | SimpleObject      |    21.06 μs |    17.29 μs |     50.99 μs |    14.70 μs |   8.400 μs |     521.0 μs |     592 B |
| **ManualVeryComplexObject**         | **VeryComplexObject** |   **228.34 μs** |    **91.26 μs** |    **269.09 μs** |   **175.10 μs** | **101.000 μs** |   **2,710.0 μs** |   **29864 B** |
| SystemTextJsonVeryComplexObject | VeryComplexObject |   512.45 μs |   641.89 μs |  1,892.62 μs |   284.50 μs | 197.600 μs |  19,211.9 μs |   71928 B |
| NewtonsoftVeryComplexObject     | VeryComplexObject | 1,112.70 μs |   541.65 μs |  1,597.08 μs | 1,011.95 μs | 630.000 μs |  16,775.3 μs |  106968 B |
| ValueInjecterVeryComplexObject  | VeryComplexObject |   584.18 μs |   122.70 μs |    361.79 μs |   521.65 μs | 323.900 μs |   3,059.3 μs |   97264 B |
| ExpressionVeryComplexObject     | VeryComplexObject |   122.75 μs |   304.72 μs |    898.46 μs |    34.40 μs |  20.000 μs |   9,017.1 μs |    4208 B |

#### Legends
  
- input  : Value of the 'input' parameter
- Mean   : Arithmetic mean of all measurements
- Median : Value separating the higher half of all measurements (50th percentile)
- Min    : Minimum
- Max    : Maximum
- 1 us   : 1 Microsecond (0.000001 sec)