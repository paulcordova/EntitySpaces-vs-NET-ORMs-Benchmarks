```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                          | Mean     | Error     | StdDev    | Median   | Allocated |
|-------------------------------- |---------:|----------:|----------:|---------:|----------:|
| &#39;Insert 1 Product EntitySpaces&#39; | 77.85 ms | 347.44 ms | 229.81 ms | 5.232 ms | 786.55 KB |
